#Region "Imports"
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop
Imports System.Runtime.Serialization.Formatters.Binary
#End Region

#Region "Classes"

Public Class frmMain

    Dim worker As WorkerClass
    Dim ex_model As ExcelInput_Model

    'Dim fheader As New FileHeader
    'Dim bheader As New BatchHeader
    'Dim bdetail As New BatchDetail
    'Dim bcontrol As New BatchControl
    'Dim fcontrol As New FileControl
    Dim frmconfig As frmConfiguration
    Dim config As Configuration
    Dim output As NACHAout
    Dim file_values As RowValues
    Dim file_path As String

#Region "Methods"

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        worker = New WorkerClass
        Try
            Try
                file_path = worker.open_reg()
                ex_model = New ExcelInput_Model(file_path)
            Catch ex As Exception
                ex_model = New ExcelInput_Model()
                worker.create_set_key(ex_model.file_location)
            End Try
        Catch ex As Exception
            MessageBox.Show(String.Format("[frmMain_Load] {0} :: {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    'Public Sub New(ByVal config As Configuration, ByVal exModel As ExcelInput_Model)
    '    InitializeComponent()
    '    'Me.config = config
    '    'Me.ex_model = exModel
    'End Sub


    Private Sub sub_group_search(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            ' get a configuration object
            config = worker.deserializeConfig()
            If config Is Nothing Then
                frmconfig = New frmConfiguration(Me)
                frmconfig.ShowDialog()
                Exit Sub
            Else
                populateOutput(Me.config)
            End If

            file_values = ex_model.find_group(TextBox1.Text)
            If Not String.IsNullOrWhiteSpace(file_values.str_group_name) Then
                Label5.Text = file_values.str_group_name
                enableForm()
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("[group_search] {0} :: {1}", ex.Message, ex.StackTrace))
        End Try

    End Sub

    Private Sub mnuEdit_Clicked(sender As System.Object, e As System.EventArgs) Handles EditInputToolStripMenuItem.Click
        Try
            ' check if there is currently information being entered for a file,
            ' if so make sure the user wants to continue because the fields and records will be initialized
            ex_model.edit_input()
            ex_model.parentFormClosing()
            ex_model = New ExcelInput_Model(file_path)
        Catch ex As Exception
            MessageBox.Show(String.Format("[mnuEdit_Clicked] {0} :: {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    ''' <summary>
    ''' Create and populate a NACHAout object with values from the configuration object
    ''' </summary>
    ''' <param name="config"></param>
    ''' <remarks></remarks>
    Public Sub populateOutput(ByVal config As Configuration)

        ' create object of RecordDefs
        output = New NACHAout
        output.fHeader.immediate_Destination = config.ImmediateDestination
        output.fHeader.bank_Name = config.ImmediateDestinationName
        output.fHeader.immediate_Origin = config.ImmediateOrigin
        output.fHeader.company_Name = config.ImmediateOriginName
        output.fHeader.file_ID = "A"

        output.bDepositHeader.company_Name = config.ImmediateOriginName
        output.bDepositHeader.company_ID = config.ImmediateOrigin

        output.bDepositHeader.orig_financialInst = config.ImmediateDestination
        output.bDepositHeader.service_Code = "220"
        output.bDepositHeader.batch_number = "2"
        output.bDepositControl.company_ID = config.ImmediateOrigin
        output.bDepositControl.batch_number = "2"
        output.bDepositControl.entry_count = "1"
        output.bDepositControl.originating_financial_ID = config.ImmediateDestination
        output.bDepositControl.service_class = "220"

        output.bWithdrawHeader.company_Name = config.ImmediateOriginName
        output.bWithdrawHeader.company_ID = config.ImmediateOrigin
        output.bWithdrawHeader.orig_financialInst = config.ImmediateDestination
        output.bWithdrawHeader.service_Code = "225"
        output.bWithdrawHeader.batch_number = "1"

        output.bWithdrawControl.company_ID = config.ImmediateOrigin
        output.bWithdrawControl.batch_number = "1"
        output.bWithdrawControl.entry_count = "1"
        output.bWithdrawControl.originating_financial_ID = config.ImmediateDestination
        output.bWithdrawControl.service_class = "225"

        output.fControl.batch_count = "2"
        output.fControl.block_count = "1"
        output.fControl.entry_count = "2"

    End Sub

    Public Sub serializeConfig(ByVal config As frmConfiguration)
        Using fs As New FileStream(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles & "\NACHAMake\config.bin"), FileMode.OpenOrCreate, FileAccess.Write)
            ' Creat binary object
            Dim bf As New BinaryFormatter()

            ' Serialize object to file
            bf.Serialize(fs, config)
        End Using

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        ' create a new frmConfiguration object and open it
        Dim frmConfig As New frmConfiguration(Me, config)
        frmConfig.ShowDialog()
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then 'AndAlso Not e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub enableForm()
        txtAmount.Enabled = True
        txtBatchNote.Enabled = True
        rbToClient.Enabled = True
        rbToVendor.Enabled = True
        btnMake.Enabled = True
        dtpCollection.Enabled = True
        dtpDisbursement.Enabled = True
    End Sub

    Private Sub disableForm()
        txtAmount.Enabled = False
        txtBatchNote.Enabled = False
        rbToClient.Enabled = False
        rbToVendor.Enabled = False
        btnMake.Enabled = False
        dtpCollection.Enabled = False
        dtpDisbursement.Enabled = False
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ex_model.parentFormClosing()
        Catch ex As Exception
            MessageBox.Show(String.Format("[FormClosing] {0} :: {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Sub btnMake_Click(sender As Object, e As EventArgs) Handles btnMake.Click
        ' check that all the window values are filled in
        Try
            If rbToVendor.Checked Then

                ' populate the deposit detail record
                output.bDepositDetail.amount = txtAmount.Text.Replace(".", "")
                output.bDepositDetail.check_digit = file_values.str_vendor_fund_rout.Substring(8, 1)
                output.bDepositDetail.individual_ID = ""
                output.bDepositDetail.individual_name = file_values.str_vendor_name
                output.bDepositDetail.receiver_acct = file_values.str_vendor_fund_acct
                output.bDepositDetail.receiver_routing = file_values.str_vendor_fund_rout
                output.bDepositDetail.transaction_code = "22"
                output.bDepositDetail.trace_number = file_values.str_vendor_fund_rout.PadRight(14, "0") & "1"

                ' finish the deposit control record
                ' output.bDepositControl.entry_hash = getEntryHash(file_values.str_vendor_fund_rout)
                output.bDepositControl.entry_hash = file_values.str_vendor_fund_rout.Substring(0, 8)
                output.bDepositControl.tot_credit_amount = 0
                output.bDepositControl.tot_debit_amount = txtAmount.Text.Replace(".", "")

                ' populate the withdraw detail record
                output.bWithdrawDetail.amount = txtAmount.Text.Replace(".", "")
                output.bWithdrawDetail.check_digit = file_values.str_group_rout.Substring(8, 1)
                output.bWithdrawDetail.individual_ID = ""
                output.bWithdrawDetail.individual_name = file_values.str_group_name
                output.bWithdrawDetail.receiver_acct = file_values.str_group_acct
                output.bWithdrawDetail.receiver_routing = file_values.str_group_rout
                output.bWithdrawDetail.transaction_code = "27"
                output.bWithdrawDetail.trace_number = file_values.str_group_rout.PadRight(14, "0") & "1"

                ' finish the withdraw control record
                ' output.bWithdrawControl.entry_hash = getEntryHash(file_values.str_group_rout)
                output.bWithdrawControl.entry_hash = file_values.str_group_rout.Substring(0, 8)
                output.bWithdrawControl.tot_credit_amount = txtAmount.Text.Replace(".", "")
                output.bWithdrawControl.tot_debit_amount = 0

            Else

                ' populate the deposit detail record
                output.bDepositDetail.amount = txtAmount.Text.Replace(".", "")
                output.bDepositDetail.check_digit = file_values.str_group_rout.Substring(8, 1)
                output.bDepositDetail.individual_ID = " "
                output.bDepositDetail.individual_name = file_values.str_group_name
                output.bDepositDetail.receiver_acct = file_values.str_group_acct
                output.bDepositDetail.receiver_routing = file_values.str_group_rout
                output.bDepositDetail.transaction_code = "22"
                output.bDepositDetail.trace_number = file_values.str_group_rout.PadRight(14, "0") & "1"

                ' finish the deposit control record
                'output.bDepositControl.entry_hash = getEntryHash(file_values.str_group_rout)
                output.bDepositControl.entry_hash = file_values.str_group_rout.Substring(0, 8)
                output.bDepositControl.tot_credit_amount = 0
                output.bDepositControl.tot_debit_amount = txtAmount.Text.Replace(".", "")

                ' populate the withdraw detail record
                output.bWithdrawDetail.amount = txtAmount.Text.Replace(".", "")
                output.bWithdrawDetail.check_digit = file_values.str_vendor_dist_rout.Substring(8, 1)
                output.bWithdrawDetail.individual_ID = " "
                output.bWithdrawDetail.individual_name = file_values.str_vendor_name
                output.bWithdrawDetail.receiver_acct = file_values.str_vendor_dist_acct
                output.bWithdrawDetail.receiver_routing = file_values.str_vendor_dist_rout
                output.bWithdrawDetail.transaction_code = "27"
                output.bWithdrawDetail.trace_number = file_values.str_vendor_dist_rout.PadRight(14, "0") & "1"

                ' finish the withdraw control record
                'output.bWithdrawControl.entry_hash = getEntryHash(file_values.str_group_rout)
                output.bWithdrawControl.entry_hash = file_values.str_vendor_dist_rout.Substring(0, 8)
                output.bWithdrawControl.tot_credit_amount = txtAmount.Text.Replace(".", "")
                output.bWithdrawControl.tot_debit_amount = 0

            End If

            ' finish the deposit header record
            output.bDepositHeader.effective_date = dtpDisbursement.Value
            output.bDepositHeader.user_data = txtBatchNote.Text
            output.bDepositHeader.entry_desc = txtEntryDescription.Text

            ' finish the withdraw header record
            output.bWithdrawHeader.effective_date = dtpCollection.Value
            output.bWithdrawHeader.user_data = txtBatchNote.Text
            output.bWithdrawHeader.entry_desc = txtEntryDescription.Text

            ' finish the file control record
            output.fControl.entry_hash = CInt(output.bDepositControl.entry_hash) + CInt(output.bWithdrawControl.entry_hash)
            output.fControl.tot_credit_amount = txtAmount.Text.Replace(".", "")
            output.fControl.tot_debit_amount = txtAmount.Text.Replace(".", "")

            ' select output file name
            Dim svDialog As New SaveFileDialog
            Dim dlogResult As DialogResult = svDialog.ShowDialog
            Dim outFileName As String = Nothing

            While 1 = 1
                If dlogResult = Windows.Forms.DialogResult.OK Then
                    Using sw As New StreamWriter(New FileStream(svDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                        sw.WriteLine(output.fHeader.ToString)
                        sw.WriteLine(output.bWithdrawHeader.ToString)
                        sw.WriteLine(output.bWithdrawDetail.ToString)
                        sw.WriteLine(output.bWithdrawControl.ToString)
                        sw.WriteLine(output.bDepositHeader.ToString)
                        sw.WriteLine(output.bDepositDetail.ToString)
                        sw.WriteLine(output.bDepositControl.ToString)
                        sw.WriteLine(output.fControl.ToString)
                        sw.WriteLine(output.filler.ToString)
                        sw.WriteLine(output.filler.ToString)
                    End Using
                    Exit While
                Else
                    If MessageBox.Show("Are you sure you don't want to select a file location?", "Are You Sure?",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit While
                    End If
                End If
            End While
        Catch ex As Exception
            MessageBox.Show(String.Format("[btnMake_Clicked] {0} :: {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Function getEntryHash(ByVal ParamArray routs() As String) As Integer
        Dim ret As Integer
        For Each item In routs
            For Each c As Char In item
                ret += Val(c)
            Next
        Next

        Return ret

    End Function

#End Region

    'Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    '    xlApp = New Excel.Application(file)
    '    ' xlBook = xlApp.Workbooks.Open(file)
    '    xlSheet = xlApp.Sheets.Item(0)

    '    Dim xlRange As Excel.Range = xlApp.Range("A")
    '    xlRange = xlRange.Find(TextBox1.Text)

    '    xlRange = xlRange.Rows

    '    Dim fHeader As New FileHeader
    '    ' fHeader.

    'End Sub

End Class

Public Class NACHAout

#Region "Instance Variables"
    Dim records() As FileRec

    Friend fHeader As FileHeader

    Friend bDepositHeader As BatchHeader
    Friend bDepositDetail As BatchDetail
    Friend bDepositControl As BatchControl

    Friend bWithdrawHeader As BatchHeader
    Friend bWithdrawDetail As BatchDetail
    Friend bWithdrawControl As BatchControl

    Friend fControl As FileControl

    Friend filler As BlockFiller
#End Region

#Region "Methods"
    Public Sub New()
        fHeader = New FileHeader
        fControl = New FileControl
        bWithdrawHeader = New BatchHeader
        bWithdrawControl = New BatchControl
        bWithdrawDetail = New BatchDetail
        bDepositHeader = New BatchHeader
        bDepositControl = New BatchControl
        bDepositDetail = New BatchDetail
        bDepositDetail = New BatchDetail
        filler = New BlockFiller
    End Sub

#End Region

End Class

Public Structure RowValues
    Dim int_group_nbr As Integer
    Dim str_group_name As String
    Dim str_group_acct As String
    Dim str_group_rout As String
    Dim str_vendor_name As String
    Dim str_vendor_fund_acct As String
    Dim str_vendor_fund_rout As String
    Dim str_vendor_dist_acct As String
    Dim str_vendor_dist_rout As String
End Structure

#End Region
