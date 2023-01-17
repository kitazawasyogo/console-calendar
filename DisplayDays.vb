''' <summary>
''' 入力された月の日数表示クラス
''' </summary>
Public Class DisplayDays

    ''' <summary>
    ''' 月の日数表示
    ''' </summary>
    Public Sub ShowOneMonth()

        Dim instructions As String = "年月を[yyyy/mm]で入力してください"

        Console.WriteLine(instructions)

        Dim inputValue As String = Console.ReadLine()

        Dim year As String = Strings.Left(inputValue, 4)
        Dim month As String = Strings.Right(inputValue, 2)

        Dim r As New System.Text.RegularExpressions.Regex("\d\d\d\d/\d\d")

        If Not r.IsMatch(inputValue) Then

            Console.WriteLine(instructions)
            Return

        ElseIf inputValue.Length <> 7 Then

            Console.WriteLine(instructions)
            Return

        End If

        Dim oneMonth As Integer = DateTime.DaysInMonth(Integer.Parse(year), Integer.Parse(month))

        Console.WriteLine(inputValue & "は" & oneMonth & "日までです")

    End Sub
End Class
