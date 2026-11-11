Public Class hourmeter_activeimage
    Inherits SimpleSinglePhaseComponentTemplate
    Dim StartedWorkingAt As Integer = -1
    Dim totalTimeElapsed As Long = 0
    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Me.Image = My.Resources.hourmeter
    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        nameImage()
        Me.information = "Ωρομετρητής. Φέρει ένα σετ επαφών (1-2) μέσω των οποίων τροφοδοτείται με τάση. Συνδέστε την φάση L στο άκρο 1 και τον ουδέτερο Ν στο άκρο 2. Μόλις τροφοδοτηθεί αρχίζει να μετράει τον χρόνο και τον καταγράφει στην οθόνη."


        addScrew(6, 4, 15, 15, "1", "Το άνω άκρο τροφοδότησης του ωρομετρητή. Συνδέστε εδώ την φάση.", wirecolors(5), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Το κάτω άκρο τροφοδότησης του ωρομετρητή. Συνδέστε εδώ τον ουδέτερο.", wirecolors(3), 1.5, Me)
        HasTimeSettings = False

        Me.numberOfScrews = 1
        Me.setMoveBounds()
        state = GlobalInfo.state.anenergo
        Dim StartedWorkingAt As Integer = 0
        totalTimeElapsed = 0
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
        Return "HOUR METER"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Ωρομετρητής"
    End Function

    '______________________________________________________________________________________________________________________________
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state

            Case GlobalInfo.state.anenergo
                Me.Image = My.Resources.hourmeter
            Case Else
                Me.Image = My.Resources.hourmeter1
        End Select
    End Sub

    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()

    End Sub


    'Εδώ σχεδιάζονται πρόσθετες λειτουργίες
    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Black, 2)
        Dim offset As Integer = 0
        Dim timeElapsed As Integer = totalTimeElapsed / 4
        Dim secs As Integer = timeElapsed Mod 60

        If state = GlobalInfo.state.energo Then totalTimeElapsed += 1

        timeElapsed = timeElapsed - secs
        Dim secstr = secs.ToString.Trim
        If Len(secstr) = 1 Then secstr = "0" + secstr

        Dim mins As Integer = timeElapsed / 60


        Dim minstr = mins.ToString.Trim
        If Len(minstr) = 1 Then minstr = "0" + minstr
        If Len(minstr) = 3 Then totalTimeElapsed = 0 : minstr = "00" : secstr = "00"

        gr.DrawString(minstr + ":" + secstr, New Font("Courier New", 10 * ratio), Brushes.Black, (Me.Location.X + 2) * ratio, (Me.Location.Y + 46) * ratio)
        'totalTimeElapsed.ToString()

    End Sub







End Class
