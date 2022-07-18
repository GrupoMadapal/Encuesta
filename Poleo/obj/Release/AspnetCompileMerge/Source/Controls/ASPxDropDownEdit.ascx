<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ASPxDropDownEdit.ascx.cs" Inherits="Poleo.Controls.ASPxDropDownEdit" %>
<%--<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>--%>
<%--<asp:Content runat="server" ContentPlaceHolderID="CustomHeadHolder">
    <script type="text/javascript">
        var textSeparator = ";";
        function OnListBoxSelectionChanged(listBox, args) {
            if (args.index == 0)
                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
            UpdateSelectAllItemState();
            UpdateText();
        }
        function UpdateSelectAllItemState() {
            IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
        }
        function IsAllSelected() {
            var selectedDataItemCount = checkListBox.GetItemCount() - (checkListBox.GetItem(0).selected ? 0 : 1);
            return checkListBox.GetSelectedItems().length == selectedDataItemCount;
        }
        function UpdateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(GetSelectedItemsText(selectedItems));
        }
        function SynchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(texts);
            checkListBox.SelectValues(values);
            UpdateSelectAllItemState();
            UpdateText(); // for remove non-existing texts
        }
        function GetSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                if (items[i].index != 0)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        }
        function GetValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="Server">
    <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="210px" runat="server" AnimationType="None">
        <DropDownWindowStyle BackColor="#EDEDED" />
        <DropDownWindowTemplate>
            <dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn"
                runat="server">
                <Border BorderStyle="None" />
                <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                <Items>
                    <dx:ListEditItem Text="(Select all)" />
                    <dx:ListEditItem Text="Chrome" Value="1" />
                    <dx:ListEditItem Text="Firefox" Value="2" />
                    <dx:ListEditItem Text="IE" Value="3" />
                    <dx:ListEditItem Text="Opera" Value="4" />
                    <dx:ListEditItem Text="Safari" Value="5" />
                </Items>
                <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
            </dx:ASPxListBox>
            <table style="width: 100%">
                <tr>
                    <td style="padding: 4px">
                        <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                            <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </DropDownWindowTemplate>
        <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />
    </aspdx:ASPxDropDownEdit>
</asp:Content>--%>
