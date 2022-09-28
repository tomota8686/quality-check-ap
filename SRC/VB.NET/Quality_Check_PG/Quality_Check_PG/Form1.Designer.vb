<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.AcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.LblHINBAN = New System.Windows.Forms.Label()
        Me.btnFin = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtHINBAN = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.LblFURYO_TOROKU = New System.Windows.Forms.Label()
        Me.LblCON = New System.Windows.Forms.Label()
        Me.btnCON = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblTime = New System.Windows.Forms.Label()
        Me.LblHINMEI = New System.Windows.Forms.Label()
        Me.txtHINMEI = New System.Windows.Forms.Label()
        Me.LblBUN = New System.Windows.Forms.Label()
        Me.txtBUN = New System.Windows.Forms.Label()
        CType(Me.AcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'AcroPDF
        '
        Me.AcroPDF.Enabled = True
        Me.AcroPDF.Location = New System.Drawing.Point(960, 12)
        Me.AcroPDF.Margin = New System.Windows.Forms.Padding(4)
        Me.AcroPDF.Name = "AcroPDF"
        Me.AcroPDF.OcxState = CType(resources.GetObject("AcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AcroPDF.Size = New System.Drawing.Size(932, 1017)
        Me.AcroPDF.TabIndex = 0
        '
        'LblHINBAN
        '
        Me.LblHINBAN.AutoSize = True
        Me.LblHINBAN.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblHINBAN.Location = New System.Drawing.Point(86, 94)
        Me.LblHINBAN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblHINBAN.Name = "LblHINBAN"
        Me.LblHINBAN.Size = New System.Drawing.Size(94, 27)
        Me.LblHINBAN.TabIndex = 1
        Me.LblHINBAN.Text = "<品番>"
        '
        'btnFin
        '
        Me.btnFin.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFin.Location = New System.Drawing.Point(12, 12)
        Me.btnFin.Name = "btnFin"
        Me.btnFin.Size = New System.Drawing.Size(114, 49)
        Me.btnFin.TabIndex = 3
        Me.btnFin.Text = "終了"
        Me.btnFin.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(406, 91)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 34)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtHINBAN
        '
        Me.txtHINBAN.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINBAN.Location = New System.Drawing.Point(187, 91)
        Me.txtHINBAN.Name = "txtHINBAN"
        Me.txtHINBAN.Size = New System.Drawing.Size(213, 34)
        Me.txtHINBAN.TabIndex = 6
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(91, 266)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(766, 492)
        Me.DataGridView1.TabIndex = 7
        '
        'LblFURYO_TOROKU
        '
        Me.LblFURYO_TOROKU.AutoSize = True
        Me.LblFURYO_TOROKU.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblFURYO_TOROKU.Location = New System.Drawing.Point(86, 236)
        Me.LblFURYO_TOROKU.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFURYO_TOROKU.Name = "LblFURYO_TOROKU"
        Me.LblFURYO_TOROKU.Size = New System.Drawing.Size(120, 27)
        Me.LblFURYO_TOROKU.TabIndex = 8
        Me.LblFURYO_TOROKU.Text = "不良登録"
        '
        'LblCON
        '
        Me.LblCON.AutoSize = True
        Me.LblCON.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCON.Location = New System.Drawing.Point(151, 23)
        Me.LblCON.Name = "LblCON"
        Me.LblCON.Size = New System.Drawing.Size(217, 27)
        Me.LblCON.TabIndex = 9
        Me.LblCON.Text = "スキャナ接続状態："
        '
        'btnCON
        '
        Me.btnCON.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCON.Location = New System.Drawing.Point(455, 19)
        Me.btnCON.Name = "btnCON"
        Me.btnCON.Size = New System.Drawing.Size(75, 35)
        Me.btnCON.TabIndex = 10
        Me.btnCON.Text = "接続"
        Me.btnCON.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime.Location = New System.Drawing.Point(672, 12)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(60, 19)
        Me.lblTime.TabIndex = 11
        Me.lblTime.Text = "日時："
        '
        'LblHINMEI
        '
        Me.LblHINMEI.AutoSize = True
        Me.LblHINMEI.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblHINMEI.Location = New System.Drawing.Point(152, 145)
        Me.LblHINMEI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblHINMEI.Name = "LblHINMEI"
        Me.LblHINMEI.Size = New System.Drawing.Size(70, 24)
        Me.LblHINMEI.TabIndex = 12
        Me.LblHINMEI.Text = "品名："
        '
        'txtHINMEI
        '
        Me.txtHINMEI.AutoSize = True
        Me.txtHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtHINMEI.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINMEI.Location = New System.Drawing.Point(229, 145)
        Me.txtHINMEI.Name = "txtHINMEI"
        Me.txtHINMEI.Size = New System.Drawing.Size(2, 26)
        Me.txtHINMEI.TabIndex = 14
        '
        'LblBUN
        '
        Me.LblBUN.AutoSize = True
        Me.LblBUN.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBUN.Location = New System.Drawing.Point(104, 178)
        Me.LblBUN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBUN.Name = "LblBUN"
        Me.LblBUN.Size = New System.Drawing.Size(118, 24)
        Me.LblBUN.TabIndex = 15
        Me.LblBUN.Text = "分類区分："
        '
        'txtBUN
        '
        Me.txtBUN.AutoSize = True
        Me.txtBUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtBUN.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUN.Location = New System.Drawing.Point(229, 178)
        Me.txtBUN.Name = "txtBUN"
        Me.txtBUN.Size = New System.Drawing.Size(2, 26)
        Me.txtBUN.TabIndex = 16
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.txtBUN)
        Me.Controls.Add(Me.LblBUN)
        Me.Controls.Add(Me.txtHINMEI)
        Me.Controls.Add(Me.LblHINMEI)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.btnCON)
        Me.Controls.Add(Me.LblCON)
        Me.Controls.Add(Me.LblFURYO_TOROKU)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtHINBAN)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnFin)
        Me.Controls.Add(Me.LblHINBAN)
        Me.Controls.Add(Me.AcroPDF)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "品質チェックシステム"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents AcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents LblHINBAN As Label
    Friend WithEvents btnFin As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtHINBAN As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    'Friend WithEvents QualityCheckDBDataSetBindingSource As BindingSource
    'Friend WithEvents Quality_Check_DBDataSet As Quality_Check_DBDataSet
    Friend WithEvents LblFURYO_TOROKU As Label
    Friend WithEvents LblCON As Label
    Friend WithEvents btnCON As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblTime As Label
    Friend WithEvents LblHINMEI As Label
    Friend WithEvents txtHINMEI As Label
    Friend WithEvents LblBUN As Label
    Friend WithEvents txtBUN As Label
End Class
