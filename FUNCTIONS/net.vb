Imports System.IO
Imports System.Net

Public Module net

    Public Class web
        Public Property settings As New settings

        Function http_get(url)
            If (settings.self_proxy = True) Then
                Dim web As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                web.DefaultWebProxy = New WebProxy()
                web.UserAgent = settings.useragent
                Dim response As HttpWebResponse
                response = CType(web.GetResponse(), HttpWebResponse)


                Dim dataStream = response.GetResponseStream()
                Dim reader = New StreamReader(dataStream)
                Dim responseFromServer = reader.ReadToEnd()


                Return responseFromServer
            Else
                Dim web As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                web.UserAgent = settings.useragent
                Dim response As HttpWebResponse
                response = CType(web.GetResponse(), HttpWebResponse)


                Dim dataStream = response.GetResponseStream()
                Dim reader = New StreamReader(dataStream)
                Dim responseFromServer = reader.ReadToEnd()


                Return responseFromServer
            End If
        End Function

        Function http_post(url As String, post_array As Specialized.NameValueCollection)
            Using client As New System.Net.WebClient
                Dim reqparm As New Specialized.NameValueCollection
                If settings.self_proxy = True Then
                    client.Proxy = New WebProxy
                End If
                client.Headers("User-Agent") = settings.useragent
                reqparm = post_array
                Dim responsebytes = client.UploadValues(url, "POST", reqparm)
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)

                Return responsebody
            End Using
        End Function

    End Class

    Public Class settings
        Public Property useragent = "Functions.NET /" & My.Application.Info.Version.Build & " (" & My.Computer.Info.OSFullName & ")  " & My.Application.Info.Title
        Public Property self_proxy = True
    End Class


End Module