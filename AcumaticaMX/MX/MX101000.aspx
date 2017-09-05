<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="MX101000.aspx.cs" Inherits="Page_MX101000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="MX.Objects.MXSetupMaint" PrimaryView="Setup">
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="Setup">
		<Template>
            <px:PXLayoutRule runat="server" StartRow="True" StartColumn="True"></px:PXLayoutRule>
            <px:PXLayoutRule runat="server" GroupCaption="Sucursal Principal" StartColumn="True" StartGroup="True">
            </px:PXLayoutRule>
            <px:PXSelector runat="server" ID="edMainBranch" DataField="MainBranch" >
            </px:PXSelector>
            <px:PXLayoutRule runat="server" StartRow="True" StartColumn="True"></px:PXLayoutRule>
            <px:PXLayoutRule runat="server" GroupCaption="Credenciales" StartColumn="True" StartGroup="True"></px:PXLayoutRule>
            <px:PXSelector ID="edCredentials" runat="server" DataField="Credentials">
            </px:PXSelector>
            <px:PXTextEdit runat="server" ID="edCertificateNbr" DataField="CertificateNbr"></px:PXTextEdit>
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds">
		<Items>
			<px:PXTabItem Text="Tab item 1">
			</px:PXTabItem>
			<px:PXTabItem Text="Tab item 2">
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
