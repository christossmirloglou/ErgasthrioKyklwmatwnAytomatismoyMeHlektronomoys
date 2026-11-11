Public Class ReleRagas
    Inherits ActiveImage
    Dim first_run = True
    Dim PlaySoundOn As Boolean = True 'Χρησιμοποιείται για να μην ακούγεται πολλές φορές το κλικ κατά το άνοιγμα και κλείσιμο του ρελέ

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        ' Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.CReleRagas0
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.ReleRagas0
        End Select
    End Sub


    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        nameImage()


        Me.information = "Ρελέ ράγας με μια μεταγωγική επαφή 1-2=NC και 1-3=NO. Όταν το πηνίο (Α1-Α2) του ρελέ με τάση 230V οι επαφές του αλλάζουν κατάσταση, δηλαδή η 1-2 ανοίγει και η 1-3 κλείνει."
        addScrew(6, 4, 15, 15, "1", "Αυτή είναι η είσοδος(1) της μεταγωγικής επαφής ισχύος του ρελέ.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Αυτή είναι η έξοδος της μεταγωγικής επαφής ισχύος (1-2=NC) του ρελέ. Σε κατάσταση ηρεμίας, δηλαδή όταν δεν τροφοδοτείται το πηνίο Α1-Α2 του ρελέ, αυτή η επαφή είναι κλειστή.", wirecolors(0), 1.5, Me)
        addScrew(31, 102, 15, 15, "3", "Αυτή είναι η έξοδος της μεταγωγικής επαφής ισχύος (1-3=NΟ) του ρελέ. Σε κατάσταση ηρεμίας, δηλαδή όταν δεν τροφοδοτείται το πηνίο Α1-Α2 του ρελέ, αυτή η επαφή είναι ανοιχτή.", wirecolors(1), 1.5, Me)

        addScrew(56, 4, 15, 15, "A1", "Αυτό είναι το ένα άκρο του πηνίου του ηλεκτρονόμου που έχει ως άκρα το Α1 και Α2. Όταν τα άκρα του ηλεκτρονόμου τροφοδοτηθούν με ηλεκτρική τάση 230V τότε ο ηλεκτρονόμος ενεργοποιείται και αλλάζει η κατάσταση όλων των επαφών του. ", wirecolors(5), 0.5, Me)
        addScrew(56, 102, 15, 15, "A2", "Αυτό είναι το άλλο άκρο του πηνίου του ηλεκτρονόμου που έχει ως άκρα το Α1 και Α2. Όταν τα άκρα του ηλεκτρονόμου τροφοδοτηθούν με ηλεκτρική τάση 230V τότε ο ηλεκτρονόμος ενεργοποιείται και αλλάζει η κατάσταση όλων των επαφών του.", wirecolors(3), 1.5, Me)
        Me.numberOfScrews = 4
        'Ορισμός των ορίων που θα επιτρέπεται η μετακίνηση
        Me.setMoveBounds()
        state = GlobalInfo.state.rele_not_powered
    End Sub



    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    'Βήματα λειτουργίας του ρελέ
    'rele_1_energo_phnio = 1                Στα 5ms ενεργοποιείται
    'rele_2_anoigei_nc = 2                  Στα 10ms
    'rele_3_kleinei_proorhs_ergasias = 3    Στα 15ms
    'rele_4_anoigei_kathysterimenhs_hremias = 4 Στα 20 ms
    'rele_5_kleinei_no = 5                      Στα 25 ms
    'rele_6_kleinoyn_kyries_epafes = 6          Στα 30 ms
    Public Overrides Sub inform_screws()

        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next




        '*************************************************************************************************
        'Αν το ρελέ δεν είναι ενεγοποιημένο
        If state = GlobalInfo.state.rele_not_powered Then
            screw(0).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(0).value)
        End If


        'Αν το ρελέ είναι ενεγοποιημένο
        If state = GlobalInfo.state.rele_powered Then
            screw(0).combine_all_values(screw(2).value)
            screw(2).combine_all_values(screw(0).value)
        End If




    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "Din Rail Relay"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Ρελέ ράγας"
    End Function



    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.rele_powered
                If SimulationSymbols Then Me.Image = My.Resources.ReleRagas1 Else Me.Image = My.Resources.CReleRagas1
            Case Else
                If SimulationSymbols Then Me.Image = My.Resources.ReleRagas0 Else Me.Image = My.Resources.CReleRagas0
        End Select
    End Sub



    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()

        Select Case state
            Case GlobalInfo.state.rele_powered
                'Για να παίξει μονο μια φορά ο ήχος
                If PlaySoundOn And soundon Then My.Computer.Audio.Play(My.Resources.Relay_Sound, AudioPlayMode.Background)
                PlaySoundOn = False

            Case Else
                'Για να παίξει μονο μια φορά ο ήχος
                If (Not PlaySoundOn) And soundon Then My.Computer.Audio.Play(My.Resources.Relay_Sound, AudioPlayMode.Background)
                PlaySoundOn = True

        End Select



    End Sub


    '***************************************************************************************************************************************
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    '***************************************************************************************************************************************

    Public Overrides Sub EvaluateObject()






        'Ενεργοποίηση του ρελέ όταν τροφοδοτείται το Α1-Α2 (10-11)
        Dim A1 As Long = screw(3).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(4).value And V_PhasesNeutralMask
        Dim A3 As Long = screw(3).value
        Dim A4 As Long = screw(4).value




        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(3).value Or screw(4).value
        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Then changestate(GlobalInfo.state.rele_not_powered) : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
       (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then changestate(GlobalInfo.state.rele_not_powered) : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : Exit Sub



        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
           (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then
            If InterlockedWith = -1 Then
                changestate(GlobalInfo.state.rele_powered)
                'Αν έχουμε και το άλλο ρελέ ΔΕΝ είναι ενεργό
            Else
                If (allActiveObjects(InterlockedWith).state <> GlobalInfo.state.rele_powered) Then
                    changestate(GlobalInfo.state.rele_powered)
                Else

                End If

            End If

        Else : changestate(GlobalInfo.state.rele_not_powered)
        End If


    End Sub


End Class
