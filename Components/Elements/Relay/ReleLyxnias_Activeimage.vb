Public Class ReleLyxnias_Activeimage
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
                Me.Image = My.Resources.ReleLyxnias0
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CReleLyxnias0
        End Select
    End Sub


    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        nameImage()


        Me.information = "Ρελέ τύπου λυχνίας με τέσσερις μεταγωγικές επαγές (α)11-12(NC),11-14(NO), (β)21-22(NC),21-24(NO), (γ)31-32(NC),31-34(NO), (δ)41-42(NC),41-44(NO) και μια επαφή διέγερσης Α1-Α2. Όταν τροφοδοτηθεί η επαφή διέγερσης (Α1-Α2) του ρελέ με τάση 230V οι επαφές του αλλάζουν κατάσταση, δηλαδή κλείνουν οι 11-14, 21-24, 31-34, 41-44 και ανοίγουν οι 11-12, 21-22, 31-32, 41-42."
        addScrew(6, 4, 15, 15, "12", "Αυτή είναι το άκρο της κανονικά κλειστής επαφής της μεταγωγικής επαφής 11-(12NC,13NO).", wirecolors(0), 0.5, Me)
        addScrew(31, 4, 15, 15, "11", "Αυτή είναι το κοινό άκρο της μεταγωγικής επαφής 11-(12NC,13NO).", wirecolors(0), 0.5, Me)
        addScrew(56, 4, 15, 15, "14", "Αυτή είναι το άκρο της κανονικά ανοικτής επαφής της μεταγωγικής επαφής 11-(12NC,13NO)", wirecolors(0), 0.5, Me)

        addScrew(81, 4, 15, 15, "22", "Αυτή είναι το άκρο της κανονικά κλειστής επαφής της μεταγωγικής επαφής 21-(22NC,23NO).", wirecolors(1), 0.5, Me)
        addScrew(106, 4, 15, 15, "21", "Αυτή είναι το κοινό άκρο της μεταγωγικής επαφής 21-(22NC,23NO).", wirecolors(1), 0.5, Me)
        addScrew(131, 4, 15, 15, "24", "Αυτή είναι το άκρο της κανονικά ανοικτής επαφής της μεταγωγικής επαφής 21-(22NC,23NO)", wirecolors(1), 0.5, Me)

        addScrew(156, 4, 15, 15, "A1", "Αυτό είναι το ένα άκρο του πηνίου του ηλεκτρονόμου που έχει ως άκρα το Α1 και Α2. Όταν τα άκρα του ηλεκτρονόμου τροφοδοτηθούν με ηλεκτρική τάση 230V τότε ο ηλεκτρονόμος ενεργοποιείται και αλλάζει η κατάσταση όλων των επαφών του. ", wirecolors(5), 0.5, Me)


        addScrew(6, 102, 15, 15, "32", "Αυτή είναι το άκρο της κανονικά κλειστής επαφής της μεταγωγικής επαφής 31-(32NC,33NO).", wirecolors(2), 1.5, Me)
        addScrew(31, 102, 15, 15, "31", "Αυτή είναι το κοινό άκρο της μεταγωγικής επαφής 31-(32NC,33NO).", wirecolors(2), 1.5, Me)
        addScrew(56, 102, 15, 15, "34", "Αυτή είναι το άκρο της κανονικά ανοικτής επαφής της μεταγωγικής επαφής 31-(32NC,33NO)", wirecolors(2), 1.5, Me)

        addScrew(81, 102, 15, 15, "42", "Αυτή είναι το άκρο της κανονικά κλειστής επαφής της μεταγωγικής επαφής 41-(42NC,43NO).", wirecolors(0), 1.5, Me)
        addScrew(106, 102, 15, 15, "41", "Αυτή είναι το κοινό άκρο της μεταγωγικής επαφής 41-(42NC,43NO).", wirecolors(0), 1.5, Me)
        addScrew(131, 102, 15, 15, "44", "Αυτή είναι το άκρο της κανονικά ανοικτής επαφής της μεταγωγικής επαφής 41-(42NC,43NO)", wirecolors(0), 1.5, Me)
        addScrew(156, 102, 15, 15, "A2", "Αυτό είναι το άλλο άκρο του πηνίου του ηλεκτρονόμου που έχει ως άκρα το Α1 και Α2. Όταν τα άκρα του ηλεκτρονόμου τροφοδοτηθούν με ηλεκτρική τάση 230V τότε ο ηλεκτρονόμος ενεργοποιείται και αλλάζει η κατάσταση όλων των επαφών του.", wirecolors(3), 1.5, Me)

        Me.numberOfScrews = 13
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
            screw(3).combine_all_values(screw(4).value)
            screw(4).combine_all_values(screw(3).value)
            screw(7).combine_all_values(screw(8).value)
            screw(8).combine_all_values(screw(7).value)
            screw(10).combine_all_values(screw(11).value)
            screw(11).combine_all_values(screw(10).value)
        End If


        'Αν το ρελέ είναι ενεγοποιημένο
        If state = GlobalInfo.state.rele_powered Then
            screw(2).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(2).value)
            screw(5).combine_all_values(screw(4).value)
            screw(4).combine_all_values(screw(5).value)
            screw(9).combine_all_values(screw(8).value)
            screw(8).combine_all_values(screw(9).value)
            screw(12).combine_all_values(screw(11).value)
            screw(11).combine_all_values(screw(12).value)
        End If




    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "PLUG IN RELAY"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Ρελέ λυχνίας"
    End Function



    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.rele_powered
                If SimulationSymbols Then Me.Image = My.Resources.CReleLyxnias1 Else Me.Image = My.Resources.ReleLyxnias1
            Case Else
                If SimulationSymbols Then Me.Image = My.Resources.CReleLyxnias0 Else Me.Image = My.Resources.ReleLyxnias0
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
        Dim A1 As Long = screw(6).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(13).value And V_PhasesNeutralMask
        Dim A3 As Long = screw(6).value
        Dim A4 As Long = screw(13).value




        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(6).value Or screw(13).value
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
