<!DOCTYPE html>
<html>
<head>
	<title>PEDIDO</title>
</head>
<body>
<?php 
	error_reporting (E_ALL & ~ E_NOTICE & ~ E_DEPRECATED);
	mysql_connect('localhost', 'root', '') or die ('Erro ao conectar');
	mysql_select_db('Sapataria') or die ('Erro ao conectar com o banco de dados');
	$clientes = mysql_query("SELECT cli_cod, cli_nome FROM Cliente");
	$produtos = mysql_query("SELECT pro_cod, pro_nome, pro_cor, pro_tamanho, pro_preco FROM Produto");
	$pagamentos = mysql_query("SELECT pag_cod, pag_tipo FROM Pagamento");
?>
	<form id='formPedido' method='post' action='salvarpedido.php'>
		<select id='cliente' name='cliente'>
			<?php
				while($result = mysql_fetch_object($clientes)){
					echo "<option value='$result->cli_cod'>$result->cli_nome</option>";
				}
				$qtdProdutos = rand(1, 10);
				echo "<input type='hidden' name='qtdProdutos' id='qtdProdutos' value='$qtdProdutos' />";
			?>
		</select>
		<br /><br />
		<label>Produto(s)</label>
		<br />
		<?php
			$prods = "";
			while($result = mysql_fetch_object($produtos)){
				$prods = $prods."<option value='$result->pro_cod'>$result->pro_nome - $result->pro_cor - $result->pro_tamanho</option>";
			}

			for ($i = 0; $i < $qtdProdutos; $i++) {
				echo "<select id='produto$i' name='produto$i'>$prods</select>";
				echo "<select id='qtdProduto$i' name='qtdProduto$i'>
					<option value='1'>1</value>
					<option value='2'>2</value>
					<option value='3'>3</value>
				</select><br />";
			}
		?>
		<br /><br />
		<label for='pagamento'>Pagamento</label>
		<select id='pagamento' name='pagamento'>
			<?php
				while($result = mysql_fetch_object($pagamentos)){
					echo "<option value='$result->pag_cod'>$result->pag_tipo</option>";
				}
			?>
		</select>
		<br /><br/>
		<label for='data'>Data</label>
		<input type='text' id='data' name='data' />
		<br /><br />
		<label for='desconto'>Desconto R$</label>
		<input type='text' id='desconto' name='desconto' />
		<br /><br/>
		<input type='submit' value='Fazer pedido' />
	</form>
</body>
</hmtl>