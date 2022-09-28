<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtBUN = New System.Windows.Forms.Label()
        Me.LblBUN = New System.Windows.Forms.Label()
        Me.txtHINMEI = New System.Windows.Forms.Label()
        Me.LblHINMEI = New System.Windows.Forms.Label()
        Me.btnTOJIRU = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 47)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 21
        Me.DataGridView2.Size = New System.Drawing.Size(776, 391)
        Me.DataGridView2.TabIndex = 0
        '
        'txtBUN
        '
        Me.txtBUN.AutoSize = True
        Me.txtBUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtBUN.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUN.Location = New System.Drawing.Point(540, 11)
        Me.txtBUN.Name = "txtBUN"
        Me.txtBUN.Size = New System.Drawing.Size(2, 26)
        Me.txtBUN.TabIndex = 20
        '
        'LblBUN
        '
        Me.LblBUN.AutoSize = True
        Me.LblBUN.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBUN.Location = New System.Drawing.Point(415, 11)
        Me.LblBUN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBUN.Name = "LblBUN"
        Me.LblBUN.Size = New System.Drawing.Size(118, 24)
        Me.LblBUN.TabIndex = 19
        Me.LblBUN.Text = "分類区分："
        '
        'txtHINMEI
        '
        Me.txtHINMEI.AutoSize = True
        Me.txtHINMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtHINMEI.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHINMEI.Location = New System.Drawing.Point(180, 11)
        Me.txtHINMEI.Name = "txtHINMEI"
        Me.txtHINMEI.Size = New System.Drawing.Size(2, 26)
        Me.txtHINMEI.TabIndex = 18
        '
        'LblHINMEI
        '
        Me.LblHINMEI.AutoSize = True
        Me.LblHINMEI.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblHINMEI.Location = New System.Drawing.Point(103, 11)
        Me.LblHINMEI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblHINMEI.Name = "LblHINMEI"
        Me.LblHINMEI.Size = New System.Drawing.Size(70, 24)
        Me.LblHINMEI.TabIndex = 17
        Me.LblHINMEI.Text = "品名："
        '
        'btnTOJIRU
        '
        Me.btnTOJIRU.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTOJIRU.Location = New System.Drawing.Point(12, 7)
        Me.btnTOJIRU.Name = "btnTOJIRU"
        Me.btnTOJIRU.Size = New System.Drawing.Size(75, 36)
        Me.btnTOJIRU.TabIndex = 21
        Me.btnTOJIRU.Text = "閉じる"
        Me.btnTOJIRU.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnTOJIRU)
        Me.Controls.Add(Me.txtBUN)
        Me.Controls.Add(Me.LblBUN)
        Me.Controls.Add(Me.txtHINMEI)
        Me.Controls.Add(Me.LblHINMEI)
        Me.Controls.Add(Me.DataGridView2)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtBUN As Label
    Friend WithEvents LblBUN As Label
    Friend WithEvents txtHINMEI As Label
    Friend WithEvents LblHINMEI As Label
    Friend WithEvents btnTOJIRU As Button
End Class
