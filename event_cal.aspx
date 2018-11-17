<%@ Page Language="VB" AutoEventWireup="true" CodeFile="event_cal.aspx.vb" Inherits="RadSchedulerAdvancedForm" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="AdvancedForm.ascx" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/tr/xhtml11/dtd/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta name='viewport' content='width=device-width, initial-scale=1.0'/>
 <link href="css_chklst/bootstrap-new.min.css" rel="stylesheet"/>
 <link rel="stylesheet" href="css_chklst/bootstrap.min.css" />
 <link href="css_chklst/notify_css.css" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" type="text/css" href="css_chklst/event-stylee.css" />
 <link rel="stylesheet" type="text/css" href="css_chklst/font-awesome.min.css" />
 <style type="text/css">
 .RadToolTip .rtWrapper td.rtWrapperContent {

    padding: 0 !important;
}
 
 </style>

<script src="js/jquery.min.js" type="text/javascript" ></script> 
<script src="js/jquery.ui.custom.js" type="text/javascript" ></script> 
<script src="js/bootstrap.min.js"  type="text/javascript"></script> 
<telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
<script type="text/javascript">

    $(document).ready(function () {
        Getdata();
        var myVar = setInterval(Getdata, 9000);

    });


    function Getdata() {

        var Name = $('#HFSession').val();

        $.ajax({
            type: "POST",
            url: "notification.asmx/FetchNotification2", // add web service Name and web service Method Name
            data: "{'Eid':'" + Name + "'}",  //web Service method Parameter Name and ,user Input value which in Name Variable.
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var xmlDoc = $.parseXML(response.d);
                var xml = $(xmlDoc);

                var noti_xml = xml.find("notification");
                // if ($(noti_xml).length < 0) { return; }     // exit function if no data

                var count = noti_xml.find("TITLE").size();

                // ANIMATEDLY DISPLAY THE NOTIFICATION COUNTER.
                $('#noti_Counter')
                .css({ opacity: 0 })
                .fadeIn('slow')
                .text(count)  // ADD DYNAMIC VALUE (YOU CAN EXTRACT DATA FROM DATABASE OR XML).
                // .css({ top: '-10px' })
                .animate({ top: '-2px', opacity: 1 }, 500);

                var ndata = $("#noti_data");
                var table = $("#noti_data ul").eq(0).clone(true);
                //$("#noti_data ul").empty();
                //$("#noti_data").empty();
                if (count == 0) {
                    $(ndata).hide();
                    return;
                }
                else {
                    $(ndata).show();
                    $(ndata).empty();
                }

                $(noti_xml).each(function () {
                    $(".title", table).html($(this).find("TITLE").text());
                    $(".date", table).html($(this).find("NOT_DATETIME").text());
                    $("#actlink", table).attr("href", $(this).find("ACTION_LINK").text());
                    $(".ack_noti", table).attr("data_id", $(this).find("ID").text());
                    $("#actlink", table).attr("data_id", $(this).find("ID").text());

                    $("#noti_data").append(table);
                    table = $("#noti_data ul").eq(0).clone(true);
                });


                //old
                //  $("#noti_Counter").html(response.d); //getting the Response from JSON
                //  $("#noti_Counter").html(response.d); 

            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }

    function UpdateNoti() {
        //not using
        var Name = $('#HFSession').val();
        var IP = $('#HFIP').val();
        //if (Greadon == undefined) return;  
        $.ajax({
            type: "POST",
            url: "notification.asmx/UpdateNotification", // add web service Name and web service Method Name
            data: "{'Eid':'" + Name + "','IP':'" + IP + "'}",  //web Service method Parameter Name and ,user Input value which in Name Variable.
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var res = response.d;
            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }
    function UpdateNoti_id(nid) {

        var Name = $('#HFSession').val();
        var IP = $('#HFIP').val();
        var id = nid;

        //if (Greadon == undefined) return;  
        $.ajax({
            type: "POST",
            url: "notification.asmx/UpdateNotification_id", // add web service Name and web service Method Name
            data: "{'Eid':'" + Name + "','IP':'" + IP + "','id':'" + nid + "'}",  //web Service method Parameter Name and ,user Input value which in Name Variable.
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var res = response.d;
                Getdata();
            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }
    </script>

<script type="text/javascript">
    $(function () {
        $('#actlink').click(function () {
            UpdateNoti_id($(this).attr('data_id'));
            location.replace($(this).attr('href'));
        });
    });


    $(function () {
        $('.ack_noti').click(function () {
            UpdateNoti_id($(this).attr('data_id'));
        });
    });

    $(document).ready(function () {

        $('#noti_Button').click(function () {
            // UpdateNoti();
            // TOGGLE (SHOW OR HIDE) NOTIFICATION WINDOW.
            $('#notifications').fadeToggle('fast', 'linear', function () {

                if ($('#notifications').is(':hidden')) {
                    //$('#noti_Button').css('background-color', '#2E467C');
                }
                // CHANGE BACKGROUND COLOR OF THE BUTTON.
                //else $('#noti_Button').css('background-color', '#FFF');
            });

            $('#noti_Counter').fadeOut('slow');     // HIDE THE COUNTER.

            return false;
        });

        // HIDE NOTIFICATIONS WHEN CLICKED ANYWHERE ON THE PAGE.
        $(document).click(function () {
            $('#notifications').hide();

            // CHECK IF NOTIFICATION COUNTER IS HIDDEN.
            if ($('#noti_Counter').is(':hidden')) {
                // CHANGE BACKGROUND COLOR OF THE BUTTON.
                // $('#noti_Button').css('background-color', '#ffffff');
            }
        });

        $('#noti_body').click(function () {
            return false;       // DO NOTHING WHEN CONTAINER IS CLICKED.
        });

//        $('#notifications').click(function () {
//            return false;       // DO NOTHING WHEN CONTAINER IS CLICKED.
//        });


    });
</script>
</head>
<body class="BODY">
    <form id="Form1" method="post" runat="server" class="event-cal">
   
   <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <script type="text/javascript">
        //Put your Java Script code here.
    </script>
     <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="WebBlue"  MinDisplayTime="1000"  ZIndex="93000"/>
    

     <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
 <%--
        <script type="text/javascript">
             <![CDATA[ 
            Sys.Application.add_load(function () {
                demo.categoryPanelBar = $find('<%=RadPanelBar1.ClientID %>');
                demo.scheduler = $find('<%=RadScheduler1.ClientID %>');
                demo.calendar1 = $find('<%=RadCalendar1.ClientID %>');
            });
             ]]> 
        </script>
          
         <script src="appointment_script/Script.js" type="text/javascript"></script>--%>
		 
		 
		 
		 
		 
		  <script src="scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
  <script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
    <script type="text/javascript" src="source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

	 <script type="text/javascript">

     
            $(document).ready(function callfancy() {
                    
                  
                    $('.fancybox').fancybox({
                        width: screen.width*60/100,
                        height: screen.height*90/100,
                        padding: 5,

                        openEffect: 'elastic',
                        openSpeed: 500,
                        type: 'iframe',
                        closeEffect: 'elastic',
                        closeSpeed: 500,
                        autoSize: false,
                        closeClick: true,

                        helpers: {
                            overlay: {
                                closeClick: true,
                                opacity: 0.4, // or the opacity you want 
                                // or your preferred hex color value
                            } // overlay 
                        }

                    });
             });
  $('.pop2').fancybox({
                 width: screen.width*95/100,
                 height: screen.height*95/100,
                 padding: 0,

                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

             });
              $('.pop').fancybox({
                        width: screen.width*25/100,
                        height: screen.height*50/100,
                        padding: 5,

                        openEffect: 'elastic',
                        openSpeed: 500,
                        type: 'iframe',
                        closeEffect: 'elastic',
                        closeSpeed: 500,
                        autoSize: false,
                        closeClick: true,

                        helpers: {
                            overlay: {
                                closeClick: true,
                                opacity: 0.4, // or the opacity you want 
                                // or your preferred hex color value
                            } // overlay 
                        }

                    });
          $('.pop3').fancybox({
                 width: 900,
                 height: 600,
                 padding: 0,

                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

             });
    </script>
		 
		 
    </telerik:RadScriptBlock>
    <script type="text/javascript">    
        //<![CDATA[

        // Dictionary containing the advanced template client object
        // for a given RadScheduler instance (the control ID is used as key).
        var schedulerTemplates = {};

        function schedulerFormCreated(scheduler, eventArgs) {
            // Create a client-side object only for the advanced templates
            var mode = eventArgs.get_mode();

        

            if (mode == Telerik.Web.UI.SchedulerFormMode.AdvancedInsert ||
                    mode == Telerik.Web.UI.SchedulerFormMode.AdvancedEdit) {
                // Initialize the client-side object for the advanced form
                var formElement = eventArgs.get_formElement();
                var templateKey = scheduler.get_id() + "_" + mode;
                var advancedTemplate = schedulerTemplates[templateKey];
                if (!advancedTemplate) {
                    // Initialize the template for this RadScheduler instance
                    // and cache it in the schedulerTemplates dictionary
                    var schedulerElement = scheduler.get_element();
                    var isModal = scheduler.get_advancedFormSettings().modal;
                    advancedTemplate = new window.SchedulerAdvancedTemplate(schedulerElement, formElement, isModal);
                    advancedTemplate.initialize();

                    schedulerTemplates[templateKey] = advancedTemplate;

                    // Remove the template object from the dictionary on dispose.
                    scheduler.add_disposing(function () {
                        schedulerTemplates[templateKey] = null;
                    });
                }

                // Are we using Web Service data binding?
                if (!scheduler.get_webServiceSettings().get_isEmpty()) {
                    // Populate the form with the appointment data
                    var apt = eventArgs.get_appointment();
                    var isInsert = mode == Telerik.Web.UI.SchedulerFormMode.AdvancedInsert;
                    advancedTemplate.populate(apt, isInsert);
                }
            }
        }



      

        //]]>
    </script>



    <div class="exampleContainer">

 <%--   <telerik:RadSplitter RenderMode="auto" runat="server" ID="RadSplitter1" Skin="Metro"
                    PanesBorderSize="0" Width="99.5%" Height="600">
                    <telerik:RadPane runat="Server" ID="leftPane" Width="230" Scrolling="None">
                        <telerik:RadSplitter RenderMode="Lightweight" runat="server" ID="RadSplitter2" Skin="Metro"
                            Orientation="Horizontal" Width="100%" >
                            <telerik:RadPane ID="RadPane1" runat="server" Height="283">
                                <telerik:RadCalendar RenderMode="Lightweight" runat="server" ID="RadCalendar1"  EnableMultiSelect="false"
                                    DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                    EnableMonthYearFastNavigation="true" Skin="Metro"  AutoPostBack="true">
                                
                                </telerik:RadCalendar>
                            </telerik:RadPane>
                            <telerik:RadSplitBar ID="RadSplitBar1" runat="server" EnableResize="false" />
                            <telerik:RadPane ID="RadPane2" runat="server">
 
                                <telerik:RadPanelBar RenderMode="Lightweight" runat="server" ID="RadPanelBar1"  Width="200px" Skin="Metro"
                                    ExpandAnimation-Type="None" CollapseAnimation-Type="None" ExpandMode="SingleExpandedItem">
                                    <Items>
                                       
                                    </Items>
                                </telerik:RadPanelBar>
                            </telerik:RadPane>
                        </telerik:RadSplitter>
                    </telerik:RadPane>
                    <telerik:RadSplitBar runat="server" ID="RadSplitBar2" CollapseMode="Forward" EnableResize="false" />
                    <telerik:RadPane runat="Server" ID="rightPane" Scrolling="Both">--%>

                    <div class="row" style="margin: 0;">
                        <div class="col-sm-12" style="padding:0; margin: 4px 0 2px 0;">
                            <div class="col-sm-3 col-xs-12">
                                <label for="sel1" class="label-class-width event_cal">
                                    Level:  <span style="color:red;display:none;">*</span></label>
                                <div class="input-class-width event_cal1">
                                    <asp:DropDownList ID="ddllevl" AutoPostBack="true" runat="server">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Branch" Value="B"></asp:ListItem>
                                        <asp:ListItem Text="Organistaion" Value="O"></asp:ListItem>
                                        <asp:ListItem Text="Department" Value="D"></asp:ListItem>
                                        <asp:ListItem Text="Individual" Value="I"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Scope is required" ControlToValidate="ddllevl"
                                        ValidationGroup="basicdetails12" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                             
                                <label for="sel1" class="label-class-width event_cal">
                                    -- <span style="color:red;display:none;">*</span></label>
                                <div class="input-class-width event_cal1">
                                    <asp:DropDownList ID="DropDownList1"  runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Branch/organistaion is required"
                                        ControlToValidate="DropDownList1" ValidationGroup="basicdetails12" ForeColor="Red"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

</div>

   <div class="col-xs-6 col-sm-3 list-icon">

   <asp:RadioButtonList  ID="rdlist" AutoPostBack="true" runat="server" Height="22px" RepeatColumns="2" 
           RepeatDirection="Horizontal" Width="161px">
       <asp:ListItem Selected="True" Value="E">Events</asp:ListItem>
       <asp:ListItem Value="A">My Activites</asp:ListItem>
   
   </asp:RadioButtonList>

   </div>



<div class="col-xs-6 col-sm-3 event_cal">

<a  id="newadd" runat="server" class="pop2 btn btn-primary all_btn top-one"><i class="fa fa-plus"></i></a>&nbsp; &nbsp; 

<span id="noti_Container" class="header_nav" style="padding-top: 0px; font-size:10px; display: block; float: right;">
<button type="button" class="button-default show-notifications  js-show-notifications" id="noti_Button" class="bell_ico">
                            <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" class="bell_ico" viewBox="0 0 30 32">
                            <defs>
                                <g id="icon-bell">
	                                <path class="path1" d="M15.143 30.286q0-0.286-0.286-0.286-1.054 0-1.813-0.759t-0.759-1.813q0-0.286-0.286-0.286t-0.286 0.286q0 1.304 0.92 2.223t2.223 0.92q0.286 0 0.286-0.286zM3.268 25.143h23.179q-2.929-3.232-4.402-7.348t-1.473-8.652q0-4.571-5.714-4.571t-5.714 4.571q0 4.536-1.473 8.652t-4.402 7.348zM29.714 25.143q0 0.929-0.679 1.607t-1.607 0.679h-8q0 1.893-1.339 3.232t-3.232 1.339-3.232-1.339-1.339-3.232h-8q-0.929 0-1.607-0.679t-0.679-1.607q3.393-2.875 5.125-7.098t1.732-8.902q0-2.946 1.714-4.679t4.714-2.089q-0.143-0.321-0.143-0.661 0-0.714 0.5-1.214t1.214-0.5 1.214 0.5 0.5 1.214q0 0.339-0.143 0.661 3 0.357 4.714 2.089t1.714 4.679q0 4.679 1.732 8.902t5.125 7.098z" />
                                </g>
                            </defs>
                            <g fill="#3b5a9a">
	                            <use xlink:href="#icon-bell" transform="translate(0 0)"></use>
                            </g>
                            </svg>
                            <div class="notifications-count js-count" id="noti_Counter"></div>
                    </button> </span>


                    <div id="notifications" style="z-index:999999">
                    <h3 class="not3">Notifications</h3>
                    <div style="height:300px;" id="noti_body">
                    <div id="noti_data">
                                    <ul class="tblNoti_Data notifications-list">
                                        <li class="item js-item" style="list-style:none; display: flex;">
                                             <i class="icon icon-circle ico_blue"></i>
                                            <div class="details">
                                                 <a href="#" id="actlink"> <span class="title"></span ></a> <br />
                                                
                                                <span class="date"></span>
                                                 <a class="ack_noti acc_link" href="" >Acknowledge</a>
                                            </div>
              
                                        </li>
                                        </ul>
                                           
                    </div> 
                    </div>
                  
                    <div class="seeAll" style="text-align: center;"> <a runat="server" id="myNotLink" class="pop2" href="notification_Details.aspx?empid=1"  style="color: #333;text-decoration:underline;"> Show All Notification </a>
                    
                    </div>
                </div>

                 <asp:LinkButton ID="LinkButton1"  OnClientClick="if(Page_ClientValidate('basicdetails')) ShowProgress();" Height="22"  CssClass="btn btn-primary all_btn" runat="server"><i class="fa fa-repeat" aria-hidden="true"></i>
 Refresh</asp:LinkButton> &nbsp; &nbsp;
                </div>
                             
                                 </div>
                            </div>
                       
                   


   




   
                             <telerik:RadScheduler runat="server" SelectedView="MonthView" ID="RadScheduler1" Width="100%" Height="600" OnDataBound="RadScheduler1_DataBound"
            AppointmentStyleMode="Default"   AllowInsert="false" AllowEdit="false" AllowDelete="false" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" DayView-HeaderDateFormat="dddd, MMMM dd, yyyy" 
            DayStartTime="00:00:01" DayEndTime="23:59:59" FirstDayOfWeek="Monday" LastDayOfWeek="Sunday" CustomAttributeNames="AppointmentColor,EVNTVENU,Budget,Curr,getlist,EVNTID,EMPID,ZBAID,EVNTSTS,SUBJ,EVNTCAT,EVNTDESC,SUB1,EVNTRSPEMPNM,STS"
            EnableDescriptionField="true" skin="Metro"  StartInsertingInAdvancedForm ="false"  AdvancedForm-EnableCustomAttributeEditing="false">           
            <AdvancedForm Modal="false"  />
            <Reminders Enabled="true" />
            <AppointmentTemplate>
                <div class="rsAptSubject">
                 <a  id="rrr" class="pop2"  href='addevent.aspx?id=<%# Eval("EVNTID") %>&empid=<%# Eval("EMPID") %>&zbaid=<%# Eval("ZBAID") %>'>   <%# Eval("SUBJ") %> </a>
                </div>
                <%# Eval("Description") %>
             <%--   <a  id="MinuteLk" href="#"  return false;">Minutes</a>  --%>
			 
			
		
             

            </AppointmentTemplate>


              <AdvancedEditTemplate>
       <%--<scheduler:AdvancedForm runat="server" ID="AdvancedEditForm1" Mode="Edit" Subject='<%# Bind("Subject") %>'
           Description='<%# Bind("Description") %>' Start='<%# Bind("Start") %>' End='<%# Bind("End") %>' AppointmentColor='<%# Bind("AppointmentColor") %>' EVNTVENU='<%# Bind("EVNTVENU") %>' CurrID='<%# Bind("Curr") %>'   Budget='<%# Bind("Budget") %>'  PriorityID='<%# Bind("Priority") %>'
             TeacherID='<%# Bind("Teacher") %>' ScopeID='<%# Bind("Scope") %>' StatusID='<%# Bind("Status") %>' CategoryID='<%# Bind("Category") %>' PersonID='<%# Bind("Person") %>' getlist='<%# Bind("getlist") %>' 
         />--%>

        

   </AdvancedEditTemplate>
   <AdvancedInsertTemplate>
      <%-- <scheduler:AdvancedForm runat="server" ID="AdvancedInsertForm1" Mode="Insert" Subject='<%# Bind("Subject") %>'
          Description='<%# Bind("Description") %>'  Start='<%# Bind("Start") %>' End='<%# Bind("End") %>' AppointmentColor='<%# Bind("AppointmentColor") %>' EVNTVENU='<%# Bind("EVNTVENU") %>'  CurrID='<%# Bind("Curr") %>' Budget='<%# Bind("Budget") %>' PriorityID='<%# Bind("Priority") %>' 
           TeacherID='<%# Bind("Teacher") %>'    ScopeID='<%# Bind("Scope") %>' StatusID='<%# Bind("Status") %>'   CategoryID='<%# Bind("Category") %>'   PersonID='<%# Bind("Person") %>'  getlist='<%# Bind("getlist") %>'  />--%>


   </AdvancedInsertTemplate>



              <%-- <AdvancedEditTemplate>
            <scheduler:AdvancedForm runat="server" ID="AdvancedEditForm1" Mode="Edit" Subject='<%# Bind("Subject") %>'
                Description='<%# Bind("Description") %>' 
                Start='<%# Bind("STARTACT") %>' End='<%# Bind("EndACT") %>' RecurrenceRuleText='<%# Bind("RECURRENCERULE") %>'
               UserID='<%# Bind("EMPNO") %>'
                RoomID='<%# Bind("ROOMID") %>' />
        </AdvancedEditTemplate>
        <AdvancedInsertTemplate>
        <scheduler:AdvancedForm runat="server" ID="AdvancedInsertForm1" Mode="Insert" Subject='<%# Bind("Subject") %>'
                Description='<%# Bind("Description") %>'
             RecurrenceRuleText='<%# Bind("RECURRENCERULE") %>'
               UserID='<%# Bind("EMPNO") %>'
               />

           
        </AdvancedInsertTemplate>--%>

          <MonthView VisibleAppointmentsPerDay="30" AdaptiveRowHeight="false" />
          <WeekView UserSelectable="true" />
            <TimelineView  NumberOfSlots="5" UserSelectable="true" />
            <TimeSlotContextMenuSettings EnableDefault="true" />
            <AppointmentContextMenuSettings EnableDefault="true" />
             <AgendaView UserSelectable="true" />
        </telerik:RadScheduler>
       <%-- </telerik:RadPane>

                  
                                                         
                </telerik:RadSplitter>
                 <telerik:RadButton RenderMode="Lightweight" runat="server" ID="Button2" Text="Add"  
                                                             Skin="Metro" Visible="false" />--%>

    </div>

     <asp:HiddenField ID="HFSession" runat="server" />
               <asp:HiddenField ID="HFIP" runat="server"  />
    </form>
</body>
</html>
