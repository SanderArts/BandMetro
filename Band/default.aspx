<%@ Page Title="MyBand" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="Band._default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!--==============================content================================-->
    <div class="metro-sections">
   
        <div id="section1" class="metro-section tile-span-4">
   
            <h2>Welcome</h2>
   
            <a class="tile wide imagetext wideimage bg-color-blue" href="./songlistajax.aspx">
                <div class="image-wrapper">
                <img src="img/headset.png" alt=""/>
                </div>
                <div class="textover-wrapper bg-color-blueDark">
                <div class="text2">Songs</div>
                </div>
            </a>
   
            <a class="tile app bg-color-blue" href="./shortsonglist.aspx">
                <div class="image-wrapper">
                <img src="img/my apps.png" alt=""/>
                </div>
                <span class="app-label">Short list</span>
            </a>

            <a class="tile wide imagetext wideimage bg-color-blue" href="./addsong.aspx">
                <div class="image-wrapper">
                <img src="img/addsong.png" alt=""/>
                </div>
                <div class="textover-wrapper bg-color-blueDark">
                <div class="text2">Add Song</div>
                </div>
            </a>
   
   
            <a class="tile app bg-color-blue" href="./tableinfo.aspx">
                <div class="image-wrapper">
                <img src="img/regedit.png" alt=""/>
                </div>
                <span class="app-label">Admin</span>
            </a>
   
        </div>
   
<%--        <div id="section2" class="metro-section tile-span-4">
   
            <h2>Restricted</h2>
   
            <a class="tile wide imagetext bg-color-blueDark" href="./shortsonglist.aspx">
                <div class="image-wrapper">
                <img src="img/My Apps.png" alt="" />
                </div>
                <span class="app-label">Songs</span>
            </a>
   
            <a class="tile app bg-color-orange" href="./addsong.aspx">
                <img src="img/RegEdit.png" alt="" />
                <div class="image-wrapper">
                </div>
                <span class="app-label">Add</span>
            </a>
   
            <a class="tile app bg-color-red" href="#l">
                <div class="image-wrapper">
                <img src="img/Devices.png" alt="" />
                </div>
                <span class="app-label">Vote</span>
            </a>
   
        </div>--%>
   
        <!--<div id="section3" class="metro-section tile-span-2">-->
            <!--<h2>Category 3</h2>-->
            <!--<div class="tile tile-double bg-color-blue">-->
                <!--<div class="tile-icon-large">-->
                <!--<img src="img/Live%20SkyDrive.png" />-->
                <!--</div>-->
                <!--<span class="tile-label">Live SkyDrive</span>-->
            <!--</div>-->
            <!--<div class="tile bg-color-blueDark">-->
                <!--<div class="tile-icon-large">-->
                <!--<img src="img/Bluetooth.png" />-->
                <!--</div>-->
                <!--<span class="tile-label">Bluetooth</span>-->
            <!--</div>-->
            <!--<div class="tile bg-color-red">-->
                <!--<div class="tile-icon-large">-->
                <!--<img src="img/Control%20Panel.png" />-->
                <!--</div>-->
                <!--<span class="tile-label">Control Panel</span>-->
            <!--</div>-->
            <!--<div class="tile bg-color-green">-->
                <!--<div class="tile-icon-large">-->
                <!--<img src="img/Signal.png" />-->
                <!--</div>-->
                <!--<span class="tile-label">WiFi Settings</span>-->
            <!--</div>-->
            <!--<div class="tile bg-color-yellow">-->
                <!--<div class="tile-icon-large">-->
                <!--<img src="img/Computer%20alt%202.png" />-->
                <!--</div>-->
                <!--<span class="tile-label">My Computer</span>-->
            <!--</div>-->
        <!--</div>-->
   
    </div>


</asp:Content>
