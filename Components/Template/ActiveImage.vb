
Public Class ActiveImage

    Inherits System.Windows.Forms.PictureBox
    Protected Const maxScrew = 20
    Protected screw As New List(Of SingleScrewData)
    Public InterlockedWith As Integer = -1
    Public type As Integer
    Public ratio As Double
    Public information As String
    Public username As String
    Public numberOfScrews As Integer
    Public state As Integer
    Private SelectionStatus As Boolean = False
    Private SelectedScrew As Integer = -1
    Protected TripTicks As Integer = 5            'Ο ΧΡΟΝΟΣ ΕΝΕΡΓΟΠΟΙΗΣΗΣ: Σε πόσα τικ του ρολογίου θα αλλάξει κατάσταση
    Public HasTimeSettings As Boolean = False                       'Αυτή η μτβ ενημερώνει ότι το συγκεκριμένο αντικείμενο δέχεται ρύθμιση χρόνου.
    Private movefromx, movefromy, movetox, movetoy As Integer
    Protected This_Objects_Number As Integer = 0
    Public Settings1 As Integer = -1
    Public Settings2 As Integer = -1
    Public Settings3 As Integer = -1
    Public Settings4 As Integer = -1
    Public Settings5 As Integer = -1
    Public Settings6 As Integer = -1
    Public Settings7 As Integer = -1
    Public Settings8 As Integer = -1
    Public Settings9 As Integer = -1
    Public Settings10 As Integer = -1
    Public Con_Errors_Found As Integer = -1
    Public ErrorSentFromElsewhere As String = ""

    Public CircuitPrintingImage As Image 'Η εικόνα που θα χρησιμοποιηθεί για την εκτύπωση σε μορφή καθαρού κυκλώματος
    Private TheImageThatWasUsedBefore As Image 'Εδώ θα αποθηκευτεί η εικόνα που χρησιμοποιείται στο κύκλωμα 
    'Αυτό θα χρησιμοποιηθεί από τους κινητήρες κυρίως για να κάνουν throw ένα σφάλμα
    Public Overridable Sub ThrowConnectionError(ConnectionErrorText As String)
        ErrorSentFromElsewhere = ConnectionErrorText
        Con_Errors_Found = Con_Errors_Found + 1
    End Sub




    'Hotkeys είναι τα πλήκτρα που θα χρησιμοποιηθούν κατά την προσομοίωση για την αλλαγή των καταστάσεων
    Private Structure HotKeyStructure
        Public Key As Char
        Public Information As String
    End Structure


    'Αυτό το Sub θα χρησιμοποιηθεί στο μέλλον για να ανοίξει το παράθυρο των ρυθμίσεων του στοιχείου
    Public Overridable Sub ShowSettings()

    End Sub


    'Το πλήθος των HotKeys
    Private HotKeyNumber As Integer = -1
    Private Const Max_Hotkeys As Integer = 10

    'Εδώ το κάθε αντικείμενο θα μπορεί να ορίζει την εικόνα του
    Public Overridable Sub nameImage()

    End Sub

    'Ορισμός του χρόνου ενεργοποίησης για τα αντικείμενα που το χρειάζονται
    Public Overridable Sub setTimeDelay(HowManyTimeTicks As Integer)
        If HowManyTimeTicks > 0 And HowManyTimeTicks < 50 Then TripTicks = HowManyTimeTicks
    End Sub

    'Θα καθορίζει την εικόνα του αντικειμένου κατά την προσομοίωση
    Public Overridable Sub Refresh_Image_Reference_For_Simulation()

    End Sub

    'λήψη του χρόνου ενεργοποίησης για τα αντικείμενα που το χρειάζονται
    Public Overridable Function getTimeDelay() As Integer
        Return TripTicks
    End Function


    'Θα χρησιμοποιηθεί από το PLC για να επαναφέρει (Reset) τις ρυθμίσεις των χρονικών και των απαριθμητών
    Public Overridable Sub reset_all_parameters()
    End Sub




    'Αυτό το sub υπάρχει για να προστεθεί κώδικας από τα αντικείμενα που θα δημιουργηθούν με βάση το ActiveImage
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overridable Sub HasBeenClickedOnDuringSimulation()

    End Sub

    'Η λίστα με τα HotKeys
    Private HotKey(Max_Hotkeys) As HotKeyStructure

    'Ορισμός του αριθμού των hotkeys
    Public Sub setHotkeyNumber(WhichNumber As Integer)

        If WhichNumber > Max_Hotkeys Then Exit Sub
        HotKeyNumber = WhichNumber
    End Sub
    'Επιστρέφει τον αριθμό των hotkeys
    Public Function getHotkeyNumber() As Integer
        Return HotKeyNumber
    End Function
    'Ορισμός HotKeys
    Public Sub setHotKey(WhichOne As Integer, theKey As Char)
        If WhichOne > HotKeyNumber Then Exit Sub
        HotKey(WhichOne).Key = theKey
    End Sub
    'Ανάγνωση HotKeys
    Public Function getHotKey(WhichOne As Integer) As Char
        If WhichOne > HotKeyNumber Then Return Nothing : Exit Function
        Return HotKey(WhichOne).Key
    End Function

    'Ορισμός HotKeys
    Public Sub setHotKeyInformation(WhichOne As Integer, theInfo As String)
        If WhichOne > HotKeyNumber Then Exit Sub
        HotKey(WhichOne).Information = theInfo
    End Sub

    'Ορισμός HotKeys
    Public Function getHotKeyInformation(WhichOne As Integer) As String
        If WhichOne > HotKeyNumber Then Return ""
        Return HotKey(WhichOne).Information
    End Function


    'Εδω θα μπει ο κώδικας που θα ενεργοποιεί τις ανάλογες λειτουργίας ανάλογα με το πλήκτρο που θα έχει πατηθεί
    Public Overridable Sub keypressed(whatkey As Char)

    End Sub
    'Εδώ θα μπεί ο κώδικας που θα καθορίζει πως θα φαίνεται το αντικείμενο ανάλογα με το state του
    Public Overridable Sub state_has_changed()

    End Sub

    'Εδώ θα μπεί ο κώδικας για τα εξαρτήματα με αυτόματη συμπεριφορά
    'όπως το ρελέ, το θερμικό, η ασφάλεια κτλ
    Public Overridable Sub EvaluateObject()

    End Sub


    'Εδώ αλλάζουμε το state του αντικειμένου
    Public Sub changestate(towhat As Integer)
        state = towhat
        state_has_changed()
        'Μια μικρή διόρθωση γιατι θόλωναν λίγο οι εικόνες επειδή είχαν διαφορά 1πιξελ
        'Width = Image.Width * ratiovalue
        'Height = Image.Height * ratiovalue
    End Sub

    ' Sub Inform_Screws()
    Overridable Sub Initialization()

    End Sub
    Overridable Sub Initialization(Whichtype As Integer)

    End Sub



    'Σε κάθε αντικείμενο θα γίνεται override αυτό το SUΒ. Σκοπός του είναι να κάνει τις εσωτερικές συνδέσεις εντός των εξαρτημάτων και την ενημέρωση των βιδών.
    Overridable Sub Inform_Screws()
        'Για να γίνει overload
    End Sub

    'Διαγραφή όλων των values από τις βίδες
    Public Sub Reset_Screws()
        Dim i As Integer

        For i = 0 To numberOfScrews
            screw(i).reset_value()
        Next

    End Sub

    'Απλά επιστρέφει το όνομα του αντικείμενου

    Overridable Function WhatAmI() As String
        Return "ACTIVEIMAGE"
    End Function

    'Απλά επιστρέφει το όνομα του αντικείμενου
    Overridable Function WhatAmIGreek() As String
        Return "ACTIVEIMAGE"
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδω ενημερώνουμε το θερμικό να πέσει
    Public Sub Drop_Thermiko()
        Dim i, j As Integer
        For i = 0 To numberOfScrews - 1 'Λόγω της γείωσης, πάντα η γείωση είναι η τελευταία βίδα
            'Αν στην συγκεκριμένη βίδα υπάρχει ένας αγωγός που οδηγεί αποκλειστικά και μόνο σε ένα θερμικό τότε θα ρίξουμε αυτό το θερμικό
            For j = 0 To screw(i).get_total_connections - 1
                If screw(i).connections(j).Screw.parent.WhatAmI = "THERMAL RELAY" Then
                    screw(i).connections(j).Screw.parent.changestate(GlobalInfo.state.thermiko_energo)
                End If
                If screw(i).connections(j).Screw.parent.WhatAmI = "THERMOMAGNETIC RELAY" Then
                    screw(i).connections(j).Screw.parent.changestate(GlobalInfo.state.thermiko_energo)
                End If

            Next

        Next

    End Sub
    '**************************************************************************************************************************
    'Σχεδίαση για την προσομοίωση
    Public Sub DrawImage(WheretoDraw As Object, ratio As Single, mynumber As Integer) ', whattodraw As Condition)
        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        DrawImageMain(WheretoDraw, gr, ratio, mynumber)
    End Sub
    '**************************************************************************************************************************
    'Δημιουργία BMP 
    Public Sub DrawImageforBMP(WheretoDraw As Object, ByRef ImageVar As Image, ratio As Single, mynumber As Integer) ', whattodraw As Condition)
        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        'Image img = new Bitmap(panel1.Width, panel1.Height);
        Dim priorselection As Boolean = show_keys_during_simulation
        show_keys_during_simulation = False
        Dim br As Graphics = Graphics.FromImage(ImageVar)

        DrawImageMain(WheretoDraw, br, ratio, mynumber)
        show_keys_during_simulation = priorselection
    End Sub

    'Κατά την εκτύπωση καθαρού κυκλώματος θα χρησιμοποιηθεί αυτή η εικόνα.
    Public Sub Set_CircuitPrintingImage(Im As Image)
        CircuitPrintingImage = Im
    End Sub


    'Αλλαγή της εικόνας σε καθαρό σύμβολο για εκτύπωση  και αποθήκευση της τρέχουσας για μελλοντική επαναφορά
    Public Overridable Sub prepare_For_Circuit_Printing()
        TheImageThatWasUsedBefore = Me.Image
        Me.Image = CircuitPrintingImage
    End Sub

    'Επαναφορά της εικόνας μετά την εκτύπωση του κυκλώματος
    Public Overridable Sub Restore_Image_After_Circuit_Printing()
        Me.Image = TheImageThatWasUsedBefore
    End Sub


    'Το κύριο σώμα της σχεδίασης για την προσομοίωση ή την δημιουργία BMP
    Public Sub DrawImageMain(WheretoDraw As Object, gr As Graphics, ratio As Single, mynumber As Integer) ', whattodraw As Condition)
        Const apostash_plaisioy = 1
        Dim defaultPen As Pen = New Pen(Brushes.Black, apostash_plaisioy * 2)
        Dim KleistoPen As Pen = New Pen(Brushes.Red, apostash_plaisioy * 2)
        Dim pathmenoPen As Pen = New Pen(Brushes.Blue, apostash_plaisioy * 2)
        Dim poweredPen As Pen = New Pen(Brushes.Green, apostash_plaisioy * 2)
        Dim textbrush As Brush = New SolidBrush(Color.Black)
        Dim keyzbrush As Brush = New SolidBrush(Color.Red)
        Dim textpoint As Point = New Point(((Me.Location.X) * ratio), ((Me.Location.Y + Me.Height / 2 - 10) * ratio))
        Dim keyzpoint As Point = New Point(textpoint.X, textpoint.Y + 16 * ratio)
        'Dim txt As String = ""
        'Dim mask As String = ""
        Dim keyz As String = ""
        Dim i As Integer
        Dim txt As String = ""
        Dim mask As String = ""

        'Σχεδίαση εικόνας
        'myPen = New Pen(whichColor, StrokeWidth)
        This_Objects_Number = mynumber
        gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default
        gr.DrawImage(Me.Image, (Me.Location.X * ratio), (Me.Location.Y * ratio), (Me.Image.Width * ratio), (Me.Image.Height * ratio))




        'Αν έχω επιλέξει να μην 
        If Not drawUsernameDuringEdit Then Exit Sub

        If show_info_during_simulation Then
            txt = Me.Tag + ""
            mask = StrDup(txt.Length, "█")
        End If

        If Image.Width < 55 Then txt = txt + vbNewLine : mask = mask + vbNewLine Else txt = txt + " " : mask = mask + "█" 'Αν είναι μικρότερο από το stop τότε χρειάζεται newline

        txt = txt + username
        mask = mask + StrDup(Len(username), "█")

        If InterlockedWith > -1 Then
            txt = txt + "~" + allActiveObjects(InterlockedWith).Tag
            mask = mask + StrDup(allActiveObjects(InterlockedWith).Tag.ToString.Length + 1, "█")
        End If

        If HasTimeSettings Then
            txt = txt + vbNewLine + "t=" + TripTicks.ToString
            mask = mask + vbNewLine + StrDup(TripTicks.ToString.Length + 2, "█")

        End If

        If show_keys_during_simulation Then
            If getHotkeyNumber() > -1 Then
                keyz = keyz + "("
                For i = 0 To getHotkeyNumber()
                    keyz = keyz + getHotKey(i)
                    If i > getHotkeyNumber() Then keyz = keyz + ", "
                Next
                keyz = keyz + ")"
                txt = txt + vbNewLine + keyz
                mask = mask + vbNewLine + StrDup(keyz.Length, "█")

            End If

        End If

        If show_info_during_simulation Or show_keys_during_simulation Then
            gr.DrawString(mask, New Font("Courier New", 10 * ratiovalue, FontStyle.Bold), New SolidBrush(Color.White), textpoint)
            gr.DrawString(txt, New Font("Courier New", 10 * ratiovalue, FontStyle.Bold), textbrush, textpoint)
        End If





        Draw_Anything_Extra(WheretoDraw, ratio)
    End Sub


    '----------------------------------------------------------------------------------------------------
    'Αυτό το Sub θα πρέπει να γίνει overrride από οποιοδήποτε αντικείμενο πρέπει να προσθέσει πρόσθετα διαδραστικά γραφικά στην επιφάνεια του
    '----------------------------------------------------------------------------------------------------
    Public Overridable Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)

    End Sub




    'Αυτό το Sub επιστρέφει τις εσωτερικές μτβ του κάθε αντικειμένου για να αποτυπωθεί η τρέχουσα κατάσταση του.
    Public Sub return_info_forsaving(ByRef maxscrew_value As Integer, _
                                     ByRef Numberofscrews_value As Integer, _
                                     ByRef SelectedScrew_value As Integer, _
                                     ByRef ratio_value As Integer, _
                                     ByRef information_value As String, _
                                     ByRef SelectionStatus_value As Boolean, _
                                     ByRef movefromx_value As Integer, _
                                     ByRef movefromy_value As Integer, _
                                     ByRef movetox_value As Integer,
                                     ByRef movetoy_value As Integer)
        maxscrew_value = maxScrew
        Numberofscrews_value = numberOfScrews
        SelectedScrew_value = SelectedScrew
        ratio_value = ratio
        information_value = information
        SelectionStatus_value = SelectionStatus
        movefromx_value = movefromx
        movefromy_value = movefromy
        movetox_value = movetox
        movetoy_value = movetoy
    End Sub



    'Προσθήκης των πληροφοριών μιας βίδας
    Public Sub addScrew(X As Integer, y As Integer, width As Integer, height As Integer, name As String, Information As String, wirecolor As Color, WhereToPutTheNodePI As Single, parent As Object)
        Dim sc As New SingleScrewData
        sc.X = X
        sc.Y = y
        sc.name = name
        sc.information = Information
        sc.Width = width
        sc.Height = height
        sc.parent = parent
        sc.color = wirecolor
        sc.WhereToPutNode = WhereToPutTheNodePI
        screw.Add(sc)
    End Sub
    'Επιστροφή δεδομένων μιας βίδας.
    'Αν ζητήσουμε βίδα που δεν υπάρχει τότε επιστρέφει -1 αλλιώς επιστρέφει 1
    Function returnScrew(WhichOne As Integer, ByRef returnedScrewData As SingleScrewData) As Integer
        If WhichOne > screw.Count Then Return -1
        returnedScrewData = screw.Item(WhichOne)
        Return 1

    End Function

    Function returnScrewData(WhichOne As Integer) As SingleScrewData
        If WhichOne > screw.Count Then Return Nothing
        Return screw.Item(WhichOne)

    End Function

    'Ορισμός ορίων για μετακίνηση
    Public Sub setMoveBounds()
        movefromx = 0
        movefromy = 0
        movetox = Image.Width
        movetoy = Image.Height
    End Sub

    'Ανάγνωση ορίων για μετακίνηση
    Public Sub getMoveBounds(ByRef fromx As Integer, ByRef fromy As Integer, ByRef tox As Integer, ByRef toy As Integer)
        fromx = movefromx
        fromy = movefromy
        tox = movetox
        toy = movetoy

    End Sub
    'Ορισμός επιλεγμένης βίδας
    Public Sub SetSelectedScrew(WhichOne As Integer)
        SelectedScrew = WhichOne
    End Sub




    'Οριζω ότι έχει επιλεχθεί
    Public Sub SetSelectedStatus(isItSelected As Boolean)
        SelectionStatus = isItSelected

        '        Select Case SelectionStatus
        '            Case True
        '        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        '            Case Else
        '        Me.BorderStyle = Windows.Forms.BorderStyle.None

        '        End Select
    End Sub

    'Διαβάζω αν έχει επιλεχθεί
    Public Function GetSelectedStatus() As Boolean
        Return SelectionStatus
    End Function





    Public Sub New()


    End Sub
    Public Overrides Sub Refresh()
        MyBase.Refresh()
        If SelectionStatus And SelectedScrew > -1 Then
            underlineScrew(SelectedScrew, Me, Drawing.Color.Red, 3)
        End If
        Draw_Username()

    End Sub

    'isOnScrew
    'Αν το ποντίκι βρίσκεται επάνω στην βίδα τότε επιστρέφει τον αριθμό της βίδας
    'Αλλιώς επιστρέφει -1
    Function isOnScrew(X As Integer, Y As Integer, sender As Object) As Integer
        Dim Clickedobj As ActiveImage
        Clickedobj = CType(sender, ActiveImage)

        For ActiveScrew = 0 To numberOfScrews
            If (X > Clickedobj.screw.Item(ActiveScrew).X / ratio And (X < (Clickedobj.screw.Item(ActiveScrew).X) / ratio + Clickedobj.screw.Item(ActiveScrew).Width / ratio)) And _
                 ((Y > Clickedobj.screw.Item(ActiveScrew).Y / ratio) And (Y < (Clickedobj.screw.Item(ActiveScrew).Y) / ratio + Clickedobj.screw.Item(ActiveScrew).Width / ratio)) Then
                Return ActiveScrew
            End If
        Next
        Return -1
    End Function

    'underlineScrew
    'Σχεδιάζει ένα κύκλο γύρω από μια βίδα του ενεργού αντικειμένου
    'WhichScrew = Ο αριθμός της βίδας που θέλω να υπογραμμίσω
    'ClickedObj = Το αντικείμενο επάνω στο οποίο θα σχεδιάσω
    'whichColor =  Το χρώμα της υπογράμμισης
    'StrokeWidth = Το πάχος της γραμμής

    Sub underlineScrew(WhichScrew As Integer, ClickedObj As ActiveImage, whichColor As Color, StrokeWidth As Integer)





        'Δημιουργώ ένα PEN με χρώμα και πάχος σύμφωνα με τις παραμέτρους του Sub
        'Dim myPen As Pen
        'myPen = New Pen(whichColor, StrokeWidth)

        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        'Dim myGraphics As Graphics = ClickedObj.CreateGraphics
        'Σχεδιάζω ένα κύκλο γύρω από την βίδα
        'myGraphics.DrawEllipse(myPen, ClickedObj.screw(WhichScrew).X \ ratio, ClickedObj.screw(WhichScrew).Y \ ratio, ClickedObj.screw(WhichScrew).Width \ ratio, ClickedObj.screw(WhichScrew).Height \ ratio)
        'Γράφω το όνομα της βίδας κάτω δεξιά
        'myGraphics.DrawString(ClickedObj.screw(WhichScrew).name, New Font("Sans", 12, FontStyle.Regular), Brushes.Black, New Point((ClickedObj.screw(WhichScrew).X + ClickedObj.screw(WhichScrew).Width) \ ratio, (ClickedObj.screw(WhichScrew).Y + ClickedObj.screw(WhichScrew).Height) \ ratio))
    End Sub


    Private Sub ActiveImage_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Dim name_typed = Trim(InputBox("Πληκτρολογήστε νέο κωδική ονομασία για το εξάρτημα." + vbNewLine + "(3 χαρακτήρες)", "Ονομασία", username))
        If name_typed <> "" Then
            If name_typed.Length <= 3 Then username = name_typed Else username = name_typed.Substring(0, 3)
        End If


    End Sub


    Private Sub Draw_Username()
        Dim myG As Graphics = CreateGraphics()
        Dim txt As String = Me.Tag + ""
        Dim mask As String = StrDup(txt.Length, "█")

        If Not drawUsernameDuringEdit Then Exit Sub

        If Width < 55 Then txt = txt + vbNewLine : mask = mask + vbNewLine Else txt = txt + " " : mask = mask + "█" 'Αν είναι μικρότερο από το stop τότε χρειάζεται newline

        txt = txt + username
        mask = mask + StrDup(Len(username), "█")

        If InterlockedWith > -1 Then
            txt = txt + "~" + allActiveObjects(InterlockedWith).Tag
            mask = mask + StrDup(allActiveObjects(InterlockedWith).Tag.ToString.Length + 1, "█")
        End If

        If HasTimeSettings Then
            txt = txt + vbNewLine + "t=" + TripTicks.ToString
            mask = mask + vbNewLine + StrDup(TripTicks.ToString.Length + 2, "█")

        End If
        myG.DrawString(mask, New Font("Courier New", 11 \ Edit.HScrollBar1.Value, FontStyle.Bold), Brushes.White, New Point(2, (Me.Height / 2) - 12 \ Edit.HScrollBar1.Value))
        myG.DrawString(txt, New Font("Courier New", 11 \ Edit.HScrollBar1.Value, FontStyle.Bold), Brushes.Black, New Point(2, (Me.Height / 2) - 12 \ Edit.HScrollBar1.Value))


    End Sub

    Private Sub ActiveImage_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Draw_Username()
    End Sub



    Private Sub ActiveImage_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove


        Dim ActiveScrew As Integer
        Dim Clickedobj As ActiveImage

        'Δημιουργώ ένα αντικείμενο τύπου Activeimage από το Sender
        Clickedobj = CType(sender, ActiveImage)

        'Ελέγχω αν βρισκόμαστε επάνω σε μια βίδα. Αν δεν είμαστε θα επιστρέψει -1
        ActiveScrew = isOnScrew(e.X, e.Y, sender)

        'Αν βρισκόμαστε επάνω σε βίδα
        If ActiveScrew > -1 Then

            'Σχεδίασε ένα κύκλο γύρω από τη βίδα
            'underlineScrew(ActiveScrew, Clickedobj, Drawing.Color.DarkCyan, 3)
            Clickedobj.Cursor = Cursors.Hand
            Edit.Tooltip.Text = screw(ActiveScrew).name & ":" & screw(ActiveScrew).information

        ElseIf (e.X * ratio > movefromx) And (e.X * ratio < movetox) And (e.Y * ratio > movefromy) And (e.Y * ratio < movetoy) Then
            Clickedobj.Cursor = Cursors.SizeAll
            Edit.Tooltip.Text = information

        Else
            'Αν δεν είμαστε επάνω στη βίδα, τότε κάνε Refresh την εικόνα.
            Clickedobj.Cursor = Cursors.Default
            Edit.Tooltip.Text = information


            'Clickedobj.Refresh()
        End If
    End Sub

    Private Sub ActiveImage_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Draw_Username()
    End Sub


    'Αυτό το Sub θα χρησιμοποιηθεί από τις παρακάτω κλάσεις για να αποθηκεύσει τα δεδομένα σε αρχείο
    Public Overridable Sub SaveDataToDisk(Writer As System.IO.StreamWriter)

    End Sub


    'Αυτό το Sub θα χρησιμοποιηθεί για να αποθηκεύσει τα δεδομένα σε αρχείο
    Public Overridable Sub ReadDatafromDisk(Reader As System.IO.StreamReader)

    End Sub
End Class
