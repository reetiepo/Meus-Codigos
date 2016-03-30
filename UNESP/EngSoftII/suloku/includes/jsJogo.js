//Permite apenas que sejam digitados números de 1 a 9
function verificaNumero(e) {
    if (e.which != 8 && e.which != 0 && (e.which < 49 || e.which > 57)) {
        return false;
    }
}
 
//Muda a variavel dos minutos e segundos do contador
function setarTempo(pausa){
	var segundos = parseInt(document.getElementById('segundos').innerHTML);
	var minutos = parseInt(document.getElementById('minutos').innerHTML);
	var soma = 0;
	var tempo = "";

	//Se o jogo foi pausado ou verificado, adiciona 29 segundos ao tempo
	//(29 porque 1 segundo já está sendo incrementado pela função)
	if (pausa)
		soma = 29;

	if (segundos < 59){ 
    	segundos = segundos + 1 + soma;
    	if ((segundos - 60) > 0){
    		segundos = segundos - 60;
    		minutos = minutos + 1;
    	}
    }
    else{
      	segundos = soma;
      	minutos = minutos + 1;
    }
    document.getElementById('minutos').innerHTML = minutos;
    tempo = minutos;

    if (segundos < 10){
      	document.getElementById('segundos').innerHTML = "0" + segundos;
    	tempo = tempo + ":0" + segundos;
    }
    else{
      	document.getElementById('segundos').innerHTML = segundos;
    	tempo = tempo + ":" + segundos;
    }

    $("#hTempo").val(tempo);
}

//Verifica se o ranking possui menos de 10 nomes ou se o tempo é menor do que o último (no caso o pior) tempo do ranking
function verificaEntraRanking(){
	var qtdR = parseInt($("#qtdR").val());
	
	if (qtdR < 10){
		return true;
	}
	else{
	var piorTempo = parseInt($("#piorTempo").val().replace(":",""));
	var tempo = parseInt($("#hTempo").val().replace(":",""));

	if (tempo < piorTempo)
		return true;
	else 
		return false;
	}
}

//Resolve a matriz caso o jogador clique em Desistir
function resolveMatriz(){
	var matriz = 
				[[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0],
				[0,0,0,0,0,0,0,0,0]];

	var nivel = parseInt($("#nivel").val());
	var k = parseInt($("#k").val());
	var i,j;

	switch(nivel){
		case 1: //fácil
			if (k == 1)
				matriz = 
					[[1,9,5,4,6,7,2,3,8],
					[4,2,8,3,5,1,7,9,6],
					[6,3,7,9,2,8,1,4,5],
					[7,1,6,8,9,4,5,2,3],
					[9,4,3,5,1,2,6,8,7],
					[8,5,2,7,3,6,9,1,4],
					[2,7,4,1,8,5,3,6,9],
					[5,6,9,2,4,3,8,7,1],
					[3,8,1,6,7,9,4,5,2]];
			if (k == 2)
				matriz =
					[[8,5,3,7,6,9,2,4,1],
					[7,4,9,2,8,1,3,6,5],
					[6,2,1,5,3,4,8,7,9],
					[9,8,2,6,4,3,5,1,7],
					[4,6,7,1,5,2,9,3,8],
					[3,1,5,8,9,7,6,2,4],
					[2,9,4,3,1,5,7,8,6],
					[5,7,6,4,2,8,1,9,3],
					[1,3,8,9,7,6,4,5,2]];
			if (k == 3)
				matriz =
					[[9,1,4,2,3,8,6,5,7],
					[2,5,8,6,1,7,4,3,9],
					[3,7,6,5,4,9,2,1,8],
					[5,8,9,3,2,1,7,6,4],
					[6,2,7,9,5,4,3,8,1],
					[1,4,3,7,8,6,5,9,2],
					[8,6,2,1,7,3,9,4,5],
					[4,9,5,8,6,2,1,7,3],
					[7,3,1,4,9,5,8,2,6]];
			if (k == 4)
				matriz =
					[[5,3,6,8,1,2,4,7,9],
					[1,7,4,6,9,5,8,3,2],
					[9,2,8,3,7,4,6,5,1],
					[7,4,1,9,5,6,2,8,3],
					[3,9,2,7,8,1,5,6,4],
					[6,8,5,4,2,3,1,9,7],
					[2,1,9,5,6,7,3,4,8],
					[8,5,3,1,4,9,7,2,6],
					[4,6,7,2,3,8,9,1,5]];
			if (k == 5)
				matriz =
					[[5,3,4,6,2,7,9,8,1],
					[9,6,2,1,5,8,4,3,7],
					[7,8,1,9,3,4,2,6,5],
					[6,4,5,7,8,3,1,2,9],
					[3,1,7,2,6,9,8,5,4],
					[8,2,9,4,1,5,3,7,6],
					[4,9,3,5,7,2,6,1,8],
					[1,5,8,3,9,6,7,4,2],
					[2,7,6,8,4,1,5,9,3]];
			if (k == 6)
				matriz =
					[[2,1,4,7,8,6,3,5,9],
					[7,9,8,3,4,5,2,1,6],
					[6,3,5,2,9,1,4,7,8],
					[1,5,3,8,6,2,9,4,7],
					[4,2,7,9,1,3,8,6,5],
					[8,6,9,4,5,7,1,3,2],
					[9,7,6,1,2,4,5,8,3],
					[5,4,2,6,3,8,7,9,1],
					[3,8,1,5,7,9,6,2,4]];
			if (k == 7)
				matriz =
					[[2,3,1,8,5,7,6,9,4],
					[6,8,7,1,9,4,2,3,5],
					[9,4,5,6,3,2,1,8,7],
					[8,2,9,4,6,1,7,5,3],
					[1,6,4,5,7,3,8,2,9],
					[5,7,3,2,8,9,4,1,6],
					[4,9,6,3,1,8,5,7,2],
					[3,5,8,7,2,6,9,4,1],
					[7,1,2,9,4,5,3,6,8]];
			if (k == 8)
				matriz =
					[[8,7,2,9,4,1,5,6,3],
					[6,5,1,3,7,8,9,4,2],
					[3,9,4,2,5,6,7,8,1],
					[2,3,5,1,8,7,4,9,6],
					[9,6,8,4,3,5,1,2,7],
					[4,1,7,6,2,9,8,3,5],
					[5,8,9,7,6,3,2,1,4],
					[7,4,3,8,1,2,6,5,9],
					[1,2,6,5,9,4,3,7,8]];
			if (k == 9)
				matriz =
					[[6,7,1,3,8,4,2,9,5],
					[9,5,4,6,2,1,7,3,8],
					[8,2,3,9,5,7,1,6,4],
					[7,4,6,5,3,2,9,8,1],
					[2,9,5,1,4,8,6,7,3],
					[3,1,8,7,9,6,5,4,2],
					[1,3,9,8,6,5,4,2,7],
					[4,8,7,2,1,9,3,5,6],
					[5,6,2,4,7,3,8,1,9]];
			if (k == 10)
				matriz =
					[[2,1,9,8,7,5,6,3,4],
					[3,6,4,1,9,2,8,7,5],
					[7,8,5,6,3,4,9,2,1],
					[6,2,3,5,4,9,1,8,7],
					[8,4,1,2,6,7,5,9,3],
					[9,5,7,3,8,1,4,6,2],
					[5,7,8,4,2,6,3,1,9],
					[1,9,6,7,5,3,2,4,8],
					[4,3,2,9,1,8,7,5,6]];
			break;
		case 2: //médio
			if (k == 1)
				matriz =
					[[8,5,9,7,3,6,1,2,4],
					[6,2,4,9,1,5,7,3,8],
					[3,1,7,4,2,8,9,5,6],
					[4,9,5,2,8,1,3,6,7],
					[7,6,3,5,4,9,2,8,1],
					[1,8,2,3,6,7,5,4,9],
					[9,3,6,8,7,2,4,1,5],
					[5,4,8,1,9,3,6,7,2],
					[2,7,1,6,5,4,8,9,3]];
			if (k == 2)
				matriz =
					[[5,1,7,9,2,8,3,6,4],
					[6,8,4,3,5,1,2,7,9],
					[9,2,3,4,7,6,5,1,8],
					[8,9,5,2,1,4,7,3,6],
					[3,7,2,6,8,5,4,9,1],
					[1,4,6,7,9,3,8,2,5],
					[2,5,8,1,3,9,6,4,7],
					[4,3,9,5,6,7,1,8,2],
					[7,6,1,8,4,2,9,5,3]];
			if (k == 3)
				matriz =
					[[8,2,7,1,6,5,9,3,4],
					[3,5,9,4,7,8,6,1,2],
					[1,6,4,9,3,2,7,5,8],
					[9,8,2,6,5,1,4,7,3],
					[5,7,1,3,2,4,8,9,6],
					[4,3,6,8,9,7,1,2,5],
					[6,4,3,5,1,9,2,8,7],
					[2,1,8,7,4,3,5,6,9],
					[7,9,5,2,8,6,3,4,1]];
			if (k == 4)
				matriz =
					[[4,6,9,5,3,2,8,1,7],
					[2,5,1,8,6,7,9,4,3],
					[7,8,3,9,4,1,6,2,5],
					[5,2,4,7,8,9,3,6,1],
					[8,3,6,4,1,5,7,9,2],
					[9,1,7,3,2,6,5,8,4],
					[6,7,8,2,5,4,1,3,9],
					[1,4,5,6,9,3,2,7,8],
					[3,9,2,1,7,8,4,5,6]];
			if (k == 5)
				matriz =
					[[6,5,1,9,7,4,3,8,2],
					[4,9,8,3,1,2,6,5,7],
					[3,7,2,5,8,6,9,4,1],
					[1,3,5,7,2,9,8,6,4],
					[8,4,6,1,3,5,7,2,9],
					[7,2,9,6,4,8,5,1,3],
					[9,8,4,2,5,3,1,7,6],
					[5,6,7,4,9,1,2,3,8],
					[2,1,3,8,6,7,4,9,5]];
			if (k == 6)
				matriz =
					[[4,7,9,1,6,8,5,3,2],
					[1,6,2,5,3,9,8,7,4],
					[3,5,8,7,2,4,9,6,1],
					[8,4,5,9,7,6,2,1,3],
					[2,9,6,3,4,1,7,5,8],
					[7,3,1,8,5,2,4,9,6],
					[9,2,4,6,1,5,3,8,7],
					[6,8,3,2,9,7,1,4,5],
					[5,1,7,4,8,3,6,2,9]];
			if (k == 7)
				matriz =
					[[7,4,9,1,2,5,3,8,6],
					[2,5,1,6,8,3,9,4,7],
					[3,8,6,4,9,7,1,5,2],
					[8,1,7,2,5,6,4,3,9],
					[5,2,4,7,3,9,8,6,1],
					[9,6,3,8,1,4,2,7,5],
					[4,3,2,5,6,1,7,9,8],
					[6,9,8,3,7,2,5,1,4],
					[1,7,5,9,4,8,6,2,3]];
			if (k == 8)
				matriz =
					[[2,6,4,5,9,8,1,7,3],
					[1,5,3,4,7,2,9,6,8],
					[8,9,7,1,6,3,2,4,5],
					[5,8,9,2,1,6,4,3,7],
					[4,3,6,7,5,9,8,1,2],
					[7,1,2,8,3,4,5,9,6],
					[9,7,1,3,8,5,6,2,4],
					[3,4,5,6,2,1,7,8,9],
					[6,2,8,9,4,7,3,5,1]];
			if (k == 9)
				matriz =
					[[7,9,5,4,8,2,3,6,1],
					[3,8,6,9,7,1,2,5,4],
					[4,1,2,3,6,5,8,7,9],
					[2,5,7,8,1,9,4,3,6],
					[8,3,4,7,5,6,9,1,2],
					[1,6,9,2,4,3,7,8,5],
					[5,4,3,1,2,8,6,9,7],
					[9,7,1,6,3,4,5,2,8],
					[6,2,8,5,9,7,1,4,3]];
			if (k == 10)
				matriz =
					[[5,2,9,1,8,3,6,4,7],
					[1,8,6,5,4,7,9,3,2],
					[3,7,4,9,6,2,1,5,8],
					[9,6,8,2,3,5,7,1,4],
					[7,5,1,8,9,4,2,6,3],
					[2,4,3,6,7,1,8,9,5],
					[8,3,2,4,1,9,5,7,6],
					[4,9,5,7,2,6,3,8,1],
					[6,1,7,3,5,8,4,2,9]];

			break;
		case 3: //difícil
			if (k == 1)
				matriz =
					[[7,2,3,9,6,1,8,4,5],
					[1,4,8,7,5,2,6,9,3],
					[9,5,6,3,8,4,2,7,1],
					[5,8,2,4,3,7,9,1,6],
					[6,1,4,2,9,5,7,3,8],
					[3,9,7,8,1,6,4,5,2],
					[2,3,5,6,4,9,1,8,7],
					[4,6,1,5,7,8,3,2,9],
					[8,7,9,1,2,3,5,6,4]];
			if (k == 2)
				matriz =
					[[4,9,6,5,3,2,8,7,1],
					[2,5,1,8,6,7,3,4,9],
					[8,7,3,1,9,4,6,5,2],
					[9,1,2,6,4,3,5,8,7],
					[5,6,4,7,8,1,9,2,3],
					[7,3,8,2,5,9,4,1,6],
					[6,8,7,9,1,5,2,3,4],
					[3,2,9,4,7,8,1,6,5],
					[1,4,5,3,2,6,7,9,8]];
			if (k == 3)
				matriz =
					[[1,8,2,4,3,5,7,9,6],
					[4,9,7,6,2,8,1,3,5],
					[6,3,5,7,9,1,8,2,4],
					[5,4,1,3,8,6,9,7,2],
					[7,6,3,9,5,2,4,1,8],
					[8,2,9,1,4,7,6,5,3],
					[2,7,4,8,1,3,5,6,9],
					[9,5,6,2,7,4,3,8,1],
					[3,1,8,5,6,9,2,4,7]];
			if (k == 4)
				matriz =
					[[4,6,1,5,9,3,2,8,7],
					[9,7,2,8,4,1,6,3,5],
					[5,8,3,2,7,6,1,9,4],
					[6,4,9,7,5,2,8,1,3],
					[1,3,5,6,8,4,9,7,2],
					[7,2,8,3,1,9,4,5,6],
					[2,1,6,9,3,5,7,4,8],
					[3,9,7,4,2,8,5,6,1],
					[8,5,4,1,6,7,3,2,9]];
			if (k == 5)
				matriz =
					[[9,8,3,2,7,4,1,6,5],
					[1,6,4,8,5,9,3,7,2],
					[7,5,2,1,3,6,4,8,9],
					[5,9,7,6,4,2,8,3,1],
					[2,3,1,5,8,7,9,4,6],
					[6,4,8,9,1,3,5,2,7],
					[3,7,6,4,9,1,2,5,8],
					[8,2,9,3,6,5,7,1,4],
					[4,1,5,7,2,8,6,9,3]];
			if (k == 6)
				matriz =
					[[1,4,7,5,8,6,2,3,9],
					[6,8,3,2,7,9,5,1,4],
					[2,5,9,3,1,4,7,8,6],
					[4,1,5,6,9,3,8,7,2],
					[7,2,8,1,4,5,6,9,3],
					[3,9,6,7,2,8,4,5,1],
					[5,6,4,9,3,7,1,2,8],
					[9,7,1,8,6,2,3,4,5],
					[8,3,2,4,5,1,9,6,7]];
			if (k == 7)
				matriz =
					[[1,4,6,8,3,9,2,7,5],
					[3,7,5,4,2,6,9,8,1],
					[8,2,9,1,7,5,4,3,6],
					[9,6,2,5,4,8,3,1,7],
					[4,8,3,9,1,7,5,6,2],
					[5,1,7,3,6,2,8,9,4],
					[2,5,1,7,9,3,6,4,8],
					[6,9,4,2,8,1,7,5,3],
					[7,3,8,6,5,4,1,2,9]];
			if (k == 8)
				matriz =
					[[4,1,2,8,3,5,7,9,6],
					[9,7,8,4,6,2,3,1,5],
					[3,6,5,9,1,7,4,8,2],
					[5,9,3,1,4,6,2,7,8],
					[6,8,4,7,2,3,9,5,1],
					[7,2,1,5,8,9,6,3,4],
					[8,5,6,3,9,4,1,2,7],
					[2,3,7,6,5,1,8,4,9],
					[1,4,9,2,7,8,5,6,3]];
			if (k == 9)
				matriz =
					[[1,8,4,2,3,7,9,6,5],
					[3,5,2,9,4,6,1,8,7],
					[6,9,7,5,1,8,3,4,2],
					[9,6,8,7,5,3,4,2,1],
					[4,1,5,8,6,2,7,3,9],
					[2,7,3,1,9,4,6,5,8],
					[8,3,9,6,7,5,2,1,4],
					[5,4,1,3,2,9,8,7,6],
					[7,2,6,4,8,1,5,9,3]];
			if (k == 10)
				matriz =
					[[3,7,9,5,1,8,6,2,4],
					[6,1,4,9,2,3,7,8,5],
					[2,5,8,6,7,4,3,1,9],
					[1,4,7,8,5,9,2,6,3],
					[8,2,6,3,4,1,9,5,7],
					[5,9,3,7,6,2,8,4,1],
					[4,6,1,2,9,7,5,3,8],
					[9,8,2,4,3,5,1,7,6],
					[7,3,5,1,8,6,4,9,2]];
			break;
	}

	for (i = 1; i <= 9; i++){
		for (j = 1; j <= 9; j++){
			$("#" + i + "x" + j).val(matriz[i-1][j-1]);
		}
	}
}

//Bloqueia a matriz caso o jogador clique em desistir
function bloqueiaMatriz(){
	var i, j;
	for (i = 1; i <= 9; i++){
		for (j = 1; j <= 9; j++){
    		if (!$("#" + i + "x" + j).attr("disabled")){
				$("#" + i + "x" + j).attr("disabled","true");
				$("#" + i + "x" + j).css("color","#000000");
				$("#" + i + "x" + j).css("background-color","#FFFFFF");
			}
		}
	}
}

//Verifica a matriz
//O pintar funciona quando o jogador clica no botão Verificar
//Quando o jogador termina a matriz, a função é chamada porém sem pintar os campos com erros
function verificaMatriz(pintar){
	var i, j;
	var vetorLinha = [0,0,0,0,0,0,0,0,0];
	var vetorColuna = [0,0,0,0,0,0,0,0,0];
	var vetorQuadrante = [0,0,0,0,0,0,0,0,0];
	var numero;
	var retorno = true;

	for (j = 1; j <= 9; j++){
		vetorLinha = [0,0,0,0,0,0,0,0,0];
		vetorColuna = [0,0,0,0,0,0,0,0,0];
		vetorQuadrante = [0,0,0,0,0,0,0,0,0];
		
		for (i = 1; i <= 9; i++){
			numero = parseInt($("#" + i + "x" + j).val());
			vetorLinha[numero-1]++;
			numero = parseInt($("#" + j + "x" + i).val()); 
			vetorColuna[numero-1]++;
			numero = parseInt($("input[name=" + i + "x" + j + "]").val());
			vetorQuadrante[numero-1]++;
		}
		for (i = 1; i <= 9; i++){	
			numero = parseInt($("#" + i + "x" + j).val());
			if (vetorLinha[numero-1] > 1){
				if ((!$("#" + i + "x" + j).attr("disabled")) && pintar)
					$("#" + i + "x" + j).css("color","red");
				retorno = false;
			}
			numero = parseInt($("#" + j + "x" + i).val()); 
			if (vetorColuna[numero-1] > 1){
				if ((!$("#" + j + "x" + i).attr("disabled")) && pintar)
					$("#" + j + "x" + i).css("color","red");
				retorno = false;
			}
			numero = parseInt($("input[name=" + i + "x" + j + "]").val());
			if (vetorQuadrante[numero-1] > 1){
				if ((!$("input[name=" + i + "x" + j + "]").attr("disabled")) && pintar)
					$("input[name=" + i + "x" + j + "]").css("color","red");
				retorno = false;
			}
		}
	}

	return retorno;
}

//Define qual div deve ser aberta no fim do jogo
//Caso o jogador entre no ranking a div para digitar o nome é aberta
//Caso o jogador não entre no ranking a div de parabéns é aberta
function abrirDivFim(){
    $("#fim").css("display","inherit");

    if (verificaEntraRanking()){
		$("#noRanking").css("display","none");
    	$("#yesRanking").css("display","inherit");
    }
    else{    	
    	$("#noRanking").css("display","inherit");
		$("#yesRanking").css("display","none");
    }

   $("#botoes input").each(function(){
   		$(this).css("display","none");
   });
}

//Verifica se a matriz do suloku está completamente preenchida
function verificaMatrizCompleta(){
	document.getElementById('mensagem').innerHTML = "";
	var sudoku = true;
	$("td input").each(function(){
		if (!$(this).attr("disabled"))
			$(this).css("color", "#000000");
    	if ($(this).val() == "")
    		sudoku = false;
	});

    if (sudoku){
    	if (!verificaMatriz(false))
    		document.getElementById('mensagem').innerHTML = "A matriz sudoku possui erros!";
		else{
			interval = window.clearInterval(interval);
				abrirDivFim();
		}
	}
}

//Seta o intervalo para o contador de tempo de 1 segundo
var interval = setInterval(function(){setarTempo(false)}, 1000);

$(document).ready(function() {
    $("td input").keypress(verificaNumero);

    $("td input").keyup(verificaMatrizCompleta);

    var pausado = false;

    //Pausa ou despausa o jogo
    $("#pausar").click(function() {
    	if (pausado){
    		interval = setInterval(function(){setarTempo(false)}, 1000);
    		pausado = false;
    		$(this).val("Pausar");
    		$("#pausa").css("display","none");
	    	$("#novo1").removeAttr("disabled");
	    	$("#verificar").removeAttr("disabled");
	    	$("#desistir").removeAttr("disabled");
    	}
    	else{
    		interval = window.clearInterval(interval);
    		setarTempo(true);
    		pausado = true;
    		$(this).val("Continuar");
    		$("#pausa").css("display","inherit");
	    	$("#novo1").attr("disabled","true");
	    	$("#verificar").attr("disabled","true");
	    	$("#desistir").attr("disabled","true");
		}
	});

    //Abre novo jogo
	$("#novo1").click(function(){
		var decisao = confirm("Tem certeza que deseja SAIR deste jogo?");
		if (decisao){
			location.href = "nivel.php";
		}
	});

	//Abre novo jogo
	$("#novo2").click(function(){
		location.href = "nivel.php";
	});

	//Verifica a matriz
	$("#verificar").click(function() {
    	setarTempo(true);
		verificaMatriz(true);
	});

	//Desiste do jogo
	$("#desistir").click(function() {
		var decisao = confirm("Tem certeza que deseja DESISTIR do jogo?");
		if (decisao){
			resolveMatriz();
			bloqueiaMatriz();
	    	$("#pausar").attr("disabled","true");
	    	$("#verificar").attr("disabled","true");
	    	$("#desistir").attr("disabled","true");
	    	interval = window.clearInterval(interval);
		}
	});

});

 
