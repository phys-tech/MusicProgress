<%@ Page Title="Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataPage.aspx.cs" Inherits="MusicProgress.DataPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Full loaded with raw data.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>&nbsp;<asp:Label ID="lTotalChunks" runat="server"></asp:Label>
            </h3>
            <p>
                <asp:Label ID="lRawData" runat="server"></asp:Label>
            </p>
        </header>
    </section>
</asp:Content>