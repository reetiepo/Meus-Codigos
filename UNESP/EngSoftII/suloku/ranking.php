<html>
	<title>Suloku - Ranking</title>
	<link rel="stylesheet" href="includes/cssPrincipal.css" type="text/css" media="screen"> 
	<link rel="stylesheet" href="includes/cssRanking.css" type="text/css" media="screen"> 
<body>
	<?php
		//Indica a string de navegação e inclui o topo
		$navegacao = "<a href='index.php'>Home</a> > <a href='ranking.php'>Ranking</a>";
		include "topo.php"; 

		//Verifica se foi passado o nível
		if (isset($_REQUEST["nivel"]))
			$nivel = $_REQUEST["nivel"];
		else
			$nivel = 0;

		//Verifica se foi passado o nome
		if (isset($_REQUEST["nome"]))
			$nome = $_REQUEST["nome"];
		else
			$nome = "";

		//Verifica se foi passado o tempo
		if (isset($_REQUEST["hTempo"])){
			$tempo = $_REQUEST["hTempo"];
			$tempoInt = str_replace(":", "", $tempo);
		}
		else
			$tempo = $tempoInt = 0;

		//Quando é consulta o tempo é 0, se o tempo for maior que 0 é para incluir novo nome ao ranking
		if ($tempoInt > 0){
			//Array que armazenará os registros do ranking
			$dados = array("nome" => array("","","","","","","","","",""),
						   "tempo" => array("","","","","","","","","",""));
			
			//Arquivo do ranking do nível selecionado
			$arquivo = "ranking\\r".$nivel.".txt";
			
			//Abre o arquivo
			$fd = fopen($arquivo, "r");

			//Lê o tamanho para verificar se o arquivo não está vazio
			if(filesize($arquivo) > 0)
				$cont = fgetss($fd);
			else
				$cont = 0;

			$qtdR = 0;

			//Lê os registros salvos no arquivo do ranking
			for ($i = 0; $i < $cont; $i++){
				$qtdR++;
				$linha = fgetss($fd);
				$info = explode("/", $linha);
				$dados["nome"][$i] = $info[0];
				$dados["tempo"][$i] = $info[1];
			}

			//Fecha o arquivo
			fclose($fd);

			$indice = $qtdR;

			//Inclui o novo nome ao ranking de forma ordenada pelo tempo
			if ($qtdR > 0){
				for ($i = 0; $i < $qtdR; $i++){
					if ($tempoInt < $dados["tempo"][$i]){
						$indice = $i;
						break;
					}
				}

				if ($qtdR < 10) 
					$qtdR = $qtdR + 1;

				for ($i = $qtdR-1; $i > $indice; $i--){
					$dados["tempo"][$i] = $dados["tempo"][$i-1];
					$dados["nome"][$i] = $dados["nome"][$i-1];
				}

				$dados["tempo"][$indice] = $tempo;
				$dados["nome"][$indice] = $nome;
			}
			else{
				$dados["tempo"][0] = $tempo;
				$dados["nome"][0] = $nome;
				$qtdR = 1;
			}

			//Abre o arquivo para atualização
			$fd = fopen($arquivo, "w");
			
			$linha = $qtdR."\r\n";
			fwrite($fd, $linha, strlen($linha));

			for ($i = 0; $i < $qtdR; $i++){
				$linha = $dados["nome"][$i]."/".$dados["tempo"][$i]."/".($i+1)."\r\n";
				fwrite($fd, $linha, strlen($linha));
			}

			fclose($fd);
		}
		else{
			$dados =
				array( 
					array("nome" => array("","","","","","","","","",""),
						   "tempo" => array("","","","","","","","","","")),
					array("nome" => array("","","","","","","","","",""),
						   "tempo" => array("","","","","","","","","","")),
					array("nome" => array("","","","","","","","","",""),
						   "tempo" => array("","","","","","","","","","")
				));

			//Carrega os dados de todos os níveis
			for($j = 0; $j < 3; $j++){
				$arquivo = "ranking\\r".($j+1).".txt";

				$fd = fopen($arquivo, "r");

				if(filesize($arquivo) > 0)
					$qtdR = fgetss($fd);
				else
					$qtdR = 0;

				for ($i = 0; $i < $qtdR; $i++){
					$linha = fgetss($fd);
					$info = explode("/", $linha);
					$dados[$j]["nome"][$i] = $info[0];
					$dados[$j]["tempo"][$i] = $info[1];
				}

				fclose($fd);
			}
		}
	?>

	<div id="principal">
		<table id="ranking">
			<?php
				//Carrega a tabela do ranking atualizado
				if ($tempoInt > 0){
					echo "<tr class='linhaTitulo'><td></td><td class='nome'>Nome</td><td class='tempo'>Tempo</td></tr>";
					for ($i = 0; $i < 10; $i++){
						echo "<tr><td class='linhaPosicao'>".($i+1)."&deg;</td><td class='nome'>".$dados["nome"][$i]."</td><td class='tempo'>".$dados["tempo"][$i]."</td></tr>";
					}
				}
				//Carrega a tabela de todos os rankings
				else{
					echo "<tr class='linhaTitulo '><td></td><td colspan='2' class='linhaNivel'>N&iacute;vel 1</td><td colspan='2' class='linhaNivel'>N&iacute;vel 2</td><td colspan='2' class='linhaNivel'>N&iacute;vel 3</td></tr>";
					echo "<tr class='linhaTitulo'><td></td><td class='nome'>Nome</td><td class='tempo'>Tempo</td><td class='nome'>Nome</td><td class='tempo'>Tempo</td><td class='nome'>Nome</td><td class='tempo'>Tempo</td></tr>";
					for ($i = 0; $i < 10; $i++){
						echo "<tr><td class='linhaPosicao'>".($i+1)."&deg;</td>";
						for ($j = 0; $j < 3; $j++){
							$nome = $dados[$j]["nome"][$i];
							$tempo = $dados[$j]["tempo"][$i];

							if(empty($nome)) $nome = "---";
							if(empty($tempo)) $tempo = "---";
							echo "<td class='nome'>".$nome."</td><td class='tempo'>".$tempo."</td>";
						}
						echo "</tr>";
					}
				}
			?>
		</table>		
	</div>
	
	<?php
		//Carrega o rodapé
		$mostraAtalhoHome = 1;
		include "rodape.php"; 
	?>
	</body>
</html>