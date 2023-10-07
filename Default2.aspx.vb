Imports System.Data.SqlClient
Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Dim _constr As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As DataSet

    Protected Sub connection()
        con = New SqlConnection(_constr)
        Try
            con.Open()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Create()
        cmd = New SqlCommand("create table user(uid integer primary key,uname text)", con)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub insert()
        cmd = New SqlCommand("insert into user values(@uid,@uname)", con)
        Try
            cmd.Parameters.AddWithValue("@uid", Convert.ToInt64(uid.Text.Trim))
            cmd.Parameters.AddWithValue("@uname", uname.Text.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("User Registered , Now User Can Login To Purchase Stocks")
        Catch ex As Exception
            lid.Text = uid.Text
            lname.Text = uname.Text
        End Try
    End Sub

    Protected Sub login()
        lid.Text = uid.Text
        lname.Text = uname.Text
    End Sub

    Protected Sub Display()
        Try
            ad = New SqlDataAdapter("select * from stocks", con)
            ds = New DataSet
            ad.Fill(ds)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection()
        login()
    End Sub

    Protected Sub btn_signup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_signup.Click
        connection()
        Create()
        insert()
        login()
    End Sub

    Protected Sub btn_login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_login.Click
        connection()
        Display()
    End Sub
End Class
