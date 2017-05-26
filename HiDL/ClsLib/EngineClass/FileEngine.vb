Imports System.IO

Namespace Engine

    Public Class FileEngine

        Public Shared Function OpenTextFile(ByVal FilePath As String, ByVal Encoding As System.Text.Encoding) As String

            Dim OpenFile As StreamReader = New StreamReader(FilePath, Encoding)
            Dim TmpStr As String

            TmpStr = OpenFile.ReadToEnd
            OpenFile.Close()

            Return TmpStr

        End Function

    End Class

End Namespace
