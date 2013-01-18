<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="errorpage.aspx.cs" Inherits="Band.errorpage" %>

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
										<h3 class="letter">Sorry <strong></strong></h3>
									</div>
									<div class="wrapper">
                                        <asp:Panel ID="PanelMessage" runat="server" Visible="true" >
                                            <br /><br />
                                            <asp:Label ID="LabelErrorMsg" runat="server" Text="ErrorHeader" Font-Size="16px"></asp:Label>
                                            <br /><br />
                                            <asp:Label ID="LabelErrorText" runat="server" Text="ErrorText" Font-Size="12px"></asp:Label>
                                            <br /><br /><br /><br /><br /><br />
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

