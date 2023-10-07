Imports System.Data.SqlClient
Imports System.Data

Partial Class Default3
    Inherits System.Web.UI.Page

    Dim _constr As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As DataSet
    Dim getPurId As Integer

    Protected Sub connection()
        con = New SqlConnection(_constr)
        Try
            con.Open()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub create()
        cmd = New SqlCommand("create table pur_stocks(sid int primary key,sname text)", con)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub addIteminPur()
        getPurId = Convert.ToInt64(Request.QueryString("sid"))
        cmd = New SqlCommand("insert into pur_stocks select * from stocks where sid = '" & getPurId & "'", con)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Your purchased stocks are there .")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Display()
        Try
            ad = New SqlDataAdapter("select * from pur_stocks", con)
            ds = New DataSet
            ad.Fill(ds)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection()
        create()
        addIteminPur()
        Display()
    End Sub
End Class
