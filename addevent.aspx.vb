Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Drawing
Imports Telerik.Web.UI
Imports System.Data
Imports System.IO
Imports System.Threading
Partial Class addevent
    Inherits System.Web.UI.Page
    Dim clas As rahulcpm.commonclass = New rahulcpm.commonclass()
    Dim dt As DataTable = New DataTable()



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox4.Text.Trim().Length > 0 Then
            TextBox4.Text = TextBox4.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")
        End If
        If TextBox42.Text.Trim().Length > 0 Then
            TextBox42.Text = TextBox42.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")
        End If
        If TextBox1.Text.Trim().Length > 0 Then
            TextBox1.Text = TextBox1.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")
        End If


        Dim actid = ""
        Dim flststhas = "N"
        Dim flvalis = "Y"
        Dim flststsreqs = "N"
        Dim mastflststsreqs = "N"
        Dim str As StringBuilder = New StringBuilder()
        If Button1.Text = "Update" Then

            If IsDBNull(ViewState("id")) = False Then
                Dim evntid = Convert.ToString(ViewState("id"))

                '     Dim Timefrom = "TO_DATE('" & dt_upload.SelectedDate.Value.ToString("dd-MMM-yyyy") & "  " & dtpTimeIn.SelectedDate.Value.ToString("HH:mm:ss") & "','dd-MON-yyyy hh24:mi:ss')"

                '   str.Append("update tt.evnt_mast set EVNTSUB='" & TextBox2.Text & "', EVNTDESC='" & TextBox3.Text & "', EVNTSTDT='" & CDate(dt_upload.SelectedDate).ToString("dd-MMM-yyyy") & "', EVNTEDDT='" & CDate(RadDatePicker1.SelectedDate).ToString("dd-MMM-yyyy") & "', EVNTLVLSCP='" & ddllevl.SelectedValue & "',EVNTLVLSCP1='" & DropDownList2.SelectedValue & "',EVNTLVLID='" & DropDownList1.SelectedValue & "',EVNTLVLID1='" & DropDownList3.SelectedValue & "', EVNTCAT=" & DropDownList4.SelectedValue & "', EVNTSTS='" & DropDownList8.SelectedValue & "', LASTUPDON=sysdate, LASTUPDBY='1', LASTUPDIP='" & HttpContext.Current.Request.UserHostAddress & "', LASTUPDBRWS='" & Request.Browser.Browser & "',EVNTPRTY='" & DropDownList6.SelectedValue & "',EVNTPRD='" & DropDownList5.SelectedValue & "',EVNTRSPEMP='" & DropDownList9.SelectedValue & "',EVNTSTTIM=" & If(Timefrom Is Nothing, "null", Timefrom) & " where EVNTID='" & evntid & "'")




            Else


            End If


        Else

            If DropDownList11.SelectedValue = "1000000" Then
                flststsreqs = "Y"
            Else
                flststsreqs = "N"
            End If


            If FileUpload1.HasFile = True Then

                Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName).ToLower()

                If fileName = "" Then
                    flvalis = "N"
                    RadWindowManager1.RadAlert("<div style=color:green;> Please browse Approval File. </div>", 300, 150, "Validation Success", Nothing)

                    Exit Sub

                Else

                    If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("+") Or fileName.Contains("&") Then
                        flvalis = "N"
                        RadWindowManager1.RadAlert("<div style=color:red;> Invalid File Name. </div>", 300, 150, "Validation Success", Nothing)
                        Exit Sub

                    Else

                        Dim ext As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
                        If ext.ToLower.Contains(".exe") = True Or ext.ToLower.Contains(".dll") = True Or ext.ToLower.Contains(".bat") = True Or ext.ToLower.Contains(".msi") = True Or ext.ToLower.Contains(".setup") = True Then
                            flvalis = "N"
                            RadWindowManager1.RadAlert("<div style=color:green;> Please upload valid file. </div>", 300, 150, "Validation Success", Nothing)
                            Exit Sub

                        Else
                            flvalis = "Y"
                        End If


                    End If


                End If
            Else
                flvalis = "N"
            End If



            If flststsreqs = "N" Then

                ' If flvalis = "N" Then

                mastflststsreqs = flvalis
                'Else
                '   mastflststsreqs = "Y"


                '  End If


            Else

                If flvalis = "Y" Then

                    mastflststsreqs = "Y"
                Else

                    RadWindowManager1.RadAlert("<div style=color:green;>Approval Document is required. </div>", 300, 150, "Validation Success", Nothing)
                    Exit Sub

                End If

            End If


            actid = clas.getMaxID("select tt.EVNT_ACT_SEQ.nextval from dual")

            str.Append("insert into tt.EVNT_ACT (TRANSID,EVNTID, CURRCODE, AMOUNT, ACTTYP, ACTDT, ACTCMNTS,STATUS,ACTALRTS,ACTEMAIL, KEYEDON, KEYEDBY, KEYEDIP, KEYEDBRWS,ACTASGNTO,ACTAGNCY,APPFILESTS) values ")
            str.Append(" ('" & actid & "','" & ViewState("id") & "','" & DropDownList7.SelectedValue & "','" & TextBox1.Text & "','" & DropDownList10.SelectedValue & "','" & CDate(RadDatePicker2.SelectedDate).ToString("dd-MMM-yyyy") & "',")
            '  str.Append("'" & TextBox4.Text & "','" & DropDownList12.SelectedValue & "','" & If(chkbox.Checked = True, "T", "F") & "','" & TextBox5.Text & "',sysdate,'1','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "','" & DropDownList11.SelectedValue & "')")
            str.Append("'" & TextBox4.Text & "','2073','F','',sysdate,'" & Convert.ToString(Request.QueryString("empid")) & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "','" & DropDownList11.SelectedValue & "','" & TextBox42.Text.Trim() & "','" & mastflststsreqs & "')")
        End If


        '     Response.Write(str.ToString)

        Dim i = clas.ExecuteNonQuery(str.ToString)

        If i = 1 Then



            If FileUpload1.HasFile = True Then

                Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName).ToLower()

                If fileName = "" Then
                    RadWindowManager1.RadAlert("<div style=color:green;> Please browse Approval. </div>", 300, 150, "Validation Success", Nothing)
                    Exit Sub

                Else

                    If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("+") Or fileName.Contains("&") Then
                        RadWindowManager1.RadAlert("<div style=color:red;> Invalid File Name. </div>", 300, 150, "Validation Success", Nothing)
                        Exit Sub
                    End If

                    fileName = Replace(fileName.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                    Dim actfileName As String = fileName

                    Dim ext As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
                    '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                    Dim fileSize As Long = FileUpload1.PostedFile.ContentLength
                    '  If fileSize < 5145728 Then
                    If ext.ToLower.Contains(".exe") = False Or ext.ToLower.Contains(".dll") = False Or ext.ToLower.Contains(".bat") = False Or ext.ToLower.Contains(".msi") = False Or ext.ToLower.Contains(".setup") = False Then
                        fileName = fileName.Replace(" ", "_")

                        Dim FileNM1 As String() = fileName.Split(".")
                        Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                        fileName = FileNM1(0) & datestr & ext

                        Dim Path As String = (Server.MapPath("eventdoc/") + fileName)
                        FileUpload1.PostedFile.SaveAs(Path)

                        Dim client_ip As String = Request.UserHostAddress()
                        Dim Browser_Name As String = Request.Browser.Browser.ToString & " " & Request.Browser.Version.ToString

                        Dim str1 As StringBuilder = New StringBuilder()

                        str1.Append("insert into TT.EVNT_DOCLIB (TRANSID,DOCID,EVNTID, DOCDT, DOCPTH, DOCRMKS, DOCUPLDBY, DOCSTATUS,KEYEDIP,keyedbrws,ACTID) values ")
                        str1.Append(" (TT.DOCLIB_SEQ.nextval ,'1','" & ViewState("id") & "',sysdate,")
                        str1.Append("'" & fileName & "','Approval Document','" & Convert.ToString(Request.QueryString("empid")) & "','A','" & client_ip & "','" & Browser_Name & "','" & actid & "')")

                        Dim j = clas.ExecuteNonQuery(str1.ToString)




                    Else
                        RadWindowManager1.RadAlert("<div style=color:green;> Please upload valid file. </div>", 300, 150, "Validation Success", Nothing)
                        Exit Sub

                    End If


                End If
            End If




            clr()
            binactgrid(Convert.ToString(ViewState("id")))
            '  RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Record Commited Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
            Exit Sub
        Else

            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "").Replace("""", "").Replace("'", "")
            Err_Msg = Err_Msg.Replace(vbCr, "")
            Err_Msg = Err_Msg.Replace(vbLf, "")

            If Err_Msg.Trim().Length > 0 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            Else
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            End If

            Exit Sub

        End If



    End Sub


    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim evntid = ""
    '    Dim str As StringBuilder = New StringBuilder()
    '    If ImageButton1.Text = "Update" Then

    '        If IsDBNull(ViewState("id")) = False Then
    '            evntid = Convert.ToString(ViewState("id"))
    '            If Not RadioButtonList1.SelectedValue Is Nothing Then
    '                str.Append(",EVNTAPPEXST='" & RadioButtonList1.SelectedValue & "'")
    '            End If
    '            If TextBox5.Text.Trim().Length > 0 And Not DropDownList12.SelectedValue Is Nothing Then
    '                str.Append(",EVNTAPPTO='" & TextBox5.Text.Trim() & "@" & DropDownList12.SelectedValue & "'")
    '            End If


    '            str.Append(" where EVNTID='" & evntid & "'")
    '        End If

    '    End If



    'End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageButton1.Click, Button2.Click, Button3.Click, Button4.Click


        If TextBox3.Text.Trim().Length > 0 Then
            TextBox3.Text = TextBox3.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")

        End If
        If TextBox2.Text.Trim().Length > 0 Then
            TextBox2.Text = TextBox2.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")

        End If
        If TextBox6.Text.Trim().Length > 0 Then
            TextBox6.Text = TextBox6.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")

        End If

        Dim evntid = ""
        Dim str As StringBuilder = New StringBuilder()
        If ImageButton1.Text = "Update" Then

            If IsDBNull(ViewState("id")) = False Then
                evntid = Convert.ToString(ViewState("id"))

                Dim Timefrom = "TO_DATE('" & dt_upload.SelectedDate.Value.ToString("dd-MMM-yyyy") & "  " & dtpTimeIn.SelectedDate.Value.ToString("HH:mm:ss") & "','dd-MON-yyyy hh24:mi:ss')"
                str.Append("update tt.evnt_mast set EVNTSUB='" & TextBox2.Text & "' ")
                If sender Is ImageButton1 Then
                    str.Append(", EVNTDESC='" & TextBox3.Text & "', EVNTSTDT='" & CDate(dt_upload.SelectedDate).ToString("dd-MMM-yyyy") & "', EVNTEDDT='" & CDate(RadDatePicker1.SelectedDate).ToString("dd-MMM-yyyy") & "', EVNTLVLSCP='" & ddllevl.SelectedValue & "',EVNTLVLSCP1='" & DropDownList2.SelectedValue & "',EVNTLVLID='" & DropDownList1.SelectedValue & "',EVNTLVLID1='" & DropDownList3.SelectedValue & "', EVNTCAT='" & DropDownList4.SelectedValue & "', EVNTSTS='" & DropDownList8.SelectedValue & "',EVNTPRTY='" & DropDownList6.SelectedValue & "',EVNTPRD='" & DropDownList5.SelectedValue & "',EVNTRSPEMP='" & DropDownList9.SelectedValue & "',EVNTSTTIM=" & If(Timefrom Is Nothing, "null", Timefrom) & "")



                ElseIf sender Is Button2 Then

                    If Not RadioButtonList1.SelectedValue Is Nothing Then
                        str.Append(",EVNTAPPEXST='" & RadioButtonList1.SelectedValue & "'")
                    End If
                    If TextBox5.Text.Trim().Length > 0 And Not DropDownList12.SelectedValue Is Nothing Then
                        str.Append(",EVNTAPPTO='" & TextBox5.Text.Trim() & "@" & DropDownList12.SelectedValue & "'")
                    End If

                ElseIf sender Is Button3 Then

                     If Not DropDownList8.SelectedValue Is Nothing Then
                        str.Append(",EVNTSTS='2065'")
                    End If


                ElseIf sender Is Button4 Then


                    Dim Timefrom1 = ""

                    If Not DropDownList8.SelectedValue Is Nothing Then
                        str.Append(",EVNTSTS='" & DropDownList8.SelectedValue & "'")
                    End If
                    If TextBox6.Text.Trim().Length > 0 Then
                        str.Append(",ENVTDESRSN='" & TextBox6.Text.Trim() & "'")
                    End If

                    If Not RadDatePicker3.SelectedDate Is Nothing Then

                        str.Append(",EVNTPREDT='" & CDate(RadDatePicker3.SelectedDate).ToString("dd-MMM-yyyy") & "'")

                    End If

                    If Not RadDatePicker4.SelectedDate Is Nothing Then

                        str.Append(",EVNTPREENDDT='" & CDate(RadDatePicker4.SelectedDate).ToString("dd-MMM-yyyy") & "'")

                    End If
                    If Not RadTimePicker1.SelectedDate Is Nothing Then

                        Timefrom1 = "TO_DATE('" & RadDatePicker3.SelectedDate.Value.ToString("dd-MMM-yyyy") & "  " & RadTimePicker1.SelectedDate.Value.ToString("HH:mm:ss") & "','dd-MON-yyyy hh24:mi:ss')"


                        str.Append(",EVNTPRESTTYM=" & Timefrom1 & "")

                    End If


                End If


                str.Append(", LASTUPDON=sysdate, LASTUPDBY='" & Convert.ToString(Request.QueryString("empid")) & "', LASTUPDIP='" & HttpContext.Current.Request.UserHostAddress & "', LASTUPDBRWS='" & Request.Browser.Browser & "'")

                str.Append(" where EVNTID='" & evntid & "'")


            Else


            End If







        Else
            evntid = clas.getMaxID("select tt.evnt_mast_seq.nextval from dual")


            Dim Timefrom = "TO_DATE('" & dt_upload.SelectedDate.Value.ToString("dd-MMM-yyyy") & "  " & dtpTimeIn.SelectedDate.Value.ToString("HH:mm:ss") & "','dd-MON-yyyy hh24:mi:ss')"
            'Dim endfrom = ""

            'If chkb.SelectedValue = "0" Then
            '    endfrom = "TO_DATE('" & RadDatePicker1.SelectedDate.Value.ToString("dd-MMM-yyyy") & " ','dd-MON-yyyy hh24:mi:ss')"

            'Else
            '    endfrom = "TO_DATE('" & RadDatePicker1.SelectedDate.Value.ToString("dd-MMM-yyyy") & "  " & dtpTimeIn.SelectedDate.Value.AddHours(chkb.SelectedValue).ToString("HH:mm:ss") & "','dd-MON-yyyy hh24:mi:ss')"
            'End If




            str.Append("insert into tt.evnt_mast (EVNTID, EVNTSUB, EVNTDESC, EVNTSTDT, EVNTEDDT, EVNTLVLSCP,EVNTLVLSCP1,EVNTLVLID,EVNTLVLID1, EVNTCAT, EVNTSTS, KEYEDON, KEYEDBY, KEYEDIP, KEYEDBRWS,EVNTPRTY,EVNTPRD,EVNTRSPEMP,EVNTSTTIM,EVNTTYMSTS) values ")
            str.Append(" ('" & evntid & "' ,'" & TextBox2.Text & "','" & TextBox3.Text & "','" & CDate(dt_upload.SelectedDate).ToString("dd-MMM-yyyy") & "', '" & CDate(RadDatePicker1.SelectedDate).ToString("dd-MMM-yyyy") & "',")
            str.Append("'" & ddllevl.SelectedValue & "','" & DropDownList2.SelectedValue & "','" & DropDownList1.SelectedValue & "','" & DropDownList3.SelectedValue & "','" & DropDownList4.SelectedValue & "','" & DropDownList8.SelectedValue & "',sysdate,'" & Convert.ToString(Request.QueryString("empid")) & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "','" & DropDownList6.SelectedValue & "','" & DropDownList5.SelectedValue & "','" & DropDownList9.SelectedValue & "'," & If(Timefrom Is Nothing, "null", Timefrom) & ",'" & chkb.SelectedValue & "')")

        End If


        '  Response.Write(str.ToString)

        Dim i = clas.ExecuteNonQuery(str.ToString)

        If i = 1 Then

            If sender Is Button3 Then

                If fupl.HasFile = True Then

                    Dim fileName As String = Path.GetFileName(fupl.PostedFile.FileName).ToLower()

                    If fileName = "" Then
                        RadWindowManager1.RadAlert("<div style=color:green;> Please browse Approval. </div>", 300, 150, "Validation Success", Nothing)
                        Exit Sub

                    Else

                        If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("+") Or fileName.Contains("&") Then
                            RadWindowManager1.RadAlert("<div style=color:red;> Invalid File Name. </div>", 300, 150, "Validation Success", Nothing)
                            Exit Sub
                        End If

                        fileName = Replace(fileName.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                        Dim actfileName As String = fileName

                        Dim ext As String = System.IO.Path.GetExtension(fupl.PostedFile.FileName)
                        '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                        Dim fileSize As Long = fupl.PostedFile.ContentLength
                        '  If fileSize < 5145728 Then
                        If ext.ToLower.Contains(".exe") = False Or ext.ToLower.Contains(".dll") = False Or ext.ToLower.Contains(".bat") = False Or ext.ToLower.Contains(".msi") = False Or ext.ToLower.Contains(".setup") = False Then
                            fileName = fileName.Replace(" ", "_")

                            Dim FileNM1 As String() = fileName.Split(".")
                            Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                            fileName = FileNM1(0) & datestr & ext

                            Dim Path As String = (Server.MapPath("eventdoc/") + fileName)
                            fupl.PostedFile.SaveAs(Path)

                            Dim client_ip As String = Request.UserHostAddress()
                            Dim Browser_Name As String = Request.Browser.Browser.ToString & " " & Request.Browser.Version.ToString

                            Dim str1 As StringBuilder = New StringBuilder()

                            str1.Append("insert into TT.EVNT_DOCLIB (TRANSID,DOCID,EVNTID, DOCDT, DOCPTH, DOCRMKS, DOCUPLDBY, DOCSTATUS,KEYEDIP,keyedbrws) values ")
                            str1.Append(" (TT.DOCLIB_SEQ.nextval ,'1','" & evntid & "',sysdate,")
                            str1.Append("'" & fileName & "','Approval Document','" & Convert.ToString(Request.QueryString("empid")) & "','A','" & client_ip & "','" & Browser_Name & "')")

                            Dim j = clas.ExecuteNonQuery(str1.ToString)




                        Else
                            RadWindowManager1.RadAlert("<div style=color:green;> Please upload valid file. </div>", 300, 150, "Validation Success", Nothing)
                            Exit Sub

                        End If


                    End If
                End If

            End If

            If sender Is ImageButton1 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Added  Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                Response.Redirect("addevent.aspx?id=" & evntid & "")
            Else
                If sender Is Button2 Then

                    If RadioButtonList1.SelectedValue = "E" Then
                        RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Approval Confirmation Received Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                    Else

                        If Button2.Text = "Send Mail" Then


                            clas.sendmail("Approval For New Event Added", "Dear user, please send me approval for new Event", TextBox5.Text.Trim() & "@" & DropDownList12.SelectedValue)


                            RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Approval Mail Sent Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                        Else
                            clas.sendmail("Re Approval For New Event Added", "Dear user, please send me approval for new Event", TextBox5.Text.Trim() & "@" & DropDownList12.SelectedValue)
                            RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Approval Mail Re-Sent Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                        End If

                    End If



                ElseIf sender Is Button3 Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Approval Uploaded  Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)

                ElseIf sender Is Button4 Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Details Updated Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                Else
                    RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Event Details Updated Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                End If

                getdetl(evntid)
            End If


            Exit Sub
        Else

            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "").Replace("""", "").Replace("'", "")
            Err_Msg = Err_Msg.Replace(vbCr, "")
            Err_Msg = Err_Msg.Replace(vbLf, "")

            If Err_Msg.Trim().Length > 0 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            Else
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            End If

            Exit Sub

        End If



    End Sub

    Private Sub bindcurr()
        dt = clas.getdata("select descr||'(' || currcode ||')' Description, currcode ID from tt.currencymaster", "QR")
        bindfromdt(DropDownList7, "", dt, "", "Description", "id", "dropdown", True)
    End Sub
    Private Sub bindprd()
        dt = clas.getdata("select immclass id, descr Description from tt.immclass_master where immclass in (select mastgrp from tt.closingimmclass) union select 'CMB' id, 'Combined' Description from tt.immclass_master ", "QR")
        bindfromdt(DropDownList5, "", dt, "", "Description", "id", "dropdown", True)
    End Sub

    Private Sub bindcat()
        dt = clas.getdata("select eventid id, descr Description from test.mkstrategymaster where parentid=0  order by descr ", "QR")
        bindfromdt(DropDownList4, "", dt, "", "Description", "id", "dropdown", True)

    End Sub

    Private Sub bindprrty()
        dt = clas.getdata("Select ID, Priority  as Description  from meenu.priority_Detail", "QR")
        bindfromdt(DropDownList6, "", dt, "", "Description", "id", "dropdown", True)
    End Sub
    Private Sub bindscp2()

        Dim qry As String = "Select 'D' ID, 'Department'  as Description  from dual union Select 'E' ID, 'Individual'  as Description from dual union Select 'N' ID, 'Branch/Org Level'  as Description  from dual"
        dt = clas.getdata(qry, "QR")
        bindfromdt(DropDownList2, "", dt, "", "Description", "id", "dropdown", True)
    End Sub
    Private Sub bindsts()

        Dim qry As String = "Select statcd ID, statdescr  as Description,scope  from tt.ipdocstatus  "
        dt = clas.getdata(qry, "QR")
        bindfromdt(DropDownList8, "scope=1009", dt, "", "Description", "id", "dropdown", False)
        bindfromdt(DropDownList10, "scope=1010", dt, "", "Description", "id", "dropdown", True)
        bindfromdt(DropDownList14, "scope=1014", dt, "", "Description", "id", "dropdown", True)
        bindfromdt(DropDownList15, "scope=1015", dt, "", "Description", "id", "dropdown", True)
    End Sub
  

    Protected Sub ddllevl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllevl.SelectedIndexChanged

        bindemptyfromdt(DropDownList5, "dropdown", False)
        bindemptyfromdt(DropDownList4, "dropdown", False)
        If ddllevl.SelectedValue = "B" Then
            dt = clas.getdata("select zbaid as id, zbaname as Description  FROM system.active_branches order by zbaname ASC", "TX")
            bindfromdt(DropDownList1, "", dt, "", "Description", "id", "dropdown", True)
            g1.Enabled = True
            g2.Enabled = False
            g3.Enabled = False
            g4.Enabled = True




        ElseIf ddllevl.SelectedValue = "O" Then
            dt = clas.getdata("select cmpid as id , cmpnm as Description from ranu.companymaster where status='A' order by cmpnm ASC ", "TX")
            bindfromdt(DropDownList1, "", dt, "", "Description", "id", "dropdown", True)
            g1.Enabled = True
            g2.Enabled = False
            g3.Enabled = False
            g4.Enabled = True
        Else
            bindemptyfromdt(DropDownList1, "dropdown", True)
            g1.Enabled = False
            g2.Enabled = False
            g3.Enabled = False
            g4.Enabled = True
        End If

        DropDownList2.ClearSelection()
        bindemptyfromdt(DropDownList3, "dropdown", True)

    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        bindscp2()
        bindemptyfromdt(DropDownList3, "dropdown", True)

        If DropDownList1.SelectedValue <> "" Then

            If ddllevl.SelectedValue = "B" Then
                dt = clas.getdata("select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch || ')' as Description from tt.employees where zbaid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description from tt.employees where zbaid=119 and active='T' and deptcode<>80 and desgid in (select desgid from ranu.desgmaster where desiglevel<10)  order by Description ASC", "TX")
                bindfromdt(DropDownList9, "", dt, "", "Description", "id", "dropdown", True)


                Dim qryemp = "select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch || ')' as Description,1 scp from tt.employees where zbaid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where zbaid=119 and active='T' and deptcode<>80 and empno not in ('1000000') and desgid in (select desgid from ranu.desgmaster where desiglevel<10) union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000'  order by 3,2"



                'select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where zbaid in (119,'" & DropDownList1.SelectedValue & "') and active='T' and deptcode<>80 and empno not in ('1000000') union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000' order by 3,2

                dt = clas.getdata(qryemp, "TX")
                bindfromdt(DropDownList11, "", dt, "", "Description", "id", "dropdown", True)


            ElseIf ddllevl.SelectedValue = "O" Then
                dt = clas.getdata("select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description from tt.employees where compid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description from tt.employees where zbaid=119 and active='T' and deptcode<>80 and desgid in (select desgid from ranu.desgmaster where desiglevel<10)  order by Description ASC", "TX")
                bindfromdt(DropDownList9, "", dt, "", "Description", "id", "dropdown", True)


                Dim qryemp = "select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where compid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where zbaid=119 and active='T' and deptcode<>80  and empno not in ('1000000') and desgid in (select desgid from ranu.desgmaster where desiglevel<10)  union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000'  order by 3,2"

                'select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where compid ='" & DropDownList1.SelectedValue & "' and active='T' and deptcode<>80 and empno not in ('1000000') union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000' order by 3,2"



                dt = clas.getdata(qryemp, "TX")
                bindfromdt(DropDownList11, "", dt, "", "Description", "id", "dropdown", True)

            End If
            g2.Enabled = True
            g3.Enabled = False
            g4.Enabled = True
        Else
            g2.Enabled = False
            g3.Enabled = False
            g4.Enabled = True
        End If





    End Sub


    Protected Function bndact() As DataTable

        If DropDownList1.SelectedValue <> "" Then

            If ddllevl.SelectedValue = "B" Then

                Dim qryemp = "select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch || ')' as Description,1 scp from tt.employees where zbaid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where zbaid=119 and active='T' and deptcode<>80 and empno not in ('1000000') and desgid in (select desgid from ranu.desgmaster where desiglevel<10) union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000'  order by 3,2"
                dt = clas.getdata(qryemp, "TX")
              

            ElseIf ddllevl.SelectedValue = "O" Then

                Dim qryemp = "select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where compid ='" & DropDownList1.SelectedValue & "' and active='T' union  select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department || branch ||')' as Description,1 scp from tt.employees where zbaid=119 and active='T' and deptcode<>80  and empno not in ('1000000') and desgid in (select desgid from ranu.desgmaster where desiglevel<10)  union select empno as id, name ||' ('|| EMPDESIGNATION||'-'|| branch ||')' as Description,0 scp from tt.employees where empno='1000000'  order by 3,2"

                dt = clas.getdata(qryemp, "TX")
          
            End If

        Else

        End If
        Return dt

    End Function





    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged

        bindemptyfromdt(DropDownList4, "dropdown", False)
        bindemptyfromdt(DropDownList5, "dropdown", False)
        If DropDownList1.SelectedValue <> "" Then

            If DropDownList2.SelectedValue = "D" Then

                If ddllevl.SelectedValue = "B" Then

                    dt = clas.getdata("select grpid id, GRPDESCR Description  from tt.deptmast_grp where grpstat='A' and cmpid in (select compid from system.active_branches where zbaid='" & DropDownList1.SelectedValue & "') order by GRPDESCR ASC", "TX")


                    '  dt = clas.getdata("select deptid as id, department as Description  FROM ranu.deptmaster where deptid in (select deptcode from tt.employees where zbaid='" & DropDownList1.SelectedValue & "' and active='T' ) order by department ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)
                ElseIf ddllevl.SelectedValue = "O" Then

                    dt = clas.getdata("select grpid id, GRPDESCR Description  from tt.deptmast_grp where grpstat='A' and cmpid='" & DropDownList1.SelectedValue & "' order by GRPDESCR ASC", "TX")


                    ' dt = clas.getdata("select deptid as id, department as Description  FROM ranu.deptmaster where deptid in (select deptcode from tt.employees where compid='" & DropDownList1.SelectedValue & "' and active='T' ) order by department ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)

                End If
                scpatr.Visible = True
                DropDownList3.Enabled = True
                RequiredFieldValidator8.ValidationGroup = "basicdetails"
                g3.Enabled = True
                g4.Enabled = True
            ElseIf DropDownList2.SelectedValue = "E" Then
                If ddllevl.SelectedValue = "B" Then
                    dt = clas.getdata("select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department ||')' as Description from tt.employees where zbaid='" & DropDownList1.SelectedValue & "' and active='T'  order by name ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)
                ElseIf ddllevl.SelectedValue = "O" Then
                    dt = clas.getdata("select empno as id, name ||' ('|| empno || ' - ' || EMPDESIGNATION|| ' - '|| Department ||')' as Description from tt.employees where compid='" & DropDownList1.SelectedValue & "' and active='T'  order by name ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)


                End If '
                scpatr.Visible = True
                DropDownList3.Enabled = True
                RequiredFieldValidator8.ValidationGroup = "basicdetails"
                g3.Enabled = True
                g4.Enabled = True
            ElseIf DropDownList2.SelectedValue = "N" Then

                If ddllevl.SelectedValue = "B" Then

                    dt = clas.getdata("select grpid id, GRPDESCR Description  from tt.deptmast_grp where grpstat='A' and cmpid in (select compid from system.active_branches where zbaid='" & DropDownList1.SelectedValue & "') order by GRPDESCR ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)
                ElseIf ddllevl.SelectedValue = "O" Then
                    dt = clas.getdata("select grpid id, GRPDESCR Description  from tt.deptmast_grp where grpstat='A' and cmpid='" & DropDownList1.SelectedValue & "' order by GRPDESCR ASC", "TX")
                    bindfromdt(DropDownList3, "", dt, "", "Description", "id", "dropdown", True)

                End If

                scpatr.Visible = True
                DropDownList3.Enabled = True
                RequiredFieldValidator8.ValidationGroup = "basicdetails"
                ' End If

                '     bindemptyfromdt(DropDownList3, "dropdown", True)
                g3.Enabled = True
                g4.Enabled = True

            Else
                g3.Enabled = False
                g4.Enabled = True
                bindemptyfromdt(DropDownList3, "dropdown", True)
            End If

        Else
            g3.Enabled = False
            g4.Enabled = True
            DropDownList2.ClearSelection()
            bindemptyfromdt(DropDownList3, "dropdown", True)
            scpatr.Visible = True
            DropDownList3.Enabled = True
            RequiredFieldValidator8.ValidationGroup = "basicdetails"
        End If



    End Sub


    Protected Sub bindfromdt(ByVal cntl As Control, ByVal filquery As String, ByVal sdt As DataTable, ByVal selval As String, ByVal disptxt As String, ByVal dispval As String, ByVal cntltyp As String, ByVal enbl As Boolean)
        Dim dv As DataView = New DataView()
        dv = sdt.DefaultView
        If filquery.Length > 0 And Not filquery.Trim = "" Then
            dv.RowFilter = filquery
        End If

        If cntltyp = "dropdown" Then
            Dim cnt As DropDownList = TryCast(cntl, DropDownList)
            cnt.ClearSelection()
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()
            cnt.AppendDataBoundItems = True
            Dim itm As ListItem = New ListItem("Select Value", "")
            cnt.Items.Add(itm)
            cnt.DataSource = dv
            cnt.DataTextField = disptxt
            cnt.DataValueField = dispval
            cnt.DataBind()
            If selval.Length > 0 And Not selval.Trim = "" Then
                cnt.Items.FindByValue(selval).Selected = True
            End If
            cnt.Enabled = enbl
            cnt.AppendDataBoundItems = False
        ElseIf cntltyp = "radcombo" Then
            Dim cnt As RadComboBox = TryCast(cntl, RadComboBox)
            cnt.ClearSelection()
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()
            cnt.DataSource = dv
            cnt.DataTextField = disptxt
            cnt.DataValueField = dispval
            cnt.DataBind()
            If selval.Length > 0 And Not selval.Trim = "" Then
                cnt.Items.FindItemByValue(selval).Selected = True
            End If
            cnt.Enabled = enbl
        End If

    End Sub


    Protected Sub bindemptyfromdt(ByVal cntl As Control, ByVal cntltyp As String, ByVal enbl As Boolean)
        Dim dv As DataView = New DataView()
       

        If cntltyp = "dropdown" Then
            Dim cnt As DropDownList = TryCast(cntl, DropDownList)
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()           
            cnt.Enabled = enbl

        ElseIf cntltyp = "radcombo" Then
            Dim cnt As RadComboBox = TryCast(cntl, RadComboBox)
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()
            cnt.DataSource = dv
           
            cnt.Enabled = enbl
        End If

    End Sub


    Protected Sub binddates(ByVal cntl As Control, ByVal seldate As String, ByVal mindate As String, ByVal maxdate As String, ByVal enbl As Boolean)

        Dim cnrl1 As RadDatePicker = TryCast(cntl, RadDatePicker)
        If Not seldate.Trim = "" Then
            cnrl1.SelectedDate = seldate
        Else
            'cnrl1.SelectedDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        If Not mindate.Trim = "" Then
            cnrl1.MinDate = mindate
        Else
            cnrl1.MinDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        If Not maxdate.Trim = "" Then
            cnrl1.MaxDate = maxdate
        Else
            cnrl1.MaxDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        cnrl1.Enabled = enbl
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            bindcurr()
            ' bindprd()
            '  bindcat()
            bindprrty()
            bindsts()
            bindscp2()
            TextBox42.Enabled = False
            agatr.Visible = False
            appdoc.Visible = False
            newadd.Visible = False
            pnlprepone.Visible = False
            Button4.Visible = False
            pnlcnc.Visible = False
            RadDatePicker2.MinDate = Date.Today
            RequiredFieldValidator14.ValidationGroup = "basicdetails"
            RequiredFieldValidator19.ValidationGroup = "basicdetails112"
            RequiredFieldValidator19.ValidationGroup = "basicdetails112"
            If Not Request.QueryString("id") Is Nothing Then
                getdetl(Convert.ToString(Request.QueryString("id")))

            Else

                dt_upload.MinDate = Date.Today

                DropDownList8.SelectedValue = "2064"
                binactgrid(0)
                ' RadTabStrip2.SelectedIndex = 0
                RadTabStrip2.Tabs(1).Enabled = False
                RadTabStrip2.Tabs(2).Enabled = False
                RadTabStrip2.Tabs(3).Enabled = False
                RadTabStrip2.Tabs(4).Enabled = False
                RadDatePicker2.MinDate = Date.Today
            End If


        End If

  

    End Sub




    Protected Sub getdetl(ByVal id As String)

        Dim dt = clas.getdata("select * from tt.evnt_mast where evntid='" & id & "'", "TX")

        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("EVNTSUB")) = False Then
                TextBox2.Text = Convert.ToString(dt.Rows(0)("EVNTSUB"))
                TextBox2.Enabled = False
            End If
            If IsDBNull(dt.Rows(0)("EVNTDESC")) = False Then
                TextBox3.Text = Convert.ToString(dt.Rows(0)("EVNTDESC"))
                TextBox3.Enabled = False
            End If

            If IsDBNull(dt.Rows(0)("EVNTSTDT")) = False Then
                dt_upload.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTSTDT"))
                dt_upload.Enabled = False
            
            End If
            If IsDBNull(dt.Rows(0)("EVNTEDDT")) = False Then
                RadDatePicker1.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTEDDT"))
                RadDatePicker1.Enabled = False
                RadDatePicker5.MinDate = Convert.ToString(dt.Rows(0)("EVNTEDDT"))
            End If

            If IsDBNull(dt.Rows(0)("EVNTSTTIM")) = False Then
                dtpTimeIn.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTSTTIM"))
                dtpTimeIn.Enabled = False
            End If

           
           
            If IsDBNull(dt.Rows(0)("EVNTPRTY")) = False Then

                Try
                    DropDownList6.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTPRTY"))).Selected = True
                    DropDownList6.Enabled = False
                Catch ex As Exception

                End Try


            End If

            If IsDBNull(dt.Rows(0)("EVNTSTS")) = False Then

                Try
                    Dim qry123 As String = "Select statcd ID, statdescr  as Description,scope  from tt.ipdocstatus  where scope=1009 "
                   
                    If Convert.ToString(dt.Rows(0)("EVNTSTS")) = "2065" Or Convert.ToString(dt.Rows(0)("EVNTSTS")) = "2067" Or Convert.ToString(dt.Rows(0)("EVNTSTS")) = "2078" Or Convert.ToString(dt.Rows(0)("EVNTSTS")) = "2079" Or Convert.ToString(dt.Rows(0)("EVNTSTS")) = "2080" Then
                        qry123 &= " and statcd in (2065,2067,2078,2079,2080)"

                    End If
                    Dim dt12 = clas.getdata(qry123, "QR")
                    bindfromdt(DropDownList8, "", dt12, Convert.ToString(dt.Rows(0)("EVNTSTS")), "Description", "id", "dropdown", False)


                    ViewState("EVNTSTS") = Convert.ToString(dt.Rows(0)("EVNTSTS"))
                    RequiredFieldValidator14.ValidationGroup = "basicdetails6"

                    DropDownList8_SelectedIndexChanged(DropDownList8, Nothing)


                    If IsDBNull(dt.Rows(0)("EVNTPREDT")) = False Then
                        RadDatePicker3.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTPREDT"))
                        RadDatePicker3.Enabled = False
                    End If


                    If IsDBNull(dt.Rows(0)("EVNTPRESTTYM")) = False Then
                        RadTimePicker1.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTPRESTTYM"))
                        RadTimePicker1.Enabled = False
                    End If

                    If IsDBNull(dt.Rows(0)("EVNTPREENDDT")) = False Then
                        RadDatePicker4.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTPREENDDT"))
                        RadDatePicker4.Enabled = False
                    End If


                    If IsDBNull(dt.Rows(0)("ENVTDESRSN")) = False Then
                        TextBox6.Text = Convert.ToString(dt.Rows(0)("ENVTDESRSN"))
                        TextBox6.Enabled = False
                    End If


                Catch ex As Exception

                End Try


            End If

            If IsDBNull(dt.Rows(0)("EVNTLVLSCP")) = False Then

                Try
                    ddllevl.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTLVLSCP"))).Selected = True
                    ddllevl_SelectedIndexChanged(ddllevl, Nothing)
                    ddllevl.Enabled = False
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTLVLID")) = False Then

                Try
                    DropDownList1.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTLVLID"))).Selected = True
                    DropDownList1_SelectedIndexChanged(DropDownList1, Nothing)
                    DropDownList1.Enabled = False
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTLVLSCP1")) = False Then

                Try
                    DropDownList2.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTLVLSCP1"))).Selected = True
                    DropDownList2_SelectedIndexChanged(DropDownList2, Nothing)
                    DropDownList2.Enabled = False
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTLVLID1")) = False Then

                Try
                    DropDownList3.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTLVLID1"))).Selected = True
                    DropDownList3.Enabled = False
                    DropDownList3_SelectedIndexChanged(DropDownList3, Nothing)
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTRSPEMP")) = False Then

                Try
                    DropDownList9.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTRSPEMP"))).Selected = True
                    DropDownList9.Enabled = False
                Catch ex As Exception

                End Try


            End If

            If IsDBNull(dt.Rows(0)("EVNTCAT")) = False Then

                Try
                    DropDownList4.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTCAT"))).Selected = True
                    DropDownList4.Enabled = False
                    DropDownList4_SelectedIndexChanged(DropDownList4, Nothing)
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTPRD")) = False Then

                Try
                    DropDownList5.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTPRD"))).Selected = True
                    DropDownList5.Enabled = False
                Catch ex As Exception

                End Try


            End If

            

           



            'If IsDBNull(dt.Rows(0)("EVNTRSPEMP")) = False Then

            '    Try
            '        DropDownList9.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTRSPEMP"))).Selected = True

            '    Catch ex As Exception

            '    End Try


            'End If
            pnleedt.Visible = True
            pnleedt.Enabled = True
            pnlmst.Visible = True




            If IsDBNull(dt.Rows(0)("EVNTRSPEMP")) = False Then

                If Convert.ToString(Request.QueryString("empid")) = Convert.ToString(dt.Rows(0)("EVNTRSPEMP")) Or Convert.ToString(Request.QueryString("empid")) = "159" Then
                    pnlmst.Enabled = True
                    DropDownList8.Enabled = True

                Else
                    pnlmst.Enabled = False
                    DropDownList8.Enabled = False
                End If

            Else
                If Convert.ToString(Request.QueryString("empid")) = "159" Then
                    pnlmst.Enabled = True
                    DropDownList8.Enabled = True
                Else
                    pnlmst.Enabled = False
                    DropDownList8.Enabled = False
                End If

            End If

            pnlcnc.Enabled = False
            pnlprepone.Enabled = False
            Button4.Enabled = False
            If IsDBNull(dt.Rows(0)("EVNTAPPEXST")) = False Then

                Try

                    RadioButtonList1.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTAPPEXST"))).Selected = True

                    If Convert.ToString(dt.Rows(0)("EVNTAPPEXST")) = "E" Then
                        RadioButtonList1.Enabled = False
                        Button2.Visible = False
                        Button3.Enabled = True
                        Button2.Text = "Confirm"
                    Else
                        RadioButtonList1.Enabled = True
                        Button3.Enabled = False
                        pnl.Visible = True
                        Button2.Visible = True
                        Button2.Text = "ReSend Mail"
                    End If

                Catch ex As Exception

                End Try

            Else
                Button3.Enabled = False
            End If
            If IsDBNull(dt.Rows(0)("EVNTAPPTO")) = False Then


                Dim word As String = Convert.ToString(dt.Rows(0)("EVNTAPPTO"))
                Dim wordArr As String() = word.Split("@")
                Try
                    TextBox5.Text = Convert.ToString(wordArr(0))
                    DropDownList12.Items.FindByValue(Convert.ToString(wordArr(1))).Selected = True
                    DropDownList12.Enabled = False
                    TextBox5.Enabled = False
                Catch ex As Exception

                End Try


            End If
            If IsDBNull(dt.Rows(0)("EVNTTYMSTS")) = False Then
                'If Convert.ToString(dt.Rows(0)("EVNTENDTYM")) = "Y" Then
                '    chkb.Checked = True
                'Else
                '    chkb.Checked = False
                'End If

                chkb.Items.FindByValue(Convert.ToString(dt.Rows(0)("EVNTTYMSTS"))).Selected = True
                chkb.Enabled = False
            End If



            ImageButton1.Text = "Update"
            ImageButton1.Visible = False
            newadd.Attributes.Add("href", "VB.aspx?empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid") & "&evntid=" & Convert.ToString(dt.Rows(0)("EVNTID")))
            newadd.Visible = True
            nwdoc.Attributes.Add("href", "uploaddoc.aspx?evntid=" & Convert.ToString(dt.Rows(0)("EVNTID")) & "&empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid"))

            ViewState("id") = Convert.ToString(dt.Rows(0)("EVNTID"))
            RequiredFieldValidator23.ValidationGroup = "basicdetails3"
            binactgrid(Convert.ToString(dt.Rows(0)("EVNTID")))
            bindocgrid(Convert.ToString(dt.Rows(0)("EVNTID")))



            Dim dtdocapr = clas.getdata(" select * from (select  * from tt.evnt_doclib where docid=1 and docstatus='A' and evntid='" & Convert.ToString(dt.Rows(0)("EVNTID")) & "' order by docdt asc) where rownum=1", "TX")

            If dtdocapr.Rows.Count > 0 Then

                If IsDBNull(dtdocapr.Rows(0)("DOCPTH")) = False Then

                    docview.InnerHtml = "Attached Approval Document: <span style='color:green';>" & Convert.ToString(dtdocapr.Rows(0)("DOCPTH")) & "</span> on " & Convert.ToDateTime(dtdocapr.Rows(0)("DOCDT")).ToString("dd-MMM-yyyy HH:mm:ss")

                Else

                End If
                Button3.Enabled = False
                fupl.Enabled = False





                RadTabStrip2.Tabs(1).Enabled = True
                RadTabStrip2.SelectedIndex = 1
                RadMultiPage2.SelectedIndex = 1

                If IsDBNull(dt.Rows(0)("EVNTEDDT")) = False Then
                    'RadDatePicker1.SelectedDate = Convert.ToString(dt.Rows(0)("EVNTEDDT"))
                    'RadDatePicker1.Enabled = False

                    Dim fnldat As DateTime = RadDatePicker1.SelectedDate

                    Dim leftday = fnldat.Subtract(Date.Today).Days

                    If leftday >= 0 Then
                        RadDatePicker2.MaxDate = RadDatePicker1.SelectedDate
                    Else
                        addact.Visible = False
                    End If


                End If

            Else
                docview.InnerHtml = ""
                RadTabStrip2.Tabs(1).Enabled = False
                RadTabStrip2.SelectedIndex = 0
                RadMultiPage2.SelectedIndex = 0
            End If


            RadTabStrip2.Tabs(3).Enabled = False
            RadTabStrip2.Tabs(4).Enabled = True



            If IsDBNull(dt.Rows(0)("EVNTRSPEMP")) = False Then

                If Convert.ToString(Request.QueryString("empid")) = Convert.ToString(dt.Rows(0)("EVNTRSPEMP")) Or Convert.ToString(Request.QueryString("empid")) = "159" Then


                    If Convert.ToString(ViewState("EVNTSTS")) = "2067" Or Convert.ToString(ViewState("EVNTSTS")) = "2068" Then

                        RadTabStrip2.Tabs(2).Enabled = False
                    ElseIf Convert.ToString(ViewState("EVNTSTS")) = "2065" Then
                        RadTabStrip2.Tabs(2).Enabled = True
                    Else
                        RadTabStrip2.Tabs(2).Enabled = False
                    End If

                    ' fb.Enabled = True
                Else
                    RadTabStrip2.Tabs(2).Enabled = False
                End If
            Else
                RadTabStrip2.Tabs(2).Enabled = False

            End If


            Dim txtbrsd = ddllevl.SelectedItem.Text & "  ( " & DropDownList1.SelectedItem.Text & " ) --> " & DropDownList2.SelectedItem.Text & " (" & DropDownList3.SelectedItem.Text & ") -->  " & DropDownList4.SelectedItem.Text & " (  " & DropDownList5.SelectedItem.Text & " ) (" & CDate(dt_upload.SelectedDate).ToString("dd-MMM-yyyy") & " - " & CDate(RadDatePicker1.SelectedDate).ToString("dd-MMM-yyyy") & ")"

            crdcrn.InnerHtml = txtbrsd

            Dim dt1 = clas.getdata("select * from  TT.EVNT_FDBCK where evntid='" & id & "'", "TX")

            If dt1.Rows.Count > 0 Then

                If IsDBNull(dt1.Rows(0)("RMKS")) = False Then
                    TextBox8.Text = Convert.ToString(dt1.Rows(0)("RMKS"))
                    TextBox8.Enabled = False
                End If
                If IsDBNull(dt1.Rows(0)("FBLVL")) = False Then

                    DropDownList14.Items.FindByValue(dt1.Rows(0)("FBLVL")).Selected = True
                    DropDownList14.Enabled = False
                End If

                If IsDBNull(dt1.Rows(0)("FBRCLVL")) = False Then
                    DropDownList15.Items.FindByValue(dt1.Rows(0)("FBRCLVL")).Selected = True
                    DropDownList15_SelectedIndexChanged(DropDownList15, Nothing)
                    DropDownList15.Enabled = False
                End If

                If IsDBNull(dt1.Rows(0)("FBRCDAT")) = False Then
                    RadDatePicker5.SelectedDate = dt1.Rows(0)("FBRCDAT")
                    RadDatePicker5.Enabled = False
                End If

                Button5.Visible = False
            Else
                Button5.Visible = True

            End If











        Else
            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>There is no such record</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

            RadTabStrip2.SelectedIndex = 0
            RadMultiPage2.SelectedIndex = 0
            RadTabStrip2.Tabs(1).Enabled = False
            RadTabStrip2.Tabs(2).Enabled = False
            RadTabStrip2.Tabs(3).Enabled = False
            Exit Sub


        End If





    End Sub


    Protected Sub binactgrid(ByVal evid As String)
        Dim qry = "select * from TT.evnt_act_vw where EVNTID='" & evid & "' "
        '  Response.Write(qry)

        If DropDownList13.SelectedValue = "M" Then
            qry &= " and actasgnto='" & Convert.ToString(Request.QueryString("empid")) & "'"

        End If
        qry &= " order by actdt desc"


        Dim dt1 = clas.getdata(qry, "TX")

        RadGrid2.DataSource = dt1
        RadGrid2.DataBind()
    End Sub



    Protected Sub bindocgrid(ByVal evid As String)
        Dim qry = "select * from TT.evnt_doc_vw where EVNTID='" & evid & "' "
        '  Response.Write(qry)

        'If DropDownList13.SelectedValue = "M" Then
        '    qry &= " and actasgnto='" & Convert.ToString(Request.QueryString("empid")) & "'"

        'End If
        ' qry &= " order by actdt desc"


        Dim dt1 = clas.getdata(qry, "TX")

        RadGrid1.DataSource = dt1
        RadGrid1.DataBind()
    End Sub



    Protected Sub RadGrid2_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand

        If e.CommandName = "Filter" Then

            binactgrid(Convert.ToString(ViewState("id")))

        ElseIf e.CommandName = "ChangePageSize" Then

            binactgrid(Convert.ToString(ViewState("id")))


        ElseIf e.CommandName = "edit" Then


            binactgrid(Convert.ToString(ViewState("id")))

         ElseIf e.CommandName = "update" Then
            Dim griditem As GridItem = RadGrid2.MasterTableView.GetItems(GridItemType.EditFormItem)(e.Item.ItemIndex)
            Dim newValues As Hashtable = New Hashtable

            Dim asgnto = CType(griditem.FindControl("searchproduct"), RadComboBox).SelectedItem.Value
            Dim evntid = CType(griditem.FindControl("hfevnt"), HiddenField).Value
            Dim trid = CType(griditem.FindControl("fhtrns"), HiddenField).Value


            Dim qry = "update tt.EVNT_ACT Set ACTASGNTO='" & asgnto & "',LASTUPDON=sysdate, LASTUPDBY='" & Convert.ToString(Request.QueryString("empid")) & "', LASTUPDIP='" & HttpContext.Current.Request.UserHostAddress & "', LASTUPDBRWS='" & Request.Browser.Browser & "' where EVNTID='" & evntid & "' and TRANSID='" & trid & "'"

            Dim i = clas.ExecuteNonQuery(qry)

            If i = 1 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>Activity Re-Assigned Successfully</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                binactgrid(Convert.ToString(ViewState("id")))
                '    binactgrid(Convert.ToString(ViewState("id")))
                ' Exit Sub


            Else

                Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "").Replace("""", "").Replace("'", "")
                Err_Msg = Err_Msg.Replace(vbCr, "")
                Err_Msg = Err_Msg.Replace(vbLf, "")

                If Err_Msg.Trim().Length > 0 Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                Else
                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                End If

                Exit Sub

            End If


        ElseIf e.CommandName = "cancel" Then

            RadGrid2.EditIndexes.Add(-1)
            binactgrid(Convert.ToString(ViewState("id")))

        ElseIf e.CommandName = "dwnldresume" Then

            Dim filename As String = e.CommandArgument.ToString()
            'Dim FilePath As String = "D:\18-jul-18\CBIS\libdocs\" & filename
            Dim FilePath As String = Server.MapPath("eventdoc") & "\" & filename
            fileDownload(filename, FilePath)
        End If

    End Sub



    Protected Sub RadGrid2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid2.ItemDataBound



        RadGrid2.MasterTableView.GetColumn("transid").Visible = False
        RadGrid2.MasterTableView.GetColumn("evntid").Visible = False
        RadGrid2.MasterTableView.GetColumn("CURRCODE").Visible = False
        RadGrid2.MasterTableView.GetColumn("AMOUNT").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTSTS").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTCMNTS").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTALRTS").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTEMAIL").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTDT").Visible = False
        RadGrid2.MasterTableView.GetColumn("KEYEDON").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTASGNTO").Visible = False
        RadGrid2.MasterTableView.GetColumn("ACTTYP").Visible = False
        RadGrid2.MasterTableView.GetColumn("AsignedTo").Visible = False
        RadGrid2.MasterTableView.GetColumn("appdoc").Visible = False

        RadGrid2.MasterTableView.GetColumn("APPFILESTS").Visible = False



        ' RadGrid1.MasterTableView.GetColumn("RID").Visible = False

        ''RadGrid1.MasterTableView.GetColumn("status").Visible = False


        If (TypeOf e.Item Is GridDataItem) Then


            Dim item As GridDataItem = e.Item
            '    '   Dim btnedit As ImageButton = DirectCast(item.FindControl("btnedit"), ImageButton)
            Dim btnget As ImageButton = DirectCast(item.FindControl("dwnldlnk"), ImageButton)
            Dim btnCand As HtmlAnchor = DirectCast(item.FindControl("act"), HtmlAnchor)
            Dim upl As HtmlAnchor = DirectCast(item.FindControl("upld"), HtmlAnchor)
            ' Dim btnico As ImageButton = DirectCast(item.FindControl("btnico"), ImageButton)
            Dim lbl As HtmlImage = CType(e.Item.FindControl("lblremLaw"), HtmlImage)
            Dim tooltipmanager As RadToolTipManager = CType(e.Item.FindControl("RadToolTipManager5"), RadToolTipManager)
            tooltipmanager.TargetControls.Add(lbl.ClientID, True)

            btnCand.Attributes.Add("style", "text-deoration:underline;")
            btnCand.Attributes.Add("class", "fancybox")

            upl.Attributes.Add("style", "text-deoration:underline;")
            upl.Attributes.Add("class", "pop4")

            If item.GetDataKeyValue("ACTSTS").ToString() = "2076" Then
                btnCand.Attributes.Add("href", "evntrmks.aspx?id=" & Convert.ToString(item.GetDataKeyValue("transid")) & "&evntid=" & Convert.ToString(item.GetDataKeyValue("evntid")) & "&empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid") & "&sts=N")
            Else
                btnCand.Attributes.Add("href", "evntrmks.aspx?id=" & Convert.ToString(item.GetDataKeyValue("transid")) & "&evntid=" & Convert.ToString(item.GetDataKeyValue("evntid")) & "&empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid"))
            End If

            upl.Attributes.Add("href", "uploaddoc.aspx?actid=" & Convert.ToString(item.GetDataKeyValue("transid")) & "&evntid=" & Convert.ToString(item.GetDataKeyValue("evntid")) & "&empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid"))


		Dim btnico As ImageButton = DirectCast(item.FindControl("btnico"), ImageButton)



            If item.GetDataKeyValue("ACTSTS").ToString = "2076" Then
                btnico.ImageUrl = "images\bullet_green.png"
            ElseIf item.GetDataKeyValue("ACTSTS").ToString = "2075" Then
                btnico.ImageUrl = "images\bullet_blue.png"
            Else
                btnico.ImageUrl = "images\bullet_black.png"

            End If


            If item.GetDataKeyValue("APPFILESTS").ToString = "N" Then
                btnget.Enabled = False
                btnget.Visible = True

            Else

                Dim fldco = Convert.ToString(item.GetDataKeyValue("appdoc")).Replace("&nbsp;", "")

                If fldco.Trim().Length > 0 Then

                    If System.IO.File.Exists(Server.MapPath("eventdoc") & "/" & fldco) Then
                        btnget.Enabled = True
                        btnget.Visible = True
                    Else
                        btnget.Enabled = False
                        btnget.Visible = True

                    End If



                End If

            End If




            If item.GetDataKeyValue("ACTSTS").ToString() = "2076" Then
                ' btnCand.Attributes.Add("style", "display:none;")
                '    '        btnico.ImageUrl = "libdocs\bullet_green.png"
                '    ElseIf item.GetDataKeyValue("masterstatus").ToString.ToUpper = "U" Then
                '    '        btnico.ImageUrl = "libdocs\bullet_black.png"
                '  ElseIf item.GetDataKeyValue("masterstatus").ToString.ToUpper = "R" Or item.GetDataKeyValue("masterstatus").ToString.ToUpper = "X" Then
                '    '        btnico.ImageUrl = "libdocs\bullet_Red.png"


                '    '        btnget.Attributes.Add("style", "display:inline")
                '    '        btnCand.Attributes.Add("style", "display:none")
                '    '    '    btnget.Attributes.Add("href", "mycase_upload.aspx?id=" & item.GetDataKeyValue("cid").ToString() & "&mode=revoke" & "&fsn=" & item.GetDataKeyValue("FSN") & "&empid=" & ddl_Employer.SelectedValue)
                '    '        ' btnget.Attributes.Add("Title", "Revoke Case")

                '    '    Else
                '    '        btnico.ImageUrl = "libdocs\bullet_blue.png"
            End If

        ElseIf (TypeOf e.Item Is GridEditFormItem And e.Item.IsInEditMode) Then

            Dim editFormItem As GridEditFormItem = TryCast(e.Item, GridEditFormItem)
            Dim txtCompleteBy As RadComboBox = TryCast(editFormItem.FindControl("searchproduct"), RadComboBox)
            txtCompleteBy.DataTextField = "Description"
            txtCompleteBy.DataValueField = "id"
            txtCompleteBy.DataSource = bndact()
            txtCompleteBy.DataBind()

            Try
                txtCompleteBy.Items.FindItemByValue(editFormItem.GetDataKeyValue("ACTASGNTO")).Selected = True
            Catch ex As Exception

            End Try


        End If
    End Sub


    Protected Sub RadGrid2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid2.PreRender
        If Page.IsPostBack = False Then



            Dim column As GridColumn = TryCast(RadGrid2.MasterTableView.GetColumnSafe("icon2"), GridColumn)
            column.OrderIndex = RadGrid2.MasterTableView.RenderColumns.Length
            Dim column1 As GridColumn = TryCast(RadGrid2.MasterTableView.GetColumnSafe("remLaw"), GridColumn)
            column1.OrderIndex = RadGrid2.MasterTableView.RenderColumns.Length - 1
            Dim column2 As GridColumn = TryCast(RadGrid2.MasterTableView.GetColumnSafe("acto"), GridColumn)
            column2.OrderIndex = RadGrid2.MasterTableView.RenderColumns.Length - 3


            RadGrid2.MasterTableView.Rebind()
        End If
    End Sub
    Private Sub RadGrid2_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid2.PageIndexChanged

        RadGrid2.CurrentPageIndex = e.NewPageIndex

        binactgrid(Convert.ToString(ViewState("id")))
    End Sub

    Protected Sub RadGrid2_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid2.SortCommand
        binactgrid(Convert.ToString(ViewState("id")))
    End Sub

    Protected Sub RadGrid2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid2.SelectedIndexChanged
        '  Dim _item As GridDataItem = TryCast(RadGrid2.SelectedItems(0), GridDataItem)
        ' vcnrmks.InnerText = Convert.ToString(_item("REMARKS").Text)
    End Sub










    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

        If e.CommandName = "Filter" Then

            bindocgrid(Convert.ToString(ViewState("id")))

        ElseIf e.CommandName = "ChangePageSize" Then

            bindocgrid(Convert.ToString(ViewState("id")))


        ElseIf e.CommandName = "dwnldresume" Then
            Dim filename As String = e.CommandArgument.ToString()
            'Dim FilePath As String = "D:\18-jul-18\CBIS\libdocs\" & filename
            Dim FilePath As String = Server.MapPath("eventdoc") & "\" & filename
            fileDownload(filename, FilePath)
        End If

    End Sub



    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound



        RadGrid1.MasterTableView.GetColumn("transid").Visible = False
        RadGrid1.MasterTableView.GetColumn("evntid").Visible = False
        RadGrid1.MasterTableView.GetColumn("ACTID").Visible = False
        RadGrid1.MasterTableView.GetColumn("FBID").Visible = False
        RadGrid1.MasterTableView.GetColumn("OCID").Visible = False
        RadGrid1.MasterTableView.GetColumn("DOCRMKS").Visible = False
        RadGrid1.MasterTableView.GetColumn("DOCSTATUS").Visible = False
        RadGrid1.MasterTableView.GetColumn("DOCPTH").Visible = False
        RadGrid1.MasterTableView.GetColumn("DOCID").Visible = False
        RadGrid1.MasterTableView.GetColumn("RMKSID").Visible = False
        RadGrid1.MasterTableView.GetColumn("DOCSUB").Visible = False

        RadGrid1.MasterTableView.GetColumn("category").HeaderText = "Category"
        RadGrid1.MasterTableView.GetColumn("STATUS").HeaderText = "Status"

        If (TypeOf e.Item Is GridDataItem) Then


            Dim item As GridDataItem = e.Item
            Dim btnget As ImageButton = DirectCast(item.FindControl("dwnldlnk"), ImageButton)

            ' Dim btnico As ImageButton = DirectCast(item.FindControl("btnico"), ImageButton)
            Dim lbl As HtmlImage = CType(e.Item.FindControl("lblremLaw"), HtmlImage)
            Dim tooltipmanager As RadToolTipManager = CType(e.Item.FindControl("RadToolTipManager5"), RadToolTipManager)
            tooltipmanager.TargetControls.Add(lbl.ClientID, True)



            Dim btnico As ImageButton = DirectCast(item.FindControl("btnico"), ImageButton)



            If item.GetDataKeyValue("DOCSTATUS").ToString = "A" Then
                btnico.ImageUrl = "images\bullet_green.png"
            Else
                btnico.ImageUrl = "images\bullet_black.png"

            End If


        


            Dim fldco = Convert.ToString(item.GetDataKeyValue("DOCPTH")).Replace("&nbsp;", "")

                If fldco.Trim().Length > 0 Then

                    If System.IO.File.Exists(Server.MapPath("eventdoc") & "/" & fldco) Then

                        btnget.Visible = True
                    Else

                        btnget.Visible = False

                    End If



                End If


            End If
    End Sub


    Protected Sub RadGrid1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.PreRender
        If Page.IsPostBack = False Then
           
            Dim column1 As GridColumn = TryCast(RadGrid1.MasterTableView.GetColumnSafe("remLaw"), GridColumn)
            column1.OrderIndex = RadGrid1.MasterTableView.RenderColumns.Length - 1
            RadGrid1.MasterTableView.Rebind()
        End If
    End Sub
    Private Sub RadGrid1_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged

        RadGrid1.CurrentPageIndex = e.NewPageIndex

        bindocgrid(Convert.ToString(ViewState("id")))
    End Sub

    Protected Sub RadGrid1_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        bindocgrid(Convert.ToString(ViewState("id")))
    End Sub

    Protected Sub RadGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.SelectedIndexChanged
        '  Dim _item As GridDataItem = TryCast(RadGrid2.SelectedItems(0), GridDataItem)
        ' vcnrmks.InnerText = Convert.ToString(_item("REMARKS").Text)
    End Sub


    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        bindocgrid(Convert.ToString(ViewState("id")))
    End Sub





    Protected Sub addact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addact.Click

        adnew.Visible = True

    End Sub

    'Protected Sub chkbox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbox.CheckedChanged

    '    If chkbox.Checked = True Then
    '        RequiredFieldValidator22.ValidationGroup = "basicdetails1"

    '    Else
    '        RequiredFieldValidator22.ValidationGroup = "basicdetails2"
    '    End If


    'End Sub



    Protected Sub clr()

        DropDownList10.ClearSelection()
        DropDownList10.DataBind()


        DropDownList7.ClearSelection()
        DropDownList7.DataBind()



        TextBox1.Text = String.Empty
        'TextBox5.Text = String.Empty
        TextBox4.Text = String.Empty
        DropDownList11.ClearSelection()
        DropDownList11.DataBind()
        TextBox42.Text = String.Empty
      

        RadDatePicker2.SelectedDate = Nothing

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        binactgrid(Convert.ToString(ViewState("id")))
    End Sub

    Protected Sub dt_upload_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles dt_upload.SelectedDateChanged

        RadDatePicker1.MinDate = dt_upload.SelectedDate
        RadDatePicker1.SelectedDate = dt_upload.SelectedDate   
        g4.Enabled = True
        DropDownList8.Enabled = False

    End Sub


    Protected Sub RadDatePicker3_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePicker3.SelectedDateChanged

        RadDatePicker4.MinDate = RadDatePicker3.SelectedDate
        RadDatePicker4.SelectedDate = RadDatePicker3.SelectedDate
      

    End Sub


    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        If RadioButtonList1.SelectedValue = "E" Then
            RequiredFieldValidator22.ValidationGroup = "basicdetails31"
            RequiredFieldValidator24.ValidationGroup = "basicdetails31"
            pnl.Visible = False
            Button2.Text = "Confirm"

        Else
            pnl.Visible = True
            RequiredFieldValidator22.ValidationGroup = "basicdetails3"
            RequiredFieldValidator24.ValidationGroup = "basicdetails3"
            Button2.Text = "Send Mail"
        End If

    End Sub

    Protected Sub DropDownList11_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList11.SelectedIndexChanged

        If DropDownList11.SelectedValue = "1000000" Then
            TextBox42.Text = String.Empty
            TextBox42.Enabled = True
            agatr.Visible = True
            appdoc.Visible = True
            RequiredFieldValidator29.ValidationGroup = "basicdetails1"
            RequiredFieldValidator19.ValidationGroup = "basicdetails1"
        Else
            TextBox42.Text = String.Empty
            TextBox42.Enabled = False
            agatr.Visible = True
            appdoc.Visible = False
            RequiredFieldValidator19.ValidationGroup = "basicdetails112"
            RequiredFieldValidator29.ValidationGroup = "basicdetails112"
        End If



    End Sub
    Protected Sub DropDownList8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList8.SelectedIndexChanged
        RadDatePicker3.SelectedDate = Nothing
        TextBox6.Text = String.Empty
        RadDatePicker4.SelectedDate = Nothing
        RadTimePicker1.SelectedDate = Nothing
        If DropDownList8.SelectedValue = "2066" Or DropDownList8.SelectedValue = "2067" Or DropDownList8.SelectedValue = "2080" Then
            pnlprepone.Enabled = False
            pnlprepone.Visible = False
            pnlcnc.Enabled = True
            RequiredFieldValidator27.ValidationGroup = "abc"
            RequiredFieldValidator30.ValidationGroup = "abc"
            RequiredFieldValidator31.ValidationGroup = "abc"
            RequiredFieldValidator28.ValidationGroup = "basicdetails6"
            pnlcnc.Visible = True
            Button4.Enabled = True
            Button4.Visible = True



        ElseIf DropDownList8.SelectedValue = "2078" Or DropDownList8.SelectedValue = "2079" Then
            pnlprepone.Visible = True
            pnlprepone.Enabled = True
            pnlcnc.Enabled = True
            pnlcnc.Visible = True
            RequiredFieldValidator28.ValidationGroup = "basicdetails6"
            RequiredFieldValidator27.ValidationGroup = "basicdetails6"
            RequiredFieldValidator30.ValidationGroup = "basicdetails6"
            RequiredFieldValidator31.ValidationGroup = "basicdetails6"
            Button4.Enabled = True
            Button4.Visible = True
            If DropDownList8.SelectedValue = "2078" Then
                RadDatePicker3.MinDate = DateTime.Today
                RadDatePicker3.MaxDate = dt_upload.SelectedDate
                RadDatePicker4.MinDate = DateTime.Today
                RadDatePicker4.MaxDate = dt_upload.SelectedDate

            Else
                RadDatePicker3.MinDate = dt_upload.SelectedDate
                RadDatePicker3.MaxDate = DateTime.Today.AddMonths(6)
                RadDatePicker4.MinDate = DateTime.Today
                RadDatePicker4.MaxDate = DateTime.Today.AddMonths(6)
            End If

        Else
            Button4.Enabled = False
            pnlprepone.Enabled = False
            pnlprepone.Visible = False
            Button4.Visible = False
            pnlcnc.Visible = False
            pnlcnc.Enabled = False
        End If



    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        binactgrid(Convert.ToString(ViewState("id")))
    End Sub

#Region "File Download"
    Private Sub fileDownload(ByVal fileName As String, ByVal fileUrl As String)
        Page.Response.Clear()
        Dim success As Boolean = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000)
        If Not success Then
            Page.Response.[End]()
            RadWindowManager1.RadAlert("<div style=color:Red;> System unable to download Reciept </div>", 320, 150, "Information", Nothing)


        End If
        Page.Response.[End]()

    End Sub
    Public Shared Function ResponseFile(ByVal _Request As HttpRequest, ByVal _Response As HttpResponse, ByVal _fileName As String, ByVal _fullPath As String, ByVal _speed As Long) As Boolean
        Try
            Dim myFile As New FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim br As New BinaryReader(myFile)
            Try
                _Response.AddHeader("Accept-Ranges", "bytes")
                _Response.Buffer = False
                Dim fileLength As Long = myFile.Length
                Dim startBytes As Long = 0

                Dim pack As Integer = 10240
                '10K bytes
                Dim sleep As Integer = CInt(Math.Floor(CDbl(1000 * pack \ _speed))) + 1
                If _Request.Headers("Range") IsNot Nothing Then
                    _Response.StatusCode = 206
                    Dim range As String() = _Request.Headers("Range").Split(New Char() {"="c, "-"c})
                    startBytes = Convert.ToInt64(range(1))
                End If
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString())
                If startBytes <> 0 Then
                    _Response.AddHeader("Content-Range", String.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength))
                End If
                _Response.AddHeader("Connection", "Keep-Alive")
                _Response.ContentType = "application/octet-stream"
                _Response.AddHeader("Content-Disposition", "attachment;filename=" & HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8))

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin)
                Dim maxCount As Integer = CInt(Math.Floor(CDbl((fileLength - startBytes) \ pack))) + 1

                For i As Integer = 0 To maxCount - 1
                    If _Response.IsClientConnected Then
                        _Response.BinaryWrite(br.ReadBytes(pack))
                        Thread.Sleep(sleep)
                    Else
                        i = maxCount
                    End If
                Next
            Catch ex As Exception
                '   ex.Message.ToString()
                Return False
            Finally
                br.Close()
                myFile.Close()
            End Try
        Catch ex As Exception
            '  ex.Message.ToString()
            Return False
        End Try
        Return True
    End Function
#End Region


    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged



        bindemptyfromdt(DropDownList4, "dropdown", False)
        bindemptyfromdt(DropDownList5, "dropdown", False)
        If DropDownList3.SelectedValue <> "" Then

            If DropDownList2.SelectedValue = "D" Or DropDownList2.SelectedValue = "N" Then

                dt = clas.getdata("select actid id, actdescr Description from tt.event_activity where actstats='A' and deptgrpid ='" & DropDownList3.SelectedValue & "' and parentid is null order by actdescr  ", "QR")
                bindfromdt(DropDownList4, "", dt, "", "Description", "id", "dropdown", True)


            ElseIf DropDownList2.SelectedValue = "E" Then

                dt = clas.getdata("select actid id, actdescr Description from tt.event_activity where actstats='A' and deptgrpid in (select depevntgrp from ranu.deptmaster where deptid in (select deptcode from tt.employees where empno ='" & DropDownList3.SelectedValue & "')) and parentid is null order by actdescr", "QR")
                bindfromdt(DropDownList4, "", dt, "", "Description", "id", "dropdown", True)


                'ElseIf DropDownList2.SelectedValue = "N" Then

                '    If ddllevl.SelectedValue = "B" Then


                '        dt = clas.getdata("select actid id, actdescr Description from tt.event_activity where actstats='A' and deptgrpid in (select grpid from tt.deptmast_grp where grpstat='A' and cmpid in (select compid from system.active_branches where zbaid='" & DropDownList1.SelectedValue & "')) order by actdescr", "QR")
                '        bindfromdt(DropDownList4, "", dt, "", "Description", "id", "dropdown", True)
                '    ElseIf ddllevl.SelectedValue = "O" Then


                '        dt = clas.getdata("select actid id, actdescr Description from tt.event_activity where actstats='A' and deptgrpid in (select grpid  from tt.deptmast_grp where grpstat='A' and cmpid='" & DropDownList1.SelectedValue & "') order by actdescr", "QR")
                '        bindfromdt(DropDownList4, "", dt, "", "Description", "id", "dropdown", True)

                '    End If





            End If

        Else


        End If

       


    End Sub

    Protected Sub DropDownList4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList4.SelectedIndexChanged

        bindemptyfromdt(DropDownList5, "dropdown", False)

        If DropDownList4.SelectedValue <> "" Then
            dt = clas.getdata("select actid id, actdescr Description from tt.event_activity where actstats='A' and parentid ='" & DropDownList4.SelectedValue & "' order by actdescr  ", "QR")
            bindfromdt(DropDownList5, "", dt, "", "Description", "id", "dropdown", True)

        End If

    End Sub

    'Protected Sub chkb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkb.CheckedChanged

    '    If chkb.Checked = True Then
    '        Dim span As TimeSpan = New TimeSpan(0, 9, 0, 0, 0)
    '        dtpTimeIn.SelectedTime = span

    '        dtpTimeIn.Enabled = False
    '    Else

    '        dtpTimeIn.Enabled = True
    '    End If

    'End Sub
    Protected Sub chkb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkb.SelectedIndexChanged

        If Not chkb.SelectedValue Is Nothing Then

            If chkb.SelectedValue = "0" Then

                Dim span As TimeSpan = New TimeSpan(0, 9, 0, 0, 0)
                dtpTimeIn.SelectedTime = span

                dtpTimeIn.Enabled = False

            Else
                If Not dtpTimeIn.SelectedTime Is Nothing Then
                    dtpTimeIn.Enabled = True
                Else
                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>Please Select Start Time</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                    Exit Sub

                End If


            End If


        End If


      

    End Sub


    Protected Sub refe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles refe.Click

        DropDownList3_SelectedIndexChanged(DropDownList3, Nothing)
        '    DropDownList4_SelectedIndexChanged(DropDownList4, Nothing)
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox8.Text.Trim().Length > 0 Then
            TextBox8.Text = TextBox8.Text.Replace("""", "").Replace("'", "").Replace("+", "").Replace("%", "")
        End If



        Dim str As StringBuilder = New StringBuilder()



        Dim Timefrom = ""

        If Not RadDatePicker5.SelectedDate Is Nothing Then
            Timefrom = "TO_DATE('" & RadDatePicker5.SelectedDate.Value.ToString("dd-MMM-yyyy") & "','dd-MON-yyyy')"
        End If


        str.Append("insert into tt.EVNT_FDBCK (FBID,EVNTID, RMKS, FBLVL, FBRCLVL, FBRCDAT, KEYEDON, KEYEDBY, KEYEDIP, KEYEDBRWS) values ")
        str.Append(" (TT.EVNT_FDBK_SEQ.nextval,'" & ViewState("id") & "','" & TextBox8.Text & "','" & DropDownList14.SelectedValue & "','" & DropDownList15.SelectedValue & "'," & If(Timefrom Is Nothing, "null", Timefrom) & ",")

        str.Append("sysdate,'" & Convert.ToString(Request.QueryString("empid")) & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "')")

        Dim i = clas.ExecuteNonQuery(str.ToString)

		
		'Response.Write(str)
		
        If i = 1 Then

		     getdetl(ViewState("id"))
		
            RadWindowManager1.RadAlert("<ul><li><div style=color:green;>Feedback Submitted successfully</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)


        Else
            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "").Replace("""", "").Replace("'", "")
            Err_Msg = Err_Msg.Replace(vbCr, "")
            Err_Msg = Err_Msg.Replace(vbLf, "")

            If Err_Msg.Trim().Length > 0 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            Else
                RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
            End If

            Exit Sub

        End If





    End Sub


    Protected Sub DropDownList15_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList15.SelectedIndexChanged

        If DropDownList15.SelectedValue = "0" Then
            RequiredFieldValidator35.ValidationGroup = "basicdetails5555"
            recdat.Visible = False
            RadDatePicker5.Enabled = False
        Else
            RequiredFieldValidator35.ValidationGroup = "basicdetails55"
            recdat.Visible = True
            RadDatePicker5.Enabled = True
        End If



    End Sub
End Class
