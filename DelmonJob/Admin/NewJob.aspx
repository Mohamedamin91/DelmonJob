<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="DelmonJob.Admin.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div style="background-image:url('../Images/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat;
 background-size: cover; background-attachment:fixed;">
    <div class="container pt-4 pb-4">
        <div>
            <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        </div>
   
        <h3 class="text-center">Add Job</h3>
        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtJobTitle" style="font-weight:600">Job title</label>
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex ' Software Engineer ' "></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtNumberOFPostions" style="font-weight:600">Job title</label>
                <asp:TextBox ID="txtNumberOFPostions" runat="server" CssClass="form-control" placeholder="Ex ' Number Of Positions  ' "></asp:TextBox>
            </div>
        </div>
    
    </div>

</div>



</asp:Content>

