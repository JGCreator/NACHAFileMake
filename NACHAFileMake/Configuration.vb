
Public Class frmConfiguration
    Private main As frmMain
    Private config As Configuration

    Public Sub New(ByVal main As frmMain, Optional ByRef config As Configuration = Nothing)
        InitializeComponent()
        Me.main = main
        Me.BringToFront()
        If config IsNot Nothing Then
            Me.config = config
        Else
            Me.config = New Configuration
        End If

    End Sub

    Private Sub Configuration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        config.immediateDest = txtFinancialInstRouting.Text
        config.immediateDestName = txtFinancialInstName.Text
        config.immediateOrig = txtTaxID.Text
        config.immediateOrigName = txtCompanyName.Text
        config.companyEntryDesc = txtTransDesc.Text
        main.populateOutput(config)
        Dim wk As New WorkerClass
        wk.serializeConfig(config)
        Me.Close()
    End Sub
End Class

<System.Serializable()>
Public Class Configuration
    ' financial institution routing
    Friend immediateDest As String
    ''' <summary>
    ''' The financial institution routing number of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImmediateDestination As String
        Get
            Return immediateDest
        End Get
    End Property

    ' company tax ID
    Friend immediateOrig As String
    ''' <summary>
    ''' The 10 digit tax ID number of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImmediateOrigin As String
        Get
            Return immediateOrig
        End Get
    End Property

    ' financial institution name
    Friend immediateDestName As String
    ''' <summary>
    ''' Financial institution name of the company producing the NACHA file 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImmediateDestinationName As String
        Get
            Return immediateDestName
        End Get
    End Property

    ' company name
    Friend immediateOrigName As String
    ''' <summary>
    ''' Company name producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImmediateOriginName As String
        Get
            Return immediateOrigName
        End Get
    End Property

    ' company entry description
    Friend companyEntryDesc As String
    ''' <summary>
    ''' A user defined, 10 digit description of the transaction. ex. Payroll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CompanyEntryDescription As String
        Get
            Return companyEntryDesc
        End Get
    End Property
End Class