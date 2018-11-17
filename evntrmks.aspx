<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="evntrmks.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
<title>AMS-Panel</title>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="css_chklst/bootstrap-new.min.css" rel="stylesheet">
<link rel="stylesheet" type="text/css" href="css/font-awsome.css"/>
<link rel="stylesheet" type="text/css" href="css_chklst/event-stylee.css" />

    <script type="text/javascript">
        function RedirectToLogin() {
            alert('Session Expired. You will be redirected to Login'); window.parent.location.href = 'logout.aspx';
        }
        function RedirectToLoginFromPopUp() {
            alert('Session Expired. You will be redirected to Login'); window.parent.parent.parent.location.href = 'logout.aspx';
        }
</script>

    <script type="text/javascript">

        function ShowProgress() {
            var loadingdiv = document.getElementById("loading");
            loadingdiv.style.visibility = 'visible';

        }

        function HideProgress() {
            var loadingdiv = document.getElementById("loading");
            loadingdiv.style.visibility = 'hidden';
        }


</script>

</head>
<body onload="HideProgress();">
<div id="loading">
        <div id="loadingimage" style="color:white; font-size: 17px; line-height: 55px; font-family: verdana;
            text-align: center;">
            <img src="Images/loading1.gif" width="20px" height="20px" />
        </div>
    </div>
<div class="panal-one event-remarks">
        <div class="container-fluid">
            <div class="panel panel-default">
               

      <form  runat="server" method="post" class="form-horizontal" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
     <asp:ValidationSummary ID="vs" ValidationGroup="basicdetails1" ShowMessageBox="true" ShowSummary="false" runat="server" />
    
  <div class="row-fluid" style="display:none;">
    <div class="span12">
<span id="error" style="color: Red; display: none"> ~ ` ! ^ & ( ) _ { } [ ] | \ : ; " < > ? Special Characters not allowed</span>
</div></div>
    
    
  

<div class="row">
  <div class="col-sm-12 a_rem">
    
       
          <div class="panel-heading">
                  <span class="Add-Acivity">My Activity Remarks</span> </div>

  



       <div class="panel-body">
      
 

                  <telerik:RadGrid ID="RadGrid2" Height="300px" style="margin: 5px 0 0 5px; width:95% !important;" EnableViewState="true"   Skin="Metro" PageSize="25"   CSSClass="table table-bordered" 
            AllowPaging="True" CellSpacing="0" GridLines="none"  
             AllowSorting="True" ShowHeader="true"     AllowFilteringByColumn="False"  runat="server" >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView DataKeyNames="transid,evntid,ACTID,RMKSSTS,APPFILESTS,appdoc" NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
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
                          <asp:ImageButton ID="btnico"   runat="server"  Width="10" border="0" />&nbsp;&nbsp;     
                          </ItemTemplate>
                  </telerik:GridTemplateColumn>

               <telerik:GridTemplateColumn HeaderStyle-Width="100px"  ItemStyle-Width="100px" SortExpression="REMARKS" HeaderText="REMARKS" UniqueName="remLaw" >
                                        <ItemTemplate>
                                        <img id="lblremLaw" width="22" src="images/complaint-thread32x32.png" runat="server" />
                                        &nbsp;&nbsp;

                                     <asp:ImageButton ID="dwnldlnk" runat="server" Width="22" CommandArgument='<%#eval("appdoc") %>' ImageUrl="images/download3.jpg"  Height="22" CommandName="dwnldresume" />
                                    
                                       &nbsp;&nbsp;
                                          <a id="upld" runat="server"> <img src="images/upload-pending_2_32x32.png" Width="22"  /> </a>  

                                       <telerik:RadToolTipManager ID="RadToolTipManager5" runat="server" Position="BottomCenter"
                Animation="Fade" Text='<%#Eval("RMKS") %>'   AutoCloseDelay="60000" Title="Remarks Description"   RelativeTo="Element" Width="320px" Height="150px" RenderInPageRoot="true">
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

              
  
       
        </div>

        
 
      </div>
      </div>
     
   <div class="panel-footer"> 
     

     
		   <div class="row">
  <div class="col-sm-12">
		   <label class="control-label-width" style="width: 100px;">Remarks  <span style="color:Red;">*</span> </label>
              <div class="control-width">
              <asp:TextBox ID="TextBox10" style="height: 101px !important; width: 100% !important;  resize:none;" onkeypress="return IsAlphaNumeric(event);" 
                    TextMode="MultiLine" class="span12" placeholder="Remarks" runat="server"
                     MaxLength="3000" onblur="textBoxOnBlur(this);"></asp:TextBox>
               <br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                  runat="server"  InitialValue=""  ValidationGroup="basicdetails" ErrorMessage="Remarks required" ControlToValidate="TextBox10" 
                    ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
              </div>
              <br />
              </div>



        </div>
         <div class="row">
        <div class="col-sm-6 col-xs-12">
            
             
             <label class="control-label-width" style="width: 100px;">Status  <span style="color:Red;">*</span> </label>
              <div class="control-width-status">
              <asp:DropDownList ID="ddluploadby" AppendDataBoundItems="true" class="span10"  runat="server">
              
                  </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="validationposition"
                        runat="server" InitialValue="" ErrorMessage="Status is required" ControlToValidate="ddluploadby"
                        ValidationGroup="basicdetails" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            
          
        
           </div>
		  </div> 
          <div class="col-sm-4 col-xs-12">
           <label for="sel1" class="label-class-width">Supporting Document:</label>
    <div class="input-class-width-upload">
<asp:FileUpload ID="FileUpload1" runat="server" />

          </div>

          </div>
          <div class="col-sm-2 col-xs-12">
          <div class="span1-one width-name-btn"><div class="span1-three" style="text-align: right;margin: 12px 7px 0 0px; float: right;">

               <asp:Button ID="Button1" Enabled="false" Visible="false" class="btn btn-success"  runat="server" Text="Save" />
               <asp:ImageButton  ID="ImageButton1" OnClientClick="if(Page_ClientValidate('basicdetails')) ShowProgress();" Enabled="false"   runat="server"  
                   ImageUrl="~/images/save20x20.png" Height="20" Width="20" ToolTip ="Save"  />
               <asp:ImageButton ID="Button2"    runat="server" ToolTip="Reset" 
                 ImageUrl="~/images/reload20x20.png"   CausesValidation="False" />
 </div></div>
          </div>
        </div>
       
              
              
               </div>
   
      


    </form>
    </div>  </div></div>
    
<script src="js/bootstrap.min.js" ></script> 


 <script type="text/javascript">

     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         return true;
     }
     function limitCharLengthAddress(txtArea) {
         if (txtArea.value.length > 15) {
             txtArea.value = txtArea.value.substring(0, 15);
         }
     }
     function limitLengthAddress(txtArea) {
         if (txtArea.value.length > 11) {
             txtArea.value = txtArea.value.substring(0, 11);
         }
     }
     function ValidateEmail(evt) {
         var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
         if (evt.value.match(mailformat)) {
             document.getElementById("emlerror").style.display = ret ? "none" : "inline";
             return mailformat;
         }

     }  
         </script>
     
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(32); //Space
        specialKeys.push(9); //Tab
        specialKeys.push(46); //Delete
        specialKeys.push(36); //Home
        specialKeys.push(35); //End
        specialKeys.push(37); //Left
        specialKeys.push(39); //Right
        function IsAlphaNumeric(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric1(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error1").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric2(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error2").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric3(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error3").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric4(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error4").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric5(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error5").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
</body>
</html>




