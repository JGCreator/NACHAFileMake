<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguration
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTaxID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFinancialInstName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFinancialInstRouting = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTransDesc = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Name"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(15, 25)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(100, 20)
        Me.txtCompanyName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tax ID"
        '
        'txtTaxID
        '
        Me.txtTaxID.Location = New System.Drawing.Point(15, 64)
        Me.txtTaxID.Name = "txtTaxID"
        Me.txtTaxID.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxID.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Financial Institution Name"
        '
        'txtFinancialInstName
        '
        Me.txtFinancialInstName.Location = New System.Drawing.Point(15, 103)
        Me.txtFinancialInstName.Name = "txtFinancialInstName"
        Me.txtFinancialInstName.Size = New System.Drawing.Size(156, 20)
        Me.txtFinancialInstName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Financial Institution Routing"
        '
        'txtFinancialInstRouting
        '
        Me.txtFinancialInstRouting.Location = New System.Drawing.Point(15, 142)
        Me.txtFinancialInstRouting.Name = "txtFinancialInstRouting"
        Me.txtFinancialInstRouting.Size = New System.Drawing.Size(156, 20)
        Me.txtFinancialInstRouting.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Transaction Desc."
        '
        'txtTransDesc
        '
        Me.txtTransDesc.Location = New System.Drawing.Point(15, 181)
        Me.txtTransDesc.Name = "txtTransDesc"
        Me.txtTransDesc.Size = New System.Drawing.Size(115, 20)
        Me.txtTransDesc.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(136, 179)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Done"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 212)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtTransDesc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFinancialInstRouting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFinancialInstName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTaxID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCompanyName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Configuration"
        Me.Text = "Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFinancialInstName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFinancialInstRouting As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTransDesc As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
