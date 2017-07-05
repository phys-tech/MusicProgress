<%@ Page Title="E" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExtremePage.aspx.cs" Inherits="MusicProgress.ExtremePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Extreme</h1>
        <h2>Best and worst results of all time.</h2>
    </hgroup>
    <asp:Panel ID="pExtremeLabels" runat="server"></asp:Panel>
</asp:Content>
