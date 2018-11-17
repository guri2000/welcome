<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EventMaster.aspx.vb" Inherits="EventMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="font-awesome.min.css" />
    <style type="text/css">
        #RadioButtonList1 td label
        {
            margin-left: 7px;
        }
        #RadioButtonList1
        {
            width: 150px;
        }
        table tr td { padding: 4px !important; }
        .form-group {
            margin-bottom: 4px !important;
        }
    </style>
    <script type="text/javascript">
        function lettersOnly(event) {
            var charCode = 0;
            if (event.charCode) {
                charCode = event.charCode;
            }
            else {
                charCode = event.keyCode;
            }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8 || charCode == 48 || charCode == 9 || charCode == 32)
                return true;
            else
                return false;
        }
        function limitTextLength(txtBox, len) {
            if (Number(txtBox.value.length) > len) {
                txtBox.value = txtBox.value.substring(0, len);
                return false;
            }
            return true;
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid" style="margin-top: 7px;">
      <%--  <h4 class="bg-primary" style="padding: 7px; border-radius: 4px;">
            Add to Masters</h4>--%>
        <div class="row">
            <div class="col-xs-12">
                <div class="col-sm-6 col-xs-12">
                    <div class="panel panel-primary">
                        <%-- <div class="row">
                            <div class="col-xs-12">--%>
                        <div class="panel-heading" style="padding: 4px 7px;">
                            Department</div>
                        <%--  </div>
                        </div>--%>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">
                                            Description</label>
                                        <asp:TextBox ID="txtDeptDesc" CssClass="form-control" runat="server" ValidationGroup="dept"
                                            placeholder="Description" onkeyup="limitTextLength(this,500);" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server"
                                            ErrorMessage="Department Description Required" ControlToValidate="txtDeptDesc"
                                            ForeColor="red" ValidationGroup="dept"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleFormControlSelect1">
                                            Company</label>
                                        <asp:DropDownList ID="ddlCompany" runat="server" ValidationGroup="dept" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server"
                                            ErrorMessage="Company is Required" ControlToValidate="ddlCompany" ForeColor="red"
                                            ValidationGroup="dept" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary pull-right" runat="server" Text="Save"
                                        ValidationGroup="dept" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="dept"
                                        ShowSummary="false" ShowMessageBox="true" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12" style="max-height: 250px;overflow-y: auto;">
                            <asp:GridView ID="dgvDepartments" runat="server" CssClass="table table-responsive table-striped table-hover" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="grpid" SortExpression="grpid" HeaderText="#" HeaderStyle-Width="10" HeaderStyle-CssClass="bg-primary" Visible="false" />
                                <asp:BoundField DataField="grpdescr" SortExpression="grpdescr" HeaderText="Description" HeaderStyle-CssClass="bg-primary" />
                                <asp:BoundField DataField="cmpnm" SortExpression="cmpnm" HeaderText="Company" HeaderStyle-CssClass="bg-primary" />
                            </Columns>
                            <HeaderStyle />
                            </asp:GridView>
                        </div>
                    </div>                   
                </div>
                <div class="col-sm-6 col-xs-12">
                    <div class="panel panel-primary">
                        <%--<div class="row">
                            <div class="col-xs-12">--%>
                        <div class="panel-heading" style="padding: 4px 7px;">
                            Event Activity</div>
                        <%--</div>
                        </div>--%>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="col-xs-12 bg-info" style="padding: 7px 7px 1px; border-radius: 1px; margin-bottom: 15px;">
                                        <asp:RadioButtonList ID="RadioButtonList1" CssClass="form-check" runat="server" AutoPostBack="True"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Parent</asp:ListItem>
                                            <asp:ListItem Value="2">Child</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleFormControlSelect1">
                                            Company</label>
                                        <asp:DropDownList ID="ddlCompanyEvent" CssClass="form-control" runat="server" ValidationGroup="event" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="None" runat="server"
                                            ErrorMessage="Company is Required" ControlToValidate="ddlCompanyEvent" ForeColor="red"
                                            ValidationGroup="event" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="exampleFormControlSelect1">
                                            Dept Group</label>
                                        <asp:DropDownList ID="ddlDeptGroup" CssClass="form-control" runat="server" ValidationGroup="event" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" runat="server"
                                            ErrorMessage="Dept Group is Required" ControlToValidate="ddlDeptGroup" ForeColor="red"
                                            ValidationGroup="event" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div id="divParent" runat="server" visible="false" style="width: 100%">
                                        <div class="form-group">
                                            <label for="exampleFormControlSelect1">
                                                Parent</label>
                                            <asp:DropDownList ID="ddlParent" CssClass="form-control" runat="server" ValidationGroup="event" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="None" runat="server"
                                                ErrorMessage="Parent is Required" ControlToValidate="ddlParent" ForeColor="red"
                                                ValidationGroup="event" InitialValue="-1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">
                                            Description</label>
                                        <asp:TextBox ID="txtEventDescription" CssClass="form-control" runat="server" ValidationGroup="event" onkeyup="limitTextLength(this,200);" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None" runat="server"
                                            ErrorMessage="Event Description Required" ControlToValidate="txtEventDescription"
                                            ForeColor="red" ValidationGroup="event"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:Button ID="btnSaveEvent" CssClass="btn btn-primary pull-right" runat="server"
                                        Text="Save" ValidationGroup="event" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="event"
                                        ShowSummary="false" ShowMessageBox="true" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12" style="max-height: 140px;overflow-y: auto;">
                            <asp:GridView ID="dgvEvent" runat="server" CssClass="table table-responsive table-striped table-hover" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="actid" SortExpression="actid" HeaderText="#" HeaderStyle-Width="10" HeaderStyle-CssClass="bg-primary" Visible="false" />
                                <asp:BoundField DataField="actdescr" SortExpression="actdescr" HeaderText="Description" HeaderStyle-CssClass="bg-primary" />
                                <asp:BoundField DataField="grpdescr" SortExpression="grpdescr" HeaderText="Department" HeaderStyle-CssClass="bg-primary" />
                                <asp:BoundField DataField="Parent" SortExpression="Parent" HeaderText="Parent" HeaderStyle-CssClass="bg-primary" />
                                
                            </Columns>
                            <HeaderStyle />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
