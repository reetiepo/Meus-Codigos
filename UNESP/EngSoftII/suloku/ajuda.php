<html>
	<title>Jogo Suloku - Ajuda</title>
	<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen">
	<link rel="stylesheet" href="includes/cssAjuda.css" type="text/css" media="screen">
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
	<script type="text/javascript" src="includes/jsAjuda.js"></script>

<body>
	<?php
		//Indica a string de navega��o e inclui o topo
		$navegacao = "<a href='index.php'>Home</a> > <a href='ajuda.php'>Ajuda</a>";
		include "topo.php"; 
	?>

	<div id="principal">
		<div id="ajuda">
			<div id="imagens">
				<img class="imgAjuda" src="images/ajuda.png">
				<img class="inicio" src="images/screenIndex.png">
				<img class="nivel" src="images/screenNivel.png">
				<img class="jogo" src="images/screenJogo.png">
				<img class="ranking" src="images/screenEntraRanking.png">
			</div>
			<div id="instrucoes">
				O Suloku � um jogo de racioc�nio e l�gica, constitu�do de um quebra-cabe�a, que � baseado na coloca��o l�gica de n�meros. O objetivo do jogo � a coloca��o de n�meros de 1 a 9 em cada uma das c�lulas vazias da matriz 9�9.
				<br />
				<br />
				Saiba como jog�-lo:
				<br />
				<br />
				<a href="javascript: void(0);" id="inicio">&gt;&gt; Iniciando o jogo</a>
				<div class="sub inicio">
					1. Clique no bot&atilde;o Jogar para iniciar o suloku<br>
					2. Clique no bot&atilde;o Ranking para visualizar os 10 jogadores com menos tempos de cada n&iacute;vel<br>
					3. Clique no bot&atilde;o Ajuda para.. voc&ecirc; j&aacute; sabe pra que serve esse bot&atilde;o! ;)<br/>
					4. Clique no bot&atilde;o Cr&eacute;ditos para visualizar os desenvolvedores do jogo
				</div>
				<a href="javascript: void(0);" id="nivel">&gt;&gt; Escolhendo o n&iacute;vel</a>
				<div class="sub nivel">
					1. Utilize as setas do teclado para girar o cubo<br>
					2. Espere o cubo parar para escolher o n&iacute;vel<br>
					3. Clique na face correspondente ao cubo escolhido para ser redirecionado para o jogo
				</div>
				<a href="javascript: void(0);" id="jogo">&gt;&gt; Regras do jogo</a>
				<div class="sub jogo">
					1. O contador inicia-se junto com o jogo<br>
					3. Ao clicar no bot&atilde;o Pausar ser&atilde;o acrescentados 30 segundos ao contador, ele ser&aacute; pausado e uma tela cobrir&aacute; o jogo<br>
					4. Ao clicar no bot&atilde;o Verificar ser&atilde;o acrescentados 30 segundos ao contador, e os n&uacute;meros repetidos nas linhas, colunas ou quadrante ficar&atilde;o vermelhos<br>
					5. Ao clicar no bot&atilde;o Desistir o contador ser&aacute; pausado e a resposta do jogo ser&aacute; mostrada<br>
					6. Ao clicar no bot&atilde;o Novo jogo voc� ser� redirecionado para a p�gina de escolha de n�vel<br>
					7. Ao incluir o &uacute;ltimo n�mero da matriz suloku, o jogo ser&aacute; verificado, e caso haja erros uma mensagem aparecer&aacute; em vermelho abaixo da matriz, caso o jogo esteja certo voc&ecirc; poder&aacute; entrar ou n&atilde;o no ranking<br> 
				</div>
				<a href="javascript: void(0);" id="ranking">&gt;&gt; Entrando no ranking</a>
				<div class="sub ranking">
					1. Ao terminar a matriz suloku, caso o seu tempo esteja entre os 10 menores do n&iacute;vel escolhido, voc&ecirc; poder&aacute; entrar no ranking do respectivo n&iacute;vel<br>
					2. Digite seu nome e clique no bot&atilde;o Entrar para ser adicionado ao ranking do respectivo n&iacute;vel
				</div>
			</div>
		</div>
	</div>

	<?php 
		//Carrega o rodap�
		$mostraAtalhoHome = 1;
		include "rodape.php"; 
	?>
</body>
</html>