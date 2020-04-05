Public Module eKretaStructures

    Class eKretaMainDataContainer
        Dim myInstitute As Institute

        Private myLessons As Dictionary(Of ULong, Lesson)
        Function AddLessons(lessons As List(Of Lesson)) As List(Of Lesson)
            For Each lesson In lessons
                If myLessons.ContainsKey(lesson.LessonID) Then
                    myLessons.Remove(lesson.LessonID)
                End If
                myLessons.Add(lesson.LessonID, lesson)
            Next
            Return myLessons.Values.ToList
        End Function
        Function getLessons() As List(Of Lesson)
            Return myLessons.Values.ToList
        End Function

        Private myHomeworks As Dictionary(Of ULong, Homework)
        Function AddHomeworks(homeworks As List(Of Homework)) As List(Of Homework)
            For Each homework In homeworks
                If myHomeworks.ContainsKey(homework.ID) Then
                    myHomeworks.Remove(homework.ID)
                End If
                myHomeworks.Add(homework.ID, homework)
            Next
            Return myHomeworks.Values.ToList
        End Function
        Function getHomeworks() As List(Of Homework)
            Return myHomeworks.Values.ToList
        End Function

        Private myMessages As Dictionary(Of ULong, Message)
        Function AddMessages(messages As List(Of Message)) As List(Of Message)
            For Each message In messages
                If myMessages.ContainsKey(message.ID) Then
                    myMessages.Remove(message.ID)
                End If
                myMessages.Add(message.ID, message)
            Next
            Return myMessages.Values.ToList
        End Function
        Function getMessages() As List(Of Message)
            Return myMessages.Values.ToList
        End Function
    End Class

    Structure Institute
        Dim InstituteID As ULong
        Dim InstituteCode As String
        Dim Name As String
        Dim Url As String
        Dim City As String
    End Structure

    Structure Lesson
        Dim LessonID As ULong
        Dim StartTime As Date
        Dim EndTime As Date
        Dim SubjectName As String
        Dim ClassRoom As String
        Dim Teacher As String
        Dim TeacherHomeworkID As ULong
        Dim IsTanuloHaziFeladatEnabled As Boolean
    End Structure

    Structure Homework
        Dim ID As ULong
        Dim Tantargy As String
        Dim Rogzito As String
        Dim Oraszam As ULong
        Dim TanitasiOraId As ULong
        Dim Szoveg As String
        Dim FeladasDatuma As Date
        Dim Hatarido As Date
        Dim IsTanuloHaziFeladatEnabled As Boolean
        Dim StudentHomeworks As List(Of StudentHomework) 'Kommentek
    End Structure
    Structure StudentHomework '= Komment
        Dim Id As ULong
        Dim TanuloNev As String
        Dim FeladasDatuma As Date
        Dim FeladatSzovege As Date
        Dim RogzitoId As ULong
    End Structure

    Structure Message
        Dim ID As ULong
        Dim isRead As Boolean

        Dim MessageID As ULong
        Dim myDate As Date
        Dim SenderName As String
        Dim SenderTitle As String
        Dim MessageBody As String
        Dim MessageSubject As String

        Dim Files As List(Of Fajl)
    End Structure
    Structure Fajl
        Dim azonosito As ULong
        Dim fajlNev As String
    End Structure

End Module
