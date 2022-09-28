Public Class Form2
    Dim clsSQL As SQL_OPE
    Dim intDispNum As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Formの初期設定
        Try

            txtHINMEI.Visible = False
            txtBUN.Visible = False
            LblBUN.Text = "分類区分："
            LblHINMEI.Text = "品名："
            btnTOJIRU.Text = "閉じる"
            btnTOJIRU.BackColor = Color.FromArgb(0, 255, 0)

            With Me
                '.WindowState = FormWindowState.Maximized
                .FormBorderStyle = FormBorderStyle.FixedSingle
                .Text = "その他"
                .MaximizeBox = False
                .MinimizeBox = False
            End With

        Catch ex As Exception

        End Try


        Try

            intDispNum = Form1.intDispNum

            'SQL操作クラスのインスタンス生成
            clsSQL = New SQL_OPE(Form1.strgetHINBAN, intDispNum, DataGridView2)

            '品名表示
            txtHINMEI.Visible = True
            txtHINMEI.Text = clsSQL.getHINMEI()

            '分類区分表示
            txtBUN.Visible = True
            txtBUN.Text = clsSQL.getBUNRUI()


            'If Not (DataGridView2.Columns.Contains("詳細")) Then

            '    'DataGridViewButtonColumnの作成
            '    Dim btnDetail As New DataGridViewButtonColumn()
            '    '列の名前を設定
            '    btnDetail.Name = "詳細"
            '    '全てのボタンにそれぞれ"詳細"と表示する
            '    btnDetail.UseColumnTextForButtonValue = True
            '    btnDetail.Text = "詳細"
            '    'DataGridViewに追加する
            '    DataGridView2.Columns.Add(btnDetail)

            'End If

            'DataGridViewに表示
            clsSQL.ETC_DATA_Disp()

        Catch ex As Exception
            'MsgBox("ここ")
            MsgBox(ex.Message)
        End Try
    End Sub

    'DataGridView変更イベント
    Private Sub DataGridView_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        If colIndex <> 3 Then
            Exit Sub
        End If

        Try

            If DataGridView2(colIndex, rowIndex).Value IsNot DBNull.Value Then
                clsSQL.UpdateSQL(DataGridView2(3, rowIndex).Value, DataGridView2(1, rowIndex).Value)
            End If


        Catch ex As Exception
            MsgBox("ここ")
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnTOJIRU_Click(sender As Object, e As EventArgs) Handles btnTOJIRU.Click
        Try
            Form1.setSONOTA()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView_PlusMinusButtonClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick, DataGridView2.CellValueChanged

        Try
            Dim colIndex As Integer = e.ColumnIndex
            Dim rowIndex As Integer = e.RowIndex

            If colIndex <> 2 And colIndex <> 4 And colIndex <> 5 Then
                Exit Sub
            End If

            '+ボタン
            If colIndex = 4 And colIndex <> 0 Then
                DataGridView2(3, rowIndex).Value = Integer.Parse(DataGridView2(3, rowIndex).Value) + 1
                clsSQL.UpdateSQL(DataGridView2(3, rowIndex).Value, DataGridView2(1, rowIndex).Value)
            End If

            '-ボタン
            If colIndex = 5 And colIndex <> 0 Then
                If DataGridView2(3, rowIndex).Value > 0 Then
                    DataGridView2(3, rowIndex).Value = Integer.Parse(DataGridView2(3, rowIndex).Value) - 1
                    clsSQL.UpdateSQL(DataGridView2(3, rowIndex).Value, DataGridView2(1, rowIndex).Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class