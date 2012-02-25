<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="Talk_Outline4_1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content" role="main">
        <%--Display all posts--%>
        <asp:Repeater ID="BlogPosts" runat="server" DataSourceID="PostListings">
            <ItemTemplate>
                <article class="post">
                    <h2>
                        <a href="<%# Page.GetRouteUrl("Post",new { PostID= DataBinder.Eval(Container.DataItem, "ID")})%>">
                            <%# Eval("Title") %></a>
                    </h2>
                    <%# Eval("PostText") %>
                </article>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="Postlistings" runat="server" SelectMethod="GetPosts" 
        TypeName="Talk_Outline4_1.Model.ObjectDataSourceModel">
        </asp:ObjectDataSource>

        <%--Add a new post--%>
        <asp:Panel ID="InsertPostPanel" runat="server">
            <article class="post">
                <h2>
                    Insert a post</h2>
                <asp:Label Text="" runat="server" ID="errormessage" CssClass="field-validation-error" />
                <asp:FormView ID="InsertPostForm" runat="server" DataSourceID="Insertpostdatasource"
                    OnItemInserted="InsertPostForm_ItemInserted" DefaultMode="Insert">
                    <InsertItemTemplate>
                        Title:
                        <asp:TextBox runat="server" ID="Title" Text='<%# Bind("Title") %>' Columns="40" />
                        <br />
                        Text:
                        <asp:TextBox runat="server" ID="PostText" Text='<%# Bind("PostText") %>' TextMode="MultiLine"
                            Columns="40" Rows="10" />
                        <br />
                        <asp:LinkButton Text="Insert" CommandName="Insert" runat="server" />
                        <asp:LinkButton ID="Cancel" Text="Cancel" CommandName="Cancel" runat="server" />
                    </InsertItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="Insertpostdatasource" runat="server" 
                TypeName="Talk_Outline4_1.Model.ObjectDataSourceModel"
                DataObjectTypeName="Talk_Outline4_1.Model.Post" InsertMethod="InsertPost">
                </asp:ObjectDataSource>
            </article>
        </asp:Panel>
    </div>
</asp:Content>
