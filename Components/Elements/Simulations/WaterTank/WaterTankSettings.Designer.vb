<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaterTankSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WaterTankSettings))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ClearMotor = New System.Windows.Forms.Button()
        Me.ClearTopTerm = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Closingtime = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ClearBottomTerm = New System.Windows.Forms.Button()
        Me.MotorList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MotorSpinDirection = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BottomTerminalList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DiscardAndExit = New System.Windows.Forms.Button()
        Me.SaveAndExit = New System.Windows.Forms.Button()
        Me.TopTerminalList = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Help = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.WaterTank
        Me.PictureBox1.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.WaterTank
        Me.PictureBox1.Location = New System.Drawing.Point(252, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(292, 217)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'ClearMotor
        '
        Me.ClearMotor.Location = New System.Drawing.Point(135, 228)
        Me.ClearMotor.Name = "ClearMotor"
        Me.ClearMotor.Size = New System.Drawing.Size(109, 23)
        Me.ClearMotor.TabIndex = 46
        Me.ClearMotor.Text = "Χωρίς επιλογή"
        Me.ClearMotor.UseVisualStyleBackColor = True
        '
        'ClearTopTerm
        '
        Me.ClearTopTerm.Location = New System.Drawing.Point(550, 73)
        Me.ClearTopTerm.Name = "ClearTopTerm"
        Me.ClearTopTerm.Size = New System.Drawing.Size(109, 23)
        Me.ClearTopTerm.TabIndex = 44
        Me.ClearTopTerm.Text = "Χωρίς επιλογή"
        Me.ClearTopTerm.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Closingtime)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(275, 58)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Χρόνος κατεβάσματος γκαραζόπορτας"
        Me.GroupBox2.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(233, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "δευτ."
        '
        'Closingtime
        '
        Me.Closingtime.Location = New System.Drawing.Point(168, 26)
        Me.Closingtime.Name = "Closingtime"
        Me.Closingtime.Size = New System.Drawing.Size(59, 20)
        Me.Closingtime.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(159, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Η γκαραζόπορτα να κλείνει σε"
        '
        'ClearBottomTerm
        '
        Me.ClearBottomTerm.Location = New System.Drawing.Point(550, 199)
        Me.ClearBottomTerm.Name = "ClearBottomTerm"
        Me.ClearBottomTerm.Size = New System.Drawing.Size(109, 23)
        Me.ClearBottomTerm.TabIndex = 45
        Me.ClearBottomTerm.Text = "Χωρίς επιλογή"
        Me.ClearBottomTerm.UseVisualStyleBackColor = True
        '
        'MotorList
        '
        Me.MotorList.FormattingEnabled = True
        Me.MotorList.Location = New System.Drawing.Point(10, 166)
        Me.MotorList.Name = "MotorList"
        Me.MotorList.Size = New System.Drawing.Size(234, 56)
        Me.MotorList.TabIndex = 41
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.MotorSpinDirection)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 90)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Κίνηση γκαραζόπορτας"
        Me.GroupBox1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "γκαραζόπορτα"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "του κινητήρα κλείνει την "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Η"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "περιστροφή"
        '
        'MotorSpinDirection
        '
        Me.MotorSpinDirection.Location = New System.Drawing.Point(28, 19)
        Me.MotorSpinDirection.Name = "MotorSpinDirection"
        Me.MotorSpinDirection.Size = New System.Drawing.Size(110, 22)
        Me.MotorSpinDirection.TabIndex = 13
        Me.MotorSpinDirection.Text = "αριστερόστροφη"
        Me.MotorSpinDirection.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(547, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Επιλογή κάτω φλοτεροδιακόπτη"
        '
        'BottomTerminalList
        '
        Me.BottomTerminalList.FormattingEnabled = True
        Me.BottomTerminalList.Location = New System.Drawing.Point(550, 151)
        Me.BottomTerminalList.Name = "BottomTerminalList"
        Me.BottomTerminalList.Size = New System.Drawing.Size(234, 43)
        Me.BottomTerminalList.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(547, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Επιλογή άνω φλοτεροδιακόπτη"
        '
        'DiscardAndExit
        '
        Me.DiscardAndExit.Location = New System.Drawing.Point(351, 258)
        Me.DiscardAndExit.Name = "DiscardAndExit"
        Me.DiscardAndExit.Size = New System.Drawing.Size(166, 46)
        Me.DiscardAndExit.TabIndex = 37
        Me.DiscardAndExit.Text = "Ακύρωση και έξοδος"
        Me.DiscardAndExit.UseVisualStyleBackColor = True
        '
        'SaveAndExit
        '
        Me.SaveAndExit.Location = New System.Drawing.Point(179, 258)
        Me.SaveAndExit.Name = "SaveAndExit"
        Me.SaveAndExit.Size = New System.Drawing.Size(166, 46)
        Me.SaveAndExit.TabIndex = 36
        Me.SaveAndExit.Text = "Αποθήκευση και έξοδος"
        Me.SaveAndExit.UseVisualStyleBackColor = True
        '
        'TopTerminalList
        '
        Me.TopTerminalList.FormattingEnabled = True
        Me.TopTerminalList.Location = New System.Drawing.Point(550, 24)
        Me.TopTerminalList.Name = "TopTerminalList"
        Me.TopTerminalList.Size = New System.Drawing.Size(234, 43)
        Me.TopTerminalList.TabIndex = 35
        '
        'Help
        '
        Me.Help.Location = New System.Drawing.Point(523, 258)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(166, 46)
        Me.Help.TabIndex = 48
        Me.Help.Text = "Βοήθεια"
        Me.Help.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Επιλογή κινητήρα(αντλίας) πλήρωσης νερού"
        '
        'WaterTankSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(795, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Help)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ClearMotor)
        Me.Controls.Add(Me.ClearTopTerm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ClearBottomTerm)
        Me.Controls.Add(Me.MotorList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BottomTerminalList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DiscardAndExit)
        Me.Controls.Add(Me.SaveAndExit)
        Me.Controls.Add(Me.TopTerminalList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WaterTankSettings"
        Me.Text = "Καθορισμός εξαρτημάτων δεξαμενής νερού"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ClearMotor As System.Windows.Forms.Button
    Friend WithEvents ClearTopTerm As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Closingtime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ClearBottomTerm As System.Windows.Forms.Button
    Friend WithEvents MotorList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MotorSpinDirection As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BottomTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DiscardAndExit As System.Windows.Forms.Button
    Friend WithEvents SaveAndExit As System.Windows.Forms.Button
    Friend WithEvents TopTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Help As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
