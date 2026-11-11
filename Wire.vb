<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")> Public Class Wire
    Const anoxhSePixel As Integer = 10
    Public Const maxnodes = 30 'Το μέγιστο πλήθος nodes που μπορεί να έχει ένας αγωγός

    Public nodes(maxnodes) As Point
    Public last_nodes(maxnodes) As Point
    Private last_nodes_first_run As Boolean = True
    'Private nodes As WireNodeData

    Private firstobject As ActiveImage
    Private secondobject As ActiveImage

    Private firstscrew As Integer
    Private secondscrew As Integer

    Private current_node As Integer = -1
    Private Const nodesize As Integer = 10

    Private SelectedNode As Integer = -1

    Public whichColor As SolidBrush = New SolidBrush(edit.SelectedColor2.BackColor)
    Public NormalStrokeWidth As Integer = 6
    Public EraserStrokeWidth As Integer = NormalStrokeWidth
    Public SelectedStrokeWidth As Integer = 2

    Public SelectedColor As SolidBrush = Brushes.DarkOrange

    Public nodecolor As SolidBrush = Brushes.Blue
    Public SelectedNodeColor As SolidBrush = Brushes.Red
    Public nodewidth As Integer = 3
    Private Selected As Boolean

    Dim DashedLineOffsetValue As Double = 100


    'Επιστρέφει τον αριθμό των nodes
    'Μπορεί να χρησιμοποιηθεί κατά την αποθήκευση για την δημιουργία Array of point
    Public Function get_total_nodes() As Integer
        Return current_node
    End Function

    'Επιστρέφει πληροφορίες για 
    Public Sub return_info_forsaving(
                                        ByRef firstobject_value As ActiveImage, _
                                        ByRef secondobject_value As ActiveImage, _
                                        ByRef firstscrew_value As Integer, _
                                        ByRef secondscrew_value As Integer, _
                                        ByRef whichColor_value As SolidBrush)



        firstobject_value = firstobject
        secondobject_value = secondobject
        firstscrew_value = firstscrew
        secondscrew_value = secondscrew
        whichColor_value = whichColor
    End Sub

    'Είναι επιλεγμένος ο αγωγός;
    Public Sub SetSelected(SelectedOrNot As Boolean)
        Selected = SelectedOrNot
        'Αν δεν είναι επιλεγμένος ο αγωγός τότε δεν γίνεται να είναι επιλεγμένο κάποιο node
        If Not Selected Then resetSelectedNode()
    End Sub


    'Επιστρέφει True αν είναι επιλεγμένος ο αγωγός
    Public Function GetSelectedStatus() As Boolean
        Return Selected
    End Function

    'Επιστρέφει τον αριθμό του επιλεγμένου node
    Function getSelectedNode() As Integer
        Return SelectedNode
    End Function

    'Επιστρέφει τον αριθμό του επιλεγμένου node
    Sub SetSelectedNode(whichone As Integer)
        If whichone > -2 And whichone < current_node Then SelectedNode = whichone
    End Sub

    'Μηδενίζει το selectedNode
    Sub resetSelectedNode()
        SelectedNode = -1
    End Sub

    'Μετακινεί τις συντεταγμένες ενός node
    Public Sub moveNode(WhichNode As Integer, x As Integer, y As Integer)
        If WhichNode <= -1 Or WhichNode > current_node Then Exit Sub
        SetSelectedNode(WhichNode)

        nodes(WhichNode).X = x
        nodes(WhichNode).Y = y


    End Sub


    'Αυτό το Function επιστρέφει το πρώτο ρελέ πάνω στο οποίο πατάει ο αγωγός
    Public Function getFirstObject(ByRef TransactionOk As Boolean) As ActiveImage
        If firstobject Is Nothing Then TransactionOk = False : Return Nothing : Exit Function
        TransactionOk = True
        Return firstobject
    End Function
    'Αυτό το Function επιστρέφει το δεύτερο ρελέ πάνω στο οποίο πατάει ο αγωγός
    Public Function getSecondObject(ByRef TransactionOk As Boolean) As ActiveImage
        If secondobject Is Nothing Then TransactionOk = False : Return Nothing : Exit Function
        TransactionOk = True
        Return secondobject
    End Function
    'Αυτό το Function επιστρέφει τον αριθμό της πρώτης βίδας πάνω στο οποίο πατάει ο αγωγός
    Public Function getFirstScrew() As Integer
        Return firstscrew
    End Function
    'Αυτό το Function επιστρέφει τον αριθμό της δεύτερης βίδας πάνω στο οποίο πατάει ο αγωγός
    Public Function getSecondScrew() As Integer
        Return secondscrew
    End Function

    

    'Υπολογισμός της θέσης των δυο ακραίων βιδών
    Private Sub calculateBasicNodes()
        Dim x As Integer
        Dim y As Integer
        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Exit Sub
        If current_node = -1 Then current_node = 1
        x = firstobject.Location.X + (firstobject.returnScrewData(firstscrew).X + firstobject.returnScrewData(firstscrew).Width / 2) / firstobject.ratio
        y = firstobject.Location.Y + (firstobject.returnScrewData(firstscrew).Y + firstobject.returnScrewData(firstscrew).Height / 2) / firstobject.ratio
        nodes(0) = New Point(x, y)
        x = secondobject.Location.X + (secondobject.returnScrewData(secondscrew).X + secondobject.returnScrewData(secondscrew).Width / 2) / secondobject.ratio
        y = secondobject.Location.Y + (secondobject.returnScrewData(secondscrew).Y + secondobject.returnScrewData(secondscrew).Width / 2) / secondobject.ratio
        nodes(current_node) = New Point(x, y)

    End Sub




    'Ελέγχει αν το αντικείμενο που θέλουμε να φτιάξουμε είναι ίδιο με το αντικείμενο που έχουμε.
    Public Function ConfigurationAlreadyExists(ByRef fromobj As ActiveImage, ByRef fromscrew As Integer, ByRef toobj As ActiveImage, ByRef toscrew As Integer) As Boolean

        'Εάν είναι η πρώτη φορά που τρέχουμε αυτό το function
        If firstobject Is Nothing Or secondobject Is Nothing Then Return False : Exit Function

        'θα πρέπει να γίνει έλεγχος για την περίπτωση που τα αντικείμενα έχουν δωθεί με την κανονική σειρά
        If firstobject.Equals(fromobj) And secondobject.Equals(toobj) And firstscrew = fromscrew And secondscrew = toscrew Then Return True : Exit Function
        'και για την ανάποδη σειρά
        If firstobject.Equals(toobj) And secondobject.Equals(fromobj) And firstscrew = toscrew And secondscrew = fromscrew Then Return True : Exit Function
        Return False
    End Function

    'Δημιουργία καλωδίου
    'Αν χρησιμοποιοηθεί σε αντικείμενο που φέρει δεδομένα τότε θα κάνει overwrite σε αυτά και θα δημιουργήσει ουσιατικά ένα νέο
    Public Sub CreateWire(ByRef fromobj As ActiveImage, ByRef fromscrew As Integer, ByRef toobj As ActiveImage, ByRef toscrew As Integer, whichbrush As Brush, insertbasicnodes As Boolean, ByRef WasItSuccessful As Boolean)
        Dim alreadyExists As Boolean

        'Αν του ζητήσουμε να κάνει το ίδιο πράγμα δυο φορές τότε δεν θα το κάνει.
        alreadyExists = ConfigurationAlreadyExists(fromobj, fromscrew, toobj, toscrew)
        If alreadyExists Then WasItSuccessful = False : Exit Sub

        'Καταχωρώ τις τιμές στο αντικείμενο
        firstobject = fromobj
        secondobject = toobj

        firstscrew = fromscrew
        secondscrew = toscrew
        whichColor = whichbrush
        'Ορίζω τις θέσεις των πρώτων δυο node (τις βίδες δηλαδή)
        If insertbasicnodes Then calculateBasicNodes() 'Αν θέλω να βάλει τα δύο αρχικά nodes στις βίδες τότε το insert basic nodes πρεπει να ειναι true

        'Ορίζω ότι ο αγωγός έχει μόνο δυο nodes 0-1
        current_node = 1
        'Η διαδικασία ήταν επιτυχής
        WasItSuccessful = True
    End Sub





    'Εισαγωγή νέου Node
    Public Function InsertNode(ByVal p As Point, ByVal WhichIndex As Integer)
        Dim i As Integer


        If WhichIndex > (current_node + 1) Then Return -1
        For i = current_node To WhichIndex Step -1

            nodes(i + 1) = nodes(i)
        Next
        nodes(WhichIndex) = p
        current_node = current_node + 1
        Return WhichIndex
    End Function

    Public Sub eraseAll()

        current_node = -1

    End Sub
    'Aφαίρεση ενός node
    Public Sub RemoveNode(WhichIndex As Integer)
        Dim i As Integer
        'Αν δεν έχουμε αρκετά δεδομένα για την σχεδίαση = εξοδος
        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Exit Sub
        'αν προσπαθήσουμε να σβήσουμε το πρώτο ή το τελευταίο node ουσιαστικά σβήνουμε όλο τη γραμμή
        If WhichIndex = 0 Or WhichIndex = current_node Then eraseAll() : Exit Sub

        'Αν αυτό που θέλω να αφαιρέσω είναι out of bounds
        If WhichIndex < 0 Or WhichIndex > current_node Then Exit Sub






        For i = WhichIndex To current_node - 1

            nodes(i) = nodes(i + 1)

        Next





        'nodes(WhichIndex) = Nothing
        current_node = current_node - 1
    End Sub




    Public Function getNode(ByVal Whichone As Integer, ByRef IsOk As Boolean) As Point
        IsOk = True
        If current_node = -1 Or (Whichone > current_node) Then IsOk = False : Exit Function
        Return nodes(Whichone)
    End Function


    'Έλεγχος αν έγινε κλικ
    Private Function checkclick(ByVal clickx As Integer, ByVal clicky As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Boolean


        '1. Μεταφέρω την ευθεία (x1,y1)-(x2,y2) στην αρχή των αξόνων (0,0)-(x2-x1, y2-y1)
        'Γραμμή
        
        Dim graph As Graphics = Edit.CreateGraphics

        'Η line0 φέρει τις συντεταγμένες της ευθείας
        Dim line0start As Point = New Point(0, 0)
        Dim line0stop As Point = New Point(x2 - x1, y2 - y1)

        'Η line1 φέρει τις συντεταγμένες μιας ευθείας από την αρχή των αξόνων στο σημείο του click
        Dim line1start As Point = New Point(0, 0)
        Dim line1stop As Point = New Point(clickx - x1, clicky - y1)


        'Dim gp1 As Point
        'Dim gp2 As Point
        'gp1 = New Point(line0start.X + 200, line0start.Y + 200)
        'gp2 = New Point(line0stop.X + 200, line0stop.Y + 200)

        'Dim pq As New Pen(Brushes.Blue, 5)
        'Ευθεία
        'graph.DrawLine(pq, gp1, gp2)

        'gp1 = New Point(line1start.X + 200, line1start.Y + 200)
        'gp2 = New Point(line1stop.X + 200, line1stop.Y + 200)

        'pq = New Pen(Brushes.Red, 5)
        'graph.DrawLine(pq, gp1, gp2)

        Dim minx, miny, maxx, maxy As Integer

        Dim tan0 As Double
        Dim atan0 As Double
        Dim len0 As Integer

        Dim tan1 As Double
        Dim atan1 As Double
        Dim len1 As Integer

        Dim angle As Double

        Dim ApostashApoGrammh As Double
        Dim ShmeioProvolhs As Double

        Const EpitrepthApostashApoGrammh As Integer = 5

        'Βρίσκω μέγιστες και ελάχιστες τιμές χ και ψ για την ευθεία 
        If line0start.X > line0stop.X Then maxx = line0start.X : minx = line0stop.X Else minx = line0start.X : maxx = line0stop.X
        If line0start.Y > line0stop.Y Then maxy = line0start.Y : miny = line0stop.Y Else miny = line0start.Y : maxy = line0stop.Y



        minx = minx - EpitrepthApostashApoGrammh
        miny = miny - EpitrepthApostashApoGrammh
        maxx = maxx + EpitrepthApostashApoGrammh
        maxy = maxy + EpitrepthApostashApoGrammh



        '        pq = New Pen(Brushes.Green, 1)
        '        gp1 = New Point(minx + 200, miny + 200)
        '        gp2 = New Point(maxx + 200, miny + 200)
        '        graph.DrawLine(pq, gp1, gp2)

        '        pq = New Pen(Brushes.LightGreen, 1)
        '        gp1 = New Point(minx + 200, miny + 200)
        '        gp2 = New Point(minx + 200, maxy + 200)
        '        graph.DrawLine(pq, gp1, gp2)

        '        pq = New Pen(Brushes.DarkGreen, 1)
        '        gp1 = New Point(maxx + 200, maxy + 200)
        '        gp2 = New Point(maxx + 200, miny + 200)
        '       graph.DrawLine(pq, gp1, gp2)

        '        edit.ListBox1.Items.Add("click στο " + line1stop.X.ToString + "," + line1stop.Y.ToString + "  Ελαχιστο " + minx.ToString + "," + miny.ToString + " Μέγιστο " + maxx.ToString + "," + maxy.ToString)

        'Το κλικ θα πρέπει να έχει γίνει αναγκαστικά εντός των παραπάνω ορίων max και min
        If line1stop.X > maxx Or line1stop.X < minx Then Return False
        If line1stop.Y > maxy Or line1stop.Y < miny Then Return False


        'Γωνία και μήκος ευθεία
        tan0 = (line0stop.Y - line0start.Y) / (line0stop.X - line0start.X)
        len0 = Math.Sqrt((line0stop.Y - line0start.Y) ^ 2 + (line0stop.X - line0start.X) ^ 2)
        atan0 = Math.Atan(tan0)

        'Γωνία και μήκος φανταστικής ευθείας από την αρχή των αξόνων προς το σημείο ckick
        tan1 = (line1stop.Y - line1start.Y) / (line1stop.X - line1start.X)
        len1 = Math.Sqrt((line1stop.Y - line1start.Y) ^ 2 + (line1stop.X - line1start.X) ^ 2)
        atan1 = Math.Atan(tan1)

        'Διαφορά γωνιών μεταξύ των δύο ευθειών
        angle = atan0 - atan1

        'συνημίτονο = απέναντι κάθετη πλευρά προς υποτίνουσα
        'ύποτίνουσα = line1
        'απέναντι πλευρά = συνημίτονο * υποτίνουσα

        ShmeioProvolhs = len1 * Math.Cos(angle)                         'Πρόκειται για την απόσταση που έχει η προβολή του σημείου click απο αρχή των αξόνων

        ApostashApoGrammh = len1 * Math.Sin(angle)                      'Πρόκειται για την κάθετη απόσταση από την γραμμή
        Dim p As New Pen(Brushes.Green, 8)

        'graph.DrawLine(p, x1 + line1stop.X, y1 + line1stop.Y, x1 + CInt(ShmeioProvolhs * Math.Cos(atan0)), y1 + CInt(ShmeioProvolhs * Math.Sin(atan0)))


        'Εάν έχει γίνει κλικ εντός των ορίων αυτής της γραμμής

        '  edit.ListBox1.Items.Add("(1)" + line0start.X.ToString + " / " + line0start.Y.ToString + _
        '  "(2)" + line1start.X.ToString + " / " + line1start.Y.ToString + " (πλάτος)" + len0.ToString + _
        '  "(Προβολή) " + ShmeioProvolhs.ToString + " (Αποσταση) " + ApostashApoGrammh.ToString + " Γωνία Α" + atan0.ToString + " Γωνία Β " + atan1.ToString)

        'Η κάθετη απόσταση από την ευθεία θα πρέπει να ειναι ΄μικρή
        If Math.Abs(ApostashApoGrammh) < EpitrepthApostashApoGrammh Then
            ' θα πρέπει όταν προβάλουμε το σημείο επάνω στην ευθεία η απόσταση της προβολής να είναι μικρότερη από το μήκος της ευθείας
            If (Math.Abs(ShmeioProvolhs) < len0) Then Return True


        End If



        Return False

        ' If (ShmeioProvolhs > 0) And (Math.Abs(ShmeioProvolhs) < len0) Then
        ' If Math.Abs(ApostashApoGrammh) < EpitrepthApostashApoGrammh Then edit.ListBox1.Items.Add("!!") : Return True Else Return False
        ' Else : Return False
        'End If


    End Function

    Private Function isItANodeAlready(clickx As Integer, clicky As Integer, ByRef WhichOne As Integer) As Boolean
        Dim i As Integer
        For i = 0 To current_node
            If (clickx > (nodes(i).X - anoxhSePixel)) And _
                (clickx < (nodes(i).X + anoxhSePixel)) And _
                (clicky > (nodes(i).Y - anoxhSePixel)) And _
                (clicky < (nodes(i).Y + anoxhSePixel)) Then WhichOne = i : Return True : Exit Function

        Next

        Return False

    End Function

    Public Function didYouClickOnMe(clickx As Integer, clicky As Integer, ByRef BaseNode As Integer) As Boolean
        Dim didheclick As Boolean
        Dim i As Integer
        'Ελέγχω αν υπάρχουν αρκετά δεδομένα


        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Return False : Exit Function
        calculateBasicNodes()
        'Ελέγχω αν έχει γίνει κλικ επάνω στην γραμμή
        For i = 0 To current_node - 1
            didheclick = checkclick(clickx, clicky, nodes(i).X, nodes(i).Y, nodes(i + 1).X, nodes(i + 1).Y)
            If didheclick Then BaseNode = i : Return didheclick : Exit Function
        Next i

        Return False

    End Function
    'Εδω θα γίνουν όλες οι δουλείες σχετικά με τα click επάνω σε κάποιο node
    Public Sub CheckForClick(clickx As Integer, clicky As Integer, ByRef WasTheClickOnThisWire As Boolean)

        Dim WasItOnAKnownNode As Boolean
        Dim NodeClicked As Integer
        Dim BaseNode As Integer
        Dim p As Point
        'Dim index As Integer
        'Αν υπάρχουν τα βασικά δεδομένα
        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then SetSelected(False) : Exit Sub

        'Έλεγξε αν ήταν πάνω σε αυτό τον αγωγό. Αν ήταν μας ενημερώνει ότι ήταν μεταξύ των nodes basenode & basenode+1
        WasTheClickOnThisWire = didYouClickOnMe(clickx, clicky, BaseNode)





        'Αν δεν εγίνε κλικ πάνω σε αυτό τον αγωγό τοτε έξοδος
        If Not WasTheClickOnThisWire Then SetSelected(False) : resetSelectedNode() : Exit Sub

        'Αν δεν έχει επιλεγεί ο αγωγός τότε απλά γίνεται επιλογή
        If Not GetSelectedStatus() Then SetSelected(True) : Exit Sub


        'Έκανε κλικ επάνω σε κάποιο ήδη υπάρχοντα node; Αν ναι, τότε επιστρέφει το node στο nodeclicked
        WasItOnAKnownNode = isItANodeAlready(clickx, clicky, NodeClicked)


        'Αν δεν έχει κάνει κλικ πάνω σε κάποιο ήδη υπάρχον node τότε θα πρέπει να δημιουργήσω ένα
        If Not WasItOnAKnownNode Then

            p = New Point(clickx, clicky)

            InsertNode(p, BaseNode + 1)
            resetSelectedNode()

        Else 'αλλιώς θα πρέπει να επιλέξω το node
            SetSelectedNode(NodeClicked)
        End If

    End Sub


    'Σχεδίαση του αγωγού επάνω στο αντικέιμενο objectforwriting με χρώμα whichcolor
    Public Sub drawWire(ByVal objectForWriting As Form, ratio As Integer, drawnodes As Boolean)
        Dim wirePen As Pen = New Pen(whichColor, NormalStrokeWidth / ratio)
        Dim nodepen As Pen = New Pen(nodecolor, nodewidth / ratio)
        Dim whitePen As Pen = New Pen(Color.White, EraserStrokeWidth / ratio)
        Dim SelectedInside As Pen = New Pen(SelectedColor, SelectedStrokeWidth / ratio)
        Dim SelectedOutside As Pen = New Pen(whichColor, NormalStrokeWidth / ratio)
        Dim SelectedNodepen As Pen = New Pen(SelectedNodeColor, nodewidth / ratio)

        Dim i As Integer
        Dim x, y As Integer
        'Ελέγχω αν υπάρχουν αρκετά δεδομένα
        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Exit Sub



        If last_nodes_first_run Or last_nodes Is Nothing Then
            For i = 0 To current_node
                last_nodes(i) = New Point(nodes(i).X, nodes(i).Y)
            Next
            last_nodes_first_run = False
        End If
        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        Dim graph As Graphics = objectForWriting.CreateGraphics
        calculateBasicNodes()

        For i = 0 To current_node - 1
            'Αν είναι η πρώτη φορά που γίνεται η σχεδίαση τότε να μην γίνει το σβήσιμο. 
            'Αυτή η μεταβλητή βρίσκεται στο GlobalInfo
            If Not This_Is_The_First_Time_Drawing Then

                'Πρώτα ελέγχουμε αν έχει γίνει μετακίνηση του συγκεκριμένου αγωγού αν έχει γίνει τότε πρώτα τον σβήνουμε
                If (nodes(i).X <> last_nodes(i).X) Or (nodes(i).Y <> last_nodes(i).Y) Or (nodes(i + 1).X <> last_nodes(i + 1).X) Or (nodes(i + 1).Y <> last_nodes(i + 1).Y) Then
                    graph.DrawLine(whitePen, last_nodes(i), last_nodes(i + 1))
                    x = (last_nodes(i).X - nodesize / 2)
                    y = (last_nodes(i).Y - nodesize / 2)
                    graph.DrawEllipse(whitePen, x, y, nodesize, nodesize)
                End If
            End If

            'Αν είναι επιλγμένος τότε χρωματίζεται αλλιώς
            If Selected Then
                graph.DrawLine(SelectedOutside, nodes(i), nodes(i + 1))
                graph.DrawLine(SelectedInside, nodes(i), nodes(i + 1))
            Else
                graph.DrawLine(wirePen, nodes(i), nodes(i + 1))
            End If


        Next

        'Εάν έχουμε επιλέξει να εμφανίζονται τα nodes
        If drawnodes Then
            For i = 1 To current_node - 1

                x = (nodes(i).X - nodesize / 2)
                y = (nodes(i).Y - nodesize / 2)
                If i = SelectedNode Then graph.DrawEllipse(SelectedNodepen, x, y, nodesize, nodesize) Else graph.DrawEllipse(nodepen, x, y, nodesize, nodesize)

            Next
        End If


        For i = 0 To current_node
            last_nodes(i) = New Point(nodes(i).X, nodes(i).Y)
        Next

    End Sub


    'Έυρεση των ελαχίστων και μεγίστων συντεταγμένων
    Public Sub findMINMAX(ByRef minx As Integer, ByRef miny As Integer, ByRef maxx As Integer, ByRef maxy As Integer)
        Dim i As Integer
        'Ελέγχω αν υπάρχουν αρκετά δεδομένα
        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Exit Sub
        Try

            For i = 0 To current_node - 1
                If nodes(i).X < minx Then minx = nodes(i).X
                If nodes(i).Y < miny Then miny = nodes(i).Y
                If nodes(i).X > maxx Then maxx = nodes(i).X
                If nodes(i).Y > maxy Then maxy = nodes(i).Y
            Next
            Exit Sub
        Catch ex As Exception
            'Σφάλμα υπολογισμού ορίων
        End Try

    End Sub

    'Σχεδίαση ενός αγωγού για προσομοίωση
    Public Sub drawWireForSimulation(ByVal objectForWriting As Object, ratio As Single)
        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        Dim graph As Graphics = objectForWriting.CreateGraphics

        drawWireForSimulationMAIN(objectForWriting, graph, ratio)

    End Sub

    'Σχεδίαση ενός αγωγού για προσομοίωση
    Public Sub drawWireForBMP(ByVal objectForWriting As Object, ByRef img As Image, ratio As Single, ChangeWireThickness As Boolean, NewThickness As Integer)
        'Δημιουργώ ένα αντικείμενο Graphics επάνω στο αντικείμενο
        Dim br As Graphics = Graphics.FromImage(img)
        Dim SavedStrokeWidth As Integer
        If ChangeWireThickness Then SavedStrokeWidth = NormalStrokeWidth : NormalStrokeWidth = NewThickness
        drawWireForSimulationMAIN(objectForWriting, br, ratio)
        If ChangeWireThickness Then NormalStrokeWidth = SavedStrokeWidth
    End Sub


    'Κορμός της σχεδίασης
    'Σχεδίαση του αγωγού επάνω στο αντικέιμενο objectforwriting με χρώμα whichcolor
    Public Sub drawWireForSimulationMAIN(ByVal objectForWriting As Object, graph As Graphics, ratio As Single)
        Dim energizedcolor = New SolidBrush(Color.Yellow)
        Dim energizedWidth = 3
        Dim wirePen As Pen = New Pen(whichColor, (NormalStrokeWidth + 1) * ratio)
        Dim nodepen As Pen = New Pen(nodecolor, nodewidth * ratio)

        Dim Energized As Pen = New Pen(energizedcolor, EnergizedWidth * ratio) 
        Energized.DashStyle = Drawing2D.DashStyle.Dot

        Dim EnergizedPE As Pen = New Pen(energizedcolor, energizedWidth * ratio)
        EnergizedPE.DashStyle = Drawing2D.DashStyle.Solid

        Dim shortpen As Pen = New Pen(shortcolor, (NormalStrokeWidth + 1) * ratio)
        Dim sc As SingleScrewData = Nothing
        Const moveby As Integer = 5 ' Ευθεία χρειάζεται μικρή μετακίνηση στο σημείο που ενώνεται με τις βίδες
        Dim i As Integer
        Dim xx1, yy1, xx2, yy2 As Integer
        Dim ThereIsAShort As Boolean = False
        'Ελέγχω αν υπάρχουν αρκετά δεδομένα
        On Error Resume Next


        For i = 0 To current_node - 1

            xx1 = 0 : xx2 = 0 : yy1 = 0 : yy2 = 0
            'Μετακίνηση της γραμμής για την πρώτη και την τελευταία βίδα γιατί ο αγωγός γιατί φτάνει μέχρι το κέντρο της βίδας και δεν φαίνεται καλά
            Select Case i
                Case 0
                    firstobject.returnScrew(firstscrew, sc)
                    If sc.isThereAShort Then ThereIsAShort = True
                    'Ανάλογα με το Where to put node κανουμε μετακίνηση του χ και ψ
                    If sc.WhereToPutNode = 0.5 Then yy1 = -sc.Height / 2 - moveby
                    If sc.WhereToPutNode = 1.5 Then yy1 = +sc.Height / 2 + moveby
                    If sc.WhereToPutNode = 1 Then xx1 = sc.Width / 2 + moveby

                    'Αν ο αγωγός δεν έχει καθόλου nodes τότε πρέπει να μετακινηθεί σε αυτή την φάση και η το τέλος της βίδας
                    If current_node = 1 Then
                        secondobject.returnScrew(secondscrew, sc)
                        If sc.isThereAShort Then ThereIsAShort = True
                        If sc.WhereToPutNode = 0.5 Then yy2 = -sc.Height / 2 - moveby
                        If sc.WhereToPutNode = 1.5 Then yy2 = +sc.Height / 2 + moveby
                        If sc.WhereToPutNode = 1 Then xx2 = sc.Width / 2 + moveby
                    End If
                Case current_node - 1
                    secondobject.returnScrew(secondscrew, sc)
                    If sc.isThereAShort Then ThereIsAShort = True
                    If sc.WhereToPutNode = 0.5 Then yy2 = -sc.Height / 2 - moveby
                    If sc.WhereToPutNode = 1.5 Then yy2 = +sc.Height / 2 + moveby
                    If sc.WhereToPutNode = 1 Then xx2 = sc.Width / 2 + moveby

            End Select
            If ThereIsAShort Then wirePen = shortpen
            'Σχεδίαση του αγωγού
            graph.DrawLine(wirePen, (xx1 + nodes(i).X) * ratio, (yy1 + nodes(i).Y) * ratio, (xx2 + nodes(i + 1).X) * ratio, (yy2 + nodes(i + 1).Y) * ratio)

            'Σχεδιαση του ενεργού αγωγού - διακεκκόμμένες από επανω
            'Dim sec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond Mod 100

            'Simulator.Text = sec
            If ((firstobject.returnScrewData(firstscrew).value And V_PhasesNeutralMask) > 0) Then
                Energized.DashOffset = DashedLineOffsetValue
                DashedLineOffsetValue = (DashedLineOffsetValue - 0.1) Mod 100

                If sc.value = V_PE Then 'Αν είναι αγωγός γείωσης
                    graph.DrawLine(EnergizedPE, (xx1 + nodes(i).X) * ratio, (yy1 + nodes(i).Y) * ratio, (xx2 + nodes(i + 1).X) * ratio, (yy2 + nodes(i + 1).Y) * ratio)
                Else                    'Αν είναι άλλος αγωγός
                    graph.DrawLine(Energized, (xx1 + nodes(i).X) * ratio, (yy1 + nodes(i).Y) * ratio, (xx2 + nodes(i + 1).X) * ratio, (yy2 + nodes(i + 1).Y) * ratio)

                End If



            End If


        Next

    End Sub

    'Αλλαγή των θέσεων των nodes όταν αλλάζει το ratio
    Public Sub changeRatio(oldratio As Integer, newratio As Integer)
        Dim i As Integer

        If firstobject Is Nothing Or secondobject Is Nothing Or firstscrew < 0 Or secondscrew < 0 Then Exit Sub

        For i = 0 To current_node
            nodes(i).X = nodes(i).X * oldratio / newratio
            nodes(i).Y = nodes(i).Y * oldratio / newratio
        Next


        last_nodes_first_run = True

    End Sub


    Public Overrides Function toString() As String

        Dim s As String
        Dim a1, a2 As String
        If firstobject Is Nothing Then a1 = "Nothing" Else a1 = "Ok"
        If secondobject Is Nothing Then a2 = "nothing" Else a2 = "Ok"
        s = "Obj1=" & a1 & ", Screw1=" & firstscrew.ToString & ", Obj2=" & a2 & ", Screw2=" & secondscrew.ToString


        Return s


    End Function
End Class
