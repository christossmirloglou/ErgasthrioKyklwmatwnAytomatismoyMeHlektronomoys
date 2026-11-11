Public Class PLCInput
    Inherits PLCSingleResource
    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Είσοδος", UserName_of_Contact, PLC_IO.Input, NumberOfCOntact)
        'Debug.Print("Creating input" + Str(NumberOfCOntact))

    End Sub
   

End Class
