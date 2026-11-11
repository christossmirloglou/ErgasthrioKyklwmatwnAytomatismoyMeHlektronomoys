Public Class SingleScrewData
    Public Const max_brances_per_Screw = 20               'Πόσες παράλληλες συνδέσεις επιτρέπονται

    Public Structure Connection_data                        'Structure για την αποθήκευση των στοιχείων των σημείων που ενώνονται με την τρέχουσα βίδα
        Public Screw As SingleScrewData                     'Αυτή είναι μια από τις άλλες βίδες (από εδώ μπορούμε να βρούμε και το αντικείμενο τύπου ActiveImage που περιέχει την βίδα
        Public ScrewNumber As Integer                       'Ο αριθμός της βίδας
        Public Wire As Wire                                 'Ο αγωγός που ενώνει την τρέχουσα βίδα με τις άλλες
    End Structure

    Public X As Integer
    Public Y As Integer
    Public name As String
    Public information As String
    Public Width As Integer
    Public Height As Integer
    Public parent As ActiveImage
    Public color As Color
    'Where to put node
    '0 Προς τα δεξιά
    '1 Προς τα αριστερά
    '1.5= Προς τα κάτω
    '0.5= Προς τα πάνω
    Public WhereToPutNode As Single
    Private total_connections As Integer = 0
    Public connections(max_brances_per_Screw) As Connection_data
    'Το Value μας ενημερώνει για το επίπεδο τάσης της βίδας. Τα επίπεδα φαίνονται στο GlobalIfo V_L1, V_L2, V_L3 κτλ και είναι δυνάμεις του 2 - Διακρίνονται με πράξη AND
    Public value As Long = 0

    'Το WhichValue πρέπει να έχει τιμή ίση με μια δυναμη τού 2
    'Δες στο GlobalInfo 
    ' V_L1 = 1
    ' V_L2 = 2
    ' V_L3 = 4
    ' V_N = 8
    ' V_PE = 16
    Sub IncludeThisValue(WhichValue As Long)
        If value And WhichValue = 0 Then value = value + WhichValue
    End Sub




    '******************************************************************************************************************************************
    'Μετατροπή των πρώτων HowManyDigits bit της  τιμής του Value σε δυαδικό αριθμό σε μορφή String
    '******************************************************************************************************************************************

    Function screwValueToBinary(HowManyDigits As Integer) As String
        If value = 0 Then Return "0"
        Return Convert.ToString(value And ((2 ^ HowManyDigits) - 1), 2)
    End Function





    '******************************************************************************************************************************************
    'Μετατροπή των της  τιμής του Value σε δυαδικό αριθμό σε μορφή String
    '******************************************************************************************************************************************

    Function ScrewValueToBinary() As String
        If value = 0 Then Return "0"
        Return Convert.ToString(value, 2)
    End Function

    '******************************************************************************************************************************************
    '
    '******************************************************************************************************************************************
    '
    'Έλεγχος αν έχουμε βραχυκύκλωμα
    '
    Function isThereAShort() As Boolean
        'Μετατροπή του Value (που περιέχει δυνάμεις του 2 V_L1 κτλ) σε δυαδικό String
        Dim BScr As String = screwValueToBinary(5)

        'Μετατροπή του δυαδικού String σε δεκαδικό αριθμό
        Dim StrToDec = Long.Parse(BScr)

        'Αν ο λογάριθμος δεν είναι καθαρός ακέραιος τότε ο παραπάνω αριθμός δέν είναι μια απλή δύναμη του 10, δηλαδή δεν περιέχει μόνο μια μονάδα, αλλά τουλάχιστον 2, οπότε έχουμε βραχυκύκλωμα.
        If Math.Log10(StrToDec) <> Int(Math.Log10(StrToDec)) Then Return True Else Return False
    End Function





    '******************************************************************************************************************************************
    ' Είναι φάση ή ουδέτερος;
    '******************************************************************************************************************************************
    Function checkifLorN() As Boolean
        '15 = 1111
        If value = 0 Then Return False
        Dim bin1 As String = screwValueToBinary(4)
        Dim par As Long = Long.Parse(bin1)
        Dim lg As Single = Math.Log10(par)
        Dim bool1 As Boolean = (lg = Fix(lg))
        Dim bool2 As Boolean = (value > 0)
        If bool1 And bool2 Then Return True
        Return False
    End Function

    'Επιστροφή του σημείου
    Public Function returnPoint() As Point
        Return New Point(X, Y)
    End Function



    'Επιστρέφει το πλήθος των συνδέσεων
    Public Function get_total_connections() As Integer
        Return total_connections
    End Function

    Public Sub reset_connections()
        total_connections = 0
    End Sub


    'Καταγραφή σύνδεσης για τη συγκεκριμένη βίδα
    'Αυτό χρησιμοποιείται κατά το Simulation για να καταγραφούν όλες οι διασυνδεδεμένες βίδες.
    'Αν ψάξουμε μέσα στο Connections θα δουμε όλους τους αγωγούς που ακουμπάνε στη συγκεκριμένη βίδα και τις βίδες που ακουμπάνει αυτοί οι άλλοι αγωγοί.
    Public Sub add_connection(WhichWire As Wire, WhichScrew As SingleScrewData, NumberOfScrew As Integer)

        If total_connections > max_brances_per_Screw Then Exit Sub
        connections(total_connections) = New Connection_data
        connections(total_connections).Screw = WhichScrew
        connections(total_connections).Wire = WhichWire
        connections(total_connections).ScrewNumber = NumberOfScrew
        total_connections = total_connections + 1
    End Sub
    'Επαναφορά όλων των Values της ομάδας των βιδών
    Public Sub reset_value()
        Dim i As Integer
        value = 0
        For i = 0 To Me.total_connections - 1
            connections(i).Screw.value = 0
        Next
        'Simulation_Values_Have_Changed = True

    End Sub

    'Συνδυάζει δύο Values τιμών τάσης
    'πχ A=17, δηλαδή 16+1 = 2^4+ 2^0
    'θέλω να το συνδυάσω με το 5,δηλαδή 4+1 = 2^2+2^0
    'Θα προσθέσει στο 17 μόνο το 2^2 και οχι το 2^0
    '17       = 10001
    '5        =   101
    'Combine  = 10101 = 21

    Function Combine_Value(InitialValue As Long, ValueToAdd As Long) As Long
        Dim i As Integer
        Dim Remember_Initial As Long = InitialValue

        For i = 0 To max_const_values
            'Αν υπάρχει κάποιο ΒΙΤ μέσα στο Value to Add τότε το προσθέτο στο InitialValue
            InitialValue = InitialValue Or ValueToAdd
            If InitialValue <> Remember_Initial Then Simulation_Values_Have_Changed = True

            'Παλιός τρόπος
            'If ((ValueToAdd And (2 ^ i)) > 0) And ((InitialValue And (2 ^ i)) = 0) Then
            ' InitialValue = InitialValue + 2 ^ i
            ' Simulation_Values_Have_Changed = True
            ' End If
        Next
        Return InitialValue
    End Function

    'Ορισμός όλων των Values της ομάδας των βιδών
    Public Sub combine_all_values(WhichValue As Long)
        Dim i As Integer
        Dim prevalue As Long
        Dim preconnections() As Connection_data = connections.Clone
        prevalue = value

        value = Combine_Value(value, WhichValue)


        For i = 0 To total_connections - 1
            connections(i).Screw.value = Combine_Value(connections(i).Screw.value, WhichValue) ' Combine_Value(connections(i).Screw.value, WhichValue)


            'Αν βρεθεί βραχυκύκλωμα και είναι το πρώτο που αναφέρεται τότε
            If isThereAShort() And ShortCircuit.FaultFound = False Then
                ShortCircuit.WhichObject = connections(i).Screw.parent
                ShortCircuit.WhichScrew = connections(i).Screw
                ShortCircuit.WhichScrewNumber = connections(i).ScrewNumber
                ShortCircuit.FaultFound = True
            End If
        Next

        InitializeAll()
    End Sub
    'Ενημέρωση όλων των βιδών ώστε να έχουν την ίδια τιμή
    Public Sub InitializeAll()

        Dim Combination As Long = value
        'Εύρεση του μέγιστου δυαδικου ψηφίου
        For i = 0 To total_connections - 1
            Combination = Combination Or connections(i).Screw.value
        Next

        value = Combination
        For i = 0 To total_connections - 1
            If connections(i).Screw.value <> Combination Then connections(i).Screw.value = Combination : Simulation_Values_Have_Changed = True
        Next


    End Sub

    'Αναφορά όλων των τιμών και συνδέσεων μιας βίδας
    Public Function reportOnValues() As String
        Dim s, k, l As String
        Dim i As Integer

        s = "Screw from Obj" & parent.Tag & "Value =" + value.ToString & " Connects to " & total_connections.ToString

        For i = 0 To total_connections - 1
            's = s + " #" + i & " Obj =" & connections(i).Screw.parent.Tag
            k = " ScrewNum " & connections(i).ScrewNumber
            l = " Value " & connections(i).Screw.value.ToString
            s = s + k + l
        Next

        Return s
    End Function
End Class




