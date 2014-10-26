#Region "Imports"
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop
#End Region

Public Class ExcelInput_Model
    Implements IDisposable

    Friend file_location As String
    Dim xlApp As Excel.Application
    Dim xlBooks As Excel.Workbooks
    Dim xlBook As Excel.Workbook
    Dim xlSheets As Excel.Sheets
    Dim xlSheet As Excel.Worksheet
    Dim misVal As Object = Reflection.Missing.Value

    Public Sub New()
        Try
            xlApp = New Excel.Application()
            Do
                get_filename()
            Loop Until file_location <> "False"
            interop_marshal(xlApp)
            create_input()
            xlApp = New Excel.Application()
            xlBooks = xlApp.Workbooks
            xlBook = xlBooks.Open(file_location)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub New(ByVal file_name As String)
        xlApp = New Excel.Application()
        xlBooks = xlApp.Workbooks
        xlBook = xlBooks.Open(file_name)
    End Sub



    ''' <summary>
    ''' Get the location for the new data file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub get_filename()

        file_location = xlApp.GetSaveAsFilename("input.xlsx", "Excel Files (*.xlsx), *.xlsx")
        If file_location = "False" Then
            MessageBox.Show("You must choose a location for the input file.")
            'Throw New Exception("Error: Get File Name")
        End If

    End Sub

    ''' <summary>
    ''' Create an excel data file for program input
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub create_input()
        Try

            xlApp = New Excel.Application(file_location)
            xlBooks = xlApp.Workbooks
            xlBook = xlBooks.Add()
            xlSheets = xlBook.Sheets
            xlSheet = xlBook.Sheets(1)
            Dim xlcells As Excel.Range = xlSheet.Range("A1:I1")

            xlSheet.Name = "Clearing House Input"

            Dim xlGroup As Excel.Range
            xlGroup = xlcells.Range("A1")
            xlGroup.Value = "Group #"

            Dim xlGroupName As Excel.Range
            xlGroupName = xlcells.Range("B1")
            xlGroupName.Value = "Group Name"

            Dim xlGroupAcct As Excel.Range
            xlGroupAcct = xlcells.Range("C1")
            xlGroupAcct.Value = "Group Account"

            Dim xlGroupRout As Excel.Range
            xlGroupRout = xlcells.Range("D1")
            xlGroupRout.Value = "Group Routing"

            Dim xlVendorName As Excel.Range
            xlVendorName = xlcells.Range("E1")
            xlVendorName.Value = "Vendor Name"

            Dim xlVendorFundAcct As Excel.Range
            xlVendorFundAcct = xlcells.Range("F1")
            xlVendorFundAcct.Value = "Vendor Fund Acct."

            Dim xlVendorFundRout As Excel.Range
            xlVendorFundRout = xlcells.Range("G1")
            xlVendorFundRout.Value = "Vendor Fund Rout."

            Dim xlVendorDistAcct As Excel.Range
            xlVendorDistAcct = xlcells.Range("H1")
            xlVendorDistAcct.Value = "Vendor Disb. Acct."

            Dim xlVendorDistRout As Excel.Range
            xlVendorDistRout = xlcells.Range("I1")
            xlVendorDistRout.Value = "Vendor Disb. Rout."

            xlSheet.SaveAs(file_location)
            xlBook.Saved = True

            AddHandler xlApp.WorkbookBeforeClose, AddressOf xlApp_BefClose

            xlApp.Visible = True
            While xlApp.Visible = True
                Threading.Thread.Sleep(500)
            End While

            GC.Collect()
            GC.WaitForPendingFinalizers()


            'System.Runtime.InteropServices.Marshal.ReleaseComObject(xlGroup)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlGroup)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlGroupAcct)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlGroupName)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlGroupRout)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlVendorDistAcct)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlVendorDistRout)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlVendorFundAcct)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlVendorFundRout)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlVendorName)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlcells)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlSheet)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlSheets)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlBook)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlBooks)
            xlApp.Quit()
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp)

            RemoveHandler xlApp.WorkbookBeforeClose, AddressOf xlApp_BefClose
        Catch ex As Exception
            MessageBox.Show("An exception was caught: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Perform custom operations before closing the workbook
    ''' </summary>
    ''' <param name="wb">The Workbook that raised the event</param>
    ''' <param name="b">A boolean parameter to cansel the closing</param>
    Sub xlApp_BefClose(ByVal wb As Excel.Workbook, ByRef b As Boolean)
        Try
            'xlBook.Saved = False
            'xlBook.Save()
            'xlBook.Saved = True
            wb.Saved = False
            wb.Save()
            wb.Saved = True
            xlApp.Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub edit_input()

        AddHandler xlApp.WorkbookBeforeClose, AddressOf xlApp_BefClose

        xlApp.Visible = True
        While xlApp.Visible = True
            Threading.Thread.Sleep(500)
        End While

        RemoveHandler xlApp.WorkbookBeforeClose, AddressOf xlApp_BefClose
    End Sub

    ''' <summary>
    ''' open and search an excel application instance
    ''' </summary>
    ''' <returns>Success: a range that represents the row found. Fail: exception</returns>
    ''' <remarks></remarks>
    Public Function find_group(ByVal find_data As String) As RowValues

        Dim values As New RowValues

        xlSheet = xlBook.Sheets(1)

        Dim xlrows As Excel.Range = xlSheet.Rows
        Dim cell_found As Excel.Range = xlrows.find(find_data)
        'Dim cell_found As Excel.Range = xlSheet.Rows.Find(find_data)
        Dim row_found As Excel.Range = xlSheet.Range("A" & cell_found.Row, "I" & cell_found.Row)
        Dim rowvals(,) As Object
        rowvals = row_found.Value2

        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(cell_found)
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(row_found)
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlrows)

        values.int_group_nbr = CInt(rowvals.GetValue(1, 1))
        values.str_group_name = rowvals(1, 2)
        ' put the rest of the array values in the RowValues structure

        Return values

    End Function


    Private Sub interop_marshal(ByRef obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch ex As Exception
            throw
        End Try

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlSheet)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlSheets)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlBook)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlBooks)
            xlApp.Quit()
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp)

            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
