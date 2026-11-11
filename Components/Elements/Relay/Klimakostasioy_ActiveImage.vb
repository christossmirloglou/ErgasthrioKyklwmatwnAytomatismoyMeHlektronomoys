Public Class Klimakostasioy_ActiveImage
    Inherits ActiveImage
    Dim StartedWorkingAt As Integer = 0
    Dim IS_powered As Boolean = False
    Dim Was_powered As Boolean = False

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Stairs0
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CStairs0
        End Select
    End Sub
    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()



        Me.information = "Διακόπτης κλιμακοστασίου. Για να λειτουργήσει θα πρέπει να τροφοδοτήσετε την συσκευή τροφοδοτώντας με φάση το άκρο L, με ουδέτερο το άκρο Ν. Η σύνδεση των μπουτόν γίνεται με τέτοιο τρόπο ώστε όταν πιέζονται τα μπουτόν να τροφοδοτείται το άκρο 3 με φάση ή ουδέτερο. Όταν ενεργοποιείται ο διακόπτης τότε τροφοδοτεί με φάση το άκρο 4, οπότε οι λαμπτήρες θα πρέπει να συνδεθούν στο άκρο 4 και στον ουδέτερο. Μπορείτε να ορίσετε αυτόν τον χρόνο της καθυστέρησης κάνοντας δεξί κλικ επάνω στο χρονικό και επιλέγοντας `Ρύθμιση χρονικής καθυστέρησης` από το αναδυόμενο μενού."
        nameImage()



        addScrew(6, 4, 15, 15, "3", "Άκρο 3: Συνδέστε εδώ τα πλήκτρα ελέγχου του διακόπτη κλιμακοστασίου. Μπορείτε να υλοποιήσετε μια σύνδεση που να τροφοδοτεί αυτό το άκρο με φάση ή ουδέτερο, ο διακόπτης θα λειτουργήσει και με τις δύο συνδέσεις.", wirecolors(5), 0.5, Me)
        addScrew(6, 102, 15, 15, "4", "Άκρο 4: Συνδέστε εδώ τους λαμπτήρες, το άλλο άκρο των λαμπτήρων θα πρέπει να συνδεθεί στον ουδέτερο. Όταν ενεργοποιηθεί ο διακόπτης το άκρο 4 θα έχει τάση 230V.", wirecolors(5), 1.5, Me)
        addScrew(31, 4, 15, 15, "L", "Συνδέστε εδώ την φάση L.", wirecolors(0), 0.5, Me)
        addScrew(31, 102, 15, 15, "N", "Συνδέστε εδώ τον ουδέτερο Ν.", wirecolors(3), 1.5, Me)
        HasTimeSettings = True
        Me.numberOfScrews = 3
        Me.setMoveBounds()
        state = GlobalInfo.state.xroniko_anenergo
        Dim StartedWorkingAt As Integer = 0
    End Sub





    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next
        Select Case state

            Case GlobalInfo.state.xroniko_counting, GlobalInfo.state.xroniko_powered
                screw(2).combine_all_values(screw(1).value)     'NO
                screw(1).combine_all_values(screw(2).value)     'NO
            Case Else
                ' GlobalInfo.state.xroniko_anenergo, και tripped
                'screw(2).combine_all_values(screw(3).value)     'NC
                'screw(3).combine_all_values(screw(2).value)     'NC

        End Select
    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************

    Public Overrides Function whatami() As String
        Return "STAIRCASE SWITCH"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Διακόπτης κλιμακοστασίου"
    End Function

    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.xroniko_anenergo
                If SimulationSymbols Then Me.Image = My.Resources.CStairs0 Else Me.Image = My.Resources.Stairs0
            Case GlobalInfo.state.xroniko_powered
                If SimulationSymbols Then Me.Image = My.Resources.CStairs1 Else Me.Image = My.Resources.Stairs1
            Case GlobalInfo.state.xroniko_counting
                If SimulationSymbols Then Me.Image = My.Resources.CStairsT Else Me.Image = My.Resources.StairsT


        End Select
    End Sub
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()

    End Sub


    '***************************************************************************************************************************************
    'checkifDifferent
    'Έλεγχος αν δεν έχουμε την ίδια φάση συνδεδεμένη επάνω και κάτω
    '***************************************************************************************************************************************
    Function checkifDifferent(val1 As Integer, val2 As Integer) As Boolean
        If (val1 And 15) = (val2 And 15) Then Return False
        Return True
    End Function





    '***************************************************************************************************************************************
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του χρονικού
    '***************************************************************************************************************************************
    Public Overrides Sub EvaluateObject()
        Dim st = GlobalInfo.state.xroniko_anenergo
        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
        Dim A1 As Long = screw(2).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(3).value And V_PhasesNeutralMask

        Dim A3 As Long = screw(2).value
        Dim A4 As Long = screw(3).value

        Dim A0 As Long = screw(0).value And V_PhasesNeutralMask



        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(2).value Or screw(3).value
        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Or (a5 = V_N) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
    (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub


        'Αν έχω συνδέσει ουδέτερο και φάση αντί για φάση και ουδέτερο
        If (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + ") Δεν τροφοδοτήσατε σωστά τον διακόπτη κλιμακοστασίου - Δεν θα λειτουργήσει" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub

        'Εφόσον τροφοδοτείται ο διακόπτης και η πρώτη βίδα έχει ουδέτερο ή φάση
        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) And _
            ((A0 = V_L1) Or (A0 = V_L2) Or (A0 = V_L3) Or (A0 = V_N)) Then
            'ΕΦΟΣΟΝ ΤΟ ΧΡΟΝΙΚΟ ΤΡΟΦΟΔΟΤΕΙΤΑΙ
            st = GlobalInfo.state.xroniko_powered
            IS_powered = True
            Was_powered = True
            StartedWorkingAt = Simulation_runsteps

        Else
            'Αν τώρα δεν τροφοδοτείται

            'αλλα τροφοδοτούνταν πριν λίγο τότε 
            If Was_powered Then
                'Αν έχει περάσει αρκετός χρόνος
                If Simulation_runsteps >= (StartedWorkingAt + TripTicks) Then
                    'κλείσε
                    st = GlobalInfo.state.xroniko_anenergo
                    Was_powered = False

                Else    'αν δεν έχει περάσει αρκετός χρόνος
                    st = GlobalInfo.state.xroniko_counting
                    Was_powered = True
                End If

            End If



        End If
        changestate(st)




    End Sub

End Class
