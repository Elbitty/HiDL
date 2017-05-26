Imports KeySoft_HiDL.Process

Public Class FrmView

    Private Sub FrmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#Region "HTML 윗쪽 태그"

        Dim fullStr As String

        fullStr = "<!DOCTYPE html>" & Environment.NewLine &
            "<html lang=""ko"">" & Environment.NewLine &
            "<head>" & Environment.NewLine &
            "<meta charset=""utf-8"">" & Environment.NewLine &
            "<title>HiDL</title>" & Environment.NewLine &
            Environment.NewLine &
            "<style type=""text/css"">" & Environment.NewLine &
            "body {" & Environment.NewLine &
            "   margin-top:0px;" & Environment.NewLine &
            "   margin-bottom:" & Convert.ToString(Convert.ToInt32(FrmViewDesign.Margins / 2)) & "px;" & Environment.NewLine &
            "   background-color: #" & FrmViewDesign.StrTmpColorCode & ";" & Environment.NewLine &
            "}" & Environment.NewLine &
            "div {" & Environment.NewLine &
            "   text-align:center;" & Environment.NewLine &
            "   vertical-align:middle;" & Environment.NewLine &
            "   margin-top:" & Convert.ToString(Convert.ToInt32(FrmViewDesign.Margins / 2)) & "px;" & Environment.NewLine &
            "   margin-bottom:" & Convert.ToString(FrmViewDesign.Margins) & "px;" & Environment.NewLine &
            "}" & Environment.NewLine &
            "img {" & Environment.NewLine &
            "   max-width:100%;" & Environment.NewLine &
            "   width:" & Convert.ToString(FrmViewDesign.Widthes) & "px;" & Environment.NewLine &
            "   height:auto;" & Environment.NewLine &
            "}" & Environment.NewLine &
            "</style>" & Environment.NewLine &
            Environment.NewLine &
            "</head>" & Environment.NewLine &
            "<body>" & Environment.NewLine

#End Region

#Region "HTML 본문 및 아랫쪽 태그"

        fullStr = fullStr & halfStr
        Debug.Print(fullStr)

#End Region

#Region "HTML 본문 및 아랫쪽 태그"

        fullStr = fullStr & Environment.NewLine &
                "</body>" & Environment.NewLine &
                "</html>" & Environment.NewLine

        Debug.Print("MainCode:")
        Debug.Print(fullStr)

#End Region

        Me.Hide()

#Region "완성된 태그 출력."

        WBimgView.Navigate("about:blank")
        WBimgView.DocumentText = (fullStr)
        WBimgView.Refresh()

#End Region

#Region "로딩 상황"

        FrmSet.PgBarTotl.Maximum = totaLimgs

        Dim tmpChar As String = String.Empty

        Do Until WBimgView.ReadyState = WebBrowserReadyState.Complete
            Tmpi = Tmpi + 1

            Debug.Print(Convert.ToString(Tmpi))
            Debug.Print(WBimgView.StatusText)

            Application.DoEvents()

            tmpChar = WBimgView.StatusText

            If (((tmpChar.Split("("c).Length - 1) > 0) And ((tmpChar.Split(")"c).Length - 1) > 0)) Then

                tmpChar = tmpChar.Split("("c)(1)
                tmpChar = tmpChar.Split(")"c)(0)
                tmpChar = tmpChar.Replace(".", "")

                Status = Convert.ToInt32(StringProcess.GetNumeric(tmpChar))

                Debug.Print(StringProcess.GetNumeric(tmpChar))

                FrmSet.PgBarTotl.Value = (totaLimgs - Status + 1)
                Debug.Print(FrmSet.PgBarTotl.Value.ToString)
                Application.DoEvents()

            End If

        Loop

#End Region

    End Sub

    Private Sub WBimgView_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WBimgView.DocumentCompleted

        Me.Show()                       '레이아웃 완성되면 폼 표시.

    End Sub

End Class