<%@ Page Title="Charts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChartPage.aspx.cs" Inherits="MusicProgress.ChartPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    
    <div>
    <p>WTF man, where's the stuff?</p>
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


    </div>
    
</body>
</html>
</asp:Content>