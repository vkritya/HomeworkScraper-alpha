Public Module eKretaStructures
    Structure eKretaInstitute
        Dim InstituteID As ULong
        Dim InstituteCode As String
        Dim Name As String
        Dim Url As String
        Dim City As String
    End Structure

    Structure eKretaLesson
        Dim LessonID As ULong
        Dim StartTime As Date
        Dim EndTime As Date
        Dim SubjectName As String
        Dim ClassRoom As String
        Dim Teacher As String
        Dim TeacherHomeworkID As ULong
        Dim IsTanuloHaziFeladatEnabled As Boolean
    End Structure

    Structure eKretaHomework
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
        Dim FeladatSzovege As String
        Dim RogzitoId As ULong
    End Structure

    Structure eKretaMessage
        Dim ID As ULong
        Dim isRead As Boolean

        Dim MessageID As ULong
        Dim myDate As Date
        Dim SenderName As String
        Dim SenderTitle As String
        Dim MessageBody As String
        Dim MessageSubject As String

        Dim Files As List(Of eKretaFajl)
    End Structure
    Structure eKretaFajl
        Dim azonosito As ULong
        Dim fajlNev As String
    End Structure

End Module
