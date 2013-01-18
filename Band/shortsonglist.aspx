<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="shortsonglist.aspx.cs" Inherits="Band._shortsonglist" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!--==============================content================================-->

    <div id="content-filters" class="row-fluid">
        <div class="span12">
            <ul class="nav nav-pills">
                <li class="dropdown">
                <a class="dropdown-toggle accent-color" data-toggle="dropdown" href="#">
                    Filter
                    <b class="caret" ></b>
                </a>
                    <asp:ListBox ID="ListBoxShow" runat="server" AutoPostBack="True" Rows="1" class="dropdown-menu"> 
                        <asp:ListItem Text="All" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Passed" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Failed/Pending" Value="2" ></asp:ListItem>
                    </asp:ListBox>
                </li>
            </ul>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">

            <asp:Table ID="vtable" class="table table-condensed" runat="server" Width="100%" CellPadding="3"></asp:Table>

		</div>
	</div>

    <footer class="win-ui-dark win-commandlayout navbar-fixed-bottom">
      <div class="container">
         <div class="row">
            <div class="span6 align-left">

                <a class="button win-command" href="./addsong.aspx">
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xe03e;</span>
                  <span class="win-label">Add</span>
               </button>
               </a> 
<%--   
               <hr class="win-command" />
   
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xe125;</span>
                  <span class="win-label">Reload</span>
               </button>
--%>
            </div>
<%--            <div class="span6 align-right">
               <button class="win-command">
                  <span class="win-commandimage win-commandring">&#xE001;</span>
                  <span class="win-label">Delete</span>
               </button>
            </div>--%>
         </div>
      </div>
   </footer>   <div id="charms" class="win-ui-dark">
    </div>
</asp:Content>

