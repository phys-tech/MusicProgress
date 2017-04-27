<%@ Page Title="Charts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ChartPage.aspx.cs" Inherits="MusicProgress.ChartPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>
  
    <div>
    <asp:Chart ID="MyChart" runat="server" Height="675px" Width="1357px">
        <Series>
            <asp:Series Name="Series1" ChartType="StackedColumn" LabelAngle="45"></asp:Series>
            <asp:Series Name="Series2" ChartArea="ChartArea1" ChartType="StackedColumn" LabelToolTip="e56yrt" LegendText="4w57yrtyety" LegendToolTip="6w456"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False" TextOrientation="Rotated90">
                    <LabelStyle Angle="90" />
                </AxisX>
                <AxisX2 TextOrientation="Rotated90">
                </AxisX2>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>


    </div>
    
</asp:Content>