Public Module PLCGlobals


    'Είσοδοι Έξοδοι PLC
    '0. Input       I
    '1. Output      Q
    '2. Memory      M
    '3. Timer TON   TON
    '4. Timer TOFF  TOFF
    '5. Counter     C
    '6. Count Up    CU
    '7. Cound Down  CD
    Public Enum PLC_IO As Byte
        Input = 0
        Output = 1
        Memory = 2
        DelayOn = 3
        DelayOff = 4
        Counter = 5
        CountUp = 6
        CountDown = 7
    End Enum

    Public PLC_IO_Symbol As String() = {"I", "Q", "M", "TON", "TOFF", "C", "CU", "CD"}

    Public PLC_IO_Info As String() = {"Είσοδος", "Έξοδος", "Μνήμη", "Χρονικό με καθυστέρηση έναυσης Delay On", "Χρονικό με καθυστέρηση απενεργοποίησης Delay Off", "Απαριθμητής", "Απαριθμητής +", "Απαριθμητής -"}

    Public Enum Logical_Operators
        LogicalNot = 0
        LogicalAnd = 1
        LogicalOr = 2
        LogicalXor = 3
    End Enum

    Public Logical_Symbol As String() = {"!", "&", "|", "^"}

    



End Module
