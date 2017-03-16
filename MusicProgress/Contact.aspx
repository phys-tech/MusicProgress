<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MusicProgress.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Data:&nbsp;
                <asp:Label ID="lTotalChunks" runat="server"></asp:Label>
            </h3>
            <p>
                <asp:Label ID="lRawData" runat="server"></asp:Label>
            </p>
        </header>
    </section>
</asp:Content>