<%@ Page Title="Average!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AveragePage.aspx.cs" Inherits="MusicProgress.AveragePage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>

    <asp:Panel ID="Panel1" runat="server" Height="1028px">
    </asp:Panel>

    <asp:Chart ID="MyChart" runat="server">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <Series>
            <asp:Series Name="Series2">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Table ID="Table1" runat="server" Height="89px" Width="130px">
    </asp:Table>

    <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/AveragePage.aspx">Average</a></li>
            <li><a runat="server" href="DataPage.aspx">Data</a></li>
        </ul>
    </aside>
</asp:Content>