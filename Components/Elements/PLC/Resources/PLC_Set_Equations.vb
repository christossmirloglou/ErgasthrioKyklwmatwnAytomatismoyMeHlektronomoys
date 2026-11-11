Public Class PLC_Set_Equations
    'Λίστες για προσωρινή αποθήκευση εξισώσεων
    Dim EqOUT As List(Of String) = New List(Of String)
    Dim EqMEM As List(Of String) = New List(Of String)
    Dim EqTON As List(Of String) = New List(Of String)
    Dim EqTOFF As List(Of String) = New List(Of String)
    Dim EqCNT As List(Of String) = New List(Of String)
    Dim EqCNTU As List(Of String) = New List(Of String)
    Dim EqCNTD As List(Of String) = New List(Of String)
    'Λίστες για προσωρινή αποθήκευση παραμέτρων
    Dim PaTON As List(Of Integer) = New List(Of Integer)
    Dim PaTOFF As List(Of Integer) = New List(Of Integer)
    Dim PaCNT As List(Of Integer) = New List(Of Integer)
    Dim selectedOutput As Integer = 0
    Dim myResources As PLCResources
    Dim CurrentSelection As String = ""

    Private Function WhatAreTheInputsAndOutputsOfThisPLC() As String
        Dim txt As String
        txt = "  Για να προγραμματίσετε το PLC θα πρέπει να γράψετε την λογική εξίσωση κάθε στοιχείου." + vbNewLine + _
              "  Για να το κάνετέ αυτό θα πρέπει πρώτα να επιλέξετε το στοιχείο που σας ενδιαφέρει, στη " + _
              "συνέχεια πρέπει να πληκτρολογήσετε την λογική εξίσωση και τέλος να πιέσετε το πλήκτρο " + _
              "με τίτλο 'Καταχώρηση'." + vbNewLine + _
              "  Για να ισχύσουν οι αλλαγές που κάνατε θα πρέπει να πιέσετε στο τέλος το πλήκτρο " + _
              "με τίτλο 'Αποθήκευση και έξοδος. Αν για κάποιο λόγο δεν θέλετε να αποθηκευτούν οι " + _
              "αλλαγές, τότε πιέστε το πλήκτρο 'Ακύρωση όλων των αλλαγών' και όλες οι αλλαγές που " + _
              "κάνατε στις λογικές εξισώσεις θα χαθούν και ο ελεγκτής θα επανέλθει στην κατάσταση " + _
              "που βρισκόταν πριν να εκκινήσετε την επεξεργασία των λογικών εξισώσεων." + vbNewLine + vbNewLine + _
              "Μπορείτε να εκτελέσετε τις παρακάτω λογικές πράξεις:" + vbNewLine + _
              "Λογικό ΚΑΙ (AND) με το σύμβολο &, πχ I1&I2." + vbNewLine + _
              "Λογικό Ή (OR) με το σύμβολο |, πχ Q1|Q2." + vbNewLine + _
              "Λογικό Αποκλειστικό Ή (XOR) με το σύμβολο ^, πχ T1^T2." + vbNewLine + _
              "Λογική Άρνηση NOT με το σύμβολο ! που όμως θα πρέπει να προηγείται του στοιχείου, πχ !I3." + vbNewLine + _
              "Μπορείτε να χρησιμοποιήσετ και παρενθέσεις, πχ !(I1|I2)&(Q2^!T1&(I5|Q2))" + vbNewLine + vbNewLine + _
                "Το συγκεκριμένο PLC διαθέτει τους παρακάτω πόρους: "
        txt += myResources.Get_PLC_MaxInputs.ToString + " είσοδοι: "
        For i = 0 To myResources.Get_PLC_MaxInputs - 1
            txt = txt + "I" + i.ToString + ", "
        Next
        txt = txt + vbNewLine + myResources.Get_PLC_MaxOutputs.ToString + " έξοδοι:"
        For i = 0 To myResources.Get_PLC_MaxOutputs - 1
            txt = txt + "Q" + i.ToString + ", "
        Next
        txt = txt + vbNewLine + myResources.Get_PLC_MaxMemory.ToString + " μνήμες:"
        For i = 0 To myResources.Get_PLC_MaxMemory - 1
            txt = txt + "M" + i.ToString + ", "
        Next
        txt = txt + vbNewLine + myResources.Get_PLC_MaxTimerDON.ToString + " χρονικά DelayOn:"
        For i = 0 To myResources.Get_PLC_MaxTimerDON - 1
            txt = txt + "TON" + i.ToString + ", "
        Next
        txt += vbNewLine + myResources.Get_PLC_MaxTimerDOff.ToString + " χρονικά DelayOff:"
        For i = 0 To myResources.Get_PLC_MaxTimerDOff - 1
            txt = txt + "TOFF" + i.ToString + ", "
        Next
        txt += vbNewLine + myResources.Get_PLC_MaxCounter.ToString + " απαριθμητές:"
        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            txt = txt + "C" + i.ToString + "(" + "CU" + i.ToString + ", " + "CD" + i.ToString + "), "
        Next
        txt += vbNewLine + vbNewLine + "Παράδειγμα: I1&Q2^T1&!(T3|Q3) = I1 AND Q2 XOR T1 AND NOT (T3 OR Q3)"
        txt += "  Για να λειτουργήσει ένα χρονικό Delay On (TON) ή Delay Off (TOFF) θα πρέπει πρώτα να το ενεργοποιήσετε, δηλαδή θα πρέπει να ισχύει πχ ότι TON2=1. Στη συνέχεια σε οποιοδήποτε μέρος του κυκλώματος" + _
            "κάνετε ανάγνωση της κατάστασης του TON2 η τιμή που θα λάβετε θα εξαρτάται από την κατάσταση της εξόδου του, δηλαδή αν Q2=TON2, TON2=I1 και έχετε ρυθμίσει τον χρόνο στο 1sec, τότε αν κρατήσετε " + _
            "πατημένο το I1 για περισσότερο από 1sec τότε το Q2 θα πάρει τιμή 1." + vbNewLine + _
            "  Για να λειτουργήσει ένας απαριθμητής θα πρέπει να τον ενεργοποιήσετε (πχ C0=1 ή C0=I5) και να ορίσετε την παράμετρο του (δηλαδή τον αριθμό που θα ενεργοποιείται). Στη συνέχεια μπορείτε να" + vbNewLine + _
            "μετρήσετε προς τα πάνω με την εντολή CU0 = Count Up 0 και προς τα κάτω με την CD0 = Count Down 0. Παράδειγμα: Ρυθμίζω το Q0=C0, το C0=I0 και την παράμετρο του σε 5. Ρυθμίζω το CU0=I1 και CD0=I2" + vbNewLine + _
            "Τώρα αν πιέσετε το Ι0 ενεργοποιείται ο απαριθμητής. Αν στη συνέχεια πιέσετε 5 φορές το Ι1 (για να μετρήσει προς τα πάνω 5 φορές 1,2,3,4,5) τότε θα ενεργοποιηθεί το Q0."


        Return txt
    End Function
    Private Sub refresh_list()
        Select Case CurrentSelection
            Case "Q"
                ClickQ()
            Case "M"
                clickM()
            Case "TON"
                clickTON()
            Case "TOFF"
                clickTOFF()
            Case "C"
                clickC()
            Case "CU"
                clickCU()
            Case "CD"
                clickCD()

        End Select

    End Sub


    Public Sub Initialize(ByRef Resources As PLCResources)
        Dim i As Integer
        SelectOutputs.Text = Resources.Get_PLC_MaxOutputs.ToString + " Έξοδοι"
        SelectMemory.Text = Resources.Get_PLC_MaxMemory.ToString + " Μνήμες"
        SelectTON.Text = Resources.Get_PLC_MaxTimerDON.ToString + " Χρονικά Delay On"
        SelectToff.Text = Resources.Get_PLC_MaxTimerDOff.ToString + " Χρονικά Delay Off"
        SelectCounter.Text = Resources.Get_PLC_MaxCounter.ToString + " Απαριθμητές"

        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""

        myResources = Resources
        'MsgBox(myResources.GetHashCode.ToString + " " + Resources.GetHashCode.ToString)
        EqOUT.Clear()
        For i = 0 To myResources.Get_PLC_MaxOutputs - 1
            'Αποθηκεύω τις εξισώσεις ώστε να μην κάνω μόνιμες αλλαγές
            EqOUT.Add(Resources.GetOutputEquation(i))
        Next
        EqMEM.Clear()
        For i = 0 To myResources.Get_PLC_MaxMemory - 1
            'Αποθηκεύω τις εξισώσεις ώστε να μην κάνω μόνιμες αλλαγές
            EqMEM.Add(Resources.GetMemoryEquation(i))
        Next
        EqTON.Clear()
        For i = 0 To myResources.Get_PLC_MaxTimerDON - 1
            'Αποθηκεύω τις εξισώσεις ώστε να μην κάνω μόνιμες αλλαγές
            EqTON.Add(Resources.GetTONEquation(i))
            'Και τις παραμέτρους
            PaTON.Add(Resources.GetTONParameter(i))
        Next
        EqTOFF.Clear()
        For i = 0 To myResources.Get_PLC_MaxTimerDOff - 1
            'Αποθηκεύω τις εξισώσεις ώστε να μην κάνω μόνιμες αλλαγές
            EqTOFF.Add(Resources.GetTOffEquation(i))
            'Και τις παραμέτρους
            PaTOFF.Add(Resources.GetTOffParameter(i))
        Next
        EqCNT.Clear()
        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            'Αποθηκεύω τις εξισώσεις ώστε να μην κάνω μόνιμες αλλαγές
            EqCNT.Add(Resources.GetCounterEquation(i))
            EqCNTU.Add(Resources.GetCounterUEquation(i))
            EqCNTD.Add(Resources.GetCounterDEquation(i))
            'Και τις παραμέτρους
            PaCNT.Add(Resources.GetCounterParameter(i))
        Next


        ListOfEquations.Items().Clear()

        'Debug.Print("PLCRESOURCES HASH after:" + Resources.GetHashCode.ToString)
        'Debug.Print("MYRESOURCES HASH:" + myResources.GetHashCode.ToString)

    End Sub


    Private Sub ListOfEquations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListOfEquations.SelectedIndexChanged
        Dim FoundEq As Integer = ListOfEquations.Text.IndexOf("=")
        Dim t As String
        selectedOutput = ListOfEquations.SelectedIndex
        SelectedOutputLabel.Text = CurrentSelection + (selectedOutput).ToString
        t = Mid(ListOfEquations.Text, FoundEq + 2, ListOfEquations.Text.Length)
        Dim FoundHash As Integer = t.IndexOf("  #")

        If FoundHash > -1 Then
            EquationEditBox.Text = Mid(t, 1, FoundHash)
        Else
            EquationEditBox.Text = t
        End If

        'Το Textbox των παραμέτρων θα συμπληρωθεί μόνο για TON TOFF & Counter
        'Αν η επιλογή περιέχει την λέξη TON.

        If (SelectedOutputLabel.Text.IndexOf("TON") = 0 Or _
            SelectedOutputLabel.Text.IndexOf("TOFF") = 0 Or _
            SelectedOutputLabel.Text.IndexOf("C") = 0) And Not (SelectedOutputLabel.Text.IndexOf("CU") = 0 Or SelectedOutputLabel.Text.IndexOf("CD") = 0) Then ParameterEditBox.Text = Mid(t, FoundHash + 4, t.Length) Else ParameterEditBox.Text = ""

    End Sub


    Private Sub Kataxwrhsh()
        Dim Eqnow As String
        Dim parnow As Integer

        If CurrentSelection = "" Then MsgBox("Επιλέξτε πρώτα το στοιχείο που θέλετε να επεξεργαστείτε.") : Exit Sub
        EquationEditBox.Text = Trim(UCase(EquationEditBox.Text).Replace(" ", ""))
        Eqnow = myResources.EquationSolver_Complex(EquationEditBox.Text)
        parnow = Val(ParameterEditBox.Text)

        If Eqnow <> "0" And Eqnow <> "1" Then
            MsgBox("Η εξίσωση σας δεν είναι σωστή και δεν μπορεί να καταχωρηθεί.")
            Exit Sub
        End If

        If parnow < 0 And parnow > 50 Then
            MsgBox("Η παράμετρος είναι εκτός ορίων (π>0 & π<50)")
            Exit Sub
        End If


        Select Case CurrentSelection
            Case "Q"
                EqOUT(selectedOutput) = EquationEditBox.Text
            Case "M"
                EqMEM(selectedOutput) = EquationEditBox.Text
            Case "TON"
                EqTON(selectedOutput) = EquationEditBox.Text
                PaTON(selectedOutput) = parnow
            Case "TOFF"
                EqTOFF(selectedOutput) = EquationEditBox.Text
                PaTOFF(selectedOutput) = parnow
            Case "C"
                EqCNT(selectedOutput) = EquationEditBox.Text
                PaCNT(selectedOutput) = parnow
            Case "CU"
                EqCNTU(selectedOutput) = EquationEditBox.Text
            Case "CD"
                EqCNTD(selectedOutput) = EquationEditBox.Text

        End Select
        refresh_list()

        'Debug.Print("MYRESOURCES HASH IN CHECK:" + myResources.GetHashCode.ToString)


    End Sub

    Private Sub CheckAndChange_Click(sender As Object, e As EventArgs) Handles CheckAndChange.Click
        Kataxwrhsh()

    End Sub


    Private Sub ClickQ()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "Q"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxOutputs - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("Q" + i.ToString + " = " + EqOUT(i))
        Next
    End Sub
    Private Sub SelectOutputs_Click(sender As Object, e As EventArgs) Handles SelectOutputs.Click
        ClickQ()
    End Sub


    Private Sub clickM()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "M"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxMemory - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("M" + i.ToString + " = " + EqMEM(i))
        Next

    End Sub
    Private Sub SelectMemory_Click(sender As Object, e As EventArgs) Handles SelectMemory.Click
        clickM()
    End Sub





    Private Sub clickC()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "C"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("C" + i.ToString + " = " + EqCNT(i) + "  #" + PaCNT(i).ToString)
        Next

    End Sub
    Private Sub SelectCounter_Click(sender As Object, e As EventArgs) Handles SelectCounter.Click
        clickC()
    End Sub


    Private Sub clickTOFF()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "TOFF"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxTimerDOff - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("TOFF" + i.ToString + " = " + EqTOFF(i) + "  #" + PaTOFF(i).ToString)
        Next

    End Sub
    Private Sub SelectToff_Click_1(sender As Object, e As EventArgs) Handles SelectToff.Click
        clickTOFF()
    End Sub

    Private Sub clickTON()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "TON"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq
        For i = 0 To myResources.Get_PLC_MaxTimerDON - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("TON" + i.ToString + " = " + EqTON(i) + "  #" + PaTON(i).ToString)
        Next

    End Sub
    Private Sub SelectTON_Click_1(sender As Object, e As EventArgs) Handles SelectTON.Click
        clickTON()
    End Sub

    Private Sub Helpme_Click(sender As Object, e As EventArgs) Handles Helpme.Click
        MsgBox(WhatAreTheInputsAndOutputsOfThisPLC)
    End Sub

    Private Sub PLC_Set_Equations_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Save_And_Exit_Click(sender As Object, e As EventArgs) Handles Save_And_Exit.Click
        For i = 0 To myResources.Get_PLC_MaxOutputs - 1
            myResources.SetOutputEquation(i, EqOUT(i))
        Next

        For i = 0 To myResources.Get_PLC_MaxMemory - 1
            myResources.SetMemoryEquation(i, EqMEM(i))
        Next

        For i = 0 To myResources.Get_PLC_MaxTimerDON - 1
            myResources.SetTONEquation(i, EqTON(i))
            myResources.SetTONParameter(i, PaTON(i))
        Next
        For i = 0 To myResources.Get_PLC_MaxTimerDOff - 1
            myResources.SetTOFFEquation(i, EqTOFF(i))
            myResources.SetTOFFParameter(i, PaTOFF(i))
        Next
        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            myResources.SetCounterEquation(i, EqCNT(i), EqCNTU(i), EqCNTD(i))
            myResources.SetCounterParameter(i, PaCNT(i))

        Next
        Me.Hide()

    End Sub

    Private Sub Discard_All_Click(sender As Object, e As EventArgs) Handles Discard_All.Click
        Me.Hide()

    End Sub

    Private Sub EquationEditBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EquationEditBox.KeyPress
        If e.KeyChar = Chr(13) Then
            Kataxwrhsh()

        End If
    End Sub

    Private Sub ParameterEditBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ParameterEditBox.KeyPress
        If e.KeyChar = Chr(13) Then
            Kataxwrhsh()

        End If

    End Sub

    Private Sub clickCU()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "CU"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("CU" + i.ToString + " = " + EqCNTU(i))
        Next

    End Sub
   
    Private Sub CUButton_Click(sender As Object, e As EventArgs) Handles CUButton.Click
        clickCU()

    End Sub

    Private Sub CDButton_Click(sender As Object, e As EventArgs) Handles CDButton.Click
        clickCD()
    End Sub


    Private Sub clickCD()
        Dim i As Integer
        'Σβήνω όλα τα στοιχεία της λίστας
        CurrentSelection = "CD"
        ListOfEquations.Items().Clear()
        SelectedOutputLabel.Text = ""
        EquationEditBox.Text = ""
        ParameterEditBox.Text = ""
        'Αποθήκευση των τρέχουσων εξισώσεων στο Eq

        For i = 0 To myResources.Get_PLC_MaxCounter - 1
            'Προσθέτω την κάθε εξίσωση στη λίστα
            ListOfEquations.Items.Add("CD" + i.ToString + " = " + EqCNTD(i))
        Next

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class


