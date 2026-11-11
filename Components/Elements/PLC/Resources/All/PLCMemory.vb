Public Class PLCMemory
    Inherits PLCSingleResource
    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Μνήμη", UserName_of_Contact, PLC_IO.Memory, NumberOfCOntact)

    End Sub
  

End Class
