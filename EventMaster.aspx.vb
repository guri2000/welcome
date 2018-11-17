Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration
Partial Class EventMaster
    Inherits System.Web.UI.Page
    Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString, strSql As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If (IsPostBack = False) Then
            bindDDL("select CMPID,CMPNM from ranu.companymaster where status='A' order by cmpnm", ddlCompany)
            bindDDL("select CMPID,CMPNM from ranu.companymaster where status='A' order by cmpnm", ddlCompanyEvent)
            bindDepartmentGrid()
            bindEventGrid()
        End If
    End Sub
    Private Sub bindParent()
        strSql = "select actid,actdescr from TT.event_activity where "
        If ddlDeptGroup.SelectedValue <> "-1" Then
            strSql += "deptgrpid=" + ddlDeptGroup.SelectedValue + " and "
        End If
        strSql += "parentid is null and actstats='A' order by actdescr"
        bindDDL(strSql, ddlParent)
    End Sub
    Private Sub bindDepMasterGroup()
        strSql = "select grpid,grpdescr from tt.deptmast_grp where "
        If ddlCompanyEvent.SelectedValue <> "-1" Then
            strSql += "cmpid=" + ddlCompanyEvent.SelectedValue + " and "
        End If
        strSql += "grpstat='A' order by grpdescr"
        bindDDL(strSql, ddlDeptGroup)
    End Sub
    Private Sub bindDepartmentGrid()
        strSql = "select grp.grpid,grp.grpdescr,cm.cmpnm from tt.deptmast_grp grp left outer join ranu.companymaster cm on cm.cmpid=grp.cmpid where grp.grpstat='A' order by 3,2"
        dgvDepartments.DataSource = getDataTable(strSql)
        dgvDepartments.DataBind()
    End Sub
    Private Sub bindEventGrid()
        strSql = "select act.actid,act.actdescr,grp.grpdescr,actPaernt.actid parentid,actPaernt.actdescr Parent from TT.event_activity act left outer join tt.deptmast_grp grp on grp.grpid = act.deptgrpid left outer join TT.event_activity actPaernt on actPaernt.actid=act.parentid where act.actstats='A' "
        If ddlCompanyEvent.SelectedValue <> "-1" Then
            strSql += "and grp.cmpid=" + ddlCompanyEvent.SelectedValue + " "
        End If
        If ddlDeptGroup.SelectedValue <> "-1" And ddlDeptGroup.SelectedValue <> "" Then
            strSql += "and act.deptgrpid=" + ddlDeptGroup.SelectedValue + " "
        End If
        If ddlParent.SelectedValue <> "-1" And ddlParent.SelectedValue <> "" Then
            strSql += "and act.parentid=" + ddlParent.SelectedValue + " "
        End If
        strSql += "order by 3,5"
        dgvEvent.DataSource = getDataTable(strSql)
        dgvEvent.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtDeptDesc.Text = String.Empty Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Please add Department Description to Continue", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Please add Department Description to Continue');</script>")
            Exit Sub
        End If
        If ddlCompany.SelectedValue = "-1" Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Please select Department Company to Continue", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Please select Company to Continue');</script>")
            Exit Sub
        End If
        strSql = "insert into tt.deptmast_grp(GRPID,GRPDESCR,GRPSTAT,CMPID) values ((select nvl(max(grpid),0)+1 from tt.deptmast_grp),'" + txtDeptDesc.Text + "','A'," + ddlCompany.SelectedValue + ")"
        Dim res As Int32 = excecuteNonQuery(strSql)
        If res > 0 Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Record Saved Successfully", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Record Saved Successfully');</script>")
            refreshDept()
            bindDepartmentGrid()
        Else
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Problem While Saving", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Problem While Saving');</script>")
        End If

    End Sub
    Public Sub bindDDL(ByVal strSql As String, ByVal ddl As DropDownList)
        Dim dt As DataTable = New DataTable
        Dim adp As New OracleDataAdapter
        Try

            adp = New OracleDataAdapter(strSql, conStr)
            adp.Fill(dt)
            ddl.DataValueField = dt.Columns(0).ColumnName.ToString
            ddl.DataTextField = dt.Columns(1).ColumnName.ToString
            ddl.DataSource = dt
            ddl.DataBind()
            ddl.Items.Insert(0, New ListItem("Select", "-1"))
        Catch ex As Exception

        Finally
            adp.Dispose()
        End Try

    End Sub
    Public Function getDataTable(ByVal strSql As String) As DataTable
        Dim dt As DataTable = New DataTable
        Dim adp As New OracleDataAdapter
        Try
            adp = New OracleDataAdapter(strSql, conStr)
            adp.Fill(dt)
        Catch ex As Exception
            Return dt
        Finally
            adp.Dispose()
        End Try

        Return dt
    End Function
    Public Function excecuteNonQuery(ByVal strSql As String) As Int32
        Dim res As Int32 = 0
        Dim con As OracleConnection
        Dim cmd As OracleCommand
        Try
            con = New OracleConnection(conStr)
            If (con.State = ConnectionState.Closed) Then
                con.Open()
            End If

            cmd = New OracleCommand(strSql, con)
            res = Convert.ToInt32(cmd.ExecuteNonQuery)
        Catch ex As Exception
            Return res
        Finally
            If (Not (cmd) Is Nothing) Then
                cmd.Dispose()
            End If

            If (con.State = ConnectionState.Open) Then
                con.Close()
            End If

        End Try

        Return res
    End Function

    Protected Sub btnSaveEvent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveEvent.Click
        If txtEventDescription.Text = String.Empty Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Please add Event Description to Continue", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Please add Event Description to Continue');</script>")
            Exit Sub
        End If
        If ddlDeptGroup.SelectedValue = "-1" Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Please select Department Group to Continue", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Please select Department Group to Continue');</script>")
            Exit Sub
        End If
        If ddlParent.SelectedValue = "-1" And RadioButtonList1.SelectedValue = "2" Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Please select Parent to Continue", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Please select Parent to Continue');</script>")
            Exit Sub
        End If
        If RadioButtonList1.SelectedValue = "1" Then
            strSql = "insert into TT.event_activity(ACTID,ACTDESCR,DEPTGRPID,ACTSTATS) values ((select nvl(max(actid),0)+1 from TT.event_activity),'" + txtEventDescription.Text + "'," + ddlDeptGroup.SelectedValue + ",'A')"
        Else
            strSql = "insert into TT.event_activity(ACTID,ACTDESCR,DEPTGRPID,ACTSTATS,PARENTID) values ((select nvl(max(actid),0)+1 from TT.event_activity),'" + txtEventDescription.Text + "'," + ddlDeptGroup.SelectedValue + ",'A'," + ddlParent.SelectedValue + ")"
        End If

        Dim res As Int32 = excecuteNonQuery(strSql)
        If res > 0 Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Event Activity Saved Successfully", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Event Activity Saved Successfully');</script>")
            refreshEvent()
            bindEventGrid()
        Else
            'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Problem While Saving", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "<script type = 'text/javascript'>alert('Problem While Saving');</script>")
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        'ClientScript.RegisterStartupScript(Me.GetType(), "AlertMessageBox", "Problem While Saving", True)
        If RadioButtonList1.SelectedValue = "1" Then
            divParent.Visible = False

        Else
            divParent.Visible = True
        End If
    End Sub
    Private Sub refreshDept()
        txtDeptDesc.Text = String.Empty
        ddlCompany.SelectedValue = "-1"
    End Sub
    Private Sub refreshEvent()
        txtEventDescription.Text = String.Empty
        ddlDeptGroup.SelectedValue = "-1"
        ddlParent.SelectedValue = "-1"
    End Sub

    Protected Sub ddlCompanyEvent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCompanyEvent.SelectedIndexChanged
        bindDepMasterGroup()
        bindEventGrid()
    End Sub

    Protected Sub ddlDeptGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeptGroup.SelectedIndexChanged
        bindParent()
        bindEventGrid()
    End Sub

    Protected Sub ddlParent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlParent.SelectedIndexChanged
        bindEventGrid()
    End Sub
End Class
