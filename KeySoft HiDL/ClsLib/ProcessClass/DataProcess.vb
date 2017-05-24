Imports System.Text

Namespace Process

    Class DataProcess

        ''' <summary>
        ''' Return the HTML Color Code.
        ''' </summary>
        ''' <param name="Color">Color to Convert to HTML color code. </param>
        ''' 
        Shared Function ColorCode(ByVal Color As Color) As String

            Dim tmpColor As String

            If Convert.ToString(RGB(Color.R, Color.G, Color.B), 16).Length >= 6 Then

                tmpColor = Convert.ToString(RGB(Color.R, Color.G, Color.B), 16)
            Else

                tmpColor = Convert.ToString(RGB(Color.R, Color.G, Color.B), 16)
                While (tmpColor.Length < 6)
                    tmpColor = "0" & tmpColor
                End While

            End If

            Return tmpColor

        End Function

    End Class

End Namespace
