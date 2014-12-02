#Region "Imports"
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
#End Region

Public Class FileRec
    <VBFixedString(1)> Private str_rectype As String
    Public Property rec_type As String
        Get
            Return str_rectype
        End Get
        Set(value As String)
            str_rectype = value
        End Set
    End Property

End Class

Public Class FileHeader
    Inherits FileRec

    Public Sub New()
        ' set the record type
        rec_type = "1"
    End Sub

#Region "Instance Vars"
    Private Const str_PriorityCode As String = "01"
    Private Const str_RecSize As String = "094"
    Private Const str_BlockFactor As String = "10"
    Private Const str_FormatCode As String = "1"
    Private Const str_ReferenceCode As String = "        "
    Private dt_Created As String = System.DateTime.Now.ToString("yyMMdd")
    Private tm_Created As String = System.DateTime.Now.ToString("HHmm")

    Private str_ImmDest As String
    ''' <summary>
    ''' Financial institution routing number of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property immediate_Destination As String
        Get
            Return str_ImmDest
        End Get
        Set(value As String)
            If value.Length = 9 Then
                str_ImmDest = value.PadLeft(10, " ")
            ElseIf (value.Length = 10) And (value.First = " ") Then
                str_ImmDest = value
            Else
                Throw New Exception(String.Format(
                                    "The financial institution routing number (Immediate Destination) is the wrong length." & vbCrLf & "Expected 9 but was {0}.", value.Length))
            End If
        End Set
    End Property

    Private str_ImmOrig As String
    ''' <summary>
    ''' The 10 digit tax ID of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property immediate_Origin As String
        Get
            Return str_ImmOrig
        End Get
        Set(value As String)
            If value.Length = 10 Then
                str_ImmOrig = value
            Else
                Throw New Exception(String.Format("The company tax id (Immediate Origin) is the wrong length." & vbCrLf & "Expected 10 but was {0}", value.Length))
            End If
        End Set
    End Property

    Private str_fileID As String
    ''' <summary>
    ''' An alpha character, starting with 'A' to identify multiple file records in the same output
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property file_ID As String
        Get
            Return str_fileID
        End Get
        Set(value As String)
            str_fileID = value.ToUpper
        End Set
    End Property

    Private str_BankName As String
    ''' <summary>
    ''' The financial institution name of the company producing the NACHA file (Immediate Destination Name)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property bank_Name As String
        Get
            Return str_BankName
        End Get
        Set(value As String)
            str_BankName = value.PadLeft(23, " ")
        End Set
    End Property

    Private str_CoName As String
    ''' <summary>
    ''' The name of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property company_Name As String
        Get
            Return str_CoName
        End Get
        Set(value As String)
            str_CoName = value.PadLeft(23, " ")
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.Append(rec_type)
        sb.Append(str_PriorityCode)
        sb.Append(str_ImmDest)
        sb.Append(str_ImmOrig)
        sb.Append(dt_Created)
        sb.Append(tm_Created)
        sb.Append(str_fileID)
        sb.Append(str_RecSize)
        sb.Append(str_BlockFactor)
        sb.Append(str_FormatCode)
        sb.Append(str_BankName)
        sb.Append(str_CoName)
        sb.Append(str_ReferenceCode)
        Return sb.ToString
    End Function
End Class

Public Class BatchHeader
    Inherits FileRec

    Public Sub New()
        rec_type = "5"
    End Sub

#Region "Instance Vars"
    Private dt_DescDate As String = System.DateTime.Now.ToString("yyMMdd")
    Private str_reserved As String = "   "
    Private str_OrigStatusCode As String = "1"
    Private str_ClassCode As String = "CCD"

    Private int_ServiceCode As Integer
    ''' <summary>
    ''' Identification of entities in this batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property service_Code As Integer
        Get
            Return int_ServiceCode
        End Get
        Set(value As Integer)
            If value.ToString.Length = 3 Then
                int_ServiceCode = value
            Else
                Throw New Exception("Service Class Code is invalid.")
            End If
        End Set
    End Property

    Private str_CompanyName As String
    ''' <summary>
    ''' The name of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property company_Name As String
        Get
            Return str_CompanyName
        End Get
        Set(value As String)
            If value.Length < 16 Then
                str_CompanyName = value.PadRight(16, " ")
            ElseIf value.Length = 16 Then
                str_CompanyName = value
            Else
                str_CompanyName = value.Substring(0, 16)
            End If
        End Set
    End Property

    Private str_UserData As String
    ''' <summary>
    ''' Discretionary data entered by the company producing the NACHA file 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property user_data As String
        Get
            Return str_UserData
        End Get
        Set(value As String)
            str_UserData = value.PadRight(20, " ")
        End Set
    End Property

    Private str_CompanyID As String
    ''' <summary>
    ''' The 10 digit tax ID of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property company_ID As String
        Get
            Return str_CompanyID
        End Get
        Set(value As String)
            If value.Length = 10 Then
                str_CompanyID = value
            Else
                Throw New Exception(String.Format("The Company ID is invalid, because it is the wrong length. Expected 10 but was {0}", value.Length))
            End If
        End Set
    End Property

    Private str_EntryDesc As String
    ''' <summary>
    ''' A description of the entries to be printed on the receivers financial statement
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property entry_desc As String
        Get
            Return str_EntryDesc
        End Get
        Set(value As String)
            str_EntryDesc = value.PadRight(10, " ")
        End Set
    End Property

    Private dt_Effective As Date
    Public Property effective_date As Date
        Get
            Return dt_Effective
        End Get
        Set(value As Date)
            dt_Effective = value
        End Set
    End Property

    Private str_OrigFinancialInst As String
    ''' <summary>
    ''' The routing number of the financial institution of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property orig_financialInst As String
        Get
            Return str_OrigFinancialInst
        End Get
        Set(value As String)
            If value.Length = 9 Then
                str_OrigFinancialInst = value.Substring(0, 8)
            Else
                Throw New Exception(String.Format("The Originating Financial Institution ID is invalid, because it is the wrong length. Expected 9 but was {0}", value.Length))
            End If
        End Set
    End Property

    Private str_BatchNumber As String
    ''' <summary>
    ''' A sequential numbering of the batches in a file record
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property batch_number As String
        Get
            Return str_BatchNumber
        End Get
        Set(value As String)
            If value.Length <= 7 Then
                str_BatchNumber = value.PadLeft(7, "0")
            Else
                str_BatchNumber = value.Substring(value.Length - 8, 7)
            End If
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.Append(rec_type)
        sb.Append(int_ServiceCode)
        sb.Append(str_CompanyName)
        sb.Append(str_UserData)
        sb.Append(str_CompanyID)
        sb.Append(str_ClassCode)
        sb.Append(str_EntryDesc)
        sb.Append(dt_DescDate)
        sb.Append(dt_Effective.ToString("yyMMdd"))
        sb.Append(str_reserved)
        sb.Append(str_OrigStatusCode)
        sb.Append(str_OrigFinancialInst)
        sb.Append(str_BatchNumber)
        Return sb.ToString
    End Function
End Class

Public Class BatchDetail
    Inherits FileRec

    Public Sub New()
        rec_type = "6"
    End Sub

#Region "Instance Vars"

    Private Const int_addenda As Integer = 0

    Private str_TransCode As String
    ''' <summary>
    ''' Two digit code identifying the account type at the receiving financial institution
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property transaction_code As String
        Get
            Return str_TransCode
        End Get
        Set(value As String)
            str_TransCode = value
        End Set
    End Property

    Private str_ReceiverRouting As String
    ''' <summary>
    ''' Transit routing number of the receiver’s financial institution
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property receiver_routing As String
        Get
            Return str_ReceiverRouting
        End Get
        Set(value As String)
            If value.Length = 8 Then
                str_ReceiverRouting = value
            ElseIf value.Length = 9 Then
                str_ReceiverRouting = value.Substring(0, 8)
            Else
                Throw New Exception(String.Format("The value given for Receiver Routing number is an incorrect length. Expected 8 or 9 but was {0}", value.Length))
            End If
        End Set
    End Property

    Private str_CheckDigit As String
    ''' <summary>
    ''' The ninth digits of the receiving financial institutions transit routing number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property check_digit As String
        Get
            Return str_CheckDigit
        End Get
        Set(value As String)
            If value.Length = 1 Then
                str_CheckDigit = value
            Else
                Throw New Exception("The value given for Check Digit is greater than one.")
            End If
        End Set
    End Property

    Private str_ReceiverAcct As String
    ''' <summary>
    ''' Receiver’s account number at their financial institution
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property receiver_acct As String
        Get
            Return str_ReceiverAcct
        End Get
        Set(value As String)
            str_ReceiverAcct = value.PadRight(17, " ")
        End Set
    End Property

    Private str_Amount As String
    ''' <summary>
    ''' Transaction amount in dollars
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property amount As String
        Get
            Return str_Amount
        End Get
        Set(value As String)
                str_Amount = value.PadLeft(10, "0")
        End Set
    End Property

    Private str_IndividualID As String
    ''' <summary>
    ''' Receiver’s identification number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property individual_ID As String
        Get
            Return str_IndividualID
        End Get
        Set(value As String)
            str_IndividualID = value.PadRight(15, " ")
        End Set
    End Property

    Private str_IndividualName As String
    ''' <summary>
    ''' Name of receiver
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property individual_name As String
        Get
            Return str_IndividualName
        End Get
        Set(value As String)
            str_IndividualName = value.PadRight(22, " ")
        End Set
    End Property

    Private Const str_Filler As String = "  "

    Private str_TraceNumber As String
    Public Property trace_number As String
        Get
            Return str_TraceNumber
        End Get
        Set(value As String)
            str_TraceNumber = value
        End Set
    End Property

#End Region

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder()
        sb.Append(rec_type)
        sb.Append(transaction_code)
        sb.Append(receiver_routing)
        sb.Append(check_digit)
        sb.Append(receiver_acct)
        sb.Append(amount)
        sb.Append(individual_ID)
        sb.Append(individual_name)
        sb.Append(str_Filler)
        sb.Append("0")
        sb.Append(trace_number)
        Return sb.ToString
    End Function

End Class

Public Class BatchControl
    Inherits FileRec

    Public Sub New()
        rec_type = "8"
    End Sub

#Region "Instance Vars"
    <VBFixedString(3)> Private str_ServiceClass As String
    ''' <summary>
    ''' Identifies the type of entries in the batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property service_class As String
        Get
            Return str_ServiceClass
        End Get
        Set(value As String)
            str_ServiceClass = value
        End Set
    End Property

    <VBFixedString(6)> Private str_EntryCount As String
    ''' <summary>
    ''' Total number of entry detail and addenda records processed within the batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property entry_count As String
        Get
            Return str_EntryCount
        End Get
        Set(value As String)
            str_EntryCount = value.PadLeft(6, "0")
        End Set
    End Property

    <VBFixedString(10)> Private str_EntryHash As String
    ''' <summary>
    ''' A check sum of all detail record routing numbers in the batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property entry_hash As String
        Get
            Return str_EntryHash
        End Get
        Set(value As String)
            str_EntryHash = value.PadLeft(10, "0")
        End Set
    End Property

    <VBFixedString(12)> Private str_TotDebitAmount As String
    ''' <summary>
    ''' Dollar totals of debit entries within the batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property tot_debit_amount As String
        Get
            Return str_TotDebitAmount
        End Get
        Set(value As String)
            str_TotDebitAmount = value.PadLeft(12, "0")
        End Set
    End Property

    <VBFixedString(12)> Private str_TotCreditAmount As String
    ''' <summary>
    ''' Dollar totals of credit entries within the batch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property tot_credit_amount As String
        Get
            Return str_TotCreditAmount
        End Get
        Set(value As String)
            str_TotCreditAmount = value.PadLeft(12, "0")
        End Set
    End Property

    <VBFixedString(10)> Private str_CompanyID As String
    ''' <summary>
    ''' The 10 digit tax ID of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property company_ID As String
        Get
            Return str_CompanyID
        End Get
        Set(value As String)
            If value.Length = 10 Then
                str_CompanyID = value
            Else
                Throw New Exception(String.Format("The value given for Company ID is the incorrect length. Expected 10 but was {0}", value.Length))
            End If
        End Set
    End Property

    <VBFixedString(19)> Private str_MsgAuth As String = String.Format("{0,19}", " ")
    <VBFixedString(6)> Private str_reserved As String = String.Format("{0,6}", " ")

    <VBFixedString(8)> Private str_OrigFinancialID As String
    ''' <summary>
    ''' The routing number of the financial institution of the company producing the NACHA file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property originating_financial_ID As String
        Get
            Return str_OrigFinancialID
        End Get
        Set(value As String)
            str_OrigFinancialID = value
            If value.Length = 9 Then
                str_OrigFinancialID = value.Substring(0, 8)
            Else
                Throw New Exception(String.Format("The Originating Financial Institution ID is invalid, because it is the wrong length. Expected 9 but was {0}", value.Length))
            End If
        End Set
    End Property

    <VBFixedString(7)> Private str_BatchNumber As String
    ''' <summary>
    ''' Sequential batch number this control record is for
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property batch_number As String
        Get
            Return str_BatchNumber
        End Get
        Set(value As String)
            str_BatchNumber = value.PadLeft(7, "0")
        End Set
    End Property

#End Region

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.Append(rec_type)
        sb.Append(service_class)
        sb.Append(entry_count)
        sb.Append(entry_hash)
        sb.Append(tot_debit_amount)
        sb.Append(tot_credit_amount)
        sb.Append(company_ID)
        sb.Append(str_MsgAuth)
        sb.Append(str_reserved)
        sb.Append(originating_financial_ID)
        sb.Append(batch_number)
        Return sb.ToString
    End Function

End Class

Public Class FileControl
    Inherits FileRec

    Public Sub New()
        rec_type = "9"
    End Sub

#Region "Instance Vars"
    <VBFixedString(6)> Private str_BatchCount As String
    Public Property batch_count As String
        Get
            Return str_BatchCount
        End Get
        Set(value As String)
            str_BatchCount = value.PadLeft(6, "0")
        End Set
    End Property

    <VBFixedString(6)> Private str_BlockCount As String
    Public Property block_count As String
        Get
            Return str_BlockCount
        End Get
        Set(value As String)
            str_BlockCount = value.PadLeft(6, "0")
        End Set
    End Property

    <VBFixedString(8)> Private str_EntryCount As String
    Public Property entry_count As String
        Get
            Return str_EntryCount
        End Get
        Set(value As String)
            str_EntryCount = value.PadLeft(8, "0")
        End Set
    End Property

    <VBFixedString(10)> Private str_EntryHash As String
    Public Property entry_hash As String
        Get
            Return str_EntryHash
        End Get
        Set(value As String)
            str_EntryHash = value.PadLeft(10, "0")
        End Set
    End Property

    <VBFixedString(12)> Private str_TotDebitAmount As String
    Public Property tot_debit_amount As String
        Get
            Return str_TotDebitAmount
        End Get
        Set(value As String)
            str_TotDebitAmount = value.PadLeft(12, "0")
        End Set
    End Property

    <VBFixedString(12)> Private str_TotCreditAmount As String
    Public Property tot_credit_amount As String
        Get
            Return str_TotCreditAmount
        End Get
        Set(value As String)
            str_TotCreditAmount = value.PadLeft(12, "0")
        End Set
    End Property

    <VBFixedString(39)> Private str_Reserved As String = String.Format("{0,39}", " ")
#End Region

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.Append(rec_type)
        sb.Append(batch_count)
        sb.Append(block_count)
        sb.Append(entry_count)
        sb.Append(entry_hash)
        sb.Append(tot_debit_amount)
        sb.Append(tot_credit_amount)
        sb.Append(str_Reserved)
        Return sb.ToString
    End Function
End Class

Public Class BlockFiller

    Dim filler As String = "9".PadLeft(94, "9")
    Public Overrides Function ToString() As String
        Return filler
    End Function

End Class