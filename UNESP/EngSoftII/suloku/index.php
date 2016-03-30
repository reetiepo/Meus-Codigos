<!DOCTYPE html>
<html>
	<title>Suloku - Home</title>
	<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen"> 
	<body>
		<?php
			//Indica a string de navegação e inclui o topo
			$navegacao = "<a href='index.php'>Home</a>";
			include "topo.php"; 
		?>

		<div id="principal">
			<div class="botao">
				<a href="nivel.php">
					<img src="images/botaoJogar.png">
				</a>
			</div>
			<div class="botao">
				<a href="ajuda.php">
					<img src="images/botaoAjuda.png">
				</a>
			</div>
			<div class="botao">
				<a href="ranking.php">
					<img src="images/botaoRanking.png">
				</a>
			</div>
			<div class="botao">
				<a href="creditos.php">
					<img src="images/botaoCreditos.png">
				</a>
			</div>
		</div>

		<?php
			//Carrega o rodapé
			$mostraAtalhoHome = 0;
			include "rodape.php"; 
		?>
	</body>
</html>