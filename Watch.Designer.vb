<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Watch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Watch))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StepNumber = New System.Windows.Forms.Label()
        Me.Keys = New System.Windows.Forms.ListBox()
        Me.information = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PauseOnError = New System.Windows.Forms.CheckBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.PauseOnGroundingError = New System.Windows.Forms.CheckBox()
        Me.showinfo = New System.Windows.Forms.CheckBox()
        Me.showkeys = New System.Windows.Forms.CheckBox()
        Me.Show_Voltage = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Βήμα προσομοίωσης:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(277, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Κατάσταση εξαρτημάτων και διαθέσιμες λειτουργίες"
        '
        'StepNumber
        '
        Me.StepNumber.AutoSize = True
        Me.StepNumber.Location = New System.Drawing.Point(129, 60)
        Me.StepNumber.Name = "StepNumber"
        Me.StepNumber.Size = New System.Drawing.Size(10, 13)
        Me.StepNumber.TabIndex = 4
        Me.StepNumber.Text = "-"
        '
        'Keys
        '
        Me.Keys.FormattingEnabled = True
        Me.Keys.HorizontalScrollbar = True
        Me.Keys.Location = New System.Drawing.Point(15, 106)
        Me.Keys.Name = "Keys"
        Me.Keys.Size = New System.Drawing.Size(345, 433)
        Me.Keys.TabIndex = 5
        '
        'information
        '
        Me.information.Location = New System.Drawing.Point(16, 563)
        Me.information.Multiline = True
        Me.information.Name = "information"
        Me.information.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.information.Size = New System.Drawing.Size(345, 162)
        Me.information.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 548)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Πληροφορίες"
        '
        'PauseOnError
        '
        Me.PauseOnError.AutoSize = True
        Me.PauseOnError.Location = New System.Drawing.Point(199, 52)
        Me.PauseOnError.Name = "PauseOnError"
        Me.PauseOnError.Size = New System.Drawing.Size(145, 17)
        Me.PauseOnError.TabIndex = 8
        Me.PauseOnError.Text = "Παύση σε κάθε σφάλμα"
        Me.PauseOnError.UseVisualStyleBackColor = True
        Me.PauseOnError.Visible = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(372, 739)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 16
        Me.LineShape1.X2 = 355
        Me.LineShape1.Y1 = 55
        Me.LineShape1.Y2 = 55
        '
        'PauseOnGroundingError
        '
        Me.PauseOnGroundingError.AutoSize = True
        Me.PauseOnGroundingError.Location = New System.Drawing.Point(197, 65)
        Me.PauseOnGroundingError.Name = "PauseOnGroundingError"
        Me.PauseOnGroundingError.Size = New System.Drawing.Size(163, 17)
        Me.PauseOnGroundingError.TabIndex = 10
        Me.PauseOnGroundingError.Text = "Παύση σε σφάλμα γείωσης"
        Me.PauseOnGroundingError.UseVisualStyleBackColor = True
        Me.PauseOnGroundingError.Visible = False
        '
        'showinfo
        '
        Me.showinfo.AutoSize = True
        Me.showinfo.Checked = True
        Me.showinfo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showinfo.Location = New System.Drawing.Point(16, 12)
        Me.showinfo.Name = "showinfo"
        Me.showinfo.Size = New System.Drawing.Size(120, 17)
        Me.showinfo.TabIndex = 11
        Me.showinfo.Text = "Προβολή ονόματος"
        Me.showinfo.UseVisualStyleBackColor = True
        '
        'showkeys
        '
        Me.showkeys.AutoSize = True
        Me.showkeys.Checked = True
        Me.showkeys.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showkeys.Location = New System.Drawing.Point(16, 35)
        Me.showkeys.Name = "showkeys"
        Me.showkeys.Size = New System.Drawing.Size(119, 17)
        Me.showkeys.TabIndex = 12
        Me.showkeys.Text = "Προβολή πλήκτρων"
        Me.showkeys.UseVisualStyleBackColor = True
        '
        'Show_Voltage
        '
        Me.Show_Voltage.AutoSize = True
        Me.Show_Voltage.Location = New System.Drawing.Point(253, 12)
        Me.Show_Voltage.Name = "Show_Voltage"
        Me.Show_Voltage.Size = New System.Drawing.Size(103, 17)
        Me.Show_Voltage.TabIndex = 13
        Me.Show_Voltage.Text = "Προβολή τάσης"
        Me.Show_Voltage.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 20000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Βοήθεια:"
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 17
        Me.LineShape2.X2 = 356
        Me.LineShape2.Y1 = 81
        Me.LineShape2.Y2 = 81
        '
        'Watch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 739)
        Me.ControlBox = False
        Me.Controls.Add(Me.Show_Voltage)
        Me.Controls.Add(Me.showkeys)
        Me.Controls.Add(Me.showinfo)
        Me.Controls.Add(Me.PauseOnGroundingError)
        Me.Controls.Add(Me.PauseOnError)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.information)
        Me.Controls.Add(Me.Keys)
        Me.Controls.Add(Me.StepNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Watch"
        Me.Text = "Παρακολούθηση προσομοίωσης"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StepNumber As System.Windows.Forms.Label
    Friend WithEvents Keys As System.Windows.Forms.ListBox
    Friend WithEvents information As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PauseOnError As System.Windows.Forms.CheckBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents PauseOnGroundingError As System.Windows.Forms.CheckBox
    Friend WithEvents showinfo As System.Windows.Forms.CheckBox
    Friend WithEvents showkeys As System.Windows.Forms.CheckBox
    Friend WithEvents Show_Voltage As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
