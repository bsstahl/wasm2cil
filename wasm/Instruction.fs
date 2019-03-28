// this file is automatically generated
module wasm.instr
    type Instruction =
        | Unreachable
        | Nop
        | Block
        | Loop
        | If
        | Else
        | Try
        | Catch
        | Throw
        | Rethrow
        | BrOnExn
        | End
        | Br
        | BrIf
        | BrTable
        | Return
        | Call of uint32
        | CallIndirect
        | ReturnCall
        | ReturnCallIndirect
        | Drop
        | Select
        | LocalGet
        | LocalSet
        | LocalTee
        | GlobalGet
        | GlobalSet
        | I32Load
        | I64Load
        | F32Load
        | F64Load
        | I32Load8S
        | I32Load8U
        | I32Load16S
        | I32Load16U
        | I64Load8S
        | I64Load8U
        | I64Load16S
        | I64Load16U
        | I64Load32S
        | I64Load32U
        | I32Store
        | I64Store
        | F32Store
        | F64Store
        | I32Store8
        | I32Store16
        | I64Store8
        | I64Store16
        | I64Store32
        | MemorySize
        | MemoryGrow
        | I32Const of int32
        | I64Const
        | F32Const
        | F64Const
        | I32Eqz
        | I32Eq
        | I32Ne
        | I32LtS
        | I32LtU
        | I32GtS
        | I32GtU
        | I32LeS
        | I32LeU
        | I32GeS
        | I32GeU
        | I64Eqz
        | I64Eq
        | I64Ne
        | I64LtS
        | I64LtU
        | I64GtS
        | I64GtU
        | I64LeS
        | I64LeU
        | I64GeS
        | I64GeU
        | F32Eq
        | F32Ne
        | F32Lt
        | F32Gt
        | F32Le
        | F32Ge
        | F64Eq
        | F64Ne
        | F64Lt
        | F64Gt
        | F64Le
        | F64Ge
        | I32Clz
        | I32Ctz
        | I32Popcnt
        | I32Add
        | I32Sub
        | I32Mul
        | I32DivS
        | I32DivU
        | I32RemS
        | I32RemU
        | I32And
        | I32Or
        | I32Xor
        | I32Shl
        | I32ShrS
        | I32ShrU
        | I32Rotl
        | I32Rotr
        | I64Clz
        | I64Ctz
        | I64Popcnt
        | I64Add
        | I64Sub
        | I64Mul
        | I64DivS
        | I64DivU
        | I64RemS
        | I64RemU
        | I64And
        | I64Or
        | I64Xor
        | I64Shl
        | I64ShrS
        | I64ShrU
        | I64Rotl
        | I64Rotr
        | F32Abs
        | F32Neg
        | F32Ceil
        | F32Floor
        | F32Trunc
        | F32Nearest
        | F32Sqrt
        | F32Add
        | F32Sub
        | F32Mul
        | F32Div
        | F32Min
        | F32Max
        | F32Copysign
        | F64Abs
        | F64Neg
        | F64Ceil
        | F64Floor
        | F64Trunc
        | F64Nearest
        | F64Sqrt
        | F64Add
        | F64Sub
        | F64Mul
        | F64Div
        | F64Min
        | F64Max
        | F64Copysign
        | I32WrapI64
        | I32TruncF32S
        | I32TruncF32U
        | I32TruncF64S
        | I32TruncF64U
        | I64ExtendI32S
        | I64ExtendI32U
        | I64TruncF32S
        | I64TruncF32U
        | I64TruncF64S
        | I64TruncF64U
        | F32ConvertI32S
        | F32ConvertI32U
        | F32ConvertI64S
        | F32ConvertI64U
        | F32DemoteF64
        | F64ConvertI32S
        | F64ConvertI32U
        | F64ConvertI64S
        | F64ConvertI64U
        | F64PromoteF32
        | I32ReinterpretF32
        | I64ReinterpretF64
        | F32ReinterpretI32
        | F64ReinterpretI64
        | I32Extend8S
        | I32Extend16S
        | I64Extend8S
        | I64Extend16S
        | I64Extend32S
        | InterpAlloca
        | InterpBrUnless
        | InterpCallHost
        | InterpData
        | InterpDropKeep
        | I32TruncSatF32S
        | I32TruncSatF32U
        | I32TruncSatF64S
        | I32TruncSatF64U
        | I64TruncSatF32S
        | I64TruncSatF32U
        | I64TruncSatF64S
        | I64TruncSatF64U
        | MemoryInit
        | DataDrop
        | MemoryCopy
        | MemoryFill
        | TableInit
        | ElemDrop
        | TableCopy
        | TableGet
        | TableSet
        | TableGrow
        | TableSize
        | RefNull
        | RefIsNull
        | V128Load
        | V128Store
        | V128Const
        | V8X16Shuffle
        | I8X16Splat
        | I8X16ExtractLaneS
        | I8X16ExtractLaneU
        | I8X16ReplaceLane
        | I16X8Splat
        | I16X8ExtractLaneS
        | I16X8ExtractLaneU
        | I16X8ReplaceLane
        | I32X4Splat
        | I32X4ExtractLane
        | I32X4ReplaceLane
        | I64X2Splat
        | I64X2ExtractLane
        | I64X2ReplaceLane
        | F32X4Splat
        | F32X4ExtractLane
        | F32X4ReplaceLane
        | F64X2Splat
        | F64X2ExtractLane
        | F64X2ReplaceLane
        | I8X16Eq
        | I8X16Ne
        | I8X16LtS
        | I8X16LtU
        | I8X16GtS
        | I8X16GtU
        | I8X16LeS
        | I8X16LeU
        | I8X16GeS
        | I8X16GeU
        | I16X8Eq
        | I16X8Ne
        | I16X8LtS
        | I16X8LtU
        | I16X8GtS
        | I16X8GtU
        | I16X8LeS
        | I16X8LeU
        | I16X8GeS
        | I16X8GeU
        | I32X4Eq
        | I32X4Ne
        | I32X4LtS
        | I32X4LtU
        | I32X4GtS
        | I32X4GtU
        | I32X4LeS
        | I32X4LeU
        | I32X4GeS
        | I32X4GeU
        | F32X4Eq
        | F32X4Ne
        | F32X4Lt
        | F32X4Gt
        | F32X4Le
        | F32X4Ge
        | F64X2Eq
        | F64X2Ne
        | F64X2Lt
        | F64X2Gt
        | F64X2Le
        | F64X2Ge
        | V128Not
        | V128And
        | V128Or
        | V128Xor
        | V128BitSelect
        | I8X16Neg
        | I8X16AnyTrue
        | I8X16AllTrue
        | I8X16Shl
        | I8X16ShrS
        | I8X16ShrU
        | I8X16Add
        | I8X16AddSaturateS
        | I8X16AddSaturateU
        | I8X16Sub
        | I8X16SubSaturateS
        | I8X16SubSaturateU
        | I8X16Mul
        | I16X8Neg
        | I16X8AnyTrue
        | I16X8AllTrue
        | I16X8Shl
        | I16X8ShrS
        | I16X8ShrU
        | I16X8Add
        | I16X8AddSaturateS
        | I16X8AddSaturateU
        | I16X8Sub
        | I16X8SubSaturateS
        | I16X8SubSaturateU
        | I16X8Mul
        | I32X4Neg
        | I32X4AnyTrue
        | I32X4AllTrue
        | I32X4Shl
        | I32X4ShrS
        | I32X4ShrU
        | I32X4Add
        | I32X4Sub
        | I32X4Mul
        | I64X2Neg
        | I64X2AnyTrue
        | I64X2AllTrue
        | I64X2Shl
        | I64X2ShrS
        | I64X2ShrU
        | I64X2Add
        | I64X2Sub
        | F32X4Abs
        | F32X4Neg
        | F32X4Sqrt
        | F32X4Add
        | F32X4Sub
        | F32X4Mul
        | F32X4Div
        | F32X4Min
        | F32X4Max
        | F64X2Abs
        | F64X2Neg
        | F64X2Sqrt
        | F64X2Add
        | F64X2Sub
        | F64X2Mul
        | F64X2Div
        | F64X2Min
        | F64X2Max
        | I32X4TruncSatF32X4S
        | I32X4TruncSatF32X4U
        | I64X2TruncSatF64X2S
        | I64X2TruncSatF64X2U
        | F32X4ConvertI32X4S
        | F32X4ConvertI32X4U
        | F64X2ConvertI64X2S
        | F64X2ConvertI64X2U
        | AtomicNotify
        | I32AtomicWait
        | I64AtomicWait
        | I32AtomicLoad
        | I64AtomicLoad
        | I32AtomicLoad8U
        | I32AtomicLoad16U
        | I64AtomicLoad8U
        | I64AtomicLoad16U
        | I64AtomicLoad32U
        | I32AtomicStore
        | I64AtomicStore
        | I32AtomicStore8
        | I32AtomicStore16
        | I64AtomicStore8
        | I64AtomicStore16
        | I64AtomicStore32
        | I32AtomicRmwAdd
        | I64AtomicRmwAdd
        | I32AtomicRmw8AddU
        | I32AtomicRmw16AddU
        | I64AtomicRmw8AddU
        | I64AtomicRmw16AddU
        | I64AtomicRmw32AddU
        | I32AtomicRmwSub
        | I64AtomicRmwSub
        | I32AtomicRmw8SubU
        | I32AtomicRmw16SubU
        | I64AtomicRmw8SubU
        | I64AtomicRmw16SubU
        | I64AtomicRmw32SubU
        | I32AtomicRmwAnd
        | I64AtomicRmwAnd
        | I32AtomicRmw8AndU
        | I32AtomicRmw16AndU
        | I64AtomicRmw8AndU
        | I64AtomicRmw16AndU
        | I64AtomicRmw32AndU
        | I32AtomicRmwOr
        | I64AtomicRmwOr
        | I32AtomicRmw8OrU
        | I32AtomicRmw16OrU
        | I64AtomicRmw8OrU
        | I64AtomicRmw16OrU
        | I64AtomicRmw32OrU
        | I32AtomicRmwXor
        | I64AtomicRmwXor
        | I32AtomicRmw8XorU
        | I32AtomicRmw16XorU
        | I64AtomicRmw8XorU
        | I64AtomicRmw16XorU
        | I64AtomicRmw32XorU
        | I32AtomicRmwXchg
        | I64AtomicRmwXchg
        | I32AtomicRmw8XchgU
        | I32AtomicRmw16XchgU
        | I64AtomicRmw8XchgU
        | I64AtomicRmw16XchgU
        | I64AtomicRmw32XchgU
        | I32AtomicRmwCmpxchg
        | I64AtomicRmwCmpxchg
        | I32AtomicRmw8CmpxchgU
        | I32AtomicRmw16CmpxchgU
        | I64AtomicRmw8CmpxchgU
        | I64AtomicRmw16CmpxchgU
        | I64AtomicRmw32CmpxchgU


