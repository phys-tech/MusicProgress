<%@ Page Title="Average" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AveragePage.aspx.cs" Inherits="MusicProgress.AveragePage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Average results across all the trainings.</h2>
            </hgroup>
            <p>
                Some fucking stupid stuff.
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>

    <asp:Panel ID="Panel1" runat="server" Height="1028px">
    </asp:Panel>



    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Table ID="Table1" runat="server" Height="89px" Width="130px">
    </asp:Table>

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