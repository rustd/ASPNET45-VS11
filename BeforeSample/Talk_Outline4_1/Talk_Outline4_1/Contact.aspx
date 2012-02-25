<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="Talk_Outline4_1.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <article class="contact">
        <header>
            <h3>
                Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span> <span>425.555.0100</span>
        </p>
        <p>
            <span class="label">After Hours:</span> <span>425.555.0199</span>
        </p>
    </article>
    <article class="contact">
        <header>
            <h3>
                Email:</h3>
        </header>
        <p>
            <span class="label">Work:</span> <span><a href="mailto:pranav.rastogi@microsoft.com">
                pranav.rastogi@microsoft.com</a></span>
        </p>
        <header>
            <h3>
                Twitter:</h3>
        </header>
        <p>
            <span><a href="http://www.twitter.com">@rustd</a></span>
        </p>
    </article>
    <article class="contact">
        <header>
            <h3>
                Address:</h3>
        </header>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399
        </address>
    </article>
</asp:Content>
