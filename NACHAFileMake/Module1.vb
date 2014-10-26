Module Module1
    Dim config As frmConfiguration
    Dim worker As WorkerClass
    Dim ex_model As ExcelInput_Model

    'Public Sub main()
    '    worker = New WorkerClass

    '    ' get a configuration object
    '    config = worker.deserializeConfig()
    '    If config Is Nothing Then
    '        'config = New Configuration(Me)
    '        Dim thr As Threading.Thread
    '        thr = New Threading.Thread(AddressOf startConfig)
    '        thr.Start()
    '        Threading.Thread.Sleep(250)
    '    End If

    '    While config.Visible = True
    '        Threading.Thread.Sleep(500)
    '    End While

    '    Dim file_path As String
    '    Try
    '        file_path = worker.open_reg()
    '        ex_model = New ExcelInput_Model(file_path)
    '    Catch ex As Exception
    '        ex_model = New ExcelInput_Model()
    '        worker.create_set_key(ex_model.file_location)
    '    End Try
    'End Sub

    'Private Sub startConfig()
    '    config.Show()

    'End Sub

End Module
