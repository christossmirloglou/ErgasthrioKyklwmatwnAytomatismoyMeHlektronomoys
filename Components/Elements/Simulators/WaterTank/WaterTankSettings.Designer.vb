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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WaterTankSettings))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MotorSpinDirection = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Closingtime = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TopTerminalList = New System.Windows.Forms.ListBox()
        Me.ClearTopTerm = New System.Windows.Forms.Button()
        Me.ClearBottomTerm = New System.Windows.Forms.Button()
        Me.MotorList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BottomTerminalList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveAndExit = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.WaterTank
        Me.PictureBox1.Location = New System.Drawing.Point(257, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(292, 217)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(11, 214)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 44)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Χωρίς επιλογή"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Closingtime
        '
        Me.Closingtime.Location = New System.Drawing.Point(147, 26)
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
        Me.Label9.Size = New System.Drawing.Size(135, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Η δεξαμενή να γεμίζει σε"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Closingtime)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(555, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 58)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Χρόνος γεμίσματος δεξαμενής"
        Me.GroupBox2.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(216, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "δευτ."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Επιλογή κινητήρα αντλίας νερού"
        '
        'TopTerminalList
        '
        Me.TopTerminalList.FormattingEnabled = True
        Me.TopTerminalList.Location = New System.Drawing.Point(552, 49)
        Me.TopTerminalList.Name = "TopTerminalList"
        Me.TopTerminalList.Size = New System.Drawing.Size(234, 43)
        Me.TopTerminalList.TabIndex = 35
        '
        'ClearTopTerm
        '
        Me.ClearTopTerm.Location = New System.Drawing.Point(792, 47)
        Me.ClearTopTerm.Name = "ClearTopTerm"
        Me.ClearTopTerm.Size = New System.Drawing.Size(109, 45)
        Me.ClearTopTerm.TabIndex = 45
        Me.ClearTopTerm.Text = "Χωρίς επιλογή"
        Me.ClearTopTerm.UseVisualStyleBackColor = True
        '
        'ClearBottomTerm
        '
        Me.ClearBottomTerm.Location = New System.Drawing.Point(792, 121)
        Me.ClearBottomTerm.Name = "ClearBottomTerm"
        Me.ClearBottomTerm.Size = New System.Drawing.Size(109, 43)
        Me.ClearBottomTerm.TabIndex = 46
        Me.ClearBottomTerm.Text = "Χωρίς επιλογή"
        Me.ClearBottomTerm.UseVisualStyleBackColor = True
        '
        'MotorList
        '
        Me.MotorList.FormattingEnabled = True
        Me.MotorList.Location = New System.Drawing.Point(11, 151)
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
        Me.GroupBox1.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 90)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Κίνηση γκαραζόπορτας"
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(552, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Επιλογή κάτω φλοτεροδιακόπτη"
        '
        'BottomTerminalList
        '
        Me.BottomTerminalList.FormattingEnabled = True
        Me.BottomTerminalList.Location = New System.Drawing.Point(555, 121)
        Me.BottomTerminalList.Name = "BottomTerminalList"
        Me.BottomTerminalList.Size = New System.Drawing.Size(234, 43)
        Me.BottomTerminalList.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(549, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Επιλογή άνω φλοτεροδιακόπτη"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(414, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 46)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Ακύρωση και έξοδος"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SaveAndExit
        '
        Me.SaveAndExit.Location = New System.Drawing.Point(242, 259)
        Me.SaveAndExit.Name = "SaveAndExit"
        Me.SaveAndExit.Size = New System.Drawing.Size(166, 46)
        Me.SaveAndExit.TabIndex = 36
        Me.SaveAndExit.Text = "Αποθήκευση και έξοδος"
        Me.SaveAndExit.UseVisualStyleBackColor = True
        '
        'WaterTankSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(909, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TopTerminalList)
        Me.Controls.Add(Me.ClearTopTerm)
        Me.Controls.Add(Me.ClearBottomTerm)
        Me.Controls.Add(Me.MotorList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BottomTerminalList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SaveAndExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WaterTankSettings"
        Me.Text = "Καθορισμός εξαρτημάτων δεξαμενής"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MotorSpinDirection As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Closingtime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TopTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents ClearTopTerm As System.Windows.Forms.Button
    Friend WithEvents ClearBottomTerm As System.Windows.Forms.Button
    Friend WithEvents MotorList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BottomTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveAndExit As System.Windows.Forms.Button
End Class
