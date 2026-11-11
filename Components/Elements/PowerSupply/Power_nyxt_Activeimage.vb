Public Class Power_nyxt_Activeimage
    Inherits ActiveImage
    '0 = Από πάνω
    '1 = Από κάτω
    '2 = Από αριστερά

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Sub changeImage(UseSymbols As Boolean)
        Select Case UseSymbols
            Case False                              'Κανονική εικόνα
                Select Case Me.state
                    Case GlobalInfo.state.leitoyrgei_kanonika
                        Select Case WhatTypeOfPowerSource
                            Case 0 'πάνω
                                Me.Image = My.Resources.Nyxt_FromBelow0
                            Case 1 'κάτω
                                Me.Image = My.Resources.Nyxt_FromAbove0
                            Case 2 'αριστερά
                                Me.Image = My.Resources.Nyxt_FromLeft0
                        End Select
                    Case GlobalInfo.state.leitoyrgei_kanonika_kai_nyxterino
                        Select Case WhatTypeOfPowerSource
                            Case 0 'πάνω
                                Me.Image = My.Resources.Nyxt_FromBelow1
                            Case 1 'κάτω
                                Me.Image = My.Resources.Nyxt_FromAbove1
                            Case 2 'αριστερά
                                Me.Image = My.Resources.Nyxt_FromLeft1
                        End Select

                End Select
            Case True                               'Εικόνα με σύμβολο
                Select Case Me.state
                    Case GlobalInfo.state.leitoyrgei_kanonika
                        Select Case WhatTypeOfPowerSource
                            Case 0 'πάνω
                                Me.Image = My.Resources.CNyxt_FromBelow0
                            Case 1 'κάτω
                                Me.Image = My.Resources.CNyxt_FromAbove0
                            Case 2 'αριστερά
                                Me.Image = My.Resources.CNyxt_FromLeft0
                        End Select
                    Case GlobalInfo.state.leitoyrgei_kanonika_kai_nyxterino
                        Select Case WhatTypeOfPowerSource
                            Case 0 'πάνω
                                Me.Image = My.Resources.CNyxt_FromBelow1
                            Case 1 'κάτω
                                Me.Image = My.Resources.CNyxt_FromAbove1
                            Case 2 'αριστερά
                                Me.Image = My.Resources.CNyxt_FromLeft1
                        End Select

                End Select
        End Select
    End Sub


    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        changeImage(useStandardSymbolsDuringEdit)

        
    End Sub

    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        changeImage(SimulationSymbols)
    End Sub


    Public WhatTypeOfPowerSource As Integer = 0
    Public Overrides Sub initialization()
        initialization(WhatTypeOfPowerSource)
    End Sub
    Public Overrides Sub initialization(Whitchtype As Integer)
        WhatTypeOfPowerSource = Whitchtype
        Select Case Whitchtype
            Case 0
                Me.information = "Τριφασική παροχή με Νυχτερινό τιμολόγιο - Παροχή από την κάτω πλευρά."
                Me.Image = My.Resources.Nyxt_FromBelow0
                addScrew(6, 4, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 0.5, Me)
                addScrew(31, 4, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 0.5, Me)
                addScrew(56, 4, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 0.5, Me)
                addScrew(81, 4, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 0.5, Me)
                addScrew(106, 4, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 0.5, Me)
                addScrew(131, 4, 15, 15, "NX", "Ακροδέκτης Νυχτερινού τιμολογίου (Ουδέτερος)", wirecolors(3), 0.5, Me)

            Case 1
                Me.information = "Τριφασική παροχή με Νυχτερινό τιμολόγιο. Παροχή από την πάνω πλευρά"
                Me.Image = My.Resources.Nyxt_FromAbove0
                addScrew(6, 117, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 1.5, Me)
                addScrew(31, 117, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 1.5, Me)
                addScrew(56, 117, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 1.5, Me)
                addScrew(81, 117, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 1.5, Me)
                addScrew(106, 117, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 1.5, Me)
                addScrew(131, 117, 15, 15, "NX", "Ακροδέκτης Νυχτερινού τιμολογίου (Ουδέτερος)", wirecolors(3), 1.5, Me)
              
            Case Else
                Me.information = "Τριφασική παροχή με Νυχτερινό τιμολόγιο. Παροχή από τα αριστερά"
                Me.Image = My.Resources.Nyxt_FromLeft0
                Me.addScrew(117, 6, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 1, Me)
                Me.addScrew(117, 31, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 1, Me)
                Me.addScrew(117, 56, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 1, Me)
                Me.addScrew(117, 81, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 1, Me)
                Me.addScrew(117, 106, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 1, Me)
                Me.addScrew(117, 131, 15, 15, "NX", "Ακροδέκτης Νυχτερινού τιμολογίου (Ουδέτερος-Ν)", wirecolors(3), 1, Me)

        End Select
        Me.setMoveBounds()
        Me.numberOfScrews = 5
        setHotkeyNumber(0)
        setHotKeyInformation(0, "(Απ)Ενεργοποίηση νυχτερινού τιμολογίου")

        state = GlobalInfo.state.leitoyrgei_kanonika
    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        screw(0).combine_all_values(V_L1)
        screw(1).combine_all_values(V_L2)
        screw(2).combine_all_values(V_L3)
        screw(3).combine_all_values(V_N)
        screw(4).combine_all_values(V_PE)
        'Αν έχει ενεργοποιηθεί το νυχτερινό
        If Me.state = GlobalInfo.state.leitoyrgei_kanonika_kai_nyxterino Then screw(5).combine_all_values(V_N)

    End Sub
    Public Overrides Function whatami() As String
        Return "POWER WITH NIGHTTIME CHARGING"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Τροφοδοσία (+νυχτερινό τιμολόγιο)"
    End Function
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        'If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        Refresh_Image_Reference_For_Simulation()

    End Sub
    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    Public Overrides Sub keypressed(whatkey As Char)
        If whatkey = getHotKey(0) Then
            If Me.state = GlobalInfo.state.leitoyrgei_kanonika Then Me.state = GlobalInfo.state.leitoyrgei_kanonika_kai_nyxterino Else Me.state = GlobalInfo.state.leitoyrgei_kanonika
        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        ' If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        If Me.state = GlobalInfo.state.leitoyrgei_kanonika Then Me.state = GlobalInfo.state.leitoyrgei_kanonika_kai_nyxterino Else Me.state = GlobalInfo.state.leitoyrgei_kanonika

    End Sub
End Class
