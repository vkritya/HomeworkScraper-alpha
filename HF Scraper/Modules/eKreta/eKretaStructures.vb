Module eKretaStructures
    Structure eKretaInstitute
        Dim InstituteID As Long
        Dim InstituteCode As String
        Dim Name As String
        Dim Url As String
        Dim City As String
    End Structure

    Structure eKretaLesson
        Dim LessonID As Long
        Dim StartTime As Date
        Dim EndTime As Date
        Dim SubjectName As String
        Dim ClassRoom As String
        Dim Teacher As String
        Dim TeacherHomeworkID As Long
        Dim IsTanuloHaziFeladatEnabled As Boolean
    End Structure

    Structure eKretaHomework
        Dim ID As Long
        Dim Tantargy As String
        Dim Rogzito As String
        Dim Oraszam As Long
        Dim TanitasiOraId As Long
        Dim Szoveg As String
        Dim FeladasDatuma As Date
        Dim Hatarido As Date
        Dim IsTanuloHaziFeladatEnabled As Boolean
        Dim StudentHomeworks As List(Of StudentHomework) 'Kommentek

        Public Sub New(homework As Common.Struct.Homework) 'Only for sendhomework
            ID = homework.HomeworkID
            Tantargy = homework.Subject
            Rogzito = homework.Sender
            Szoveg = homework.HomeworkText
            FeladasDatuma = homework.myDate
            Hatarido = homework.myDeadlineDate
        End Sub
    End Structure
    Structure StudentHomework '= Komment
        Dim Id As Long
        Dim TanuloNev As String
        Dim FeladasDatuma As Date
        Dim FeladatSzovege As String
        Dim RogzitoId As Long
    End Structure

    Structure eKretaMessage
        Dim ID As Long
        Dim isRead As Boolean

        Dim MessageID As Long
        Dim myDate As Date
        Dim SenderName As String
        Dim SenderTitle As String
        Dim MessageBody As String
        Dim MessageSubject As String

        Dim Files As List(Of eKretaFajl)
    End Structure
    Structure eKretaFajl
        Dim azonosito As Long
        Dim fajlNev As String
    End Structure

End Module
