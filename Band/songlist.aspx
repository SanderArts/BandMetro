<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="songlist.aspx.cs" Inherits="Band._songlist" %>

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
										<h3 class="letter">Full <strong>List</strong></h3>
									</div>
									<div class="wrapper">
                                        <asp:Label ID="Label1" runat="server" Text="Show"></asp:Label>
                                        <asp:ListBox ID="ListBoxShow" runat="server" AutoPostBack="True" Rows="1"> 
                                            <asp:ListItem Text="All" Value="0" Selected="True" ></asp:ListItem>
                                            <asp:ListItem Text="Passed" Value="1" ></asp:ListItem>
                                            <asp:ListItem Text="Failed" Value="2" ></asp:ListItem>
                                            <asp:ListItem Text="Pending" Value="3" ></asp:ListItem>
                                        </asp:ListBox>
                                        <br /><br />
                                        <asp:Table ID="vtable" runat="server" ></asp:Table>

									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			<div class="block"></div>
			</div>

</asp:Content>

