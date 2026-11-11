<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PLCWatch
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
        Me.inp = New System.Windows.Forms.ListBox()
        Me.OutPre = New System.Windows.Forms.ListBox()
        Me.timON = New System.Windows.Forms.ListBox()
        Me.Timoff = New System.Windows.Forms.ListBox()
        Me.COUNTER = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mem = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HideMe = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'inp
        '
        Me.inp.FormattingEnabled = True
        Me.inp.Location = New System.Drawing.Point(12, 28)
        Me.inp.Name = "inp"
        Me.inp.Size = New System.Drawing.Size(58, 121)
        Me.inp.TabIndex = 0
        '
        'OutPre
        '
        Me.OutPre.FormattingEnabled = True
        Me.OutPre.Location = New System.Drawing.Point(76, 28)
        Me.OutPre.Name = "OutPre"
        Me.OutPre.Size = New System.Drawing.Size(617, 121)
        Me.OutPre.TabIndex = 3
        '
        'timON
        '
        Me.timON.FormattingEnabled = True
        Me.timON.Location = New System.Drawing.Point(12, 168)
        Me.timON.Name = "timON"
        Me.timON.Size = New System.Drawing.Size(678, 121)
        Me.timON.TabIndex = 4
        '
        'Timoff
        '
        Me.Timoff.FormattingEnabled = True
        Me.Timoff.Location = New System.Drawing.Point(13, 308)
        Me.Timoff.Name = "Timoff"
        Me.Timoff.Size = New System.Drawing.Size(677, 121)
        Me.Timoff.TabIndex = 5
        '
        'COUNTER
        '
        Me.COUNTER.FormattingEnabled = True
        Me.COUNTER.Location = New System.Drawing.Point(12, 448)
        Me.COUNTER.Name = "COUNTER"
        Me.COUNTER.Size = New System.Drawing.Size(681, 121)
        Me.COUNTER.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Είσοδοι Ι"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Κατάσταση Εξόδων Q"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Κατάσταση  Χρονικών Delay On TON"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 292)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(196, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Κατάσταση  Χρονικών Delay Off TOFF"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 432)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Κατάσταση Απαριθμητών C"
        '
        'mem
        '
        Me.mem.FormattingEnabled = True
        Me.mem.Location = New System.Drawing.Point(12, 588)
        Me.mem.Name = "mem"
        Me.mem.Size = New System.Drawing.Size(681, 82)
        Me.mem.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 572)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Κατάσταση Μνημών Μ"
        '
        'HideMe
        '
        Me.HideMe.Location = New System.Drawing.Point(254, 677)
        Me.HideMe.Name = "HideMe"
        Me.HideMe.Size = New System.Drawing.Size(217, 23)
        Me.HideMe.TabIndex = 18
        Me.HideMe.Text = "Απόκρυψη παραθύρου"
        Me.HideMe.UseVisualStyleBackColor = True
        '
        'PLCWatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 712)
        Me.ControlBox = False
        Me.Controls.Add(Me.HideMe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mem)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.COUNTER)
        Me.Controls.Add(Me.Timoff)
        Me.Controls.Add(Me.timON)
        Me.Controls.Add(Me.OutPre)
        Me.Controls.Add(Me.inp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PLCWatch"
        Me.ShowInTaskbar = False
        Me.Text = "PLCWatch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents inp As System.Windows.Forms.ListBox
    Friend WithEvents OutPre As System.Windows.Forms.ListBox
    Friend WithEvents timON As System.Windows.Forms.ListBox
    Friend WithEvents Timoff As System.Windows.Forms.ListBox
    Friend WithEvents COUNTER As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mem As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HideMe As System.Windows.Forms.Button
End Class
