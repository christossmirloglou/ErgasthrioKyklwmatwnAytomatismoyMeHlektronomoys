Public Class PLCOutput
    Inherits PLCSingleResource
    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Έξοδος", UserName_of_Contact, PLC_IO.Output, NumberOfCOntact)

    End Sub
 
End Class
