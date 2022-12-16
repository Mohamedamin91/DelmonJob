<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster2.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DelmonJob.Admin.Dashboard" %>
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
                color:#fff;
                font-weight:bold;
                border-bottom-color:#F3F2E7;
                padding-top:4px;
            }
            .radiobuttonlist label:hover {
             color:#CC3300;
             background:#01CFC2;
            }
        .radiobuttoncontainer {
            position:relative;
            z-index:0;
            border: solid 1px #AcA899;
            padding:10px;
            background-color:#F3F2E7;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
    <%--   <div class="container pt-4">
           <div class="row">
               <div class="col-12 pb-3">
                   <h2 class=" text-center"> Dashboard </h2>
               </div>

               <div class="col-md-10 mx-auto">
                   <div class="row">

                       <div class="col-xl-3 col-lg-6">
                           <div class="card l-bg-cherry">
                               <div class="card-statistic-3 p-4">
                                   <div class="card-icon card-icon-large">
                                  <i class="fas fa-users pr-2"></i>
                                   </div>
                               <div class="mb-4">
                                   <h5 class=" card-title mb-0 ">Total Users</h5>
                               </div>
                                   <div class="row-align-items-center mb-2 d-flex">
                                       <div class="col-8">
                                           <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["Users"]); %>
                                           </h2>

                                       </div>

                                   </div>
                               </div>
                           </div>
                       </div>

                   </div>


               </div>

               <div class="col-md-10 mx-auto">
                   <div class="row">

                       <div class="col-xl-3 col-lg-6">
                           <div class="card l-bg-blue-dark">
                               <div class="card-statistic-3 p-4">
                                   <div class="card-icon card-icon-large">
                                  <i class="fas fa-briefcase pr-2"></i>
                                   </div>
                               <div class="mb-4">
                                   <h5 class=" card-title mb-0 ">Total Jobs</h5>
                               </div>
                                   <div class="row-align-items-center mb-2 d-flex">
                                       <div class="col-8">
                                           <h2 class="d-flex align-items-center mb-0">
                                                  <% Response.Write(Session["jobs"]); %>
                                           </h2>

                                       </div>

                                   </div>
                               </div>
                           </div>
                       </div>

                   </div>


               </div>
           
               <div class="col-md-10 mx-auto">
                   <div class="row">

                       <div class="col-xl-3 col-lg-6">
                           <div class="card l-bg-green-dark">
                               <div class="card-statistic-3 p-4">
                                   <div class="card-icon card-icon-large">
                                  <i class="fas fa-check-square pr-2"></i>
                                   </div>
                               <div class="mb-4">
                                   <h5 class=" card-title mb-0 ">Applied Jobs</h5>
                               </div>
                                   <div class="row-align-items-center mb-2 d-flex">
                                       <div class="col-8">
                                           <h2 class="d-flex align-items-center mb-0">
                                    <% Response.Write(Session["AppliedJobs"]); %>
                                           </h2>

                                       </div>

                                   </div>
                               </div>
                           </div>
                       </div>

                   </div>


               </div>

               <div class="col-md-10 mx-auto">
                   <div class="row">

                       <div class="col-xl-3 col-lg-6">
                           <div class="card l-bg-orange-dark">
                               <div class="card-statistic-3 p-4">
                                   <div class="card-icon card-icon-large">
                                  <i class="fas fa-comment pr-2"></i>
                                   </div>
                               <div class="mb-4">
                                   <h5 class=" card-title mb-0 ">Contacted Users</h5>
                               </div>
                                   <div class="row-align-items-center mb-2 d-flex">
                                       <div class="col-8">
                                           <h2 class="d-flex align-items-center mb-0">
                                             <% Response.Write(Session["Contact"]); %>
                                           </h2>

                                       </div>

                                   </div>
                               </div>
                           </div>
                       </div>

                   </div>


               </div>
           
           </div>

       </div>  --%>
   
</asp:Content>

