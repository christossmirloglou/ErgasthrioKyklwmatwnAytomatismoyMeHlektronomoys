Public Class Fuse_ActiveImage
    Inherits ActiveImage
    Public Overrides Sub initialization()



        Me.information = "Μονοπολική τηκτή ασφάλεια. Προστατεύει από υπεφόρτιση και βραχυκύκλωμα."
        Me.Image = My.Resources.fuse_1P
        Me.addScrew(1, 1, 38, 38, "1", "Αυτό είναι το ένα άκρο της ασφάλειας. Η ασφάλεια προστατεύει το κύκλωμα από βραχυκυκλώματα και υπερεντάσεις.", wirecolors(0), 0.5, Me)
        Me.addScrew(1, 134, 38, 38, "2", "Αυτό είναι το άλλο άκρο της ασφάλειας. Η ασφάλεια προστατεύει το κύκλωμα από βραχυκυκλώματα και υπερεντάσεις.", wirecolors(0), 1.5, Me)
        Me.numberOfScrews = 1
        Me.setMoveBounds()

    End Sub
Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

    End Sub
    Public Overrides Function whatami() As String
        Return "FUSE"
    End Function
End Class
