<html>
<title>Suloku - N&iacute;vel</title>
<head>
	<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen"> 
	<link rel="stylesheet" href="includes/cssNivel.css" type="text/css" media="screen"> 
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script> 
    <script type="text/javascript" src="includes/jsNivel.js"></script>
</head>
<body>
	<?php
		//Indica a string de navegação e inclui o topo
		$navegacao = "<a href='index.php'>Home</a> > <a href='nivel.php'>N&iacute;vel</a>";
		include "topo.php"; 
	?>

	<div id="principal">
		<div id="experiment">
		    <div id="cube">
		    	<form id="form" action="jogo.php" method="POST">
			        <div class="face one">
			            <input type="image" value="3" name="nivel" src="images/III.png">
			        </div>
			        <div class="face two">
			            <input type="image" value="1" name="nivel" src="images/I.png">
			        </div>
			        <div class="face three">
			            <input type="image" value="2" name="nivel" src="images/II.png">
			        </div>
			        <div class="face four">
			            <input type="image" value="1" name="nivel" src="images/I.png">
			        </div>
			        <div class="face five">
			            <input type="image" value="2" name="nivel" src="images/II.png">
			        </div>
			        <div class="face six">
			            <input type="image" value="3" name="nivel" src="images/III.png">
			        </div>
			    </form>
		    </div>
		</div>
		<div id="info">
			Utilize as setas do teclado para girar o cubo <img src="images/setasTeclado.png" width="40"><br>
			Espere o cubo parar para escolher o n&iacute;vel
		</div>
	</div>

	<?php
		//Carrega o rodapé
		$mostraAtalhoHome = 1;
		include "rodape.php"; 
	?>
	</body>
</html>