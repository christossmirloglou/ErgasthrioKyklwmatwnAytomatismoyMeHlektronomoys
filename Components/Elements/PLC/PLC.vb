Public Class PLC
    

    'Ρύθμιση της κατάστασης της εισόδου
    Public Sub SetInput(MyIo As PLCResources, WhichInput As Integer, WhichValue As Boolean)
        MyIo.SetInput(WhichInput, WhichValue)
    End Sub

    'Ανάγνωση της κατάστασης της εξόδου
    Public Function getOutput(MyIo As PLCResources, WhichOutput As Integer) As Boolean
        Return MyIo.GetOutput(WhichOutput)
    End Function

    Public Sub EvaluateOutputs(MyIo As PLCResources)
        MyIo.EvaluateOutputState()
    End Sub
    'Άνοιγμα του παραθύρου ορισμού λογικών εξισώσεων
    Public Sub OpenEquationsWindow(MyIo As PLCResources)
        MyIo.OpenEquationsWindow()

    End Sub
End Class
