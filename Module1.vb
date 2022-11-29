Public Module Module1

    Public Sub Main()

        Dim current As New DisplayCurrentTime
        current.ShowCurrentTime()

        Dim display As New DisplayDays
        display.ShowOneMonth()

        Dim calender As New DisplayCalendar
        calender.ShowCalendar()

        Console.WriteLine()
        Console.WriteLine("終了するには何かキーを押してください...")

        Console.ReadKey()

    End Sub
End Module
