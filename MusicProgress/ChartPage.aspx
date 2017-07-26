<%@ Page Title="Charts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChartPage.aspx.cs" Inherits="MusicProgress.ChartPage" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Наглядный способ увидеть прогресс с помощью графиков.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>

<style>
    .container {
      display: flex;                  /* establish flex container */
      flex-direction: row;            /* default value; can be omitted */
      flex-wrap: nowrap;              /* default value; can be omitted */
      justify-content: center; /* switched from default (flex-start, see below) */
      background-color: lightyellow;
    }
</style>
<style>
    .center {
        margin: auto;
        width: 80%;
        border: 3px solid #73AD21;
        padding: 10px;
    }
</style>


    <div class="container">
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
        </div>
        <div>
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
        </div>

    </div> 
    <div >
        <asp:Panel ID="pCharts" runat="server" HorizontalAlign="Justify" ValidateRequestMode="Enabled" ViewStateMode="Disabled" Width="1300px">
        </asp:Panel>

    </div>
    
</asp:Content>