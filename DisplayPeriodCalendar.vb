''' <summary>
''' 入力された期間のカレンダー表示クラス
''' </summary>
Public Class DisplayPeriodCalendar

    ''' <summary>
    ''' 指示メッセージ定義
    ''' </summary>
    Private Const PROMPTING_MASSAGE As String = "年月を[yyyy/mm-yyyy/mm]で入力してください"

    ''' <summary>
    ''' 期間のカレンダー表示
    ''' </summary>
    Public Sub ShowPeriodCalendar()
        Console.WriteLine(PROMPTING_MASSAGE)

        Dim inputValueDisplay As String = ConfirmInputValue()
        Dim inputValueArray As String() = inputValueDisplay.Split("-"c)
        Dim inputBeginningArray As String() = inputValueArray(0).Split("/"c)
        Dim inputEndArray As String() = inputValueArray(1).Split("/"c)

        Dim inputValueBeginningYear As New DateTime
        inputValueBeginningYear = Convert.ToDateTime(inputValueArray(1))

        Dim inputValueEndYear As New DateTime
        inputValueEndYear = Convert.ToDateTime(inputValueArray(0))

        Dim lastMonth As Integer = inputValueBeginningYear.Month - inputValueEndYear.Month + (12 * (inputValueBeginningYear.Year - inputValueEndYear.Year))

        For flowMothNumber As Integer = 0 To lastMonth

            Dim inputValueBeginningMonth As String = inputBeginningArray(0) + inputBeginningArray(1)
            Dim yearAndMonth As Integer = Integer.Parse(inputValueBeginningMonth)

            Dim flowOfYearAndMonth As Integer = yearAndMonth + flowMothNumber
            Dim flowYearAndMonth As String = flowOfYearAndMonth.ToString
            Dim flowOfMonth As String = Strings.Right(flowYearAndMonth, 2)
            Dim flowMonth As Integer = Integer.Parse(flowOfMonth)

            Dim nextYear As Integer = Nothing
            If flowMonth > 12 Then
                nextYear = (flowOfYearAndMonth + 100) - 12
            Else
                nextYear = flowOfYearAndMonth
            End If

            Dim displayYearAndMonth As String = nextYear.ToString("0000/00")
            Console.WriteLine()
            Console.WriteLine("・" & displayYearAndMonth)

            Dim beginningDay As String = (displayYearAndMonth & "/01")
            Dim beginningDt As DateTime = DateTime.Parse(beginningDay)
            Dim beginningWeek As DayOfWeek = beginningDt.DayOfWeek
            Console.Write(Space(beginningWeek * 4))

            Dim year As String = Strings.Left(displayYearAndMonth, 4)
            Dim month As String = Strings.Right(displayYearAndMonth, 2)
            Dim daysInMonth As Integer = DateTime.DaysInMonth(Integer.Parse(year), Integer.Parse(month))

            For flowOfDays As Integer = 1 To daysInMonth

                Dim day As String = (displayYearAndMonth & flowOfDays.ToString("/00"))
                Dim dt As DateTime = DateTime.Parse(day)

                Console.Write(String.Format("{0, 4}", flowOfDays))
                If dt.DayOfWeek = DayOfWeek.Saturday Then
                    Console.WriteLine()
                End If

            Next

        Next
    End Sub


    '' <summary>
    '' 例外処理と入力値の受け渡し
    '' </summary>
    '' <returns></returns>
    Private Function ConfirmInputValue() As String

        Const WARNING_MASSAGE As String = "[yyyy/mm-yyyy/mm]のフォーマット外です"
        Dim inputValue As String = Nothing

        While True

            Try

                inputValue = Console.ReadLine()
                Dim inputValueArray As String() = inputValue.Split("-"c)
                Dim inputBeginningArray As String() = inputValueArray(0).Split("/"c)
                Dim inputEndArray As String() = inputValueArray(1).Split("/"c)

                If Not inputValueArray.Length = 2 Then
                    Throw New ArgumentException
                ElseIf Not inputBeginningArray.Length = 2 OrElse Not IsNumeric(inputBeginningArray(0)) OrElse Not IsNumeric(inputBeginningArray(1)) OrElse Not inputBeginningArray(0).Length = 4 OrElse Not inputBeginningArray(1).Length = 2 Then
                    Throw New ArgumentException
                ElseIf Not inputEndArray.Length = 2 OrElse Not IsNumeric(inputEndArray(0)) OrElse Not IsNumeric(inputEndArray(1)) OrElse Not inputEndArray(0).Length = 4 OrElse Not inputEndArray(1).Length = 2 Then
                    Throw New ArgumentException
                Else
                    Return inputValue
                End If

            Catch ex As ArgumentException
                Console.WriteLine(WARNING_MASSAGE)
                Console.WriteLine(PROMPTING_MASSAGE)
            End Try

        End While

        Return inputValue

    End Function
End Class