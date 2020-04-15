Namespace Common
    Namespace Constant
        Module GlobalConstants
            Public Const REGEX_YMD As String = "^(2[0-9]{3})[ ,;._/\-\\](0?[1-9]|1[0-2])[ ,;._/\-\\](0?[1-9]|[1-2][0-9]|3[0-1])[ ,;._/\-\\]?$"
            Public Const REGEX_MD As String = "^(0?[1-9]|1[0-2])[ ,;._/\-\\](0?[1-9]|[1-2][0-9]|3[0-1])[ ,;._/\-\\]?$"
            Public Const REGEX_HEX As String = "^#?[0-9a-fA-F]{6}$"
            Public Const FORMAT_YMD As String = "yyyy\/MM\/dd"
            Public Const FORMAT_HMS As String = "HH:mm:ss"
            Public Const FORMAT_YMD_HMS As String = "yyyy\/MM\/dd - HH:mm:ss"
        End Module
    End Namespace
    Namespace Struct
        Enum ServiceType
            eKretaMessage
            eKretaHomework
            eMail
            Facebook
            Messenger
            Classroom
        End Enum

        Structure Message
            Dim Service As ServiceType
            Dim MessageID As ULong

            Dim myDate As Date
            Dim Sender As String
            Dim MessageText As String

            Dim Comments As List(Of Comment)
            Dim Attachment As Object
        End Structure
        Structure Comment
            Dim CommentID As ULong
            Dim myDate As Date

            Dim Sender As String
            Dim CommentText As String

            Dim Attachment As Object
        End Structure

        Structure Homework
            Dim Service As ServiceType
            Dim HomeworkID As ULong

            Dim myDate As Date
            Dim Sender As String
            Dim Subject As String
            Dim HomeworkText As String
            Dim myDeadlineDate As Date

            Dim Comments As List(Of Comment)
            Dim Attachment As Object

            Sub New(fromMessage As Message, deadline As Date, subject As String)
                Service = fromMessage.Service
                HomeworkID = fromMessage.MessageID
                myDate = fromMessage.myDate
                Sender = fromMessage.Sender
                subject = subject
                HomeworkText = fromMessage.MessageText
                myDeadlineDate = deadline
                Comments = fromMessage.Comments
                Attachment = fromMessage.Attachment
            End Sub
        End Structure
    End Namespace
End Namespace