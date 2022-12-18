<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DelmonJob.User.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Hero Area Start-->
    <div class="slider-area ">
        <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="../assets/img/hero/about.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="hero-cap text-center">
                            <h2>Contact us</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <!-- Hero Area End -->
    <!-- ================ contact section start ================= -->
    <section class="contact-section">
            <div class="container">
                <div class="col-lg-8">
            	<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3575.6939646911546!2d50.194233915032854!3d26.336407483379183!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3e49e8ba60d420ad%3A0xedc43bb2ad5573b6!2sDelmon%20Tower!5e0!3m2!1sen!2ssa!4v1648464843163!5m2!1sen!2ssa" width="600" height="450" style="border:0;" allowfullscreen=""></iframe>

                </div>
    
                <div class="row">
                    <div class="col-12 pb-20">
                                 <asp:Label ID="lblMsg" runat="server" Visible="false" ></asp:Label>
                        </div>
                        <div class="col-12">
                           <h2 class="contact-title">Get in Touch</h2>
                        </div>
                     
                    <div class="col-lg-8">
<%--                        <form class="form-contact contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">--%>
                          <div class="form-contact contact_form" id="contactForm" >
                        <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <textarea class="form-control w-100" runat="server" name="message" id="message" cols="30" rows="9" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter Message'" placeholder=" Enter Message" required></textarea>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <input class="form-control valid"  runat="server" name="name" id="name" type="text" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter your name'" placeholder="Enter your name" required>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <input class="form-control valid" runat="server" name="email" id="email" type="email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter email address'" placeholder="Email" required>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <input class="form-control" runat="server" name="subject" id="subject" type="text" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter Subject'" placeholder="Enter Subject" required>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group mt-3">
                                     <asp:Button ID="btnSend"  runat="server" CssClass="button button-contactForm boxed-btn" Text="Send" OnClick="btnSend_Click" />
                                </div>
                              </div>
                        <%--</form>--%>
                    </div>
                    <div class="col-lg-3 offset-lg-1">
                        <div class="media contact-info">
                            <span class="contact-info__icon"><i class="ti-home"></i></span>
                            <div class="media-body">
                                <h3> Delmon Tower-Prince Sultan Road</h3>
                                <p>Qurtoba-Khobar</p>
                            </div>
                        </div>
                        <div class="media contact-info">
                            <span class="contact-info__icon"><i class="ti-tablet"></i></span>
                            <div class="media-body">
                                <h3>+966138577777</h3>
                                <p>Sat to Thu 08:00am to 04:30pm</p>
                            </div>
                        </div>
                       <%--<div class="media contact-info">
                            <span class="contact-info__icon"><i class="ti-email"></i></span>
                            <div class="media-body">
                                <h3>support@colorlib.com</h3>
                                <p>Send us your query anytime!</p>
                            </div>
                        </div>--%>
                    </div>
                </div>
           </div>
        </section>
    <!-- ================ contact section end ================= -->


</asp:Content>
