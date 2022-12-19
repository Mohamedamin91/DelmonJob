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
                    EmptyDataText="No Record to display ..!" AutoGenerateColumns= "false" OnRowDataBound="GridView1_RowDataBound"   HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"  DataKeyNames="UserID" >
                    <Columns>
               
                        <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Sr.No" HeaderText="Sr.No">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                         <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Userid" HeaderText="User Id">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="FullName" HeaderText="Full Name">
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

                         <asp:BoundField HeaderStyle-Font-Bold="false" DataField="CompanyName" HeaderText="Department">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                      
                        
                        
                           <asp:TemplateField  HeaderText="Edit">
                            <ItemTemplate>
                              <asp:LinkButton ID="btnEditUserType" runat="server" CommandName="EditUserType" CommandArgument= '<%# Eval("UserID") %>'>
                                  <asp:Image ID="Img" runat="server" ImageUrl="../assets/img/icon/edit.png" Height="25px" />
                              </asp:LinkButton>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center"   Width="50px" />
                        </asp:TemplateField>


                        
                      


                 
                    
                    
                    
                    </Columns>
                    <HeaderStyle Height="20"  BackColor="#35348d" ForeColor="White"/>
                </asp:GridView>
               
                    
            </div>
                                         <div class="col-md-6">
                                          
                                             <div class="form-group">
                                    
                               <asp:DropDownList ID="DDUsertype" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="UserType" DataValueField="UserType" >
                                      <asp:ListItem Value="0">Select User Type</asp:ListItem>
                                          </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [UserType] FROM [TblUserType]"></asp:SqlDataSource>
            
                                       </div>

                                             <div class="form-group">
                                    
                                     <asp:DropDownList ID="DDepartment" Cssclass="form-control w-100" runat="server"  >
                                     <asp:ListItem Value="0">Select Department</asp:ListItem>
                                     <asp:ListItem>Head Office</asp:ListItem>
                                     <asp:ListItem>IT</asp:ListItem> 
                                     <asp:ListItem>Finance</asp:ListItem>
                                     <asp:ListItem>Operations</asp:ListItem>
                                     <asp:ListItem>SAP</asp:ListItem>
                                     <asp:ListItem>Lukoil</asp:ListItem>
                                     <asp:ListItem>National Factory </asp:ListItem>
                                     <asp:ListItem>Riyadh Plant</asp:ListItem>
                                     <asp:ListItem>Hofuf Palnt</asp:ListItem>
                                     <asp:ListItem>Salt Plant</asp:ListItem>
                                     <asp:ListItem>Coating</asp:ListItem>
                                     <asp:ListItem>Masterbatch</asp:ListItem>
                                     <asp:ListItem>Operation 2</asp:ListItem>
                                     <asp:ListItem>Operation 4</asp:ListItem>
                                 </asp:DropDownList>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DDepartment" runat="server" ErrorMessage="Department is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>--%>
            
                                       </div>

                                            
                             

                                             <asp:Button ID="btnupdate" runat="server" Text="Update"  CssClass="btn btn-primary btn-block"  OnClick="btnupdate_Click" BackColor="#35348d"  />
                                             
                                            
                                </div>
        </div>
        </div>
</asp:Content>
