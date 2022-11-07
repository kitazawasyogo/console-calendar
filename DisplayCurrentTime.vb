''' <summary>
''' 現在日時表示クラス
''' </summary>
Public Class DisplayCurrentTime

    ''' <summary>
    ''' 現在日時の表示
    ''' </summary>
    Public Sub ShowCurrentTime()

        Dim time As DateTime = DateTime.Now

        Dim moji As String = ("現在日時：")
        Dim hyoji As String = time.ToString("yyyy/MM/dd HH:mm:ss")

        Console.WriteLine(moji & hyoji)

    End Sub
End Class
