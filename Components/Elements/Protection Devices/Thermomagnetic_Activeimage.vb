Public Class Thermomagnetic_Activeimage
    Inherits ActiveImage
    Private ResetsAutomatically As Boolean = True
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
                Me.Image = My.Resources.ThermoMagnetic_on
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CThermoMagnetic_on
        End Select
    End Sub



    Public Overrides Sub initialization()
        nameImage()

        Me.information = "Τριφασικός θερμομαγνητικός διακόπτης για χειρισμό κινητήρα. Φέρει έξι επαφές. Οι τρεις πρώτες είναι επαφές ισχύος (L1-T1, L2-T2, L3-T3). Ο διακόπτης αυτός επιτηρεί την τιμή του ρεύματος των τριών φάσεων μέσω τριών αισθητηρίων υπερφόρτισης και βραχυκυκλώματος (ένα για κάθε φάση). Αν το ρεύμα ξεπεράσει μια ορισμένη (από εμάς) τιμή ή αν εμφανιστεί βραχυκύκλωμα, τότε το θερμικό ενεργοποιείται και ανοίγουν οι κύριες επαφές του (L1-T1, L2-T2, L3-T3) ενώ οι βοηθητικές του επαφές (NC 95-96, NO 97-98) αλλάζουν κατάσταση. Προσοχή. Οι βοηθητικές επαφές είναι σε κατάσταση ηρεμίας όταν ο διακόπτης είναι ανοιχτός. Οπότε μια ΝΟ βοηθητική επαφή θα είναι κλειστή όταν ο διακόπτης άγει. Ο διακόπτης αυτός μπορεί να χρησιμοποιηθεί και χωρίς ρελέ."
        Me.addScrew(6, 4, 15, 15, "L1", "Αυτό είναι το ένα άκρο (είσοδος) για την πρώτη φάση L1 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(0), 0.5, Me)
        Me.addScrew(6, 102, 15, 15, "T1", "Αυτό είναι το άλλο άκρο (έξοδος) για την πρώτη φάση L2 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(0), 1.5, Me)
        Me.addScrew(31, 4, 15, 15, "L2", "Αυτό είναι το ένα άκρο (είσοδος) για την δεύτερη φάση L2 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(1), 0.5, Me)
        Me.addScrew(31, 102, 15, 15, "T2", "Αυτό είναι το άλλο άκρο (έξοδος) για την δεύτερη φάση L2 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(1), 1.5, Me)
        Me.addScrew(56, 4, 15, 15, "L3", "Αυτό είναι το ένα άκρο (είσοδος) για την τρίτη φάση L3 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(2), 0.5, Me)
        Me.addScrew(56, 102, 15, 15, "T3", "Αυτό είναι το άλλο άκρο (έξοδος) για την τρίτη φάση L2 του θερμομαγνητικού διακόπτη. Αν η τιμή του ρεύματος της φάσης ξεπεράσει το καθορισμένο όριο έντασης (ή εμφανιστεί βραχυκύκλωμα) τότε ο διακόπτης ανοίγει και αλλάζουν κατάσταση οι βοηθητικές επαφές του.", wirecolors(2), 1.5, Me)
        Me.addScrew(81, 4, 15, 15, "13", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) βοηθητικής επαφής 13-14 του θερμομαγνητικού διακόπτη. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του διακόπτη είναι κάτω από την τιμή που έχουμε ορίσει και δεν έχει εμφανιστεί βραχυκύκλωμα ο διακόπτης δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Αυτή η επαφή είναι ανοιχτή όταν ο διακόπτης είναι ανοιχτός.", wirecolors(5), 0.5, Me)
        Me.addScrew(81, 102, 15, 15, "14", "Αυτό είναι το άλλο άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) βοηθητικής επαφής 13-14 του θερμομαγνητικού διακόπτη. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του διακόπτη είναι κάτω από την τιμή που έχουμε ορίσει και δεν έχει εμφανιστεί βραχυκύκλωμα ο διακόπτης δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Αυτή η επαφή είναι ανοιχτή όταν ο διακόπτης είναι ανοιχτός.", wirecolors(5), 1.5, Me)
        Me.addScrew(106, 4, 15, 15, "21", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά κλειστής (Normally Closed) βοηθητικής επαφής 21-22 του θερμομαγνητικού διακόπτη. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του διακόπτη είναι κάτω από την τιμή που έχουμε ορίσει και δεν έχει εμφανιστεί βραχυκύκλωμα ο διακόπτης δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Αυτή η επαφή είναι κλειστή όταν ο διακόπτης είναι ανοιχτός.", wirecolors(5), 0.5, Me)
        Me.addScrew(106, 102, 15, 15, "22", "Αυτό είναι το άλλο άκρο (είσοδος) της κανονικά κλειστής (Normally Closed) βοηθητικής επαφής 21-22 του θερμομαγνητικού διακόπτη. Όσο το ρεύμα που διαρρέει τα τρία αισθητήρια του διακόπτη είναι κάτω από την τιμή που έχουμε ορίσει και δεν έχει εμφανιστεί βραχυκύκλωμα ο διακόπτης δεν ενεργοποιείται. Αν το ρεύμα ξεπεράσει την ορισμένη τιμή τότε θα ενεργοποιηθεί. Αυτή η επαφή είναι κλειστή όταν ο διακόπτης είναι ανοιχτός.", wirecolors(5), 1.5, Me)
        Me.numberOfScrews = 9
        'Ορισμός των ορίων που θα επιτρέπεται η μετακίνηση
        Me.setMoveBounds()
        '1 Πλήκτρο για Ενεργοποίηση
        '1 Πλήκτρο για Test
        '1 Πλήκτρο για Reset
        '1 πλήκτρο για χειροκίνητη επαναφορά
        '1 πλήκτρο για αυτόματη επαναφορά
        setHotkeyNumber(2)
        Me.state = GlobalInfo.state.thermiko_anenergo
        setHotKeyInformation(0, "Κλεισιμό του διακόπτη")
        setHotKeyInformation(1, "Άνοιγμα του διακόπτη λόγο υπερφόρτωσης")
        setHotKeyInformation(2, "Πίεση του πληκτρου Test")
        '        setHotKeyInformation(3, "Πίεση του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
        '        setHotKeyInformation(4, "Επαναφορά του πλήκτρου Reset (Χειροκίνητη Επαναφορά)")
        '        setHotKeyInformation(5, "Χειροκίνητη επαναφορά (Manual)")
        '        setHotKeyInformation(6, "Αυτόματη επαναφορά (Automatic)")
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


        If state = GlobalInfo.state.thermiko_energo Or state = GlobalInfo.state.thermiko_test Then
            screw(8).combine_all_values(screw(9).value)     'Είναι κλειστό μόνο το normally closed
            screw(9).combine_all_values(screw(8).value)     'Είναι κλειστό μόνο το normally closed
        End If


        'Αν το ρελέ είναι ενεγοποιημένο
        If state = GlobalInfo.state.thermiko_anenergo Then
            For i = 0 To 3
                screw(0 + i * 2).combine_all_values(screw(1 + i * 2).value)
                screw(1 + i * 2).combine_all_values(screw(0 + i * 2).value)
            Next i
        End If

        '*************************************************************************************************
        'Αν το θερμικό δεν είναι απενεργοποιημένο τότε άγει μόνο η normally closed 95-96 (βίδα 8-9)
        '        If (state = GlobalInfo.state.thermiko_anenergo) Or (state = GlobalInfo.state.thermiko_reset) Then
        ' screw(8).combine_all_values(screw(9).value)     'Είναι κλειστό μόνο το normally closed
        ' screw(9).combine_all_values(screw(8).value)     'Είναι κλειστό μόνο το normally closed
        ' Else 'Αλλιώς, αν ειναι ενεργοποιημέντο τότε άγει μόνο η 97-98(6-7)
        ' screw(6).combine_all_values(screw(7).value)     'Είναι κλειστό το Normally open 97-98
        ' screw(7).combine_all_values(screw(6).value)     'Είναι κλειστό μόνο το normally closed

        '        End If

    End Sub
    Public Overrides Function whatami() As String
        Return "THERMOMAGNETIC RELAY"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "θερμομαγνητικός διακόπτης"
    End Function





    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.thermiko_anenergo
                If SimulationSymbols Then Image = My.Resources.CThermoMagnetic_on Else Image = My.Resources.ThermoMagnetic_on
            Case GlobalInfo.state.thermiko_energo
                If SimulationSymbols Then Image = My.Resources.CThermoMagnetic_off Else Image = My.Resources.ThermoMagnetic_off
            Case GlobalInfo.state.thermiko_test
                If SimulationSymbols Then Image = My.Resources.CThermoMagnetic_test Else Image = My.Resources.ThermoMagnetic_test
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
    '        setHotKeyInformation(0, "Κλεισιμό του διακόπτη")
    '        setHotKeyInformation(1, "Άνοιγμα του διακόπτη λόγο υπερφόρτωσης")
    '        setHotKeyInformation(2, "Πίεση του πληκτρου Test")
    Public Overrides Sub keypressed(whatkey As Char)
        Select Case whatkey
            Case getHotKey(1)   '
                changestate(GlobalInfo.state.thermiko_energo)
            Case getHotKey(0)   'Ενεργοποίηση θερμικού
                changestate(GlobalInfo.state.thermiko_anenergo)
            Case getHotKey(2)   'Ενεργοποίηση θερμικού
                changestate(GlobalInfo.state.thermiko_test)

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
                'MsgBox("Ενεργό")
                Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + "Το θερμικό ενεργοποιηθήκε. Το θερμικό ενεργοποιείται όταν εμφανίζεται υπεφόρτιση του κινητήρα ώστε να προλάβει πιθανή υπερθέρμανση και καταστροφή του." + vbNewLine
        End Select
    End Sub

    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        '   Dim gr As Graphics = WheretoDraw.CreateGraphics
        '    Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        '     Dim offset As Integer = 0
        '      If ResetsAutomatically Then offset = 21

        '        Dim pos1 = New Point((Me.Location.X + 131 + offset) * ratio, (Me.Location.Y + 107) * ratio)
        '       Dim pos2 = New Point((Me.Location.X + 148 + offset) * ratio, (Me.Location.Y + 107) * ratio)


        ' gr.DrawLine(defaultPen, pos1, pos2)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If state = GlobalInfo.state.thermiko_energo Then changestate(GlobalInfo.state.thermiko_anenergo) Else changestate(GlobalInfo.state.thermiko_energo)

    End Sub
End Class
