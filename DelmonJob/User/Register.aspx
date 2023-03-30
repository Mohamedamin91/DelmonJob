<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DelmonJob.User.Register" %>
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
                           <h2 class="contact-title text-center">Sign Up</h2>
                        </div>
                     
                    <div class="col-lg-6 mx-auto">
<%--                        <form class="form-contact contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">--%>
                          <div class="form-contact contact_form">
                        <div class="row">
                             <div class="col-12">
                                 <h6>Login Information</h6>
                                 </div>
                                <div class="col-12">
                                    <div class="form-group">
                                  <label>Username</label>
                                  <asp:TextBox ID="txtUsername" Cssclass="form-control" placeholder="Enter Unique Username" required runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                    <label>Password</label>
                                  <asp:TextBox ID="txtPassword" TextMode="Password" Cssclass="form-control" placeholder="Enter Password" required runat="server"></asp:TextBox>
                                 
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                           <label>Confirm Password</label>
                                  <asp:TextBox ID="txtConfirmPassword" TextMode="Password" Cssclass="form-control" placeholder="Enter Confirm Password" required runat="server"></asp:TextBox>
                                       <asp:CompareValidator ID="CompareValidator1" runat="server"
                                           ErrorMessage="Password & Confirm Password should be same" 
                                           ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small">
                                       </asp:CompareValidator>    </div>
                                </div>
                            <div class="col-12">
                                 <h6>Personal Information</h6>
                                 </div>
                                <div class="col-6">
                                    <div class="form-group">
                                          <label>First Name</label>
                                  <asp:TextBox ID="txtFirstName" Cssclass="form-control" placeholder="Enter First Name" required runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFirstName" ErrorMessage="Name must Be in Characters :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 
                                        </div>
                                </div>
                            <div class="col-6">
                                    <div class="form-group">
                                          <label>Second Name</label>
                                  <asp:TextBox ID="txtsecondname" Cssclass="form-control" placeholder="Enter Second Name" required runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtsecondname" ErrorMessage="Name must Be in Characters :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 
                                        </div>
                                </div>

                            <div class="col-6">
                                    <div class="form-group">
                                          <label>Third Name</label>
                                  <asp:TextBox ID="txtthirdname" Cssclass="form-control" placeholder="Enter Third Name" required runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtthirdname" ErrorMessage="Name must Be in Characters :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 
                                        </div>
                                </div>
                            <div class="col-6">
                                    <div class="form-group">
                                          <label>Last Name</label>
                                  <asp:TextBox ID="txtlastname" Cssclass="form-control" placeholder="Enter Last Name" required runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtlastname" ErrorMessage="Name must Be in Characters :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 
                                        </div>
                                </div>
                            <div class="col-12">
                                    <div class="form-group">
                                          <label>Address</label>
                                  <asp:TextBox ID="txtAddress" Cssclass="form-control" placeholder="Enter Address" TextMode="MultiLine" required runat="server" ></asp:TextBox>
                                                                    </div>
                                </div>

                            <div class="col-12">
                                    <div class="form-group">
                                          <label>Mobile Number</label>
                                  <asp:TextBox ID="txtMobileNumber" Cssclass="form-control" placeholder="+( Country Code ) - Mobile number" required runat="server"></asp:TextBox>
                             <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number must Have 10 Digits :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 

                                        </div>
                                </div>

                             <div class="col-12">
                                    <div class="form-group">
                                          <label>Email </label>
                                  <asp:TextBox ID="txtEmail" TextMode="Email" Cssclass="form-control" placeholder="Enter Email" required runat="server"></asp:TextBox>

                                        </div>
                                </div>

                             <div class="col-12">
                                    <div class="form-group">
                                          <label>Country </label>
                                  <asp:DropDownList ID="DDCountry" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName" >
                                      <asp:ListItem Value="0">Select Country</asp:ListItem>
                                          </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DDCountry" runat="server" ErrorMessage="Country is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                                        </div>
                                </div>
                            </div>
                            <div class="form-group mt-3">
                                     <asp:Button ID="btnRegister"  runat="server" CssClass="button button-contactForm boxed-btn mr-4" Text="Register" OnClick="btnRegister_Click" />
                                <label CssClass="form control" ><a style="color:darkblue" href="../User/Login.aspx">Already Register? Click Here..</a></label>
                                </div>
                              </div>
                        <%--</form>--%>
                    </div>
             </div>
    </div>
</section>


</asp:Content>
