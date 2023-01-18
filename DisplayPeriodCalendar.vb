''' <summary>
''' 入力された期間のカレンダー表示クラス
''' </summary>
Public Class DisplayPeriodCalendar

    ''' <summary>
    ''' 指示メッセージ定義
    ''' </summary>
    Private Const PROMPTING_MASSAGE As String = "年月を[yyyy/mm-yyyy/mm]で入力してください"

    ''' <summary>
    ''' 警告メッセージ定義
    ''' </summary>
    Private Const WARNING_MASSAGE As String = "[yyyy/mm-yyyy/mm]のフォーマット外です"


    ''' <summary>
    ''' 期間のカレンダー表示
    ''' </summary>
    Public Sub ShowPeriodCalendar()
        Console.WriteLine(PROMPTING_MASSAGE)

        Dim inputValueDisplay As String = ConfirmInputValue()
        Dim inputValueArray As String() = inputValueDisplay.Split("-"c)
        Dim inputBeginningArray As String() = inputValueArray(0).Split("/"c)
        Dim inputEndArray As String() = inputValueArray(1).Split("/"c)

        Dim inputValueBeginningYear As DateTime = Convert.ToDateTime(inputValueArray(1))
        Dim inputValueEndYear As DateTime = Convert.ToDateTime(inputValueArray(0))

        Dim lastMonth As Integer = inputValueBeginningYear.Month - inputValueEndYear.Month + (12 * (inputValueBeginningYear.Year - inputValueEndYear.Year))

        For flowMonthNumber As Integer = 0 To lastMonth

            Dim inputValueBeginningMonth As String = inputBeginningArray(0) & inputBeginningArray(1)
            Dim yearAndMonth As Integer = Integer.Parse(inputValueBeginningMonth)

            Dim flowOfYearAndMonth As Integer = yearAndMonth + flowMonthNumber
            Dim flowYearAndMonth As String = flowOfYearAndMonth.ToString
            Dim flowOfMonth As String = Strings.Right(flowYearAndMonth, 2)
            Dim flowMonth As Integer = Integer.Parse(flowOfMonth)

            Dim nextYear As Integer
            If 12 < flowMonth Then
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


    ''' <summary>
    ''' 入力値の確認
    ''' </summary>
    ''' <returns></returns>
    Private Function ConfirmInputValue() As String

        Dim inputValue As String = Nothing

        While True

            Try

                inputValue = Console.ReadLine()
                Dim inputValueArray As String() = inputValue.Split("-"c)

                If Not inputValueArray.Length = 2 Then
                    Throw New ArgumentException(WARNING_MASSAGE)
                End If

                Dim inputBeginningArray As String() = inputValueArray(0).Split("/"c)
                Dim inputEndArray As String() = inputValueArray(1).Split("/"c)

                ValidateYearAndMonthValue(inputBeginningArray)
                ValidateYearAndMonthValue(inputEndArray)

                Dim biginningMonth As Integer = Integer.Parse(inputBeginningArray(1))
                Dim endMonth As Integer = Integer.Parse(inputEndArray(1))

                ValidateMonthRangeValue(biginningMonth)
                ValidateMonthRangeValue(endMonth)

                Return inputValue

            Catch ex As ArgumentException
                Console.WriteLine(ex.Message)
                Console.WriteLine(PROMPTING_MASSAGE)
            End Try

        End While

        Return inputValue

    End Function


    ''' <summary>
    ''' yyyy/MMフォーマットチェック
    ''' </summary>
    ''' <param name="checkInputArray"></param>
    ''' <returns></returns>
    Private Function ValidateYearAndMonthValue(checkInputArray As String()) As Boolean

        If Not checkInputArray.Length = 2 OrElse Not IsNumeric(checkInputArray(0)) OrElse Not IsNumeric(checkInputArray(1)) OrElse Not checkInputArray(0).Length = 4 OrElse Not checkInputArray(1).Length = 2 Then
            Throw New ArgumentException(WARNING_MASSAGE)
        End If

        Return True

    End Function


    ''' <summary>
    ''' 月の数値範囲チェック
    ''' </summary>
    ''' <param name="monthValue"></param>
    ''' <returns></returns>
    Private Function ValidateMonthRangeValue(monthValue As Integer) As Boolean

        If 13 <= monthValue OrElse monthValue <= 0 Then
            Throw New ArgumentException("月の入力値が範囲外です")
        End If

        Return True

    End Function
End Class