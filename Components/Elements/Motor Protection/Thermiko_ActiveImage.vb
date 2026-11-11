Public Class thermiko_ActiveImage
    Inherits ActiveImage
    Private ResetsAutomatically As Boolean = False
    Dim StartedWorkingAt As Integer = -1
    Dim AytomathEpanaforaSe As Integer = 10            'Ο ΧΡΟΝΟΣ ΕΝΕΡΓΟΠΟΙΗΣΗΣ: Σε πόσα τικ του ρολογίου θα αλλάξει κατάσταση, όταν το έχουμε ρυθμίσει για αυτόματη επαναφορά



    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Thermiko
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CThermiko
        End Select
    End Sub



    Public Overrides Sub initialization()
        nameImage()
        Set_CircuitPrintingImage(My.Resources._Thermiko)
        Me.information = "Τριφασικό θερμικό. Φέρει τρία αισθητήρια (L1-T1, L2-T2, L3-T3) που συνδέονται αντίστοιχα στις τρεις φάσεις (γραμμές) τροφοδοσίας του κινητήρα. Το θερμικό επιτηρεί την τιμή του ρεύματος των τριών φάσεων. Αν το ρεύμα ξεπεράσει μια ορισμένη (από εμάς) τιμή, τότε το θερμικό ενεργοποιείται και οι βοηθητικές του επαφές (NC 95-96, NO 97-98) αλλάζουν κατάσταση. Τα άκρα L1-T1, L2-T2, L3-T3 φέρουν αισθητήρια και δεν προκαλούν διακοπή στη ροή του ρεύματος. Η διακοπή θα προκύψει από τον ηλεκτρονόμο μέσω των βοηθητικών επαφών του θερμικού 95-96 & 97-98"
        Me.addScrew(  6, 4, 15, 15, "L1", "Αυτό είναι το ένα άκρο (είσοδος) για το πρώτο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L1 και T1. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(0), 0.5, Me)
        Me.addScrew(6, 102, 15, 15, "T1", "Αυτό είναι το άλλο άκρο (έξοδος) για το πρώτο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L1 και T1. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(0), 1.5, Me)
        Me.addScrew( 31, 4, 15, 15, "L2", "Αυτό είναι το ένα άκρο (είσοδος) για το δεύτερο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L2 και T2. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(1), 0.5, Me)
        Me.addScrew(31, 102, 15, 15, "T2", "Αυτό είναι το άλλο άκρο (έξοδος) για το δεύτερο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L2 και T2. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(1), 1.5, Me)
        Me.addScrew(56, 4, 15, 15, "L3", "Αυτό είναι το ένα άκρο (είσοδος) για το πρώτο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L3 και T3. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(2), 0.5, Me)
        Me.addScrew(56, 102, 15, 15, "T3", "Αυτό είναι το άλλο άκρο (έξοδος) για το πρώτο θερμικό αισθητήριο του θερμικού ρελέ. Το πρώτο αισθητήριο έχει ως άκρα τα L3 και T3. Μέσα από αυτό το αισθητήριο θα πρέπει να ρέει το ρεύμα της πρώτης φάσης. Δουλειά του αισθητηρίου αυτού είναι η επιτήρηση της τιμής του ρεύματος της πρώτης φάσης. Σε περίπτωση που εντοπιστεί ότι η τιμή του ρεύματος υπερβαίνει την μέγιστη τιμή (που έχουμε ορίσει εμείς) τότε ενεργοποιούνται οι βοηθητικές επαφές του θερμικού (95-96 & 97-98) ώστε να προκληθεί (μέσω του κυκλώματος αυτοματισμού παύσης τροφοδοσίας του φορτίου)", wirecolors(2), 1.5, Me)
        Me.addScrew(81, 4, 15, 15, "95", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά κλειστής (Normally Closed) επαφής 95-96 του θερμικού. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του θερμικού είναι κάτω από την τιμή που έχουμε ορίσει το θεμικό δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Όσο το θερμικό παραμένει ανενεργό η επαφή αυτή είναι κλειστή. Μόλις ενεργοποιηθεί το θερμικό η επαφή θα ανοίξει. Αν το θερμικό είναι ρυθμισμένο για χειροκίνητη λειτουργία (Manual) τότε θα πρέπει να πιέσουμε κατάλληλο πλήκτρο ώστε να γίνει απενεργοποίηση του θερμικού και επαναφορά της επαφής. Αν είναι ρυθμισμένο για αυτόματη λειτουργία, τότε απενεργοποιείται μόνο του μετά από λίγη ώρα.", wirecolors(5), 0.5, Me)
        Me.addScrew(81, 102, 15, 15, "96", "Αυτό είναι το άλλο άκρο (έξοδος) της κανονικά κλειστής (Normally Closed) επαφής 95-96 του θερμικού. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του θερμικού είναι κάτω από την τιμή που έχουμε ορίσει το θεμικό δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Όσο το θερμικό παραμένει ανενεργό η επαφή αυτή είναι κλειστή. Μόλις ενεργοποιηθεί το θερμικό η επαφή θα ανοίξει. Αν το θερμικό είναι ρυθμισμένο για χειροκίνητη λειτουργία (Manual) τότε θα πρέπει να πιέσουμε κατάλληλο πλήκτρο ώστε να γίνει απενεργοποίηση του θερμικού και επαναφορά της επαφής. Αν είναι ρυθμισμένο για αυτόματη λειτουργία, τότε απενεργοποιείται μόνο του μετά από λίγη ώρα.", wirecolors(5), 1.5, Me)
        Me.addScrew(106, 4, 15, 15, "97", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) επαφής 97-98 του θερμικού. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του θερμικού είναι κάτω από την τιμή που έχουμε ορίσει το θεμικό δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Όσο το θερμικό παραμένει ανενεργό η επαφή αυτή είναι ανοιχτή. Μόλις ενεργοποιηθεί το θερμικό η επαφή θα κλείσει. Αν το θερμικό είναι ρυθμισμένο για χειροκίνητη λειτουργία (Manual) τότε θα πρέπει να πιέσουμε κατάλληλο πλήκτρο ώστε να γίνει απενεργοποίηση του θερμικού και επαναφορά της επαφής. Αν είναι ρυθμισμένο για αυτόματη λειτουργία, τότε απενεργοποιείται μόνο του μετά από λίγη ώρα.", wirecolors(5), 0.5, Me)
        Me.addScrew(106, 102, 15, 15, "98", "Αυτό είναι το άλλο άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) επαφής 97-98 του θερμικού. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του θερμικού είναι κάτω από την τιμή που έχουμε ορίσει το θεμικό δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Όσο το θερμικό παραμένει ανενεργό η επαφή αυτή είναι ανοιχτή. Μόλις ενεργοποιηθεί το θερμικό η επαφή θα κλείσει. Αν το θερμικό είναι ρυθμισμένο για χειροκίνητη λειτουργία (Manual) τότε θα πρέπει να πιέσουμε κατάλληλο πλήκτρο ώστε να γίνει απενεργοποίηση του θερμικού και επαναφορά της επαφής. Αν είναι ρυθμισμένο για αυτόματη λειτουργία, τότε απενεργοποιείται μόνο του μετά από λίγη ώρα.", wirecolors(5), 1.5, Me)
        Me.numberOfScrews = 9
        'Ορισμός των ορίων που θα επιτρέπεται η μετακίνηση
        Me.setMoveBounds()
        '1 Πλήκτρο για Ενεργοποίηση
        '1 Πλήκτρο για Test
        '1 Πλήκτρο για Reset
        '1 πλήκτρο για χειροκίνητη επαναφορά
        '1 πλήκτρο για αυτόματη επαναφορά
        setHotkeyNumber(6)
        Me.state = GlobalInfo.state.thermiko_anenergo
        setHotKeyInformation(0, "Ενεργοποίηση του θερμικού λόγω υπερφόρτισης")
        setHotKeyInformation(1, "Πίεση του πλήκτρου Test (Δοκιμή)")
        setHotKeyInformation(2, "Επαναφορά του πλήκτρου Test (Δοκιμή)")
        setHotKeyInformation(3, "Πίεση του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
        setHotKeyInformation(4, "Επαναφορά του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
        setHotKeyInformation(5, "Χειροκίνητη επαναφορά (Manual)")
        setHotKeyInformation(6, "Αυτόματη επαναφορά (Automatic)")
        ResetsAutomatically = False
        Dim StartedWorkingAt As Integer = 0


    End Sub




    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************

    Public Overrides Sub inform_screws()
        Dim i As Integer
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        'Το ρεύμα περνάει όπως και να έχει από τις επαφές ισχύος
        For i = 0 To 2
            screw(0 + i * 2).combine_all_values(screw(1 + i * 2).value)
            screw(1 + i * 2).combine_all_values(screw(0 + i * 2).value)
        Next i


        '*************************************************************************************************
        'Αν το θερμικό δεν είναι απενεργοποιημένο τότε άγει μόνο η normally closed 95-96 (βίδα 8-9)
        If (state = GlobalInfo.state.thermiko_anenergo) Or (state = GlobalInfo.state.thermiko_reset) Then
            screw(8).combine_all_values(screw(9).value)     'Είναι κλειστό μόνο το normally closed
            screw(9).combine_all_values(screw(8).value)     'Είναι κλειστό μόνο το normally closed
        Else 'Αλλιώς, αν ειναι ενεργοποιημέντο τότε άγει μόνο η 97-98(6-7)
            screw(6).combine_all_values(screw(7).value)     'Είναι κλειστό το Normally open 97-98
            screw(7).combine_all_values(screw(6).value)     'Είναι κλειστό μόνο το normally closed

        End If

    End Sub
    Public Overrides Function whatami() As String
        Return "THERMAL RELAY"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Θερμικό"
    End Function





    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.thermiko_anenergo
                If SimulationSymbols Then Image = My.Resources.CThermiko Else Image = My.Resources.Thermiko
            Case GlobalInfo.state.thermiko_energo
                If SimulationSymbols Then Image = My.Resources.CThermiko_Tripped Else Image = My.Resources.Thermiko_Tripped
            Case GlobalInfo.state.thermiko_reset
                If SimulationSymbols Then Image = My.Resources.CThermiko_Reset Else Image = My.Resources.Thermiko_Reset
            Case GlobalInfo.state.thermiko_test
                If SimulationSymbols Then Image = My.Resources.CThermiko_Tripped_Test_Pressed Else Image = My.Resources.Thermiko_Tripped_Test_Pressed
            Case GlobalInfo.state.thermiko_test_reset
                If SimulationSymbols Then Image = My.Resources.CThermiko_Tripped_Test_Reset_Pressed Else Image = My.Resources.Thermiko_Tripped_Test_Reset_Pressed





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
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    '       setHotKeyInformation(0, "Ενεργοποίηση του θερμικού λόγω υπερφόρτισης")
    '       setHotKeyInformation(1, "Πίεση του πλήκτρου Test (Δοκιμή)")
    '       setHotKeyInformation(2, "Επαναφορά του πλήκτρου Test (Δοκιμή)")
    '       setHotKeyInformation(3, "Πίεση του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
    '       setHotKeyInformation(4, "Επαναφορά του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
    '       setHotKeyInformation(5, "Ρύθμιση του χρονικού για λειτουργία με χειροκίνητη επαναφορά (Manual)")
    '       setHotKeyInformation(6, "Ρύθμιση του χρονικού για λειτουργία με αυτόματη επαναφορά (Automatic)")
    Public Overrides Sub keypressed(whatkey As Char)
        Select Case whatkey
            Case getHotKey(0)   'Ενεργοποίηση θερμικού
                changestate(GlobalInfo.state.thermiko_energo)
            Case getHotKey(1) 'Αν πατηθεί το Test
                'Αν είναι πατημένο το Reset τότε πατα και τα δύο, αλλιώς μόνο το τεστ
                If state = GlobalInfo.state.thermiko_test_reset Then Exit Sub
                If state = GlobalInfo.state.thermiko_reset Then changestate(GlobalInfo.state.thermiko_test_reset) Else changestate(GlobalInfo.state.thermiko_test)
            Case getHotKey(2) 'Επαναφορά του Test
                'Αν δεν έχεις πατημένο το test τότε δεν γίνεται τίποτα
                If (state = GlobalInfo.state.thermiko_test) Or (state = GlobalInfo.state.thermiko_test_reset) Then
                    'Αν είναι πατημένα και τα δύο τότε άσε μόνο το reset αλλίως αφησε το θερμικό απλά ενεργό
                    If state = GlobalInfo.state.thermiko_test_reset Then changestate(GlobalInfo.state.thermiko_reset) Else changestate(GlobalInfo.state.thermiko_energo)

                End If

            Case getHotKey(3) ' Αν πατηθεί το rest
                If state = GlobalInfo.state.thermiko_test_reset Then Exit Sub
                'Αν είναι πατημένο το τεστ, τότε πάτε και τα δύοι αλλίως ενεργοποίησε μόνο το reset
                If state = GlobalInfo.state.thermiko_test Then changestate(GlobalInfo.state.thermiko_test_reset) Else changestate(GlobalInfo.state.thermiko_reset)
            Case getHotKey(4) 'Επαναφορά του Reset
                'Αν δεν έχεις πατημένο το reset τότε δεν γίνεται τίποτα
                If (state = GlobalInfo.state.thermiko_reset) Or (state = GlobalInfo.state.thermiko_test_reset) Then
                    'Αν είναι πατημένα και τα δύο τότε άσε μόνο το test, αλλιώς ασε το θερμικό ανενεργό
                    If state = GlobalInfo.state.thermiko_test_reset Then changestate(GlobalInfo.state.thermiko_test) Else changestate(GlobalInfo.state.thermiko_anenergo)

                End If

            Case getHotKey(5)   'Ρυθμίσε το θερμικό για χειροκίνητη λειτουργία
                ResetsAutomatically = False
            Case getHotKey(6)   'Ρύθμισε το θερμικό για αυτόματη λειτουργία
                ResetsAutomatically = True
        End Select

    End Sub








    '***************************************************************************************************************************************
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Sub EvaluateObject()
        If state = GlobalInfo.state.thermiko_energo And ResetsAutomatically Then
            If StartedWorkingAt = -1 Then StartedWorkingAt = GlobalInfo.Simulation_runsteps
            'Simulator.Text = "Μετράω από " + StartedWorkingAt.ToString + " χρόνος " + AytomathEpanaforaSe.ToString
            If Simulation_runsteps > (StartedWorkingAt + AytomathEpanaforaSe) Then StartedWorkingAt = -1 : changestate(GlobalInfo.state.thermiko_anenergo)
        End If
        Select Case state
            Case GlobalInfo.state.thermiko_energo
                Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + "Το θερμικό ενεργοποιηθήκε. Το θερμικό ενεργοποιείται όταν εμφανίζεται υπεφόρτιση του κινητήρα ώστε να προλάβει πιθανή υπερθέρμανση και καταστροφή του." + vbNewLine
        End Select
    End Sub

    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        Dim offset As Integer = 0
        If ResetsAutomatically Then offset = 21

        Dim pos1 = New Point((Me.Location.X + 131 + offset) * ratio, (Me.Location.Y + 107) * ratio)
        Dim pos2 = New Point((Me.Location.X + 148 + offset) * ratio, (Me.Location.Y + 107) * ratio)


        gr.DrawLine(defaultPen, pos1, pos2)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If state = GlobalInfo.state.thermiko_energo Then changestate(GlobalInfo.state.thermiko_anenergo) Else changestate(GlobalInfo.state.thermiko_energo)

    End Sub
End Class
