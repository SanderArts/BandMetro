<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="vote.aspx.cs" Inherits="Band._vote" %>

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
										<h3 class="letter">Vote <strong></strong></h3>
									</div>
									<div class="wrapper">
                                        <asp:Panel ID="PanelMessage" runat="server" Visible="false" >
                                            <br /><br />
                                            <asp:Label ID="LabelMsg1" runat="server" Text="" Font-Size="16px"></asp:Label>
                                            <br /><br />
                                            <asp:HyperLink ID="HyperLinkVotes" Visible="false" runat="server">Click here to view all votes.</asp:HyperLink>
                                            <br /><br /><br /><br /><br /><br />
                                        </asp:Panel>
                                        <asp:Panel ID="PanelForm" runat="server" Visible="true">
                                            <asp:Label ID="LabelVote" runat="server" Text="Do not forget to click Submit!" ForeColor="Orange"></asp:Label><br /><br />
                                            <asp:Table ID="vtable" runat="server" ></asp:Table>

                                            <div class="buttonright" >
                                                <br /><br />
                                                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" onclick="ButtonSubmit_Click" />
                                                <br /><br />
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

<asp:Table ID="Table1" runat="server">
</asp:Table>
</asp:Content>

