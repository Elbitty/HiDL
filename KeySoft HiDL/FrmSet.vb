Imports System.IO
Imports System.Net
Imports KeySoft_HiDL.Process
Imports KeySoft_HiDL.Engine

Public Class FrmSet
    Const Clearance As Byte = 86

    Private Sub BtnFile_Click(sender As Object, e As EventArgs) Handles BtnFile.Click

#Region "파일 열기"

        Try
            OpFDiagimg.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End

        End Try

        strImgFilePathes = OpFDiagimg.FileNames

        Try
            fileNo = strImgFilePathes.Length
            If (fileNo <= 0) Then Exit Sub

            totaLimgs = fileNo
            Debug.Print(totaLimgs.ToString)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End

        End Try

#End Region

#Region "변수 설정"

        FrmViewDesign.Margins = Convert.ToUInt16(NumUDimgGap.Value)
        FrmViewDesign.Widthes = Convert.ToUInt16(NumUDimgWidth.Value)
        FrmViewDesign.RollCount = Convert.ToUInt16(NumUDimgRepeat.Value)

        If TxtBGColor.Text = "Transparent" Then
            FrmView.TransparencyKey = Color.White
            FrmViewDesign.StrTmpColorCode = "ffffff"
        Else
            FrmViewDesign.StrTmpColorCode = TxtBGColor.Text
        End If

        FrmView.Height = Convert.ToInt32(FrmViewDesign.Widthes * 0.5625 + FrmViewDesign.Margins + Clearance)
        FrmView.Width = Convert.ToInt32(FrmViewDesign.Widthes + FrmViewDesign.Margins + Clearance)

#End Region

#Region "<body> 내용 이미지 태깅"

        Dim StrTempHTMLCodes As String
        Dim StrTempForReplaceDriveLetters As String

        For jRollCountLoopCount As Integer = 1 To FrmViewDesign.RollCount Step +1
            For i As Integer = 0 To (fileNo - 1) Step +1

                StrTempForReplaceDriveLetters = strImgFilePathes(i)
                StrTempForReplaceDriveLetters = StrTempForReplaceDriveLetters.Replace("\", "/")
                StrTempForReplaceDriveLetters = StrTempForReplaceDriveLetters.Replace(":", "|")

                StrTempHTMLCodes = "<div>" & Environment.NewLine &
                         "	<img src=""file:///" & StrTempForReplaceDriveLetters & """ alt=""""/>" & Environment.NewLine &
                         "</div>" & Environment.NewLine

                Debug.Print(StrTempHTMLCodes)

                halfStr = halfStr & Environment.NewLine & StrTempHTMLCodes
            Next

        Next

        Debug.Print(halfStr)

#End Region

#Region "메인 폼 출력"

        FrmView.Show()
        Me.Close()

#End Region

    End Sub

    Private Function CheckLeftside([String] As String, Separator As Char) As String
        If [String].Substring(0, 1) = Separator.ToString Then Return [String].Substring(1, [String].Length - 1)
        Return [String]
    End Function

    Private Function CheckLeftside([String] As String, Separator As String) As String
        If [String].Substring(0, Separator.Length) = Separator Then Return [String].Substring(Separator.Length, [String].Length - Separator.Length)
        Return [String]
    End Function

    Private Function SplitFastly(Expression As String, Delimiter As Char, Optional Number As Integer = 0) As String
        Return (Expression.Split(Delimiter)(Number + 1)).Split(Delimiter)(0)
    End Function


    Private Sub BtnWeb_Click(sender As Object, e As EventArgs) Handles BtnWeb.Click

#Region "주소 자르고 합쳐 가공"

        Dim FileCode As String = InputBox("Code", "Input Code")   '갤러리 번호를 입력받은 후 가공하기 전 변수.

        If FileCode = String.Empty Then Exit Sub

        FileCode = CheckLeftside(FileCode, "/"c)

#End Region

#Region "파일 유무 확인 및 온라인 접근을 통해 제목 받아오기"

        Dim folderDir As String
        Dim infoFile As String = FileProcess.AppPath & "\" & FileCode & ".txt"
        Dim strTitle As String                 '폴더의 제목
        Dim isFileExists As Boolean


        If (File.Exists(infoFile) = False) Then
            isFileExists = False

            Dim strTmpHtml As String = "https://hitomi.la/reader/" & FileCode & ".html"

            Try

                Dim wReq As HttpWebRequest = CType(WebRequest.Create(strTmpHtml), HttpWebRequest)
                wReq.UserAgent = "Mozilla/5.0 () AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2300.0 Safari/537.36"
                Debug.Print(wReq.UserAgent)

                Dim wResp As HttpWebResponse = CType(wReq.GetResponse(), HttpWebResponse)

                Dim streamResponse As Stream = wResp.GetResponseStream()

                Using streamRead As New StreamReader(streamResponse)
                    strTitle = streamRead.ReadToEnd()
                    streamRead.Close()

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "가져오기 실패", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            strTitle = StringProcess.SplitByString(strTitle, "<title>", "</title>", 0)

            If (strTitle.Split("|"c).Length - 1) > 0 Then

                Dim strDelemeter As String

                strDelemeter = strTitle.Split("|"c)(strTitle.Split("|"c).Length - 1)
                strTitle = StringProcess.SplitByString(strTitle, "|" & strDelemeter)(0)

            End If

            strTitle = FileProcess.DeAbstract(strTitle)
            strTitle = strTitle.Trim

        Else
            isFileExists = True
            strTitle = FileEngine.OpenTextFile(infoFile, System.Text.Encoding.UTF8) '읽은 파일 모두 할당
        End If

        folderDir = FileProcess.AppPath & "\" & FileCode & " " & strTitle

#End Region

#Region "파일명 색인 파일 존재하지 않을 시 받아오기 및 오픈."

        If (isFileExists = False) Then

            Try
                Dim saveFile = New StreamWriter(infoFile, False, System.Text.Encoding.UTF8)
                saveFile.Write(strTitle) '파일 쓰기
                saveFile.Close()

                Directory.CreateDirectory(folderDir)

                Dim WebCl As WebClient = New WebClient
                WebCl.DownloadFile("https://ltn.hitomi.la/galleries/" & FileCode & ".js", folderDir & "\" & FileCode & ".js")

            Catch ex As Exception

            End Try
        End If

        Dim strJSONcontent As String = String.Empty                       'strJSONcontent 변수는 받아온 웹상의 내용임.

        If (isFileExists = False) Then
            strJSONcontent = FileEngine.OpenTextFile((folderDir & "\" & FileCode & ".js"), System.Text.Encoding.UTF8) '읽은 파일 모두 할당
        End If

#End Region

#Region "JSON 파싱"

        Dim strFileNames() As String            '파일 이름

        Dim countOfMain As Integer      'JSON에서 [] 안쪽 내용인 Main의 갯수.
        Dim countOfSub As Integer       'JSON에서 {} 안쪽 내용인 Sub의 갯수.

#Region "없으면"
        If (isFileExists = False) Then

            strJSONcontent = strJSONcontent.Replace(" ", "")

            countOfMain = strJSONcontent.Split("["c).Length - 1

            If countOfMain > 0 Then         'JSON에서 [] 안쪽 내용인 Main을 찾는다. 이 항목이 1개 이상일 경우 코드 실행.

                strJSONcontent = strJSONcontent.Split("["c)(1)
                strJSONcontent = strJSONcontent.Split("]"c)(0)

                countOfSub = strJSONcontent.Split("{"c).Length - 1

                ReDim strFileNames(countOfSub)

                If strJSONcontent.Substring(0, 1) = "{" Then
                    strJSONcontent = "}," & strJSONcontent
                End If

                If strJSONcontent.Substring((strJSONcontent.Length - 1), 1) = "}" Then
                    strJSONcontent = strJSONcontent & ",{"
                End If

            Else
                ReDim strFileNames(0)               'null 참조 예외 방지.
            End If

            Debug.Print(strJSONcontent)

            Try                             'JSON에서 {} 안쪽 내용인 Sub를 Parse한다.

                For i As Integer = 1 To countOfSub Step +1

                    strFileNames(i) = StringProcess.SplitByString(strJSONcontent, "},{")(i)
                    strFileNames(i) = StringProcess.SplitByString(strFileNames(i), """name"":""")(1)
                    strFileNames(i) = strFileNames(i).Split(""""c)(0)
                    Debug.Print(strFileNames(i))

                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Parse 실패", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

#End Region

#Region "파일이 없으면 다운로드"

            Dim saveFile2 As StreamWriter = New StreamWriter(infoFile, False, System.Text.Encoding.UTF8)
            saveFile2.Write(strTitle) '파일 쓰기
            saveFile2.Close()

            folderDir = FileProcess.AppPath() & "\" & FileCode & " " & strTitle

            Debug.Print(folderDir)

            Directory.CreateDirectory(folderDir)

            Dim WebCl2 As WebClient = New WebClient

            For i As Integer = 1 To countOfSub Step +1
                WebCl2.DownloadFile("https://ba.hitomi.la/galleries/" & FileCode & "/" & strFileNames(i), folderDir & "\" & strFileNames(i))

            Next
            WebCl2.Dispose()

#End Region

#Region "파일 MIMETYPE 확인 후 확장자 변경"

            Dim NewNameOfImageFiles(countOfSub) As String
            Dim ImageFileList As String = String.Empty

            For i As Integer = 1 To countOfSub Step +1

                If FileProcess.Extension(strFileNames(i)) = FileProcess.ImageType(folderDir & "\" & strFileNames(i)) Then
                    NewNameOfImageFiles(i) = strFileNames(i)
                Else

                    NewNameOfImageFiles(i) = strFileNames(i).Split("."c)(0) & "." & FileProcess.Extension(folderDir & "\" & strFileNames(i))
                    My.Computer.FileSystem.RenameFile(folderDir & "\" & strFileNames(i), NewNameOfImageFiles(i))

                End If

                ImageFileList = ImageFileList & NewNameOfImageFiles(i) & "/"

            Next

#End Region

            Dim saveFile3 As StreamWriter = New StreamWriter(folderDir & "\" & FileCode & ".list", False, System.Text.Encoding.UTF8)
            saveFile3.Write(ImageFileList) '파일 쓰기
            saveFile3.Close()
        End If

#End Region

#Region "파일 읽기 시작"

        Dim TmpStr As String = FileEngine.OpenTextFile((folderDir & "\" & FileCode & ".list"), System.Text.Encoding.UTF8)

        TmpStr = TmpStr.Trim

        countOfSub = 0
        countOfSub = TmpStr.Split("/"c).Length - 1

        totaLimgs = countOfSub
        ReDim strFileNames(countOfSub)

        For i As Integer = 1 To countOfSub Step +1
            strFileNames(i) = TmpStr.Split("/"c)(i - 1)
        Next

#End Region

#Region "변수 설정"

        FrmViewDesign.Margins = Convert.ToUInt16(NumUDimgGap.Value)            '출력할 이미지 간의 Margin 설정.
        FrmViewDesign.Widthes = Convert.ToUInt16(NumUDimgWidth.Value)            '출력할 이미지들의 Width 설정.
        FrmViewDesign.RollCount = Convert.ToUInt16(NumUDimgRepeat.Value)          '이미지를 몇 회 반복하여 출력할 것인가.

        If TxtBGColor.Text = "Transparent" Then
            FrmView.TransparencyKey = Color.White
            FrmViewDesign.StrTmpColorCode = "ffffff"
        Else
            FrmViewDesign.StrTmpColorCode = TxtBGColor.Text
        End If

        FrmView.Height = Convert.ToInt32(FrmViewDesign.Widthes * (Screen.PrimaryScreen.Bounds.Height / Screen.PrimaryScreen.Bounds.Width) + FrmViewDesign.Margins + Clearance)
        FrmView.Width = Convert.ToInt32(FrmViewDesign.Widthes + FrmViewDesign.Margins + Clearance)

#End Region

#Region "<body> 내용 이미지 태깅"

        TmpStr = String.Empty
        Dim tmpTmp As String = String.Empty

        For j As Integer = 1 To FrmViewDesign.RollCount Step +1
            For i As Integer = 1 To countOfSub Step +1

                tmpTmp = folderDir & "\" & strFileNames(i)
                tmpTmp = tmpTmp.Replace("\", "/")
                tmpTmp = tmpTmp.Replace(":", "|")

                TmpStr = "<div>" & Environment.NewLine &
                         "	<img src=""file:///" & tmpTmp & """ />" & Environment.NewLine &
                         "</div>" & Environment.NewLine

                Debug.Print(TmpStr)

                halfStr = halfStr & Environment.NewLine & TmpStr

            Next

        Next
        Debug.Print(halfStr)

#End Region

#Region "HTML 윗쪽 태그"

        Dim fullStr As String = String.Empty

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

        Dim saveFile4 As StreamWriter = New StreamWriter(folderDir & "\" & FileCode & ".html", False, System.Text.Encoding.UTF8)
        saveFile4.Write(fullStr) '파일 쓰기
        saveFile4.Close()

        strHTMLFileDirectory = folderDir & "\" & FileCode & ".html"

#Region "메인 폼 출력"

        FrmView.Show()
        Me.Close()

#End Region

    End Sub

    Private Sub FrmSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NumUDimgWidth.Maximum = (Screen.PrimaryScreen.Bounds.Width)
        NumUDimgWidth.Value = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width / 2.625)

        NumUDimgGap.Maximum = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height / 1.6875)
        NumUDimgGap.Value = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height / 18)
    End Sub

    Private Sub BtnBGColorReset_Click(sender As Object, e As EventArgs) Handles BtnBGColorReset.Click

        With TxtBGColor
            .BackColor = Color.White
            .ForeColor = Color.DarkCyan
            .Text = "Transparent"
        End With

    End Sub

    Private Sub TxtBGColor_Click(sender As Object, e As EventArgs) Handles TxtBGColor.Click

        Dim TmpColor As Color

        ColorDiagBG.ShowDialog()

        TmpColor = ColorDiagBG.Color

        With TxtBGColor
            .BackColor = TmpColor
            .ForeColor = Color.FromArgb(255 - TmpColor.R, 255 - TmpColor.G, 255 - TmpColor.B)
            .Text = System.Drawing.ColorTranslator.ToHtml(TmpColor)
        End With

    End Sub

End Class