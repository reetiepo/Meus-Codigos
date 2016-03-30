<html>
<title>Suloku - Jogo</title>
<head>
<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen">
<link rel="stylesheet" href="includes/cssJogo.css" type="text/css" media="screen">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script> 
<script type="text/javascript" src="includes/jsJogo.js"></script>
</head>
<body>
	<?php
		//Verifica se foi passado o nível
		if (isset($_POST["nivel"]))
			$nivel = $_POST["nivel"];
		else
			header("Location: nivel.php");

		//Escolhe de forma arbitrária qual das 10 matrizes iniciais serão apresentadas
		$k = rand(1, 10);

		//Quantidade de registros no ranking
		$qtdR = 0;
		//Array que armazenará os registros do ranking
		$dados = array("nome" => array("","","","","","","","",""),
					   "tempo" => array("","","","","","","","",""));

		//Arquivo do ranking do nível selecionado
		$arquivo = "ranking\\r".$nivel.".txt";

		//Abre o arquivo
		$fd = fopen($arquivo, "r");

		//Lê o tamanho para verificar se o arquivo não está vazio
		if(filesize($arquivo) > 0)
			$qtdR = fgets($fd);
		else
			$qtdR = 0;

		//Lê os registros salvos no arquivo do ranking
		for ($i = 0; $i < $qtdR; $i++){
			$linha = fgets($fd);
			$info = explode("/", $linha);
			$dados["nome"][$i] = $info[0];
			$dados["tempo"][$i] = $info[1];
		}

		//Fecha o arquivo
		fclose($fd);

		//Indica a string de navegação e inclui o topo
		$navegacao = "<a href='index.php'>Home</a> > <a href='nivel.php'>N&iacute;vel</a> > <a href='jogo.php?nivel=$nivel'>Jogo(N&iacute;vel $nivel)</a>";
		include "topo.php"; 
	?>

	<div id="Principal">
		<form id="form" action="ranking.php" method="POST">
			<input type="hidden" name="nivel" id="nivel" value="<?php echo $nivel; ?>" />
			<input type="hidden" name="k" id="k" value="<?php echo $k; ?>" />
			<input type="hidden" name="qtdR" id="qtdR" value="<?php echo $qtdR; ?>" />
			<input type="hidden" name="piorTempo" id="piorTempo" value="<?php if ($qtdR > 0) echo $dados["tempo"][$qtdR-1]; ?>" />
			<input type="hidden" name="hTempo" id="hTempo" />
			<div id="jogo">
				<table id="sudoku">
				<?php
					//Seleciona a matriz que será carregada
					function gerarMatriz($nivel, &$matriz, $k){

						switch ($nivel) {
							case 1: //fácil
								if ($k == 1)
									$matriz = 
										array(
											array(0,9,0,0,0,0,2,0,0),
											array(4,0,8,0,0,0,0,0,0),
											array(6,0,0,9,0,0,0,4,5),
											array(0,0,6,8,0,4,5,2,3),
											array(9,0,0,0,1,0,0,0,7),
											array(8,5,2,7,0,6,9,0,0),
											array(2,7,0,0,0,5,0,0,9),
											array(0,0,0,0,0,0,8,0,1),
											array(0,0,1,0,0,0,0,5,0));
								if ($k == 2)
									$matriz = 
										array(
											array(8,5,0,0,0,9,0,4,0),
											array(0,4,0,0,0,0,3,6,0),
											array(0,0,1,5,0,4,0,0,0),
											array(9,0,0,6,0,0,0,0,7),
											array(4,0,0,1,5,2,0,0,8),
											array(3,0,0,0,0,7,0,0,4),
											array(0,0,0,3,0,5,7,0,0),
											array(0,7,6,0,0,0,0,9,0),
											array(0,3,0,9,0,0,0,5,2));
								if ($k == 3)
									$matriz = 
										array(
											array(0,1,4,2,3,0,6,0,7),
											array(0,0,8,0,0,0,4,0,0),
											array(0,7,0,0,0,9,0,0,0),
											array(5,8,9,0,0,1,0,0,0),
											array(6,0,0,0,0,0,0,0,1),
											array(0,0,0,7,0,0,5,9,2),
											array(0,0,0,1,0,0,0,4,0),
											array(0,0,5,0,0,0,1,0,0),
											array(7,0,1,0,9,5,8,2,0));
								if ($k == 4)
									$matriz = 
										array(
											array(0,3,0,8,0,0,4,0,9),
											array(1,7,0,0,0,5,0,0,0),
											array(0,2,0,0,0,0,6,0,0),
											array(0,0,0,9,0,6,2,0,3),
											array(3,0,2,0,0,0,5,0,4),
											array(6,0,5,4,0,3,0,0,0),
											array(0,0,9,0,0,0,0,4,0),
											array(0,0,0,1,0,0,0,2,6),
											array(4,0,7,0,0,8,0,1,0));
								if ($k == 5)
									$matriz = 
										array(
											array(0,0,4,0,0,7,0,0,0),
											array(0,6,0,0,5,0,4,3,7),
											array(0,8,1,9,0,0,0,0,0),
											array(0,4,0,0,0,3,1,0,0),
											array(0,0,7,2,6,9,8,0,0),
											array(0,0,9,4,0,0,0,7,0),
											array(0,0,0,0,0,2,6,1,0),
											array(1,5,8,0,9,0,0,4,0),
											array(0,0,0,8,0,0,5,0,0));
								if ($k == 6)
									$matriz = 
										array(
											array(0,0,4,7,8,0,0,5,0),
											array(7,0,0,0,4,5,0,0,6),
											array(6,3,0,0,0,0,0,0,8),
											array(1,0,0,0,0,0,0,4,0),
											array(0,2,0,9,0,3,0,6,0),
											array(0,6,0,0,0,0,0,0,2),
											array(9,0,0,0,0,0,0,8,3),
											array(5,0,0,6,3,0,0,0,1),
											array(0,8,0,0,7,9,6,0,0));
								if ($k == 7)
									$matriz = 
										array(
											array(0,0,0,0,0,0,6,9,4),
											array(6,8,7,1,0,0,0,0,0),
											array(0,4,5,0,0,0,0,0,0),
											array(0,2,0,4,0,0,0,0,3),
											array(0,6,4,5,7,3,8,2,0),
											array(5,0,0,0,0,9,0,1,0),
											array(0,0,0,0,0,0,5,7,0),
											array(0,0,0,0,0,6,9,4,1),
											array(7,1,2,0,0,0,0,0,0));
								if ($k == 8)
									$matriz = 
										array(
											array(0,0,0,0,0,1,5,6,0),
											array(0,5,0,3,7,0,0,4,0),
											array(3,0,0,2,0,0,0,8,0),
											array(0,0,5,0,0,7,0,9,0),
											array(9,0,8,0,3,0,1,0,7),
											array(0,1,0,6,0,0,8,0,0),
											array(0,8,0,0,0,3,0,0,4),
											array(0,4,0,0,1,2,0,5,0),
											array(0,2,6,5,0,0,0,0,0));
								if ($k == 9)
									$matriz = 
										array(
											array(0,0,1,3,0,0,0,0,0),
											array(0,5,4,6,0,1,0,0,8),
											array(0,0,0,0,0,7,0,6,4),
											array(7,0,0,0,0,2,9,0,1),
											array(0,0,5,0,4,0,6,0,0),
											array(3,0,8,7,0,0,0,0,2),
											array(1,3,0,8,0,0,0,0,0),
											array(4,0,0,2,0,9,3,5,0),
											array(0,0,0,0,0,3,8,0,0));
								if ($k == 10)
									$matriz = 
										array(
											array(0,0,0,0,7,5,6,0,0),
											array(3,6,0,0,0,2,0,7,0),
											array(0,8,0,6,0,4,0,2,0),
											array(6,0,0,0,0,9,0,0,0),
											array(8,0,1,0,0,0,5,0,3),
											array(0,0,0,3,0,0,0,0,2),
											array(0,7,0,4,0,6,0,1,0),
											array(0,9,0,7,0,0,0,4,8),
											array(0,0,2,9,1,0,0,0,0));
								break;
							case 2: //médio
								if ($k == 1)
									$matriz = 
										array(
											array(0,5,9,0,3,0,0,0,0),
											array(0,0,0,9,0,0,7,0,8),
											array(3,1,0,4,2,0,0,0,0),
											array(0,0,5,2,0,1,0,0,7),
											array(0,6,0,0,4,0,0,8,0),
											array(1,0,0,3,0,7,5,0,0),
											array(0,0,0,0,7,2,0,1,5),
											array(5,0,8,0,0,3,0,0,0),
											array(0,0,0,0,5,0,8,9,0));
								if ($k == 2)
									$matriz = 
										array(
											array(0,0,0,0,2,0,3,0,0),
											array(0,8,0,3,0,1,0,7,0),
											array(9,0,0,0,0,0,0,1,0),
											array(0,9,5,2,1,0,0,0,0),
											array(0,7,2,6,8,5,4,9,0),
											array(0,0,0,0,9,3,8,2,0),
											array(0,5,0,0,0,0,0,0,7),
											array(0,3,0,5,0,7,0,8,0),
											array(0,0,1,0,4,0,0,0,0));
								if ($k == 3)
									$matriz = 
										array(
											array(8,2,0,0,0,5,0,0,4),
											array(3,0,9,0,7,8,0,0,0),
											array(1,0,0,0,0,0,0,5,0),
											array(0,8,2,6,0,0,0,7,0),
											array(5,0,0,0,2,0,0,0,6),
											array(0,3,0,0,0,7,1,2,0),
											array(0,4,0,0,0,0,0,0,7),
											array(0,0,0,7,4,0,5,0,9),
											array(7,0,0,2,0,0,0,4,1));
								if ($k == 4)
									$matriz = 
										array(
											array(0,6,9,0,0,0,0,0,0),
											array(0,5,0,0,6,7,0,0,0),
											array(0,0,3,0,4,1,6,0,0),
											array(5,0,0,0,0,9,3,0,1),
											array(8,3,0,0,0,0,0,9,2),
											array(9,0,7,3,0,0,0,0,4),
											array(0,0,8,2,5,0,1,0,0),
											array(0,0,0,6,9,0,0,7,0),
											array(0,0,0,0,0,0,4,5,0));
								if ($k == 5)
									$matriz = 
										array(
											array(6,5,0,0,0,0,0,0,2),
											array(4,9,8,0,1,2,0,0,0),
											array(0,0,0,0,8,6,9,0,0),
											array(1,0,5,7,0,0,0,0,0),
											array(0,4,0,0,3,0,0,2,0),
											array(0,0,0,0,0,8,5,0,3),
											array(0,0,4,2,5,0,0,0,0),
											array(0,0,0,4,9,0,2,3,8),
											array(2,0,0,0,0,0,0,9,5));
								if ($k == 6)
									$matriz = 
										array(
											array(0,7,0,0,6,8,5,0,0),
											array(0,0,2,0,0,0,8,0,0),
											array(3,0,8,7,0,0,0,6,1),
											array(0,0,5,9,0,0,0,1,3),
											array(0,0,0,0,0,0,0,0,0),
											array(7,3,0,0,0,2,4,0,0),
											array(9,2,0,0,0,5,3,0,7),
											array(0,0,3,0,0,0,1,0,0),
											array(0,0,7,4,8,0,0,2,0));
								if ($k == 7)
									$matriz = 
										array(
											array(7,4,0,1,0,5,3,0,0),
											array(0,0,1,6,0,0,0,0,0),
											array(3,0,6,0,0,0,1,0,2),
											array(0,1,0,0,0,0,0,0,9),
											array(5,0,0,7,3,9,0,0,1),
											array(9,0,0,0,0,0,0,7,0),
											array(4,0,2,0,0,0,7,0,8),
											array(0,0,0,0,0,2,5,0,0),
											array(0,0,5,9,0,8,0,2,3));
								if ($k == 8)
									$matriz = 
										array(
											array(0,0,0,0,0,8,0,7,3),
											array(0,5,0,4,0,0,9,0,8),
											array(8,0,0,0,6,3,2,0,0),
											array(0,0,0,0,1,6,0,0,0),
											array(0,0,6,7,0,9,8,0,0),
											array(0,0,0,8,3,0,0,0,0),
											array(0,0,1,3,8,0,0,0,4),
											array(3,0,5,0,0,1,0,8,0),
											array(6,2,0,9,0,0,0,0,0));
								if ($k == 9)
									$matriz = 
										array(
											array(0,0,0,0,0,2,3,0,1),
											array(3,0,0,0,0,0,2,5,0),
											array(0,0,0,3,0,5,0,7,0),
											array(2,5,0,8,1,0,4,0,6),
											array(0,0,0,0,0,0,0,0,0),
											array(1,0,9,0,4,3,0,8,5),
											array(0,4,0,1,0,8,0,0,0),
											array(0,7,1,0,0,0,0,0,8),
											array(6,0,8,5,0,0,0,0,0));
								if ($k == 10)
									$matriz = 
										array(
											array(0,0,0,0,8,0,0,4,7),
											array(0,0,0,5,4,7,9,0,0),
											array(0,0,4,0,6,2,1,0,0),
											array(9,0,8,0,3,0,0,0,0),
											array(7,0,0,0,0,0,0,0,3),
											array(0,0,0,0,7,0,8,0,5),
											array(0,0,2,4,1,0,5,0,0),
											array(0,0,5,7,2,6,0,0,0),
											array(6,1,0,0,5,0,0,0,0));
								break;
							case 3: //difícil
								if($k == 1)
									$matriz =
										array(
											array(7,0,0,0,0,0,8,0,0),
											array(1,4,0,0,0,2,0,0,3),
											array(0,0,6,0,8,4,0,0,1),
											array(5,0,0,4,0,0,9,0,0),
											array(6,1,0,0,9,0,0,3,8),
											array(0,0,7,0,0,6,0,0,2),
											array(2,0,0,6,4,0,1,0,0),
											array(4,0,0,5,0,0,0,2,9),
											array(0,0,9,0,0,0,0,0,4));
								if($k == 2)
									$matriz =
										array(
											array(4,9,0,5,0,0,8,0,1),
											array(0,5,0,0,6,0,0,0,0),
											array(0,0,3,1,0,4,0,5,0),
											array(0,0,2,0,0,3,5,0,0),
											array(5,0,0,0,8,0,0,0,3),
											array(0,0,8,2,0,0,4,0,0),
											array(0,8,0,9,0,5,2,0,0),
											array(0,0,0,0,7,0,0,6,0),
											array(1,0,5,0,0,6,0,9,8));
								if($k == 3)
									$matriz =
										array(
											array(1,0,0,0,3,0,0,9,0),
											array(4,9,0,6,2,0,0,0,5),
											array(0,0,5,0,9,1,0,0,4),
											array(5,0,1,0,0,0,0,7,0),
											array(0,0,0,0,5,0,0,0,0),
											array(0,2,0,0,0,0,6,0,3),
											array(2,0,0,8,1,0,5,0,0),
											array(9,0,0,0,7,4,0,8,1),
											array(0,1,0,0,6,0,0,0,7));
								if($k == 4)
									$matriz =
										array(
											array(0,0,1,5,9,3,0,8,0),
											array(0,0,0,0,4,0,6,3,0),
											array(0,8,0,0,0,6,0,0,0),
											array(0,4,9,0,0,0,0,1,3),
											array(0,3,0,0,0,0,0,7,0),
											array(7,2,0,0,0,0,4,5,0),
											array(0,0,0,9,0,0,0,4,0),
											array(0,9,7,0,2,0,0,0,0),
											array(0,5,0,1,6,7,3,0,0));
								if($k == 5)
									$matriz =
										array(
											array(0,8,0,2,7,0,0,6,5),
											array(0,0,0,8,0,0,3,0,0),
											array(0,0,2,0,0,6,0,8,9),
											array(0,9,7,0,0,0,0,3,0),
											array(2,0,0,0,8,0,0,0,6),
											array(0,4,0,0,0,0,5,2,0),
											array(3,7,0,4,0,0,2,0,0),
											array(0,0,9,0,0,5,0,0,0),
											array(4,1,0,0,2,8,0,9,0));
								if($k == 6)
									$matriz =
										array(
											array(0,0,0,5,0,0,0,0,0),
											array(0,8,3,2,7,0,0,0,4),
											array(0,0,0,3,1,4,7,8,0),
											array(0,1,0,0,0,0,0,0,2),
											array(0,2,8,0,0,0,6,9,0),
											array(3,0,0,0,0,0,0,5,0),
											array(0,6,4,9,3,7,0,0,0),
											array(9,0,0,0,6,2,3,4,0),
											array(0,0,0,0,0,1,0,0,0));
								if($k == 7)
									$matriz =
										array(
											array(0,0,0,8,3,0,0,0,5),
											array(3,0,5,4,0,0,9,8,0),
											array(0,2,0,0,7,0,0,0,6),
											array(0,0,2,0,4,0,0,0,0),
											array(0,8,0,9,0,7,0,6,0),
											array(0,0,0,0,6,0,8,0,0),
											array(2,0,0,0,9,0,0,4,0),
											array(0,9,4,0,0,1,7,0,3),
											array(7,0,0,0,5,4,0,0,0));
								if($k == 8)
									$matriz =
										array(
											array(4,0,0,0,3,0,7,0,6),
											array(0,0,0,4,6,2,0,0,0),
											array(0,0,0,0,0,0,0,8,0),
											array(0,9,3,1,0,0,2,7,8),
											array(6,0,0,0,2,0,0,0,1),
											array(7,2,1,0,0,9,6,3,0),
											array(0,5,0,0,0,0,0,0,0),
											array(0,0,0,6,5,1,0,0,0),
											array(1,0,9,0,7,0,0,0,3));
								if($k == 9)
									$matriz =
										array(
											array(1,0,0,0,0,0,0,0,5),
											array(0,5,2,9,0,6,0,8,0),
											array(0,9,0,0,1,0,3,0,0),
											array(9,6,0,7,0,0,4,0,0),
											array(0,0,0,8,0,2,0,0,0),
											array(0,0,3,0,0,4,0,5,8),
											array(0,0,9,0,7,0,0,1,0),
											array(0,4,0,3,0,9,8,7,0),
											array(7,0,0,0,0,0,0,0,3));
								if($k == 10)
									$matriz =
										array(
											array(0,0,9,0,1,8,6,0,4),
											array(0,1,0,0,0,3,7,0,0),
											array(0,0,0,0,7,0,0,1,0),
											array(0,0,7,0,0,9,2,0,0),
											array(8,2,0,0,0,0,0,5,7),
											array(0,0,3,7,0,0,8,0,0),
											array(0,6,0,0,9,0,0,0,0),
											array(0,0,2,4,0,0,0,7,0),
											array(7,0,5,1,8,0,4,0,0));
								break;
						}

					}

					//Valor que será colocado em uma posição da matriz
					$valor = 0;
					//Quadrante da posição da matriz
					$quadrante = 0;
					//Auxiliar do quadrante
					$contQuadrante = array(0,0,0,0,0,0,0,0,0);
					//Matriz que será carregada
					$matriz = 0;

					gerarMatriz($nivel, $matriz, $k);

					//Carrega a matriz e da nome às celulas da tabela que conterá a matriz para que possa ser lido no jQuery
					for ($i = 1; $i <= 9; $i++){
						echo "<tr>";
						for ($j = 1; $j <= 9; $j++){
							$valor = $matriz[($i-1)][($j-1)];

							if ($i < 4 && $j < 4)
								$quadrante = 1;
							if (($i > 3 && $i < 7) && $j < 4)
								$quadrante = 2;
							if ($i > 6 && $j < 4)
								$quadrante = 3;
							if ($i < 4 && ($j > 3 && $j < 7))
								$quadrante = 4;
							if (($i > 3 && $i < 7) && ($j > 3 && $j < 7))
								$quadrante = 5;
							if ($i > 6 && ($j > 3 && $j < 7))
								$quadrante = 6;
							if ($i < 4 && $j > 6)
								$quadrante = 7;
							if (($i > 3 && $i < 7) && $j > 6)
								$quadrante = 8;
							if ($i > 6 && $j > 6)
								$quadrante = 9;

							$contQuadrante[$quadrante-1]++;

							if ($valor == 0)
								echo "<td><input type='text' name='".$contQuadrante[$quadrante-1]."x".$quadrante."' id='".$i."x".$j."' value='' maxlength='1' onclick='this.select()' /></td>";
							else
								echo "<td><input type='text' name='".$contQuadrante[$quadrante-1]."x".$quadrante."' id='".$i."x".$j."' value='".$valor."' maxlength='1' onclick='this.select()' disabled='true' /></td>";
						}
						echo "</tr>";
					}
				?>
				</table>
				<div id="pausa">
					<input type="image" id="pausado" src="images/pausado.png">
				</div>	
				<div id="fim">
					<input type="image" id="parabens" src="images/parabens.png">
					<label id="noRanking">
						<br /><br />
						Voc&ecirc; conseguiu terminar o suloku n&iacute;vel <?php echo $nivel; ?><br /> 
						Que tal jogar novamente?<br /><br />
						<input type="button" id="novo2" value="Novo jogo" />
					</label>
					<label id="yesRanking">
						<br />
						Voc&ecirc; conseguiu um dos 10 melhores tempos do n&iacute;vel <?php echo $nivel; ?><br /> 
						Digite seu nome para entrar no nosso ranking:<br />
						<input type="text" id="nome" name="nome" maxlength="50" required/><br />
						<input type="submit" value="Enviar"/>
					</label>
				</div>		
				<div id="mensagem"></div>
			</div>
			<div id="botoes">
				<div id="tempo">
					<b>Tempo:</b> <label id="minutos">0</label>:<label id="segundos">00</label>
				</div>
				<input type="button" id="pausar" value="Pausar" title="Pausar o jogo (ATEN&Ccedil;&Atilde;O: acrescentar&aacute; 30 segundos ao seu contador!)" />
				<input type="button" id="verificar" value="Verificar" title="Verificar matriz (ATEN&Ccedil;&Atilde;O: acrescentar&aacute; 30 segundos ao seu contador!)" />
				<input type="button" id="desistir" value="Desistir" title="Desistir e ver resposta do jogo" />
				<input type="button" id="novo1" value="Novo jogo" title="Iniciar novo jogo" />
			</div>
		</form>
	</div>
	<?php
		//Carrega o rodapé
		$mostraAtalhoHome = 1;
		include "rodape.php"; 
	?>
</body>
</html>