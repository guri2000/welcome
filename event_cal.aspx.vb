Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Imports System.Data
Partial Class RadSchedulerAdvancedForm
    Inherits System.Web.UI.Page
    Dim clas As rahulcpm.commonclass = New rahulcpm.commonclass()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim manager As ScriptManager = RadScriptManager.GetCurrent(Page)
        manager.Scripts.Add(New ScriptReference(ResolveUrl("AdvancedForm.js")))
        ' RadScheduler1.Provider = New XmlSchedulerProvider(Server.MapPath("~/App_Data/Appointments_CustomTemplates.xml"), True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' bindresource()
        If Page.IsPostBack = False Then
            bindschedule()
            ' RadCalendar1.FocusedDate = Date.Today

            newadd.Attributes.Add("href", "addevent.aspx?empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid"))
            
            refill()
        End If

        HFSession.Value = Request.QueryString("empid")
            HFIP.Value = Request.ServerVariables("REMOTE_ADDR").ToString

        myNotLink.Attributes.Add("href", "notification_Details.aspx?empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid"))

        ' RadScheduler1.DataSource = clas.getdata("select * from  tt.evnt_mast", "qr")
        ' RadScheduler1.DataSource = clas.getdata("SELECT t1.EVNTID,t1.EVNTSUB,t1.EVNTDESC, t1.EVNTSTDT,t1.EVNTEDDT,t1.EVNTVENU,t1.EVNTSCP,t1.EVNTCAT,t1.EVNTAPPBY,t1.EVNTSTS,t1.EVNTPRTY,t1.EVNTLVLSCP,t1.EVNTLVLID,t1.EVNTRSPEMP,t2.amount as Budget,t2.currcode Curr,t3.empno FROM TT.EVNT_MAST t1  left outer join tt.evnt_budgt t2 on t2.evntid=t1.evntid  left outer join tt.evnt_asgn t3 on t3.evntid=t1.evntid", "qr")



        'select * from  tt.evnt_mast where evntsts<>607
    End Sub

    Protected Sub RadScheduler1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        ' RadScheduler1.ResourceTypes.FindByName("User").AllowMultipleValues = True
        ' RadScheduler1.ResourceTypes.FindByName("Room").AllowMultipleValues = False
        'bindschedule()

        'Dim rt As ResourceType = New ResourceType("User")
        'rt.DataSource = clas.getdata("select empno,name from tt.employee", "qr")
        'rt.KeyField = "empno"
        'rt.TextField = "name"
        'rt.ForeignKeyField = "empno"
        'RadScheduler1.ResourceTypes.Add(rt)
    End Sub

    Protected Sub RadScheduler1_AppointmentClick(sender As Object, e As Telerik.Web.UI.SchedulerEventArgs) Handles RadScheduler1.AppointmentClick
        Dim id = e.Appointment.ID
        ' e.Appointment.Attributes.  
        Dim user As Resource = e.Appointment.Resources.GetResourceByType("Teacher")


    End Sub
    Protected Sub binddates(ByVal cntl As Control, ByVal seldate As String, ByVal mindate As String, ByVal maxdate As String, ByVal enbl As Boolean)

        Dim cnrl1 As RadDatePicker = TryCast(cntl, RadDatePicker)
        If Not seldate.Trim = "" Then
            cnrl1.SelectedDate = seldate
        Else
            '  cnrl1.SelectedDate = Date.Today.ToString("dd-MMM-yyyy")
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

    Protected Sub RadScheduler1_AppointmentDataBound(ByVal sender As Object, ByVal e As SchedulerEventArgs)


        Dim colorAttribute As String = e.Appointment.Attributes("EVNTSTS")
        Dim catAttribute1 As String = e.Appointment.Attributes("EVNTCAT")

        If Not String.IsNullOrEmpty(catAttribute1) Then

            If catAttribute1 = "1021" Then

                e.Appointment.BackColor = Color.Red
                e.Appointment.ForeColor = Color.White

            ElseIf catAttribute1 = "1023" Then

                e.Appointment.BackColor = Color.ForestGreen
                e.Appointment.ForeColor = Color.White

            Else

                GoTo line
            End If

        Else

line:
            If Not String.IsNullOrEmpty(colorAttribute) Then
                '   Dim colorValue As Integer
                ' If Integer.TryParse(colorAttribute, colorValue) Then

                If colorAttribute = "2064" Then

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    e.Appointment.BackColor = Color.RosyBrown
                    e.Appointment.ForeColor = Color.White
                    ' e.Appointment.BorderColor = Color.Black
                ElseIf colorAttribute = "2066" Or colorAttribute = "2067" Then

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    e.Appointment.BackColor = Color.MistyRose
                    e.Appointment.ForeColor = Color.White
                    ' e.Appointment.BorderColor = Color.Black
                ElseIf colorAttribute = "2065" Or colorAttribute = "802" Then

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    e.Appointment.BackColor = Color.SandyBrown
                    e.Appointment.ForeColor = Color.White
                    ' e.Appointment.BorderColor = Color.Black
                ElseIf colorAttribute = "2078" Or colorAttribute = "2079" Then

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    e.Appointment.BackColor = Color.SeaGreen
                    e.Appointment.ForeColor = Color.White
                    ' e.Appointment.BorderColor = Color.Black
                Else
                    e.Appointment.BackColor = Color.WhiteSmoke
                    e.Appointment.ForeColor = Color.White
                    '  e.Appointment.BorderColor = Color.Black
                End If


                ' e.Appointment.BorderStyle = BorderStyle.Solid
                '  e.Appointment.BorderWidth = Unit.Pixel(1)
                'End If
            End If
        End If





        ' e.Appointment.ToolTip = e.Appointment.Subject + ": " + e.Appointment.Description
        '       Dim str As New StringBuilder

        '       str.Append("<br>" & e.Appointment.Attributes("SUB1"))
        '       str.Append(vbNewLine & "Start Date: " & e.Appointment.Start.ToString("dd-MMM-yyyy HH:mm:ss"))
        '       str.Append(vbNewLine & "End Date: " & e.Appointment.End.ToString("dd-MMM-yyyy HH:mm:ss"))
        '       str.Append(vbNewLine & "Category/Product: " & e.Appointment.Attributes("SUBJ"))
        '       str.Append(vbNewLine & "Moderator: ")
        '       str.Append(vbNewLine & "--------------------------------------------------")

        '       str.Append(vbNewLine & e.Appointment.Description)
        '    str.Append(" <a  id='rrr1' class='pop2'  href='addevent.aspx?id=" & e.Appointment.ID & "&empid=" & Request.QueryString("empid") & "'> More Details</a>")

        'Dim aptCont As 	SchedulerAppointmentContainer  =  TryCast(SchedulerAppointmentContainer,)ltlApptDisplay.Parent;

        '	Dim radTooltip As RadToolTip = New RadToolTip()
        '       radTooltip.ID = "radApp" & e.Appointment.ClientID.ToString()
        '       radTooltip.Text = str.ToString()
        '       radTooltip.TargetControlID = e.Appointment.ClientID
        '       radTooltip.IsClientID = True
        '       radTooltip.AutoCloseDelay = 0
        '       radTooltip.ShowDelay = 0
        '       radTooltip.HideDelay = 10
        '       radTooltip.Position = ToolTipPosition.MiddleLeft
        '       radTooltip.RelativeTo = ToolTipRelativeDisplay.Element
        '       radTooltip.HideEvent = ToolTipHideEvent.LeaveTargetAndToolTip

        '       '  e.Appointment.AppointmentControls.Add(radTooltip)


        '       'e.Container.Controls.Add(lnkButtonMore)
        '       '  e.Container.Controls.Add(radTooltip)

        '       e.Appointment.



    End Sub


    Private Sub bindresource()

        'Dim rt As ResourceType = New ResourceType("User")
        'rt.DataSource = clas.getdata("select empno,name from tt.employee", "qr")
        'rt.KeyField = "empno"
        'rt.TextField = "name"
        'rt.ForeignKeyField = "empno"
        'RadScheduler1.ResourceTypes.Add(rt)

    End Sub
    Private Sub bindschedule()


        'Session.Remove(AppointmentsKey)
        
    

        'RadScheduler1.DataKeyField = "ID"
        'RadScheduler1.DataStartField = "STARTACT"
        'RadScheduler1.DataEndField = "ENDACT"
        'RadScheduler1.DataSubjectField = "Subject"
        'RadScheduler1.DataRecurrenceField = "RECURRENCERULE"
        'RadScheduler1.DataRecurrenceParentKeyField = "RECURRENCEPARENTID"
        'RadScheduler1.DataDescriptionField = "DESCRIPTION"



        RadScheduler1.DataKeyField = "EVNTID"
        RadScheduler1.DataStartField = "EVNTSTDT"
        RadScheduler1.DataEndField = "EVNTEDDT"
        RadScheduler1.DataSubjectField = "SUBJ"


        '   RadScheduler1.DataSubjectField = "EVNTSUB"


        '  Dim timeCheckin As String = Format("EVNTSTTIM", "HH:mm:ss")
        '  RadScheduler1.DayStartTime = TimeSpan.Parse(timeCheckin)
        '  RadScheduler1.CustomAttributeNames(1) = "EVNTVENU"
        '. DataRecurrenceField = "RECURRENCERULE"
        '  RadScheduler1.DataRecurrenceParentKeyField = "RECURRENCEPARENTID"

        RadScheduler1.DataDescriptionField = "EVNTDESC"
   

        'Dim rt As ResourceType = New ResourceType("Teacher")
        'Dim qry = "select Empno,Name from TT.EMPLOYEES where desgid=(select desgid from ranu.desgmaster where desiglevel=1) and active='T' "
        'rt.DataSource = clas.getdata(qry, "qr")
        'rt.KeyField = "empno"
        'rt.TextField = "name"
        'rt.ForeignKeyField = "EVNTAPPBY"
        'RadScheduler1.ResourceTypes.Add(rt)

        'Dim rt1 As ResourceType = New ResourceType("Scope")
        'Dim qry1 = "select transid,description from tt.event_intstatus  where scope=1 and status='A'"
        'rt1.DataSource = clas.getdata(qry1, "qr")
        'rt1.KeyField = "transid"
        'rt1.TextField = "description"
        'rt1.ForeignKeyField = "EVNTSCP"
        'RadScheduler1.ResourceTypes.Add(rt1)



        'Dim rt2 As ResourceType = New ResourceType("Status")
        'qry1 = "select statcd,statdescr from tt.ipdocstatus where scope=555"
        'rt2.DataSource = clas.getdata(qry1, "qr")
        'rt2.KeyField = "statcd"
        'rt2.TextField = "statdescr"
        'rt2.ForeignKeyField = "EVNTSTS"
        'RadScheduler1.ResourceTypes.Add(rt2)


        'Dim rt3 As ResourceType = New ResourceType("Category")
        'qry1 = "select statcd,statdescr from tt.ipdocstatus where scope=558"
        'rt3.DataSource = clas.getdata(qry1, "qr")
        'rt3.KeyField = "statcd"
        'rt3.TextField = "statdescr"
        'rt3.ForeignKeyField = "EVNTCAT"
        'RadScheduler1.ResourceTypes.Add(rt3)


        'Dim rt4 As ResourceType = New ResourceType("Person")
        'qry1 = "select Empno,Name from TT.EMPLOYEES where active='T'"
        'rt4.DataSource = clas.getdata(qry1, "qr")
        'rt4.KeyField = "Empno"
        'rt4.TextField = "Name"
        'rt4.ForeignKeyField = "EVNTRSPEMP"
        'RadScheduler1.ResourceTypes.Add(rt4)
        '' ctr_dtAppBy.Items.Insert(0, New ListItem("Choose Approved by", ""))

        'Dim rt5 As ResourceType = New ResourceType("Priority")
        'qry1 = "select statcd,statdescr from tt.ipdocstatus where scope=557"
        'rt5.DataSource = clas.getdata(qry1, "qr")
        'rt5.KeyField = "statcd"
        'rt5.TextField = "statdescr"
        'rt5.ForeignKeyField = "EVNTPRTY"
        'RadScheduler1.ResourceTypes.Add(rt5)

       

        ' RadScheduler1.Rebind()
    End Sub

    Protected Sub RadScheduler1_AppointmentCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentCreatedEventArgs) Handles RadScheduler1.AppointmentCreated

     
        Dim str As New StringBuilder
        Dim colorAttribute As String = e.Appointment.Attributes("EVNTSTS")
        Dim catAttribute1 As String = e.Appointment.Attributes("EVNTCAT")
        str.Append("<div class='evntTt'>")
        If Not String.IsNullOrEmpty(catAttribute1) Then

            If catAttribute1 = "1021" Then

                ' e.Appointment.BackColor = Color.Red
                'e.Appointment.ForeColor = Color.White
                str.Append("<h3  class='title-one red'><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

            ElseIf catAttribute1 = "1023" Then
                ' e.Appointment.BackColor = Color.ForestGreen
                'e.Appointment.ForeColor = Color.White
                str.Append("<h3 class='title-one forestgreen'><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

            Else

                GoTo line
            End If

        Else

line:
            If Not String.IsNullOrEmpty(colorAttribute) Then
                '   Dim colorValue As Integer
                ' If Integer.TryParse(colorAttribute, colorValue) Then

                If colorAttribute = "2064" Then

                    str.Append("<h3 class='title-one rosybrown' ><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    ' e.Appointment.BackColor = Color.RosyBrown
                  
                ElseIf colorAttribute = "2066" Or colorAttribute = "2067" Then
                    str.Append("<h3 class='title-one mistyrose'><span class='title'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    '  e.Appointment.BackColor = Color.MistyRose
                  
                ElseIf colorAttribute = "2065" Or colorAttribute = "802" Then
                    str.Append("<h3 class='title-one sandybrown'><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    '  e.Appointment.BackColor = Color.SandyBrown
                 
                ElseIf colorAttribute = "2078" Or colorAttribute = "2079" Then
                    str.Append("<h3 class='title-one seagreen'><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")


                    '  Dim appointmentColor As Color = Color.FromArgb(colorValue)
                    ' e.Appointment.BackColor = Color.SeaGreen
                 
                Else
                    str.Append("<h3 class='title-one whitesmoke'><span class='title1'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a class='icon-env'  href=''><i class='fa fa-envelope'></i></a> <a class='icon-circle' href=''><i class='fa fa-info-circle'></i></a></span></h3>")

                    ' e.Appointment.BackColor = Color.WhiteSmoke                   
                End If
                ' e.Appointment.BorderStyle = BorderStyle.Solid
                '  e.Appointment.BorderWidth = Unit.Pixel(1)
                'End If
            End If
        End If

        'str.Append("<br>" & e.Appointment.Attributes("SUB1"))
        'str.Append(vbNewLine & "Start Date: " & e.Appointment.Start.ToString("dd-MMM-yyyy HH:mm:ss"))
        'str.Append(vbNewLine & "End Date: " & e.Appointment.End.ToString("dd-MMM-yyyy HH:mm:ss"))
        'str.Append(vbNewLine & "Category/Product: " & e.Appointment.Attributes("SUBJ"))
        'str.Append(vbNewLine & "Moderator: ")
        'str.Append(vbNewLine & "--------------------------------------------------")
        'str.Append(vbNewLine & e.Appointment.Description)
        'str.Append("<h3 class='title-one'><span class='title'>" & e.Appointment.Attributes("SUB1") & "</span><span class='icon'><a href=''><i class='fa fa-envelope'></i></a> <a href=''><i class='fa fa-info-circle'></i></a></span></h3>")

        str.Append("<div class='title1cnt'>" & "<b>Start Date: </b>" & e.Appointment.Start.ToString("dd-MMM-yyyy HH:mm:ss"))
        str.Append("<br>" & "<b>End Date:</b> " & e.Appointment.End.ToString("dd-MMM-yyyy HH:mm:ss"))
        str.Append("<br>" & "<b>Category/Product:</b> " & e.Appointment.Attributes("SUBJ"))
        str.Append("<br>" & "<b>Moderator:</b> " & e.Appointment.Attributes("EVNTRSPEMPNM"))
        str.Append("<br>" & "<b>Status:</b> " & e.Appointment.Attributes("STS"))
        str.Append("<br>" & "--------------------------------------------------")

        str.Append("<br>" & e.Appointment.Description & "<br><br>")
        str.Append("<a id='rrr1' class='pop2 more-info'  href='addevent.aspx?id=" & e.Appointment.ID & "&empid=" & Request.QueryString("empid") & "&zbaid=" & Request.QueryString("zbaid") & "'> More Info</a> </div>")
        str.Append("</div>")

        '  e.Appointment.ToolTip = str.ToString()

        Dim radTooltip As RadToolTip = New RadToolTip()
        radTooltip.ID = "radApp" & e.Appointment.ClientID.ToString()
        radTooltip.Text = str.ToString()
        radTooltip.TargetControlID = e.Appointment.ClientID
        radTooltip.IsClientID = True
        radTooltip.AutoCloseDelay = 0
        radTooltip.ShowDelay = 100
        radTooltip.HideDelay = 1000
        radTooltip.Animation = ToolTipAnimation.Fade
        radTooltip.Position = ToolTipPosition.BottomCenter
        radTooltip.RelativeTo = ToolTipRelativeDisplay.Element
        radTooltip.HideEvent = ToolTipHideEvent.LeaveTargetAndToolTip

        'e.Container.Controls.Add(lnkButtonMore)
        e.Container.Controls.Add(radTooltip)



    End Sub





    Protected Sub RadScheduler1_AppointmentDelete(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentDeleteEventArgs) Handles RadScheduler1.AppointmentDelete
        'Dim qry = "delete from satinder.APPOINTMENT where id='" & e.Appointment.ID & "'"
        '   Dim qry = "delete from tt.evnt_mast where EVNTID='" & e.Appointment.ID & "'"
        ' clas.ExecuteNonQuery(qry.ToString)
        refill()
    End Sub


    Private Sub RadScheduler1_AppointmentInsert(ByVal sender As Object, ByVal e As SchedulerCancelEventArgs) Handles RadScheduler1.AppointmentInsert

        'Dim subjet1 = e.Appointment.Subject
        'Dim start1 = e.Appointment.Start
        'Dim end1 = e.Appointment.[End]
        'Dim desc = e.Appointment.Description
        'Dim uid = e.Appointment.ID

        'Dim recrule = e.Appointment.RecurrenceRule
        'Dim empid = ""
        'Dim scope = "1"
        'Dim status, category, person, Priority
        'Dim recurence = e.Appointment.RecurrenceParentID
        'Dim colorattr = e.Appointment.Attributes("AppointmentColor")
        'Dim colorValue As Integer
        'Dim appointmentColor As Color
        'Dim venue As String

        'If Not String.IsNullOrEmpty(colorattr) Then

        '    If Integer.TryParse(colorattr, colorValue) Then
        '        appointmentColor = Color.FromArgb(colorValue)
        '    End If
        'End If

        'If Not e.Appointment.Resources.GetResourceByType("Teacher") Is Nothing Then
        '    empid = Convert.ToString(e.Appointment.Resources.GetResourceByType("Teacher").Key)
        'End If


        'If Not e.Appointment.Resources.GetResourceByType("Scope") Is Nothing Then
        '    scope = Convert.ToString(e.Appointment.Resources.GetResourceByType("Scope").Key)
        'End If

        'If Not e.Appointment.Resources.GetResourceByType("Status") Is Nothing Then
        '    status = Convert.ToString(e.Appointment.Resources.GetResourceByType("Status").Key)
        'End If

        'If Not e.Appointment.Resources.GetResourceByType("Category") Is Nothing Then
        '    category = Convert.ToString(e.Appointment.Resources.GetResourceByType("Category").Key)
        'End If

        'If Not e.Appointment.Resources.GetResourceByType("Person") Is Nothing Then
        '    person = Convert.ToString(e.Appointment.Resources.GetResourceByType("Person").Key)
        'End If
        'If Not e.Appointment.Resources.GetResourceByType("Priority") Is Nothing Then
        '    Priority = Convert.ToString(e.Appointment.Resources.GetResourceByType("Priority").Key)
        'End If




        'Dim tmp = e.Appointment.Attributes("AppointmentColor")
        'venue = e.Appointment.Attributes("EVNTVENU")
        'Dim curr = e.Appointment.Attributes("Curr")
        'Dim amt = e.Appointment.Attributes("Budget")


        'Dim lsemp As String
        'lsemp = e.Appointment.Attributes("getlist")

        ''For Each i In ls
        ''    Dim j = 1
        ''Next

        ''Dim rm = e.Appointment.Resources.GetResource("Room")
        'Dim agentid = 1
        '' Dim qry = "insert into satinder.APPOINTMENT(id,subject,startact,endact,DESCRIPTION,empno,APPOINTMENTCOLOR) values( satinder.APPOINTMENT_SEQ.nextval ,'" & subjet1 & "','" & CDate(start1).ToString("dd-MMM-yyyy") & "','" & CDate(end1).ToString("dd-MMM-yyyy") & "', '" & Convert.ToString(e.Appointment.Description) & "','" & empid & "','" & colorValue & "')"
        'Dim str As New StringBuilder
        'Dim evntid = clas.getMaxID("select tt.evnt_mast_seq.nextval from dual")

        'str.Append("insert into tt.evnt_mast (EVNTID, EVNTSUB, EVNTDESC, EVNTSTDT, EVNTEDDT, EVNTVENU, EVNTSCP, EVNTCAT, EVNTAPPBY, EVNTSTS, KEYEDON, KEYEDBY, KEYEDIP, KEYEDBRWS,EVNTPRTY,EVNTRSPEMP) values ")
        'str.Append(" ('" & evntid & "' ,'" & subjet1 & "','" & Convert.ToString(e.Appointment.Description) & "',TO_DATE('" & start1.ToString() & "', 'DD/MM/YYYY HH12:MI:SS PM'),TO_DATE('" & end1.ToString() & "', 'DD/MM/YYYY HH12:MI:SS PM'),")
        'str.Append("'" & venue & "','" & scope & "','" & category & "','" & empid & "','" & status & "',sysdate,'" & agentid & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "','" & Priority & "', '" & person & "')")
        ''CDate(start1).ToString("dd-MMM-yyyy hh:mm tt")
        ''CDate(end1).ToString("dd-MMM-yyyy hh:mm tt") 
        '' Response.Write(qry)
        'clas.ExecuteNonQuery(str.ToString)

        'Dim qry = "insert into tt.evnt_budgt(TRANSID,EVNTID,CURRCODE,AMOUNT,status,KEYEDON,KEYEDBY,KEYEDIP,KEYEDBRWS) values "
        'qry += " (tt.evnt_budgt_seq.nextval,'" & evntid & "', '" & curr & "', '" & amt & "', '" & status & "', sysdate, '" & agentid & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "')"
        'clas.ExecuteNonQuery(qry.ToString)


        ''Insert Assigned Emploee
        'Dim eno() As String = lsemp.ToString.Split(New Char() {","c})

        'For Each element As String In eno
        '    If element.Trim = "" Then Continue For
        '    qry = "insert into  TT.EVNT_ASGN (ID,EVNTID,EMPNO,status,KEYEDON,KEYEDBY,KEYEDIP,KEYEDBRWS) values "
        '    qry += " (tt.EVNT_ASGN_seq.nextval,'" & evntid & "', '" & element & "','A', sysdate, '" & agentid & "','" & HttpContext.Current.Request.UserHostAddress & "','" & Request.Browser.Browser & "')"
        '    clas.ExecuteNonQuery(qry.ToString)
        'Next

        'refill()


        ''If i = 1 Then
        ''    RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Transaction Done Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
        ''    Exit Sub
        ''Else
        ''    Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
        ''    Err_Msg = Err_Msg.Replace(vbCr, "")
        ''    Err_Msg = Err_Msg.Replace(vbLf, "")
        ''    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

        ''    '  RadWindowManager1.RadAlert("<ul><li><div style=color:red;> Transaction not Done </div></li></ul>", 300, 150, "Validation Success", Nothing)
        ''End If

        ''bindschedule()
    End Sub

    Private Sub refill()
        'RadScheduler1.DataSource = clas.getdata("SELECT t1.EVNTID,t1.EVNTSUB,t1.EVNTDESC, t1.EVNTSTDT,t1.EVNTEDDT,t1.EVNTVENU,t1.EVNTSCP,t1.EVNTCAT,t1.EVNTAPPBY,t1.EVNTSTS,t1.EVNTPRTY,t1.EVNTLVLSCP,t1.EVNTLVLID,t1.EVNTRSPEMP,t2.amount as Budget,t2.currcode Curr,t3.empno FROM TT.EVNT_MAST t1  left outer join tt.evnt_budgt t2 on t2.evntid=t1.evntid  left outer join tt.evnt_asgn t3 on t3.evntid=t1.evntid", "qr")
        '  RadScheduler1.DataSource = clas.getdata("SELECT t1.EVNTID,t1.EVNTSUB,t1.EVNTDESC, t1.EVNTSTDT,  to_date(to_char(T1.EVNTEDDT,'dd-Mon-yyyy') ||' 23:59:59','dd-Mon-yyyy hh24:mi:ss')   EVNTEDDT,t1.EVNTVENU,t1.EVNTPRD,t1.EVNTCAT,t1.EVNTAPPBY,t1.EVNTSTS,t1.EVNTPRTY,t1.EVNTLVLSCP,t1.EVNTLVLID,t1.EVNTRSPEMP,t1.EVNTRSPEMP, to_char(t1.EVNTSTTIM,'hh:mi:ss') EVNTSTTIM, '" & Request.QueryString("empid") & "' empid, '" & Request.QueryString("zbaid") & "' zbaid FROM TT.EVNT_MAST t1  ", "tx")
        Dim qry As String = ""
        If rdlist.SelectedValue = "A" Then
            qry = "SELECT t1.EVNTID,t1.EVNTSUB SUB1,t1.EVNTDESC, EVNTSTTIM EVNTSTDT,  to_date(to_char(T1.EVNTEDDT,'dd-Mon-yyyy') ||' 23:59:59','dd-Mon-yyyy hh24:mi:ss')   EVNTEDDT,t1.EVNTVENU,t1.EVNTPRD,t1.EVNTCAT,t1.EVNTAPPBY,t1.EVNTSTS,t1.EVNTPRTY,t1.EVNTLVLSCP,t1.EVNTLVLID,t1.EVNTRSPEMP, to_char(t1.EVNTSTTIM,'hh:mi:ss') EVNTSTTIM, (select actdescr from TT.EVENT_ACTIVITY where actid =t1.EVNTCAT)||' - '|| (select actdescr from TT.EVENT_ACTIVITY where actid =t1.EVNTPRD) SUBJ,(select name from tt.employees where empno= T1.EVNTRSPEMP) EVNTRSPEMPNM, (select statdescr from tt.ipdocstatus where scope=1009 and statcd= t1.EVNTSTS ) STS,  '" & Request.QueryString("empid") & "' empid, '" & Request.QueryString("zbaid") & "' zbaid FROM TT.EVNT_MAST t1 where t1.EVNTID in (select evntid from tt.evnt_act where actasgnto='" & DropDownList1.SelectedValue & "') "
        Else
            qry = "SELECT t1.EVNTID,t1.EVNTSUB SUB1,t1.EVNTDESC, EVNTSTTIM EVNTSTDT,  to_date(to_char(T1.EVNTEDDT,'dd-Mon-yyyy') ||' 23:59:59','dd-Mon-yyyy hh24:mi:ss')   EVNTEDDT,t1.EVNTVENU,t1.EVNTPRD,t1.EVNTCAT,t1.EVNTAPPBY,t1.EVNTSTS,t1.EVNTPRTY,t1.EVNTLVLSCP,t1.EVNTLVLID,t1.EVNTRSPEMP, to_char(t1.EVNTSTTIM,'hh:mi:ss') EVNTSTTIM, (select actdescr from TT.EVENT_ACTIVITY where actid =t1.EVNTCAT)||' - '|| (select actdescr from TT.EVENT_ACTIVITY where actid =t1.EVNTPRD) SUBJ,(select name from tt.employees where empno= T1.EVNTRSPEMP) EVNTRSPEMPNM, (select statdescr from tt.ipdocstatus where scope=1009 and statcd= t1.EVNTSTS ) STS, '" & Request.QueryString("empid") & "' empid, '" & Request.QueryString("zbaid") & "' zbaid FROM TT.EVNT_MAST t1  "


            If ddllevl.SelectedValue = "B" Then
                qry &= " where evntlvlscp='B' and evntlvlid='" & DropDownList1.SelectedValue & "'"

            ElseIf ddllevl.SelectedValue = "O" Then
                qry &= " where evntlvlscp='O' and evntlvlid='" & DropDownList1.SelectedValue & "'"

            ElseIf ddllevl.SelectedValue = "D" Then

                qry &= " where evntlvlscp1='D' and evntlvlid1='" & DropDownList1.SelectedValue & "'"
            ElseIf ddllevl.SelectedValue = "I" Then

                qry &= " where evntlvlscp1='I' and (evntlvlid1='" & DropDownList1.SelectedValue & "' or EVNTRSPEMP='" & DropDownList1.SelectedValue & "')"
            Else


            End If

        End If



       





        RadScheduler1.DataSource = clas.getdata(qry, "tx")

        'Response.Write(qry)

        '  RadScheduler1.DataBind()

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        refill()
    End Sub

    Protected Sub RadScheduler1_Load(ByVal sender As Object, ByVal e As EventArgs)
        '  refill()
    End Sub
    Protected Sub RadScheduler1_AppointmentUpdate(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentUpdateEventArgs) Handles RadScheduler1.AppointmentUpdate
        ' Dim qry = "update satinder.APPOINTMENT set subject='" & e.Appointment.Subject & "',startact=" & e.Appointment.Start & ",endact=" & e.Appointment.[End] & " where id='" & e.Appointment.ID & "'"""
        'clas.ExecuteNonQuery(qry.ToString)
        ' bindschedule()
    End Sub

    'Protected Sub RadCalendar1_SelectionChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDatesEventArgs) Handles RadCalendar1.SelectionChanged
    '    RadScheduler1.SelectedDate = RadCalendar1.SelectedDate
    '    RadScheduler1.SelectedView = SchedulerViewType.DayView
    '    ' RadScheduler1.Rebind()
    'End Sub
    'Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    RadScheduler1.ShowAlldayInlineInsertForm(Now)
    'End Sub


    'Protected Sub RadScheduler1_FormCreated(sender As Object, e As Telerik.Web.UI.SchedulerFormCreatedEventArgs) Handles RadScheduler1.FormCreated

    '    If (e.Container.Mode = SchedulerFormMode.AdvancedEdit) OrElse (e.Container.Mode = SchedulerFormMode.AdvancedInsert) Then
    '        'Find and hide the advanced control panel:     
    '        'Dim advancedPanel As Panel = DirectCast(e.Container.FindControl("AdvancedControlsPanel"), Panel)  
    '        'advancedPanel.Visible = False  

    '        ''Find the Subject textbox and set its Height:     
    '        'Dim subjectTextbox As RadTextBox = DirectCast(e.Container.FindControl("Subject"), RadTextBox)
    '        'subjectTextbox.Height = Unit.Pixel(20)
    '        'subjectTextbox.Label = "Subject (modified):"

    '        ''Find the RadComboBox control for the Room resource and set its SelectedIndex property.      
    '        ''This is useful if you want to default to a specific resource selection. However,     
    '        ''you should leave only the AdvancedInsert clause from the if statement above.      
    '        'Dim resRoomDDL As RadComboBox = DirectCast(e.Container.FindControl("ResRoom"), RadComboBox)
    '        'resRoomDDL.SelectedIndex = 2

    '        ''Find the TextBox for the Description custom attribute and set its background color and label:     
    '        'Dim attrAnnotationsTextbox As RadTextBox = DirectCast(e.Container.FindControl("AttrDescription"), RadTextBox)
    '        'attrAnnotationsTextbox.BackColor = System.Drawing.Color.Yellow
    '        'attrAnnotationsTextbox.Label = "Description(modified):"

    '        ''Change the description for the Room resource:     
    '        'Dim resWebcontrol1 As WebControl = DirectCast(e.Container.FindControl("LblResRoom"), WebControl)
    '        'Dim resLabel1 As New Label()
    '        'resLabel1.Text = "Room: (modified)"
    '        'resWebcontrol1.Controls.Clear()
    '        'resWebcontrol1.Controls.Add(resLabel1)
    '        'Dim resRoomDDL As RadComboBox = DirectCast(e.Container.FindControl("ResRoom"), RadComboBox)
    '        Dim resWebcontrol1 As RadComboBox = DirectCast(e.Container.FindControl("Scope"), RadComboBox)
    '        '  resWebcontrol1.SelectedIndex = 2
    '    End If
    'End Sub


    Protected Sub ddllevl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllevl.SelectedIndexChanged


        If ddllevl.SelectedValue = "B" Then
            Dim dt = clas.getdata("select zbaid as id, zbaname as Description  FROM system.active_branches order by zbaname ASC", "TX")
            bindfromdt(DropDownList1, "", dt, "", "Description", "id", "dropdown", True)
        ElseIf ddllevl.SelectedValue = "O" Then
            Dim dt = clas.getdata("select cmpid as id , cmpnm as Description from ranu.companymaster where status='A' order by cmpnm ASC ", "TX")
            bindfromdt(DropDownList1, "", dt, "", "Description", "id", "dropdown", True)

        ElseIf ddllevl.SelectedValue = "D" Then
            Dim dt = clas.getdata("select deptid as id, department as Description  FROM ranu.deptmaster order by department ASC", "TX")
            bindfromdt(DropDownList1, "", dt, "", "Description", "id", "dropdown", True)

        ElseIf ddllevl.SelectedValue = "I" Then
            Dim dt = clas.getdata("select empno as id , name ||' ('|| Branch||' - '|| EMPDESIGNATION||')' as Description from tt.employees where active='T' order by name ASC ", "TX")

            If Convert.ToString(Request.QueryString("empid")) = "159" Then
                bindfromdt(DropDownList1, "", dt, Request.QueryString("empid"), "Description", "id", "dropdown", True)
                RequiredFieldValidator5.ValidationGroup = "abc"

            Else
                bindfromdt(DropDownList1, "", dt, Request.QueryString("empid"), "Description", "id", "dropdown", False)
                RequiredFieldValidator5.ValidationGroup = "basicdetails12"
            End If

        Else
            bindemptyfromdt(DropDownList1, "dropdown", True)

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


    Protected Sub rdlist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlist.SelectedIndexChanged

        If rdlist.SelectedValue = "A" Then

            ddllevl.SelectedValue = "I"
            ddllevl_SelectedIndexChanged(ddllevl, Nothing)

            refill()

        Else

            ddllevl.SelectedValue = ""
            ddllevl_SelectedIndexChanged(ddllevl, Nothing)
        End If

    End Sub
End Class
