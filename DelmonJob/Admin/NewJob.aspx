<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="DelmonJob.Admin.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section>
  <h3 class="text-center" style="margin-top:50px;"><% Response.Write(Session["Title"]); %> </h3>
<div class="container pt-50 pb-40">
    
      <div class="row" style="margin-top:70px;">
                    <div class="btn-toolbar justify-content-between mb-3" >
            <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
            </div>
            <div class="input-Group h-25">
                <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn btn-secondary" Visible="false"  > < Back</asp:HyperLink>
            </div>
        
           

        </div>
                     
                    <div class="col-lg-5 mx-auto">
                  
                        <div class="form-contact contact_form">
                        <div class="row">
                            
                             <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                          <label for="txtJobTitle" style="font-weight:600">Job title  </label>
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex ' Software ' " required></asp:TextBox>
                                        </div>
                                </div>
                                <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                 <label for="txtNumberOFPostions" style="font-weight:600">Number Of Postions  </label>
                              <asp:TextBox ID="txtNumberOFPostions" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ex ' 1 Postions ' " required></asp:TextBox>
                 </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label for="txtdescription" style="font-weight:600">Description   </label>
                <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" placeholder="Ex '  job Description ' "
                    textmode="MultiLine"  required></asp:TextBox>
                                                                    </div>
                                </div>

                            <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                         <label for="txtQualification" style="font-weight:600">Qualification/Education   </label>
                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex ' Primary - Secondry  ' " required></asp:TextBox>

                                        </div>
                                </div>

                             <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                      <label for="txtExpereiance" style="font-weight:600">Expereiance    </label>
                <asp:TextBox ID="txtExpereiance"  runat="server" CssClass="form-control" placeholder="Ex '  2 Years    ' " required></asp:TextBox>
        
                                        </div>
                                </div>

                             <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                          <label>Country </label>
                                  <asp:DropDownList ID="DDCountry" Enabled="false" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName" >
                                      <asp:ListItem Value="0">Select Country</asp:ListItem>
                                          </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DDCountry" runat="server" ErrorMessage="Country is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>


                                        </div>
                                </div>
                               
                           
                             <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                       <label for="txtSpecialization" style="font-weight:600">Specialization  </label>
                <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Ex ' Enter Specialization ' " TextMode="MultiLine"  required></asp:TextBox>
                 </div>
                                     </div>

                                    <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                             <label for="txtLastDate" style="font-weight:600">Last Date To Apply      </label>
                <asp:TextBox ID="txtLastDate"  runat="server" CssClass="form-control" placeholder="Ex '  Enter Last Date To Apply  ' " TextMode="Date" required></asp:TextBox>
                  </div>
                                     </div>

                            <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                              <label for="txtsalary" style="font-weight:600">Salary  </label>
                <asp:TextBox ID="txtsalary" runat="server" CssClass="form-control" placeholder="Ex '  4000/Month 'SAR'   ' "  required></asp:TextBox>
                        </div>
                                     </div>

                                 <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                              <label for="txtCompanyName" style="font-weight:600">Department Name    </label>
              
                                        
                                      <%--  <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" placeholder="Ex '  Enter Company name   ' "  required></asp:TextBox>--%>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DDepartment" runat="server" ErrorMessage="UserType is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                                      
                                    </div>
                                     </div>

                              <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                  <label for="txtWebsite" style="font-weight:600">Website  </label>
                <asp:TextBox ID="txtWebsite" runat="server" TextMode="Url" CssClass="form-control" placeholder="Ex '  Website ' "  ></asp:TextBox>
                        </div>
                                     </div>
                        
                            <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                     <label for="txtEmail" style="font-weight:600"> Email    </label>
                <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control" placeholder="Ex '  Enter Email  ' " TextMode="Email" ></asp:TextBox>
                     </div>
                                     </div>

                             <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                         <label for="txtAddress" style="font-weight:600">Address  </label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Ex ' Enter Address ' "
                    textmode="MultiLine"  required></asp:TextBox>
                </div>
                                     </div>
                               <div class="col-md-6 col-md-6">
                                    <div class="form-group">
                                          <label for="txtstate" style="font-weight:600">City    </label>
               <asp:DropDownList ID="DDCity" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource3"
                                      AppendDataBoundItems="true" DataTextField="Cityname" DataValueField="Cityname" >
                                      <asp:ListItem Value="0">Select City</asp:ListItem>
                                          </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource3"   runat="server" ConnectionString="Data Source=DELSQLSRVR;Initial Catalog=DelmonJobPortal;User ID=sa;Password=Ram72763@" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Cityname] FROM [tblCity]"></asp:SqlDataSource>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DDCity" runat="server" ErrorMessage="City is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>

                </div>
                                     </div>
                           
                           

                             <div class="col-md-6 col-md-6" Cssclass="form-control w-100">
                                    <div class="form-group">
  <label for="txtJobType" style="font-weight:600">Job Type     </label>
                  <asp:DropDownList ID="DDJobTypes" runat="server" CssClass="form-control">
                      <asp:ListItem Value="0"> Select Job Type </asp:ListItem>
                      <asp:ListItem > Full Time </asp:ListItem>
                      <asp:ListItem > Part Time </asp:ListItem>
                      <asp:ListItem > Remote </asp:ListItem>
                      <asp:ListItem > Freelance </asp:ListItem>
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="JobType Is required" ForeColor="Red" ControlToValidate="DDJobTypes" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
           </div>
                                     </div>

                            <div class="ccol-md-6 col-md-6">
                                    <div class="form-group">
                                        <label for="txtJobCategory" style="font-weight:600">Job Category     </label>
                  <asp:DropDownList ID="DDJobCategory" runat="server" CssClass="form-control">
                      <asp:ListItem Value="0"> Select Job Category </asp:ListItem>
                                     <asp:ListItem>IT</asp:ListItem> 
                                     <asp:ListItem>Finance</asp:ListItem>
                                     <asp:ListItem>Labour</asp:ListItem>
                                     <asp:ListItem>Sales & Marketing</asp:ListItem>
                                     <asp:ListItem>Engineering</asp:ListItem>

                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="JobCategory Is required" ForeColor="Red" ControlToValidate="DDJobCategory" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                      </div>
                                     </div>
                              <div class="col-lg-6 col-lg-6">
                                    <div class="form-group">
                                        <label for="txtcompanylogo" style="font-weight:600">Company Logo     </label>
                 <asp:FileUpload ID="Fucompanylogo" runat="server" CssClass="form-control" ToolTip=".jpg , .jpeg , .png extension only" />
                  </div>
                                     </div>
                        
                        
                        
                        
                        </div>








                            <div class="form-group mt-3">
             <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#35348d" Text="Add Job" OnClick="btnAdd_Click"/>
                                </div>
                              </div>
                        <%--</form>--%>
                    </div>
             </div>
    </div>
</section>

   
</asp:Content>

