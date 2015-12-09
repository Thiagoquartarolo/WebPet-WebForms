<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sonserina.EscritorioDeProjetos.WebPet.Parceiros.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<script src="/Scripts/jquery.cycle.all.js" type="text/javascript"></script>
	<script src="/Scripts/jquery.cycle.all.js" type="text/javascript"></script>
	<script>
		$(function () {
			$('.nivoSlider_wrapper ul').cycle({
				fx: 'fade',
				speed: 2000,
				timeout: 5000,
				next: '#prox',
				prev: '#ant',
			})
		})
	</script>
	<style>
	.nivoSlider_wrapper{/*border:2px solid #000000;*/padding:10px;width:996px; height:623px;margin-top:133px;margin-left: 0px;border-radius:5px;  margin-bottom: 65px;}
	.nivoSlider_wrapper ul{margin:0;padding:0;list-style:none}
	.nivoSlider_wrapper .pag{margin:20px 0 0 0}


	#ant{float:left;margin-left: -155px;padding-top: 328px;z-index:1;display:none;}
	#prox{float:right;padding-top: 328px;margin-right: 20px;z-index:1;display:none;}


	</style>
		<a href="javascript:void(0);" id="ant"><img src="/Images/ant.png" alt="Proximo" /></a>
		<a href="javascript:void(0);" id="prox"><img src="/Images/prox.png" alt="Alternate Text" /></a>
			<div class="nivoSlider_wrapper">
				<ul>
					<li><img src="/Images/slide-1.png" alt="Alternate Text" /></li>
					<li><img src="/Images/slide-2.png" alt="Alternate Text" /></li>
					<li><img src="/Images/slide-3.png" alt="Alternate Text" /></li>
				</ul>
			</div>
</asp:Content>
