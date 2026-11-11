Public Class PLCTimerDelayOff
    Inherits PLCSingleResource
    Private PreviousValue As Boolean = False             'Η προηγούμενη τιμή του Value, για να δούμε αν είναι η πρώτη φορά που ενεργοποιείται το χρονικό. 
    Private Execute As Boolean = False                    'Η εντολή για την ενεργοποίηση του χρονικού
    'Constructor
    Public Sub New(ByRef UserName_of_Contact As String, ByRef NumberOfCOntact As Byte)

        'Κλήση Base Constructor
        MyBase.New("Χρονικό Delay Off", UserName_of_Contact, PLC_IO.DelayOff, NumberOfCOntact)

    End Sub

    Public Overrides Function GetValue10() As Byte
        If GetValue() Then Return 1 Else Return 0
    End Function


    'Επιστρέφει την τιμή του στοιχείου
    'Επειδή όμως είναι χρονικό, ουσιαστικά θα επιστρέφει την κατάσταση της επαφής του
    'Δηλαδή θα είναι 1 μόνο αν έχει περάσει ο προκαθορισμένος χρόνος
    Public Overrides Function GetValue() As Boolean
        'Διαβάζω από τη Base class την τιμή του Value για να δώ πρώτα απ' όλα αν το χρονικό είναι ενεργό
        Dim BaseV As Boolean = MyBase.GetValue
        Dim Param As Integer = MyBase.GetParameter()

        'Αν η Base Class Value = True τότε επιστρέφει True. Αν δηλαδή τροφοδοτείται το χρονικό
        If BaseV Then Return True

        'Αν τώρα έχει κλείσει το χρονικό, αλλά το Execute είναι True δηλαδή μετέβει ενερό σε ανανεργό και πρέπει να ελεγχθεί ο χρόνος
        If Execute Then
            'Αν ο χρόνος που έχει περάσει (σε δευτερόλεπτα) είναι μικρότερος από τη ρύθμιση τότε επιστρέφει 1 αλλιώς 0 και μηδενίζει το Execute
            If MyBase.GetTimeElaplsed() <= MyBase.GetParameter() Then Return True Else Execute = False : Return False

        End If

        Return False
    End Function

    'Ορίζει την τιμή του στοιχείου
    Public Overrides Sub SetValue(value_of_contact As Boolean)
        'Αν πριν το Value = True και τώρα False τότε θα πρέπει τώρα να αρχίσω να μετράω τον χρόνο
        If PreviousValue And Not value_of_contact Then
            SetStartTime(Now())
            Execute = True
        End If
        MyBase.SetValue(value_of_contact)
        PreviousValue = value_of_contact
    End Sub
End Class
