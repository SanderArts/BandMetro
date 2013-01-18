<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="tableinfo.aspx.cs" Inherits="Band._tableinfo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!--==============================content================================-->

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <h3 class="letter">Table definition: <asp:Label ID="LabelTableName" runat="server" Text=""></asp:Label></h3>

            <div id="content-filters" class="row-fluid" >
                <div class="span12">
                    <ul class="nav nav-pills">
                        <li class="dropdown">
                            <a class="dropdown-toggle accent-color" data-toggle="dropdown" href="#">
                                Filter
                                <b class="caret" ></b>
                            </a>
                            <asp:ListBox ID="ListBoxTable" runat="server" AutoPostBack="True" class="dropdown-menu" > 
                                <asp:ListItem Text="Users" Value="users" ></asp:ListItem>
                                <asp:ListItem Text="Votes" Value="votes" ></asp:ListItem>
                                <asp:ListItem Text="Videos" Value="videos" ></asp:ListItem>
                            </asp:ListBox>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <asp:Table ID="vtable" runat="server" Width="100%" CellPadding="3"></asp:Table>
		        </div>
	        </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

