<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="settings.aspx.cs" Inherits="Band._settings" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="content"><div class="ic"></div>
	    <div class="main">
		    <div class="content-padding-2">
			    <div class="container_12">
				    <div class="wrapper">
					    <div class="grid_12">
						    <div class="padding-grid-1">
							    <h3 class="letter">Settings<strong></strong></h3>
						    </div>
						    <div class="wrapper">
                                <asp:Label ID="LabelError" ForeColor="Red" runat="server" Text="" Visible="false" ></asp:Label><br /><br />
                                <asp:Panel ID="PanelMessage" runat="server">
                                    <asp:Label ID="Label4" runat="server" Text="Your settings are saved." Font-Size="20px"></asp:Label>
                                    <br /><br /><br /><br />
                                </asp:Panel>
                                <asp:Panel ID="PanelForm" runat="server" Visible="true">
                                    <asp:label runat="server" Font-Size="14px">ID</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxUserID" Width="50" Enabled="false" runat="server" ></asp:TextBox>
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">User name</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxUsername" Width="200" Enabled="false" runat="server" ></asp:TextBox>
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">Full name</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxFullname" Width="200" Enabled="false" runat="server" ></asp:TextBox>
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">E-mail</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxMailAddress" runat="server" Width="200"></asp:TextBox>
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">Receive notification  mails</asp:label>
                                    <br />
                                    <asp:CheckBox ID="CheckBoxReceiveMails" runat="server" />
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">Password</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxPassword" Width="200" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:label runat="server" Font-Size="14px">Retype password</asp:label>
                                    <br />
                                    <asp:TextBox ID="TextBoxPassword2" Width="200" runat="server" TextMode="Password"></asp:TextBox>
                                    <br /><br /><br /><br />
                                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" onclick="ButtonSubmit_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" onclick="ButtonCancel_Click"></asp:Button>
                                    <br /><br /><br /><br /><br /><br /><br /><br />
                                </asp:Panel>

                            </div> 
                        </div> 
                    </div> 
                </div> 
            </div> 
        </div> 
    </div> 
</asp:Content>
