<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmView
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
        Me.WBimgView = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WBimgView
        '
        Me.WBimgView.AllowNavigation = False
        Me.WBimgView.AllowWebBrowserDrop = False
        Me.WBimgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WBimgView.IsWebBrowserContextMenuEnabled = False
        Me.WBimgView.Location = New System.Drawing.Point(0, 0)
        Me.WBimgView.Margin = New System.Windows.Forms.Padding(0)
        Me.WBimgView.MinimumSize = New System.Drawing.Size(26, 28)
        Me.WBimgView.Name = "WBimgView"
        Me.WBimgView.Size = New System.Drawing.Size(304, 161)
        Me.WBimgView.TabIndex = 0
        Me.WBimgView.TabStop = False
        Me.WBimgView.Url = New System.Uri("about:blank", System.UriKind.Absolute)
        Me.WBimgView.WebBrowserShortcutsEnabled = False
        '
        'FrmView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 161)
        Me.Controls.Add(Me.WBimgView)
        Me.Font = New System.Drawing.Font("나눔고딕", 11.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeySoft PhotoRoll - View"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WBimgView As System.Windows.Forms.WebBrowser

End Class
