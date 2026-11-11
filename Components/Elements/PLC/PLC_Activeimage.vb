Public Class PLC_Activeimage
    Inherits ActiveImage
    Private MaxInputs As Integer = 8
    Private MaxOutputs As Integer = 4
    Private MaxMemory As Integer = 30
    Private MaxTimerDON As Integer = 8
    Private MaxTimerDOFF As Integer = 8
    Private MaxCounter As Integer = 8


    Dim StartedWorkingAt As Integer = -1
    Private MyPLC As PLC
    Private MyPLCResources As PLCResources
    Private MyPLCWatch As PLCWatch

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Me.Image = My.Resources.PLC



        'Select Case useStandardSymbolsDuringEdit
        '    Case False                              'Κανονική εικόνα
        'Me.Image = My.Resources.PLC
        '    Case True                               'Εικόνα με σύμβολο
        'Me.Image = My.Resources.PLC
        'End Select
    End Sub


    Public Overrides Sub initialization()
        If MyPLCWatch Is Nothing Then MyPLCWatch = New PLCWatch
        If MyPLCResources Is Nothing Then MyPLCResources = New PLCResources(MaxInputs, MaxOutputs, MaxMemory, MaxTimerDON, MaxTimerDOFF, MaxCounter, MyPLCWatch)
        If MyPLC Is Nothing Then
            MyPLC = New PLC()
            ': MyPLCResources.SetOutputEquation(0, "TON0") : MyPLCResources.SetTONEquation(0, "I0") : MyPLCResources.SetTONParameter(0, 10)
            'MyPLCResources.SetOutputEquation(1, "TOFF0") : MyPLCResources.SetTOFFEquation(0, "I0") : MyPLCResources.SetTOFFParameter(0, 10)
            'MyPLCResources.SetOutputEquation(0, "C0") : MyPLCResources.SetCounterEquation(0, "I0", "I1", "I2")
            'MyPLCResources.SetCounterParameter(0, 5)

        End If
       



        '
        nameImage()
        Me.information = "Προγραμματιζόμενος Λογικός Ελεγκτής(ΠΛΕ/PLC)- με 8 ψηφιακές εισόδους (I0-I7) και τέσσερις ψηφιακές εξόδους (Q0-Q3). Για να λειτουργήσει το PLC θα πρέπει πρώτ' απ' όλα να τροφοδοτηθεί με τάσης 230V στα άκρα L & N. Οι είσοδοι είναι ψηφιακές, δηλαδή, η κατάσταση τους θα θεωρείται από το PLC ως αληθής (true) όταν ο αντίστοιχος ακροδέκτης της εισόδου τροφοδοτηθεί με τάση 230V. Όταν ενεργοποιείται μια έξοδος τότε κλείνει η αντίστοιχη επαφή. Αν θέλετε κατά την ενεργοποίηση μιας εξόδου να εκκίνειται μια συσκευή τότε θα πρέπει να τροφοδοτήσετε την συσκευή μέσω της επαφής της εισόδου."
        addScrew(6, 4, 15, 15, "I0", "Αυτός είναι ο ακροδέκτης της πρώτης ψηφιακής εισόδου(I0). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(31, 4, 15, 15, "I1", "Αυτός είναι ο ακροδέκτης της δεύτερης ψηφιακής εισόδου(I1). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(56, 4, 15, 15, "I2", "Αυτός είναι ο ακροδέκτης της τρίτης ψηφιακής εισόδου(I2). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(81, 4, 15, 15, "I3", "Αυτός είναι ο ακροδέκτης της τέταρτης ψηφιακής εισόδου(I3). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(106, 4, 15, 15, "I4", "Αυτός είναι ο ακροδέκτης της πέμπτης ψηφιακής εισόδου(I4). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(131, 4, 15, 15, "I5", "Αυτός είναι ο ακροδέκτης της έκτης ψηφιακής εισόδου(I5). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(156, 4, 15, 15, "I6", "Αυτός είναι ο ακροδέκτης της έβδομης ψηφιακής εισόδου(I6). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(181, 4, 15, 15, "I7", "Αυτός είναι ο ακροδέκτης της όγδοης ψηφιακής εισόδου(I7). Όταν αυτός ο ακροδέκτης τροφοδοτηθεί με τάση 230V τότε το PLC θα θεωρήσει ότι η κατάσταση της πρώτης εισόδου είναι αληθής (true).", wirecolors(0), 0.5, Me)
        addScrew(206, 4, 15, 15, "L", "Αυτό είναι το πρώτο άκρο τροφοδοσίας του PLC. Όταν τα άκρα της τροφοδοσίας του PLC τροφοδοτηθούν με ηλεκτρική τάση 230V  τότε το PLC ενεργοποιείται και ξεκινά την εκτέλεση του προγράμματος του.", wirecolors(5), 0.5, Me)

        addScrew(6, 102, 15, 15, "Q0(A)", "Η πρώτη έξοδος του PLC(Q0) φέρει δυο άκρα το Q0(A) και το Q0(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q0) τότε η επαφή Q0(A)-Q0(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q0(A)-Q0(B).", wirecolors(0), 1.5, Me)
        addScrew(31, 102, 15, 15, "Q0(B)", "Η πρώτη έξοδος του PLC(Q0) φέρει δυο άκρα το Q0(A) και το Q0(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q0) τότε η επαφή Q0(A)-Q0(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q0(A)-Q0(B).", wirecolors(0), 1.5, Me)
        addScrew(56, 102, 15, 15, "Q1(A)", "Η δεύτερη έξοδος του PLC(Q1) φέρει δυο άκρα το Q1(A) και το Q1(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q1) τότε η επαφή Q1(A)-Q1(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q1(A)-Q1(B).", wirecolors(0), 1.5, Me)
        addScrew(81, 102, 15, 15, "Q1(B)", "Η δεύτερη έξοδος του PLC(Q1) φέρει δυο άκρα το Q1(A) και το Q1(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q1) τότε η επαφή Q1(A)-Q1(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q1(A)-Q1(B).", wirecolors(0), 1.5, Me)
        addScrew(106, 102, 15, 15, "Q2(A)", "Η τρίτη έξοδος του PLC(Q2) φέρει δυο άκρα το Q2(A) και το Q2(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q2) τότε η επαφή Q2(A)-Q2(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q2(A)-Q2(B).", wirecolors(0), 1.5, Me)
        addScrew(131, 102, 15, 15, "Q2(B)", "Η τρίτη έξοδος του PLC(Q2) φέρει δυο άκρα το Q2(A) και το Q2(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q2) τότε η επαφή Q2(A)-Q2(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q2(A)-Q2(B).", wirecolors(0), 1.5, Me)
        addScrew(156, 102, 15, 15, "Q3(A)", "Η τέταρτη έξοδος του PLC(Q3) φέρει δυο άκρα το Q3(A) και το Q3(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q3) τότε η επαφή Q3(A)-Q3(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q3(A)-Q3(B).", wirecolors(0), 1.5, Me)
        addScrew(181, 102, 15, 15, "Q3(B)", "Η τέταρτη έξοδος του PLC(Q3) φέρει δυο άκρα το Q3(A) και το Q3(B), στα άκρα αυτά συνδέεται μια επαφή που ελέγχεται από το PLC. Όταν ενεργοποιηθεί η έξοδος (Q3) τότε η επαφή Q3(A)-Q3(B) θα κλείσει και θα επιτρέπει τη ροή ρεύματος. Αν επιθυμείτε να συνδέσετε κάποια συσκευή που να ελέγχεται από αυτή την έξοδο, τότε τροφοδοτήστε την συσκευή μέσω της επαφής Q3(A)-Q3(B).", wirecolors(0), 1.5, Me)

        addScrew(206, 102, 15, 15, "N", "Αυτό είναι το δεύτερο άκρο τροφοδοσίας του PLC. Όταν τα άκρα της τροφοδοσίας του PLC τροφοδοτηθούν με ηλεκτρική τάση 230V  τότε το PLC ενεργοποιείται και ξεκινά την εκτέλεση του προγράμματος του.", wirecolors(3), 1.5, Me)

        Me.numberOfScrews = 17
        'Ορισμός των ορίων που θα επιτρέπεται η μετακίνηση
        Me.setMoveBounds()
        state = GlobalInfo.state.anenergo


        Dim StartedWorkingAt As Integer = 0


        'MyProgram.MaxLines()


    End Sub




    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************

    Public Overrides Sub inform_screws()
        Dim i As Integer, ou As Integer
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        'Όσο θα είναι ενεργό θα πρέπει....
        If state = GlobalInfo.state.energo Then

            '  'Θα πρέπει να ενημερώσουμε και τιμές των εισόδων του PLC
            '  For i = 0 To MaxInputs
            ' 'Ελέγχω τι είναι συνδεδεμένο σε κάθε βίδα. Αν είναι μια από τις τρεις φάσεις, τότε η τιμή της εισόδου θα είναι αληθής, αλλιώς ωευδής
            ' If screw(i).value And V_PhaseMask > 0 Then IsItL = True Else IsItL = False
            ' Debug.Print("                                              In ActiveImage I" + i.ToString + "=" + IsItL.ToString)
            ' MyPLC.SetInput(MyPLCResources, i, IsItL)
            ' Next

            'Μετά θα πρέπει να γίνει ο υπολογισμός της κατάστασης των εξόδων
            MyPLC.EvaluateOutputs(MyPLCResources)

            'Τέλος με βάση τις νέες τιμές των εξόδων θα πρέπει να ανοίξουν και να κλείσουν οι επαφές των εξόδων του PLC
            'Οπότε γίνεται σάρωση όλων των επαφών
            For ou = 0 To MaxOutputs - 1

                'Αν η έξοδος έχει ενεργοποιηθεί τότε
                If MyPLC.getOutput(MyPLCResources, ou) Then
                    'κλείσε την επαφή
                    screw(9 + ou * 2).combine_all_values(screw(10 + ou * 2).value)
                    screw(10 + ou * 2).combine_all_values(screw(9 + ou * 2).value)
                End If
            Next ou

        End If




    End Sub

    Public Overrides Function whatami() As String
        Return "PLC"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Προγραμματιζόμενος Λογικός Ελεγκτής"
    End Function





    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Dim isitl As Boolean
        Select Case state
            Case GlobalInfo.state.anenergo
                Image = My.Resources.PLC
            Case GlobalInfo.state.energo
                Image = My.Resources.PLC_Powered
        End Select

        'Θα πρέπει να ενημερώσουμε και τιμές των εισόδων του PLC
        For i = 0 To MaxInputs
            'Ελέγχω τι είναι συνδεδεμένο σε κάθε βίδα. Αν είναι μια από τις τρεις φάσεις, τότε η τιμή της εισόδου θα είναι αληθής, αλλιώς ωευδής
            If screw(i).value And V_PhaseMask > 0 Then IsItL = True Else IsItL = False
            'Debug.Print("                                              In ActiveImage I" + i.ToString + "=" + IsItL.ToString)
            MyPLC.SetInput(MyPLCResources, i, IsItL)
        Next
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

    Public Overrides Sub keypressed(whatkey As Char)


    End Sub








    '***************************************************************************************************************************************
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Sub EvaluateObject()
        Dim st = GlobalInfo.state.anenergo

        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
        Dim A1 As Long = screw(8).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(17).value And V_PhasesNeutralMask

        Dim A3 As Long = screw(8).value
        Dim A4 As Long = screw(17).value
        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(8).value Or screw(17).value



        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Or (a5 = V_N) Then st = GlobalInfo.state.anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : changestate(st) : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
    (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then st = GlobalInfo.state.anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : changestate(st) : Exit Sub




        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
      (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then st = GlobalInfo.state.energo
        changestate(st)

    End Sub

    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        Dim Truebrush As SolidBrush = New SolidBrush(Color.Red)
        Dim Falsebrush As SolidBrush = New SolidBrush(Color.White)

        Dim i As Integer

        If state = GlobalInfo.state.anenergo Then Exit Sub

        For i = 0 To MaxInputs - 1
            If (screw(i).value And V_PhaseMask) > 0 Then

                gr.FillEllipse(Truebrush, ratio * (9 + Me.Location.X + i * 25), ratio * (38 + Me.Location.Y), ratio * 6, ratio * 6)
            Else
                gr.FillEllipse(Falsebrush, ratio * (9 + Me.Location.X + i * 25), ratio * (38 + Me.Location.Y), ratio * 6, ratio * 6)
            End If


        Next

        '74-22
        For i = 0 To MaxOutputs - 1
            If MyPLCResources.GetOutput(i) Then

                gr.FillEllipse(Truebrush, ratio * (24 + Me.Location.X + i * 49), ratio * (76 + Me.Location.Y), ratio * 6, ratio * 6)
            Else
                gr.FillEllipse(Falsebrush, ratio * (24 + Me.Location.X + i * 49), ratio * (76 + Me.Location.Y), ratio * 6, ratio * 6)
            End If

            '74-22

        Next




        'gr.DrawLine(defaultPen, pos1, pos2)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        'If state = GlobalInfo.state.thermiko_energo Then changestate(GlobalInfo.state.thermiko_anenergo) Else changestate(GlobalInfo.state.thermiko_energo)
        If MyPLCWatch.Visible = False Then MyPLCWatch.Show() Else MyPLCWatch.Hide()
    End Sub


    'Άνοιγμα του παραθύρου ορισμού λογικών εξισώσεων
    Public Sub OpenEquationsWindow()
        MyPLC.OpenEquationsWindow(MyPLCResources)

    End Sub


    Public Overrides Sub Reset_all_Parameters()
        MyPLCResources.ResetAll()
    End Sub

    'Αυτό το Sub θα χρησιμοποιηθεί για να αποθηκεύσει τα δεδομένα σε αρχείο
    Public Overrides Sub SaveDataToDisk(Writer As System.IO.StreamWriter)
        MyPLCResources.SaveDataToDisk(Writer)
    End Sub

    'Αυτό το Sub θα χρησιμοποιηθεί για να αποθηκεύσει τα δεδομένα σε αρχείο
    Public Overrides Sub ReadDatafromDisk(Reader As System.IO.StreamReader)
        MyPLCResources.ReadDataFromDisk(Reader)
    End Sub
End Class
