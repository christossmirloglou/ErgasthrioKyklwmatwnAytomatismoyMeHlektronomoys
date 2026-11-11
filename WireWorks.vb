Public Class WireWorks

    Public drawnodes As Boolean = True

    Public allWires(maxwires) As Wire
    Public Sub selectallbut(whichone As Integer)
        If whichone < 0 Or whichone > maxwires Then Exit Sub
        For i = 0 To whichone - 1
            allWires(i).SetSelected(False)
        Next
        For i = whichone + 1 To numberOfWires

            allWires(i).SetSelected(False)
        Next
    End Sub

    Public Sub selectnone()
        For i = 0 To numberOfWires
            allWires(i).SetSelected(False)
        Next
    End Sub

    'Έλεγχω αν υπάρχει ήδη αυτός ο αγωγός που θέλω να δημιουργήσω
    Function doesThisWireAlreadyExist(ByRef Clickedobj As ActiveImage, activeobject As ActiveImage, activescrewnum As Integer, currentactivescrew As Integer) As Integer
        Dim i As Integer
        For i = 0 To numberOfWires
            If allWires(i).ConfigurationAlreadyExists(activeobject, activescrewnum, Clickedobj, currentactivescrew) Then Return i : Exit Function
        Next
        Return -1
    End Function



    'Σχεδίαση όλων των αγωγών
    Sub drawAllWires()
        Dim i As Integer
        For i = 0 To numberOfWires
            allWires(i).drawWire(edit, edit.HScrollBar1.Value, drawnodes)
        Next
    End Sub

    'Σχεδίαση όλων των αγωγών για προσομοίωση
    Sub drawAllWires_for_Simulation(where As Object, ratio As Single)
        Dim i As Integer
        For i = 0 To numberOfWires
            allWires(i).drawWireForSimulation(where, ratio)
        Next
    End Sub
    'Σχεδίαση για αποθήκευση εικόνας
    Sub drawallwires_for_bmp(where As Object, img As Image, ratio As Single, ChangeWireThickness As Boolean, NewThickness As Integer)
        Dim i As Integer
        For i = 0 To numberOfWires
            allWires(i).drawWireForBMP(where, img, ratio, ChangeWireThickness, NewThickness)
        Next

    End Sub
    '-----------------------------------------------------------------------------------------------------
    'Αλλαγή όλων των ratios
    Sub changeAllWireRatios(lastratiovalue As Integer)
        Dim i As Integer
        For i = 0 To numberOfWires
            allWires(i).changeRatio(lastRatioValue, edit.HScrollBar1.Value)
        Next
    End Sub
    Sub deleteSelectedNode(nodeToBeDeleted As Integer)
        'checkit.Items.Add("Deleteing. Selected=" + deleteme.GetSelectedStatus.ToString & " Selected Node (deleteme) = " & deleteme.getSelectedNode.ToString & " Node to be deleted :" & nodeToBeDeleted.ToString)
        If nodeToBeDeleted < 0 Then Exit Sub
        allWires(selectedWire).RemoveNode(nodeToBeDeleted)
        allWires(selectedWire).resetSelectedNode()
        edit.Refresh()

        drawAllWires()
        'deleteme.drawWire(Me, HScrollBar1.Value)
    End Sub

    Sub deleteSelectedWire(WireToBeDeleted As Integer)
        Dim i As Integer
        If numberOfWires < 0 Then Exit Sub

        For i = WireToBeDeleted To numberOfWires - 1
            allWires(i) = allWires(i + 1)
        Next

        allWires(numberOfWires) = Nothing
        numberOfWires = numberOfWires - 1
    End Sub

    Public Sub findMINMAXinAllWires(ByRef minx As Integer, ByRef miny As Integer, ByRef maxx As Integer, ByRef maxy As Integer)
        Dim i As Integer
        If numberOfWires < 0 Then Exit Sub

        For i = 0 To numberOfWires
            allWires(i).findMINMAX(minx, miny, maxx, maxy)
        Next

    End Sub
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------\
    'Όταν πρόκειται να διαγράψουμε ένα στοιχείο (ρελέ) θα πρέπει πριν από αυτό να γίνει διαγραφή όλων των αγωγών που σχετίζονται με αυτό το ρελέ.
    'Αυτή η δουλεία γίνεται σε αυτό το sub.
    Sub deleteAllWiresAssociatedWith(relayToBeDeleted As ActiveImage)
        Dim i As Integer
        Dim relay1 As ActiveImage
        Dim relay2 As ActiveImage
        Dim ok1 As Boolean
        Dim ok2 As Boolean


        For i = numberOfWires To 0 Step -1                                                       'Σάρωση όλων των αγωγών 


            relay1 = allWires(i).getFirstObject(ok1)                                          'Για το συγκεκριμένο αγωγό πάρε το Reference του πρώτου ρελέ και αποθήκευσε το στο Relay
            relay2 = allWires(i).getSecondObject(ok2)                                         'Το ίδιο για το δεύτερο ρελέ

            If ok1 And ok2 Then                                                                     'Εάν το 1o Reference υπάρχει
                If (relayToBeDeleted Is relay1) Or (relayToBeDeleted Is relay2) Then deleteSelectedWire(i) 'Εάν εντοπιστεί ότι το wire ανήκει στο συγκεκριμένο ρελέ τότε διαγραφή του συγκεκριμένου Wire
            End If


        Next
    End Sub
End Class
