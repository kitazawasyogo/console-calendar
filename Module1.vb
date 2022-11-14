Public Module Module1

    Public Sub Main()

        Dim current As New DisplayCurrentTime
        current.ShowCurrentTime()

        Dim display As New DisplayDays
        display.ShowOneMonth()

        Console.ReadKey()

    End Sub
End Module
