Public Class Power_ActiveImage
    Inherits ActiveImage
    '0 = Από πάνω
    '1 = Από κάτω
    '2 = Από αριστερά
    Public WhatTypeOfPowerSource As Integer = 0
    Public Overrides Sub initialization()
        initialization(WhatTypeOfPowerSource)
    End Sub
    Public Overrides Sub initialization(Whitchtype As Integer)
        WhatTypeOfPowerSource = Whitchtype
        Select Case Whitchtype
            Case 0
                Me.information = "Τριφασική παροχή με ουδέτερο και γείωση - Παροχή από την κάτω πλευρά."
                Me.Image = My.Resources.Supply_FromBelow
                addScrew(6, 4, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 0.5, Me)
                addScrew(31, 4, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 0.5, Me)
                addScrew(56, 4, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 0.5, Me)
                addScrew(81, 4, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 0.5, Me)
                addScrew(106, 4, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 0.5, Me)
                Me.setMoveBounds()
                Me.numberOfScrews = 4
            Case 1
                Me.information = "Τριφασική παροχή με ουδέτερο και γείωση. Παροχή από την πάνω πλευρά"
                Me.Image = My.Resources.Supply_FromTop
                addScrew(6, 117, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 1.5, Me)
                addScrew(31, 117, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 1.5, Me)
                addScrew(56, 117, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 1.5, Me)
                addScrew(81, 117, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 1.5, Me)
                addScrew(106, 117, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 1.5, Me)
                Me.setMoveBounds()
                Me.numberOfScrews = 4
            Case Else
                Me.information = "Τριφασική παροχή με ουδέτερο και γείωση. Παροχή από τα αριστερά"
                Me.Image = My.Resources.Supply_FromLeft
                Me.addScrew(117, 6, 15, 15, "L1", "Ακροδέκτης παροχής φάσης L1", wirecolors(0), 1, Me)
                Me.addScrew(117, 31, 15, 15, "L2", "Ακροδέκτης παροχής φάσης L2", wirecolors(1), 1, Me)
                Me.addScrew(117, 56, 15, 15, "L3", "Ακροδέκτης παροχής φάσης L3", wirecolors(2), 1, Me)
                Me.addScrew(117, 81, 15, 15, "N", "Ακροδέκτης ουδετέρου", wirecolors(3), 1, Me)
                Me.addScrew(117, 106, 15, 15, "PE", "Ακροδέκτης γείωσης", wirecolors(4), 1, Me)
                Me.setMoveBounds()
                Me.numberOfScrews = 4
        End Select
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
    End Sub
    Public Overrides Function whatami() As String
        Return "POWER"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Τροφοδοσία"
    End Function
End Class
