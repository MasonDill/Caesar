<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.rtxtbxInput = New System.Windows.Forms.RichTextBox()
        Me.nudShift = New System.Windows.Forms.NumericUpDown()
        Me.btnClear = New System.Windows.Forms.Button()
        CType(Me.nudShift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDecrypt
        '
        Me.btnDecrypt.Location = New System.Drawing.Point(318, 181)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnDecrypt.TabIndex = 2
        Me.btnDecrypt.Text = "Decrpyt"
        Me.btnDecrypt.UseVisualStyleBackColor = True
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(472, 181)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnEncrypt.TabIndex = 1
        Me.btnEncrypt.Text = "Encypt"
        Me.btnEncrypt.UseVisualStyleBackColor = True
        '
        'rtxtbxInput
        '
        Me.rtxtbxInput.Location = New System.Drawing.Point(318, 65)
        Me.rtxtbxInput.Name = "rtxtbxInput"
        Me.rtxtbxInput.Size = New System.Drawing.Size(229, 96)
        Me.rtxtbxInput.TabIndex = 0
        Me.rtxtbxInput.Text = ""
        '
        'nudShift
        '
        Me.nudShift.Location = New System.Drawing.Point(427, 39)
        Me.nudShift.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.nudShift.Name = "nudShift"
        Me.nudShift.Size = New System.Drawing.Size(120, 20)
        Me.nudShift.TabIndex = 4
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(553, 101)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 35)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 348)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.nudShift)
        Me.Controls.Add(Me.rtxtbxInput)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.btnDecrypt)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.nudShift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDecrypt As System.Windows.Forms.Button
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents rtxtbxInput As System.Windows.Forms.RichTextBox
    Friend WithEvents nudShift As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class
