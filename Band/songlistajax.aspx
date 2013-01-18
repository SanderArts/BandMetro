<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="songlistajax.aspx.cs" Inherits="Band._songlistajax" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!--==============================content================================-->

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
	<h3 class="letter">Songs<strong></strong></h3>

    <table style="width:100%;">
        <tr>
            <td style="width:50%; vertical-align:top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="content-filters" class="row-fluid" >
                            <div class="span12">
                                <ul class="nav nav-pills">
                                    <li class="dropdown">
                                        <a class="dropdown-toggle accent-color" data-toggle="dropdown" href="#">
                                            Filter
                                            <b class="caret" ></b>
                                        </a>
                                        <asp:ListBox ID="ListBoxShow" runat="server" AutoPostBack="True" class="dropdown-menu" > 
                                            <asp:ListItem Text="All" Value="0" Selected="True" ></asp:ListItem>
                                            <asp:ListItem Text="Passed" Value="1" ></asp:ListItem>
                                            <asp:ListItem Text="Failed" Value="2" ></asp:ListItem>
                                            <asp:ListItem Text="Pending" Value="3" ></asp:ListItem>
                                        </asp:ListBox>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <asp:Label ID="Label1" runat="server" Text="Click the Artist/Title to view details and vote."></asp:Label><br /><br />
                                <asp:Table ID="vtable" class="table table-condensed" runat="server" ></asp:Table>
		                    </div>
	                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

            <td style="width:50%; vertical-align:top;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Table ID="TableDetails" runat="server" ></asp:Table>
                            <asp:Panel ID="PanelDetails" runat="server">
                                <asp:Label ID="LabelVote" runat="server" Text="Vote now:" Visible="false" ></asp:Label>
                                <asp:HiddenField ID="HiddenFieldvid" runat="server" />
                                <asp:HiddenField ID="HiddenFieldArtist" runat="server" />
                                <asp:HiddenField ID="HiddenFieldTitle" runat="server" />
                                <asp:HiddenField ID="HiddenFieldFullname" runat="server" />
                                <asp:HiddenField ID="HiddenFieldEmail" runat="server" />
                                <asp:HiddenField ID="HiddenFieldPoints" runat="server" />
                                <asp:DropDownList ID="ddl" runat="server" Visible="false" 
                                 onselectedindexchanged="ddl_SelectedIndexChanged"
                                    AutoPostBack="True" Width="10">
                                </asp:DropDownList>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </td>
        </tr>
    </table>	


    
    

<%--
    <footer class="win-ui-dark win-commandlayout navbar-fixed-bottom">
      <div class="container">
         <div class="row">
            <div class="span6 align-left">
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#x0067;</span>
                  <span class="win-label">Cerca</span>
               </button>
   
               <hr class="win-command" />
   
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xe125;</span>
                  <span class="win-label">Reload</span>
               </button>
   
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xE165;</span>
                  <span class="win-label">Send Email</span>
               </button>
            </div>
            <div class="span6 align-right">
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xE001;</span>
                  <span class="win-label">Delete</span>
               </button>
   
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xe03e;</span>
                  <span class="win-label">Add</span>
               </button>
            </div>
         </div>
      </div>
   </footer>   <div id="charms" class="win-ui-dark">
   --%>


</asp:Content>

