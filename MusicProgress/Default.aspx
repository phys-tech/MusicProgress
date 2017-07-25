<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusicProgress._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                Some fucking stupid stuff.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>We suggest the following:</h2>
    <h3>
    Total files number:
        <asp:Label ID="lTotalFilesNum" runat="server"></asp:Label>    
    </h3>
    <asp:Label ID="lFilenames" runat="server"></asp:Label>
    
    </asp:Content>
