Imports System.Net
Imports System.Web
Imports Newtonsoft.Json

Namespace eKreta
    Module eKreta
        Private Const API_KEY = "7856d350-1fda-45f5-822d-e1a2f3f1acf0"
        Private Const TOKEN_TIME_DEADZONE = 120
        Private Const REGISTRY_KEY = "HKEY_CURRENT_USER\Software\HomeWorkScraper"

        Private myUsername = ""
        Private myPassword = ""

        Dim myRefreshToken As String
        Dim myAccessTokenValid As Date = Date.MinValue
        Private myAccessToken As String

        Dim myInstitute As eKretaInstitute

        Private Sub saveLoginData(username As String, password As String, saveToRegistry As Boolean)
            myUsername = username
            myPassword = password
            If saveToRegistry Then
                setRegistry("eKreta_Username", myUsername, Microsoft.Win32.RegistryValueKind.String)
                setRegistry("eKreta_Password", myPassword, Microsoft.Win32.RegistryValueKind.String)
            End If
        End Sub
        Private Sub setRegistry(key As String, value As Object, kind As Microsoft.Win32.RegistryValueKind)
            My.Computer.Registry.CurrentUser.CreateSubKey("Software\HomeWorkScraper")
            My.Computer.Registry.SetValue(REGISTRY_KEY, key, value, kind)
        End Sub
        Private Function getRegistry(key As String) As Object
            Return My.Computer.Registry.GetValue(REGISTRY_KEY, key, Nothing)
        End Function
        Private Async Function myGETRequest(Of Type)(url As String, Headers As Dictionary(Of String, String), Optional gzip As Boolean = False) As Task(Of Type)
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
        Private Function myPOSTRequest(Of Type)(url As String, body As String, Optional contentType As String = Nothing, Optional Headers As Dictionary(Of String, String) = Nothing) As Type
            Dim bodyBytes = Text.Encoding.UTF8.GetBytes(body)

            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(url)

            If Headers IsNot Nothing Then
                For Each e In Headers
                    myHttpWebRequest.Headers.Add(e.Key, e.Value)
                Next
            End If

            myHttpWebRequest.Accept = "application/json"
            myHttpWebRequest.UserAgent = "Kreta ()"
            myHttpWebRequest.ContentType = contentType

            myHttpWebRequest.Method = WebRequestMethods.Http.Post
            myHttpWebRequest.ContentLength = bodyBytes.Length
            myHttpWebRequest.GetRequestStream.Write(bodyBytes, 0, bodyBytes.Length)
            myHttpWebRequest.GetRequestStream.Close()

            Dim str = New IO.StreamReader(myHttpWebRequest.GetResponse.GetResponseStream).ReadToEnd
            Return JsonConvert.DeserializeObject(Of Type)(str, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        End Function

        Public Async Function Initialize() As Task
            'HTTPS
            ServicePointManager.ServerCertificateValidationCallback = New Security.RemoteCertificateValidationCallback(Function(sender As Object, certification As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As Security.SslPolicyErrors) True)
            'Get Institute
            Dim instituteId = getRegistry("eKreta_InstituteID")
            If instituteId IsNot Nothing Then
                myInstitute = Await getInstituteByID(instituteId)
            Else
                Dim myInstitutePicker As New InstitutePicker
                If myInstitutePicker.ShowDialog = DialogResult.OK Then
                    myInstitute = myInstitutePicker.myInstitute
                    setRegistry("eKreta_InstituteID", myInstitute.InstituteID, Microsoft.Win32.RegistryValueKind.DWord)
                End If
            End If
            'Get Username and Password
            myUsername = getRegistry("eKreta_Username")
            myPassword = getRegistry("eKreta_Password")
            If myUsername Is Nothing Then
                myUsername = ""
            End If
            If myPassword Is Nothing Then
                myPassword = ""
            End If
            'Get RefreshToken
            myRefreshToken = getRegistry("eKreta_RefreshToken")
            If myRefreshToken Is Nothing Then
                myRefreshToken = ""
            End If
        End Function

#Region "Institute"
        Private myInstitutes As New Dictionary(Of ULong, eKretaInstitute)

        Private Structure InstituteResponse
            Dim InstituteId As ULong
            Dim InstituteCode As String
            Dim Name As String
            Dim Url As String
            Dim City As String
            Dim AdvertisingUrl As String
            Dim FeatureToggleSet As Dictionary(Of String, String)
        End Structure

        Async Function getInstituteByID(instituteID As ULong) As Task(Of eKretaInstitute)
            If myInstitutes.Count > 0 Then
                Return myInstitutes(instituteID)
            End If
            Await getInstitutes()
            Return myInstitutes(instituteID)
        End Function
        Async Function getInstitutes() As Task(Of List(Of eKretaInstitute))
            If myInstitutes.Count <= 0 Then
                Dim myInstituteResponseList = Await myGETRequest(Of List(Of InstituteResponse))("https://kretaglobalmobileapi.ekreta.hu/api/v1/Institute", New Dictionary(Of String, String) From {{"apiKey", API_KEY}})
                Dim outList As New List(Of eKretaInstitute)

                'Keep important things only
                For Each instituteResponse In myInstituteResponseList
                    Dim myInstitute As eKretaInstitute
                    myInstitute.InstituteID = instituteResponse.InstituteId
                    myInstitute.InstituteCode = instituteResponse.InstituteCode
                    myInstitute.Name = instituteResponse.Name
                    myInstitute.Url = instituteResponse.Url
                    myInstitute.City = instituteResponse.City

                    'Update Message at key
                    myInstitutes.Remove(myInstitute.InstituteID)
                    myInstitutes.Add(myInstitute.InstituteID, myInstitute)
                Next
            End If
            Return myInstitutes.Values.ToList
        End Function
#End Region

#Region "Token"
        Private Structure TokenResponse
            Dim access_token As String
            Dim token_type As String
            Dim expires_in As Long
            Dim refresh_token As String
        End Structure

        Private Function getAccessToken() As String
            If DateTime.UtcNow >= myAccessTokenValid Then
                'Try with RefreshToken
                If myRefreshToken <> "" Then
                    myAccessToken = getNewAccessToken(myRefreshToken)
                    If myAccessToken <> "" Then
                        Return myAccessToken
                    End If
                End If
                'Try with Username and Password if available
                If myUsername <> "" AndAlso myPassword <> "" Then
                    myAccessToken = getNewAccessToken(myUsername, myPassword)
                    If myAccessToken <> "" Then
                        Return myAccessToken
                    End If
                End If
                'Ask for Username and Password
                Dim myEKretaLoginForm As New EKretaLoginForm
                While True
                    myEKretaLoginForm.PasswordTextBox.Text = ""
                    If myEKretaLoginForm.ShowDialog = DialogResult.OK Then
                        myAccessToken = getNewAccessToken(myEKretaLoginForm.Username, myEKretaLoginForm.Password)
                        If myAccessToken = "" Then
                            Continue While
                        End If
                        saveLoginData(myEKretaLoginForm.Username, myEKretaLoginForm.Password, myEKretaLoginForm.SaveLoginCheckBox.Checked)
                        Return myAccessToken
                    ElseIf EKretaLoginForm.myClosed = True Then
                        Exit While
                    Else
                        MsgBox("Ha nem jelentkezel be, nem fog működni a program.")
                    End If
                End While
            End If
            Return myAccessToken
        End Function

        Private Function getNewAccessToken(username As String, password As String) As String
            Try
                Return tokenResponseHandler(myPOSTRequest(Of TokenResponse)($"{myInstitute.Url}/idp/api/v1/Token", $"institute_code={myInstitute.InstituteID}&userName={username}&password={password}&grant_type=password&client_id=919e0c1c-76a2-4646-a2fb-7085bbbf3c56"))
            Catch ex As Exception
            End Try
            Return ""
        End Function
        Private Function getNewAccessToken(refreshToken As String) As String
            Try
                Return tokenResponseHandler(myPOSTRequest(Of TokenResponse)($"{myInstitute.Url}/idp/api/v1/Token", $"institute_code={myInstitute.InstituteID}&refresh_token={refreshToken}&grant_type=refresh_token&client_id=919e0c1c-76a2-4646-a2fb-7085bbbf3c56"))
            Catch ex As Exception
            End Try
            Return ""
        End Function
        Private Function tokenResponseHandler(tokenResponse As TokenResponse) As String
            myAccessTokenValid = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in - TOKEN_TIME_DEADZONE)
            myRefreshToken = tokenResponse.refresh_token
            setRegistry("eKreta_RefreshToken", myRefreshToken, Microsoft.Win32.RegistryValueKind.String)
            Return tokenResponse.access_token
        End Function
#End Region

#Region "Lessons"
        Private myLessons As New Dictionary(Of ULong, eKretaLesson)

        Private Structure LessonResponse
            Dim LessonID As ULong
            Dim CalendarOraType As String
            Dim Count As ULong
            Dim [Date] As String
            Dim StartTime As String
            Dim EndTime As String
            Dim Subject As String
            Dim SubjectCategory As String
            Dim SubjectCategoryName As String
            Dim ClassRoom As String
            Dim OsztalyCsoportUid As String
            Dim ClassGroup As String
            Dim Teacher As String
            Dim DeputyTeacher As String
            Dim State As String
            Dim StateName As String
            Dim PresenceType As String
            Dim PresenceTypeName As String
            Dim TeacherHomeworkID As ULong
            Dim IsTanuloHaziFeladatEnabled As Boolean
            Dim BejelentettSzamonkeresIDList As List(Of ULong)
            Dim Theme As String
            Dim Nev As String
            Dim Homework As String
        End Structure

        Public Async Function getLessonByID(lessonID) As Task(Of eKretaLesson)
            If myLessons.ContainsKey(lessonID) Then
                Return myLessons(lessonID)
            End If
            Await getLessonRangePrivate("null", "null")
            Return myLessons(lessonID)
        End Function
        Public Async Function getLessonRangeUpdate(fromDate As Date, toDate As Date) As Task(Of List(Of eKretaLesson))
            Return Await getLessonRangePrivate(Format.formatForRequest(fromDate), Format.formatForRequest(toDate))
        End Function

        Private Async Function getLessonRangePrivate(fromDate As String, toDate As String) As Task(Of List(Of eKretaLesson))
            Dim myLessonResponseList = Await myGETRequest(Of List(Of LessonResponse))($"{myInstitute.Url}/mapi/api/v1/LessonAmi?fromDate={fromDate}&toDate={toDate}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {getAccessToken()}"}}, True)

            Dim outlist As New List(Of eKretaLesson)
            For Each lessonResponse In myLessonResponseList
                Dim lesson As eKretaLesson
                lesson.ClassRoom = lessonResponse.ClassRoom
                lesson.StartTime = Format.getDateTime(lessonResponse.StartTime)
                lesson.EndTime = Format.getDateTime(lessonResponse.EndTime)
                lesson.IsTanuloHaziFeladatEnabled = lessonResponse.IsTanuloHaziFeladatEnabled
                lesson.LessonID = lessonResponse.LessonID
                lesson.SubjectName = lessonResponse.Nev
                lesson.Teacher = lessonResponse.Teacher
                lesson.TeacherHomeworkID = lessonResponse.TeacherHomeworkID

                'Update Lesson at key
                myLessons.Remove(lesson.LessonID)
                myLessons.Add(lesson.LessonID, lesson)

                outlist.Add(lesson)
            Next

            Return outlist
        End Function
#End Region

#Region "Homeworks"
        Private myHomeworks As New Dictionary(Of ULong, eKretaHomework)

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
            'Dim OraId As ULong
            'Dim OraDate As String
            'Dim OraType As String
            Dim FeladatSzovege As String
            'Dim Hatarido As String

            Sub New(tanarHFID As String, oraID As ULong, szoveg As String, feladasiDate As String, hatarido As String)
                TanarHaziFeladatId = tanarHFID
                'Me.OraId = oraID
                'OraDate = feladasiDate
                'OraType = "TanitasiOra"
                FeladatSzovege = szoveg
                'Me.Hatarido = hatarido
            End Sub
        End Structure

        Async Function getHomeworkRangeUpdate(fromDate As String, toDate As String) As Task(Of List(Of eKretaHomework))
            Dim myHomeworkTaskList As New List(Of Task(Of eKretaHomework))
            'Start Requests in parallel
            For Each lesson In Await getLessonRangeUpdate(fromDate, toDate)
                If lesson.TeacherHomeworkID <> 0 Then
                    myHomeworkTaskList.Add(getHomeworkByIDUpdate(lesson.TeacherHomeworkID))
                End If
            Next

            'Await Requests
            Dim outList As New List(Of eKretaHomework)
            For Each myHomeworkTask In myHomeworkTaskList
                outList.Add(Await myHomeworkTask)
            Next

            Return outList
        End Function

        Public Async Function getHomeworkByID(homeworkID As ULong) As Task(Of eKretaHomework)
            If myHomeworks.ContainsKey(homeworkID) Then
                Return myHomeworks(homeworkID)
            End If
            Return Await getHomeworkByIDUpdate(homeworkID)
        End Function
        Public Async Function getHomeworkByIDUpdate(homeworkID As ULong) As Task(Of eKretaHomework)
            Dim myTeacherHomeworkResponseTask = myGETRequest(Of TeacherHomeworkResponse)($"{myInstitute.Url}/mapi/api/v1/HaziFeladat/TanarHaziFeladat/{homeworkID}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {getAccessToken()}"}})
            Dim myStudentHomeworkResponseTask = myGETRequest(Of List(Of StudentHomeworkResponse))($"{myInstitute.Url}/mapi/api/v1/HaziFeladat/TanuloHaziFeladatLista/{homeworkID}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {getAccessToken()}"}})
            Return formatHomeworkResponse(Await myTeacherHomeworkResponseTask, Await myStudentHomeworkResponseTask)
        End Function

        Private Function formatHomeworkResponse(teacherHomeworkResponse As TeacherHomeworkResponse, studentHomeworkResponseList As List(Of StudentHomeworkResponse))
            Dim myHomework As eKretaHomework
            myHomework.StudentHomeworks = New List(Of StudentHomework)

            myHomework.ID = teacherHomeworkResponse.Id
            myHomework.Tantargy = teacherHomeworkResponse.Tantargy
            myHomework.Rogzito = teacherHomeworkResponse.Rogzito
            myHomework.Oraszam = teacherHomeworkResponse.Oraszam
            myHomework.TanitasiOraId = teacherHomeworkResponse.TanitasiOraId
            myHomework.Szoveg = teacherHomeworkResponse.Szoveg
            myHomework.FeladasDatuma = Format.getDateTime(teacherHomeworkResponse.FeladasDatuma)
            myHomework.Hatarido = Format.getDateTime(teacherHomeworkResponse.Hatarido)
            myHomework.IsTanuloHaziFeladatEnabled = teacherHomeworkResponse.IsTanuloHaziFeladatEnabled

            For Each myStudentHomeworkResponse In studentHomeworkResponseList
                Dim myStudentHomework As StudentHomework
                myStudentHomework.FeladasDatuma = Format.getDateTime(myStudentHomeworkResponse.FeladasDatuma)
                myStudentHomework.FeladatSzovege = myStudentHomeworkResponse.FeladatSzovege
                myStudentHomework.Id = myStudentHomeworkResponse.Id
                myStudentHomework.RogzitoId = myStudentHomeworkResponse.RogzitoId
                myStudentHomework.TanuloNev = myStudentHomeworkResponse.TanuloNev

                myHomework.StudentHomeworks.Add(myStudentHomework)
            Next
            'Update Homework at key
            myHomeworks.Remove(myHomework.ID)
            myHomeworks.Add(myHomework.ID, myHomework)

            Return myHomework
        End Function

        Public Sub sendStudentHomework(homework As eKretaHomework, szoveg As String)
            Dim myStudentHomeworkPayload As StudentHomeworkPayload
            myStudentHomeworkPayload.FeladatSzovege = szoveg
            'myStudentHomeworkPayload.Hatarido = homework.Hatarido
            'myStudentHomeworkPayload.OraDate = Format.formatDateTime(homework.FeladasDatuma)
            'myStudentHomeworkPayload.OraId = homework.TanitasiOraId
            'myStudentHomeworkPayload.OraType = "TanitasiOra"
            myStudentHomeworkPayload.TanarHaziFeladatId = homework.ID

            Dim str = JsonConvert.SerializeObject(myStudentHomeworkPayload)
            myPOSTRequest(Of StudentHomeworkResponse)($"{myInstitute.Url}/mapi/api/v1/HaziFeladat/CreateTanuloHaziFeladat", str, "application/json; charset=utf-8", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {getAccessToken()}"}})
        End Sub
#End Region

#Region "Messages (e-Ügyintézés)"
        Private myMessages As New Dictionary(Of ULong, eKretaMessage)

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
            Dim csatolmanyok As List(Of eKretaFajl)
        End Structure
        Private Structure Cimzett
            Dim azonosito As ULong
            Dim kretaAzonosito As ULong
            Dim nev As String
            Dim tipus As Tipus
        End Structure
        Private Structure Tipus
            Dim azonosito As ULong
            Dim kod As String
            Dim rovidNev As String
            Dim nev As String
            Dim leiras As String
        End Structure

        Public Async Function getMessageRange(fromDate As Date, toDate As Date) As Task(Of List(Of eKretaMessage))
            toDate = toDate.AddDays(1) 'Include day of toDate

            Dim messages = Await getMessages()
            Dim outlist As New List(Of eKretaMessage)
            For Each myMessage In messages
                If fromDate <= myMessage.myDate AndAlso myMessage.myDate < toDate Then
                    outlist.Add(myMessage)
                End If
            Next
            Return outlist
        End Function

        Public Async Function getMessagesUpdate() As Task(Of List(Of eKretaMessage))
            Return Await getMessagesPrivate(getAccessToken())
        End Function
        Public Async Function getMessages() As Task(Of List(Of eKretaMessage))
            If myMessages.Keys.Count <> 0 Then
                Return myMessages.Values.ToList
            Else
                Return Await getMessagesUpdate()
            End If
        End Function
        Public Async Function getMessageByID(messageID As ULong) As Task(Of eKretaMessage)
            If myMessages.ContainsKey(messageID) Then
                Return myMessages(messageID)
            Else
                Return Await getMessageByIDUpdate(messageID)
            End If
            Return Nothing
        End Function
        Public Async Function getMessageByIDUpdate(messageID As ULong) As Task(Of eKretaMessage)
            Return Await getMessageByIDPrivate(messageID, getAccessToken())
        End Function

        Private Async Function getMessageByIDPrivate(messageID As ULong, accessToken As String) As Task(Of eKretaMessage)
            Dim myMessageResponse = Await myGETRequest(Of MessageResponse)($"https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/kommunikacio/postaladaelemek/{messageID}", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})
            'Keep important things only
            Dim myMessage As eKretaMessage
            myMessage.ID = myMessageResponse.azonosito
            myMessage.isRead = myMessageResponse.isElolvasva
            myMessage.MessageBody = myMessageResponse.uzenet.szoveg
            myMessage.MessageID = myMessageResponse.uzenet.azonosito
            myMessage.MessageSubject = myMessageResponse.uzenet.targy
            myMessage.myDate = Format.getDateTime(myMessageResponse.uzenet.kuldesDatum)
            myMessage.SenderName = myMessageResponse.uzenet.feladoNev
            myMessage.SenderTitle = myMessageResponse.uzenet.feladoTitulus

            myMessage.Files = myMessageResponse.uzenet.csatolmanyok

            'Update Message at key
            myMessages.Remove(myMessage.MessageID)
            myMessages.Add(myMessage.MessageID, myMessage)

            Return myMessage
        End Function
        Private Async Function getMessagesPrivate(accessToken As String) As Task(Of List(Of eKretaMessage))
            'Get messages with short text (for IDs)
            Dim myMessageResponseList = Await myGETRequest(Of List(Of MessageResponse))("https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/kommunikacio/postaladaelemek/sajat", New Dictionary(Of String, String) From {{"Authorization", $"Bearer {accessToken}"}})

            Dim myMessageByIDTaskList As New List(Of Task(Of eKretaMessage))
            'Start all async (in parallel)
            For Each myMessageResponse In myMessageResponseList
                myMessageByIDTaskList.Add(getMessageByIDUpdate(myMessageResponse.azonosito))
            Next
            Dim outList As New List(Of eKretaMessage)
            'Await all
            For Each myMessageByIDTask In myMessageByIDTaskList
                outList.Add(Await myMessageByIDTask)
            Next
            Return outList
        End Function

        Public Async Sub downloadFile(file As eKretaFajl, localPath As String)
            Dim myWebRequest = WebRequest.Create($"https://eugyintezes.e-kreta.hu/integration-kretamobile-api/v1/dokumentumok/uzenetek/{file.azonosito}")
            myWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {getAccessToken()}")

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
        End Sub
#End Region

#Region "Web API"
        Private myCookies As CookieCollection

        Private Async Function getAuthCookie() As Task(Of CookieCollection)

            If myUsername = "" OrElse myPassword = "" Then
                Dim myEKretaLoginForm As New EKretaLoginForm
                myEKretaLoginForm.UsernameTextBox.Text = myUsername
                If myEKretaLoginForm.ShowDialog() = DialogResult.OK Then
                    myCookies = Await getNewAuthCookie(myEKretaLoginForm.Username, myEKretaLoginForm.Password)
                    If myCookies IsNot Nothing Then
                        saveLoginData(myEKretaLoginForm.Username, myEKretaLoginForm.Password, myEKretaLoginForm.SaveLoginCheckBox.Checked)
                        Return myCookies
                    End If
                End If
                MsgBox("Sikertelen bejelentkezés, a lekérés megszakítva")
                Return Nothing
            Else
                Return Await getNewAuthCookie(myUsername, myPassword)
            End If
        End Function
        Private Async Function getNewAuthCookie(username As String, password As String) As Task(Of CookieCollection)
            Try
                'Login
                Dim myHttpWebResponse = Await WebAPIGETRequest($"{myInstitute.Url}/Adminisztracio/Login")
                Dim localCookies As CookieCollection = myHttpWebResponse.Cookies

                'LoginCheck
                myHttpWebResponse = Await WebAPIPOSTRequest($"{myInstitute.Url}/Adminisztracio/Login/LoginCheck", $"{{""UserName"":""{username}"",""Password"":""{password}""}}", "application/json", localCookies)
                localCookies.Add(myHttpWebResponse.Cookies)

                'Main page authentication
                myHttpWebResponse = Await WebAPIGETRequest($"{myInstitute.Url}/Adminisztracio/SzerepkorValaszto", localCookies)
                localCookies.Add(myHttpWebResponse.Cookies)

                'Redirect Auth
                'myHttpWebResponse = Await WebAPIGETRequest(myInstitute.Url & myHttpWebResponse.Headers("Location"), localCookies)
                'localCookies.Add(myHttpWebResponse.Cookies)

                If myHttpWebResponse.StatusCode = HttpStatusCode.Found Then
                    Return localCookies
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function

        Private Async Function WebAPIGETRequest(url As String, Optional cookies As CookieCollection = Nothing, Optional Headers As Dictionary(Of String, String) = Nothing) As Task(Of HttpWebResponse)
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(New Uri(url))

            myHttpWebRequest.AllowAutoRedirect = False

            If Headers IsNot Nothing Then
                For Each e In Headers
                    myHttpWebRequest.Headers.Add(e.Key, e.Value)
                Next
            End If

            myHttpWebRequest.CookieContainer = New CookieContainer
            If cookies IsNot Nothing Then
                myHttpWebRequest.CookieContainer.Add(cookies)
            End If

            Return Await myHttpWebRequest.GetResponseAsync
        End Function
        Private Async Function WebAPIPOSTRequest(url As String, body As String, Optional contentType As String = Nothing, Optional cookies As CookieCollection = Nothing, Optional Headers As Dictionary(Of String, String) = Nothing) As Task(Of HttpWebResponse)
            Dim bodyBytes = Text.Encoding.UTF8.GetBytes(body)

            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(url)
            If Headers IsNot Nothing Then
                For Each e In Headers
                    myHttpWebRequest.Headers.Add(e.Key, e.Value)
                Next
            End If
            If contentType IsNot Nothing Then
                myHttpWebRequest.ContentType = contentType
            End If

            myHttpWebRequest.CookieContainer = New CookieContainer
            If cookies IsNot Nothing Then
                myHttpWebRequest.CookieContainer.Add(cookies)
            End If

            myHttpWebRequest.Method = WebRequestMethods.Http.Post
            myHttpWebRequest.ContentLength = bodyBytes.Length
            myHttpWebRequest.GetRequestStream.Write(bodyBytes, 0, bodyBytes.Length)
            myHttpWebRequest.GetRequestStream.Close()

            Return Await myHttpWebRequest.GetResponseAsync
        End Function

        Private Structure WebAPIHomeworkResponse
            Dim AggregateResults As String
            Dim Data As List(Of WebAPIHomework)
            Dim Errors As String
            Dim Total As ULong
        End Structure
        Private Structure WebAPIHomework
            Dim ID As ULong
            Dim TantargyId As ULong
            Dim TantargyNev As String
            Dim isTanitasiOra As String
            Dim EventId As ULong
            Dim TanitasiOraId As ULong
            Dim TanarNeve As String
            Dim HelyettesitoNev As String
            Dim HaziFeladaSzoveg As String
            Dim HaziFeladatRogzitesDatuma As String
            Dim HaziFeladatTenylegesRogzitesDatuma As String
            Dim HaziFeladatHatarido As String
            Dim HaziFeladatId As ULong
            Dim HaziFeladatRogzitoId As ULong
            Dim IsTanarRogzitette As String
            Dim OsztalyCsoport As String
            Dim OsztalyCsoportId As ULong
            Dim Oraszam As ULong
            Dim MegoldottHF As String
            Dim isTanitasiOra_BOOL As Boolean
            Dim isTanitasiOra_BNAME As String
        End Structure

        Public Async Function getHomeworksByDeadline(fromDate As Date, toDate As Date) As Task(Of List(Of eKretaHomework))
            Dim myHttpWebResponse = Await WebAPIGETRequest($"{myInstitute.Url}/api/TanuloHaziFeladatApi/GetTanulotHaziFeladatGrid?data={{""HaziFeladatHataridoKezdoDatum""%3A""{fromDate.ToString("yyyy.+MM.+dd.")}""%2C""HaziFeladatHatairdo""%3A""{toDate.ToString("yyyy.+MM.+dd.")}""%2C""RegiHaziFeladatokElrejtese""%3Afalse%2C""ElkeszitettHaziFeladatokElrejtese""%3Afalse}}", Await getAuthCookie())

            Dim myWebAPIHomeworkResponse = myDeserialize(Of WebAPIHomeworkResponse)(New IO.StreamReader(myHttpWebResponse.GetResponseStream).ReadToEnd)

            Dim myHomeworkTaskList As New List(Of Task(Of eKretaHomework))
            For Each homeworkResponse In myWebAPIHomeworkResponse.Data
                myHomeworkTaskList.Add(getHomeworkByIDUpdate(homeworkResponse.HaziFeladatId))
            Next

            Dim outlist As New List(Of eKretaHomework)
            For Each homeworkTask In myHomeworkTaskList
                outlist.Add(Await homeworkTask)
            Next

            Return outlist
        End Function

        Private Function myDeserialize(Of Type)(str As String) As Type
            Return JsonConvert.DeserializeObject(Of Type)(str, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        End Function

#End Region

    End Module
End Namespace