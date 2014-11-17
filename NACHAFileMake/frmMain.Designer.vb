<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dtpCollection = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDisbursement = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMake = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbToClient = New System.Windows.Forms.RadioButton()
        Me.rbToVendor = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnlineDocumentationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtBatchNote = New System.Windows.Forms.TextBox()
        Me.lbl_BatchNote = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(11, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(76, 20)
        Me.TextBox1.TabIndex = 0
        '
        'dtpCollection
        '
        Me.dtpCollection.Checked = False
        Me.dtpCollection.Enabled = False
        Me.dtpCollection.Location = New System.Drawing.Point(11, 147)
        Me.dtpCollection.Name = "dtpCollection"
        Me.dtpCollection.Size = New System.Drawing.Size(200, 20)
        Me.dtpCollection.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dtpCollection, "The date for deposit into clearing house account.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Group #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Clearinghouse Collection Date"
        '
        'dtpDisbursement
        '
        Me.dtpDisbursement.Checked = False
        Me.dtpDisbursement.Enabled = False
        Me.dtpDisbursement.Location = New System.Drawing.Point(11, 186)
        Me.dtpDisbursement.Name = "dtpDisbursement"
        Me.dtpDisbursement.Size = New System.Drawing.Size(200, 20)
        Me.dtpDisbursement.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.dtpDisbursement, "The date for disbursement to vendor or client account.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Clearinghouse Disbursement Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Group Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(88, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "My_Company"
        '
        'btnMake
        '
        Me.btnMake.Enabled = False
        Me.btnMake.Location = New System.Drawing.Point(217, 144)
        Me.btnMake.Name = "btnMake"
        Me.btnMake.Size = New System.Drawing.Size(76, 62)
        Me.btnMake.TabIndex = 8
        Me.btnMake.Text = "Make"
        Me.btnMake.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "$ Amount"
        '
        'rbToClient
        '
        Me.rbToClient.AutoSize = True
        Me.rbToClient.Checked = True
        Me.rbToClient.Enabled = False
        Me.rbToClient.Location = New System.Drawing.Point(95, 109)
        Me.rbToClient.Name = "rbToClient"
        Me.rbToClient.Size = New System.Drawing.Size(51, 17)
        Me.rbToClient.TabIndex = 12
        Me.rbToClient.TabStop = True
        Me.rbToClient.Text = "Client"
        Me.rbToClient.UseVisualStyleBackColor = True
        '
        'rbToVendor
        '
        Me.rbToVendor.AutoSize = True
        Me.rbToVendor.Enabled = False
        Me.rbToVendor.Location = New System.Drawing.Point(152, 109)
        Me.rbToVendor.Name = "rbToVendor"
        Me.rbToVendor.Size = New System.Drawing.Size(59, 17)
        Me.rbToVendor.TabIndex = 13
        Me.rbToVendor.Text = "Vendor"
        Me.rbToVendor.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(305, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditInputToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditInputToolStripMenuItem
        '
        Me.EditInputToolStripMenuItem.Name = "EditInputToolStripMenuItem"
        Me.EditInputToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditInputToolStripMenuItem.Text = "Edit Input"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SettingsToolStripMenuItem.Text = "Configuration"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnlineDocumentationToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.HelpToolStripMenuItem.Text = "Help?"
        '
        'OnlineDocumentationToolStripMenuItem
        '
        Me.OnlineDocumentationToolStripMenuItem.Name = "OnlineDocumentationToolStripMenuItem"
        Me.OnlineDocumentationToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OnlineDocumentationToolStripMenuItem.Text = "Online Documentation"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 248)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(305, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "status"
        '
        'txtBatchNote
        '
        Me.txtBatchNote.Enabled = False
        Me.txtBatchNote.Location = New System.Drawing.Point(12, 225)
        Me.txtBatchNote.Name = "txtBatchNote"
        Me.txtBatchNote.Size = New System.Drawing.Size(282, 20)
        Me.txtBatchNote.TabIndex = 16
        '
        'lbl_BatchNote
        '
        Me.lbl_BatchNote.AutoSize = True
        Me.lbl_BatchNote.Location = New System.Drawing.Point(8, 209)
        Me.lbl_BatchNote.Name = "lbl_BatchNote"
        Me.lbl_BatchNote.Size = New System.Drawing.Size(61, 13)
        Me.lbl_BatchNote.TabIndex = 17
        Me.lbl_BatchNote.Text = "Batch Note"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(92, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Disburse To:"
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(93, 43)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(32, 23)
        Me.btnGo.TabIndex = 19
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Enabled = False
        Me.txtAmount.Location = New System.Drawing.Point(11, 108)
        Me.txtAmount.MaxLength = 11
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(76, 20)
        Me.txtAmount.TabIndex = 20
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 270)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_BatchNote)
        Me.Controls.Add(Me.txtBatchNote)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rbToVendor)
        Me.Controls.Add(Me.rbToClient)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnMake)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpDisbursement)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpCollection)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "NACHA File Make"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dtpCollection As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDisbursement As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnMake As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbToClient As System.Windows.Forms.RadioButton
    Friend WithEvents rbToVendor As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditInputToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnlineDocumentationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBatchNote As System.Windows.Forms.TextBox
    Friend WithEvents lbl_BatchNote As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox

End Class
