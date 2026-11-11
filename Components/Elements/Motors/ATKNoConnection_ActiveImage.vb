Public Class ATKNoConnection_ActiveImage
    Inherits ActiveImage
    Public connectioninfo As Char = ""
    Public Overrides Sub initialization()


        Me.information = "Ασύγχρονος τριφασικός κινητήρας."
        Me.Image = My.Resources.motor
        addScrew(31, 4, 15, 15, "U/U1", "Άνω άκρο του πρώτου τυλίγματος του ΑΤΚ (U1/U2)", wirecolors(0), 0.5, Me)
        addScrew(31, 102, 15, 15, "Z/W2", "Κάτω άκρο του τρίτου τυλίγματος του ΑΤΚ (W1/W2)", wirecolors(0), 1.5, Me)
        addScrew(56, 4, 15, 15, "V/V1", "Άνω άκρο του δεύτερου τυλίγματος του ΑΤΚ (V1/V2)", wirecolors(1), 0.5, Me)
        addScrew(56, 102, 15, 15, "X/U2", "Άνω άκρο του δεύτερου τυλίγματος του ΑΤΚ (V1/V2)", wirecolors(1), 1.5, Me)
        addScrew(81, 4, 15, 15, "W/W1", "Άνω άκρο του τρίτου τυλίγματος του ΑΤΚ (W1/W2)", wirecolors(2), 0.5, Me)
        addScrew(81, 102, 15, 15, "Y/V2", "Κάτω άκρο του δεύτερου τυλίγματος του ΑΤΚ (V1/V2)", wirecolors(2), 1.5, Me)
        addScrew(106, 4, 15, 15, "PE", "Γείωση", wirecolors(4), 0.5, Me)
        Me.setMoveBounds()
        Me.state = GlobalInfo.state.motor_not_powered

        Me.numberOfScrews = 6

    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next
        screw(0).combine_all_values(V_U1)
        screw(1).combine_all_values(V_W2)
        screw(2).combine_all_values(V_V1)
        screw(3).combine_all_values(V_U2)
        screw(4).combine_all_values(V_W1)
        screw(5).combine_all_values(V_V2)

    End Sub
    Public Overrides Function whatami() As String
        Return "3PHASE MOTOR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Κινητήρας 3φ"
    End Function
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Select Case state
            Case GlobalInfo.state.motor_not_powered
                Me.Image = My.Resources.motor
            Case GlobalInfo.state.motor_right
                Me.Image = My.Resources.motor_Working_Right
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_SOund, AudioPlayMode.Background)

            Case GlobalInfo.state.motor_left
                Me.Image = My.Resources.motor_Working_Left
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_SOund, AudioPlayMode.Background)




        End Select

    End Sub
    

   
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έχουμε σύνδεση Τριγώνου
    'Το NumberofDeltaConnections μας ενημερωνεί για το πλήθος των γεφυρών τριγώνου
    Function CheckisItDelta(ByRef NumberOfDeltaConnections As Integer, ByRef UsesASinglePhase As Boolean, ByRef DoesNotUseAllThreePhases As Boolean, ByRef ConnectsToNeutral As Boolean, ByRef ConnectsToGround As Boolean) As Boolean
        Dim scr1wind, scr2wind As Long
        Dim phase1, phase2 As Long
        Dim barFound() As Boolean = {False, False, False}
        Dim phasefound() As Boolean = {False, False, False}
        Dim i As Integer
        Dim result As Boolean

        ConnectsToNeutral = False
        ConnectsToGround = False
        NumberOfDeltaConnections = 0

        For i = 0 To 2
            'Πρώτα ελέγχω για τις 3 γέφυρες
            ' Ελέγχω αν υπάρχει η πρώτη μπάρα, δηλαδή ελέγχω αν υπάρχουν στις βίδες δηλωμένα τα άκρα των σωστών τυλιγμάτων
            scr1wind = screw(0 + i * 2).value And V_WindingsMask
            scr2wind = screw(1 + i * 2).value And V_WindingsMask
            'Θα πρέπει οι τιμές αυτών των δύο να είναι V_U1 και U_W2
            If ((scr1wind And (V_U1 + V_W2)) And (scr2wind = scr1wind)) Or _
               ((scr1wind And (V_V1 + V_U2)) And (scr2wind = scr1wind)) Or _
               ((scr1wind And (V_W1 + V_V2)) And (scr2wind = scr1wind)) Then barFound(i) = True : NumberOfDeltaConnections = NumberOfDeltaConnections + 1 Else barFound(i) = False


            'Τώρα θα δούμε αν παίρνουν την ίδια φάση και τα δύο άκρα της μπάρας
            phase1 = screw(0 + i * 2).value And V_PhasesNeutralMask
            phase2 = screw(1 + i * 2).value And V_PhasesNeutralMask

            'Αν παίρνουν την ίδια φάση (ουδετερο - γείωση)
            If (phase1 = phase2) And (phase1 > 0) Then
                'Αν η συγκεκριμένη μπάρα είναι συνδέμένη σε μια φάση
                If ((phase1 = V_L1) Or (phase1 = V_L2) Or (phase1 = V_L3)) Then
                    If phase1 = V_L1 And phasefound(0) = True Then DoesNotUseAllThreePhases = True
                    If phase1 = V_L2 And phasefound(1) = True Then DoesNotUseAllThreePhases = True
                    If phase1 = V_L3 And phasefound(2) = True Then DoesNotUseAllThreePhases = True
                    phasefound(i) = True
                Else
                    If phase1 = V_N Then ConnectsToNeutral = True
                    If phase1 = V_PE Then ConnectsToGround = True
                    phasefound(i) = False
                End If
            End If


        Next
        'LEN TRUEFALSEFLASE = 13
        If Len(phasefound(0).ToString + phasefound(1).ToString + phasefound(2).ToString) = 13 Then UsesASinglePhase = True Else UsesASinglePhase = False
        result = True
        For i = 0 To 2
            result = (result And barFound(i)) And phasefound(i)
        Next

        Return result



    End Function



    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έχουμε σύνδεση Τριγώνου
    'Το NumberofDeltaConnections μας ενημερωνεί για το πλήθος των γεφυρών τριγώνου
    Function CheckisItStar(ByRef foundStar As Integer, ByRef FoundPower As Integer, ByRef SingleStarConnection As Boolean, ByRef SinglePhaseConnection As Boolean, ByRef NotPoweredCorrectly As Boolean, ByRef Connectionwithneutral As Boolean, ByRef connectionwithearth As Boolean) As Boolean
        Dim scrwind() As Long = {0, 0, 0, 0, 0, 0}
        Dim scrval() As Long = {0, 0, 0, 0, 0, 0}
        Dim all3 As Long
        foundStar = 0 '1= επάνω , 2 κάτω
        FoundPower = 0 '1=επάνω, 2 κάτω


        SingleStarConnection = False
        Connectionwithneutral = False
        connectionwithearth = False
        NotPoweredCorrectly = False
        SinglePhaseConnection = True

        'Για να είναι αστέρας θα πρέπει οι πάνω ή οι κάτω βίδες να είναι γεφυρωμένες
        For i = 0 To 5
            scrwind(i) = screw(i).value And V_WindingsMask
            scrval(i) = screw(i).value And V_PhasesNeutralMask
        Next

        'Έλεγχος για την γέφυρα του αστέρα - θα μου δώσει 1 για επάνω και 2 για κάτω
        For i = 0 To 1
            ' If (scrwind(0 + i) = scrwind(2 + i)) And (scrwind(0 + i) = scrwind(4 + i)) And (scrval(0 + i) = 0) And (scrval(2 + i) = 0) And (scrval(4 + i) = 0) Then
            If (scrwind(0 + i) = scrwind(2 + i)) And (scrwind(0 + i) = scrwind(4 + i)) Then
                foundStar = 1 + i
            End If
            'Αν όμως είναι συνδεμένες μόνο δύο από τις 3 βίδες
            If scrwind(0 + i) = scrwind(2 + i) And scrwind(0 + i) <> scrwind(4 + i) Or
                scrwind(0 + i) = scrwind(4 + i) And scrwind(0 + i) <> scrwind(2 + i) Or
                scrwind(2 + i) = scrwind(4 + i) And scrwind(0 + i) <> scrwind(2 + i) Then SingleStarConnection = True
        Next

        'Έλεγχος για την τροφοδοσία του αστέρα θα μου δώσει 1 για επάνω και 2 για κάτω
        For i = 0 To 1
            'Αν δέν έχω συνδέσεις μεταξύ φάσεων
            all3 = scrval(0 + i) Or scrval(2 + i) Or scrval(4 + i)
            Select Case all3
                Case V_L1 + V_L2 + V_L3
                    FoundPower = 1 + i
                Case V_L1, V_L2, V_L3
                    SinglePhaseConnection = True
                Case (V_L1 + V_L2), (V_L2 + V_L3), (V_L1 + V_L3), V_L1 + V_N, V_L2, V_L3 + V_N
                    NotPoweredCorrectly = True
                Case Else
                    If (scrval(0 + i) Or scrval(2 + i) Or scrval(4 + i)) And V_N Then Connectionwithneutral = True
                    If (scrval(0 + i) Or scrval(2 + i) Or scrval(4 + i)) And V_PE Then connectionwithearth = True

            End Select
        Next
        If (FoundPower = 1 And foundStar = 2) Or (FoundPower = 2 And foundStar = 1) Then Return True Else Return False


    End Function


 


    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για σωστή γείωση
    Public Function check_for_grounding_errors(ByRef returnstring As String) As Boolean
        Dim v As Long = screw(6).value And V_PhasesNeutralMask
        returnstring = ""
        Select Case v
            Case V_PE
                returnstring = returnstring + "Σώμα κινητήρα γειωμένο σωστά."
                Return False
            Case 0
                returnstring = returnstring + "Το σώμα του κινητήρα δεν έχει γειωθεί! Υπάρχει κίνδυνος ηλεκτροπληξίας για τους χειριστές!"
                Return True
            Case V_L1, V_L2, V_L3
                returnstring = returnstring + "Στον ακροδέκτη της γείωσης συνδέσατε φάση. ΑΜΕΣΟΣ ΚΙΝΔΥΝΟΣ ΗΛΕΚΤΡΟΠΛΗΞΙΑΣ ΚΑΙ ΘΑΝΑΤΟΥ ΓΙΑ ΤΟΥΣ ΧΕΙΡΙΣΤΕΣ!"
                Return True
            Case Else
                returnstring = returnstring + "Επικίνδυνη και λανθασμένη γείωση κινητήρα."
                Return True
        End Select

    End Function


    '***************************************************************************************************************************************
    ' MotorSpin
    'Επιστρέφει True για αριστερόστροφη ή False για δεξιόστροφη φορά
    'ΠΡΕΠΕΙ ΝΑ ΕΧΟΥΝ ΓΙΝΕΙ ΟΛΟΙ ΟΙ ΕΛΕΓΧΟΙ ΠΡΩΤΑ
    '***************************************************************************************************************************************
    '1=ar
    '2=de
    '0=error
    Function motorSpinLeft() As Integer
        Dim tyligma1, tyligma2, tyligma3 As Long
        tyligma1 = screw(0).value And 7
        tyligma2 = screw(2).value And 7
        tyligma3 = screw(4).value And 7

        If tyligma1 = 0 Or tyligma2 = 0 Or tyligma3 = 0 Then
            tyligma1 = screw(1).value And 7
            tyligma2 = screw(3).value And 7
            tyligma2 = screw(5).value And 7

        End If

        If (tyligma1 = V_L1 And tyligma2 = V_L2 And tyligma3 = V_L3) Or _
            (tyligma1 = V_L2 And tyligma2 = V_L3 And tyligma3 = V_L3) Or _
            (tyligma1 = V_L3 And tyligma2 = V_L1 And tyligma3 = V_L3) Then Return 1

        If (tyligma1 = V_L2 And tyligma2 = V_L1 And tyligma3 = V_L3) Or _
            (tyligma1 = V_L1 And tyligma2 = V_L3 And tyligma3 = V_L2) Or _
            (tyligma1 = V_L3 And tyligma2 = V_L2 And tyligma3 = V_L1) Then Return 2
        Return 0



    End Function



    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    Public Overrides Sub EvaluateObject()
        Dim star, delta, StarConnectedToNeutral, StarConnectedToEarth, DeltaNotPoweredbyAllphases, DeltaConnectedToNeutral, DeltaConnectedtoEarth As Boolean
        Dim StarIsWhere, PowerIsWhere, NumberOfDeltaBars As Integer
        Dim ok, grerr, SingleStarConnection, notPoweredCorrectlyStar, StarSinglePhase, DeltaSinglePhase As Boolean
        Dim groundingError_Text As String = ""
        Dim errtxt As String = ""
        star = CheckisItStar(StarIsWhere, PowerIsWhere, SingleStarConnection, StarSinglePhase, notPoweredCorrectlyStar, StarConnectedToNeutral, StarConnectedToEarth)
        delta = CheckisItDelta(NumberOfDeltaBars, DeltaSinglePhase, DeltaNotPoweredbyAllphases, DeltaConnectedToNeutral, DeltaConnectedtoEarth)

        If (star Or delta) And (star = Not delta) And Not SingleStarConnection Then ok = True Else ok = False
        If star And NumberOfDeltaBars > 0 Then ok = False
        grerr = check_for_grounding_errors(groundingError_Text)

        connectioninfo = ""
        Select Case ok
            Case True
                'Αν όλα πάνε καλά τότε ορίζουμε τον τρόπο περιστροφής του κινητήρα.
                If motorSpinLeft() = 1 Then changestate(GlobalInfo.state.motor_left)
                If motorSpinLeft() = 2 Then changestate(GlobalInfo.state.motor_right)

                'Για να τα τυπώσει μετά
                If delta Then connectioninfo = "Δ"
                If star Then connectioninfo = "Υ"

            Case False
                changestate(GlobalInfo.state.motor_not_powered)
                'Ελέγχω αν υπάρχει κάποιο σφάλμα
                If ((NumberOfDeltaBars > 0 And NumberOfDeltaBars < 3) And SingleStarConnection) Or (star And delta) Or (star And (NumberOfDeltaBars > 0 And NumberOfDeltaBars < 3)) Or (delta And SingleStarConnection) Then
                    errtxt = errtxt + "Δεν είναι δυνατή η λειτουργεία σε συνδεσμολογία αστέρα και τριγώνου." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If NumberOfDeltaBars > 0 And NumberOfDeltaBars < 3 Then
                    errtxt = errtxt + "Η σύνδεση τριγώνου είναι ατελής." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If SingleStarConnection Then
                    errtxt = errtxt + "Η σύνδεση αστέρα είναι ατελής." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If (DeltaNotPoweredbyAllphases And Not DeltaSinglePhase) Or notPoweredCorrectlyStar Then
                    errtxt = errtxt + "Η τροφοδότηση του κινητήρα δεν είναι σωστή. Η λειτουργεία του κινητήρα σε αυτή την κατάσταση μπορεί να οδηγήσει στην καταστροφή του." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If DeltaConnectedToNeutral Or StarConnectedToNeutral Then
                    errtxt = errtxt + "Ο τριφασικός κινητήρας δεν πρέπει να τροφοδοτείται με ουδέτερο." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If DeltaConnectedtoEarth Or StarConnectedToEarth Then
                    errtxt = errtxt + "Τα τυλίγματα του κινητήρα δεν πρέπει να γειώνονται." + vbNewLine
                    con_Errors_found = con_Errors_found + 1
                End If

                If Trim(errtxt) <> "" Then Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + errtxt + vbNewLine



        End Select
        If ErrorSentFromElsewhere <> "" Then Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + ErrorSentFromElsewhere
        ErrorSentFromElsewhere = ""

    End Sub



    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        Dim offset As Integer = 0
        Dim fn As Font = New Font("Arial", 20 * ratio)
        Dim pos1 = New Point((Me.Location.X) * ratio, (Me.Location.Y + Me.Height / 2 - My.Resources.new_file.Height) * ratio)

        gr.DrawString(connectioninfo, fn, Brushes.Red, pos1)

        If con_Errors_found > -1 Then
            pos1 = New Point((Me.Location.X + Me.Width / 2 - My.Resources.Fire.Width / 2) * ratio, (Me.Location.Y + Me.Height / 2 - My.Resources.Fire.Height) * ratio)
            gr.DrawImage(My.Resources.Fire, pos1.X, pos1.Y, My.Resources.Fire.Width * ratio, My.Resources.Fire.Height * ratio)
            Drop_Thermiko()
            con_Errors_found = -1
            If soundon Then My.Computer.Audio.Play(My.Resources.motor_error_sound, AudioPlayMode.Background)
        End If


    End Sub

End Class
