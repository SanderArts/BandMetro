<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="addsong.aspx.cs" Inherits="Band._addsong" %>

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
										<h3 class="letter">Add new <strong>song</strong></h3>
									</div>
									<div class="wrapper">
                                        <asp:Panel ID="PanelMessage" runat="server">
                                                <asp:Label ID="Label4" runat="server" Text="Your video was " Font-Size="20px"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text=" SAVED" ForeColor="Green" Font-Size="20px"></asp:Label>
                                        </asp:Panel>

                                        <asp:Panel ID="PanelForm" runat="server">
                                            <asp:Label ID="Label6" runat="server" Text="Add a song by filling in all fields below. Provide (copy=paste) the full YouTube url from your browser."></asp:Label>
									        <br />
									        <br />
                                            <div class="userlabels" >
                                                <asp:Label ID="Label1" runat="server" Text="Artist"></asp:Label><br />
                                                <asp:TextBox ID="TextBoxArtist" runat="server" Width="316px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field" 
                                                    ControlToValidate="TextBoxArtist" ForeColor="Red"></asp:RequiredFieldValidator>
									            <br />
                                                <asp:Label ID="Label2" runat="server" Text="Song title"></asp:Label><br />
                                                <asp:TextBox ID="TextBoxTitle" runat="server" Width="316px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field" 
                                                    ControlToValidate="TextBoxTitle" ForeColor="Red"></asp:RequiredFieldValidator>
									            <br />
                                                <asp:Label ID="Label3" runat="server" Text="YouTube URL"></asp:Label><br />
                                                <asp:TextBox ID="TextBoxURL" runat="server" Width="525px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field" 
                                                    ControlToValidate="TextBoxURL" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <br /><br /><br />
                                                <asp:Button ID="Button1" runat="server" Text="ADD" onclick="Button1_Click" />
                                            </div>
                                        </asp:Panel>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			<div class="block"></div>
			</div>


</asp:Content>

