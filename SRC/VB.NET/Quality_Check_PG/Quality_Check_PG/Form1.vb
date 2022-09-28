
Public Class Form1

    '共有フィールド
    Dim strpdfpath As String
    Public Dim clsSQL As SQL_OPE
    Public intDispNum As Integer
    Public strgetHINBAN As String

    'その他不良数変更
    Public Sub setSONOTA()
        DataGridView1(3, intDispNum).Value = clsSQL.getETCFuryo()
    End Sub

    ' WndProc メソッドをオーバーライドする→フォームを移動できなくする
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_MOVE As Integer = &HF010
        Const SC_MASK As Integer = &HFFF0

        ' フォームの移動を捕捉したら以降の制御をカットする
        If (m.Msg = WM_SYSCOMMAND) AndAlso ((m.WParam.ToInt32() And SC_MASK) = SC_MOVE) Then
            Return
        End If

        ' 基本クラスのメソッドを実行する
        MyBase.WndProc(m)
    End Sub

    'フォームが起動したときの初期設定
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'AcroPDF.LoadFile("C:\Users\Iwakoshi\Desktop\Quality_Check\DATA\9784798012940.pdf")

        'SYSTEM.INIの存在するフォルダ
        Dim strPath As String = "C:\Dev\Quality_Check" & "\INI\SYSTEM.INI"

        '<System.IO.FileNotFoundExceptionでも記述できる>
        'SYSTEM.INIが見つからない場合
        If System.IO.File.Exists(strPath) <> True Then
            MsgBox("SYSTEM.INIが見つかりません。" & vbCrLf & "プログラムを終了します。",, "エラー")
            Try
            Finally
                Application.Exit()
            End Try
        End If

        'インスタンス生成
        Dim INI As New RWini(strPath)

        Try

            'Formの初期設定
            Size = New Size(1920, 1080)
            With Me
                .WindowState = FormWindowState.Maximized
                .FormBorderStyle = FormBorderStyle.FixedSingle
                .Text = "品質チェックシステム"
                .MaximizeBox = False
            End With

            'PDFViewerの初期設定
            AcroPDF.Location = New Point(960, 12)
            'AcroPDF.Size = New Size(595, 847)
            AcroPDF.setZoom(78)

            'スキャナ接続状態
            LblCON.Text = "スキャナ接続状態："
            btnCON.Visible = False

            '品番
            LblHINBAN.Text = "<品番>"
            txtHINBAN.Text = Nothing

            '「終了」ボタン
            btnFin.Text = "終了"
            btnFin.BackColor = Color.FromArgb(0, 255, 0)

            '「検索」ボタン
            btnSearch.Text = "検索"
            btnSearch.BackColor = Color.FromArgb(255, 255, 0)

            '不良登録ラベル
            LblFURYO_TOROKU.Text = "<不良登録>"

            '日時表示ラベル
            lblTime.Text = "日時："
            Timer1.Start()

            '品名ラベル
            LblHINMEI.Text = "品名："
            txtHINMEI.Visible = False

            '分類区分ラベル
            LblBUN.Text = "分類区分："
            txtBUN.Visible = False

            'INIファイルからPDFファイルのパスを取得
            strpdfpath = INI.GetIniString("PDF", "DIRECTORY")

            'INIファイルから表示件数の取得
            intDispNum = INI.GetIniString("SQL", "DISPNUM")


            ''MsgBox(INI.GetIniString("SCANNER", "PORT"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Serialportの設定
        Try

            'SerialPortの初期設定
            With SerialPort1
                .PortName = INI.GetIniString("SCANNER", "PORT")
                .BaudRate = INI.GetIniString("SCANNER", "BAUDRATE")
                .DataBits = INI.GetIniString("SCANNER", "DATABITS")
                .Parity = IO.Ports.Parity.None
                .StopBits = IO.Ports.StopBits.One
                'SerialPortを開く
                '--------------スキャナを差していないときは下の一行をコメントアウト---------------------------
                .Open()

                LblCON.Text = "スキャナ接続状態：接続済み"

            End With

        Catch ex As System.IO.IOException
            Dim ans As DialogResult = MessageBox.Show(ex.Message & vbCrLf & "スキャナを接続してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LblCON.Text = "スキャナ接続状態：未接続"
            LblCON.ForeColor = Color.Red
            btnCON.Visible = True
            'Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '日時表示
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dtNow1 As DateTime = DateTime.Now.ToString("yyyy/MM/d")
        Dim dtNow2 As DateTime = DateTime.Now.ToString("HH:mm:ss")

        Me.lblTime.Text = "日時：" & dtNow1 & " " & dtNow2
    End Sub

    'スキャナ再接続
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCON.Click

        Try

            'SerialPortの初期設定
            SerialPort1.Open()
            LblCON.ForeColor = Color.Black
            LblCON.Text = "スキャナ接続状態：接続済み"
            btnCON.Visible = False

        Catch ex As System.IO.IOException
            Dim ans As DialogResult = MessageBox.Show(ex.Message & vbCrLf & "スキャナを再接続してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LblCON.Text = "スキャナ接続状態：未接続"
            LblCON.ForeColor = Color.Red
            btnCON.Visible = True
            'Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'バーコード読み取り
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As EventArgs) Handles SerialPort1.DataReceived

        Try
            'データ受信  
            Dim str2 = SerialPort1.ReadExisting()
            '改行文字列削除
            str2 = str2.Replace(Environment.NewLine, "")
            'デリゲート生成  
            Dim dlg As New DisplayTextDelegate(AddressOf DisplayText)
            'デリゲート関数をコールする  
            Me.Invoke(dlg, New Object() {str2})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Invokeメソッドで使用するデリゲート宣言  
    Delegate Sub DisplayTextDelegate(ByVal strDisp As String)

    Private Sub DisplayText(ByVal strDisp As String)
        'テキストBOXに文字列を追加  
        txtHINBAN.Text = strDisp

        'PDF表示メソッドを起動
        PDF_Disp(strDisp)
        'SQL表示メソッドの呼び出し
        conSQL(strDisp)

    End Sub

    '×ボタンをクリック
    Private Sub Form_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing

        Try

            Dim result As DialogResult = MessageBox.Show("プログラムを終了しますか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            If result = DialogResult.Yes Then
                '「はい」が選択された時 
                SerialPort1.Close()
                Application.Exit()
            ElseIf result = DialogResult.No Then
                '「いいえ」が選択された時
                e.Cancel = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '終了ボタンクリック
    Sub btnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click

        Try

            Dim result As DialogResult = MessageBox.Show("プログラムを終了しますか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            If result = DialogResult.Yes Then
                '「はい」が選択された時 
                Application.Exit()
                SerialPort1.Close()
            ElseIf result = DialogResult.No Then
                '「いいえ」が選択された時
                sender.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '検索ボタンをクリック
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'DisplayText(txtHINBAN.Text)

        If txtHINBAN.Text <> "" Then
            'PDF表示メソッドの呼び出し
            PDF_Disp(txtHINBAN.Text)
            'SQL表示メソッドの呼び出し
            conSQL(txtHINBAN.Text)
        Else
            MsgBox("品番を入力して下さい。",, "入力エラー")
        End If

    End Sub
    'テキストボックス内でEnterキーが押下されたら検索ボタンクリックメソッドを呼び出す
    Private Sub keyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtHINBAN.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    'PDF表示メソッド
    Private Sub PDF_Disp(Filename As String)

        If System.IO.File.Exists(strpdfpath & Filename & ".pdf") <> True Then
            MsgBox("指定されたファイルが見つかりません。" & vbCrLf & "品番を再確認してください。",, "エラー")
        Else
            'MsgBox(pdfpath & Filename & ".pdf")
            AcroPDF.LoadFile(strpdfpath & Filename & ".pdf")
        End If

    End Sub

    'SQL表示メソッド
    Private Sub conSQL(HINBAN As String)

        Try

            'SQL操作クラスのインスタンス生成
            clsSQL = New SQL_OPE(HINBAN, intDispNum, DataGridView1)

            '品名表示
            txtHINMEI.Visible = True
            txtHINMEI.Text = clsSQL.getHINMEI()

            '分類区分表示
            txtBUN.Visible = True
            txtBUN.Text = clsSQL.getBUNRUI()


            'If Not (DataGridView1.Columns.Contains("詳細")) Then

            '    'DataGridViewButtonColumnの作成
            '    Dim btnDetail As New DataGridViewButtonColumn()
            '    '列の名前を設定
            '    btnDetail.Name = "詳細"
            '    '全てのボタンにそれぞれ"詳細"と表示する
            '    btnDetail.UseColumnTextForButtonValue = True
            '    btnDetail.Text = "詳細"
            '    'DataGridViewに追加する
            '    DataGridView1.Columns.Add(btnDetail)

            'End If

            'DataGridViewに表示
            clsSQL.DATA_Disp()

            strgetHINBAN = HINBAN

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '+-その他ボタン押下
    Private Sub DataGridView_PlusMinusButtonClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Try
            Dim colIndex As Integer = e.ColumnIndex
            Dim rowIndex As Integer = e.RowIndex

            If colIndex <> 2 And colIndex <> 4 And colIndex <> 5 Then
                Exit Sub
            End If

            'その他ボタン押下
            If colIndex = 2 And rowIndex = intDispNum Then
                Dim f2 As New Form2()
                DataGridView1(2, intDispNum).ReadOnly = True
                f2.ShowDialog()

            End If

            '+ボタン
            If colIndex = 4 And rowIndex < intDispNum And colIndex <> 0 Then
                DataGridView1(3, rowIndex).Value = Integer.Parse(DataGridView1(3, rowIndex).Value) + 1
                clsSQL.UpdateSQL(DataGridView1(3, rowIndex).Value, DataGridView1(1, rowIndex).Value)
            End If

            '-ボタン
            If colIndex = 5 And rowIndex < intDispNum And colIndex <> 0 Then
                If DataGridView1(3, rowIndex).Value > 0 Then
                    DataGridView1(3, rowIndex).Value = Integer.Parse(DataGridView1(3, rowIndex).Value) - 1
                    clsSQL.UpdateSQL(DataGridView1(3, rowIndex).Value, DataGridView1(1, rowIndex).Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'DataGridView変更イベント
    Private Sub DataGridView_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        If colIndex <> 3 Or rowIndex = intDispNum Then
            Exit Sub
        End If

        Try

            If DataGridView1(colIndex, rowIndex).Value IsNot DBNull.Value Then
                clsSQL.UpdateSQL(DataGridView1(3, rowIndex).Value, DataGridView1(1, rowIndex).Value)
            End If


        Catch ex As Exception
            MsgBox("ここ")
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
