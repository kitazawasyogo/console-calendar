Public Module Module1

    Public Sub Main()

        While True

            Console.WriteLine("実行可能なコマンド")
            Console.WriteLine("1：現在日時の表示")
            Console.WriteLine("2：月ごとの日数表示")
            Console.WriteLine("3：カレンダー表示(1月分)")
            Console.WriteLine("4：カレンダー表示(期間)")
            Console.WriteLine("exit：カレンダー表示アプリを終了します")
            Console.Write("コマンドを入力してください：")

            Dim inputValue As String = Console.ReadLine()
            Console.WriteLine()

            If inputValue.Equals("1") Then
                Dim current As New DisplayCurrentTime
                current.ShowCurrentTime()
            ElseIf inputValue.Equals("2") Then
                Dim display As New DisplayDays
                display.ShowOneMonth()
            ElseIf inputValue.Equals("3") Then
                Dim calender As New DisplayCalendar
                calender.ShowCalendar()
            ElseIf inputValue.Equals("4") Then
                Dim periodcalendar As New DisplayPeriodCalendar
                periodcalendar.ShowPeriodCalendar()
            ElseIf inputValue.Equals("exit") Then
                Exit While
            Else
                Console.WriteLine("対応するコマンドがありませんでした")
            End If

        End While

        Console.WriteLine()
        Console.WriteLine("終了するには何かキーを押してください...")

        Console.ReadKey()

    End Sub
End Module