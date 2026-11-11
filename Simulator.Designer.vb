<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Simulator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Simulator))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ΠροσομοίωσηToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΕκκίνησηToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΕπαναφοράToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΈξοδοςToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ΈξοδοςToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΠροβολήToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΜεγέθυνσηToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΣμίκρινσηToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΡυθμίσειςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΒοήθειαToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΒοήθειαΣτοYoutubeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΠροσομοίωσηToolStripMenuItem, Me.ΠροβολήToolStripMenuItem, Me.ΡυθμίσειςToolStripMenuItem, Me.ΒοήθειαToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1503, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ΠροσομοίωσηToolStripMenuItem
        '
        Me.ΠροσομοίωσηToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΕκκίνησηToolStripMenuItem, Me.ΕκτέλεσηΒήματοςToolStripMenuItem, Me.ΕπαναφοράToolStripMenuItem, Me.ΈξοδοςToolStripMenuItem1, Me.ΈξοδοςToolStripMenuItem2})
        Me.ΠροσομοίωσηToolStripMenuItem.Name = "ΠροσομοίωσηToolStripMenuItem"
        Me.ΠροσομοίωσηToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.ΠροσομοίωσηToolStripMenuItem.Text = "Προσομοίωση"
        Me.ΠροσομοίωσηToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ξεκινήσετε ή να επανεκκινήσετε την προσομοίωση."
        '
        'ΕκκίνησηToolStripMenuItem
        '
        Me.ΕκκίνησηToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.play_button
        Me.ΕκκίνησηToolStripMenuItem.Name = "ΕκκίνησηToolStripMenuItem"
        Me.ΕκκίνησηToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ΕκκίνησηToolStripMenuItem.Text = "Εκκίνηση"
        Me.ΕκκίνησηToolStripMenuItem.ToolTipText = "Πιέστε αυτό το πλήκτρο για να ξεκινήσει η διαδικασία της προσομοίωσης"
        '
        'ΕκτέλεσηΒήματοςToolStripMenuItem
        '
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.play_pause_button
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem.Name = "ΕκτέλεσηΒήματοςToolStripMenuItem"
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem.Text = "Εκτέλεση βήματος"
        Me.ΕκτέλεσηΒήματοςToolStripMenuItem.Visible = False
        '
        'ΕπαναφοράToolStripMenuItem
        '
        Me.ΕπαναφοράToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.go_back
        Me.ΕπαναφοράToolStripMenuItem.Name = "ΕπαναφοράToolStripMenuItem"
        Me.ΕπαναφοράToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ΕπαναφοράToolStripMenuItem.Text = "Επαναφορά"
        Me.ΕπαναφοράToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ξεκινήσετε την διαδικασία της προσομοίωσης από την αρχή."
        '
        'ΈξοδοςToolStripMenuItem1
        '
        Me.ΈξοδοςToolStripMenuItem1.Name = "ΈξοδοςToolStripMenuItem1"
        Me.ΈξοδοςToolStripMenuItem1.Size = New System.Drawing.Size(169, 6)
        '
        'ΈξοδοςToolStripMenuItem2
        '
        Me.ΈξοδοςToolStripMenuItem2.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.power_on_off
        Me.ΈξοδοςToolStripMenuItem2.Name = "ΈξοδοςToolStripMenuItem2"
        Me.ΈξοδοςToolStripMenuItem2.Size = New System.Drawing.Size(172, 22)
        Me.ΈξοδοςToolStripMenuItem2.Text = "Έξοδος"
        Me.ΈξοδοςToolStripMenuItem2.ToolTipText = "Έξοδος και επανεμφάνιση του παραθύρου επεξεργασίας του κυκλώματος."
        '
        'ΠροβολήToolStripMenuItem
        '
        Me.ΠροβολήToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΜεγέθυνσηToolStripMenuItem, Me.ΣμίκρινσηToolStripMenuItem, Me.ToolStripMenuItem1, Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem, Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem})
        Me.ΠροβολήToolStripMenuItem.Name = "ΠροβολήToolStripMenuItem"
        Me.ΠροβολήToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.ΠροβολήToolStripMenuItem.Text = "Προβολή"
        Me.ΠροβολήToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να αλλάξετε τις ρυθμίσεις της προβολής."
        '
        'ΜεγέθυνσηToolStripMenuItem
        '
        Me.ΜεγέθυνσηToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.zoom_in
        Me.ΜεγέθυνσηToolStripMenuItem.Name = "ΜεγέθυνσηToolStripMenuItem"
        Me.ΜεγέθυνσηToolStripMenuItem.Size = New System.Drawing.Size(361, 22)
        Me.ΜεγέθυνσηToolStripMenuItem.Text = "Μεγέθυνση"
        Me.ΜεγέθυνσηToolStripMenuItem.ToolTipText = "Μεγέθυνση του κυκλώματος. Μπορείτε να χρησιμοποιήσετε και το ροδάκι του ποντικιού" & _
    "."
        '
        'ΣμίκρινσηToolStripMenuItem
        '
        Me.ΣμίκρινσηToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.zoom_out
        Me.ΣμίκρινσηToolStripMenuItem.Name = "ΣμίκρινσηToolStripMenuItem"
        Me.ΣμίκρινσηToolStripMenuItem.Size = New System.Drawing.Size(361, 22)
        Me.ΣμίκρινσηToolStripMenuItem.Text = "Σμίκρυνση"
        Me.ΣμίκρινσηToolStripMenuItem.ToolTipText = "Σμίκρυνση του κυκλώματος. Μπορείτε να χρησιμοποιήσετε και το ροδάκι του ποντικιού" & _
    "."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(358, 6)
        '
        'ΠαρακολούθησηΚατάστασηςToolStripMenuItem
        '
        Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Name = "ΠαρακολούθησηΚατάστασηςToolStripMenuItem"
        Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Size = New System.Drawing.Size(361, 22)
        Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem.Text = "Εμφάνιση παραθύρου παρακολούθησης κατάστασης"
        Me.ΠαρακολούθησηΚατάστασηςToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να εμφανιστεί/εξαφανιστεί το παράθυρο παρακολούθησης κατάστασης."
        '
        'ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem
        '
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Name = "ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem"
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Size = New System.Drawing.Size(361, 22)
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Tag = "Πιέστε εδώ για να ξεκινήσετε/σταματήσετε την χρήση συμβόλων."
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.Text = "Προσομοίωση με χρήση συμβόλων"
        Me.ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ενεργοποιήσετε/απενεργοποιήσετε την προβολή των συμβόλων των εξ" & _
    "αρτημάτων του κυκλώματος"
        '
        'ΡυθμίσειςToolStripMenuItem
        '
        Me.ΡυθμίσειςToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem, Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem})
        Me.ΡυθμίσειςToolStripMenuItem.Name = "ΡυθμίσειςToolStripMenuItem"
        Me.ΡυθμίσειςToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ΡυθμίσειςToolStripMenuItem.Text = "Ρυθμίσεις"
        Me.ΡυθμίσειςToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ρυθμίσετε τον χρόνο προσομοίωσης ή να ενεργοποιήσετε/απενεργοπο" & _
    "ιήσετε τον ήχο της προσομοίωσης."
        '
        'ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem
        '
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.time
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.Name = "ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem"
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.Text = "Ρύθμιση βήματος προσομοίωσης"
        Me.ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ρυθμίσετε τον ανά πόσο χρόνο θα εκτελείτε το κάθε βήμα της προσ" & _
    "ομοίωσης"
        '
        'ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem
        '
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.sound_mute_button
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Name = "ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem"
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.Text = "Σίγαση ήχου"
        Me.ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem.ToolTipText = "Πιέστε εδώ για να ενεργοποιήσετε/απενεργοποιήσετε τα ηχητικά εφέ κατά τη διάρκεια" & _
    " της προσομοίωσης."
        '
        'ΒοήθειαToolStripMenuItem
        '
        Me.ΒοήθειαToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΒοήθειαΣτοYoutubeToolStripMenuItem})
        Me.ΒοήθειαToolStripMenuItem.Name = "ΒοήθειαToolStripMenuItem"
        Me.ΒοήθειαToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ΒοήθειαToolStripMenuItem.Text = "Βοήθεια"
        '
        'ΒοήθειαΣτοYoutubeToolStripMenuItem
        '
        Me.ΒοήθειαΣτοYoutubeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem})
        Me.ΒοήθειαΣτοYoutubeToolStripMenuItem.Name = "ΒοήθειαΣτοYoutubeToolStripMenuItem"
        Me.ΒοήθειαΣτοYoutubeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ΒοήθειαΣτοYoutubeToolStripMenuItem.Text = "Βίντεο βοήθειας"
        '
        'ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem
        '
        Me.ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem.Name = "ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem"
        Me.ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem.Text = "Διαδικασία προσομοίωσης ενός κυκλώματος"
        '
        'Simulator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1503, 830)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Simulator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Προσομοίωση κυκλώματος"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ΠροσομοίωσηToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΕκκίνησηToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΠροβολήToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΜεγέθυνσηToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΣμίκρινσηToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΕπαναφοράToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ΠαρακολούθησηΚατάστασηςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΈξοδοςToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ΈξοδοςToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΡυθμίσειςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΡύθμισηΒήματοςΠροσομοίωσηςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΣίγασηΕνεργοποίησηΉχουToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΠροσομοίωσηΜεΧρήσηΣυμβόλωνToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΒοήθειαToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΒοήθειαΣτοYoutubeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΔιαδικασίαΠροσομοίωσηςΕνόςΚυκλώματοςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ΕκτέλεσηΒήματοςToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
