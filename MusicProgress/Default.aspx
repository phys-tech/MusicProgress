<%@ Page Title="Start Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusicProgress._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Добро пожаловать!</h1>
                <h2>Здесь вы оцените ваши музыкальные результаты в программе Musical Examiner!</h2>
                <h3>Загружайте файлы вида [дата]_log.txt и смотрите на свои достижения во вкладках Data, Average, Extreme, Charts. </h3>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Загружайте файлы с данными о результатах занятий:</h2>
    <h3><asp:Label ID="lDebugInfo" runat="server"></asp:Label></h3>
    <asp:FileUpload ID="MyFileUpload" runat="server" CssClass="featured" />
    <asp:Button ID="bUpload" runat="server" OnClick="bUpload_Click" Text="Upload" /><br>
    <asp:Label ID="lStatus" runat="server"></asp:Label>
</asp:Content>
