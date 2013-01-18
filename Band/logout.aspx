<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="logout.aspx.cs" Inherits="Band._logout" %>

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
							    <h3 class="letter">Log <strong>out</strong></h3>
						    </div>
                            <br /><br /><br /><br />
						    <div class="wrapper">
                                <asp:Panel ID="PanelMessage" runat="server">
                                    <asp:Label ID="Label4" runat="server" Text="You have succesfully logged out." Font-Size="20px"></asp:Label>
                                    <br /><br />
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="./default.aspx">&lt;&nbsp;Main menu</asp:HyperLink>
                                </asp:Panel>
                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                            </div> 
                        </div> 
                    </div> 
                </div> 
            </div> 
        </div> 
    </div> 
</asp:Content>
