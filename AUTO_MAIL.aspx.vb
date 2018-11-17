Imports System.Data.OracleClient
Imports System.Configuration
Imports System.Net.Mail
Imports System.Data

Partial Class EVENT_MAIL
    Inherits System.Web.UI.Page

    Private EVNT As New Timer

    Dim con As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("constr").ToString())
    Dim cmd As New OracleCommand

    Dim clas As rahulcpm.commonclass = New rahulcpm.commonclass()
    Dim qry As String
    Dim dt As System.Data.DataTable
    Dim query As StringBuilder = New StringBuilder   

    Protected Sub BTN1_Click(sender As Object, e As System.EventArgs) Handles BTN1.Click

        Response.Write("clicked: " & Now.ToString)

    End Sub

    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load

        ams_candidatemails_proc()
        event_remindermails_proc()
        mycase_noaction_proc()

        Response.Write("Exectuted ams_candidatemail, event_remindermails_proc, AMS_CandNoAction_MAIL_Proc on : " & Now.ToString)
    End Sub
    Protected Sub mycase_noaction_proc()
        Try
            cmd.CommandText = "tt.mycase_mail_noactlaw"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            cmd.Dispose()
        Catch ex As Exception
            Dim statmsgs = ""
            If ex.Message.Contains("TNS:listener does not currently know of service requested in connect descriptor") = True Then
                statmsgs = ex.Message.ToString()
            ElseIf ex.Message.Contains("TNS:Connect timeout occurred") Then
                statmsgs = ex.Message.ToString()
            Else
                statmsgs = ex.Message.ToString()
            End If

        End Try
    End Sub
    Protected Sub ams_candidatemails_proc()
        Try
            cmd.CommandText = "tt.AMS_CandNoAction_MAIL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            cmd.Dispose()
        Catch ex As Exception
            Dim statmsgs = ""
            If ex.Message.Contains("TNS:listener does not currently know of service requested in connect descriptor") = True Then
                statmsgs = ex.Message.ToString()
            ElseIf ex.Message.Contains("TNS:Connect timeout occurred") Then
                statmsgs = ex.Message.ToString()
            Else
                statmsgs = ex.Message.ToString()
            End If

        End Try
    End Sub
    Protected Sub event_remindermails_proc()
        Try            
            cmd.CommandText = "tt.EVENT_MAIL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            cmd.Dispose()
        Catch ex As Exception
            Dim statmsgs = ""
            If ex.Message.Contains("TNS:listener does not currently know of service requested in connect descriptor") = True Then
                statmsgs = ex.Message.ToString()
            ElseIf ex.Message.Contains("TNS:Connect timeout occurred") Then
                statmsgs = ex.Message.ToString()
            Else
                statmsgs = ex.Message.ToString()
            End If

        End Try


    End Sub
    Private Sub ams_candidatemails()
        Try
            dt = clas.getdata("select * from  AMS.BDC_LEAD_MASTER where CANDRESULT is null and to_date(keyedon,'dd-Mon-yyyy') < to_date(sysdate,'dd-Mon-yyyy')", "tx")
            Dim body_str As New StringBuilder

            If dt.Rows.Count > 0 Then
                Dim dt2 As System.Data.DataTable
                body_str.Append("Dear User, <br/><br/> This is system generated email reminds you that no action has been taken from past 24 hours for below candidates. <br/><br/> <table border=1 style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify; > <tr> <th> Name </th> <th> Email</th> <th> Keyedon </th> </tr>")
                'select decode(EVNTLVLSCP,'B','1','O',EVNTID) into cid from dual;

                dt2 = clas.getdata("select   ", "tx")

                For i = 0 To dt.Rows.Count - 1

                    body_str.Append("<tr> <td>'" & dt.Rows(i)("CANDNAME") & "' </td> ")
                    body_str.Append(" <td>'" & dt.Rows(i)("CANDEML") & "' </td> ")
                    body_str.Append(" <td>'" & dt.Rows(i)("keyedon") & "' </td> </tr> ")

                Next

            End If

            qry = " insert into rahul.autoemail (ID,MAILSUB,MAILTO,MAILINT,MAILFRM,MAILBCC,MAILCC,MAILRPLYTO,DEPT,PRSN,BODYSTT,MAILSNDON,STATUS,KEYEDON,MAILTEMP)   values "
            qry += "(rahul.automail_seq.nextval,'AMS Reminder email for no action taken','itdept@wwicsgroup.com', 'AMS Intimation no action taken','mis_alerts@acumen-services.com','itdept@wwicsgroup.com',null,null,null,null,'" & body_str.ToString & "',sysdate,'I',sysdate,'3')"
            clas.ExecuteNonQuery(qry)

        Catch ex As Exception
            If ex.Message.Contains("OutOfMemory") Then
                Response.Write("<ul><li><div style=color:Red;>This is a temporary issue; please try to Re-Login after some time.</div></li></ul>")
            Else
                Dim Err_Msg As String = ex.Message.ToString.Replace(vbCrLf, "")
                Err_Msg = Err_Msg.Replace(vbCr, "")
                Err_Msg = Err_Msg.Replace(vbLf, "")
                Response.Write("<ul><li><div style=color:Red;>" & Err_Msg & ".</div></li></ul>")
            End If
        End Try

    End Sub


    Private Sub event_remindermails()
        dt = clas.getdata(" select * from tt.evnt_mail_vw2 ", "tx")
        Dim body_str As New StringBuilder

        If dt.Rows.Count > 0 Then
            body_str.Append("Dear User, <br/><br/> This is system generated email reminds you that no action has been taken from past 24 hours for below candidates. <br/><br/> <table border=1 style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify; > <tr> <th> Name </th> <th> Email</th> <th> Keyedon </th> </tr>")


            For i = 0 To dt.Rows.Count - 1
                body_str.Clear()
                If dt.Rows(i)("perAct") <= 60 And dt.Rows(i)("perAct") >= 0 Then

                    body_str.Append("Dear User, <br/><br/> This is to intimate you that activity: " & dt.Rows(i)("ACTTYPE") & " is assigned on  " & dt.Rows(i)("keyedon") & " is pending for your action. You have consumed " & (100 - dt.Rows(i)("perAct")) & "% of time. <br/><br/>")
                    body_str.Append("<table style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify;>")
                    body_str.Append("<tr><td> Activity </td> <td>" & dt.Rows(i)("acttype") & " </td> </tr><tr><td> Activity held on </td> <td>" & dt.Rows(i)("actdt") & "</td> </tr> <tr><td> Activity assign date </td> <td>" & dt.Rows(i)("keyedon") & "</td> </tr> <tr><td> Event date </td> <td>" & dt.Rows(i)("evntdt") & "  </td> </tr> </table>")

                    qry = "insert into rahul.autoemail (ID,MAILSUB,MAILTO,MAILINT,MAILFRM,MAILBCC,MAILCC,MAILRPLYTO,DEPT,PRSN,BODYSTT,MAILSNDON,STATUS,KEYEDON) "
                    qry += " values  (rahul.automail_seq.nextval,'Activity Pending for your Intimation (Event Calendar)','" & dt.Rows(i)("ACTASGNTO_EM") & "' , 'Activity Pending for your Intimation (Event Calendar)','mis_alert@wwicsgroup.com','itdept@wwicsgroup.com','" & dt.Rows(i)("EVNTRSPEMP_EM") & "' ,null,null,null,'" & body_str.ToString & "',sysdate,'I',sysdate;"
                    clas.ExecuteNonQuery(qry)
                End If

                If dt.Rows(i)("perAct") < 0 Then
                    'warning mail activity date is over
                    If dt.Rows(i)("eventdays") >= 0 Then
                        body_str.Append(" Dear User, <br/> <br/>  This is to warn you that activity: '|| v_mail.ACTTYPE || ' is assigned on '|| v_mail.keyedon || ' is still pending for your action. <br/><br/>")

                        body_str.Append("<table style=font-size:12px; line-height:16px;  font-family:Arial, Helvetica, sans-serif; text-align:justify;>")
                        body_str.Append("<tr><td> Activity </td> <td>'" & dt.Rows(i)("acttype") & "' </td> </tr><tr><td> Activity held on </td> <td>'" & dt.Rows(i)("actdt") & "'</td> </tr>")
                        body_str.Append(" <tr><td> Activity assign date </td> <td>'" & dt.Rows(i)("keyedon") & "' </td> </tr> <tr><td> Event date </td> <td>'" & dt.Rows(i)("evntdt") & "'</td> </tr></table>")


                        qry = "insert into rahul.autoemail (ID,MAILSUB,MAILTO,MAILINT,MAILFRM,MAILBCC,MAILCC,MAILRPLYTO,DEPT,PRSN,BODYSTT,MAILSNDON,STATUS,KEYEDON) "
                        qry += " values  (rahul.automail_seq.nextval,'Activity Pending for your Intimation (Event Calendar)','" & dt.Rows(i)("ACTASGNTO_EM") & "' , 'Activity Pending for your Intimation (Event Calendar)','mis_alert@wwicsgroup.com','itdept@wwicsgroup.com','" & dt.Rows(i)("EVNTRSPEMP_EM") & "',null,null,null,'" & body_str.ToString & "',sysdate,'I',sysdate)"
                        clas.ExecuteNonQuery(qry)
                    End If
                End If

            Next

        End If


    End Sub
End Class
