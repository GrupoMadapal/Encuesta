<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Pag_SEF.aspx.cs" Inherits="Poleo.Pages.Pag_SEF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">   

    <table style="width:100%;">
        

        <tr id="rowEditing" runat="server" visible="false">
            <td>      
                <asp:DropDownList ID="cmbSearching" runat="server" ForeColor="Black" ValidationGroup="groupCheckingE"> </asp:DropDownList> 
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" ValidationGroup="groupChecking" OnClick="btnSearch_Click" />

        <asp:GridView ID="grdRegister" runat="server" AutoGenerateColumns="false" DataKeyNames="IDMotorcycle" Visible="false"
                    BorderColor="White" RowStyle-BorderColor="White" BorderWidth="4px" Width="100%" RowStyle-BorderWidth="3px" ShowFooter="true"
                    OnRowDataBound="grdRegister_RowDataBound" OnRowCommand="grdRegister_RowCommand" OnRowEditing="grdRegister_RowEditing" 
                    OnRowUpdating="grdRegister_RowUpdating" OnRowCancelingEdit="grdRegister_RowCancelingEdit" OnRowDeleting="grdRegister_RowDeleting">
            <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:strText, strYear %>" HeaderStyle-BorderColor="White" 
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">   

                            <EditItemTemplate>
                                <asp:TextBox ID="txtYear" runat="server" ValidationGroup="groupCheckingE" MaxLength="4" ForeColor="Black" Width="90px" Text='<%# Bind("Year")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="txtYear" ErrorMessage="*" CssClass="LabelRed" 
                                    ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" ValidationGroup="groupCheckingE"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                                
                           
                            <ItemTemplate>
                                

                                <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>' CssClass="LabelWhite"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:strText, strModel %>" HeaderStyle-BorderColor="White" 
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">
                           
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbModel" runat="server" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvModel" runat="server" ControlToValidate="cmbModel" ErrorMessage="*" CssClass="LabelRed" 
                                    ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" ValidationGroup="groupCheckingE"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hfdIdModel" runat="server" Value='<%# Bind("Model") %>' />
                            </EditItemTemplate>
                            <ItemTemplate> 
                                
                            
                              
                                
                                 
                                <asp:Label ID="lblModel" runat="server" Text='<%# Bind("Model") %>' CssClass="LabelWhite"></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="<%$ Resources:strText, strSerial %>" HeaderStyle-BorderColor="White" 
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">
                            
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSerial" runat="server" ValidationGroup="groupCheckingE" MaxLength="17" Width="150px" ForeColor="Black" Text='<%# Bind("Serial") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSerial" runat="server" ControlToValidate="txtSerial" ErrorMessage="*" CssClass="LabelRed" 
                                    ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" ValidationGroup="groupCheckingE"></asp:RequiredFieldValidator>                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                
                            
                            


                                <asp:Label ID="lblSerial" runat="server" Text='<%# Bind("Serial") %>' CssClass="LabelWhite"></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:strText, strLicenseNumberPlate %>" HeaderStyle-BorderColor="White"
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">

                            <EditItemTemplate>
                                <asp:TextBox ID="txtLicenseNumberPlate" runat="server" Width="100px" MaxLength="6" ForeColor="Black" ValidationGroup="groupCheckingE" Text='<%# Bind("LicenseNumberPlate") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLicenseNumberPlate" runat="server" ControlToValidate="txtLicenseNumberPlate" ErrorMessage="*" CssClass="LabelRed" 
                                    ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" ValidationGroup="groupCheckingE"></asp:RequiredFieldValidator> 
                            </EditItemTemplate>
                            <ItemTemplate>
                                
                            
                              


                                <asp:Label ID="lblLicenseNumberPlate" runat="server" Text='<%# Bind("LicenseNumberPlate") %>' CssClass="LabelWhite"></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:strText, strStore %>" HeaderStyle-BorderColor="White"
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite" >
                            
                            <EditItemTemplate>
                                 <asp:DropDownList ID="cmbNumberStore" runat="server" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvNumberStore" runat="server" ControlToValidate="cmbNumberStore" ErrorMessage="*" ValidationGroup="groupCheckingE"
                                    CssClass="LabelRed" ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hfdIdNumberStore" runat="server" Value='<%# Bind("NumberStore") %>' />
                            
                            </EditItemTemplate>
                             <ItemTemplate>      
                               
                                                     
                            
                            
                                <asp:Label ID="lblNumberStore" runat="server" Text='<%# Bind("NumberStore") %>' CssClass="LabelWhite"></asp:Label>
                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="<%$ Resources:strText, strNumEco %>" HeaderStyle-BorderColor="White" 
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNumEco" runat="server" ValidationGroup="groupCheckingE" ForeColor="Black" MaxLength="15" Width="90px" Text='<%# Bind("NumEco") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumEco" runat="server" ControlToValidate="txtNumEco" ErrorMessage="*" CssClass="LabelRed" 
                                    ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" ValidationGroup="groupCheckingE"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                             <ItemTemplate>                  
                            
                           
                                
                            
                            
                                <asp:Label ID="lblNumEco" runat="server" Text='<%# Bind("NumEco") %>' CssClass="LabelWhite"></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         

                        <asp:TemplateField HeaderText="<%$ Resources:strText, strLocation %>" HeaderStyle-BorderColor="White"
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite" >
                          
                            <EditItemTemplate>
                                 <asp:DropDownList ID="cmbLocation" runat="server" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="cmbLocation" ErrorMessage="*" ValidationGroup="groupCheckingE"
                                    CssClass="LabelRed" ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                             <ItemTemplate>
                               
                                
                            
                            
                                
                            
                            
                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("Location") %>' CssClass="LabelWhite"></asp:Label>
                                <asp:HiddenField ID="hfdIDLocation" runat="server" Value='<%# Bind("Location") %>' />
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:strText, strStatus %>" HeaderStyle-BorderColor="White"
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite" >

                            <EditItemTemplate>
                                 <asp:DropDownList ID="cmbStatus" runat="server" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="cmbStatus" ErrorMessage="*" ValidationGroup="groupCheckingE"
                                    CssClass="LabelRed" ToolTip="<%$ Resources:strText, msgRequiredField %>" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hfdIdStatus" runat="server" Value='<%# Bind("Status") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                               
                            
                            
                                
                            
                            
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="LabelWhite"></asp:Label>                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                        
                      
                        <%--Columns Edit - Delete --%>
                        <asp:TemplateField HeaderStyle-BorderColor="White" HeaderStyle-Width="50px" ItemStyle-Width="50px" FooterStyle-Width="50px"
                            HeaderStyle-BorderWidth="1px" HeaderStyle-CssClass="LabelWhite">
                           
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Images/save.png" CommandName="Update" Width="20px" Height="20px" ValidationGroup="groupCheckingE" />
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/cancel.png" CommandName="Cancel" Width="20px" Height="20px" />
                            </EditItemTemplate>
                             <ItemTemplate>

                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/pencil.png" CommandName="Edit" Width="20px" Height="20px" />

                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>  
                    </Columns>
                    <EmptyDataTemplate>
                         <label class="LabelWhite"><%= Resources.strText.msgNoRecordsFound %></label>  
                    </EmptyDataTemplate>

        </asp:GridView>

        
                <table style="width:100%; align-content:center; text-align:center;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAcept" runat="server" Text="<%$ Resources:strText, strAcept %>" Visible="True" OnClick="btnAcept_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:strText, strClose %>" Visible="True" OnClick="btnClose_Click" />
                        </td>
                    </tr>
                </table>
            

        
                <asp:Label ID="lblError" runat="server" CssClass="LabelRed"></asp:Label>
          

    </td>
    </tr>

        <tr id="rowRegister" runat="server" visible="false" style="margin-bottom:5px;">
            <td>
               
                            
                   <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <%--<div class="pr-wrap">--%>
                                <div class="pass-reset">
                                    <asp:Label runat="server" ID="lblYear" Text="Año:" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>                                    
                                    
                                    <asp:TextBox ID="txtYear" runat="server" Width="150px" MaxLength="4" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE" ></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvYear2" runat="server" ControlToValidate="txtYear" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revYear2" runat="server" ControlToValidate="txtYear" ErrorMessage="*Ingrese Valores Numericos" 
                                    ForeColor="Red" ValidationExpression="^(201[5-9]|202[0-6])$" Display="Dynamic">
                                    </asp:RegularExpressionValidator>
                                    <br />
                                     <asp:Label runat="server" ID="lblModel" Text="Modelo:" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>                                     
                                    
                                    <asp:DropDownList ID="cmbModel" runat="server" Width="150px" Height="25px" ForeColor="Black" ValidationGroup="groupCheckingE"> 
                                    </asp:DropDownList> 

                                    <asp:RequiredFieldValidator ID="rfvModel2" runat="server" ControlToValidate="cmbModel" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label runat="server" ID="lblSerial" Text="Serial:" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>
                                    
                                    <asp:TextBox ID="txtSerial" runat="server" Width="150px" MaxLength="17" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="revSerial2" runat="server" ControlToValidate="txtSerial" ErrorMessage="Escribir letras en Mayusculas. Total de 17 digitos" 
                                    ForeColor="Red" ValidationExpression="^[0-9|A-Z]{17}$" Display="Dynamic">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvSerial2" runat="server" ControlToValidate="txtSerial" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" ForeColor="Red"></asp:RequiredFieldValidator>                                    
                                    <br />
                                    <asp:Label runat="server" ID="lblLicenseNumberPlate" Text="Placas" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>
                                    
                                    <asp:TextBox ID="txtLicenseNumberPlate" runat="server" Width="150px" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvLicenseNumberPlate2" runat="server" ControlToValidate="txtLicenseNumberPlate" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label runat="server" ID="lblNumberStore" Text="Tienda" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>
                                    
                                    <asp:DropDownList ID="cmbNumberStore" runat="server" Width="150px" Height="25px" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE">
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvNumberStore" runat="server" ControlToValidate="cmbNumberStore" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label runat="server" ID="lblNumEco" Text="Num. Eco." Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>
                                    
                                    <asp:TextBox ID="txtNumEco" runat="server" Width="150px" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvNumEco2" runat="server" ControlToValidate="txtNumEco" ErrorMessage="*Campo Obligatorio" 
                                    ValidationGroup="groupCheckingE" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label runat="server" ID="lblLocation" Text="Ubicacion" Font-Bold ="true" Font-Size="Large" CssClass="labels"></asp:Label>
                                    
                                    <asp:DropDownList ID="cmbLocation" runat="server" Width="150px" Height="25px" CssClass="txtCSS" ForeColor="Black" ValidationGroup="groupCheckingE">
                                    </asp:DropDownList>
                                    
                                    <asp:RequiredFieldValidator ID="rfvLocation2" runat="server" ControlToValidate="cmbLocation" ErrorMessage="*Campo Obligatorio"
                                    ValidationGroup="groupCheckingE" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    <br /> 

                                     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" OnClick="cmdSave_Click" Text="Guardar" Causevalidation="true"
                                     ValidationGroup="groupCheckingE" />                                  
                                    <br id="unique"/>

                                </div>
                            </div>                            
                        </div>
                    </div>
                
                    
            </td>
        </tr>

    </table>
</asp:Content>

