<?php 
	error_reporting (E_ALL & ~ E_NOTICE & ~ E_DEPRECATED);
	mysql_connect('localhost', 'root', '') or die ('Erro ao conectar');
	mysql_select_db('Sapataria') or die ('Erro ao conectar com o banco de dados');
	$idPedido = mysql_fetch_object(mysql_query("SELECT count(ped_cod)+1 as idPedido FROM Pedido"))->idPedido;
	 
	 $cli_cod = $_POST["cliente"];
	 $pag_cod = $_POST["pagamento"]; 
	 $data = $_POST["data"];
	 $desconto = $_POST["desconto"];
	 mysql_query("INSERT INTO pedido(ped_cod, cli_cod, pag_cod, ped_data, ped_desconto) VALUES ($idPedido, $cli_cod, $pag_cod, '$data', $desconto);");

	 $qtdProdutos = $_POST["qtdProdutos"];
	 for ($i = 0; $i < $qtdProdutos; $i++) {
	 	$produto = $_POST["produto$i"];
	 	$qtdProduto = $_POST["qtdProduto$i"];
	 	$precoUni = $_POST["precoUni$i"];

	 	mysql_query("INSERT INTO produtopedido(ped_cod, pro_cod, ppe_qtd, ppe_precoUni) VALUES ($idPedido, $produto, $qtdProduto, (SELECT pro_preco FROM Produto WHERE pro_cod = $produto));");
	 }

	 echo "<script>alert('Pedido realizado com sucesso!');</script>";
	 header('Location: pedido.php');
?>