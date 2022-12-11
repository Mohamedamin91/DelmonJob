<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="DelmonJob.Admin.JobList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image:url('../Images/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat;
 background-size: cover; background-attachment:fixed;">
    <div class="container-fluid  pt-4 pb-4">
        <div>
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
        </div>
   
        <h3 class="text-center">Job List/Details</h3>
        <div class="row mb-3 pt-sm-3">
            <div class="col-md-12">
                <div style="width:100%;overflow:scroll;">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" 
                    EmptyDataText="No Record to display ..!" AutoGenerateColumns= "false"     
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobID">
                    <Columns>
               
                        <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Sr.No" HeaderText="Sr.No">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Title" HeaderText="Job Title">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="postions" HeaderText="No. Positions">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Qualification" HeaderText="Qualification">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Experiance" HeaderText="Experiance">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="LastDayToApply" HeaderText="Valid Till" DataFormatString="{0:dd MMMM yyyy}">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField HeaderStyle-Font-Bold="false" DataField="CompanyName" HeaderText="Company">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                         <asp:BoundField HeaderStyle-Font-Bold="false" DataField="Country" HeaderText="Country">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderStyle-Font-Bold="false" DataField="State" HeaderText="State">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                     
                        <asp:BoundField HeaderStyle-Font-Bold="false" DataField="CreateDate" HeaderText="Posted Date">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle Height="20"  BackColor="#35348d" ForeColor="White"/>
                </asp:GridView>
                    </div>
            </div>
        </div>
        </div>
        </div>
</asp:Content>
