Imports System.IO

Namespace Process

    Class FileProcess

        ''' <summary>
        ''' Return the startup path of Application. 
        ''' </summary>
        ''' 
        Shared ReadOnly Property AppPath() As String
            Get
                If Directory.GetCurrentDirectory.Substring(0, Directory.GetCurrentDirectory.Length - 1) = "\" Then
                    Return Directory.GetCurrentDirectory.Substring(0, Directory.GetCurrentDirectory.Length - 1)
                Else
                    Return Directory.GetCurrentDirectory
                End If
            End Get
        End Property

        ''' <summary>
        '''  Return whether the file is in use.
        ''' </summary>
        ''' <param name="FilePath">File to check whether is in use.</param>
        ''' 
        Shared Function IsInUse(ByVal FilePath As String) As Boolean
            If File.Exists(FilePath) Then
                Try
                    Using f As New FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                        f.Dispose()
                        Return False
                    End Using
                Catch
                    Return True
                End Try
            End If
            Return True
        End Function

        ''' <summary>
        ''' Get the image extension(MIMEType) from the image.
        ''' </summary>
        ''' <param name="Image ">Image to get the appropriate extension.</param>
        ''' 
        Shared Function ImageType(ByVal Image As System.Drawing.Image) As String
            If System.Drawing.Imaging.ImageFormat.Jpeg.Equals(Image.RawFormat) Then
                Image.Dispose()
                Return "jpg"
            ElseIf System.Drawing.Imaging.ImageFormat.Png.Equals(Image.RawFormat) Then
                Image.Dispose()
                Return "png"
            ElseIf System.Drawing.Imaging.ImageFormat.Gif.Equals(Image.RawFormat) Then
                Image.Dispose()
                Return "gif"
            ElseIf System.Drawing.Imaging.ImageFormat.Bmp.Equals(Image.RawFormat) Then
                Image.Dispose()
                Return "bmp"
            ElseIf System.Drawing.Imaging.ImageFormat.Tiff.Equals(Image.RawFormat) Then
                Image.Dispose()
                Return "tiff"
            Else
                Image.Dispose()
                Return ""
            End If
            'Image.Dispose()
        End Function

        ''' <summary>
        ''' Get the image extension(MIMEType) from the image file.
        ''' </summary>
        ''' <param name="FilePath">File to get the appropriate extension.</param>
        ''' 
        Shared Function ImageType(ByVal FilePath As String) As String
            Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(FilePath)
            If System.Drawing.Imaging.ImageFormat.Jpeg.Equals(fullSizeImg.RawFormat) Then
                fullSizeImg.Dispose()
                Return "jpg"
            ElseIf System.Drawing.Imaging.ImageFormat.Png.Equals(fullSizeImg.RawFormat) Then
                fullSizeImg.Dispose()
                Return "png"
            ElseIf System.Drawing.Imaging.ImageFormat.Gif.Equals(fullSizeImg.RawFormat) Then
                fullSizeImg.Dispose()
                Return "gif"
            ElseIf System.Drawing.Imaging.ImageFormat.Bmp.Equals(fullSizeImg.RawFormat) Then
                fullSizeImg.Dispose()
                Return "bmp"
            ElseIf System.Drawing.Imaging.ImageFormat.Tiff.Equals(fullSizeImg.RawFormat) Then
                fullSizeImg.Dispose()
                Return "tiff"
            Else
                fullSizeImg.Dispose()
                Return ""
            End If
            'fullSizeImg.Dispose()
            'Return TypeOfImage
        End Function

        ''' <summary>
        ''' Get the file extension which is written in the file name.
        ''' </summary>
        ''' <param name="FilePath">File to get the current extension.</param>
        ''' 
        Shared Function Extension(ByVal FilePath As String) As String

            Dim TmpStr As String = String.Empty

            For i As Integer = (FilePath.Length - 1) To 1 Step -1
                If FilePath.Substring(i, 1) = "." Then
                    TmpStr = FilePath.Substring(i, FilePath.Length - i)
                    Exit For
                End If
            Next
            If TmpStr = String.Empty Then TmpStr = FilePath

            Return TmpStr.Substring(1, TmpStr.Length - 1)

        End Function

        ''' <summary>
        ''' Remove abstract character in String, which cannot use in File / Folder's name.
        ''' </summary>
        ''' <param name="[String]">Expression string to replaced.</param>
        ''' <param name="ToReplace">String to Replace abstract. Default value is 'NullString'</param>
        ''' 
        Shared Function DeAbstract(ByVal [String] As String, Optional ByVal ToReplace As String = Nothing) As String

            With [String]
                [String] = .Replace("\", ToReplace)
                [String] = .Replace("/", ToReplace)
                [String] = .Replace(":", ToReplace)
                [String] = .Replace("*", ToReplace)
                [String] = .Replace("?", ToReplace)
                [String] = .Replace("""", ToReplace)
                [String] = .Replace("<", ToReplace)
                [String] = .Replace(">", ToReplace)
                [String] = .Replace("|", ToReplace)
            End With
            '\/:*?"<>|
            Return [String]

        End Function

        Shared Function Replacer(ByVal [String] As String, ByVal From As String, Optional ByVal [To] As String = Nothing) As String
            'If From.Length <> [To].Length Then Throw New System.Exception()
            Dim TmpStr As String = [String]
            For i As Integer = 0 To From.Length - 1 Step +1
                TmpStr = TmpStr.Replace(From.Substring(i, 1), [To].Substring(i, 1))
            Next
            Return TmpStr
        End Function

    End Class

End Namespace

