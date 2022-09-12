<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="crudapp.Pages.crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Admin CRUD options
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="labeltitle"></asp:Label>
        <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
            <div>
                <div class="mb-3">
                    <label class="form-label">Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbname"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Age</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbage"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbemail"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Birthdate</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbbirthdate"></asp:TextBox>
                </div>
                <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click"/>
                <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_Click"/>
                <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click"/>
                <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnBack" Text="Back" Visible="True" OnClick="BtnBack_Click"/>
            </div>
        </form>
    </div>
</asp:Content>
