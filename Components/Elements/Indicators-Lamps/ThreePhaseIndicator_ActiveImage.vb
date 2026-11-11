Public Class ThreePhaseIndicator_ActiveImage
    Inherits ActiveImage
    Private lighton() As Boolean = {False, False, False}



    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources._3phIndicator
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.C3phIndicator
        End Select
    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()
        Me.information = "Τριπλή ενδεικτική λυχνία για ένδειξη παρουσίας τάσης και στις τρεις φάσεις. Συνδέστε τις τρεις φάσεις στις επάνω τρεις βίδες και τον ουδέτερο στην κάτω για να λειτουργήσει."
        nameImage()
        addScrew(31, 4, 15, 15, "L1", "Συνδέστε την πρώτη φάση εδω.", wirecolors(0), 1, Me)
        addScrew(31, 29, 15, 15, "L2", "Συνδέστε την δεύτερη φάση εδω.", wirecolors(0), 1, Me)
        addScrew(31, 54, 15, 15, "L3", "Συνδέστε την τρίτη φάση εδω.", wirecolors(0), 1, Me)
        addScrew(31, 102, 15, 15, "Ν", "Συνδέστε τον ουδέτερο εδω.", wirecolors(0), 1, Me)

        Me.numberOfScrews = 3

        Me.setMoveBounds()
        state = GlobalInfo.state.anenergo


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

    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "3PHASE INDICATOR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Τριφασική Ενδεικτική λυχνία"
    End Function
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()
    End Sub

    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If SimulationSymbols Then Me.Image = My.Resources.C3phIndicator Else Me.Image = My.Resources._3phIndicator
    End Sub

    '***************************************************************************************************************************************
    'checkifDifferent
    'Έλεγχος αν δεν έχουμε την ίδια φάση συνδεδεμένη επάνω και κάτω
    '***************************************************************************************************************************************
    Function checkifDifferent(val1 As Integer, val2 As Integer) As Boolean
        If (val1 And 15) = (val2 And 15) Then Return False
        Return True
    End Function

    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    Public Overrides Sub EvaluateObject()
        Dim st = GlobalInfo.state.anenergo
        Dim i As Integer
        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
        Dim A1 As Long
        Dim A2 As Long

        For i = 0 To 2
            A1 = screw(i).value And V_PhasesNeutralMask
            A2 = screw(3).value And V_PhasesNeutralMask

            'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
            lighton(i) = False
            If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
    (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then st = GlobalInfo.state.energo : lighton(i) = True
            changestate(st)
        Next
        changestate(st)
    End Sub
    'Εδώ σχεδιάζονται πρόσθετες λειτουργίες
    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Green, 2)
        Dim offset As Integer = 0
        Dim i As Integer
        Dim rec As Rectangle

        For i = 0 To 2
            rec = New Rectangle((Me.Location.X + 5) * ratio, (Me.Location.Y + 6 + 37 * i) * ratio, 15 * ratio, 15 * ratio)
            'gr.DrawEllipse(defaultPen, rec)

            If lighton(i) Then
                gr.FillEllipse(Brushes.GreenYellow, rec)
                gr.DrawString("X", New Font("Courier New", 12 * ratio), Brushes.Green, (Me.Location.X + 6) * ratio, (Me.Location.Y + 5 + 37 * i) * ratio)
            Else
                gr.FillEllipse(Brushes.Green, rec)
                gr.DrawString("X", New Font("Courier New", 12 * ratio), Brushes.DarkGray, (Me.Location.X + 6) * ratio, (Me.Location.Y + 5 + 37 * i) * ratio)

            End If

        Next


    End Sub
End Class
