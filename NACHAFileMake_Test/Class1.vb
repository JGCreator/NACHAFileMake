Imports System
Imports NUnit.Framework
Imports NACHAFileMake

<TestFixture()>
Public Class TestClass

End Class

<TestFixture()>
Public Class File_fixture



    <Test()>
    Public Sub test_fileHeader_ToString()
        Dim fh As New FileHeader
        fh.bank_Name = "bankName"
        fh.company_Name = "coName"
        fh.file_ID = "A"
        fh.immediate_Destination = "123456789"
        fh.immediate_Origin = "0123456789"

        Dim ret As String = fh.ToString
        Dim dt As String = Now.ToString("yyMMdd")
        Dim tm As String = Now.ToString("HHmm")

        Assert.AreEqual(94, ret.Length)
    End Sub

    <Test()>
    Public Sub test_batchHeader_ToString()
        Dim bh As New BatchHeader
        bh.batch_number = "1234567"
        bh.company_ID = "1234567890"
        bh.company_Name = "CompanyName"
        bh.effective_date = Today
        bh.entry_desc = "test desc"
        bh.orig_financialInst = "12345678"
        bh.rec_type = "5"
        bh.service_Code = "999"
        bh.user_data = "Descretionary Data"

        Dim ret As String = bh.ToString

        Assert.AreEqual(94, ret.Length)
    End Sub

End Class
