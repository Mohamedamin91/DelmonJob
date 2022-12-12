<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="DelmonJob.User.ResumeBuild" %>
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
                           <h2 class="contact-title text-center">Build Resume</h2>
                        </div>
                     
                    <div class="col-lg-6 mx-auto">
<%--                        <form class="form-contact contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">--%>
                          <div class="form-contact contact_form">
                        <div class="row">
                             <div class="col-12">
                                 <h6>Personal Information - المعلومات الاساسية</h6>
                                 </div>
                             <div class="col-12">
                                    <div class="form-group">
                                          <label>Full Name - الاسم كامل</label>
                                  <asp:TextBox ID="txtFullName" Cssclass="form-control" placeholder="Enter Full Name" required runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName" ErrorMessage="Name must Be in Characters :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 
                                        </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                  <label>Username- اسم المستخدم</label>
                                  <asp:TextBox ID="txtUsername" Cssclass="form-control" placeholder="Enter Unique Username" required runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                          <label>Address - العنوان</label>
                                  <asp:TextBox ID="txtAddress" Cssclass="form-control" placeholder="Enter Address" TextMode="MultiLine" required runat="server" ></asp:TextBox>
                                                                    </div>
                                </div>

                            <div class="col-12">
                                    <div class="form-group">
                                          <label>Mobile Number - رقم الهاتف</label>
                                  <asp:TextBox ID="txtMobileNumber" Cssclass="form-control" placeholder="Enter Mobile Number" required runat="server"></asp:TextBox>
                             <asp:RegularExpressionValidator runat="server"  ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number must Have 10 Digits :(" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RegularExpressionValidator>                 

                                        </div>
                                </div>

                             <div class="col-12">
                                    <div class="form-group">
                                          <label>Email - الايميل </label>
                                  <asp:TextBox ID="txtEmail" TextMode="Email" Cssclass="form-control" placeholder="Enter Email" required runat="server"></asp:TextBox>

                                        </div>
                                </div>

                             <div class="col-12">
                                    <div class="form-group">
                                          <label>Country - البلد </label>
                                  <asp:DropDownList ID="DDCountry" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName" >
                                      <asp:ListItem Value="0">Select Country</asp:ListItem>
                                          </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DDCountry" runat="server" ErrorMessage="Country is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>


                                        </div>
                                </div>
                               
                            <div class="col-12 pt-4">
                                 <h6>Education/Resume Information - السيرة الذاتية</h6>
                                 </div>

                             <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label>Primary Stage - المرحلة الابتدائية </label>
                                  <asp:TextBox ID= "txtPrimarystage"  Cssclass="form-control" placeholder="'Ex: 90%'"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                                    <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> Secondry Stage - المرحلة الثانوية </label>
                                  <asp:TextBox ID= "txtHigherstage"  Cssclass="form-control" placeholder="'Ex: 90%'"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> Graduate Stage - المرحلة الجامعية </label>
                                  <asp:TextBox ID="txtGraduatestage"  Cssclass="form-control" placeholder="'Ex: Prince Sultan University-Civil- Excellent Grade '"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> PostGraduate Stage - دراسات عليا </label>
                                  <asp:TextBox ID="txtPostGraduate"  Cssclass="form-control" placeholder="'Ex: Prince Sultan University- Master's Degree - Civil Engineer   '"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                              <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> Job Profile/Work on  - تعمل لدى / حاليا او سابقا  </label>
                                  <asp:TextBox ID="txtWorksOn"  Cssclass="form-control" placeholder="'Ex: Work on 'Abc' technology  '"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>
                        
                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> Experiance  - الخبرة </label>
                                  <asp:TextBox ID="txtExperiance"  Cssclass="form-control" placeholder="'Ex: 3 Years As Software Enigneer '"  runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                             <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                          <label> Resume  - ملف السيرة الذاتية  </label>
                                        <asp:FileUpload ID="FuResume" runat="server" required CssClass="form-contact pt-2" ToolTip=".doc,.docx,.pdf extension only" />
                                        </div>
                                     </div>
                            </div>
                            <div class="form-group mt-3">
                                     <asp:Button ID="btnUpdate"  runat="server" CssClass="button button-contactForm boxed-btn mr-4" Text="Update" OnClick="btnUpdate_Click" />
                                </div>
                              </div>
                        <%--</form>--%>
                    </div>
             </div>
    </div>
</section>


</asp:Content>
