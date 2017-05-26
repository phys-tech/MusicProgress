<%@ Page Title="Charts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChartPage.aspx.cs" Inherits="MusicProgress.ChartPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>
  
    <div>
            <asp:Calendar ID="cdStartDate" runat="server" BackColor="White" BorderColor="#999999" Caption="Дата начала" CellPadding="4" DayNameFormat="Shortest" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="cdStartDate_SelectionChanged" ToolTip="Выберите дату начала графиков" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Calendar ID="cdEndDate" runat="server" BackColor="White" BorderColor="#999999" Caption="Дата конца" CellPadding="4" DayNameFormat="Shortest" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="cdEndDate_SelectionChanged" ToolTip="Выберите дату конца графиков" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        <asp:Panel ID="pCharts" runat="server" Height="1222px">
        </asp:Panel>

    </div>
    
</asp:Content>