<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSet
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GrBxDesign = New System.Windows.Forms.GroupBox()
        Me.TxtBGColor = New System.Windows.Forms.TextBox()
        Me.NumUDimgRepeat = New System.Windows.Forms.NumericUpDown()
        Me.NumUDimgGap = New System.Windows.Forms.NumericUpDown()
        Me.NumUDimgWidth = New System.Windows.Forms.NumericUpDown()
        Me.BtnBGColorReset = New System.Windows.Forms.Button()
        Me.LblBGColor = New System.Windows.Forms.Label()
        Me.LblimgRepeat = New System.Windows.Forms.Label()
        Me.LblimgWidth = New System.Windows.Forms.Label()
        Me.LblimgGap = New System.Windows.Forms.Label()
        Me.BtnFile = New System.Windows.Forms.Button()
        Me.ColorDiagBG = New System.Windows.Forms.ColorDialog()
        Me.OpFDiagimg = New System.Windows.Forms.OpenFileDialog()
        Me.BtnWeb = New System.Windows.Forms.Button()
        Me.PgBarTotl = New System.Windows.Forms.ProgressBar()
        Me.GrBxDesign.SuspendLayout()
        CType(Me.NumUDimgRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUDimgGap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUDimgWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrBxDesign
        '
        Me.GrBxDesign.Controls.Add(Me.TxtBGColor)
        Me.GrBxDesign.Controls.Add(Me.NumUDimgRepeat)
        Me.GrBxDesign.Controls.Add(Me.NumUDimgGap)
        Me.GrBxDesign.Controls.Add(Me.NumUDimgWidth)
        Me.GrBxDesign.Controls.Add(Me.BtnBGColorReset)
        Me.GrBxDesign.Controls.Add(Me.LblBGColor)
        Me.GrBxDesign.Controls.Add(Me.LblimgRepeat)
        Me.GrBxDesign.Controls.Add(Me.LblimgWidth)
        Me.GrBxDesign.Controls.Add(Me.LblimgGap)
        Me.GrBxDesign.Location = New System.Drawing.Point(13, 9)
        Me.GrBxDesign.Margin = New System.Windows.Forms.Padding(4)
        Me.GrBxDesign.Name = "GrBxDesign"
        Me.GrBxDesign.Padding = New System.Windows.Forms.Padding(4)
        Me.GrBxDesign.Size = New System.Drawing.Size(350, 147)
        Me.GrBxDesign.TabIndex = 0
        Me.GrBxDesign.TabStop = False
        Me.GrBxDesign.Text = "디자인"
        '
        'TxtBGColor
        '
        Me.TxtBGColor.BackColor = System.Drawing.Color.White
        Me.TxtBGColor.ForeColor = System.Drawing.Color.Black
        Me.TxtBGColor.Location = New System.Drawing.Point(96, 114)
        Me.TxtBGColor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBGColor.Name = "TxtBGColor"
        Me.TxtBGColor.ReadOnly = True
        Me.TxtBGColor.Size = New System.Drawing.Size(232, 25)
        Me.TxtBGColor.TabIndex = 4
        Me.TxtBGColor.Text = "ffffff"
        '
        'NumUDimgRepeat
        '
        Me.NumUDimgRepeat.Location = New System.Drawing.Point(97, 82)
        Me.NumUDimgRepeat.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NumUDimgRepeat.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUDimgRepeat.Name = "NumUDimgRepeat"
        Me.NumUDimgRepeat.Size = New System.Drawing.Size(246, 25)
        Me.NumUDimgRepeat.TabIndex = 3
        Me.NumUDimgRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumUDimgGap
        '
        Me.NumUDimgGap.Location = New System.Drawing.Point(97, 51)
        Me.NumUDimgGap.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.NumUDimgGap.Name = "NumUDimgGap"
        Me.NumUDimgGap.Size = New System.Drawing.Size(246, 25)
        Me.NumUDimgGap.TabIndex = 2
        Me.NumUDimgGap.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'NumUDimgWidth
        '
        Me.NumUDimgWidth.Location = New System.Drawing.Point(97, 20)
        Me.NumUDimgWidth.Maximum = New Decimal(New Integer() {2560, 0, 0, 0})
        Me.NumUDimgWidth.Minimum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumUDimgWidth.Name = "NumUDimgWidth"
        Me.NumUDimgWidth.Size = New System.Drawing.Size(246, 25)
        Me.NumUDimgWidth.TabIndex = 1
        Me.NumUDimgWidth.ThousandsSeparator = True
        Me.NumUDimgWidth.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'BtnBGColorReset
        '
        Me.BtnBGColorReset.Location = New System.Drawing.Point(326, 113)
        Me.BtnBGColorReset.Name = "BtnBGColorReset"
        Me.BtnBGColorReset.Size = New System.Drawing.Size(17, 27)
        Me.BtnBGColorReset.TabIndex = 5
        Me.BtnBGColorReset.UseVisualStyleBackColor = True
        '
        'LblBGColor
        '
        Me.LblBGColor.AutoSize = True
        Me.LblBGColor.Location = New System.Drawing.Point(20, 117)
        Me.LblBGColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBGColor.Name = "LblBGColor"
        Me.LblBGColor.Size = New System.Drawing.Size(68, 17)
        Me.LblBGColor.TabIndex = 0
        Me.LblBGColor.Text = "배경 색상"
        '
        'LblimgRepeat
        '
        Me.LblimgRepeat.AutoSize = True
        Me.LblimgRepeat.Location = New System.Drawing.Point(22, 84)
        Me.LblimgRepeat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblimgRepeat.Name = "LblimgRepeat"
        Me.LblimgRepeat.Size = New System.Drawing.Size(68, 17)
        Me.LblimgRepeat.TabIndex = 0
        Me.LblimgRepeat.Text = "반복 횟수"
        '
        'LblimgWidth
        '
        Me.LblimgWidth.AutoSize = True
        Me.LblimgWidth.Location = New System.Drawing.Point(8, 22)
        Me.LblimgWidth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblimgWidth.Name = "LblimgWidth"
        Me.LblimgWidth.Size = New System.Drawing.Size(82, 17)
        Me.LblimgWidth.TabIndex = 0
        Me.LblimgWidth.Text = "이미지 너비"
        '
        'LblimgGap
        '
        Me.LblimgGap.AutoSize = True
        Me.LblimgGap.Location = New System.Drawing.Point(8, 53)
        Me.LblimgGap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblimgGap.Name = "LblimgGap"
        Me.LblimgGap.Size = New System.Drawing.Size(82, 17)
        Me.LblimgGap.TabIndex = 0
        Me.LblimgGap.Text = "이미지 간격"
        '
        'BtnFile
        '
        Me.BtnFile.Font = New System.Drawing.Font("나눔고딕", 11.25!)
        Me.BtnFile.Location = New System.Drawing.Point(13, 164)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(350, 29)
        Me.BtnFile.TabIndex = 6
        Me.BtnFile.Text = "File"
        Me.BtnFile.UseVisualStyleBackColor = True
        '
        'ColorDiagBG
        '
        Me.ColorDiagBG.AnyColor = True
        Me.ColorDiagBG.Color = System.Drawing.Color.White
        Me.ColorDiagBG.FullOpen = True
        '
        'OpFDiagimg
        '
        Me.OpFDiagimg.Filter = "모든 이미지|*.jpeg;*.jpg;*.gif;*.bmp;*.png|JPEG파일|*.jpg;*.jpeg|BMP파일|*.bmp|PNG파일|*.png" &
    "|GIF 이미지|*.gif|모든 파일|*.*"
        Me.OpFDiagimg.Multiselect = True
        Me.OpFDiagimg.Title = "KeySoft PhotoRoll - Open Image"
        '
        'BtnWeb
        '
        Me.BtnWeb.Font = New System.Drawing.Font("나눔고딕", 11.25!)
        Me.BtnWeb.Location = New System.Drawing.Point(13, 201)
        Me.BtnWeb.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnWeb.Name = "BtnWeb"
        Me.BtnWeb.Size = New System.Drawing.Size(350, 29)
        Me.BtnWeb.TabIndex = 7
        Me.BtnWeb.Text = "Web"
        Me.BtnWeb.UseVisualStyleBackColor = True
        '
        'PgBarTotl
        '
        Me.PgBarTotl.Location = New System.Drawing.Point(13, 238)
        Me.PgBarTotl.Name = "PgBarTotl"
        Me.PgBarTotl.Size = New System.Drawing.Size(350, 14)
        Me.PgBarTotl.TabIndex = 8
        '
        'FrmSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 264)
        Me.Controls.Add(Me.PgBarTotl)
        Me.Controls.Add(Me.BtnWeb)
        Me.Controls.Add(Me.BtnFile)
        Me.Controls.Add(Me.GrBxDesign)
        Me.Font = New System.Drawing.Font("나눔고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeySoft PhotoRoll - Setting Panel"
        Me.GrBxDesign.ResumeLayout(False)
        Me.GrBxDesign.PerformLayout()
        CType(Me.NumUDimgRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUDimgGap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUDimgWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrBxDesign As System.Windows.Forms.GroupBox
    Friend WithEvents LblimgGap As System.Windows.Forms.Label
    Friend WithEvents TxtBGColor As System.Windows.Forms.TextBox
    Friend WithEvents LblimgRepeat As System.Windows.Forms.Label
    Friend WithEvents LblimgWidth As System.Windows.Forms.Label
    Friend WithEvents BtnFile As System.Windows.Forms.Button
    Friend WithEvents ColorDiagBG As System.Windows.Forms.ColorDialog
    Friend WithEvents LblBGColor As System.Windows.Forms.Label
    Friend WithEvents OpFDiagimg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents NumUDimgWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUDimgGap As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUDimgRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnWeb As Button
    Friend WithEvents PgBarTotl As ProgressBar
    Friend WithEvents BtnBGColorReset As Button
End Class
