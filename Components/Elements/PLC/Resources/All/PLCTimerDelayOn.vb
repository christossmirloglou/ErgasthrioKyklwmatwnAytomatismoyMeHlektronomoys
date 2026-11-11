Public Class PLCTimerDelayOn
    Inherits PLCSingleResource
    Private PreviousValue As Boolean = False


    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Χρονικό Delay On", UserName_of_Contact, PLC_IO.DelayOn, NumberOfCOntact)

    End Sub



    'Επιστρέφει την τιμή του στοιχείου
    'Επειδή όμως είναι χρονικό, ουσιαστικά θα επιστρέφει την κατάσταση της επαφής του
    'Δηλαδή θα είναι 1 μόνο αν έχει περάσει ο προκαθορισμένος χρόνος
    Public Overrides Function GetValue() As Boolean
        'Διαβάζω από τη Base class την τιμή του Value για να δώ πρώτα απ' όλα αν το χρονικό είναι ενεργό
        Dim BaseV As Boolean = MyBase.GetValue
        Dim Param As Integer = MyBase.GetParameter()

        'Αν η Base Class Value = False τότε επιστρέφει False
        If Not BaseV Then Return False

        'Από εδώ και πέρα το BaseV είναι True

        'Αν ο χρόνος που έχει περάσει (σε δευτερόλεπτα) είναι μεγαλύτερος ή ίσος από την παράμετρο του χρόνικού τότε επέστρεψε 1
        If MyBase.GetTimeElaplsed() >= MyBase.GetParameter() Then Return True
        'Αν δεν έχει περάσει αρκετός χρόνος τότε επέστρεψε 0
        Return False
    End Function

    'Ορίζει την τιμή του στοιχείου
    Public Overrides Sub SetValue(value_of_contact As Boolean)
        'Αν πριν το Value = False τότε θα πρέπει τώρα να αρχίσω να μετράω τον χρόνο
        If Not PreviousValue Then
            SetStartTime(Now())
        End If
        MyBase.SetValue(value_of_contact)
        PreviousValue = value_of_contact
    End Sub
End Class
