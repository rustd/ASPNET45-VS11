<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PostDetails.aspx.cs" 
    
    
    
    Inherits="Talk_Outline4_1.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/TinyMCE/jquery.tinymce.js" type="text/javascript"></script>
    <script type="text/javascript">
        $().ready(function () {
            $('textarea').tinymce({
                script_url: '../Scripts/TinyMCE/tiny_mce.js',
                theme: "simple",
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <article class="post">
        <h2>
            <asp:Label ID="postName" runat="server"></asp:Label>
        </h2>
        <asp:Label ID="postdetails" runat="server"></asp:Label>
    </article>
    <%--Show all comments--%>
    <asp:Repeater ID="blogPostComments" runat="server" 
        
        ModelType="Talk_Outline4_1.Model.Comment"
        
        DataSourceID="showcommentsds">
        <HeaderTemplate>
            <strong>Comments for this post</strong>
        </HeaderTemplate>
        <ItemTemplate>
            <article class="post">

            <%#: Item.Author %>

            said <%# Eval("CommentText") %>
            Posted On
            <%# Eval("PublishedDate") %>
            </article>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="showcommentsds" runat="server" SelectMethod="GetComments"
        TypeName="Talk_Outline4_1.Model.ObjectDataSourceModel">
        <SelectParameters>
            <asp:RouteParameter RouteKey="PostID" Name="PostID" DbType="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <%--Insert a new comment--%>
    <asp:FormView ID="insertcomment" runat="server" DataSourceID="insertcommentds" DefaultMode="Insert"
        DataKeyNames="ID" OnItemInserted="insertcomment_ItemInserted">
        <InsertItemTemplate>
            <b>Enter Your Name</b>
            <br />
            <asp:TextBox runat="server" ID="TextBox1" Text='<%# Bind("Author") %>' />
            <br />
            <b>Enter Your Comment</b>
            <asp:TextBox runat="server" ID="commenttext" 
                                ValidateRequestMode="Disabled"
                                Text='<%# Bind("CommentText") %>' TextMode="MultiLine" />
            <br />
            <asp:LinkButton ID="LinkButton1" Text="Save" CommandName="Insert" runat="server" />
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="insertcommentds" runat="server" InsertMethod="InsertComment"
        TypeName="Talk_Outline4_1.Model.ObjectDataSourceModel">
        <InsertParameters>
            <asp:RouteParameter RouteKey="PostID" Name="PostID" DbType="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
