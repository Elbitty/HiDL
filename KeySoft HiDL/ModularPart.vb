Public Structure DesignOfForm

    Public Widthes As UShort
    Public Margins As UShort
    Public RollCount As Integer
    Public StrTmpColorCode As String

End Structure


Module ModularPart

    Public FrmViewDesign As DesignOfForm = New DesignOfForm

#Region "전역 변수 선언"

    Public strImgFilePathes() As String

    Public fileNo As Integer

    Public halfStr As String

    Public Tmpi As Integer
    Public Status As Integer
    Public totaLimgs As Integer
    Public strHTMLFileDirectory As String
#End Region

End Module