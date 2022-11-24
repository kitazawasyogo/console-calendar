''' <summary>
''' 入力された月のカレンダー表示クラス
''' </summary>
Public Class DisplayCalendar

    ''' <summary>
    ''' 指示メッセージ定義
    ''' </summary>
    Private Const PROMPTING_MASSAGE As String = "年月を[yyyy/mm]で入力してください"

    ''' <summary>
    ''' 警告メッセージ定義
    ''' </summary>
    Private Const WARNING_MASSAGE As String = "[yyyy/mm]のフォーマット外です"

    ''' <summary>
    ''' 月のカレンダー表示
    ''' </summary>
    Public Sub ShowCalendar()

        Console.WriteLine(PROMPTING_MASSAGE)

        Dim inputValueDisplay As String = ConfirmInputValue()
        Dim inputArray As String() = inputValueDisplay.Split("/"c)

        Dim beginningDay As String = (inputValueDisplay & "/01")
        Dim beginningDt As DateTime = DateTime.Parse(beginningDay)
        Dim beginningWeek As DayOfWeek = beginningDt.DayOfWeek

        Console.Write(Space(beginningWeek * 4))

        Dim daysInMonth As Integer = DateTime.DaysInMonth(Integer.Parse(inputArray(0)), Integer.Parse(inputArray(1)))

        For flowOfDays As Integer = 1 To daysInMonth

            Dim day As String = (inputValueDisplay & flowOfDays.ToString("/00"))
            Dim dt As DateTime = DateTime.Parse(day)

            Console.Write(String.Format("{0, 4}", flowOfDays))
            If dt.DayOfWeek = DayOfWeek.Saturday Then
                Console.WriteLine()
            End If

        Next

    End Sub

    ''' <summary>
    ''' 例外処理と入力値の受け渡し
    ''' </summary>
    ''' <returns></returns>
    Private Function ConfirmInputValue() As String

        Dim inputValue As String = Nothing

        While True

            Try

                inputValue = Console.ReadLine()

                Dim inputArray As String() = inputValue.Split("/"c)

                If Not inputArray.Length = 2 OrElse Not IsNumeric(inputArray(0)) OrElse Not IsNumeric(inputArray(1)) OrElse Not inputArray(0).Length = 4 OrElse Not inputArray(1).Length = 2 Then
                    Throw New ArgumentException
                Else
                    Return inputValue
                End If

            Catch ex As ArgumentException
                Console.WriteLine(WARNING_MASSAGE)
            End Try

        End While

    End Function
End Class
