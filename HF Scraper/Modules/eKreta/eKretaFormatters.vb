Namespace eKreta.Format
    Module Format
#Region "DateTime"
        Function getDateTime(eKretaTime As String) As DateTime
            Return New DateTime(CInt(eKretaTime.Substring(0, 4)),
                                CInt(eKretaTime.Substring(5, 2)),
                                CInt(eKretaTime.Substring(8, 2)),
                                CInt(eKretaTime.Substring(11, 2)),
                                CInt(eKretaTime.Substring(14, 2)),
                                CInt(eKretaTime.Substring(17, 2)),
                                DateTimeKind.Local)
        End Function
        Function buildDate(dateTime As DateTime) As String
            Return $"{dateTime.Year}. {dateTime.Month}. {dateTime.Day}."
        End Function
        Function buildDate(eKretaTime As String) As String
            Dim dateTime = getDateTime(eKretaTime)
            Return $"{dateTime.Year}. {dateTime.Month}. {dateTime.Day}."
        End Function
        Function buildTime(dateTime As DateTime) As String
            Return String.Format("{0:0}:{1:00}", dateTime.Hour, dateTime.Minute)
        End Function
        Function buildTime(eKretaTime As String) As String
            Dim dateTime = getDateTime(eKretaTime)
            Return String.Format("{0:0}:{1:00}", dateTime.Hour, dateTime.Minute)
        End Function
        Function formatForRequest(dateTime As DateTime) As String
            Return String.Format("{0:0000}-{1:00}-{2:00}", dateTime.Year, dateTime.Month, dateTime.Day)
        End Function
        Function formatDateTime(dateTime As DateTime) As String
            Return String.Format("{0:0000}-{1:00}-{2:00}T{3:00}:{4:00}:{5:00}", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second)
        End Function
#End Region


    End Module
End Namespace
