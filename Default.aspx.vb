Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default
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

    Protected Sub create()
        cmd = New SqlCommand("create table stocks(sid int primary key,sname text)", con)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub insert()
        cmd = New SqlCommand("insert into stocks values(@sid,@sname)", con)
        Try
            cmd.Parameters.AddWithValue("@sid", Convert.ToInt64(sid.Text.Trim))
            cmd.Parameters.AddWithValue("@sname", sname.Text.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Stock Added")
        Catch ex As Exception
            MsgBox("ID Unvaliable Please Try New One")
        End Try
    End Sub

    Protected Sub clear()
        sid.Text = ""
        sname.Text = ""
    End Sub

    Protected Sub Display()
        Try
            ad = New SqlDataAdapter("select * from stocks", con)
            ds = New DataSet
            ad.Fill(ds)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btn_login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Try
            If id.Text = "admin" And pass.Text = "admin123" Then
                MsgBox("Good To Go")
                Response.Redirect("Default.aspx")
            Else
                MsgBox("ID & Pass Wrong")
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btn_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_add.Click
        connection()
        create()
        insert()
        Display()
        clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection()
        Display()
    End Sub
End Class
