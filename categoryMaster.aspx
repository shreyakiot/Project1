<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categoryMaster.aspx.cs" Inherits="Product1.categoryMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 124px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-8 col-md-offset-2">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-2">
                        <label>Category Name</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <br />
               <asp:Label runat="server" ID="lblmsg"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-2 col-md-offset-2">
                    <asp:Button runat="server" ID="btnsubmit" CssClass="btn btn-block btn-success" Text="Submit" OnClick="btnsubmit_Click" OnClientClick="btnsubmit_click" />
                </div>
                <div class="col-md-8 col-md-offset-2">
                </div>
            </div>
          
     
        </div>
        <div class="col-md-8 col-md-offset-2">
        <asp:GridView ID="Gridview" runat="server" CssClass="table" OnRowDeleting="Gridview_RowDeleting"
            OnRowEditing="Gridview_RowEditing"
            OnRowUpdating="Gridview_RowUpdating"
            OnRowCancelingEdit="Gridview_RowCancelingEdit"
            DataKeyNames="Cat_Id"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Catagory Id" DataField="Cat_Id" ReadOnly="true"/>
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="Cat_Id" runat="server" Text='<%#Eval("Cat_Id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Cat_name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Cat_name" runat="server" Text='<%#Bind("Cat_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="Remove Record" />
                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" HeaderText="Edit Record" />
            </Columns>
        </asp:GridView>
            </div>
    </form>
</body>
</html>
