<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="ViewResume.aspx.cs" Inherits="DelmonJob.Admin.ViewResume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid  pt-4 pb-4">
        <div>
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
        </div>
   
        <h3 class="text-center">View Resume /Download Resume</h3>
        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
                
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" 
                    EmptyDataText="No Record to display ..!" AutoGenerateColumns= "false"     
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    DataKeyNames="AppliedJobID" OnRowDeleting="GridView1_RowDeleting"  OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
               
                        <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Sr.No" HeaderText="Sr.No">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                         <asp:BoundField HeaderStyle-Font-Bold="false" DataField="CompanyName" HeaderText="Company Name">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Title" HeaderText="Job Title">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="name" HeaderText="User name">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Email" HeaderText="User email">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Mobile" HeaderText="Mobile No.">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                     
                        <asp:TemplateField  HeaderText="Resume">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.Resume","../{0}") %>' runat="server">
                                    <i class="fas fa-download"></i> Download</asp:HyperLink>
                                    <asp:HiddenField ID="hdnJob" runat="server"  Value=' <%# Eval("jobid") %>'  Visible =" false"/>
                                </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>


                 
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
      <%--  </div>--%>

</asp:Content>
