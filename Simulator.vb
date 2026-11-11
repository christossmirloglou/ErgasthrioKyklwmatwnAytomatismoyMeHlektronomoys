Public Class Simulator

    Private working_now As Boolean = False
    Private stop_simulation As Boolean = True
    Private Sub calculate_all_components()
        Dim antik As Integer

        For antik = 0 To numberOfActiveObjects - 1
            allActiveObjects(antik).Inform_Screws()

        Next

    End Sub

    Public Function is_Simulation_Running() As Boolean
        Return Not stop_simulation
    End Function

    'Μονο για development mode
    Sub show_all_connections()

        Dim graph As Graphics = Me.CreateGraphics
        Dim antik, result As Integer
        Dim bid, wir As Integer
        Dim ActiveObj As ActiveImage
        Dim ScrewObject As SingleScrewData = Nothing
        Dim fnt As Font
        Dim pt As Point
        fnt = New Font("Arial", 10 * ratiovalue, FontStyle.Bold)


        Dim c As Integer = 3


        'Για κάθε αντικείμενο
        For antik = 0 To numberOfActiveObjects - 1
            ActiveObj = allActiveObjects(antik)

            'Για κάθε βίδα του αντικείμενου 
            For bid = 0 To ActiveObj.numberOfScrews
                result = ActiveObj.returnScrew(bid, ScrewObject)


                For wir = 0 To ScrewObject.get_total_connections - 1



                    c = c + 1


                    pt = New Point((ScrewObject.parent.Location.X + ScrewObject.X) * ratiovalue, (ScrewObject.parent.Location.Y + ScrewObject.Y) * ratiovalue)


                    graph.DrawString(explain_Value(ScrewObject.value And V_PhasesNeutralMask), fnt, Brushes.Yellow, pt)
                Next



            Next

        Next
        'ListBox1.Items.Add(


    End Sub

    'Εδω θα οριστούν τα hotkeys για κάθε ενεργό αντικείμενο
    'Το κάθε αντικείμενο μπορεί να ζητήσει μέσω του gethotkeynumber τον αριθμό των hotkeys που επιθυμεί.
    'Επειδή όμως αυτά θα πρέπει να αντιστοιχιθούν κατά το Runtime, γι' αυτό η ανάθεση γίνεται εδώ.
    Private Sub Set_All_Hotkeys()
        Dim obj, c As Integer
        Dim theKey As Char
        Dim allchars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*(),.<>/?;:'\|[{]}αβγδεζηθικλμνξοπρστυφχψωΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ".ToCharArray
        Dim posinarray As Integer = 0

        For obj = 0 To numberOfActiveObjects - 1
            For c = 0 To allActiveObjects(obj).getHotkeyNumber
                theKey = allchars(posinarray) : posinarray = posinarray + 1
                allActiveObjects(obj).setHotKey(c, theKey)
            Next
        Next
    End Sub



    'Όταν γίνεται διπλό κλικ επάνω στον προσομοιωτή
    'Ψάχνω να βρω ποιο είναι το σχετικό αντικείμενο και το ενημερώνω
    Private Sub Simulator_DoubleClick(sender As Object, e As MouseEventArgs) Handles Me.DoubleClick
        Dim i As Integer
        Dim obj As ActiveImage

        If stop_simulation Then Exit Sub

        For i = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(i)
            If (e.Location.X > (obj.Location.X * ratiovalue)) And (e.Location.Y > (obj.Location.Y * ratiovalue)) And _
               (e.Location.X < ((obj.Location.X + obj.Width) * ratiovalue)) And (e.Location.Y < ((obj.Location.Y + obj.Height) * ratiovalue)) Then
                obj.HasBeenClickedOnDuringSimulation()
            End If
        Next

    End Sub
    Private Sub Simulator_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        exitSimulator()

    End Sub




    'Αρχική ανάλυση του κυκλώματος εύρεση όλων των συνδέσεων μεταξύ των βιδών. 
    'Εντοπίζει κάθε βίδα με ποιές άλλες βίδες και αντικείμενα συνδέεται.
    'Πρέπει να γίνει κατά την εκκίνηση της προσομοίωσης
    Private Sub initial_analysis()
        Dim antik, result As Integer
        Dim bid, wir As Integer
        Dim ActiveObj As ActiveImage
        Dim ScrewObject As SingleScrewData = Nothing
        Dim ok, ch As Boolean
        Dim s As String
        ch = False

        Dim graph As Graphics = Me.CreateGraphics

        'Για κάθε αντικείμενο
        For antik = 0 To numberOfActiveObjects - 1
            ActiveObj = allActiveObjects(antik)

            'Για κάθε βίδα του αντικείμενου 
            For bid = 0 To ActiveObj.numberOfScrews
                result = ActiveObj.returnScrew(bid, ScrewObject)
                ScrewObject.parent = ActiveObj
                'Θα ψάξουμε να βρούμε τώρα όλους τους αγωγούς που συνδέονται στη συγκεκριμένη βίδα
                'Σάρωση όλων των Wires
                For wir = 0 To numberOfWires

                    'Αν δούμε ότι το συγκεκριμένο Wire, (είτε στην αρχή του, είτε στο τέλος του) συνδέεται με την βίδα που μας ενδιαφέρει 
                    'τότε καταχωρούμε τα στοιχεία του συνδεδεμένου, αντικείμενου, βίδας και αγωγού

                    'Αν είναι στην αρχή του αγωγού
                    'Αν το πρώτο αντικείμενο που ακουμπάει σε αυτό τον αγωγό είναι το ίδιο με το αντικείμενο υπο έλεγχο
                    'Και η βίδα που ανήκει στο παραπάνω αντικείμενο και η βίδα του υπό έλεγχο αντικείμενου είναι ίδιες
                    'Τότε το πρώτο άκρο του αγωγού ξέρουμε ότι ακουμπάει στο υπο έλεγχο αντικείμενο και βίδα
                    ch = False
                    s = "-Αντικείμενο " & antik.ToString & "  Βίδα " & bid.ToString & " DATA ΒΙΔΑΣ " & ScrewObject.reportOnValues

                    If ((wires.allWires(wir).getFirstObject(ok).Tag = ActiveObj.Tag) And (wires.allWires(wir).getFirstScrew = bid)) Then _
                    'Οπότε θα πρέπει να σημειώσω τα στοιχεία του ΔΕΥΤΕΡΟΥ άκρου του αγωγού
                        ScrewObject.add_connection(wires.allWires(wir), wires.allWires(wir).getSecondObject(ok).returnScrewData(wires.allWires(wir).getSecondScrew), wires.allWires(wir).getSecondScrew)
                        s = s + " Συνδ Αντ#" & wires.allWires(wir).getSecondObject(ok).Tag & "     Βίδα " & wires.allWires(wir).getSecondScrew.ToString
                        ch = True
                    End If


                    'Ομοίως αν βρώ ότι το σημείο επαφής είναι το δεύτερο άκρο του αγωγού, σημείωνω το πρώτο άκρο

                    If ((wires.allWires(wir).getSecondObject(ok).Tag = ActiveObj.Tag) And (wires.allWires(wir).getSecondScrew = bid)) Then _
                'Οπότε θα πρέπει να σημειώσω τα στοιχεία του ΔΕΥΤΕΡΟΥ άκρου του αγωγού
                        ScrewObject.add_connection(wires.allWires(wir), wires.allWires(wir).getFirstObject(ok).returnScrewData(wires.allWires(wir).getFirstScrew), wires.allWires(wir).getFirstScrew)
                        s = s + " Συνδ Αντ#" & wires.allWires(wir).getFirstObject(ok).Tag & " Β " & wires.allWires(wir).getFirstScrew.ToString
                        ch = True
                    End If
                    'If ch Then ListBox1.Items.Add(s)
                Next
            Next
        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        initial_analysis()

    End Sub


    Public Sub A_Key_Was_Pressed(whatkey As Char)
        Dim i As Integer
        Dim fnt = New Font("Arial", 12, FontStyle.Bold)
        'Me.Text = whatkey
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).keypressed(whatkey)
        Next
    End Sub

    Private Sub Simulator_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim ch As Char = e.KeyChar
        'MsgBox("yo")

        A_Key_Was_Pressed(ch)
    End Sub




    Private Sub Simulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        Dim p As New Point(0, 0)
        'Ρυθμίζω έτσι ώστε αρχικά να φαίνεται το παράθυρο Watch δίπλα στον προσομοιωτή.
        Me.Location = p
        Me.Width = My.Computer.Screen.WorkingArea.Width - Watch.Width
        Me.Height = My.Computer.Screen.WorkingArea.Height
        Watch.information.Text = ""

        watch_visibility_changed()
        p = New Point(Me.Width, 0)
        Watch.Location = p
        Watch.Height = Me.Height

        Me.KeyPreview = True            'Απαραίτητο για να μπορούμε να κάνουμε ανάγνωση των πλήκτρων

        'inform_runsteps()



        reset_parameters()
        draw_everything()
    End Sub



    Public Sub reset_parameters()
        'Αν πρόκειται για PLC θα πρέπει να μηδενίσω τις τιμές των παραμέτρων
        For i = 0 To numberOfActiveObjects - 1
            'Debug.Print("Evaluating " + i.ToString)

            'If allActiveObjects(i).WhatAmI = "PLC" Then allActiveObjects(i).reset_all_parameters()
            allActiveObjects(i).reset_all_parameters()
        Next
    End Sub



    '----------------------------------------------------------
    'Σχεδίαση όλων των αντικειμένων και των γραμμών


    Public Sub draw_everything()
        Dim i As Integer
        'Σχεδιάζω τα αντικείμενα
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).Refresh_Image_Reference_For_Simulation()
            allActiveObjects(i).DrawImage(Me, ratiovalue, i)
        Next

        wires.drawAllWires_for_Simulation(Me, ratiovalue)
        'show_all_connections() 'μονο για development mode
    End Sub

    '----------------------------------------------------------
    'Ενημέρωση της λίστας καταστάσεων


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer

        Dim graph As Graphics = Me.CreateGraphics
        If stop_simulation Then Exit Sub
        If working_now Then Exit Sub
        working_now = True

        'Me.Refresh()

        'Πρώτα σβήνω όλα τα δεδομένα
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).Reset_Screws()
        Next
        Sim_Error_Text = ""
        Sim_Grounding_Error_Text = ""
        Simulation_Values_Have_Changed = True

        'Μετά ενημερώνω τις τιμές των βιδών με βάση την τρέχουσα κατάσταση των εξαρτημάτων
        While Simulation_Values_Have_Changed
            Simulation_Values_Have_Changed = False
            calculate_all_components()          'Μετά από αυτό το σημείο έχει ενημερωθεί το shortcircuit
        End While


        'Ελέγχω αν εξαρτήματα με αυτόματη συμπεριφορά όπως θερμικά και ρελέ πρέπει να αλλάξουν κατάσταση
        For i = 0 To numberOfActiveObjects - 1
            'Debug.Print("Evaluating " + i.ToString)

            allActiveObjects(i).EvaluateObject()
        Next
        'Debug.Print("Done Evaluating")



        draw_everything()
        If Show_Voltage_During_Simulation Then show_all_connections() 'Μονο για development mode
        working_now = False
        Watch.information.Text = Sim_Error_Text + vbNewLine + Sim_Grounding_Error_Text
        InformWatchForm(False)
        increase_runsteps()
        If ShortCircuit.FaultFound Then
            pausesimulation()
            ShortCircuit.FaultFound = False
            MsgBox("Εντοπίστηκε βραχυκύκλωμα, σταματά η προσομοίωση.", vbOKOnly, "Βραχυκύκλωμα")
        End If
        If Stop_Simulation_On_Error And Sim_Error_Text <> "" Then pausesimulation()
        If Stop_Simulation_On_Grounding_Error And Sim_Grounding_Error_Text <> "" Then pausesimulation()

    End Sub


    Private Sub runsimulation()
        Simulation_runsteps = 0
        inform_runsteps()

        initial_analysis()
        Set_All_Hotkeys()
        stop_simulation = False
        ΕκκίνησηToolStripMenuItem.Text = "Παύση"
        ΕκκίνησηToolStripMenuItem.Image = My.Resources.pause_button
        'Αν έχει πατηθεί η εκτέλεση ενός βήματος τότε παύση.

    End Sub

    Private Sub pausesimulation()
        stop_simulation = True
        ΕκκίνησηToolStripMenuItem.Text = "Εκκίνηση"
        ΕκκίνησηToolStripMenuItem.Image = My.Resources.play_button

    End Sub
    Private Sub ΕκκίνησηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕκκίνησηToolStripMenuItem.Click
        Select Case stop_simulation
            Case True
                If ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Checked = True Then show_watch()
                runsimulation()
            Case False
                pausesimulation()

        End Select
    End Sub


    Sub resized()
        'Information.Location = New Point(Me.Width - Information.Width - 100, Me.Height - Information.Height - 100)

        If Me.Visible Then draw_everything()


    End Sub

    Private Sub Simulator_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then zoom_in() Else zoom_out()
    End Sub


    Private Sub Simulator_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        resized()
    End Sub

    Private Sub Simulator_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            resized()
            Watch.information.Text = ""
            If ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Checked Then Watch.Show()

        Else
            exitSimulator()

        End If
    End Sub

    Private Sub zoom_in()
        If ratiovalue < 3 Then
            ratiovalue = ratiovalue + 0.1
            initial_analysis()
            Me.Refresh()
            draw_everything()
        End If

    End Sub

    Private Sub zoom_out()
        If ratiovalue > 0.5 Then
            ratiovalue = ratiovalue - 0.1
            initial_analysis()
            Me.Refresh()
            draw_everything()

        End If

    End Sub

    Private Sub ΜεγέθυνσηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΜεγέθυνσηToolStripMenuItem.Click
        zoom_in()

    End Sub

    Private Sub ΣμίκρινσηToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣμίκρινσηToolStripMenuItem.Click
        zoom_out()
    End Sub

    Public Sub reset_simulation()
        Dim antik, bid As Integer
        Dim obj As ActiveImage
        Dim scr As SingleScrewData
        For antik = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(antik)

            'Για κάθε βίδα του αντικείμενου 
            For bid = 0 To obj.numberOfScrews
                scr = obj.returnScrewData(bid)
                scr.value = 0
            Next

        Next
        Simulation_runsteps = 0
        inform_runsteps()
        reset_parameters()

    End Sub

    Sub inform_runsteps()
        Watch.StepNumber.Text = Simulation_runsteps.ToString
    End Sub

    Sub increase_runsteps()
        Simulation_runsteps = Simulation_runsteps + 1
        inform_runsteps()
    End Sub
    Public Sub reset_screw_connections()
        Dim obj As ActiveImage
        Dim scr As SingleScrewData
        For antik = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(antik)

            'Για κάθε βίδα του αντικείμενου 
            For bid = 0 To obj.numberOfScrews
                scr = obj.returnScrewData(bid)
                scr.reset_connections()
            Next

        Next

    End Sub

    Private Sub reset_all_states()
        Dim antik As Integer
        Dim obj As ActiveImage
        For antik = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(antik)
            obj.Initialization()

        Next
    End Sub
    Public Sub reset_all()


        reset_simulation()
        reset_all_states()
        reset_screw_connections()
        draw_everything()

    End Sub
    Private Sub ΕπαναφοράToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΕπαναφοράToolStripMenuItem.Click
        pausesimulation()
        reset_all()
    End Sub
    Public Sub exitSimulator()
        Dim i As Integer
        Dim simval As Boolean = SimulationSymbols
        SimulationSymbols = False
        pausesimulation()

        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).Refresh_Image_Reference_For_Simulation()
        Next
        useStandardSymbolsDuringEdit = False
        Edit.ΠροβολήΣυμβόλωνToolStripMenuItem.Checked = useStandardSymbolsDuringEdit
        'changeAllImages()

        ratiovalue = 1
        initial_analysis()
        Me.Refresh()
        reset_all()
        Watch.Visible = False
        Me.Visible = False
        SimulationSymbols = simval

        Edit.Enabled = True
        wires.drawAllWires()
        Edit.refresh_all_activeobjects()
    End Sub
    Private Sub ΈξοδοςToolStripMenuItem_Click(sender As Object, e As EventArgs)

        exitSimulator()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    'Συμπλήρωση των βασικών στοιχείων του Watch form
    Sub InformWatchForm(Clearit As Boolean)
        Dim obj As ActiveImage
        Dim i As Integer
        Dim line As Integer = 0
        Dim txt As String
        Watch.StepNumber.Text = Simulation_runsteps.ToString
        If Clearit Then Watch.Keys.Items().Clear()
        On Error GoTo skipit
        For antik = 0 To numberOfActiveObjects - 1
            obj = allActiveObjects(antik)
            txt = antik.ToString + ". " + obj.WhatAmIGreek + " " + state_explained(obj.state)
            If Clearit Or (Watch.Keys.Items.Count < line + 1) Then Watch.Keys.Items.Add(txt) Else Watch.Keys.Items(line) = txt

            If obj.getHotkeyNumber > -1 Then

                For i = 0 To obj.getHotkeyNumber
                    line = line + 1
                    txt = "       -Πιέστε " + obj.getHotKey(i).ToString + " για: " + obj.getHotKeyInformation(i)
                    If Clearit Or (Watch.Keys.Items.Count < line + 1) Then Watch.Keys.Items.Add(txt) Else Watch.Keys.Items(line) = txt
                Next

            End If
            line = line + 1
        Next
skipit:
    End Sub


    Public Sub hide_watch()
        ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Checked = False
        Watch.Visible = False

    End Sub


    Public Sub show_watch()
        ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Checked = True
        Set_All_Hotkeys()
        InformWatchForm(True)
        Watch.Show()
    End Sub

    Public Sub watch_visibility_changed()
        Select Case ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Checked
            Case False
                show_watch()
            Case True
                hide_watch()
        End Select

    End Sub


    Private Sub ΠαρακολούθησηΚατάστασηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Click
        watch_visibility_changed()
    End Sub

    Private Sub ΈξοδοςToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ΈξοδοςToolStripMenuItem1.Click

    End Sub

    Private Sub ΈξοδοςToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ΈξοδοςToolStripMenuItem2.Click
        exitSimulator()

    End Sub

    Private Sub ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.Click
        Dim tick As Integer
        Dim responce As String
        Dim newtick As Integer
        tick = Timer1.Interval
        responce = InputBox("Αυτή τη στιγμή ο προσομοιωτής εκτελεί ένα βήμα κάθε " + tick.ToString + "ms." + vbNewLine + "Μπορείτε παρακάτω να ορίσετε νέα διάρκεια βήματος σε ms." + vbNewLine + "πχ. γράψτε 500 για μισό δευτερόλεπτο.", "Ρύθμιση διάρκειας βήματος προσομοίωσης", tick.ToString)
        If responce <> "" Then
            Try
                newtick = Integer.Parse(responce)
                If newtick > 100 And newtick < 20000 Then Timer1.Interval = newtick : MsgBox("Έγινε ρύθμιση της νέας διάρκειας βήματος σε " + newtick.ToString + "ms", MsgBoxStyle.OkOnly, "Επιτυχής ρύθμιση")

            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub SetSoundOnMenuImage()
        Select Case soundon
            Case False
                ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Image = My.Resources.sound_on_button
                ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Text = "Ενεργοποίηση ήχου"
            Case True
                ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Image = My.Resources.sound_mute_button
                ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Text = "Σίγαση ήχου"
        End Select
    End Sub

    Private Sub ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        soundon = Not soundon
        SetSoundOnMenuImage()






    End Sub

    Private Sub ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Click
        If Not Me.Visible Then Exit Sub
        Dim i As Integer
        SimulationSymbols = Not SimulationSymbols
        For i = 0 To numberOfActiveObjects - 1
            allActiveObjects(i).Refresh_Image_Reference_For_Simulation()
            draw_everything()
        Next
        ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Checked = SimulationSymbols
    End Sub

    Private Sub ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem.Click
        Process.Start("https://youtu.be/MY5xyCtk21I")


    End Sub

 
End Class
