<%@ Page Language="VB" AutoEventWireup="false" CodeFile="addevent.aspx.vb" Inherits="addevent" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>
<meta name='viewport' content='width=device-width, initial-scale=1.0'/>
<link href="css_chklst/bootstrap-new.min.css" rel="stylesheet">
<link rel="stylesheet" type="text/css" href="css_chklst/event-stylee.css" />
 <link rel="stylesheet" type="text/css" href="css_chklst/font-awesome.min.css" />
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
                 width: screen.width*100/100,
                 height: screen.height*100/100,
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
             $('.pop4').fancybox({
                 width: 800,
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
		 

</head>
<body>
    <form id="form1" runat="server" class="add-event-ca">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <asp:ValidationSummary ID="vs" ValidationGroup="basicdetails1" ShowMessageBox="true"
        ShowSummary="false" runat="server" />

<%-- <a  id="newadd"  style=" position: absolute; float:right; right: 34px; top: 3px;  z-index: 1; height: auto;
    width: 53px;  margin: 0; font-size: 11px;
    border-radius: 2px;  padding: 2px 0 1px;" runat="server" class="pop4 btn btn-primary btn-xs"><i class="fa fa-print" aria-hidden="true"></i> Print</a>--%>

   <div class="container-fluid1">
            <div class="panel panel-default" style="margin-bottom: 2px;">
                <div class="panel-heading height-outer">
              <div class="row" style="margin: 0;">
                        <div class="col-md-12 col-sm-12 col-xs-12" style="padding:0;">
                        <div class="col-md-11 col-sm-11 col-xs-11 width-wel" style="padding:0;">
                  <span class="Add-Acivity1" id="crdcrn" runat="server"> </span></div>
                   <div class="col-md-1 col-sm-1 col-xs-1 head-padd" style="padding:0;">
               <a  id="newadd"  style=" float:right; z-index: 1; height: auto;
    width: 53px;  margin: 0; font-size: 11px;
    border-radius: 2px;  padding: 2px 0 1px;" runat="server" class="pop4 btn btn-primary btn-xs print-btn"><i class="fa fa-print" aria-hidden="true"></i> Print</a>
              </div></div>
              </div>  </div></div>
              </div>
             

<telerik:RadTabStrip ID="RadTabStrip2"  RenderMode="Lightweight"   runat="server" 
        SelectedIndex="0" MultiPageID="RadMultiPage2"
                                CssClass="tabgrid" ResolvedRenderMode="Classic" 
        Skin="Office2007">
                                <Tabs>
                                   
                                    <telerik:RadTab PageViewID="summ" Text="Event Details" Style="font: 11px/26px Arial,sans-serif !important;">
                                    </telerik:RadTab>
                      

                                    <telerik:RadTab PageViewID="pbr" Text="Tasks" 
                                        Style="font: 11px/26px Arial,sans-serif !important;" Selected="True">
                                    </telerik:RadTab>

									
									 <telerik:RadTab PageViewID="fb" Enabled="false" Text="Feedback" Style="font: 11px/26px Arial,sans-serif !important;">
                                    </telerik:RadTab>
									
									 <telerik:RadTab PageViewID="ot" Enabled="false" Text="Outcome/ROI" Style="font: 11px/26px Arial,sans-serif !important;">
                                    </telerik:RadTab>
									 <telerik:RadTab PageViewID="doc" Text="Document library" Style="font: 11px/26px Arial,sans-serif !important;">
                                    </telerik:RadTab>
                                    </Tabs>
                                    </telerik:RadTabStrip>

 <telerik:RadMultiPage ID="RadMultiPage2"  runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="summ"  Height="80px"  runat="server" Style="padding-top: 3px;">

<div class="fixed-height">
    <div class="panal-one">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                  <span class="Add-Acivity"> Step 1: Add/Edit New Event</span></div>
                <div class="panel-body edit-new-event one-part">

<div class="row" style="margin: 0;">
                        <div class="col-sm-12" style="padding:0;">
                            <div class="col-sm-6">
                                <label for="sel1" class="label-class-width" title ="Used to select Branch/Organization data">
                                    Level:  <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="ddllevl" AutoPostBack="true" runat="server">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Branch" Value="B"></asp:ListItem>
                                        <asp:ListItem Text="Organization" Value="O"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Level is required" ControlToValidate="ddllevl"
                                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-6">
                               <asp:Panel ID="g1" Enabled="false" runat="server">
                                <label for="sel1" class="label-class-width">
                                    -- <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Branch/organistaion is required"
                                        ControlToValidate="DropDownList1" ValidationGroup="basicdetails" ForeColor="Red"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="g2" Enabled="false" runat="server">
                    <div class="row" style="margin: 0;">
                        <div class="col-sm-12" style="padding:0;">
                            <div class="col-sm-6">
                                <label for="sel1" class="label-class-width" title ="Used to select Department/individual values">
                                    Scope <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Scope is required" ControlToValidate="DropDownList2"
                                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <label for="sel1" class="label-class-width">
                                   -- <span id="scpatr" runat="server" style="color:red">*</span> </label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="DropDownList3" AutoPostBack="true" class="span10" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Dept/Employees is required" ControlToValidate="DropDownList3"
                                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:Panel>
                     <asp:Panel ID="g3" Enabled="false" runat="server">
                    <div class="row" style="margin: 0;">
                        <div class="col-sm-12" style="padding:0;">
                            <div class="col-sm-3">
                                <label for="sel1" class="label-class-width Start-Date">Start Date: 
                                <span style="color:red">*</span></label>
                                <div class="input-class-width start-date">
                                 <telerik:RadDatePicker ID="dt_upload" AutoPostBack="true" class="control" runat="server" MinDate="2010-01-01"
                        DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar1" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd " DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="validationposition"
                        runat="server" ErrorMessage="Start Date is required" ControlToValidate="dt_upload"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                  <label for="sel1" class="label-class-width Start-Date">End Date: 
                                  <span style="color:red">*</span></label>
                                <div class="input-class-width start-date">

                                <telerik:RadDatePicker ID="RadDatePicker1" class="control" runat="server"
                        MinDate="2010-01-01" DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar2" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd" DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validationposition"
                        runat="server" ErrorMessage="End Date is required" ControlToValidate="RadDatePicker1"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="col-sm-3">
                                   <label for="sel1" class="label-class-width Start-Date">Event Duration<span style="color:red">*</span></label>
                                <div class="input-class-width start-date time">
                                  <asp:DropDownList ID="chkb" AutoPostBack="true" class="span10" runat="server">
                                     <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="All Day Event" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1 Hour" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="2 Hour" Value="2"></asp:ListItem>
                                          <asp:ListItem Text="3 Hour" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="4 Hour" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5 Hour" Value="5"></asp:ListItem>
                                         <asp:ListItem Text="6 Hour" Value="6"></asp:ListItem>
                                          <asp:ListItem Text="7 Hour" Value="7"></asp:ListItem>
                                           <asp:ListItem Text="8 Hour" Value="8"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Event Time Period is required" ControlToValidate="chkb"
                                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                                 </div>
                                </div>
                               <div class="col-sm-3">
                                
                                  <label for="sel1" class="label-class-width Start-Date">Start Time:<span style="color:red">*</span> <p class="small-font"> (Local Time)</p></label>
                                <div class="input-class-width start-date time">

                                <telerik:RadTimePicker ID="dtpTimeIn" runat="server" ZIndex="30001"
                        Width="75%" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator20" CssClass="validationposition"
                        runat="server" ErrorMessage="Start Time is required" ControlToValidate="dtpTimeIn"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <%--  <span class="check-btn">   <asp:CheckBox ID="chkb" AutoPostBack="true" runat="server" />  <span>All day Event</span></span>--%>
                                </div>
                                
                                 

                        </div>
                    </div>
                    </asp:Panel>
                      <asp:Panel ID="g4" Enabled="true" runat="server">
                     <div class="row" style="margin:0;">
 <div class="col-sm-12" style="padding:0;">
 <div class="col-sm-6">
  <label for="sel1" class="label-class-width" title="It defines the type of  an Event"> Category 
     <span style="color:red">*</span></label>
  <div class="input-class-width">
   <asp:DropDownList ID="DropDownList4" AutoPostBack="true" Enabled="false" CssClass="category" runat="server">
                    </asp:DropDownList> &nbsp;&nbsp;  
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Category is required" ControlToValidate="DropDownList4"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <a class="pop2" href="EventMaster.aspx"><img src="Images/add-new24x24.png" height="15" width="15" /></a>
                         &nbsp;&nbsp; <asp:ImageButton ID="refe" ImageUrl="~/Images/refresh1234.png" Width="15" Height="15"  style="margin: 7px 8px 0 0; display: block;

float: right; " CausesValidation="false" runat="server" /> 
  
   </div> 
   </div>

     <div class="col-sm-3">
  <label for="sel1" class="label-class-width" title="It is sub category">Sub Category 
      <span style="color:red">*</span></label>
  <div class="input-class-width">
                     <asp:DropDownList ID="DropDownList5" Enabled="false" class="span10" runat="server">
                    </asp:DropDownList>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Product is required" ControlToValidate="DropDownList5"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div></div>



    <div class="col-sm-3">
  <label for="sel1" class="label-class-width" title="It defines the criticality of an Event">Priority 
        <span style="color:red">*</span></label>
  <div class="input-class-width">
    <asp:DropDownList ID="DropDownList6" class="span10" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Priority is required" ControlToValidate="DropDownList6"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
  
   </div> 
   </div>




  </div>

 </div>

  <div class="row" style="margin:0;">
 <div class="col-sm-12" style="padding:0;">


  <div class="col-sm-6">
  <label for="sel1" class="label-class-width" title="One who is organizer of the Event"> Moderator/Owner 
      <span style="color:red">*</span></label>
  <div class="input-class-width">
   <asp:DropDownList ID="DropDownList9" class="span10" runat="server">
                    </asp:DropDownList>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Moderator is required" ControlToValidate="DropDownList9"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div></div>
  <div class="col-sm-6" >

 <label for="sel1" class="label-class-width">Subject 
      <span style="color:red">*</span></label>

               <div class="input-class-width"> 
			     <asp:TextBox ID="TextBox2" onkeypress="return isAdd(event);" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validationposition"
                        runat="server" ErrorMessage="Subject is required" ControlToValidate="TextBox2"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
			   </div>

 </div>


  </div>

 </div>


 <div class="row" style="margin:0 !important;">
  <div class="col-sm-12 full-width">
  <label for="sel1" class="label-class-width full-con">Description 
      <span style="color:red">*</span></label>
  <div class="input-class-width">
   <asp:TextBox ID="TextBox3"  TextMode="MultiLine" onkeypress="return isAdd(event);"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validationposition"
                        runat="server" ErrorMessage="Description is required" ControlToValidate="TextBox3" ValidationGroup="basicdetails"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
  
  </div>
  </div></div>

  </asp:Panel>

   <div class="row" style="margin:5px 0 0 0;">
  <div class="col-sm-12" style="padding:0;">

<asp:Button ID="ImageButton1"  OnClientClick="if(Page_ClientValidate('basicdetails')) ShowProgress();"
                        runat="server" Height="22" Width="60" CssClass="btn btn-primary all_btn"  style="margin: 0px 16px 0 0;" Text="Save" ToolTip="Save" />  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
</div></div>



</div>
            </div>
        </div>
    </div>
    
    
    <asp:Panel ID="pnleedt" Enabled="false" runat="server" Visible="True">

     <div class="row" style="margin:0 !important;">
  <div class="col-sm-12" style="padding:0;">
  <div class="col-sm-6">
     <div class="panal-one">
        
            <div class="panel panel-default">
                <div class="panel-heading">
                  <span class="Add-Acivity" style="width:100%"> Step 2: Approval section</span></div>
                <div class="panel-body aprovesection">
                 <div class="row" style="margin:0 !important;">
  <div class="col-sm-12 col-xs-12 full-width" style="padding:0;">
                <p class="imp-note">Note:Step 2 will only be accessible if  Step 1 is completed.</p>
                </div></div>
                <div class="row" style="margin:0 !important;">
  <div class="col-sm-12 full-width" style="padding:0;">

  <div class="col-sm-11 full-width" style="padding:0;">
               <div class="input-class-width full-con radio-button">
                   <asp:RadioButtonList ID="RadioButtonList1"  runat="server" AutoPostBack="True" 
                       RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="0" 
                       CellSpacing="0" Width="100%">
                       <asp:ListItem Value="E">Yes, I have approval for this event.</asp:ListItem>
                       <asp:ListItem Value="N">No, I do not have approval for this event.</asp:ListItem>
                   </asp:RadioButtonList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" CssClass="validationposition"
                        runat="server" ErrorMessage="Approval is required" ControlToValidate="RadioButtonList1"
                        ValidationGroup="basicdetails3" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
			   </div>

 
 </div>
  <div class="col-sm-1" style="padding:0;">
    <asp:Button ID="Button2"  OnClientClick="if(Page_ClientValidate('basicdetails3')) ShowProgress();"
                        runat="server" Height="22"  CssClass="btn btn-primary all_btn"  style="float: right; padding: 5px 8px !important; width:auto !important; font-size: 11px;
    border-radius: 2px; margin: 0px 0px 0 0;" Text="Confirm" ToolTip="Save" />
 </div>
 
 </div> </div>

 <asp:Panel ID="pnl" Visible="false" runat="server">
    <div class="row" style="margin:0 !important;">
    
     <div class="col-sm-10 full-width" style="padding:0;">

             <label for="sel1" class="label-class-width full-con">Email 
             <span style="color:red">*</span></label>
<div class="input-class-width">
<asp:TextBox ID="TextBox5" style="width:40%" TextMode="SingleLine" onkeypress="return Alphanumwithspcl(event);" runat="server"></asp:TextBox> @ 
      <asp:DropDownList  style="width:50%"  ID="DropDownList12" class="span10" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>wwicsgroup.com</asp:ListItem>
                    <asp:ListItem>immigrationwwics.com</asp:ListItem>
                    <asp:ListItem>immigrationwwics.in</asp:ListItem>
                    <asp:ListItem>pinnacleinfoedge.com</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" CssClass="validationposition"
                        runat="server" ErrorMessage="Email Address is required" ControlToValidate="TextBox5" ValidationGroup="basicdetails3"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Domain Name is Required" ControlToValidate="DropDownList12" ValidationGroup="basicdetails3"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

</div>
</div>
<div class="col-sm-2" style="padding:0;">
</div>
</div>
</asp:Panel>
</div>
</div>             
</div>
  </div>
    <div class="col-sm-6">
     <div class="panal-one">
       
            <div class="panel panel-default">
                <div class="panel-heading">
                  <span class="Add-Acivity" style="width:100%"> Step 3: Approval Document</span></div>
                <div class="panel-body aprovesection" style="padding: 5px 10px 10px 10px !important;">
                <div class="row" style="margin:0 !important;">
  <div class="col-sm-12 col-xs-12 full-width" style="padding:0;">
                <p class="imp-note">Note:Step 3 will only be accessible if  Step 2 is completed.</p>
                </div></div>
                  <div class="row" style="margin:0 !important;">
    
     <div class="col-sm-10 full-width" style="padding:0;">

             <label for="sel1" class="label-class-width full-con-upload">Upload Approval <span style="color:red">*</span></label>
  <div class="input-class-width-upload">
<asp:FileUpload ID="fupl" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validationposition"
                        runat="server" ErrorMessage="Approval Document is required" ControlToValidate="fupl" ValidationGroup="basicdetails4"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
  
  </div>

 </div>
<div class="col-sm-2 col-xs-12 mer-top" style="padding:0;">
<asp:Button ID="Button3"  OnClientClick="if(Page_ClientValidate('basicdetails4')) ShowProgress();" runat="server" Height="22" Width="60" CssClass="btn btn-primary all_btn"  style="
border-radius: 2px; margin: 0px 9px 0 0;" Text="Upload" ToolTip="Save" />

</div>
</div>
<div class="row" style="margin:0;">
<div class="col-sm-12" style="padding:0;">
<div id="docview" runat="server">
</div>
</div>
</div>
</div>
</div>
</div>
</div>



  </div>
  </div>




  </asp:Panel>

  </div>
  <div class="panel-footer pan-foot">
   <asp:Panel ID="pnlmst" Enabled="false" runat="server" Visible="True">
   <div class="row" style="margin:0 !important;">
    <div class="col-sm-2 col-xs-12">
  <label for="sel1" class="label-class-width stats-margin"> Status 
        <span style="color:red">*</span></label>
  <div class="input-class-width">
   <asp:DropDownList ID="DropDownList8" AutoPostBack="true" class="span10" runat="server">
                    </asp:DropDownList>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Status is required" ControlToValidate="DropDownList8"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
 </div>
 </div>
   <div class="col-xs-12 col-sm-6 padd-cal">
 <asp:Panel ID="pnlprepone" Enabled="false" runat="server">
  <div class="row" style="margin:0 !important;">
  <div class="col-sm-4 col-xs-12">

  
  <label for="sel1" class="label-class-width full-con stats-margin">Start Date <span style="color:red">*</span></label>
  <div class="input-class-width">
    <telerik:RadDatePicker ID="RadDatePicker3" AutoPostBack="true" class="control" runat="server"
                        MinDate="2010-01-01" DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar4" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd" DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" CssClass="validationposition"
                        runat="server" ErrorMessage="Start Date is required" ControlToValidate="RadDatePicker3"
                        ValidationGroup="basicdetails6" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

  </div>
  

  </div>
    <div class="col-sm-4 col-xs-12">

  
  <label for="sel1" class="label-class-width full-con stats-margin">End Date <span style="color:red">*</span></label>
  <div class="input-class-width">
    <telerik:RadDatePicker ID="RadDatePicker4" class="control" runat="server"
                        MinDate="2010-01-01" DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar5" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd" DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" CssClass="validationposition"
                        runat="server" ErrorMessage="End Date is required" ControlToValidate="RadDatePicker4"
                        ValidationGroup="basicdetails6" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

  </div>
  

  </div>
    
     <div class="col-sm-4 col-xs-12">
                                  <label for="sel1" class="label-class-width Start-Date">Start Time: (Local Time)<span style="color:red">*</span></label>
                                <div class="input-class-width start-date">

                                <telerik:RadTimePicker ID="RadTimePicker1" runat="server" ZIndex="30001"
                        Width="75%" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator31" CssClass="validationposition"
                        runat="server" ErrorMessage="Start Time is required" ControlToValidate="RadTimePicker1"
                        ValidationGroup="basicdetails6" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                </div>

    </div>
    </asp:Panel>
  
  </div>
   <div class="col-sm-3">

    <asp:Panel ID="pnlcnc" Enabled="false" runat="server">

     <label for="sel1" class="label-class-width stats-margin">Reason 
        <span style="color:red">*</span></label>

               <div class="input-class-width"> 
			     <asp:TextBox ID="TextBox6" onkeypress="return isAdd(event);" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" CssClass="validationposition"
                        runat="server" ErrorMessage="Reason is required" ControlToValidate="TextBox6"
                        ValidationGroup="basicdetails6" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
			   </div>


    </asp:Panel>

   

  </div>
   <div class="col-sm-1 col-xs-12 mer-top" style="margin-bottom:5px !important; ">

   
   <asp:Button ID="Button4"  OnClientClick="if(Page_ClientValidate('basicdetails6')) ShowProgress();"
                        runat="server" Height="22" Width="57" CssClass="btn btn-primary all_btn"  style="
    border-radius: 2px; margin: 0px 16px 0 0;" Text="Update" ToolTip="Save" />
   </div>



 </div>
 </asp:Panel>
 </div>
    </telerik:RadPageView>
                              <telerik:RadPageView ID="pbr"  Height="400px"  runat="server" Style="padding-top: 3px;">

                                  <div class="panal-one">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading" style="float:left;width:100%">
                 <span class="Add-Acivity">Add/Edit New Tasks</span>
                 <asp:LinkButton ID="addact" Height="22" Width="57" CssClass="btn btn-primary all_btn top-one"  style="
    margin: 0px 7px 0 0;"  runat="server"><i class="fa fa-plus"></i></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" Visible="false" Height="22" Width="57" CssClass="btn btn-primary all_btn"  style="
    border-radius: 2px; margin: 0px 3px 0 0;"  runat="server"><i class="fa fa-repeat" aria-hidden="true"></i>
 Refresh</asp:LinkButton> &nbsp; &nbsp;
                  </div>
               
                <div class="panel-body">

                
               

                <asp:Panel ID="adnew" Visible="false" runat="server">
                
 <div class="row" style="margin:0 !important;">

  <div class="col-sm-12" style="padding:0 !important;">

   <div class="col-sm-3">
  <label for="sel1" class="label-class-width">Type 
       <span style="color:red">*</span></label>
   <div class="input-class-width">
    <asp:DropDownList ID="DropDownList10" class="span10" runat="server">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp; 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Activity Type is required" ControlToValidate="DropDownList10"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
     

   </div></div>


      <div class="col-sm-3">
  <label for="sel1" class="label-class-width">Assigned To 
          <span style="color:red">*</span></label>
   <div class="input-class-width">
    <asp:DropDownList ID="DropDownList11" AutoPostBack="true" class="span10" runat="server">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp; 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Assigned To is required" ControlToValidate="DropDownList11"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        
   </div></div>


       <div class="col-sm-3">
  <label for="sel1" class="label-class-width">Agency Name 
           <span id="agatr" runat="server" style="color:red">*</span></label>
   <div class="input-class-width">
    <asp:TextBox ID="TextBox42" class="span10" runat="server">
                    </asp:TextBox>
                    &nbsp; &nbsp; &nbsp; &nbsp; 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" CssClass="validationposition"
                        runat="server"  ErrorMessage="Agency Name is required" ControlToValidate="TextBox42"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        
   </div></div>
  
   

  <div class="col-sm-3">

   <label for="sel1" class="label-class-width">Approval Document: 
      <span id="appdoc" runat="server" style="color:red">*</span></label>
    <div class="input-class-width-upload">
<asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" CssClass="validationposition"
                        runat="server" ErrorMessage="Approval Documnet is required" ControlToValidate="FileUpload1" ValidationGroup="basicdetails1"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
  
  </div>


</div>
  </div></div>

 <div class="row" style="margin:0 !important;">
 <div class="col-sm-12" style="padding:0 !important;">
 <div class="col-sm-3 col-xs-12">
  <label for="sel1" class="label-class-width">Budget 
     <span style="color:red">*</span></label>
   <div class="input-class-width">
    <asp:DropDownList ID="DropDownList7" style="width:57%" runat="server">
                    </asp:DropDownList>-<asp:TextBox ID="TextBox1"  onkeypress="return isNumberKey(event);" MaxLength="5" style="width:40%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Currency is required" ControlToValidate="DropDownList7"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="validationposition"
                        runat="server" ErrorMessage="Amount is required" ControlToValidate="TextBox1"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


   </div></div>


    <div class="col-xs-12 col-sm-3 time-event">
                                <label for="sel1" class="label-class-width">Date: 
                                <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                 <telerik:RadDatePicker ID="RadDatePicker2" class="control" runat="server" 
                        DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar3" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd" DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="validationposition"
                        runat="server" ErrorMessage="Activity Date is required" ControlToValidate="RadDatePicker2"
                        ValidationGroup="basicdetails1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>



   <%-- <div class="col-sm-4">
  <label for="sel1" class="label-class-width">Alerts</label>
   <div class="input-class-width">

   <div class="col-sm-12">
    <div class="col-sm-1">
     <asp:CheckBox ID="chkbox" AutoPostBack="true" style="margin:0px !important"  Text="" runat="server" />
   </div>
     <div class="col-sm-11" style="width:90%; margin-left:-35px">
      <asp:TextBox ID="TextBox5"  placeholder="Email Address" onkeypress="" runat="server"></asp:TextBox>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22"  CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Email Address is required" ControlToValidate="TextBox5"
                        ValidationGroup="basicdetails2" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
   </div>

    </div>
   
                  
                   
                        
   </div></div>--%>
   <div class="col-xs-12 col-sm-6">
     <label for="sel1" class="label-class-width-action">Action 
       <span style="color:red">*</span></label>
   <div class="input-class-width-action">
<asp:TextBox ID="TextBox4"  TextMode="MultiLine" onkeypress="return isAdd(event);"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" CssClass="validationposition"
                        runat="server" ErrorMessage="Comments are required" ControlToValidate="TextBox4" ValidationGroup="basicdetails1"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
   </div>



     </div>
     
    </div>

     
    </div>
       <div class="row" style="margin: 5px 0 0 0 !important;">
      <div class="col-xs-12 col-sm-12 save-btn mar-top">
     <asp:Button ID="Button1" OnClientClick="if(Page_ClientValidate('basicdetails1')) ShowProgress();"
                        runat="server" Height="22" Width="57" CssClass="btn btn-primary all_btn"  style="
    border-radius: 2px; margin: 0;"  Text="Save" ToolTip="Save" />

     </div>  </div>

                </asp:Panel>
         <br />
<div class="panel-body next-block">
 <div class="row" style="margin:0 !important;">
 <div class="col-sm-12 col-xs-12" style="padding:0 !important;">
 <div class="col-sm-10 col-xs-12"  style="padding:0 !important;">
 
 <label for="sel1" class="label-class-width Advance">Advance Filter:</label>

 <div class="input-class-width Advance1">
   <asp:DropDownList ID="DropDownList13" AutoPostBack="true" runat="server">
                                        <asp:ListItem Text="Select Filter" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Show All" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="My Activity" Value="M"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Select Filter is required" ControlToValidate="DropDownList13"
                                        ValidationGroup="basicdetails10" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


 </div></div>
   <div class="col-sm-2 col-xs-12 new-padd">

   <asp:LinkButton ID="LinkButton2"  OnClientClick="if(Page_ClientValidate('basicdetails10')) ShowProgress();" Height="23" Width="60" CssClass="btn btn-primary all_btn"  style="
    border-radius: 2px; margin: 0 !important;"  runat="server"><i class="fa fa-repeat" aria-hidden="true"></i>
 Refresh</asp:LinkButton> &nbsp; &nbsp;  

 </div>
 </div>
 </div>
 </div>

                  <telerik:RadGrid ID="RadGrid2" Height="400px" EnableViewState="true"   Skin="Metro" PageSize="25"   CSSClass="table table-bordered" 
            AllowPaging="True"  CellSpacing="0" GridLines="none"  
             AllowSorting="True" ShowHeader="true"     AllowFilteringByColumn="False"  runat="server" >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView  DataKeyNames="transid,evntid,ACTSTS,APPFILESTS,appdoc,ACTASGNTO" NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div class="no-record">No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                    
                    
                </CommandItemTemplate>
               <ColumnGroups>
                            <telerik:GridColumnGroup Name="GeneralInformation" HeaderText="General Information"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="SpecificInformation" HeaderText="Specific Information"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Booking Information"
                                HeaderStyle-HorizontalAlign="Center" />
                        </ColumnGroups>
                    
         

         <Columns>
           <telerik:GridTemplateColumn  UniqueName="" HeaderText="" 
                            ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="15px" ItemStyle-Width="15px">
                            <HeaderTemplate>
                           
                            </HeaderTemplate>
                            <ItemTemplate>                            
                          <asp:ImageButton ID="btnico"   runat="server"  Width="10" Height="10"  border="0" />&nbsp;     
                          </ItemTemplate>
                  </telerik:GridTemplateColumn>


              


           <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="icon2" HeaderStyle-Width="80" ItemStyle-Width="80" HeaderText="">
                                <ItemTemplate >             
                                <a id="act" runat="server" title="Add activity remarks">Action</a>           
                                                
                            </ItemTemplate>
                            </telerik:GridTemplateColumn>
         

           <telerik:GridTemplateColumn   UniqueName="acto" HeaderText="Assigned To" 
                            ItemStyle-Wrap="false" ItemStyle-Width="120px" HeaderStyle-Width="120px" AllowFiltering="true" >
                         
                            <ItemTemplate>                            
                        <asp:LinkButton ID="lnkchng" CommandName="edit" runat="server" Text='<%# Eval("AsignedTo")%>'></asp:LinkButton>
                          </ItemTemplate>
                          

                  </telerik:GridTemplateColumn>




            <telerik:GridTemplateColumn HeaderStyle-Width="100px"  ItemStyle-Width="100px" SortExpression="REMARKS" HeaderText="Remarks" UniqueName="remLaw" >
                                        <ItemTemplate>
                                        <img id="lblremLaw" width="22" src="images/complaint-thread32x32.png" runat="server" />
                                     &nbsp;&nbsp;

                                     <asp:ImageButton ID="dwnldlnk" ToolTip="Download" runat="server" Width="22" CommandArgument='<%#eval("appdoc") %>' ImageUrl="images/download3.jpg"  Height="22" CommandName="dwnldresume" />
                                    
                                      &nbsp;&nbsp;
                                          <a id="upld" runat="server"> <img src="images/upload-pending_2_32x32.png" Width="22" title="Upload"  /> </a>           
                                    
                                       <telerik:RadToolTipManager ID="RadToolTipManager5" runat="server" Position="BottomCenter"
                Animation="Fade" Text='<%#Eval("ACTCMNTS") %>'   AutoCloseDelay="60000" Title="Remarks Description"   RelativeTo="Element" Width="320px" Height="150px" RenderInPageRoot="true">
            </telerik:RadToolTipManager>
                                       </ItemTemplate>
                             
                                    </telerik:GridTemplateColumn>



         </Columns>


          <EditFormSettings EditFormType="Template" >
                    <FormTemplate>
                        <table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="0" rules="none"
                            style="border-collapse: collapse;" runat="server" >
                            <tr class="EditFormHeader font">
                            <td>
                            <div class="Acti_vity">
                            <label for="sel1" class="label-class-width-assign"> Activity Assigned To:
       <span style="color:red">*</span></label>
                           <div class="input-class-width-assign"> <telerik:RadComboBox ID="searchproduct"  DropDownAutoWidth="Enabled"  runat="server" AutoPostBack="false" Width="100%" EnableLoadOnDemand="true">
        </telerik:RadComboBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator117" CssClass="validationposition"
                        runat="server" ErrorMessage="Activity Assigned To required" ControlToValidate="searchproduct"
                        ValidationGroup="basicdetails50" InitialValue="" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> </div>
                        </div>    </td>
                                <td> 

                                          
                                  
                                </td>
                            </tr>
                           
                           <tr>
                           <td colspan="2">
                          <div class="add-btn-can">
                          <asp:LinkButton ID="cancel" CssClass="btn btn-primary btn-xs all_btn" CommandName="cancel" style="color:#fff; line-height: 10px !important;" runat="server" Text="Cancel"></asp:LinkButton>
                           <asp:LinkButton ID="update" OnClientClick="if(Page_ClientValidate('basicdetails50')) ShowProgress();" CssClass="btn btn-primary btn-xs all_btn" style="color:#fff;margin: 0px 4px 0px 0px; line-height: 10px !important;" CommandName="update" runat="server" Text="Update"></asp:LinkButton> 
                            
                                 <asp:HiddenField ID="hfevnt" runat="server" Value='<%#Eval("evntid") %>' />
                            <asp:HiddenField ID="fhtrns" runat="server" Value='<%#Eval("transid") %>' />

                            </div>
                           </td>
                           </tr>

                        </table>
                       
                  
                    </FormTemplate>
                </EditFormSettings> 

                      <PagerStyle AlwaysVisible="true"  PageSizeControlType="RadComboBox"  Mode="NextPrevAndNumeric" PageSizeLabelText="Display Rows: " PageSizes="5,10,25,50,100,250,500,1000,1500,2000" ></PagerStyle>
                
                   </MasterTableView>
                  
                  <ItemStyle Width="120px" Wrap="false" CssClass="font"/> 
                  <AlternatingItemStyle  Width="120px" Wrap="false" CssClass="font"/>
                 <HeaderStyle  Width="120px" Font-Size="12px" Font-Names="Arial"  Font-Bold="true"  />
                      <clientsettings  allowkeyboardnavigation="True" EnablePostBackOnRowClick="false" reordercolumnsonclient="False">
                                                            <Selecting  AllowRowSelect="True" />
                                                            <Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" ClipCellContentOnResize="True"
                                                                EnableRealTimeResize="True" AllowResizeToFit="true" />
                                                            <Scrolling AllowScroll="true" UseStaticHeaders="True" SaveScrollPosition="True" />
                                                        </clientsettings>
            </telerik:RadGrid>




                </div>
                </div>

                </div>

                </div>






                              </telerik:RadPageView>
							  
							  
							   <telerik:RadPageView ID="fb"  Height="400px"  runat="server" Style="padding-top: 3px;">


                               
<div class="fixed-height">
    <div class="panal-one">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                  <span class="Add-Acivity"> Feedback </span></div>
                <div class="panel-body edit-new-event feedback">


                 <div class="row" style="margin-bottom: 10px !important; padding: 0 15px 0 15px !important;">
  <div class="col-sm-12 full-width fed-back">
  <label for="sel1" class="label-class-width full-con">Feedback 
      <span style="color:red">*</span></label>
  <div class="input-class-width">
   <asp:TextBox ID="TextBox8"  TextMode="MultiLine" CssClass=" Description-box" onkeypress="return isAdd(event);"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" CssClass="validationposition"
                        runat="server" ErrorMessage="Description is required" ControlToValidate="TextBox8" ValidationGroup="basicdetails55"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
  
  </div>
  </div>
  </div>   </div>
   

<div class="row" style="margin: 0;">
                        <div class="col-xs-12 col-sm-12 satis-1" >
                           
                                <label for="sel1" class="label-class-width full-con" title ="">
                                  Please mention, being a  moderator, how  satisified you are from this overall event and its outcome:  <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="DropDownList14" AutoPostBack="false" runat="server">
                                     
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Satisfaction Level is required" ControlToValidate="DropDownList14"
                                        ValidationGroup="basicdetails55" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            
                           
                            

                        </div>
                    </div>
<div class="panel-body edit-new-event feedback-one">
<div class="row" style="margin: 0;">
                        <div class="col-sm-12 satis" style="padding:0;">
                            <div class="col-xs-12 col-sm-6">
                             <label for="sel1" class="label-class-width" title ="">
                                   Would you be interetsed in repeating this event in future for yourself:  <span style="color:red">*</span></label>
                                <div class="input-class-width">
                                    <asp:DropDownList ID="DropDownList15" AutoPostBack="true" runat="server">
                                     
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Reccurance is required" ControlToValidate="DropDownList15"
                                        ValidationGroup="basicdetails55" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6"><label for="sel1" class="label-class-width">Since you have opted for Repeat hence please define from what date you would like to repeat this event: 
                                <span id="recdat" runat="server" style="color:red">*</span></label>
                                <div class="input-class-width">
                                 <telerik:RadDatePicker ID="RadDatePicker5" class="control" runat="server" 
                        DateInput-DateFormat="dd-MMM-yyyy" Culture="en-US" ResolvedRenderMode="Classic">
                        <Calendar ID="Calendar6" runat="server">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday">
                                    <ItemStyle CssClass="rcToday"></ItemStyle>
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <DateInput DisplayDateFormat="dd-MMM-yyyy, dddd" DateFormat="dd-MMM-yyyy" LabelWidth="40%">
                            <%--<DateInput DisplayDateFormat="dd-MMM-yyyy hh:mm:ss" DateFormat="dd-MMM-yyyy hh:mm:ss" LabelWidth="40%">--%>
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" CssClass="validationposition"
                        runat="server" ErrorMessage="Reccurance Date is required" ControlToValidate="RadDatePicker5"
                        ValidationGroup="basicdetails55" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div></div>
                            </div></div>
                            
                            </div> 
                         

   <div class="row" style="margin:5px 0 0 0;">
  <div class="col-sm-12" style="padding:0;">

<asp:Button ID="Button5"  OnClientClick="if(Page_ClientValidate('basicdetails55')) ShowProgress();"
                        runat="server" Height="22" Width="60" CssClass="btn btn-primary all_btn"  style="margin: 0px 16px 0 0;" Text="Save" ToolTip="Save" />  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
</div></div>



</div>
            </div>
        </div>
    </div>
    
    
  

  </div>
  
                              </telerik:RadPageView>
							  
							   <telerik:RadPageView ID="ot"  Height="200px"  runat="server" Style="padding-top: 3px;">

                              </telerik:RadPageView>
							     <telerik:RadPageView ID="doc"  Height="200px"  runat="server" Style="padding-top: 3px;">

<div class="panal-one">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading" style="float:left;width:100%">
                 <span class="Add-Acivity">Document Library</span>
              
                  </div>
          
                <div class="panel-body">
     <br>
         
<div class="panel-body next-block">
 <div class="row" style="margin:0 !important;">
 <div class="col-sm-12 col-xs-12" style="padding:0 !important;">
 <div class="col-sm-8 col-xs-12" style="padding:0 !important;">
 
 <label for="sel1" class="label-class-width Advance">Advance Filter:</label>

 <div class="input-class-width Advance1">
   <asp:DropDownList ID="DropDownList17" AutoPostBack="true" runat="server">
                                        <asp:ListItem Text="Select Filter" Value=""></asp:ListItem>
                                     <%--   <asp:ListItem Text="Show All" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="My Activity" Value="M"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" CssClass="validationposition"
                                        runat="server" InitialValue="" ErrorMessage="Select Filter is required" ControlToValidate="DropDownList13"
                                        ValidationGroup="basicdetails12" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


 </div></div>
   <div class="col-sm-4 col-xs-12 new-padd">

   <asp:LinkButton ID="LinkButton5"  OnClientClick="if(Page_ClientValidate('basicdetails1333')) ShowProgress();" Height="23" Width="60" CssClass="btn btn-primary all_btn"  style="
    border-radius: 2px; margin: 0px 0px 0 3px;"  runat="server"><i class="fa fa-repeat" aria-hidden="true"></i>
 Refresh</asp:LinkButton> &nbsp; &nbsp; 
 
   <a id="nwdoc" runat="server" Class="pop4 btn btn-primary all_btn top-one" style=""  runat="server" >
       <i class="fa fa-plus" aria-hidden="true" ></i></a> &nbsp; &nbsp; &nbsp;
  

 </div>
 </div>
 </div>
 </div>
  <div class="row" style="margin:0 !important;">
 <div class="col-sm-12" style="padding:0 !important;">
<telerik:RadGrid ID="RadGrid1" Height="400px"  EnableViewState="true"   Skin="Metro" PageSize="25"   CSSClass="table table-bordered" 
            AllowPaging="True" CellSpacing="0" GridLines="none"  
             AllowSorting="True" ShowHeader="true"     AllowFilteringByColumn="False"  runat="server" >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView DataKeyNames="DOCID,EVNTID ,ACTID,RMKSID,FBID,OCID,DOCSTATUS,TRANSID,DOCPTH" NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div class="no-record">No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                    
                    
                </CommandItemTemplate>
               <ColumnGroups>
                            <telerik:GridColumnGroup Name="GeneralInformation" HeaderText="General Information"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="SpecificInformation" HeaderText="Specific Information"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Booking Information"
                                HeaderStyle-HorizontalAlign="Center" />
                        </ColumnGroups>
                    
         

         <Columns>
           <telerik:GridTemplateColumn  UniqueName="" HeaderText="" 
                            ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="15px" ItemStyle-Width="15px">
                            <HeaderTemplate>
                           
                            </HeaderTemplate>
                            <ItemTemplate>                            
                          <asp:ImageButton ID="btnico"   runat="server"  Width="10" Height="10"  border="0" />&nbsp;     
                          </ItemTemplate>
                  </telerik:GridTemplateColumn>



                

       


            <telerik:GridTemplateColumn HeaderStyle-Width="100px"  ItemStyle-Width="100px" SortExpression="DOCRMKS" HeaderText="Remarks" UniqueName="remLaw" >
                                        <ItemTemplate>
                                        <img id="lblremLaw" width="22" src="images/complaint-thread32x32.png" runat="server" />
                                     &nbsp;&nbsp;&nbsp;
                                       <asp:ImageButton ID="dwnldlnk"  Width="22" runat="server" CommandArgument='<%#Eval("DOCPTH") %>' ImageUrl="images/download3.jpg"  Height="22" CommandName="dwnldresume" />
                                    

                                       <telerik:RadToolTipManager ID="RadToolTipManager5" runat="server" Position="BottomCenter"
                Animation="Fade" Text='<%#Eval("DOCRMKS") %>'   AutoCloseDelay="60000" Title="Remarks Description"   RelativeTo="Element" Width="320px" Height="150px" RenderInPageRoot="true">
            </telerik:RadToolTipManager>
                                       </ItemTemplate>
                             
                                    </telerik:GridTemplateColumn>



         </Columns>

                      <PagerStyle AlwaysVisible="true"  PageSizeControlType="RadComboBox"  Mode="NextPrevAndNumeric" PageSizeLabelText="Display Rows: " PageSizes="5,10,25,50,100,250,500,1000,1500,2000" ></PagerStyle>
                
                   </MasterTableView>
                  
                  <ItemStyle Width="120px" Wrap="false" CssClass="font"/> 
                  <AlternatingItemStyle  Width="120px" Wrap="false" CssClass="font"/>
                 <HeaderStyle  Width="120px" Font-Size="12px" Font-Names="Arial"  Font-Bold="true"  />
                      <clientsettings allowkeyboardnavigation="True" EnablePostBackOnRowClick="false" reordercolumnsonclient="False">
                                                            <Selecting AllowRowSelect="True" />
                                                            <Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" ClipCellContentOnResize="True"
                                                                EnableRealTimeResize="True" AllowResizeToFit="true" />
                                                            <Scrolling AllowScroll="true" UseStaticHeaders="True" SaveScrollPosition="True" />
                                                        </clientsettings>
            </telerik:RadGrid>

</div> </div>


                </div>
                </div>

                </div>

                </div>






                              </telerik:RadPageView>

   </telerik:RadMultiPage>
    
    
    
    
    </form>
    <script type="text/jscript">
        function NumberChar(e) {
            var ctrlDown = e.ctrlKey || e.metaKey
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k >= 48 && k <= 57) || (ctrlDown && k == 67) || (ctrlDown && k == 99) || (ctrlDown && k == 86) || k == 8 || (ctrlDown && k == 118));
        }

        function RestrictSpace(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 65 || charcode > 90) && (charcode < 97 || charcode > 123)) {
                return false;
            }
        }
        function Alphanum(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 65 || charcode > 90) && (charcode < 97 || charcode > 123) && (charcode < 48 || charcode > 58)) {
                return false;
            }
        }
        function Alphanumwithspcl(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 65 || charcode > 90) && (charcode < 97 || charcode > 123) && (charcode < 48 || charcode > 58) &&  (charcode < 45 || charcode > 46)) {
                return false;
            }
        }
        function Email(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 64 || charcode > 90) && (charcode < 97 || charcode > 123) && (charcode < 48 || charcode > 58) && (charcode < 45 || charcode > 47) && charcode != 95) {
                return false;
            }
        }
        function RestrictSpace1(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 32 && (charcode < 65 || charcode > 90) && (charcode < 97 || charcode > 123)) {
                return false;
            }
        }
        function isNumberKey(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                return false;
            }

            return true;
        }
        function isProfile(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 65 || charcode > 90) && (charcode < 97 || charcode > 123) && (charcode < 46 || charcode > 57)) {
                return false;
            }

            return true;
        }
        function isAdd(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 32 && charcode > 8 && (charcode < 65 || charcode > 95) && (charcode < 97 || charcode > 126) && (charcode < 40 || charcode > 57) && (charcode < 35 || charcode > 38)) {
                return false;
            }

            return true;
        }
        function isLandLine(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 48 || charcode > 57) && charcode != 45) {
                return false;
            }

            return true;
        }
        function isMobile(evt) {
            var charcode = (evt.which) ? evt.which : evt.keycode;
            if (charcode > 31 && (charcode < 48 || charcode > 57) && charcode != 43) {
                return false;
            }

            return true;
        }
        function validateEmail(email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }     
    </script>
</body>
</html>
