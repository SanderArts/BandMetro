<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="Band._login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <!--==============================content================================-->

    <div id="content"><div class="ic"></div>
	    <div class="main">
		    <div class="content-padding-2">
			    <div class="container_12">
				    <div class="wrapper">
					    <div class="grid_12">
						    <div class="padding-grid-1">
							    <h3 class="letter">Please <strong>Login</strong></h3>
						    </div>
						    <div class="wrapper">
                                <br /><br />
                                <p>
                                    You must log in, to be able to use this page.
                                </p>
                                <asp:Panel ID="PanelError" Visible="false" runat="server">
                                    <span class="failureNotification">
                                        <asp:Label ID="LabelError" runat="server" ForeColor="Red" >Login failed, try again.</asp:Label>
                                        <br /><br />
                                    </span>
                                </asp:Panel>
                                <div class="accountInfo">
                                    <p>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                                ValidationGroup="LoginUserValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </p>
                                    <p>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                                ValidationGroup="LoginUserValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </p>
                                    <p class="submitButton">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click"/>
                                    </p>
                                </div>
						    </div>
					    </div>
				    </div>
			    </div>
		    </div>
	    </div>
    <div class="block"></div>
    </div>

</asp:Content>

