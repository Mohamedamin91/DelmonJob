<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="DelmonJob.Admin.Setting" %>
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
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"  DataKeyNames="UserID" >
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

                       
                        
                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="UserType" HeaderText="User Type">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>






                 
                      <asp:TemplateField  HeaderText="Edit">
                            <ItemTemplate>
                              <asp:LinkButton ID="btnEditJob" runat="server"  OnClick="btnEditJob_Click">
                                  <asp:Image ID="Img" runat="server" ImageUrl="../assets/img/icon/edit.png" Height="25px" />
                              </asp:LinkButton>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center"   Width="50px" />
                        </asp:TemplateField>
                    
                    
                    </Columns>
                    <HeaderStyle Height="20"  BackColor="#35348d" ForeColor="White"/>
                </asp:GridView>
               
                    
            </div>
                                         <div class="col-md-3">
                                    <div class="form-group">
                                    <label >Login Type</label>
                               <asp:DropDownList ID="DDUsertype" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="UserType" DataValueField="UserType" >
                                      <asp:ListItem Value="0">Select User Type</asp:ListItem>
                                          </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [UserType] FROM [TblUserType]"></asp:SqlDataSource>
               </div>
                                             
                                </div>
        </div>
        </div>
</asp:Content>
