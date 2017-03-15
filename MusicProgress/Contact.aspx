<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MusicProgress.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h2>Total file number: <asp:Label ID="TotalFilesNum" runat="server"></asp:Label></h2>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </header>
    </section>

    <section class="contact">
        <header>
            <h3>Dates:</h3>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </p>
        </header>
    </section>
</asp:Content>