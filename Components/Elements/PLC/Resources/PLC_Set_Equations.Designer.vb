<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PLC_Set_Equations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PLC_Set_Equations))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListOfEquations = New System.Windows.Forms.ListBox()
        Me.EquationEditBox = New System.Windows.Forms.TextBox()
        Me.TitleofList = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Save_And_Exit = New System.Windows.Forms.Button()
        Me.Discard_All = New System.Windows.Forms.Button()
        Me.CheckAndChange = New System.Windows.Forms.Button()
        Me.SelectedOutputLabel = New System.Windows.Forms.Label()
        Me.SelectOutputs = New System.Windows.Forms.Button()
        Me.SelectMemory = New System.Windows.Forms.Button()
        Me.SelectTON = New System.Windows.Forms.Button()
        Me.SelectToff = New System.Windows.Forms.Button()
        Me.SelectCounter = New System.Windows.Forms.Button()
        Me.Helpme = New System.Windows.Forms.Button()
        Me.ParameterEditBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CUButton = New System.Windows.Forms.Button()
        Me.CDButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Επιλέξτε τα στοιχεία που επιθυμείτε να επεξεργαστείτε:"
        '
        'ListOfEquations
        '
        Me.ListOfEquations.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ListOfEquations.FormattingEnabled = True
        Me.ListOfEquations.ItemHeight = 24
        Me.ListOfEquations.Location = New System.Drawing.Point(15, 116)
        Me.ListOfEquations.Name = "ListOfEquations"
        Me.ListOfEquations.Size = New System.Drawing.Size(549, 124)
        Me.ListOfEquations.TabIndex = 5
        '
        'EquationEditBox
        '
        Me.EquationEditBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EquationEditBox.Location = New System.Drawing.Point(97, 265)
        Me.EquationEditBox.Name = "EquationEditBox"
        Me.EquationEditBox.Size = New System.Drawing.Size(363, 29)
        Me.EquationEditBox.TabIndex = 6
        '
        'TitleofList
        '
        Me.TitleofList.AutoSize = True
        Me.TitleofList.Location = New System.Drawing.Point(12, 100)
        Me.TitleofList.Name = "TitleofList"
        Me.TitleofList.Size = New System.Drawing.Size(100, 13)
        Me.TitleofList.TabIndex = 4
        Me.TitleofList.Text = "Λογικές εξισώσεις"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(301, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Επεξεργασία λογικής εξίσωσης του επιλεγμένου στοιχείου"
        '
        'Save_And_Exit
        '
        Me.Save_And_Exit.Location = New System.Drawing.Point(15, 367)
        Me.Save_And_Exit.Name = "Save_And_Exit"
        Me.Save_And_Exit.Size = New System.Drawing.Size(144, 23)
        Me.Save_And_Exit.TabIndex = 9
        Me.Save_And_Exit.Text = "Αποθήκευση και έξοδος"
        Me.Save_And_Exit.UseVisualStyleBackColor = True
        '
        'Discard_All
        '
        Me.Discard_All.Location = New System.Drawing.Point(219, 367)
        Me.Discard_All.Name = "Discard_All"
        Me.Discard_All.Size = New System.Drawing.Size(182, 23)
        Me.Discard_All.TabIndex = 10
        Me.Discard_All.Text = "Ακύρωση όλων των αλλαγών"
        Me.Discard_All.UseVisualStyleBackColor = True
        '
        'CheckAndChange
        '
        Me.CheckAndChange.Location = New System.Drawing.Point(466, 265)
        Me.CheckAndChange.Name = "CheckAndChange"
        Me.CheckAndChange.Size = New System.Drawing.Size(98, 29)
        Me.CheckAndChange.TabIndex = 8
        Me.CheckAndChange.Text = "Καταχώρηση"
        Me.CheckAndChange.UseVisualStyleBackColor = True
        '
        'SelectedOutputLabel
        '
        Me.SelectedOutputLabel.AutoSize = True
        Me.SelectedOutputLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SelectedOutputLabel.Location = New System.Drawing.Point(12, 265)
        Me.SelectedOutputLabel.Name = "SelectedOutputLabel"
        Me.SelectedOutputLabel.Size = New System.Drawing.Size(16, 24)
        Me.SelectedOutputLabel.TabIndex = 11
        Me.SelectedOutputLabel.Text = "-"
        '
        'SelectOutputs
        '
        Me.SelectOutputs.Location = New System.Drawing.Point(15, 32)
        Me.SelectOutputs.Name = "SelectOutputs"
        Me.SelectOutputs.Size = New System.Drawing.Size(75, 23)
        Me.SelectOutputs.TabIndex = 0
        Me.SelectOutputs.Text = "10 Έξοδοι"
        Me.SelectOutputs.UseVisualStyleBackColor = True
        '
        'SelectMemory
        '
        Me.SelectMemory.Location = New System.Drawing.Point(15, 61)
        Me.SelectMemory.Name = "SelectMemory"
        Me.SelectMemory.Size = New System.Drawing.Size(75, 23)
        Me.SelectMemory.TabIndex = 1
        Me.SelectMemory.Text = "100 Μνήμες"
        Me.SelectMemory.UseVisualStyleBackColor = True
        '
        'SelectTON
        '
        Me.SelectTON.Location = New System.Drawing.Point(198, 32)
        Me.SelectTON.Name = "SelectTON"
        Me.SelectTON.Size = New System.Drawing.Size(123, 23)
        Me.SelectTON.TabIndex = 2
        Me.SelectTON.Text = "10 Χρονικά Delay On"
        Me.SelectTON.UseVisualStyleBackColor = True
        '
        'SelectToff
        '
        Me.SelectToff.Location = New System.Drawing.Point(198, 61)
        Me.SelectToff.Name = "SelectToff"
        Me.SelectToff.Size = New System.Drawing.Size(123, 23)
        Me.SelectToff.TabIndex = 3
        Me.SelectToff.Text = "10 Χρονικά Delay Off"
        Me.SelectToff.UseVisualStyleBackColor = True
        '
        'SelectCounter
        '
        Me.SelectCounter.Location = New System.Drawing.Point(406, 32)
        Me.SelectCounter.Name = "SelectCounter"
        Me.SelectCounter.Size = New System.Drawing.Size(158, 23)
        Me.SelectCounter.TabIndex = 4
        Me.SelectCounter.Text = "10 Απαριθμητές"
        Me.SelectCounter.UseVisualStyleBackColor = True
        '
        'Helpme
        '
        Me.Helpme.Location = New System.Drawing.Point(501, 367)
        Me.Helpme.Name = "Helpme"
        Me.Helpme.Size = New System.Drawing.Size(63, 23)
        Me.Helpme.TabIndex = 11
        Me.Helpme.Text = "Βοήθεια"
        Me.Helpme.UseVisualStyleBackColor = True
        '
        'ParameterEditBox
        '
        Me.ParameterEditBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ParameterEditBox.Location = New System.Drawing.Point(15, 321)
        Me.ParameterEditBox.Name = "ParameterEditBox"
        Me.ParameterEditBox.Size = New System.Drawing.Size(129, 29)
        Me.ParameterEditBox.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 305)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(411, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Παράμετρος (Χρόνος ενεργοποίησης (sec) για χρονικά, Πλήθος για απαριθμητές)"
        '
        'CUButton
        '
        Me.CUButton.Location = New System.Drawing.Point(406, 61)
        Me.CUButton.Name = "CUButton"
        Me.CUButton.Size = New System.Drawing.Size(70, 38)
        Me.CUButton.TabIndex = 25
        Me.CUButton.Text = "Πρόσθεση Count Up"
        Me.CUButton.UseVisualStyleBackColor = True
        '
        'CDButton
        '
        Me.CDButton.Location = New System.Drawing.Point(482, 61)
        Me.CDButton.Name = "CDButton"
        Me.CDButton.Size = New System.Drawing.Size(82, 38)
        Me.CDButton.TabIndex = 26
        Me.CDButton.Text = "Αφαίρεση Count Down"
        Me.CDButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 24)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "="
        '
        'PLC_Set_Equations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 399)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CDButton)
        Me.Controls.Add(Me.CUButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ParameterEditBox)
        Me.Controls.Add(Me.Helpme)
        Me.Controls.Add(Me.SelectCounter)
        Me.Controls.Add(Me.SelectToff)
        Me.Controls.Add(Me.SelectTON)
        Me.Controls.Add(Me.SelectMemory)
        Me.Controls.Add(Me.SelectOutputs)
        Me.Controls.Add(Me.SelectedOutputLabel)
        Me.Controls.Add(Me.CheckAndChange)
        Me.Controls.Add(Me.Discard_All)
        Me.Controls.Add(Me.Save_And_Exit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TitleofList)
        Me.Controls.Add(Me.EquationEditBox)
        Me.Controls.Add(Me.ListOfEquations)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PLC_Set_Equations"
        Me.Text = "Ορισμός λογικών εξισώσεων προγραμματιζόμενου λογικού ελεγκτή"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListOfEquations As System.Windows.Forms.ListBox
    Friend WithEvents EquationEditBox As System.Windows.Forms.TextBox
    Friend WithEvents TitleofList As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Save_And_Exit As System.Windows.Forms.Button
    Friend WithEvents Discard_All As System.Windows.Forms.Button
    Friend WithEvents CheckAndChange As System.Windows.Forms.Button
    Friend WithEvents SelectedOutputLabel As System.Windows.Forms.Label
    Friend WithEvents SelectOutputs As System.Windows.Forms.Button
    Friend WithEvents SelectMemory As System.Windows.Forms.Button
    Friend WithEvents SelectTON As System.Windows.Forms.Button
    Friend WithEvents SelectToff As System.Windows.Forms.Button
    Friend WithEvents SelectCounter As System.Windows.Forms.Button
    Friend WithEvents Helpme As System.Windows.Forms.Button
    Friend WithEvents ParameterEditBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CUButton As System.Windows.Forms.Button
    Friend WithEvents CDButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
