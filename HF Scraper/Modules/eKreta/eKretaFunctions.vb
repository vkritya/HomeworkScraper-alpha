Imports System.Net
Imports System.Web
Imports Newtonsoft.Json

'TODO:
'    KÉSZ?: HANDLE myToken = ""
'    REMOVE str, make private
'    ADD Other REQUESTS - download attachment
'
'
'
'
'
Namespace eKreta
    Module eKretaFunctions

        Private Const API_KEY = "7856d350-1fda-45f5-822d-e1a2f3f1acf0"
        Private Const TOKEN_TIME_DEADZONE = 120
        Private Const REGISTRY_KEY = "HKEY_CURRENT_USER\Software\HomeWorkScraper"

        Private myTokenValid = DateTime.UtcNow
        Private myToken = ""
        Private myRefreshToken = ""

        Public myInstituteID = 0

        Private Structure Tipus
            Dim azonosito As ULong
            Dim kod As String
            Dim rovidNev As String
            Dim nev As String
            Dim leiras As String
        End Structure

        Async Function Initialize(myMainForm As MainForm) As Task
            'HTTPS
            ServicePointManager.ServerCertificateValidationCallback = New Security.RemoteCertificateValidationCallback(Function(sender As Object, certification As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As Security.SslPolicyErrors) True)

            'instituteId
            myInstituteID = My.Computer.Registry.GetValue(REGISTRY_KEY, "eKreta_InstituteId", Nothing)
            If myInstituteID Is Nothing Then
                Dim myInstitutePicker As New InstitutePicker
                If myInstitutePicker.ShowDialog = DialogResult.OK Then
                    myInstituteID = myInstitutePicker.InstituteId
                    My.Computer.Registry.CurrentUser.CreateSubKey("Software\HomeWorkScraper")
                    My.Computer.Registry.SetValue(REGISTRY_KEY, "eKreta_InstituteId", myInstituteID, Microsoft.Win32.RegistryValueKind.DWord)
                End If
            End If

            'refreshToken
            Dim refreshToken = My.Computer.Registry.GetValue(REGISTRY_KEY, "eKreta_RefreshToken", Nothing)
            If refreshToken IsNot Nothing Then
                myRefreshToken = refreshToken.ToString()
            Else
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\HomeWorkScraper")
                Dim myInstitute = Await getInstituteFromID(My.Computer.Registry.GetValue(REGISTRY_KEY, "eKreta_InstituteId", Nothing))

                getAccessToken(myInstitute.Url, myInstitute.InstituteCode)
                If myRefreshToken = "" Then
                    MsgBox("A program működéséhez SZÜKSÉGES bejelentkezned az e-Krétába, ugyanis innen kérdi le az órarendet, a tanárok listáját stb...")
                    getAccessToken(myInstitute.Url, myInstitute.InstituteCode)
                    If myRefreshToken = "" Then
                        myMainForm.Close()
                    End If
                End If
            End If
        End Function

        Async Function myGETRequest(Of Type)(url As String, Headers As Dictionary(Of String, String), Optional gzip As Boolean = False) As Task(Of Type)
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(url)

            For Each e In Headers
                myHttpWebRequest.Headers.Add(e.Key, e.Value)
            Next

            myHttpWebRequest.UserAgent = "Kreta ()"
            myHttpWebRequest.Accept = "application/json"
            If gzip Then
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip")
            End If

            Dim str = New IO.StreamReader((Await myHttpWebRequest.GetResponseAsync).GetResponseStream).ReadToEnd
            Return JsonConvert.DeserializeObject(Of Type)(str, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        End Function

        Function myPOSTRequest(Of Type)(Url As String, body As String, Optional contentType As String = Nothing, Optional Headers As Dictionary(Of String, String) = Nothing) As Type
            Dim bodyBytes = Text.Encoding.UTF8.GetBytes(body)

            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(Url)

            If Headers IsNot Nothing Then
                For Each e In Headers
                    myHttpWebRequest.Headers.Add(e.Key, e.Value)
                Next
            End If

            myHttpWebRequest.UserAgent = "Kreta ()"
            myHttpWebRequest.ContentType = contentType

            myHttpWebRequest.Method = WebRequestMethods.Http.Post
            myHttpWebRequest.ContentLength = bodyBytes.Length
            myHttpWebRequest.GetRequestStream.Write(bodyBytes, 0, bodyBytes.Length)
            myHttpWebRequest.GetRequestStream.Close()

            Dim str = New IO.StreamReader(myHttpWebRequest.GetResponse.GetResponseStream).ReadToEnd
            Return JsonConvert.DeserializeObject(Of Type)(str, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        End Function

        Async Function myPOSTRequest2(Of Type)(url As String, body As String, Optional contentType As String = Nothing, Optional headers As Dictionary(Of String, String) = Nothing) As Task(Of Type)
            Dim myHttpRequestMessage = New Http.HttpRequestMessage(Http.HttpMethod.Post, url)
            myHttpRequestMessage.Content = New Http.StringContent(body, Text.Encoding.UTF8, "application/x-www-form-urlencoded")
            myHttpRequestMessage.Headers.Add("Accept", "application/json")
            myHttpRequestMessage.Headers.Add("Accept-Encoding", "gzip")
            myHttpRequestMessage.Headers.Add("Connection", "keep-alive")
            myHttpRequestMessage.Headers.Add("User-Agent", "Kreta.Ellenorzo/2.9.10.2020031602 (Android; WAS-LX1 8.0.0)")
            'Add bearer
            Dim myHttpClient = New Http.HttpClient()
            Dim myHttpResponseMessage = Await myHttpClient.SendAsync(myHttpRequestMessage)
            Dim str = New IO.StreamReader(Await myHttpResponseMessage.Content.ReadAsStreamAsync).ReadToEnd

            Return JsonConvert.DeserializeObject(Of Type)(str, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        End Function

#Region "Institute"

        Private InstituteList As List(Of Institute) = Nothing

        Async Function getInstituteFromID(instituteID As Long) As Task(Of Institute)
            Dim myInstitutes = getInstituteList()
            For Each e In Await myInstitutes
                If e.InstituteID = instituteID Then
                    Return e
                End If
            Next
            Return Nothing
        End Function

        Private Structure InstituteResponse
            Dim InstituteId As ULong
            Dim InstituteCode As String
            Dim Name As String
            Dim Url As String
            Dim City As String
            Dim AdvertisingUrl As String
            Dim FeatureToggleSet As Dictionary(Of String, String)
        End Structure

        Async Function getInstituteList() As Task(Of List(Of Institute))
            If InstituteList Is Nothing Then
                Dim myInstituteResponseList = myGETRequest(Of List(Of InstituteResponse))("https://kretaglobalmobileapi.ekreta.hu/api/v1/Institute", New Dictionary(Of String, String) From {{"apiKey", API_KEY}})
                Dim outList As New List(Of Institute)

                For Each e In Await myInstituteResponseList
                    Dim tempInstitute As Institute

                    tempInstitute.InstituteID = e.InstituteId
                    tempInstitute.InstituteCode = e.InstituteCode
                    tempInstitute.Name = e.Name
                    tempInstitute.Url = e.Url
                    tempInstitute.City = e.City

                    outList.Add(tempInstitute)
                Next
                InstituteList = New List(Of Institute)
                InstituteList.AddRange(outList)
            End If
            Return InstituteList
        End Function

#End Region

#Region "Token"

        Function getAccessToken(instituteURL As String, instituteID As String) As String
            If DateTime.UtcNow > myTokenValid Then
                If myRefreshToken = "" Then
                    Dim myLoginForm As New LoginForm("Bejelentkezés: e-Kréta")
                    Do While True
                        myLoginForm.PasswordTextBox.Text = ""
                        If myLoginForm.ShowDialog = DialogResult.OK Then
                            myToken = getNewAccessToken(instituteURL, instituteID, myLoginForm.Username, myLoginForm.Password)
                            If myToken = "" Then
                                Continue Do
                            End If
                            My.Computer.Registry.SetValue(REGISTRY_KEY, "eKreta_RefreshToken", myRefreshToken)
                        End If
                        Exit Do
                    Loop
                    myLoginForm.Dispose()
                Else
                    myToken = getNewAccessToken(instituteURL, instituteID, myRefreshToken)
                    My.Computer.Registry.SetValue(REGISTRY_KEY, "eKreta_RefreshToken", myRefreshToken)
                End If
            End If

            Return myToken
        End Function

        Private Structure TokenResponse
            Dim access_token As String
            Dim token_type As String
            Dim expires_in As Long
            Dim refresh_token As String
        End Structure

        Private Function getNewAccessToken(instituteURL As String, instituteID As String, username As String, password As String) As String
            'Try
            Dim myTokenResponse = myPOSTRequest(Of TokenResponse)($"{instituteURL}/idp/api/v1/Token", $"institute_code={instituteID}&userName={username}&password={password}&grant_type=password&client_id=919e0c1c-76a2-4646-a2fb-7085bbbf3c56")

            myTokenValid = DateTime.UtcNow.AddSeconds(myTokenResponse.expires_in - TOKEN_TIME_DEADZONE)
            myRefreshToken = myTokenResponse.refresh_token

            Return myTokenResponse.access_token
            'Catch e As WebException
            'MsgBox(e.Message)
            'End Try

            Return ""
        End Function

        Private Function getNewAccessToken(instituteURL As String, instituteID As String, refreshToken As String) As String
            Try
                Dim myTokenResponse = myPOSTRequest(Of TokenResponse)($"{instituteURL}/idp/api/v1/Token", $"institute_code={instituteID}&refresh_token={refreshToken}&grant_type=refresh_token&client_id=919e0c1c-76a2-4646-a2fb-7085bbbf3c56")

                myTokenValid = DateTime.UtcNow.AddSeconds(myTokenResponse.expires_in - TOKEN_TIME_DEADZONE)
                myRefreshToken = myTokenResponse.refresh_token

                Return myTokenResponse.access_token
            Catch e As WebException
                MsgBox(e.Message)
            End Try

            Return ""
        End Function

#End Region

#Region "Lesson"

        Private Structure LessonResponse
            'Important
            Dim LessonID As ULong

            Dim CalendarOraType As String
            Dim Count As ULong

            'Important
            Dim [Date] As String
            Dim StartTime As String
            Dim EndTime As String

            Dim Subject As String
            Dim SubjectCategory As String 'Tuti string?
            'Important
            Dim SubjectCategoryName As String

            Dim ClassRoom As String
            'Important?
            Dim OsztalyCsoportUid As String 'Intbe át majd
            Dim ClassGroup As String
            'Important
            Dim Teacher As String

            Dim DeputyTeacher As String
            Dim State As String
            Dim StateName As String
            Dim PresenceType As String
            Dim PresenceTypeName As String
            'Important
            Dim TeacherHomeworkID As ULong
            Dim IsTanuloHaziFeladatEnabled As Boolean
            Dim BejelentettSzamonkeresIDList As List(Of ULong)
            Dim Theme As String

            Dim Nev As String
            'Important?
            Dim Homework As String 'Tuti string?

        End Structure

        Async Function getLessonList(instituteUrl As String, fromDate As String, toDate As String, accessToken As String) As Task(Of List(Of Lesson))
            Dim myLessonResponseList = myGETRequest(Of List(Of LessonResponse))($"{instituteUrl}/mapi/api/v1/LessonAmi?fromDate={fromDate}&toDate={toDate}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}}, True)

            Dim outList As New List(Of Lesson)
            Dim lesson As Lesson
            For Each lessonResponse In Await myLessonResponseList
                lesson.ClassRoom = lessonResponse.ClassRoom
                lesson.StartTime = eKreta.Format.getDateTime(lessonResponse.StartTime)
                lesson.EndTime = eKreta.Format.getDateTime(lessonResponse.EndTime)
                lesson.IsTanuloHaziFeladatEnabled = lessonResponse.IsTanuloHaziFeladatEnabled
                lesson.LessonID = lessonResponse.LessonID
                lesson.SubjectName = lessonResponse.Nev
                lesson.Teacher = lessonResponse.Teacher
                lesson.TeacherHomeworkID = lessonResponse.TeacherHomeworkID
                outList.Add(lesson)
            Next

            Return outList
        End Function

#End Region

#Region "Homework"

        Private Structure TeacherHomeworkResponse
            Dim Uid As String
            Dim Id As ULong
            Dim OsztalyCsoportUid As String
            Dim Tantargy As String
            Dim Rogzito As String
            Dim IsTanarRogzitette As Boolean
            Dim Oraszam As ULong
            Dim TanitasiOraId As ULong
            Dim Szoveg As String
            Dim FeladasDatuma As String
            Dim Hatarido As String
            Dim IsTanuloHaziFeladatEnabled As Boolean
        End Structure

        Private Structure StudentHomeworkResponse
            Dim Uid As String
            Dim Id As ULong
            Dim TanuloNev As String
            Dim FeladasDatuma As String
            Dim FeladatSzovege As String
            Dim RogzitoId As ULong
            Dim TanuloAltalTorolt As Boolean
            Dim TanarAltalTorolt As Boolean
        End Structure

        Private Structure StudentHomeworkPayload
            Dim TanarHaziFeladatId As String
            Dim OraId As ULong
            Dim OraDate As String
            Dim OraType As String
            Dim FeladatSzovege As String
            Dim Hatarido As String

            Sub New(tanarHFID As String, oraID As ULong, szoveg As String, feladasiDate As String, hatarido As String)
                TanarHaziFeladatId = tanarHFID
                Me.OraId = oraID
                OraDate = feladasiDate
                OraType = "TanitasiOra"
                FeladatSzovege = szoveg
                Me.Hatarido = hatarido
            End Sub
        End Structure

        Async Function getHomeworkList(instituteURL As String, fromDate As String, toDate As String, accessToken As String) As Task(Of List(Of Homework))
            Dim myHomeworkTaskList As New List(Of Task(Of Homework))
            'Start Requests in parallel
            For Each lesson In Await getLessonList(instituteURL, fromDate, toDate, accessToken)
                If lesson.TeacherHomeworkID <> 0 Then
                    myHomeworkTaskList.Add(getHomework(instituteURL, lesson.TeacherHomeworkID, accessToken))
                End If
            Next

            'Await Requests
            Dim outList As New List(Of Homework)
            For Each myHomeworkTask In myHomeworkTaskList
                outList.Add(Await myHomeworkTask)
            Next

            Return outList
        End Function

        Async Function getHomework(instituteURL As String, teacherHomeworkID As ULong, accessToken As String) As Task(Of Homework)
            Dim myTeacherHomeworkResponseTask = myGETRequest(Of TeacherHomeworkResponse)($"{instituteURL}/mapi/api/v1/HaziFeladat/TanarHaziFeladat/{teacherHomeworkID}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})
            Dim myStudentHomeworkResponseTask = myGETRequest(Of List(Of StudentHomeworkResponse))($"{instituteURL}/mapi/api/v1/HaziFeladat/TanuloHaziFeladatLista/{teacherHomeworkID}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})
            Return formatHomeworkResponse(Await myTeacherHomeworkResponseTask, Await myStudentHomeworkResponseTask)
        End Function

        Private Function formatHomeworkResponse(teacherHomeworkResponse As TeacherHomeworkResponse, studentHomeworkResponseList As List(Of StudentHomeworkResponse))
            Dim myHomework As Homework
            myHomework.StudentHomeworks = New List(Of StudentHomework)

            myHomework.ID = teacherHomeworkResponse.Id
            myHomework.Tantargy = teacherHomeworkResponse.Tantargy
            myHomework.Rogzito = teacherHomeworkResponse.Rogzito
            myHomework.Oraszam = teacherHomeworkResponse.Oraszam
            myHomework.TanitasiOraId = teacherHomeworkResponse.TanitasiOraId
            myHomework.Szoveg = teacherHomeworkResponse.Szoveg
            myHomework.FeladasDatuma = eKreta.Format.getDateTime(teacherHomeworkResponse.FeladasDatuma)
            myHomework.Hatarido = eKreta.Format.getDateTime(teacherHomeworkResponse.Hatarido)
            myHomework.IsTanuloHaziFeladatEnabled = teacherHomeworkResponse.IsTanuloHaziFeladatEnabled

            For Each myStudentHomeworkResponse In studentHomeworkResponseList
                Dim myStudentHomework As StudentHomework
                myStudentHomework.FeladasDatuma = eKreta.Format.getDateTime(myStudentHomeworkResponse.FeladasDatuma)
                myStudentHomework.FeladatSzovege = myStudentHomeworkResponse.FeladatSzovege
                myStudentHomework.Id = myStudentHomeworkResponse.Id
                myStudentHomework.RogzitoId = myStudentHomeworkResponse.RogzitoId
                myStudentHomework.TanuloNev = myStudentHomeworkResponse.TanuloNev

                myHomework.StudentHomeworks.Add(myStudentHomework)
            Next

            Return myHomework
        End Function

        Sub sendStudentHomework(instituteURL As String, homework As Homework, szoveg As String, accessToken As String)
            Dim myStudentHomeworkPayload As StudentHomeworkPayload
            myStudentHomeworkPayload.FeladatSzovege = szoveg
            myStudentHomeworkPayload.Hatarido = homework.Hatarido
            myStudentHomeworkPayload.OraDate = eKreta.Format.formatDateTime(homework.FeladasDatuma)
            myStudentHomeworkPayload.OraId = homework.TanitasiOraId
            myStudentHomeworkPayload.OraType = "TanitasiOra"
            myStudentHomeworkPayload.TanarHaziFeladatId = homework.ID

            Dim str = JsonConvert.SerializeObject(myStudentHomeworkPayload)

            myPOSTRequest(Of StudentHomeworkResponse)($"{instituteURL}/mapi/api/v1/HaziFeladat/CreateTanuloHaziFeladat", str, "application/json; charset=utf-8", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})
        End Sub

#End Region

#Region "e-Ügyintézés Messages"
        Private Structure MessageResponse
            Dim azonosito As ULong
            Dim isElolvasva As Boolean
            Dim isToroltElem As Boolean
            Dim tipus As Tipus
            Dim uzenet As Uzenet
        End Structure

        Private Structure Uzenet
            Dim azonosito As ULong
            Dim kuldesDatum As String
            Dim feladoNev As String
            Dim feladoTitulus As String
            Dim szoveg As String
            Dim targy As String
            Dim cimzettLista As List(Of Cimzett)
            Dim csatolmanyok As List(Of Fajl)
        End Structure
        Private Structure Cimzett
            Dim azonosito As ULong
            Dim kretaAzonosito As ULong
            Dim nev As String
            Dim tipus As Tipus
        End Structure

        Async Function getMessages(accessToken As String) As Task(Of List(Of eKretaStructures.Message))
            Dim myMessageResponseList = Await myGETRequest(Of List(Of MessageResponse))("https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/kommunikacio/postaladaelemek/sajat", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})

            Dim myMessageResponseTaskList As New List(Of Task(Of MessageResponse))
            For Each myMessageResponse In myMessageResponseList
                myMessageResponseTaskList.Add(myGETRequest(Of MessageResponse)($"https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/kommunikacio/postaladaelemek/{myMessageResponse.azonosito}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}}))
            Next
            myMessageResponseList.Clear()
            For Each myMessageResponseTask In myMessageResponseTaskList
                myMessageResponseList.Add(Await myMessageResponseTask)
            Next
            Dim outList As New List(Of eKretaStructures.Message)
            For Each myMessageResponse In myMessageResponseList
                Dim myMessage As eKretaStructures.Message
                myMessage.ID = myMessageResponse.azonosito
                myMessage.isRead = myMessageResponse.isElolvasva
                myMessage.MessageBody = myMessageResponse.uzenet.szoveg
                myMessage.MessageID = myMessageResponse.uzenet.azonosito
                myMessage.MessageSubject = myMessageResponse.uzenet.targy
                myMessage.myDate = eKreta.Format.getDateTime(myMessageResponse.uzenet.kuldesDatum)
                myMessage.SenderName = myMessageResponse.uzenet.feladoNev
                myMessage.SenderTitle = myMessageResponse.uzenet.feladoTitulus

                myMessage.Files = myMessageResponse.uzenet.csatolmanyok

                outList.Add(myMessage)
            Next
            Return outList
        End Function

        Async Function downloadFile(file As Fajl, localPath As String, accessToken As String) As Task
            Dim myWebRequest = WebRequest.Create($"https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/dokumentumok/uzenetek/{file.azonosito}")
            myWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {accessToken}")

            Dim myResponseStream = (Await myWebRequest.GetResponseAsync).GetResponseStream
            Dim myWriterStream = IO.File.Create(localPath)

            Dim data(1023) As Byte
            Dim count As UShort
            While True
                count = myResponseStream.Read(data, 0, 1024)
                If count <= 0 Then
                    Exit While
                End If
                myWriterStream.Write(data, 0, count)
            End While

            myResponseStream.Close()
            myWriterStream.Close()
        End Function
#End Region

    End Module
End Namespace