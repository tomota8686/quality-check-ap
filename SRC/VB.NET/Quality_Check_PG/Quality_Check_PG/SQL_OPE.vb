Imports System.Data.SqlClient
Imports System.Configuration

Public Class SQL_OPE

    Dim HINBAN As String = ""
    Dim DispNum As Integer
    Private settings As ConnectionStringSettings
    Private DataGridView1 As DataGridView

    'コンストラクタ
    Sub New(HINBAN As String, DispNum As Integer, DataGridView1 As DataGridView)

        Try
            If DataGridView1 Is Nothing Then
                Throw New ArgumentNullException(NameOf(DataGridView1))
            End If

            Me.HINBAN = HINBAN
            Me.DispNum = DispNum
            Me.DataGridView1 = DataGridView1

            settings = ConfigurationManager.ConnectionStrings("QC_DB")

            If settings Is Nothing Then
                MessageBox.Show("App.configに未登録", "接続文字列エラー")
                Exit Sub
            End If

        Catch ex As ArgumentNullException
            'MsgBox("エラーはここです")
            MsgBox(ex.Message)
        End Try

    End Sub

    'その他のデータをForm2に表示
    Sub ETC_DATA_Disp()

        DataGridView1.DataSource = Nothing

        Try

            'SQLと接続
            Dim con = New System.Data.SqlClient.SqlConnection()
            '接続文字列の設定
            con.ConnectionString = settings.ConnectionString

            con.Open()

            'DataGridViewの幅,高さを調節
            DataGridView1.RowTemplate.Height = 30
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'DataGridViewの文字大きさ
            DataGridView1.Font = New Font(DataGridView1.Font.Name, 15)

            ''並び替え禁止
            'For s As Integer = 0 To 4
            '    DataGridView1.Columns(s).SortMode = DataGridViewColumnSortMode.NotSortable
            'Next

            Dim My_SQL As String

            'SQL文の設定
            My_SQL = "SELECT M02.DISP_ORDER AS No, M02.FURYO_ID AS 不良ID, FURYO_CON AS 内容, ISNULL(D01.FURYO_NUM, 0) AS 不良数 FROM M02_FURYO AS M02 LEFT OUTER JOIN M03_HINBAN AS M03 ON M02.BUNRUI_KB = M03.BUNRUI_KB LEFT OUTER JOIN D01_RECORD AS D01 ON M02.FURYO_ID = D01.FURYO_ID AND LEFT(D01.ADD_YMDHNS, 8) = FORMAT(GETDATE(),'yyyyMMdd') WHERE M03.HINBAN = " & HINBAN & " AND M02.DISP_ORDER > " & DispNum & " ORDER BY DISP_ORDER ASC"

            Dim Sqlds1 As New DataSet
            Dim Sqlda1 As New SqlClient.SqlDataAdapter
            Sqlda1.SelectCommand = New SqlClient.SqlCommand(My_SQL, con)

            Sqlda1.SelectCommand.CommandTimeout = 0
            Sqlda1.Fill(Sqlds1)
            DataGridView1.DataSource = Sqlds1.Tables(0)

            con.Close()
            con.Dispose()

            If Not (DataGridView1.Columns.Contains("追加")) And Not (DataGridView1.Columns.Contains("削除")) Then

                'DataGridViewButtonColumnの作成
                Dim btnPlus As New DataGridViewButtonColumn()
                Dim btnMinus As New DataGridViewButtonColumn()

                '列の名前を設定
                btnPlus.Name = "追加"
                btnMinus.Name = "削除"

                '列追加
                DataGridView1.Columns.Add(btnPlus)
                DataGridView1.Columns.Add(btnMinus)

                '全てのボタンにそれぞれ"+""-と表示する
                btnPlus.UseColumnTextForButtonValue = True
                btnMinus.UseColumnTextForButtonValue = True
                btnPlus.Text = "+"
                btnMinus.Text = "-"

            End If

            'DataGridViewのセルを「不良数」以外読み取り専用にする
            For i As Integer = 0 To 2
                DataGridView1.Columns(i).ReadOnly = True
            Next i

        Catch ex As Exception
            MsgBox(ex.Message)
            'Form2.Close()
        End Try

    End Sub

    'DataGridViewにデータを表示
    Sub DATA_Disp()

        DataGridView1.DataSource = Nothing

        Try

            'SQLと接続
            Dim con = New System.Data.SqlClient.SqlConnection()
            '接続文字列の設定
            con.ConnectionString = settings.ConnectionString

            con.Open()

            'DataGridViewの幅,高さを調節
            If DispNum <> 0 Then
                DataGridView1.RowTemplate.Height = ((Form1.DataGridView1.Size.Height - 28) / (DispNum + 1))
            Else

            End If
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'DataGridViewの文字大きさ
            DataGridView1.Font = New Font(DataGridView1.Font.Name, 15)

            Dim My_SQL As String

            'SQL文の設定
            My_SQL = "SELECT M02.DISP_ORDER AS No, M02.FURYO_ID AS 不良ID, FURYO_CON AS 内容, ISNULL(D01.FURYO_NUM, 0) AS 不良数 FROM M02_FURYO AS M02 LEFT OUTER JOIN M03_HINBAN AS M03 ON M02.BUNRUI_KB = M03.BUNRUI_KB LEFT OUTER JOIN D01_RECORD AS D01 ON M02.FURYO_ID = D01.FURYO_ID AND LEFT(D01.ADD_YMDHNS, 8) = FORMAT(GETDATE(),'yyyyMMdd') WHERE M03.HINBAN = " & HINBAN & " AND M02.DISP_ORDER <= " & DispNum & " ORDER BY DISP_ORDER ASC"

            Dim Sqlds1 As New DataSet
            Dim Sqlda1 As New SqlClient.SqlDataAdapter
            Sqlda1.SelectCommand = New SqlClient.SqlCommand(My_SQL, con)

            Sqlda1.SelectCommand.CommandTimeout = 0
            Sqlda1.Fill(Sqlds1)
            DataGridView1.DataSource = Sqlds1.Tables(0)

            con.Close()
            con.Dispose()

            If DataGridView1.Columns.Contains("追加") And DataGridView1.Columns.Contains("削除") Then

                DataGridView1.Columns.Remove("追加")
                DataGridView1.Columns.Remove("削除")

            End If

            If Not (DataGridView1.Columns.Contains("追加")) And Not (DataGridView1.Columns.Contains("削除")) Then

                'DataGridViewButtonColumnの作成
                Dim btnPlus As New DataGridViewButtonColumn()
                Dim btnMinus As New DataGridViewButtonColumn()

                '列の名前を設定
                btnPlus.Name = "追加"
                btnMinus.Name = "削除"

                '列追加
                DataGridView1.Columns.Add(btnPlus)
                DataGridView1.Columns.Add(btnMinus)

                '全てのボタンにそれぞれ"+""-と表示する
                btnPlus.UseColumnTextForButtonValue = True
                btnMinus.UseColumnTextForButtonValue = True
                btnPlus.Text = "+"
                btnMinus.Text = "-"

                For i As Integer = 0 To DispNum - 1
                    DataGridView1.Rows(i).Cells("追加").Value = "+"
                    DataGridView1.Rows(i).Cells("削除").Value = "-"
                Next

            End If

            'その他作成
            Sqlds1.Tables(0).Rows.Add()
            DataGridView1.Rows(DispNum).Cells("追加") = New DataGridViewTextBoxCell()
            DataGridView1.Rows(DispNum).Cells("削除") = New DataGridViewTextBoxCell()
            For i As Integer = 0 To 5
                If i <> 3 Then
                    DataGridView1.Rows(DispNum).Cells(i).Style.BackColor = Color.Gray
                End If
            Next
            'DataGridView1.Rows(DispNum).Cells().Style.BackColor = Color.Gray
            DataGridView1.Rows(DispNum).Cells(2) = New DataGridViewButtonCell()
            DataGridView1.Rows(DispNum).Cells(2).Value = "その他"



            'DataGridViewのセルを「不良数」以外読み取り専用にする
            For i As Integer = 0 To 2
                DataGridView1.Columns(i).ReadOnly = True
            Next i

            DataGridView1(3, DispNum).Value = getETCFuryo()

        Catch ex As Exception
            'MsgBox("エラーはここです")
            MsgBox(ex.Message)
        End Try

    End Sub

    '品名取得
    Function getHINMEI() As String

        Try
            Using con As New SqlConnection
                Using cmd As New SqlCommand
                    '接続文字列の設定
                    con.ConnectionString = settings.ConnectionString
                    'SqlCommand.Connectionプロパティの設定
                    cmd.Connection = con
                    'SQL文設定
                    cmd.CommandText = "SELECT * FROM M03_HINBAN WHERE HINBAN = " & HINBAN

                    'レコード取得
                    Dim da As New SqlDataAdapter
                    Dim dt As New DataTable
                    da.SelectCommand = cmd
                    da.Fill(dt)

                    If dt.Rows.Count = 1 Then
                        'レコードがあったとき
                        Return CStr(dt.Rows(0)("HINBAN_NAME"))
                    Else
                        'レコードがないとき
                        Return "Err"
                        MessageBox.Show("データがありません", "エラー")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "【例外発生】")
            Return "Err"
        End Try

    End Function

    '分類区分取得
    Function getBUNRUI() As String

        Try
            Using con As New SqlConnection
                Using cmd As New SqlCommand
                    '接続文字列の設定
                    con.ConnectionString = settings.ConnectionString
                    'SqlCommand.Connectionプロパティの設定
                    cmd.Connection = con
                    'SQL文設定
                    cmd.CommandText = "SELECT * FROM M03_HINBAN AS M03 LEFT OUTER JOIN (SELECT * FROM M01_CODE WHERE KOMO_NM = '分類区分' ) AS M01 ON M03.BUNRUI_KB = M01.VALUE WHERE HINBAN = " & HINBAN

                    'レコード取得
                    Dim da As New SqlDataAdapter
                    Dim dt As New DataTable
                    da.SelectCommand = cmd
                    da.Fill(dt)

                    If dt.Rows.Count = 1 Then
                        'レコードがあったとき
                        Return CStr(dt.Rows(0)("DISP"))
                    Else
                        'レコードがないとき
                        Return "Err"
                        MessageBox.Show("データがありません", "エラー")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "【例外発生】")
            Return "Err"
        End Try

    End Function

    'その他合計不良数
    Function getETCFuryo() As String

        Try
            Using con As New SqlConnection
                Using cmd As New SqlCommand
                    '接続文字列の設定
                    con.ConnectionString = settings.ConnectionString
                    'SqlCommand.Connectionプロパティの設定
                    cmd.Connection = con
                    'SQL文設定
                    cmd.CommandText = "SELECT SUM(D02.不良数) FROM (SELECT M02.DISP_ORDER AS No, M02.FURYO_ID AS 不良ID, FURYO_CON AS 内容, IIF(CONVERT(date, LEFT(d01.ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()), D01.FURYO_NUM, 0) AS 不良数 FROM M02_FURYO AS M02 LEFT OUTER JOIN M03_HINBAN AS M03 ON M02.BUNRUI_KB = M03.BUNRUI_KB LEFT OUTER JOIN D01_RECORD AS D01 ON M02.FURYO_ID = D01.FURYO_ID WHERE M03.HINBAN = " & HINBAN & ") AS D02 WHERE D02.No > " & DispNum
                    'レコード取得
                    Dim da As New SqlDataAdapter
                    Dim dt As New DataTable
                    da.SelectCommand = cmd
                    da.Fill(dt)

                    If dt.Rows.Count = 1 Then
                        'レコードがあったとき
                        Return CStr(dt.Rows(0)(0))
                    Else
                        'レコードがないとき
                        Return "Err"
                        MessageBox.Show("データがありません", "エラー")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "【例外発生】")
            Return "Err"
        End Try


    End Function

    'updateSQL
    Sub UpdateSQL(FuryoSU As Integer, Furyo_ID As Integer)

        Try

            Dim cn As New SqlClient.SqlConnection
            Dim cd As New SqlClient.SqlCommand
            Dim My_SQL As String

            'データベース接続
            cn.ConnectionString = settings.ConnectionString
            cn.Open()
            'SQL文生成
            My_SQL = "IF EXISTS(SELECT * FROM D01_RECORD AS D01 WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND D01.HINBAN = " & HINBAN & " AND D01.FURYO_ID = " & Furyo_ID & ") BEGIN UPDATE D01_RECORD SET FURYO_NUM = " & FuryoSU & " WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND HINBAN = " & HINBAN & " AND FURYO_ID = " & Furyo_ID
            My_SQL &= " UPDATE D01_RECORD SET EDIT_YMDHNS = FORMAT(GETDATE(), 'yyyyMMddHHmmss') WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND HINBAN = " & HINBAN & " AND FURYO_ID = " & Furyo_ID & " END ELSE INSERT INTO D01_RECORD(ADD_YMDHNS,HINBAN,FURYO_ID,FURYO_NUM,EDIT_YMDHNS) VALUES (FORMAT(GETDATE(), 'yyyyMMddHHmmss')," & HINBAN & "," & Furyo_ID & "," & FuryoSU & ",' ')"

            'SQLコマンド設定
            cd.CommandText = My_SQL
            cd.Connection = cn
            cd.ExecuteNonQuery()
            'クローズ解放
            cd.Dispose()
            cn.Close()
            cn.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class


''SQLと接続
'Dim con = New System.Data.SqlClient.SqlConnection()
''接続文字列の設定
'con.ConnectionString = settings.ConnectionString

'Dim My_SQL As String

''SQL文の設定
'My_SQL = "IF EXISTS(SELECT * FROM D01_RECORD AS D01 WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND D01.HINBAN = " & HINBAN & " AND D01.FURYO_ID = " & Furyo_ID & ") BEGIN UPDATE D01_RECORD SET FURYO_NUM = " & FuryoSU & " WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND HINBAN = " & HINBAN & " AND FURYO_ID = " & Furyo_ID
'My_SQL &= " UPDATE D01_RECORD SET EDIT_YMDHNS = FORMAT(GETDATE(), 'yyyyMMddHHmmss') WHERE CONVERT(date,LEFT(ADD_YMDHNS, 8)) = CONVERT(date, GETDATE()) AND HINBAN = " & HINBAN & " AND FURYO_ID = " & Furyo_ID & " END ELSE INSERT INTO D01_RECORD(ADD_YMDHNS,HINBAN,FURYO_ID,FURYO_NUM,EDIT_YMDHNS) VALUES (FORMAT(GETDATE(), 'yyyyMMddHHmmss')," & HINBAN & "," & Furyo_ID & "," & FuryoSU & ",' ')"

'con.Open()

'Dim Sqlda1 As New SqlClient.SqlDataAdapter
'Sqlda1.SelectCommand = New SqlClient.SqlCommand(My_SQL, con)

'Sqlda1.SelectCommand.CommandTimeout = 0

'con.Close()
'con.Dispose()