<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DelmonJob.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
  
<div class="container pt-50 pb-40">

      <div class="row">
                    <div class="col-12 pb-20">
                                 <asp:Label ID="lblMsg" runat="server" Visible="false" ></asp:Label>
                        </div>
                        <div class="col-12">
                           <h2 class="contact-title text-center">Sign In</h2>
                        </div>
                     
                    <div class="col-lg-6 mx-auto">
<%--                        <form class="form-contact contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">--%>
                          <div class="form-contact contact_form">
                        <div class="row">
                                <div class="col-10">
                                    <div class="form-group">
                                  <label>Username</label>
                                  <asp:TextBox ID="txtUsername" Cssclass="form-control" placeholder="Enter  Username" required runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                    <label>Password</label>
                                  <asp:TextBox ID="txtPassword" TextMode="Password" Cssclass="form-control" placeholder="Enter Password" required runat="server"></asp:TextBox>
                                    </div>
                                    </div>
       
                            </div>
                      
                            <div class="form-group mt-3">
                                     <asp:Button ID="btnLogin"  runat="server" CssClass="button button-contactForm boxed-btn mr-4" Text="Login" OnClick="btnLogin_Click" />
                                <label CssClass="form control" ><a style="color:darkblue" href="../User/Register.aspx">New User? Click Here..</a></label>
                                </div>
                              </div>
                    </div>
             </div>
    </div>
</section>

</asp:Content>
