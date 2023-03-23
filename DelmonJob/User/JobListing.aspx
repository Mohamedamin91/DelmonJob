<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="JobListing.aspx.cs" Inherits="DelmonJob.User.JobListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.0.3/css/font-awesome.css " rel="stylesheet" type="text/css"/>
    <style>
        .checkbox {
    padding-left: 20px;   
}
         .checkbox label {
        display: inline-block;
        position: relative;
        padding-left:5px;
        vertical-align:middle;    
    }
            .checkbox label::before {
                content:"";
                display:inline-block;
                position:absolute;
                width:17px;
                height:17px;
                left:0;
                top:0;
                margin-left: -20px;
                border:1px solid #cccccc;
                border-radius:3px;
                background-color:#fff;
                -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                 transition:border 0.15s ease-in-out, color 0.15s ease-in-out;
            }
            .checkbox label::after {
                  
                display:inline-block;
                position:absolute;
                width:16px;
                height:16px;
                left:0;
                top:0;
                margin-left: -20px;
                padding-left:3px;
                padding-top:1px;
                font-size:11px;
                color:#ff4354;
            }
            .checkbox input[type="checkbox"] {
                  opacity:0;
                  z-index:1;
            }
             .checkbox input[type="checkbox"]:checked +label::after {
                 font-family: "FontAwsome";
                 content:"\f00c";

             }
                .checkbox-primary input[type="checkbox"]:checked + label::before {
                    background-color:#FF4357;
                    border-color:#FF4357;
                }
        .checkbox-primary input[type="checkbox"]:checked + label::after {
            color:#fff;
        } 
    </style>
    <style>
        .radiobuttonlist {
            font: 12px verdana, san-serif;
            color:#000;
        }
            .radiobuttonlist input {
                width:0px;
                height:20px;
            }
            .radiobuttonlist label {
                color:#FF4357;
                background-color:#FFF;
                padding-left:6px;
                padding-right:6px;
                padding-top:2px;
                padding-bottom:2px;
                border: 1px solid #FF4357;
                border-radius:10%;
                margin:0px 0px 0px 0px;
                white-space:nowrap;
                clear:left;
                margin-right:5px;
            }
            .radiobuttonlist span.selectedradio label {
                background-color:#FF4357;
                color:#FFF;
                font-weight:bold;
                border-bottom-color:#35348d;
                padding-top:4px;
            }
            .radiobuttonlist label:hover {
             color:#FFF;
             background:#35348d;
            }
        .radiobuttoncontainer {
            position:relative;
            z-index:0;
            border: solid 1px #AcA899;
            padding:10px;
            background-color:#FFF;
        }
    </style>
    </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <div>
            <asp:Label ID="lblMsg" runat="server" Visible="false"  ></asp:Label>
        </div>
      <main>

        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="../assets/img/hero/about.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                <h2>Get your job</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hero Area End -->
        <!-- Job List Area Start -->
        <div class="job-listing-area pt-120 pb-120">
            <div class="container">
                <div class="row">
                    <!-- Left content -->
                    <div class="col-xl-3 col-lg-3 col-md-4">
                        <div class="row">
                            <div class="col-12">
                                    <div class="small-section-tittle2 mb-45">
                                    <div class="ion"> <svg 
                                        xmlns="http://www.w3.org/2000/svg"
                                        xmlns:xlink="http://www.w3.org/1999/xlink"
                                        width="20px" height="12px">
                                    <path fill-rule="evenodd"  fill="rgb(27, 207, 107)"
                                        d="M7.778,12.000 L12.222,12.000 L12.222,10.000 L7.778,10.000 L7.778,12.000 ZM-0.000,-0.000 L-0.000,2.000 L20.000,2.000 L20.000,-0.000 L-0.000,-0.000 ZM3.333,7.000 L16.667,7.000 L16.667,5.000 L3.333,5.000 L3.333,7.000 Z"/>
                                    </svg>
                                    </div>
                                    <h4>Filter Jobs</h4>
                                </div>
                            </div>
                        </div>
                        <!-- Job Category Listing start -->
                        <div class="job-category-listing mb-50">
                            <!-- single one -->
                            <div class="single-listing">
                               <div class="small-section-tittle2">
                                     <h4>Job Category</h4>
                               </div>
                                <!-- Select job items start -->
                                <div class="select-job-items2">
                                    <asp:DropDownList ID="DDJobCategory" OnSelectedIndexChanged="DDJobCategory_SelectedIndexChanged" Cssclass="form-control w-100" runat="server">
                                     <asp:ListItem Value="0">Select Job Category </asp:ListItem>
                                     <asp:ListItem>Computer Jobs</asp:ListItem>
                                     <asp:ListItem>Accounts</asp:ListItem>
                                 </asp:DropDownList>
                             
                                </div>
                                <!--  Select job items End-->
                                <!-- select-Categories start -->
                                <div class="select-Categories pt-80 pb-50">
                                    <div class="small-section-tittle2">
                                        <h4>Job Type</h4>
                                    </div>
                                    <div class="checkbox checkbox-primary">
                                        <asp:CheckBoxList ID="CheckBoxList1" AutoPostBack="true" RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="styled" TextAlign="Right"  runat="server">
                                           <asp:ListItem > Full Time </asp:ListItem>
                                           <asp:ListItem > Part Time </asp:ListItem>
                                           <asp:ListItem > Remote </asp:ListItem>
                                            <asp:ListItem >Freelance </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <!-- select-Categories End -->
                            </div>
                            <!-- single two -->
                            <div class="single-listing">
                               <div class="small-section-tittle2">
                                     <h4>Job Location</h4>
                               </div>
                                <!-- Select job items start -->
                                <div class="select-job-items2">
                                   
                                  <asp:DropDownList ID="DDCity" Cssclass="form-control w-100"  runat="server" DataSourceID="SqlDataSource1"
                                      AppendDataBoundItems="true" DataTextField="Cityname" DataValueField="Cityname" >
                                      <asp:ListItem Value="0">Select City</asp:ListItem>
                                          </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1"   runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Cityname] FROM [tblCity]"></asp:SqlDataSource>
                               
                                   
                                </div>
                                <!--  Select job items End-->
                              
                            </div>
                            <!-- single three -->
                            <div class="single-listing">
                                <!-- select-Categories start -->
                                <div class="select-Categories pb-50" >
                                    <div class="small-section-tittle2">
                                        <h4 style="margin-top:100px;">Posted Within</h4>
                                    </div>
                                    <div class="radiobuttoncontainer">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radiobuttonlist" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatLayout="Flow">
                                            <asp:ListItem Value="0" Selected="True">Any</asp:ListItem>
                                            <asp:ListItem Value="1"> Today</asp:ListItem>
                                            <asp:ListItem Value="2"> Last 2 days</asp:ListItem>
                                            <asp:ListItem Value="3"> Last 3 days</asp:ListItem>
                                            <asp:ListItem Value="4"> Last 5 days</asp:ListItem>
                                            <asp:ListItem Value="5"> Last 10 days</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                  
                                </div>
                                <!-- select-Categories End -->
                            </div>
                            <div class="single-listing">
                            
                                  <div class="container" style="margin-top:20px">

                                         </div>
                                <asp:LinkButton ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-sm" OnClick="btnFilter_Click" BackColor="#35348d"/>
                                 <div class="container" style="margin-top:20px">

                                         </div>
                                <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-sm " OnClick="btnReset_Click" BackColor="#eb2d2e" />
                            </div>
                        </div>
                        <!-- Job Category Listing End -->
                    </div>
                                                           

                    <!-- Right content -->
                    <div class="col-xl-9 col-lg-9 col-md-8">
                        <!-- Featured_job_start -->
                        <section class="featured-job-area">
                            <div class="container">
                                <!-- Count of Job list Start -->
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="count-job mb-35">
                                 <asp:Label ID="lbljobcount" runat="server" Visible="true"  ></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <!-- Count of Job list End -->
                                <!-- single-job-content -->
                                <asp:DataList ID="DataList1" runat="server">
                                     <ItemTemplate>
                                <div class="single-job-items mb-30">
                                    <div class="job-items">
                                        <div class="company-img">
                                            
                                            <a href="JobDetails.aspx?id=<%# Eval("JobID") %>">
                                           <img style="width:50px; height:50px;" src="<%# GetimageUrl( Eval("CompanyLogo")) %>" alt=""></a>
                                        </div>
                                        <div class="job-tittle job-tittle2">
                                            <a href="JobDetails.aspx?id=<%# Eval("JobID") %>">
                                                <h4> <%# Eval("Title") %></h4>
                                            </a>
                                            <ul>
                                                <li> <%# Eval("companyname") %></li>
                                                <li><i class="fas fa-map-marker-alt"></i><%# Eval("State") %>,<%# Eval("Country") %></li>
                                                <li style="margin-right:100px;"> <%# Eval("Salary") %></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="items-link items-link2 f-right" >
                                        <a  href="JobDetails.aspx?id=<%# Eval("JobID") %>"> <%# Eval("JobType") %></a>
                                         <span class="text-secondary">
                                             <i class="fas fa-clock pr-1"></i>
                                          <%# Relativedata(Convert.ToDateTime( Eval("CreateDate"))) %></span>
                                    </div>
                                </div>
                                <!-- single-job-content -->


                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            
                        </section>

                        <!-- Featured_job_end -->
                    </div>
                </div>
            </div>
        </div>
        <!-- Job List Area End -->
      
        
    </main>

</asp:Content>