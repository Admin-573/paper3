Imports System.Data.SqlClient
Imports System.Data
Partial Class Default3
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

    Protected Sub Update()
        Dim getID As Integer = Convert.ToInt64(Request.QueryString("sid"))
        cmd = New SqlCommand("update stocks set sname='" & sname.Text & "' where sid='" & getID & "'", con)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Stocks Updated")
            Response.Redirect("Default.aspx")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection()
        Dim getID As Integer = Convert.ToInt64(Request.QueryString("sid"))
        cmd = New SqlCommand("select * from stocks where sid='" & getID & "'", con)

        Try
            ad = New SqlDataAdapter(cmd)
            ds = New DataSet
            ad.Fill(ds)
            If IsPostBack = False Then
                sid.Text = ds.Tables(0).Rows(0).Item(0).ToString
                sname.Text = ds.Tables(0).Rows(0).Item(1).ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btn_upd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_upd.Click
        connection()
        Update()
    End Sub
End Class
