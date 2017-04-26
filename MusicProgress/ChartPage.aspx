<%@ Page Title="Charts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChartPage.aspx.cs" Inherits="MusicProgress.ChartPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>
  
    <div>
    <asp:Chart ID="MyChart" runat="server" Height="675px" Width="1357px">
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
    
</asp:Content>