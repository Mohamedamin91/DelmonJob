﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="DelmonJob.Admin.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width:800px; margin:0 auto;">
      

<div style="background-image:url('../Images/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat;
 background-size: cover; background-attachment:fixed;">
    <div class="container pt-4 pb-4">
      <%--  <div>
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
        </div>--%>
            
        <div class="btn-toolbar justify-content-between mb-3">
            <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
            </div>
            <div class="input-Group h-25">
                <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn btn-secondary" Visible="false"  > < Back</asp:HyperLink>
            </div>
        
        </div>
   
   
        <h3 class="text-center"><% Response.Write(Session["Title"]); %></h3>

           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtJobTitle" style="font-weight:600">Job title / عنوان الوظيفة</label>
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex ' Software Engineer ' " required></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtNumberOFPostions" style="font-weight:600">Number Of Postions /  الخانات للوظيفة</label>
                <asp:TextBox ID="txtNumberOFPostions" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ex ' Number Of Positions  ' " required></asp:TextBox>
            </div>
        </div>
           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-12 pt-3">
                <label for="txtdescription" style="font-weight:600">Description / وصف الوظيفة</label>
                <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" placeholder="Ex ' Enter job Description ' "
                    textmode="MultiLine"  required></asp:TextBox>
            </div>
        </div>
           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtQualification" style="font-weight:600">Qualification/Education / مؤهل </label>
                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex ' Primary - Secondry - Graduated ' " required></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtExpereiance" style="font-weight:600">Expereiance / الخبرة  </label>
                <asp:TextBox ID="txtExpereiance"  runat="server" CssClass="form-control" placeholder="Ex '  2 Years , 3 Years   ' " required></asp:TextBox>
            </div>
        </div> 
           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtSpecialization" style="font-weight:600">Specialization / التخصص</label>
                <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Ex ' Enter Specialization ' "  required></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtLastDate" style="font-weight:600">Last Date To Apply / اخر موعد للتقديم  </label>
                <asp:TextBox ID="txtLastDate"  runat="server" CssClass="form-control" placeholder="Ex '  Enter Last Date To Apply  ' " TextMode="Date" required></asp:TextBox>
            </div>
        </div> 
           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtsalary" style="font-weight:600">Salary / المرتب</label>
                <asp:TextBox ID="txtsalary" runat="server" CssClass="form-control" placeholder="Ex '  4000/Month 'SAR'   ' "  required></asp:TextBox>
            </div>
                      <div class="col-md-6 pt-3">
                <label for="txtJobType" style="font-weight:600">Job Type / نوع الوظيفة  </label>
                  <asp:DropDownList ID="DDJobTypes" runat="server" CssClass="form-control">
                      <asp:ListItem Value="0"> Select Job Type </asp:ListItem>
                      <asp:ListItem > Full Time </asp:ListItem>
                      <asp:ListItem > Part Time </asp:ListItem>
                      <asp:ListItem > Remote </asp:ListItem>
                      <asp:ListItem > Freelance </asp:ListItem>
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="JobType Is required" ForeColor="Red" ControlToValidate="DDJobTypes" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                  
              </div>
       
        </div> 
        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtCompanyName" style="font-weight:600">Company Name /  اسم الشركة</label>
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" placeholder="Ex '  Enter Company name   ' "  required></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtcompanylogo" style="font-weight:600">Company Logo / شعار الشركة  </label>
                 <asp:FileUpload ID="Fucompanylogo" runat="server" CssClass="form-control" ToolTip=".jpg , .jpeg , .png extension only" />
                  
              </div>
        </div> 

           <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtWebsite" style="font-weight:600">Website / الموقع</label>
                <asp:TextBox ID="txtWebsite" runat="server" TextMode="Url" CssClass="form-control" placeholder="Ex ' Enter Specialization ' "  required></asp:TextBox>
            </div>
              <div class="col-md-6 pt-3">
                <label for="txtEmail" style="font-weight:600"> Email / الايميل  </label>
                <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control" placeholder="Ex '  Enter Email  ' " TextMode="Email"     required></asp:TextBox>
            </div>
        </div> 

        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-12 pt-3">
                <label for="txtAddress" style="font-weight:600">Address / العنوان</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Ex ' Enter Address ' "
                    textmode="MultiLine"  required></asp:TextBox>
            </div>
        </div>
      <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtCountry" style="font-weight:600">Country /  البلد</label>
             <asp:DropDownList ID="DDCountry" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName" >
                                      <asp:ListItem Value="0">Select Country</asp:ListItem>
                                          </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DDCountry" runat="server" ErrorMessage="Country is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>

            </div>
              <div class="col-md-6 pt-3">
                <label for="txtstate" style="font-weight:600">State / المحافظة  </label>
                <asp:TextBox ID="txtstate" runat="server" CssClass="form-control" placeholder="Ex ' Enter State ' "  required></asp:TextBox>
                  
              </div>
        </div> 
         <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
         <div class="col-md-3 col-md-offset-2 mb-3">
             <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#35348d" Text="Add Job" OnClick="btnAdd_Click"/>
         </div>
         </div>

    </div>
    


</div>
</div>

   
</asp:Content>

