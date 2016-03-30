<html>
	<title>Suloku - Ranking</title>
	<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen"> 
	<link rel="stylesheet" href="includes/cssRanking.css" type="text/css" media="screen"> 
<body>
	<?php
		//Indica a string de navegaÃ§Ã£o e inclui o topo
		$navegacao = "<a href='index.php'>Home</a> > <a href='creditos.php'>Cr&eacute;ditos</a>";
		include "topo.php"; 
	?>

	<div id="principal">
		<div id="creditos">
			<img src="images/logoUnesp.png"><br><br>
			Software desenvolvido para a disciplina de Engenharia de Software II.<br><br>
			
			<u>Desenvolvedores:</u><br/>
			Paula de Camargo Fiorini<br/>
			Rafael Hiroshi Hanahusa<br/>
			Renata Fonseca Tiepo<br/>
			Talissa Gaspareli de Barros<br/><br/>
			
			Prof. Wilson Yonezawa<br/><br/>
			
			Bacharelado em Sistemas de Informação<br>
			UNESP - Campus Bauru<br>
		</div>
	</div>
	
	<?php
		//Carrega o rodapÃ©
		$mostraAtalhoHome = 1;
		include "rodape.php"; 
	?>
	</body>
</html>