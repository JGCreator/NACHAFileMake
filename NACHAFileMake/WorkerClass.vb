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

Public Class WorkerClass
#Region "Instance Variables"
    Friend file As String
#End Region

    ''' <summary>
    ''' Open registry and read for a file path to the input file
    ''' </summary>
    ''' <returns>Success: the value of the key. Fail: exception.</returns>
    Public Function open_reg() As String
        ' try to open the registry key
        Try
            Dim reg As RegistryKey = Registry.LocalMachine
            reg = reg.OpenSubKey("SOFTWARE\NMake_file")

            ' if the open failed the key mus not exist 
            If reg Is Nothing Then
                ' throw an exception instead of returning key value
                Throw New Exception("Open Failed")
            Else
                Return reg.GetValue("path")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Ask the user for the name and location of the data file and set the registry key "path" value to the location
    ''' </summary>
    ''' <param name="debug"></param>
    ''' <returns>The file path set by the user</returns>
    Public Function create_set_key(ByVal file_path As String, Optional debug As Boolean = False) As String
        Try
            Dim reg As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
            reg = reg.CreateSubKey("NMake_file", RegistryKeyPermissionCheck.ReadWriteSubTree)
            
            reg.SetValue("path", file_path)
            Return file
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function deserializeConfig() As Configuration
        Try
            Dim progFiles As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles)
            If Not Directory.Exists(progFiles & "\NACHAMake") Then Directory.CreateDirectory(progFiles & "\NACHAMake")
            Using fs As New FileStream(progFiles & "\NACHAMake\config.bin", FileMode.OpenOrCreate, FileAccess.Read)
                ' Creat binary object
                Dim bf As New BinaryFormatter()

                ' Serialize object to file
                Return CType(bf.Deserialize(fs), Configuration)
            End Using
        Catch serial_ex As Runtime.Serialization.SerializationException
            Return Nothing
        Catch ex As Exception
            MessageBox.Show("An unexpected exception occurred while trying to deserialize the configuration file: " & ex.Message)
            ' write to log
            Throw ex
        End Try

    End Function

    Public Sub serializeConfig(ByVal config As Configuration)
        Dim progFiles As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles)
        If Not Directory.Exists(progFiles & "\NACHAMake") Then Directory.CreateDirectory(progFiles & "\NACHAMake")
        Using fs As New FileStream(progFiles & "\NACHAMake\config.bin", FileMode.OpenOrCreate, FileAccess.Write)
            ' Creat binary object
            Dim bf As New BinaryFormatter()

            ' Serialize object to file
            bf.Serialize(fs, config)
        End Using

    End Sub
End Class
