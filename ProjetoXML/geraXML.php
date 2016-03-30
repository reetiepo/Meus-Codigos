<?php 
	error_reporting (E_ALL & ~ E_NOTICE & ~ E_DEPRECATED);
	mysql_connect('localhost', 'root', '') or die ('Erro ao conectar');
	mysql_select_db('Sapataria') or die ('Erro ao conectar com o banco de dados');
	 
	$tipoRel = $_POST["tipoRelatorio"];
	$dataInicio = $_POST["dataInicio"];
	$dataFim = $_POST["dataFim"];

	$datasValidas = ($dataInicio !== "" && $dataFim !== "");

	if ($datasValidas) {
		$dataInicio = date("Y-m-d", strtotime($dataInicio));
		$dataFim = date("Y-m-d", strtotime($dataFim));
	}

	$xml = "<?xml version='1.0' encoding='ISO-8859-1' ?> \n<?xml-stylesheet href='sapataria.xsl' type='text/xsl' ?>\n<!DOCTYPE sapataria SYSTEM 'sapataria.dtd'>\n\n";

	$xml .= "<sapataria>\n";
	$xml .= "\t<sobre>\n";
	$xml .= "\t\t<nome>Sapatos Maneiros</nome>\n";
	$xml .= "\t\t<site>www.sapatosmaneiros.com.br</site>\n";
	$xml .= "\t</sobre>\n";
	switch($tipoRel) {
		// Clientes por quantidade de pedidos
		case 1:
			$select = mysql_query("SELECT c.cli_nome, COUNT(p.ped_cod) as qtdPedido FROM pedido as p INNER JOIN cliente AS c ON p.cli_cod = c.cli_cod GROUP BY c.cli_nome ORDER BY qtdPedido DESC");
			$xml .= "\t<tituloGrafico>Clientes por quantidade de pedidos</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->cli_nome</titulo>\n";
				$xml .= "\t\t<valor>$result->qtdPedido</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
		// Clientes por valor gasto
		case 2:
			$select = mysql_query("SELECT c.cli_nome, ROUND(SUM(pp.ppe_precoUni)-p.ped_desconto,2) AS valorPedido FROM pedido AS p INNER JOIN Cliente AS c ON p.cli_cod = c.cli_cod  INNER JOIN produtopedido AS pp ON p.ped_cod = pp.ped_cod GROUP BY c.cli_nome ORDER BY valorPedido DESC");
			$xml .= "\t<tituloGrafico>Clientes por valor gasto</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->cli_nome</titulo>\n";
				$xml .= "\t\t<valor>$result->valorPedido</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
		// Produtos mais vendidos
		case 3:
			if ($datasValidas)
				$select = mysql_query("SELECT pp.pro_nome, count(pp.ppe_qtd) AS qtdVendida FROM produtopedido AS pp INNER JOIN pedido AS p ON pp.ped_cod = p.ped_cod WHERE p.ped_data BETWEEN '$dataInicio' AND '$dataFim' GROUP BY pp.pro_nome ORDER BY qtdVendida DESC");
			else
				$select = mysql_query("SELECT pro_nome, count(ppe_qtd) AS qtdVendida FROM produtopedido GROUP BY pro_nome ORDER BY qtdVendida DESC");
			$xml .= "\t<tituloGrafico>Produtos mais vendidos</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->pro_nome</titulo>\n";
				$xml .= "\t\t<valor>$result->qtdVendida</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
        // Categorias mais vendidas
		case 4:
			if ($datasValidas)
				$select = mysql_query("SELECT cp.cpr_tipo, count(pp.ppe_qtd) AS qtdVendida FROM categoriaproduto AS cp INNER JOIN produto AS pr ON cp.cpr_cod = pr.cpr_cod INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod INNER JOIN pedido AS p ON pp.ped_cod = p.ped_cod WHERE p.ped_data BETWEEN '$dataInicio' AND '$dataFim' GROUP BY cp.cpr_tipo ORDER BY qtdVendida DESC ");
			else
				$select = mysql_query("SELECT cp.cpr_tipo, count(pp.ppe_qtd) AS qtdVendida FROM categoriaproduto AS cp INNER JOIN produto AS pr ON cp.cpr_cod = pr.cpr_cod INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod GROUP BY cp.cpr_tipo ORDER BY qtdVendida DESC ");
			$xml .= "\t<tituloGrafico>Categorias mais vendidas</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->cpr_tipo</titulo>\n";
				$xml .= "\t\t<valor>$result->qtdVendida</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
		// Tamanho de produtos mais vendidos
		case 5:
			if ($datasValidas)
				$select = mysql_query("SELECT pr.pro_tamanho, count(pp.ppe_qtd) AS qtdVendida FROM produto AS pr INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod INNER JOIN pedido AS p ON pp.ped_cod = p.ped_cod WHERE p.ped_data BETWEEN '$dataInicio' AND '$dataFim' GROUP BY pr.pro_tamanho ORDER BY qtdVendida DESC");
			else
				$select = mysql_query("SELECT pr.pro_tamanho, count(pp.ppe_qtd) AS qtdVendida FROM produto AS pr INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod GROUP BY pr.pro_tamanho ORDER BY qtdVendida DESC");
			$xml .= "\t<tituloGrafico>Tamanho de produtos mais vendidos</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->pro_tamanho</titulo>\n";
				$xml .= "\t\t<valor>$result->qtdVendida</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
		// Cores de produtos mais vendidos
		case 6:
			if ($datasValidas)
				$select = mysql_query("SELECT pr.pro_cor, count(pp.ppe_qtd) AS qtdVendida FROM produto AS pr INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod INNER JOIN pedido AS p ON pp.ped_cod = p.ped_cod WHERE p.ped_data BETWEEN '$dataInicio' AND '$dataFim' GROUP BY pr.pro_cor ORDER BY qtdVendida DESC");
			else
				$select = mysql_query("SELECT pr.pro_cor, count(pp.ppe_qtd) AS qtdVendida FROM produto AS pr INNER JOIN produtopedido AS pp ON pr.pro_cod = pp.pro_cod GROUP BY pr.pro_cor ORDER BY qtdVendida DESC");
			$xml .= "\t<tituloGrafico>Cores de produtos mais vendidos</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->pro_cor</titulo>\n";
				$xml .= "\t\t<valor>$result->qtdVendida</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
		// Meios de pagamentos mais utilizados
		case 7:
			if ($datasValidas)
				$select = mysql_query("SELECT pa.pag_tipo, count(p.pag_cod) AS vezesUtilizado FROM pagamento AS pa INNER JOIN pedido AS p ON pa.pag_cod = p.pag_cod WHERE p.ped_data BETWEEN '$dataInicio' AND '$dataFim' GROUP BY pa.pag_tipo ORDER BY vezesUtilizado DESC");
			else
				$select = mysql_query("SELECT pa.pag_tipo, count(p.pag_cod) AS vezesUtilizado FROM pagamento AS pa INNER JOIN pedido AS p ON pa.pag_cod = p.pag_cod GROUP BY pa.pag_tipo ORDER BY vezesUtilizado DESC");
			$xml .= "\t<tituloGrafico>Meios de pagamentos mais utilizados</tituloGrafico>\n";
			while($result = mysql_fetch_object($select)){
				$xml .= "\t<dados>\n";
				$xml .= "\t\t<titulo>$result->pag_tipo</titulo>\n";
				$xml .= "\t\t<valor>$result->vezesUtilizado</valor>\n";
				$xml .= "\t</dados>\n";
			}
			break;
	}

	$xml .= "</sapataria>";

	$arquivo = fopen('sapataria.xml', 'w');
	fwrite($arquivo, $xml); 

	$arquivo = fclose($arquivo);

	header('Location: sapataria.xml');
	exit;
?>