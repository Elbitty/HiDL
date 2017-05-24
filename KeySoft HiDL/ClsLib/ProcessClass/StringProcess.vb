Imports System.IO
Imports System.Text

Namespace Process

    Class StringProcess

        ''' <summary>
        ''' Return the value of a particular Hangul string divided by the leading, middle, and trailing Hangul characters.
        ''' </summary>
        ''' <param name="Letter">Hangul string to divide.</param>
        ''' 
        Shared Function LastWord(ByVal Letter As String) As Long

            Dim InCode As Integer
            Dim Code As Long
            Dim Last As Long

            InCode = AscW(Letter)
            Code = InCode

            Select Case InCode
                Case -1     'Negative
                    If InCode < &HAC00 Then Return 0
                Case 1, 0   'Else(Positive && Zero)
                    Return 0
            End Select

            Code = Code - &HAC00
            Code = Code Mod (21 * 28) 'Separate the leading from the entire Hangul character and leave only the middle and the trailing. 
            Last = Code Mod 28 'Remove the middle character and leave the trailing.

            Return Last

        End Function

        ''' <summary>
        ''' Split the expression by delimeter string, and returns the array value. 
        ''' </summary>
        ''' <param name="Expression">Expression string to be splitted.</param>
        ''' <param name="Delimeter">Delimeter string to split the expression string.</param>
        ''' 
        Shared Function SplitByString(ByVal Expression As String, ByVal Delimeter As String) As String()
            Dim Offset As Int32
            Dim Index As Int32
            Dim Offsets(Expression.Length) As Integer
            While Index < Expression.Length
                Dim indexOf As Int32
                indexOf = Expression.IndexOf(Delimeter, Index)
                If indexOf <> -1 Then
                    Offsets(Offset) = indexOf
                    Offset = Offset + 1
                    Index = (indexOf + Delimeter.Length)
                Else
                    Index = Expression.Length
                End If
            End While
            Dim Final(Offset) As String
            If Offset = 0 Then
                Final(0) = Expression
            Else
                Offset = Offset - 2
                Final(0) = Expression.Substring(0, Offsets(0))
                Dim iCount As Int32
                For iCount = 0 To Offset
                    Final(iCount + 1) = Expression.Substring(Offsets(iCount) + Delimeter.Length, Offsets(iCount + 1) - Offsets(iCount) - Delimeter.Length)
                Next
                Final(Offset + 2) = Expression.Substring(Offsets(Offset + 1) + Delimeter.Length)
            End If
            Return Final

        End Function

        ''' <summary>
        ''' Split the expression by delimeter string, and returns the array value. 
        ''' </summary>
        ''' <param name="Expression">Expression string to be splitted.</param>
        ''' <param name="Start_Delimeter">Start delimeter string to split the expression string.</param>
        ''' <param name="End_Delimeter">End delimeter string to split the expression string.</param>
        ''' <param name="Number">Nth output.</param>
        ''' 
        Shared Function SplitByString(ByVal Expression As String, ByVal Start_Delimeter As String, ByVal End_Delimeter As String, Optional ByVal Number As Integer = 0) As String
            Return StringProcess.SplitByString(StringProcess.SplitByString(Expression, Start_Delimeter)(Number + 1), End_Delimeter)(0)
        End Function

        ''' <summary>
        ''' Returns the numeric value which is in string. 
        ''' </summary>
        ''' <param name="Expression">String to get numeric value.</param>
        ''' 
        Shared Function GetNumeric(ByVal Expression As String) As String

            Dim output As StringBuilder = New StringBuilder

            For iCount As Integer = 0 To (Expression.Length - 1)
                If IsNumeric(Expression(iCount)) Then output.Append(Expression(iCount))
            Next
            Return output.ToString

        End Function

    End Class

End Namespace