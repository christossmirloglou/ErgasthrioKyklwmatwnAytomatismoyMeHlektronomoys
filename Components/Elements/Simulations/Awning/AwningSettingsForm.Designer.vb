<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AwningSettingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AwningSettingsForm))
        Me.TopTerminalList = New System.Windows.Forms.ListBox()
        Me.SaveAndExit = New System.Windows.Forms.Button()
        Me.DiscardAndExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BottomTerminalList = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MotorList = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MotorSpinDirection = New System.Windows.Forms.Button()
        Me.Closingtime = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ClearTopTerm = New System.Windows.Forms.Button()
        Me.ClearBottomTerm = New System.Windows.Forms.Button()
        Me.ClearMotor = New System.Windows.Forms.Button()
        Me.help = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LightSensorList = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ClearLightSensor = New System.Windows.Forms.Button()
        Me.ClearWindSensor = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.WindSensorList = New System.Windows.Forms.ListBox()
        Me.RainSensorList = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ClearRainSensor = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopTerminalList
        '
        Me.TopTerminalList.FormattingEnabled = True
        Me.TopTerminalList.Location = New System.Drawing.Point(12, 438)
        Me.TopTerminalList.Name = "TopTerminalList"
        Me.TopTerminalList.Size = New System.Drawing.Size(234, 69)
        Me.TopTerminalList.TabIndex = 0
        '
        'SaveAndExit
        '
        Me.SaveAndExit.Location = New System.Drawing.Point(224, 620)
        Me.SaveAndExit.Name = "SaveAndExit"
        Me.SaveAndExit.Size = New System.Drawing.Size(166, 46)
        Me.SaveAndExit.TabIndex = 1
        Me.SaveAndExit.Text = "Αποθήκευση και έξοδος"
        Me.SaveAndExit.UseVisualStyleBackColor = True
        '
        'DiscardAndExit
        '
        Me.DiscardAndExit.Location = New System.Drawing.Point(396, 620)
        Me.DiscardAndExit.Name = "DiscardAndExit"
        Me.DiscardAndExit.Size = New System.Drawing.Size(166, 46)
        Me.DiscardAndExit.TabIndex = 2
        Me.DiscardAndExit.Text = "Ακύρωση και έξοδος"
        Me.DiscardAndExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 409)
        Me.Label1.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Επιλογή τερματικού διακόπτη κλεισίματος τέντας"
        '
        'BottomTerminalList
        '
        Me.BottomTerminalList.FormattingEnabled = True
        Me.BottomTerminalList.Location = New System.Drawing.Point(714, 473)
        Me.BottomTerminalList.Name = "BottomTerminalList"
        Me.BottomTerminalList.Size = New System.Drawing.Size(234, 69)
        Me.BottomTerminalList.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(714, 444)
        Me.Label2.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Επιλογή τερματικού διακόπτη ανοίγματος τέντας"
        '
        'MotorList
        '
        Me.MotorList.FormattingEnabled = True
        Me.MotorList.Location = New System.Drawing.Point(714, 250)
        Me.MotorList.Name = "MotorList"
        Me.MotorList.Size = New System.Drawing.Size(234, 56)
        Me.MotorList.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(711, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Επιλογή κινητήρα κίνησης τέντας"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.MotorSpinDirection)
        Me.GroupBox1.Location = New System.Drawing.Point(714, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 90)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Κίνηση τέντας"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "τέντα"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "του κινητήρα κατεβάζει την "
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
        'Closingtime
        '
        Me.Closingtime.Location = New System.Drawing.Point(122, 26)
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
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Η τέντα να κλείνει σε"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Closingtime)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(714, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 58)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Χρόνος κατεβάσματος τέντας"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(191, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "δευτ."
        '
        'ClearTopTerm
        '
        Me.ClearTopTerm.Location = New System.Drawing.Point(12, 513)
        Me.ClearTopTerm.Name = "ClearTopTerm"
        Me.ClearTopTerm.Size = New System.Drawing.Size(109, 23)
        Me.ClearTopTerm.TabIndex = 18
        Me.ClearTopTerm.Text = "Χωρίς επιλογή"
        Me.ClearTopTerm.UseVisualStyleBackColor = True
        '
        'ClearBottomTerm
        '
        Me.ClearBottomTerm.Location = New System.Drawing.Point(714, 548)
        Me.ClearBottomTerm.Name = "ClearBottomTerm"
        Me.ClearBottomTerm.Size = New System.Drawing.Size(109, 23)
        Me.ClearBottomTerm.TabIndex = 19
        Me.ClearBottomTerm.Text = "Χωρίς επιλογή"
        Me.ClearBottomTerm.UseVisualStyleBackColor = True
        '
        'ClearMotor
        '
        Me.ClearMotor.Location = New System.Drawing.Point(714, 313)
        Me.ClearMotor.Name = "ClearMotor"
        Me.ClearMotor.Size = New System.Drawing.Size(109, 23)
        Me.ClearMotor.TabIndex = 20
        Me.ClearMotor.Text = "Χωρίς επιλογή"
        Me.ClearMotor.UseVisualStyleBackColor = True
        '
        'help
        '
        Me.help.Location = New System.Drawing.Point(568, 620)
        Me.help.Name = "help"
        Me.help.Size = New System.Drawing.Size(166, 46)
        Me.help.TabIndex = 21
        Me.help.Text = "Βοήθεια"
        Me.help.UseVisualStyleBackColor = True
        '
        'LightSensorList
        '
        Me.LightSensorList.FormattingEnabled = True
        Me.LightSensorList.Location = New System.Drawing.Point(15, 35)
        Me.LightSensorList.Name = "LightSensorList"
        Me.LightSensorList.Size = New System.Drawing.Size(234, 43)
        Me.LightSensorList.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(12, 19)
        Me.Label10.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Επιλογή αισθητήρα φωτός"
        '
        'ClearLightSensor
        '
        Me.ClearLightSensor.Location = New System.Drawing.Point(15, 84)
        Me.ClearLightSensor.Name = "ClearLightSensor"
        Me.ClearLightSensor.Size = New System.Drawing.Size(109, 23)
        Me.ClearLightSensor.TabIndex = 18
        Me.ClearLightSensor.Text = "Χωρίς επιλογή"
        Me.ClearLightSensor.UseVisualStyleBackColor = True
        '
        'ClearWindSensor
        '
        Me.ClearWindSensor.Location = New System.Drawing.Point(15, 180)
        Me.ClearWindSensor.Name = "ClearWindSensor"
        Me.ClearWindSensor.Size = New System.Drawing.Size(109, 23)
        Me.ClearWindSensor.TabIndex = 24
        Me.ClearWindSensor.Text = "Χωρίς επιλογή"
        Me.ClearWindSensor.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 115)
        Me.Label11.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(201, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Επιλογή αισθητήρα ταχύτητας ανέμου"
        '
        'WindSensorList
        '
        Me.WindSensorList.FormattingEnabled = True
        Me.WindSensorList.Location = New System.Drawing.Point(15, 131)
        Me.WindSensorList.Name = "WindSensorList"
        Me.WindSensorList.Size = New System.Drawing.Size(234, 43)
        Me.WindSensorList.TabIndex = 22
        '
        'RainSensorList
        '
        Me.RainSensorList.FormattingEnabled = True
        Me.RainSensorList.Location = New System.Drawing.Point(15, 234)
        Me.RainSensorList.Name = "RainSensorList"
        Me.RainSensorList.Size = New System.Drawing.Size(234, 43)
        Me.RainSensorList.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(12, 218)
        Me.Label12.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Επιλογή αισθητήρα βροχής"
        '
        'ClearRainSensor
        '
        Me.ClearRainSensor.Location = New System.Drawing.Point(15, 283)
        Me.ClearRainSensor.Name = "ClearRainSensor"
        Me.ClearRainSensor.Size = New System.Drawing.Size(109, 23)
        Me.ClearRainSensor.TabIndex = 24
        Me.ClearRainSensor.Text = "Χωρίς επιλογή"
        Me.ClearRainSensor.UseVisualStyleBackColor = True
        '
        'AwningSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ΕργαστήριοΚυκλωμάτωνΑυτοματισμού.My.Resources.Resources.awningsettingsimage
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(957, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.ClearRainSensor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ClearWindSensor)
        Me.Controls.Add(Me.RainSensorList)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.WindSensorList)
        Me.Controls.Add(Me.help)
        Me.Controls.Add(Me.ClearMotor)
        Me.Controls.Add(Me.ClearBottomTerm)
        Me.Controls.Add(Me.ClearLightSensor)
        Me.Controls.Add(Me.ClearTopTerm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MotorList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BottomTerminalList)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DiscardAndExit)
        Me.Controls.Add(Me.SaveAndExit)
        Me.Controls.Add(Me.LightSensorList)
        Me.Controls.Add(Me.TopTerminalList)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AwningSettingsForm"
        Me.ShowInTaskbar = False
        Me.Text = "Καθορισμός εξαρτημάτων ηλεκτροκίνησης τέντας"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Closingtime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TopTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents SaveAndExit As System.Windows.Forms.Button
    Friend WithEvents DiscardAndExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BottomTerminalList As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MotorList As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MotorSpinDirection As System.Windows.Forms.Button
    Friend WithEvents Closingtime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ClearTopTerm As System.Windows.Forms.Button
    Friend WithEvents ClearBottomTerm As System.Windows.Forms.Button
    Friend WithEvents ClearMotor As System.Windows.Forms.Button
    Friend WithEvents help As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LightSensorList As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ClearLightSensor As System.Windows.Forms.Button
    Friend WithEvents ClearWindSensor As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents WindSensorList As System.Windows.Forms.ListBox
    Friend WithEvents RainSensorList As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ClearRainSensor As System.Windows.Forms.Button
End Class
