﻿''' <summary>
''' 入力された月のカレンダー表示クラス
''' </summary>
Public Class DisplayCalendar

    ''' <summary>
    ''' 指示メッセージ定義
    ''' </summary>
    Private Const PROMPTING_MASSAGE As String = "年月を[yyyy/mm]で入力してください"

    ''' <summary>
    ''' 月のカレンダー表示
    ''' </summary>
    Public Sub ShowCalendar()

        Console.WriteLine(PROMPTING_MASSAGE)
        Dim inputValue As String = Console.ReadLine()

        Dim inputArray As String() = inputValue.Split("/"c)

        If Not inputArray.Length = 2 OrElse Not IsNumeric(inputArray(0)) OrElse Not IsNumeric(inputArray(1)) Then

            MsgBox(PROMPTING_MASSAGE)
            Return

        End If

        Dim beginningDay As String = (inputValue & "/01")
        Dim beginningDt As DateTime = DateTime.Parse(beginningDay)
        Dim beginningWeek As DayOfWeek = beginningDt.DayOfWeek

        Console.Write(Space(beginningWeek * 4))

        Dim daysInMonth As Integer = DateTime.DaysInMonth(Integer.Parse(inputArray(0)), Integer.Parse(inputArray(1)))

        For flowOfDays As Integer = 1 To daysInMonth

            Dim day As String = (inputValue & flowOfDays.ToString("/00"))
            Dim dt As DateTime = DateTime.Parse(day)

            Console.Write(String.Format("{0, 4}", flowOfDays))
            If dt.DayOfWeek = DayOfWeek.Saturday Then
                Console.WriteLine()
            End If

        Next

    End Sub
End Class