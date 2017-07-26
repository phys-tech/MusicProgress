<%@ Page Title="Average" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AveragePage.aspx.cs" Inherits="MusicProgress.AveragePage" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Средний результат по каждому типу занятий.</h2>
                <h3><asp:Label ID="lAveragePacks" runat="server"></asp:Label></h3>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>

    <asp:Panel ID="pAverageData" runat="server">
    </asp:Panel>

    <aside>
        <h3>Quick links</h3>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="DataPage.aspx">Data</a></li>
            <li><a runat="server" href="AveragePage.aspx">Average</a></li>
            <li><a runat="server" href="ExtremePage.aspx">Extreme</a></li>
            <li><a runat="server" href="ChartPage.aspx">Chart</a></li>
        </ul>
    </aside>
</asp:Content>