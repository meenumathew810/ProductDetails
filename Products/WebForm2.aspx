<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Products.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Customer_id"
        DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display." AllowPaging="True" 
        AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" 
        PageSize="5" Width="873px"  OnRowCommand = "RunCustomMethod" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                        CommandName="myCustomUpdateMethod" Text="Update" CommandArgument = '<%# Eval("Customer_ID") %>'
                        onclientclick="return Confirm ('Are You Sure You Want To Make These Changes?')"></asp:LinkButton>

            </asp:TemplateField>
            <asp:BoundField DataField="Customer_id" HeaderText="Customer_id" ReadOnly="True"
                SortExpression="Customer_id" InsertVisible="False" />
            <asp:TemplateField HeaderText="Customer_Name" SortExpression="Customer_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Customer_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Customer_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
    </div>
    </form>
</body>
</html>
