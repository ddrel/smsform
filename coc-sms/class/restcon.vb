Imports System.Runtime.Serialization
Imports System.ServiceModel.Web
Imports System.ComponentModel
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class restcon
    Private __URL_ROOT_ As String = "http://localhost:9080"
    Private dtUser As New DataTable
    Public Property URL_ROOT As String
    Public Property DTUSERS As DataTable
    Public Event onrestStatus(ByVal msg As String)

    Public Sub New(ByVal host As String)
        __URL_ROOT_ = host
        URL_ROOT = __URL_ROOT_
        With dtUser.Columns
            .Add("name", GetType(String))
            .Add("mobile", GetType(String))
            .Add("email", GetType(String))
            .Add("location", GetType(String))
            .Add("location_key", GetType(String))
            .Add("lat", GetType(String))
            .Add("lng", GetType(String))
        End With
    End Sub

    Public Function converttoDT(ByVal jArr As JArray) As DataTable
        'Dim UserList As List(Of User) = JsonConvert.DeserializeObject(Of List(Of User))(jsonStrin)
        'Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
        'Dim UserList As List(Of JObject) = jArr.Values(Of List(Of JObject))()

        dtUser.Rows.Clear()
        For Each user As JObject In jArr
            Dim row As DataRow = dtUser.NewRow()
            row("name") = user.GetValue("name").ToString
            row("mobile") = user.GetValue("mobile").ToString
            row("email") = user.GetValue("email").ToString
            Dim loc As JObject = user.GetValue("location").First()
            row("location_key") = loc.GetValue("_id").ToString
            row("location") = loc.GetValue("brgy_name").ToString & " " & loc.GetValue("map_loc_prov_name").ToString
            Dim coord As JArray = loc.GetValue("coordinates")
            row("lat") = coord.Item(1)
            row("lng") = coord.Item(0)
            dtUser.Rows.Add(row)
        Next

        Return dtUser
        'Return dt
    End Function
    Public Sub GetResponseUser(uri As Uri, callback As Action(Of JArray))
        Dim wc As New WebClient()
        AddHandler wc.OpenReadCompleted,
            Function(o, a)
                If callback IsNot Nothing Then
                    'Dim ser As New Newtonsoft.Json.JsonSerializer()
                    Dim serializer = New JsonSerializer()
                    Using sr = New StreamReader(a.Result)
                        Using jsonTextReader = New JsonTextReader(sr)
                            callback(serializer.Deserialize(jsonTextReader))
                        End Using
                    End Using
                    'callback(TryCast(ser.ReadObject(a.Result), WebResponse))
                End If
                Return 0
            End Function
        wc.OpenReadAsync(uri)
    End Sub
    Public Sub GetResponseMosq(uri As Uri, callback As Action(Of JObject))
        Dim wc As New WebClient()
        RaiseEvent onrestStatus("Sending request to server... " + uri.OriginalString)
        AddHandler wc.OpenReadCompleted,
            Function(o, a)
                If callback IsNot Nothing Then
                    'Dim ser As New Newtonsoft.Json.JsonSerializer()
                    Dim serializer = New JsonSerializer()
                    Using sr = New StreamReader(a.Result)
                        Using jsonTextReader = New JsonTextReader(sr)
                            wc.Dispose()
                            callback(serializer.Deserialize(jsonTextReader))
                        End Using
                    End Using
                    'callback(TryCast(ser.ReadObject(a.Result), WebResponse))
                End If
                Return 0
            End Function
        wc.OpenReadAsync(uri)
    End Sub

    Public Sub getmosquitoactivity(ByVal coords As String, ByVal key As String, callback As Action(Of MosquitoForecast))
        Dim geocodeRequest As New Uri(String.Format(__URL_ROOT_ + "/api/get15daysmosquetoactivity?geocode={0}&keylocation={1}", coords, key))
        GetResponseMosq(geocodeRequest, Function(jobj)
                                            Dim Obj As JObject = TryCast(jobj, JObject)
                                            Dim MosquitoForecast = New MosquitoForecast

                                            If jobj.Item("code") IsNot Nothing Then
                                                MosquitoForecast.Eveningforecast = "Mosquito forecast failed"
                                                MosquitoForecast.Forecast1 = ""
                                                MosquitoForecast.Forecast2 = ""

                                                RaiseEvent onrestStatus("Response from server (Error) ... " & jobj.Item("code").ToString)
                                                callback(MosquitoForecast)
                                            Else
                                                Dim mosquitoIndex24hour As JObject = Obj.GetValue("forecast").Item("mosquitoIndex24hour")
                                                Dim mosquitoIndex12hour As JObject = Obj.GetValue("forecast").Item("mosquitoIndex12hour")
                                                MosquitoForecast.Eveningforecast = "Evening (6PM-10PM): " & mosquitoIndex24hour.GetValue("eveningMosquitoCategory").First.ToString
                                                MosquitoForecast.Forecast1 = mosquitoIndex12hour.GetValue("daypartName").Item(0).ToString & " : " & mosquitoIndex12hour.GetValue("mosquitoCategory").Item(0).ToString
                                                MosquitoForecast.Forecast2 = mosquitoIndex12hour.GetValue("daypartName").Item(1).ToString & " : " & mosquitoIndex12hour.GetValue("mosquitoCategory").Item(1).ToString
                                                RaiseEvent onrestStatus("Response from server (Success) ... ")
                                                callback(MosquitoForecast)
                                            End If
                                            Return MosquitoForecast
                                        End Function)


    End Sub

    Public Sub getusers(callback As Action(Of DataTable))
        Dim geocodeRequest As New Uri(String.Format(__URL_ROOT_ + "/api/user/getusers"))
        Dim dt As DataTable = Nothing
        GetResponseUser(geocodeRequest, Function(x)
                                            DTUSERS = Nothing
                                            DTUSERS = converttoDT(TryCast(x, JArray))
                                            'callback(TryCast(converttoDT(x), DataTable))
                                            callback(DTUSERS)
                                            Return 0

                                        End Function)

    End Sub

    Private Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table As New DataTable()
        For i As Integer = 0 To props.Count - 1
            Dim prop As PropertyDescriptor = props(i)
            table.Columns.Add(prop.Name, prop.PropertyType)
        Next
        Dim values As Object() = New Object(props.Count - 1) {}
        For Each item As T In data
            For i As Integer = 0 To values.Length - 1
                values(i) = props(i).GetValue(item)
            Next
            table.Rows.Add(values)
        Next
        Return table
    End Function


End Class


