Public Class PLCCounter
    Inherits PLCSingleResource
    Private PreviousCountUpValue As Boolean = False             'Η προηγούμενη τιμή του CU
    Private PreviousCountDownValue As Boolean = False              'Προηγούμενη τιμή του CD

    Private oldvalue As Boolean

    Public Sub CountUp(CountUp As Boolean)
        'MyBase.CountUp(CountUp)
        'Αν δεν είναι ενεργος ο απαριθμητής να μην γίνει η αύξηση
        If Not MyBase.GetValue() Then Exit Sub
        If PreviousCountUpValue = False And CountUp = True Then SetCurrentCount(GetCurrentCount() + 1)
        PreviousCountUpValue = CountUp
    End Sub

    Public Sub CountDown(CountDownV As Boolean)
        'MyBase.CountDown(CountDown)
        'αν δεν είναι ενεργόςο ο απαριθμητής να μήν γίνει η μείωση
        If Not MyBase.GetValue Then Exit Sub

        'Debug.Print("CountDown = " + CountDown.ToString)
        If Not PreviousCountDownValue And CountDownV Then
            SetCurrentCount(GetCurrentCount() - 1)
        End If
        PreviousCountDownValue = CountDownV

    End Sub

    Public Overrides Function GetValue() As Boolean
        If MyBase.GetValue = True Then
            If GetCurrentCount() >= GetParameter() Then Return True Else Return False
        End If


        Return MyBase.GetValue()
    End Function
    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Απαριθμητής", UserName_of_Contact, PLC_IO.Counter, NumberOfCOntact)

    End Sub
  

End Class
