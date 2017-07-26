<%@ Page Title="Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataPage.aspx.cs" Inherits="MusicProgress.DataPage" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Сырые данные о результатах занятий.</h2>
                <h3><asp:Label ID="lTotalFilesNum" runat="server"></asp:Label></h3>
                <h3><asp:Label ID="lTotalChunks" runat="server"></asp:Label></h3>

            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>        
    </hgroup>

    <section class="contact">
        <header>
            <p>
                <asp:Label ID="lRawData" runat="server"></asp:Label>
            </p>
        </header>
    </section>
</asp:Content>