Public Class DelayOn_ActiveImage
    Inherits ActiveImage
    Dim StartedWorkingAt As Integer = -1

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.DelayOn
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CDelayOn
        End Select
    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        nameImage()
        Me.information = "Χρονικό Delay On. Φέρει δύο σετ επαφών. Η επαφή 15-16 NO είναι κανονικά ανοιχτή με χρονική λειτουργία. Η επαφή 27-28 NC είναι κανονικά κλειστή με χρονική λειτουργία. Οι επαφές θα αλλάξουν κατάσταση όταν τροφοδοτηθεί το χρονικό (Α1-Α2) και περάσει ο καθορισμένος (από τον χειριστή) χρόνος. Μπορείτε να ορίσετε αυτόν τον χρόνο κάνοντας δεξί κλικ επάνω στο χρονικό και επιλέγοντας `Ρύθμιση χρονικής καθυστέρησης` από το αναδυόμενο μενού."


        addScrew(6, 4, 15, 15, "17", "Άνω άκρο της βοηθητικής επαφής 17-18 NO. Μόλις τροφοδοτηθεί το Α1-Α2 αυτή η επαφή αρχικά δεν θα αλλάξει κατάσταση και θα παραμείνει ανοιχτή. Η επαφή θα κλείσει όταν τροφοδοτήσουμε το Α1-Α2 για χρόνο μεγαλύτερο από τον προκαθορισμένο (τον χρόνο που έχουμε ρυθμίσει δηλαδή). Μέτα από το πέρας αυτού του χρόνου θα κλείσει η επαφή και θα παραμείνει έτσι για όσο χρόνο τροφοδοτείται το Α1-Α2.", wirecolors(5), 0.5, Me)
        addScrew(6, 102, 15, 15, "18", "Κάτω άκρο της βοηθητικής επαφής 17-18 NO. Μόλις τροφοδοτηθεί το Α1-Α2 αυτή η επαφή αρχικά δεν θα αλλάξει κατάσταση και θα παραμείνει ανοιχτή. Η επαφή θα κλείσει όταν τροφοδοτήσουμε το Α1-Α2 για χρόνο μεγαλύτερο από τον προκαθορισμένο (τον χρόνο που έχουμε ρυθμίσει δηλαδή). Μέτα από το πέρας αυτού του χρόνου θα κλείσει η επαφή και θα παραμείνει έτσι για όσο χρόνο τροφοδοτείται το Α1-Α2.", wirecolors(5), 1.5, Me)
        addScrew(31, 4, 15, 15, "25", "Άνω άκρο της βοηθητικής επαφής 25-25 NC. Μόλις τροφοδοτηθεί το Α1-Α2 αυτή η επαφή αρχικά δεν θα αλλάξει κατάσταση και θα παραμείνει κλειστή. Η επαφή θα ανοίξει όταν τροφοδοτήσουμε το Α1-Α2 για χρόνο μεγαλύτερο από τον προκαθορισμένο (τον χρόνο που έχουμε ρυθμίσει δηλαδή). Μέτα από το πέρας αυτού του χρόνου θα ανοίξει η επαφή και θα παραμείνει έτσι για όσο χρόνο τροφοδοτείται το Α1-Α2.", wirecolors(5), 0.5, Me)
        addScrew(31, 102, 15, 15, "25", "Κάτω άκρο της βοηθητικής επαφής 25-26 NC. Μόλις τροφοδοτηθεί το Α1-Α2 αυτή η επαφή αρχικά δεν θα αλλάξει κατάσταση και θα παραμείνει κλειστή. Η επαφή θα ανοίξει όταν τροφοδοτήσουμε το Α1-Α2 για χρόνο μεγαλύτερο από τον προκαθορισμένο (τον χρόνο που έχουμε ρυθμίσει δηλαδή). Μέτα από το πέρας αυτού του χρόνου θα ανοίξει η επαφή και θα παραμείνει έτσι για όσο χρόνο τροφοδοτείται το Α1-Α2.", wirecolors(5), 1.5, Me)
        addScrew(56, 4, 15, 15, "A1", "Άνω άκρο της επαφής Α1-Α2 τροφοδοσίας του χρονικού.", wirecolors(0), 0.5, Me)
        addScrew(56, 102, 15, 15, "A2", "Κάτω άκρο της επαφής Α1-Α2 τροφοδοσίας του χρονικού.", wirecolors(3), 1.5, Me)
        HasTimeSettings = True

        Me.numberOfScrews = 5
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

        Select state
            Case GlobalInfo.state.xroniko_anenergo, GlobalInfo.state.xroniko_powered
                screw(2).combine_all_values(screw(3).value)     'NC
                screw(3).combine_all_values(screw(2).value)     'NC
            Case GlobalInfo.state.xroniko_tripped
                screw(0).combine_all_values(screw(1).value)     'NO
                screw(1).combine_all_values(screw(0).value)     'NO

        End Select


    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************

    Public Overrides Function whatami() As String
        Return "DELAY ON TIMER"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Χρονικό Delay On"
    End Function

    '______________________________________________________________________________________________________________________________
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state

            Case GlobalInfo.state.xroniko_powered
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOn_Powered Else Me.Image = My.Resources.DelayOn_Powered
            Case GlobalInfo.state.xroniko_tripped
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOn_Tripped Else Me.Image = My.Resources.DelayOn_Tripped
            Case Else
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOn Else Me.Image = My.Resources.DelayOn


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
        Dim st As Integer
        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N

        Dim A1 As Long = screw(4).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(5).value And V_PhasesNeutralMask
        Dim A3 As Long = screw(4).value
        Dim A4 As Long = screw(5).value




        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(4).value Or screw(5).value
        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Or (a5 = V_N) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
    (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub




        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
           (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then
            'ΕΦΟΣΟΝ ΤΟ ΧΡΟΝΙΚΟ ΤΡΟΦΟΔΟΤΕΙΤΑΙ
            'Η συμπεριοφρά του εξαρτάται από τον χρόνο που ξεκίνησε η τροφοδοσία του
            If StartedWorkingAt = -1 Then StartedWorkingAt = GlobalInfo.Simulation_runsteps
            Select Case GlobalInfo.Simulation_runsteps - StartedWorkingAt
                'Εάν είναι η πρώτη φορά που τροφοδοτείται
                Case Is < TripTicks
                    st = GlobalInfo.state.xroniko_powered
                Case Is >= TripTicks
                    st = GlobalInfo.state.xroniko_tripped
            End Select


        Else
            StartedWorkingAt = -1
            st = GlobalInfo.state.xroniko_anenergo
        End If

        changestate(st)

    End Sub



End Class
