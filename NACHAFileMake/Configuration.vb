
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
        ' populate window fields with values from configuration object
    End Sub

    ''' <summary>
    ''' Check that all the values have been entered. If so, populate output and exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            checkFormInputs()

            main.populateOutput(config)
            Dim wk As New WorkerClass
            wk.serializeConfig(config)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Confirm that values have been entered before closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmConfiguration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' make sure that values have been entered before closing
        Try
            checkFormInputs()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            e.Cancel = True
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub checkFormInputs()
        If Not String.IsNullOrWhiteSpace(txtCompanyName.Text) Then
            config.immediateOrigName = txtCompanyName.Text
        Else
            Throw New Exception("Company Name Value is Required.")
        End If

        If Not String.IsNullOrWhiteSpace(txtTaxID.Text) Then
            config.immediateOrig = txtTaxID.Text
        Else
            Throw New Exception("Tax ID Value is Required.")
        End If

        If Not String.IsNullOrWhiteSpace(txtFinancialInstName.Text) Then
            config.immediateDestName = txtFinancialInstName.Text
        Else
            Throw New Exception("Financial Institution Name Value is Required.")
        End If

        If Not String.IsNullOrWhiteSpace(txtFinancialInstRouting.Text) Then
            config.immediateDest = txtFinancialInstRouting.Text
        Else
            Throw New Exception("Financial Institution Routing Value is Required.")
        End If

        If Not String.IsNullOrWhiteSpace(txtTransDesc.Text) Then
            config.companyEntryDesc = txtTransDesc.Text
        Else
            Throw New Exception("Transaction Description Value is Required")
        End If
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