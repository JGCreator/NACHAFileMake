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

#Region "Methods"
    'Public Sub New(ByVal config As Configuration, ByVal exModel As ExcelInput_Model)
    '    InitializeComponent()
    '    'Me.config = config
    '    'Me.ex_model = exModel
    'End Sub


    Private Sub sub_group_search(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave

        Dim file_values As RowValues = ex_model.find_group(TextBox1.Text)
        Label5.Text = file_values.str_group_name




        ' set what can be set in the RecordDefs class
        ' deserialize the settings .xml file
        ' set what can be set from the settings file



        ' open the registry key for the file path
        '   if the key doesn't exist open excel

        ' try to open the file
        '   if the file doesn't exist open excel

        ' use find to locate the group number entered
        '   if the group number wasn't found tell the user and ask to add it
        '      if yes to add, show excel 

        ' create new record objects and populate with excel data

    End Sub

    Private Sub mnuEdit_Clicked(sender As System.Object, e As System.EventArgs) Handles EditInputToolStripMenuItem.Click
        ' open reg key
        'Dim f As String = worker.open_reg()

        ' check if there is currently information being entered for a file,
        ' if so make sure the user wants to continue because the fields and records will be initialized
        ex_model.edit_input()

    End Sub

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

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        worker = New WorkerClass

        ' get a configuration object
        config = worker.deserializeConfig()
        If config Is Nothing Then
            frmconfig = New frmConfiguration(Me)
            frmconfig.Show()
        Else
            populateOutput(Me.config)
        End If



        Dim file_path As String
        Try
            file_path = worker.open_reg()
            ex_model = New ExcelInput_Model(file_path)
        Catch ex As Exception
            ex_model = New ExcelInput_Model()
            worker.create_set_key(ex_model.file_location)
        End Try

    End Sub

    Public Sub populateOutput(ByVal config As Configuration)
        ' create object of RecordDefs
        output = New NACHAout
        output.fHeader.immediate_Destination = config.ImmediateDestination
        output.fHeader.bank_Name = config.ImmediateDestinationName
        output.fHeader.immediate_Origin = config.ImmediateOrigin
        output.fHeader.company_Name = config.ImmediateOriginName
        output.fHeader.file_ID = "A"

        output.bWithdrawHeader.company_Name = config.ImmediateOriginName
        output.bWithdrawHeader.company_ID = config.ImmediateOrigin
        output.bWithdrawHeader.entry_desc = config.CompanyEntryDescription
        output.bWithdrawHeader.orig_financialInst = config.ImmediateDestination
        output.bWithdrawHeader.service_Code = "225"
        output.bWithdrawHeader.batch_number = "1"

        output.bDepositHeader.company_Name = config.ImmediateOriginName
        output.bDepositHeader.company_ID = config.ImmediateOrigin
        output.bDepositHeader.entry_desc = config.CompanyEntryDescription
        output.bDepositHeader.orig_financialInst = config.ImmediateDestination
        output.bDepositHeader.service_Code = "220"
        output.bDepositHeader.batch_number = "2"

        output.bWithdrawControl.company_ID = config.ImmediateOrigin
        output.bWithdrawControl.batch_number = "1"
        output.bWithdrawControl.entry_count = "1"
        output.bWithdrawControl.originating_financial_ID = config.ImmediateDestination
        output.bWithdrawControl.service_class = "225"

        output.bDepositControl.company_ID = config.ImmediateOrigin
        output.bDepositControl.batch_number = "2"
        output.bDepositControl.entry_count = "1"
        output.bDepositControl.originating_financial_ID = config.ImmediateDestination
        output.bDepositControl.service_class = "220"
    End Sub

    Private Sub TextBox2_Leave(sender As System.Object, e As System.EventArgs) Handles TextBox2.Leave
        ' validate the value in the amount field and then add it to the RecordDefs object

    End Sub

    Public Sub serializeConfig(ByVal config As frmConfiguration)
        Using fs As New FileStream(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles & "\NACHAMake\config.bin"), FileMode.OpenOrCreate, FileAccess.Write)
            ' Creat binary object
            Dim bf As New BinaryFormatter()

            ' Serialize object to file
            bf.Serialize(fs, config)
        End Using

    End Sub

    'Public Function deserializeConfig() As Configuration
    '    Try
    '        Dim progFiles As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles)
    '        If Not Directory.Exists(progFiles & "\NACHAMake") Then Directory.CreateDirectory(progFiles & "\NACHAMake")
    '        Using fs As New FileStream(progFiles & "\NACHAMake\config.bin", FileMode.OpenOrCreate, FileAccess.Read)
    '            ' Creat binary object
    '            Dim bf As New BinaryFormatter()

    '            ' Serialize object to file
    '            Return CType(bf.Deserialize(fs), Configuration)
    '        End Using
    '    Catch serial_ex As Runtime.Serialization.SerializationException
    '        Return Nothing
    '    Catch ex As Exception
    '        MessageBox.Show("An unexpected exception occurred while trying to deserialize the configuration file: " & ex.Message)
    '        ' write to log
    '        Throw ex
    '    End Try

    'End Function

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click

    End Sub
End Class





Public Class NACHAout

#Region "Instance Variables"
    Dim records() As FileRec

    Friend fHeader As FileHeader
    Friend fControl As FileControl
    Friend bWithdrawHeader As BatchHeader
    Friend bWithdrawControl As BatchControl
    Friend bWithdrawDetail As BatchDetail
    Friend bDepositHeader As BatchHeader
    Friend bDepositControl As BatchControl
    Friend bDepositDetail As BatchDetail

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
    End Sub

    Public Sub saveOutput(ByVal fname As String)
        ' write records to fname file
    End Sub
#End Region

End Class

Public Structure OutputStruct
    
End Structure

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
