
module wasm.write

    open wasm.def
    open wasm.write_basic
    open wasm.write_instr

    let write_name w (s : string) =
        let len = System.Text.Encoding.UTF8.GetByteCount(s)
        let ba = Array.zeroCreate len
        let len2 = System.Text.Encoding.UTF8.GetBytes(s, 0, s.Length, ba, 0)
        write_var_int w len
        write_blob w ba
    
    let write_magic w =
        write_byte w 0x00uy
        write_byte w 0x61uy
        write_byte w 0x73uy
        write_byte w 0x6Duy

    let write_custom_section w s =
        write_name w s.name
        write_blob w s.data
        0uy

    let write_valtype w vt =
        let b =
            match vt with
            | I32 -> 0x7Fuy
            | I64 -> 0x7Euy
            | F32 -> 0x7Duy
            | F64 -> 0x7Cuy
        write_byte w b

    let write_limits w lim =
        match lim with
        | Min min ->
            write_byte w 0x00uy
            write_var_uint32 w min
        | MinMax (min,max) -> 
            write_byte w 0x01uy
            write_var_uint32 w min
            write_var_uint32 w max

    let write_functype w ft =
        write_byte w 0x60uy
        write_var_int w ft.parms.Length
        for t in ft.parms do
            write_valtype w t
        write_var_int w ft.result.Length
        for t in ft.result do
            write_valtype w t

    let write_expr w e =
        for op in e do
            write_instruction w op

    let write_elemtype w t =
        match t with
        | FuncRef -> write_byte w 0x70uy

    let write_table_item w t =
        write_elemtype w t.elemtype
        write_limits w t.limits

    let write_memory_item w t =
        write_limits w t.limits

    let write_bool w b =
        match b with
        | true -> write_byte w 0x01uy
        | false -> write_byte w 0x00uy

    let write_globaltype w g =
        write_valtype w g.typ
        write_bool w g.mut
        
    let write_global_item w g =
        write_globaltype w g.globaltype
        write_expr w g.expr

    let write_importdesc w d =
        match d with
        | TypeIdx i ->
            write_byte w 0x00uy
            write_var_uint32 w i
        | TableType t ->
            write_byte w 0x01uy
            write_table_item w t
        | MemType t ->
            write_byte w 0x02uy
            write_memory_item w t
        | GlobalType t ->
            write_byte w 0x03uy
            write_globaltype w t

    let write_import_item w it =
        write_name w it.m
        write_name w it.name
        write_importdesc w it.desc

    let write_function_item w tidx =
        write_var_uint32 w tidx

    let write_exportdesc w d =
        match d with
        | FuncIdx i -> 
            write_byte w 0x00uy
            write_var_uint32 w i
        | TableIdx i -> 
            write_byte w 0x01uy
            write_var_uint32 w i
        | MemIdx i -> 
            write_byte w 0x02uy
            write_var_uint32 w i
        | GlobalIdx i -> 
            write_byte w 0x03uy
            write_var_uint32 w i

    let write_export_item w (it : ExportItem) =
        write_name w it.name
        write_exportdesc w it.desc

    let write_element_item w it =
        write_var_uint32 w it.tableidx
        write_expr w it.expr
        write_var_int w it.init.Length
        for x in it.init do
            write_var_uint32 w x

    let write_local w loc =
        write_var_uint32 w loc.n
        write_valtype w loc.valtype

    let write_code_item w it =
        write_var_int w it.locals.Length
        for loc in it.locals do
            write_local w loc
        write_expr w it.expr

    let write_data_item w it =
        write_var_uint32 w it.memidx
        write_expr w it.expr
        write_blob w it.init

    let write_type_section w s =
        write_var_int w s.types.Length
        for it in s.types do
            write_functype w it
        1uy

    let write_import_section w s =
        write_var_int w s.imports.Length
        for it in s.imports do
            write_import_item w it
        2uy

    let write_function_section w s =
        write_var_int w s.funcs.Length
        for it in s.funcs do
            write_function_item w it
        3uy

    let write_table_section w s =
        write_var_int w s.tables.Length
        for it in s.tables do
            write_table_item w it
        4uy

    let write_memory_section w s =
        write_var_int w s.mems.Length
        for it in s.mems do
            write_memory_item w it
        5uy

    let write_global_section w s =
        write_var_int w s.globals.Length
        for it in s.globals do
            write_global_item w it
        6uy

    let write_export_section w s =
        write_var_int w s.exports.Length
        for it in s.exports do
            write_export_item w it
        7uy

    let write_start_section w s =
        8uy

    let write_element_section w s =
        write_var_int w s.elems.Length
        for it in s.elems do
            write_element_item w it
        9uy

    let write_code_section w s =
        write_var_int w s.codes.Length
        for it in s.codes do
            use ms = new System.IO.MemoryStream()
            use sub = new System.IO.BinaryWriter(ms)
            write_code_item sub it
            let ba = ms.ToArray()
            write_var_int w ba.Length
            write_blob w ba
        10uy

    let write_data_section w s =
        write_var_int w s.datas.Length
        for it in s.datas do
            write_data_item w it
        11uy

    let create_section_contents s =
        use ms = new System.IO.MemoryStream()
        use sub = new System.IO.BinaryWriter(ms)
        let id =
            match s with
            | Custom s -> write_custom_section sub s
            | Type s -> write_type_section sub s
            | Import s -> write_import_section sub s
            | Function s -> write_function_section sub s
            | Table s -> write_table_section sub s
            | Memory s -> write_memory_section sub s
            | Global s -> write_global_section sub s
            | Export s -> write_export_section sub s
            | Start s -> write_start_section sub s
            | Element s -> write_element_section sub s
            | Code s -> write_code_section sub s
            | Data s -> write_data_section sub s
        let ba = ms.ToArray()
        (id, ba)

    let write_section w s =
        let (id, ba) = create_section_contents s
        printfn "write section %d with len %d" id ba.Length
        write_byte w id
        write_var_int w ba.Length
        write_blob w ba

    let write_module w m =
        write_magic w
        write_uint32 w m.version
        for s in m.sections do
            write_section w s

