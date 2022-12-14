<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="Userlist.aspx.cs" Inherits="DelmonJob.Admin.Userlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container-fluid  pt-4 pb-4">
        <div>
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
        </div>
   
        <h3 class="text-center">User List/Details</h3>
        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
                
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" 
                    EmptyDataText="No Record to display ..!" AutoGenerateColumns= "false"    HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"  DataKeyNames="UserID" OnRowDeleting="GridView1_RowDeleting" >
                    <Columns>
               
                        <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Sr.No" HeaderText="Sr.No">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Name" HeaderText="User Name">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Email" HeaderText="Email">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Mobile" HeaderText="Mobile No.">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Country" HeaderText="Country">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        



                 
                        <asp:CommandField  CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                            DeleteImageUrl="../assets/img/icon/trash.png" ButtonType="Image">
                            <ControlStyle  Height="25px" Width="25px"/>
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:CommandField>
                    
                    
                    </Columns>
                    <HeaderStyle Height="20"  BackColor="#35348d" ForeColor="White"/>
                </asp:GridView>
               
                    
            </div>
        </div>
        </div>
     
</asp:Content>
