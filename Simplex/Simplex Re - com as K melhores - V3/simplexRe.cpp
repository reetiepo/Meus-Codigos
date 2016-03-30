//#include <stdio.h>
//#include <stdlib.h>
//#include <iostream>
////#include <Windows.h>
//#include <string.h>
//#include <math.h>
//#include <vector>
//#include "mochila.h"
//
//// Auxiliar para verificar número negativo
//#define minPositivo 0.00001
//// Váriavel utilizada no cálculo do Branch and Bound
//#define custoAlto 10000
//// Quantidade máxima de diferentes tipos de retalhos permitidos
//#define maxQtdTipoRetalho 0
//// Diretório dos arquivos de entrada
//#define dirArquivoEntrada "Arquivo/Entrada/D4d"
//// Diretório dos arquivos de saída
//#define dirArquivoSaida "Arquivo/Saida/S-D4d"
//#define dirTeste "Arquivo/Saida/S-D4d-Teste.txt"
//// Quantidade de arquivos de entrada que devem ser lidos
//#define qtdArquivosEntrada 1
//// Quantidade de soluções da mochila
//#define k_solucoes 1
//
//
//using namespace std;
//
//// in - arquivo de entrada
//// out - arquivo de saída
//FILE *in, *out;
//
//// Número máximo de retalhos que pode ser gerado (informação do arquivo de entrada)
//int maxRetalho;
//
//void Ordena(int m, classe dados){
//	int i, j;
//	double t_utilidade;
//	int t_demanda, t_l, t_pos;  
//             
//	double pivo;          
//             
//	for(i = 1; i < m; i++){
//		pivo = (dados[i].utilidade / dados[i].l);
//		t_l = dados[i].l;
//		t_utilidade = dados[i].utilidade;
//		t_demanda = dados[i].demanda;
//
//		j = i - 1;
//
//		while((j >= 0) && (pivo > (dados[j].utilidade / dados[j].l))){
//			dados[j+1].l = dados[j].l;
//			dados[j+1].utilidade = dados[j].utilidade;
//			dados[j+1].demanda = dados[j].demanda;
//			j = j-1;
//		}
//
//		dados[j + 1].l = t_l;
//		dados[j + 1].utilidade = t_utilidade;
//		dados[j + 1].demanda = t_demanda;
//	}
//	       
//	return;
//}
//
//void Reordena(int m, classe dados, solucao matriz, int troca[]){
//	int i, j, h, k;
//	int indice_K = 0;
//	double t_utilidade;
//	int t_demanda, t_l, t_sol;
//	vector<vector<int> > sol(k_solucoes,vector<int>(m));
//
//	for (h = 0; h < k_solucoes; h++){
//		for(k = 0; k < m; k++){
//			if (k == matriz[h].indice[indice_K]){
//				sol[h][k] = matriz[h].sol[indice_K];
//				indice_K++;
//			}
//			else
//				sol[h][k] = 0;
//		}
//	}
//
//	/*for (int re = 0 ; re < k_solucoes ; re++){
//		printf("ANTES:\n"); 
//		for(int re2 = 0; re2<matriz[re].tamanho_k; re2++)
//			printf("%d:%d\t", dados[matriz[re].indice[re2]].l, matriz[re].sol[re2]);
//		printf("\n");
//	}*/
//             
//	for(i = 0; i < m; i++){
//		for (j = 0; j < m; j++){
//			if (troca[i] == dados[j].l){
//
//				t_l = dados[i].l;
//				t_utilidade = dados[i].utilidade;
//				t_demanda = dados[i].demanda;
//				
//				dados[i].l = dados[j].l;
//				dados[i].utilidade = dados[j].utilidade;
//				dados[i].demanda = dados[j].demanda;
//				
//				dados[j].l = t_l;
//				dados[j].utilidade = t_utilidade;
//				dados[j].demanda = t_demanda;
//
//				for (int h = 0 ; h < k_solucoes ; h++){
//					t_sol = sol[h][i];
//					sol[h][i] = sol[h][j];
//					sol[h][j] = t_sol;
//				}
//			}
//		}
//	}
//
//	indice_K = 0;
//
//	for (h = 0 ; h < k_solucoes ; h++){
//		for(k = 0; k < m; k++){
//			if (sol[h][k] != 0){
//				matriz[h].indice[indice_K] = k;
//				matriz[h].sol[indice_K] = sol[h][k];
//				indice_K++;
//			}
//		}
//	}
//
//	/*for (int re = 0 ; re < k_solucoes ; re++){
//		printf("DEPOIS:\n"); 
//		for(int re2 = 0; re2<matriz[re].tamanho_k; re2++)
//			printf("%d:%d\t", dados[matriz[re].indice[re2]].l, matriz[re].sol[re2]);
//		printf("\n");
//	}
//	system("pause");*/
//}
//void TrocaBase(int i, int j, int idBarraPadrao[], vector<vector<int> > *matrizInicial, float solucaoInicial[], int totalItens, int qtdTiposBarras)
//{
//	int auxInt;
//	float auxFloat;
//	int *auxVet = new int[totalItens + qtdTiposBarras];
//
//	for (auxInt = 0; auxInt < (totalItens + qtdTiposBarras); auxInt++)
//	{
//		auxVet[auxInt] = (*matrizInicial)[auxInt][i];
//		(*matrizInicial)[auxInt][i] = (*matrizInicial)[auxInt][j];
//		(*matrizInicial)[auxInt][j] = auxVet[auxInt];
//	}
//
//	auxInt = idBarraPadrao[i];
//	idBarraPadrao[i] = idBarraPadrao[j];
//	idBarraPadrao[j] = auxInt;
//
//	auxFloat = solucaoInicial[i];
//	solucaoInicial[i] = solucaoInicial[j];
//	solucaoInicial[j] = auxFloat;
//
//	delete[] auxVet;
//}
//
//void CalculaDirecaoSimplex(float direcaoSimplex[], vector<vector<float> > matrizInversa, float alfa[], int indice, int totalItensDiscretizados, int qtdTiposBarras)
//{
//	int i,j;
//
//	for(i = 0; i < (2 * (totalItensDiscretizados + qtdTiposBarras)); i++)
//		direcaoSimplex[i] = 0;
//
//	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//		for(j = 0; j < (totalItensDiscretizados); j++)
//			direcaoSimplex[i] -= (matrizInversa[i][j] * alfa[j]);
//
//	for(i = 0;i < (totalItensDiscretizados + qtdTiposBarras); i++)
//			direcaoSimplex[i] -= matrizInversa[i][totalItensDiscretizados + indice];
//}
//
//void CalculaPasso(float solucaoInicial[], float direcaoSimplex[], float *passoSimplex, int *indiceNovoPadrao, int totalItensDiscretizados, int qtdTiposBarras, int qtdTiposItem)
//{
//	int i;
//
//	(*passoSimplex) = 2 * custoAlto;
//	(*indiceNovoPadrao) = 0;
//	
//	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//	{
//		if(direcaoSimplex[i] < -minPositivo)
//			if((-solucaoInicial[i] / direcaoSimplex[i]) < (*passoSimplex) - minPositivo)
//			{
//				(*passoSimplex) = (-solucaoInicial[i] / direcaoSimplex[i]);
//				(*indiceNovoPadrao) = i;
//			}
//	}
//}		
//void AtualizaMatriz(vector<vector<int> > *matriz, float alfa[], int indiceNovoPadrao, int idBarraPadrao[], int indice, vector<vector<float> > *matrizInversa, float direcaoSimplex[], float solucaoInicial[], float passoSimplex, float multiplicadorSimplex[], float custoMinimo, int totalItensDiscretizados, int qtdTiposBarras)
//{
//	int i,j;
//
//	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//		(*matriz)[i][indiceNovoPadrao] = floor(alfa[i]);
//
//	idBarraPadrao[indiceNovoPadrao] = indice;
//
//	for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
//	{ 
//		(*matrizInversa)[indiceNovoPadrao][j] = -((*matrizInversa)[indiceNovoPadrao][j] / direcaoSimplex[indiceNovoPadrao]);
//	}
//
//	solucaoInicial[indiceNovoPadrao] = passoSimplex;
//
//	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//		if(i != indiceNovoPadrao)
//		{
//			for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
//				(*matrizInversa)[i][j] += ((*matrizInversa)[indiceNovoPadrao][j] * direcaoSimplex[i]);
//				
//  			solucaoInicial[i] += (passoSimplex * direcaoSimplex[i]);
//		}
//
//	for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
//	{
//		multiplicadorSimplex[j]+= ((*matrizInversa)[indiceNovoPadrao][j] * custoMinimo);
//	}
//}
//
//int VerificaPadraoNulo(vector<vector<int> > matriz, int j, int qtdTiposItem)
//{
//	int i;
//
//	for(i = 0; i < qtdTiposItem; i++)
//		if(matriz[i][j] > 0)
//			return 1; // Padrão não nulo
//			
//	return 0; // Padrão nulo
//}
//
//double PerdaPadrao(vector<vector<int> > matriz, int j, int qtdTiposItem, classe dados, int tamanhoBarra[],int totalItensDiscretizados, int qtdTiposBarras)
//{
//	int i, indice;
//	int soma = 0;
//
//	for(i = 0; i < qtdTiposItem; i++)
//		soma += dados[i].l * matriz[i][j];
//
//	for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//		if(matriz[i][j] != 0)
//		{
//			indice = i;
//			break;
//		}
//
//	return tamanhoBarra[indice - totalItensDiscretizados] - soma;
//}
//
//int TamanhoRetalhoPadrao(vector<vector<int> > matriz, int j, int qtdTiposItem, classe dados, int totalItensDiscretizados)
//{
//	int i;
//	int total = 0;
//
//	for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
//		if(matriz[i][j] > 0)
//			total += matriz[i][j] * dados[i].l;
//
//	return total;
//}
//
//int main(int argc, char **argv)
//{
//	int  i, j, n, p, numArquivoEntrada; 
//	char entrada[100], saida[100], sNumArquivoEntrada[3];
//
//	float totalPerda, totalSobra, auxFloat;
//	int qtdTiposItem, qtdTiposBarras, mediaItens, qtdRetalhos, auxQtdRetalhos, leftover, auxInt;
//	int *retalhos_gerados = new int[100];
//	int *amount_retalhos_gerados = new int[100];
//
//	for(numArquivoEntrada = 1; numArquivoEntrada <= qtdArquivosEntrada; numArquivoEntrada++)
//	{
//		// Inicializa as variáveis
//		qtdRetalhos = auxQtdRetalhos = totalSobra = totalPerda = 0;
//		
//		//Monta arquivo de entrada
//		sprintf (entrada, "%s%d.txt",dirArquivoEntrada,numArquivoEntrada);
//
//		if ((in = fopen(entrada, "r")) != NULL) {
//
//			#pragma region Monta e inicializa arquivo de saida
//			sprintf (saida, "%s%d.txt",dirArquivoSaida,numArquivoEntrada);
//			out = fopen(saida, "w+");
//
//					FILE *teste;
//					teste = fopen(dirTeste, "w+");
//	     
//			printf("\nArquivo: %d\n",numArquivoEntrada);
//			printf("\n");
//
//			fprintf(out,"\nSaida %s\n", entrada);
//			fprintf(out,"\nMinimizar a Perda Total\n");
//
//			#pragma endregion
//		         	   
//			fscanf(in, "%d\n", &qtdTiposBarras);
//			qtdTiposBarras = qtdTiposBarras + qtdRetalhos;
//
//			//variáveis utilizadas para controle dos valores das barras
//			int *tamanhoBarra = new int[qtdTiposBarras];
//			int *qtdBarra = new int[qtdTiposBarras];
//			int *qtdBarraInicial = new int[qtdTiposBarras];
//			float *custoBarra = new float[qtdTiposBarras];
//
//			//leitura dos valores das barras
//			for(n = 0; n < qtdTiposBarras - qtdRetalhos; n++)
//			{
//				fscanf(in, "%d", &auxInt);
//				fscanf(in, "%d", &tamanhoBarra[n]);
//				fscanf(in, "%f", &custoBarra[n]);
//				fscanf(in, "%d", &qtdBarra[n]);
//				qtdBarraInicial[n] = qtdBarra[n];
//			}
//		  
//			fscanf(in, "%d", &qtdTiposItem);
//
//			//for(n = 0; n < qtdRetalhos; n++)
//			//{
//			//	tamanhoBarra[n + qtdTiposBarras - qtdRetalhos] = retalhos_gerados[n];
//			//	custoBarra[n + qtdTiposBarras - qtdRetalhos] = 100; 
//			//	qtdBarra[n + qtdTiposBarras - qtdRetalhos] = amount_retalhos_gerados[n];
//			//	qtdBarraInicial[n + qtdTiposBarras - qtdRetalhos] = amount_retalhos_gerados[n];
//			//}
//		          
//			float g = 0;
//			float percMinPerda = 0.5;
//			int indice = 0;
//			int tamanhoSolucao;
//			int maior;
//
//			//calculo da quantidade de itens discretizados que haverá
//			int totalItensDiscretizados = qtdTiposItem + maxQtdTipoRetalho;
//			
//			//int *size_item = new int[totalItensDiscretizados];
//			//int *amount_item = new int[totalItensDiscretizados];	 
//			
//			classe dados = (problema_um *) malloc(sizeof(problema_um) * totalItensDiscretizados);
//
//			if(dados == NULL){
//				printf("Erro de alocação de memória!!\n\n");   
//				getchar();   
//				exit(1);
//			}
//
//			//Leitura dos valores dos itens a serem cortados
//			for (i = 0; i < qtdTiposItem; i++)
//				fscanf(in, "%d %d %d\n", &auxInt, &dados[i].l, &dados[i].demanda);
//
//			fscanf(in, "%d\n", &auxInt);
//			fscanf(in, "%f\n", &percMinPerda);
//			fscanf(in, "%f\n", &auxFloat);
//			fscanf(in, "%d\n", &maxRetalho);
//			fscanf(in, "%d\n", &mediaItens);
//
//			float somaMedia = 0;
//			int menor_item = HUGE_VAL;
//
//			for(i = 0; i < qtdTiposItem; i++){
//				if(menor_item > dados[i].l) 
//					menor_item = dados[i].l;
//				somaMedia += dados[i].l;
//			}
//
//			mediaItens = floor(somaMedia/qtdTiposItem);
//	      
//			float *auxd = new float[totalItensDiscretizados];
//			float *estoqueUtilizado = new float[totalItensDiscretizados];
//
//			/*#pragma region Verifica menor item e maior barra
//
//			int menorItem = dados[0].l;
//
//			for (i = 1; i < qtdTiposItem; i++)
//				if (dados[i].l < menorItem)
//					menorItem = dados[i].l;
//
//			int maiorBarra = tamanhoBarra[0];
//
//			for (i = 1; i < qtdTiposBarras; i++)
//			{
//				if (tamanhoBarra[i] > maiorBarra)
//					maiorBarra = tamanhoBarra[i];
//			}
//
//			#pragma endregion 
//*/
//			//Calcula a porcentagem mínima de perda
//			percMinPerda *= tamanhoBarra[0];
//			
//			float *direcaoSimplex = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			int *idBarraPadrao = new int[2 * (totalItensDiscretizados + qtdTiposBarras)];
//
//			double loss;
//
//			vector<vector<int> > matriz(2 * (totalItensDiscretizados + qtdTiposBarras),vector<int>(2 * (totalItensDiscretizados + qtdTiposBarras)));
//			vector<vector<float> > matrizInversa(2 * (totalItensDiscretizados + qtdTiposBarras),vector<float>(2 * (totalItensDiscretizados + qtdTiposBarras)));
//			float *solucaoInicial = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			float *multiplicadorSimplex = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			float *valor = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			float *perda = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			//int *alfa = new int[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			float *alfa = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
//			int caso = 1;
//			int indiceNovoPadrao;
//			float custo_var_folga = 0;
//			float cr;
//			float fo;
//			float soma =0;
//			float passoSimplex;
//			bool pare = false;
//			bool chamamochila;
//			bool ok;
//			int iteracao = 1;
//	       
//			#pragma region Calcula itens discretizados (retalhos)
//			if (maxQtdTipoRetalho > 0){
//				int s = (int)((tamanhoBarra[0] - menor_item - mediaItens) / (maxQtdTipoRetalho+1e-12));
//
//				for(i = 0; i < maxQtdTipoRetalho; i++) {
//					dados[qtdTiposItem + i].l = mediaItens + (s * i);
//					dados[qtdTiposItem + i].demanda = 10;
//				}
//			}
//			#pragma endregion
//
//			#pragma region Inicializa vetor de retalhos
//
//			qtdRetalhos = 0;
//			for (i = 0; i < 100; i++) {
//				retalhos_gerados[i] = 0;
//				amount_retalhos_gerados[i] = 0;
//			}
//
//			#pragma endregion
//
//	Inicio:
//			
//			//Inicializando as variáveis
//
//			for(i = 0; i < (2 * (qtdTiposBarras + totalItensDiscretizados)); i++)
//			{
//				for(j = 0; j < (2 * (qtdTiposBarras + totalItensDiscretizados)); j++)
//				{
//					matriz[i][j] = 0;
//					matrizInversa[i][j] = 0;
//				}
//				solucaoInicial[i] = 0;
//				multiplicadorSimplex[i] = 0;
//				direcaoSimplex[i] = 0;
//				perda[i] = 0;
//				idBarraPadrao[i] = -HUGE_VAL;
//			}
//
//			#pragma region Calcula base homogênea
//			
//			maior = 0;
//			while(qtdBarra[maior] == 0)
//				maior++;
//
//			for(i = maior + 1; i < qtdTiposBarras; i++)
//				if(tamanhoBarra[maior] < tamanhoBarra[i] && qtdBarra[i] > 0)
//					maior = i;
//
//			for(i = 0; i < totalItensDiscretizados; i++)
//			{
//				if(i < qtdTiposItem)
//					idBarraPadrao[i] = maior;
//					
//				if(tamanhoBarra[maior] / dados[i].l > dados[i].demanda)
//					matriz[i][i] = dados[i].l;
//				else
//					matriz[i][i] = tamanhoBarra[maior] / dados[i].l;
//
//				if(matriz[i][i] == 0)
//				{
//					matriz[i][i] = 1;
//					idBarraPadrao[i] = -maior;
//				}
//			}
//
//			for(i = 0; i < totalItensDiscretizados; i++)
//				matriz[totalItensDiscretizados + maior][i] = 1;
//
//			for(i = 0; i < qtdTiposBarras; i++)
//			{
//				idBarraPadrao[totalItensDiscretizados + i] = -i;
//				matriz[totalItensDiscretizados + i][totalItensDiscretizados + i] = 1;
//			}
//
//			#pragma endregion
//
//			#pragma region Calcula solução inicial
//			for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//				solucaoInicial[i] = 0;
//				
//			for(i = 0; i < totalItensDiscretizados; i++)
//			{
//				solucaoInicial[i] = dados[i].demanda / matriz[i][i];
//			}
//			
//			soma = 0;
//			for(i = 0; i < qtdTiposItem; i++)
//				soma += solucaoInicial[i];
//
//			if(qtdBarra[maior] > (soma - minPositivo))
//			{
//				solucaoInicial[totalItensDiscretizados + maior] = qtdBarra[maior] - soma;
//				caso = 1;
//			}
//			else
//			{
//				matriz[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = -1;
//				solucaoInicial[totalItensDiscretizados + maior] = -(qtdBarra[maior] - soma);
//				caso = 2;
//				idBarraPadrao[totalItensDiscretizados + maior] = 0;
//			}
//
//			for(i = 0; i < qtdTiposBarras; i++)
//				if(i != maior)
//					solucaoInicial[totalItensDiscretizados + i] = qtdBarra[i];
//			#pragma endregion
//
//			#pragma region Calcula inversa
//
//			for(i = 0; i < totalItensDiscretizados; i++)
//			{
//				matrizInversa[i][i] = 1 / matriz[i][i];
//			}
//
//			for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//				matrizInversa[i][i] = 1;
//
//			if(caso == 1)
//			{
//				matrizInversa[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = 1;
//				for(i = 0; i < totalItensDiscretizados; i++)
//				{
//					matrizInversa[totalItensDiscretizados + maior][i] = -1 / matriz[i][i];
//				}
//			}
//			else
//			{
//				matrizInversa[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = -1;
//				for(i = 0; i < totalItensDiscretizados; i++)
//				{
//					matrizInversa[totalItensDiscretizados + maior][i] = 1 / matriz[i][i];
//				}
//			}
//
//			#pragma endregion
//
//			#pragma region Calcula multiplicador simplex
//			
//			if(caso == 1)
//			{
//				for(i = 0; i < qtdTiposItem; i++)
//					multiplicadorSimplex[i] = custoBarra[maior] / matriz[i][i];
//					
//				for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
//					multiplicadorSimplex[i] = (minPositivo) * custoBarra[maior] / matriz[i][i];
//			}
//			else
//			{
//				for(i = 0; i < totalItensDiscretizados; i++)
//					multiplicadorSimplex[i] = (custoBarra[maior] + custoAlto) / matriz[i][i];
//				multiplicadorSimplex[totalItensDiscretizados+maior] = -custoAlto;
//			}
//			
//			#pragma endregion
//
//			while(!pare)
//			{
//				chamamochila = true;
//				custo_var_folga = -custoAlto;
//
//				for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//					if(multiplicadorSimplex[i] > minPositivo && multiplicadorSimplex[i] > custo_var_folga)
//					{
//						custo_var_folga = -multiplicadorSimplex[i];
//						indice = i - totalItensDiscretizados;
//						chamamochila = false;
//					}
//
//				if(!chamamochila)
//				{
//					g = custo_var_folga;
//
//					for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//						alfa[i] = 0;
//					alfa[totalItensDiscretizados + indice] = 1;
//				}
//				else
//				{
//					g = custoAlto;
//
//					for(i = 0; i < totalItensDiscretizados; i++){
//						valor[i] = multiplicadorSimplex[i];
//					}
//					indice = -1;
//
//					mochila m;
//
//					float menorUtilidade = -HUGE_VAL;
//					solucao matriz_K;
//					time_t fim, inicio;
//					int *troca = new int[totalItensDiscretizados];
//
//					for(int h = 0; h < totalItensDiscretizados; h++){
//						dados[h].utilidade = valor[h]/dados[h].l*1000;
//						if (dados[h].utilidade < menorUtilidade)
//							menorUtilidade = dados[h].utilidade;
//						if (h >= qtdTiposItem){
//							menorUtilidade = menorUtilidade	* 0,9;
//							dados[h].utilidade = menorUtilidade;
//						}
//						troca[h] = dados[h].l;
//					}
//						
//					for(i = 0; i < qtdTiposBarras; i++)
//						if(qtdBarra[i] > 0){
//
//							Ordena(totalItensDiscretizados, dados);
//
//							//for (int tst = 0; tst < totalItensDiscretizados; tst++)
//							//	printf("%d\t%lf\n", dados[tst].l, dados[tst].utilidade);
//							//system("pause");
//
//							//CHAMA O PROCEDIMENTO QUE RESOLVE O PROBLEMA DA MOCHILA
//							//for (int kk = 0; kk < totalItensDiscretizados; kk++)
//							//	printf("DEMANDA: %d \n", dados[kk].demanda);
//							printf("ENTROUU\n");
//							m.branch_bound_k(dados, totalItensDiscretizados, tamanhoBarra[i], k_solucoes, menor_item, &matriz_K, &fim, &inicio);
//							printf("SAIU: %lf\n", matriz_K[0].valor);
//							for (int kk = 0; kk < matriz_K[0].tamanho_k; kk++)
//								printf("%d - %d \n", matriz_K[0].indice[kk], matriz_K[0].sol[kk]);
//							//system("pause");
//							Reordena(totalItensDiscretizados, dados, matriz_K, troca);
//							
//							int somatudore = 0;
//							for (int rr = 0; rr < matriz_K[0].tamanho_k; rr++){
//								somatudore += dados[matriz_K[0].indice[rr]].l * matriz_K[0].sol[rr];
//							}
//							//matriz_K[0].valor = somatudore;
//
//							cr = tamanhoBarra[i] - matriz_K[0].valor - multiplicadorSimplex[totalItensDiscretizados+i];
//				
//							/*printf("\nbarra = %d", tamanhoBarra[i]);
//							printf("\npadrão: ");
//							for (int rr = 0; rr < matriz_K[0].tamanho_k; rr++){
//								printf("(%d)%d\t", dados[matriz_K[0].indice[rr]].l, matriz_K[0].sol[rr]);
//							}
//							printf("\nperda = %d", tamanhoBarra[i] - somatudore);
//							printf("\ncr = %f\n", cr);
//							system("pause");*/
//
//							//verifica se o custo do novo padrão é menor do que o melhor padrão encontrado até o instante
//							if(cr - g < 0.000001)
//							{
//								g = cr;
//								indice = i;
//								int indice_K = 0;
//
//								for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
//								alfa[j] = 0;
//
//								/*printf("ANTES\n");
//								for (j = 0; j < matriz_K[0].tamanho_k; j++){
//									printf("(%d)%d\t", dados[matriz_K[0].indice[j]].l, matriz_K[0].sol[j]);
//								}
//								printf("\n");*/
//
//								for (j = 0; j < matriz_K[0].tamanho_k; j++){
//									alfa[matriz_K[0].indice[j]] = matriz_K[0].sol[j];
//								}
//
//								/*printf("\nDEPOIS\n");
//								for (j = 0; j < totalItensDiscretizados; j++){
//									if (alfa[j] > 0)
//										printf("(%d)%d\t", dados[j].l, alfa[j]);
//								}
//								printf("\n");
//								system("pause");*/
//							}
//						}
//					if(indice != -1)
//						alfa[totalItensDiscretizados+indice] = 1;
//					//printf("AQUI - DEPOIS FOR");
//				}
//				//printf("AQUI - DEPOIS ELSE");
//
//				//TESTE DE OTIMALIDADE
//				if(floor(g * -100) <= 0)
//				{
//					pare = true;
//				
//					if(idBarraPadrao[totalItensDiscretizados + maior] == -HUGE_VAL && solucaoInicial[totalItensDiscretizados + maior] > minPositivo)
//						fo = 100;
//					else
//					{
//						for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
//						{
//							if((idBarraPadrao[i] < 0 && idBarraPadrao[i] != HUGE_VAL) || solucaoInicial[i] < minPositivo)
//							{
//								j = i + 1;
//								
//								while(idBarraPadrao[j] < 0 && idBarraPadrao[j] != HUGE_VAL)
//									j++;
//
//								if(j < (totalItensDiscretizados + qtdTiposBarras))
//									TrocaBase(i,j,idBarraPadrao,&matriz,solucaoInicial,totalItensDiscretizados,qtdTiposBarras);
//							}
//						}
//						
//						i = 0;
//			
//						while(idBarraPadrao[i] >= 0)
//							i++;
//
//						tamanhoSolucao = i - 1;
//
//						fo = 0;
//						for(i = 0; i < tamanhoSolucao; i++)
//							fo += solucaoInicial[i];
//					}
//				}
//				else
//				{
//					fprintf(teste, "\n--------------------------------------------\nENTROU");
//					fprintf(teste, "\nbarra = %d", tamanhoBarra[indice]);
//					fprintf(teste, "\npadrão: ");
//					for (int rr = 0; rr < totalItensDiscretizados; rr++){
//						if (alfa[rr] > 0)
//							fprintf(teste, "%d(%d)%d\t",rr ,dados[rr].l, alfa[rr]);
//					}
//					fprintf(teste, "\ncr = %f\n--------------------------------------------\n", g);
//				
//					CalculaDirecaoSimplex(direcaoSimplex,matrizInversa,alfa,indice,totalItensDiscretizados,qtdTiposBarras);
//					CalculaPasso(solucaoInicial,direcaoSimplex,&passoSimplex,&indiceNovoPadrao,totalItensDiscretizados,qtdTiposBarras,qtdTiposItem);
//					AtualizaMatriz(&matriz,alfa,indiceNovoPadrao,idBarraPadrao,indice,&matrizInversa,direcaoSimplex,solucaoInicial,passoSimplex,multiplicadorSimplex,g,totalItensDiscretizados,qtdTiposBarras);
//
//					if(!chamamochila)
//						idBarraPadrao[indiceNovoPadrao] = -indice;
//				}
//			}
//			printf("AQUI - DEPOIS TESTE OTIMALIDADE");
//
//
//			int nn = 0;
//			int jj = 0;
//			int testando = 0;
//
//			//fprintf(teste, "\n----------------------------------------------------\n");
//			//while (jj < tamanhoSolucao)
//			//{
//			//	testando = 0;
//			//	if(VerificaPadraoNulo(matriz, jj, totalItensDiscretizados))
//			//	{
//			//		fprintf(teste, "(%d)(%d)\t%4.2f\t",nn,tamanhoBarra[idBarraPadrao[jj]],solucaoInicial[nn]);
//			//		for(int ii = 0; ii < totalItensDiscretizados; ii++)
//			//			if (matriz[ii][nn] > 0){
//			//				testando += dados[ii].utilidade * matriz[ii][nn];
//			//				fprintf(teste, "%d(%d)%d\t",ii,dados[ii].l,matriz[ii][nn]);
//			//			}
//			//				fprintf(teste, "\nValor padrao: %d",testando);
//			//		fprintf(teste, "\n");
//			//		jj++;
//			//	}
//			//	nn++;
//			//}
//			//fprintf(teste, "\n----------------------------------------------------\n");
//			////system("pause");
//
//			vector<vector<int> > matsol(2 * (totalItensDiscretizados + qtdTiposBarras),vector<int>(tamanhoSolucao));
//			vector<float> vetsol(tamanhoSolucao);
//			float auxf_troca;
//			int auxi_troca;
//
//			j = 0;
//			n = 0;
//
//			fflush(out);
//
//			//passa os padrões gerados na matriz "matriz" para a matriz "matsol", já verificando o número de retalhos usados
//			//as frequências dos padrões são passadas do vetor solucaoInicial para o vetsol
//			printf("AQUI - ANTES WHILE");
//	//system("pause");
//			while (j < tamanhoSolucao && n < tamanhoSolucao + 2)
//			{
//				//VerificaPadraoNulo - verifica se o padrão não é um padrão nulo
//				if(VerificaPadraoNulo(matriz,n,qtdTiposItem))
//				{
//					//IF e ELSE para controlar a quantidade de retalhos
//					//Perda - devolve o valor da perda inteira do padrão (se houver sobra, essa função considera como perda)
//					if(PerdaPadrao(matriz,n,qtdTiposItem,dados,tamanhoBarra,totalItensDiscretizados,qtdTiposBarras) < percMinPerda || maxRetalho > 0)
//					{
//						vetsol[j] = solucaoInicial[n];
//						idBarraPadrao[j] = idBarraPadrao[n];
//						for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
//							matsol[i][j] = matriz[i][n];
//					}
//					else
//					{
//						//Retalho - devolve o tamanho do retalho no padrão, se houver
//						if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,dados,totalItensDiscretizados) && maxRetalho > 0)
//						{
//							vetsol[j] = solucaoInicial[n];
//							idBarraPadrao[j] = idBarraPadrao[n];
//							for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
//								matsol[i][j] = matriz[i][n];
//						}
//						else
//						{
//							//Caso o padrão gere retalho e o limite de retalhos já estourou, a frequência do padrão é zerada
//							if(maxRetalho == 0)
//							{
//								vetsol[j] = solucaoInicial[n];
//								if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,dados,totalItensDiscretizados))
//									vetsol[j] = 0;
//
//								idBarraPadrao[j] = idBarraPadrao[n];
//								for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
//									matsol[i][j] = matriz[i][n];
//							}
//						}
//					}
//					j++;
//				}
//				n++;
//			}
//	printf("AQUI - DEPOIS WHILE");
//			//Teste para garantir a integridade do tamanhoSolucao
//			if(j < tamanhoSolucao)
//				tamanhoSolucao = j;
//
//			//Ordenar os padrões pela menor frequência
//			i = 0;
//			j = 0;
//			n = 0;
//			p = 0;
//			while (j<tamanhoSolucao-1)
//			{
//				if(VerificaPadraoNulo(matriz,n,qtdTiposItem))
//				{	
//					i = j+1;
//					p = j+1;
//					while(i<tamanhoSolucao && p<tamanhoSolucao)
//					{
//						if(VerificaPadraoNulo(matriz,p,qtdTiposItem))
//						{
//							//o primeiro if abaixo é para ordenação pela frequência, o segundo é para ordenação pela perda
//							if(vetsol[n] < vetsol[p])
//							//if(PerdaPadrao(matriz,n,qtdTiposItem,dados,tamanhoBarra,totalItensDiscretizados,qtdTiposBarras) > PerdaPadrao(matriz,p,qtdTiposItem,dados,tamanhoBarra,totalItensDiscretizados,qtdTiposBarras))
//							{
//								auxf_troca = vetsol[n];
//								vetsol[n] = vetsol[p];
//								vetsol[p] = auxf_troca;
//
//								for(auxInt = 0; auxInt < 2*(totalItensDiscretizados+qtdTiposBarras); auxInt++)
//								{
//									auxi_troca = matsol[auxInt][n];
//									matsol[auxInt][n] = matsol[auxInt][p];
//									matsol[auxInt][p] = auxi_troca;
//								}
//
//								auxi_troca = idBarraPadrao[n];
//								idBarraPadrao[n] = idBarraPadrao[p];
//								idBarraPadrao[p] = auxi_troca;
//							}
//							i++;
//						}
//						p++;
//					}
//					j++;
//				}
//				n++;
//			}
//			
//			#pragma region Para verificar os padrões gerados ANTES da heurística descomente abaixo
//
//			//fprintf(out,"\nANTES DA HEURÍSTICA\n");
//			//for(j = 0; j < tamanhoSolucao; j++)
//			//{
//			//	if(vetsol[j] > 0.0001)
//			//	{
//			//		fprintf(out,"Frequencia: %4.2lf\n",vetsol[j]);
//			//		for(n = 0; n < totalItensDiscretizados; n++)
//			//			fprintf(out,"(%d)(%4.2lf)%d\t",dados[n].l,dados[n].demanda,matsol[n][j]);
//			//		fprintf(out,"\n");
//			//	}
//			//}
//			//
//			//fflush(out);
//
//			#pragma endregion
//	
//			printf("Cheguei nos finalmentes\n");
//			printf("tamanhoSolucao: %d\n",tamanhoSolucao);
//			printf("Aplicando Heuristica de Arredondamento\n");
//
//			#pragma region Verificar a factibilidade
//
//			for(j = 0; j< qtdTiposItem; j++)
//				auxd[j] = 0;
//			
//			for(j = 0; j < qtdTiposBarras; j++)
//				estoqueUtilizado[j] = 0;
//
//			i = 0;			
//			j = 0;
//			n = 0;
//
//			for(i = 0; i < tamanhoSolucao; i++)
//			{
//				ok = true;
//				
//				//Arredonda o padrão para cima
//				if(vetsol[i] > minPositivo && VerificaPadraoNulo(matsol,i,qtdTiposItem))
//					vetsol[i] = ceil(vetsol[i]);
//				else
//					vetsol[i] = 0;
//				
//				do
//				{
//				
//					#pragma region Verificar a factibilidade com relação a quantidade de itens cortados
//					
//					for(j = 0; j< qtdTiposItem; j++)
//						auxd[j] = 0;
//
//					for(n = 0; n < qtdTiposItem; n++)
//						for(j = 0; j < tamanhoSolucao; j++)
//						{
//							if(j > i && vetsol[j] > 0.000001)
//								auxd[n] += floor(vetsol[j]) * matsol[n][j];
//							if(j <= i)
//								auxd[n] += vetsol[j] * matsol[n][j];
//						}
//
//					ok = true;
//
//					for(j = 0; j < qtdTiposItem; j++)
//						if(auxd[j] - dados[j].demanda > 0.000001)
//							ok = false;
//
//					#pragma endregion
//					
//					#pragma region Verificar a factibilidade com relação a quantidade de barras cortadas
//					
//					for(j = 0; j < qtdTiposBarras; j++)
//						estoqueUtilizado[j] = 0;
//
//					for(j = 0; j < tamanhoSolucao; j++)
//						estoqueUtilizado[idBarraPadrao[j]] += vetsol[j];
//
//					for(j = 0; j < qtdTiposBarras; j++)
//						if(estoqueUtilizado[j] - qtdBarra[j] > 0.000001) 
//							ok = false;
//
//					#pragma endregion
//					
//					while(!ok)
//					{
//						//Se o padrão viola qualquer uma das duas verificações de factibilidade
//						//sua frequência é reduzida em uma unidade
//						vetsol[i] -= 1;
//
//						#pragma region Verificar a factibilidade com relação a quantidade de itens cortados
//						
//						for(j = 0; j < qtdTiposItem; j++)
//							auxd[j] = 0;
//			
//						for(n = 0; n < qtdTiposItem; n++)
//							for(j = 0; j < tamanhoSolucao; j++)
//							{
//								if(j > i && vetsol[j] > 0.000001)
//									auxd[n] += floor(vetsol[j]) * matsol[n][j];
//								if(j <= i)
//									auxd[n] += vetsol[j] * matsol[n][j];
//							}
//
//						ok = true;
//
//						for(j = 0; j < qtdTiposItem; j++)
//							if(auxd[j] - dados[j].demanda > 0.000001)
//								ok = false;
//
//						#pragma endregion
//
//						//caso o padrão verificado atinge frequência 0, a heurística sai do loop e vai para o próximo padrão
//						if(vetsol[i] <= 0.000001)
//						{
//							vetsol[i] = 0;
//							ok = true;
//						}
//					}
//				}while(!ok);
//			}
//
//			#pragma endregion
//
//			#pragma region Atualiza demanda dos itens e estoque de barras
//
//
//			for(n = 0; n < qtdTiposItem; n++)
//				auxd[n] = 0;
//
//			//Soma a quantidade de cada item cortado em todos os padrões de corte
//			for(j = 0; j < tamanhoSolucao; j++)
//				if(vetsol[j] > 0.000001)
//				{
//					for(n = 0; n < qtdTiposItem; n++)
//						auxd[n] += vetsol[j] * matsol[n][j];
//				}
//
//			//Atualiza a demanda dos itens 
//				for(j = 0; j < qtdTiposItem; j++){
//					printf("DEMANDA: %d , ", dados[j].demanda);
//					dados[j].demanda -= auxd[j];
//					printf(" %d\n", dados[j].demanda);
//				}
//
//			for(j = 0; j < qtdTiposBarras; j++)
//				estoqueUtilizado[j] = 0;
//			printf("TA ATUALIZANDO DEMANDA");
//			//system("pause");
//
//			//Soma a quantidade de cada barra cortada
//			for(j = 0; j < tamanhoSolucao; j++)
//				estoqueUtilizado[idBarraPadrao[j]] += vetsol[j];
//
//			//Atualiza o estoque das barras
//			for(j = 0; j < qtdTiposBarras; j++)
//				qtdBarra[j] -= estoqueUtilizado[j];	
//
//			#pragma endregion
//	
//			printf("Arredondamento finalizado\n");
//		
//			#pragma region Para verificar os padrões gerados DEPOIS da heurística descomente abaixo
//
//			//fprintf(out,"\nDEPOIS DA HEURÍSTICA\n");
//			//for(j = 0; j < tamanhoSolucao; j++)
//			//{
//			//	if(vetsol[j] > 0.0001)
//			//	{
//			//		fprintf(out,"Frequencia: %4.2lf\n",vetsol[j]);
//			//		for(n = 0; n < qtdTiposItem; n++)
//			//			fprintf(out,"(%d)(%4.2lf)%d\t",dados[n].l,dados[n].demanda,matsol[n][j]);
//			//		fprintf(out,"\n");
//			//	}
//			//}
//			//fflush(out)
//
//			#pragma endregion
//
//			#pragma region Verifica se o grupo de padrões de corte gerado é o último (toda a demanda cumprida)
//			
//			ok = true;
//			for(j = 0; j < qtdTiposItem; j++)
//				if(dados[j].demanda > 0)
//					ok = false;
//
//			leftover = -1;
//
//			//Se for o último grupo, verifica qual é o último padrão gerado
//			if(ok)
//			{
//				n = -1;
//				for(j = 0; j < tamanhoSolucao; j++)
//					if(VerificaPadraoNulo(matsol,j,qtdTiposItem) && vetsol[j] > 0.5)
//						n = j;
//
//				loss = PerdaPadrao(matsol,n,qtdTiposItem,dados,tamanhoBarra,totalItensDiscretizados,qtdTiposBarras);
//
//				//Se o último padrão possui um retalho, esse retalho é zerado
//				//já que toda a perda será considerada como um retalho
//				for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
//					matsol[i][n] = 0;
//				
//				//Se no último padrão a perda for maior ou igual ao menor retalho, 
//				//toda a perda é considerada como um retalho
//				if (loss > mediaItens)
//					leftover = n;
//			}
//
//			#pragma endregion
//
//			fprintf(out,"max retalho: %d\n",maxRetalho);
//			fflush(out);
//
//			#pragma region Imprime as soluções obtidas no arquivo de saída
//
//			j = 0;
//			n = 0;
//			
//			while (j < tamanhoSolucao)
//			{
//				if(VerificaPadraoNulo(matsol,n,qtdTiposItem))
//				{
//					loss = PerdaPadrao(matsol,n,qtdTiposItem,dados,tamanhoBarra,totalItensDiscretizados,qtdTiposBarras);
//					
//					//Verifica integridade do número de retalhos usados
//					if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) && maxRetalho == 0 && vetsol[n] > 0.5)
//					{
//						qtdBarra[idBarraPadrao[j]] += vetsol[n];
//						vetsol[n] = 0;
//						for(i = 0; i < qtdTiposItem; i++)
//							dados[i].demanda += matsol[i][n];
//					}
//
//					//Verifica se o padrão de corte não possui frequência nula
//					if(vetsol[n] > 0.5)
//					{
//						//Se um dia achar necessário usá-la novamente :)
//						//POG DA ADRIANA
//						//if (loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)> 299.99){
//							/*if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)> 499.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) != 500)
//							{
//								matsol[totalItensDiscretizados - 3][n] ++;
//							}
//							if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)> 399.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) != 400)
//							{
//								matsol[totalItensDiscretizados - 2][n] ++;
//							}
//							if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)> 299.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) != 300)
//							{
//								matsol[totalItensDiscretizados - 1][n] ++;
//							}*/
//						//}
//						//FIM POG
//
//						fprintf(out,"(%d)(%d)\t%4.2f\t",n,tamanhoBarra[idBarraPadrao[j]],vetsol[n]);
//
//						////Dados para o relatório
//						//qtdd_obj += vetsol[n];
//						//if (idBarraPadrao[j] == 0 || idBarraPadrao[j] == 1)
//						//{
//						//	if(idBarraPadrao[j] == 0)
//						//		obj_padrao0 += vetsol[n];
//						//	else
//						//		obj_padrao1 += vetsol[n];
//
//						//	qtdd_padrao += vetsol[n];
//						//}
//						//else
//						//{
//						//	obj_retalho += vetsol[n];
//						//	tam_total += (double)(vetsol[n] * tamanhoBarra[idBarraPadrao[j]]) / 5;
//						//}
//						////Fim dados para relatório
//							
//						//Imprime o tamanho do item e a quantidade cortada do mesmo no padrão de corte
//						for(i = 0; i < totalItensDiscretizados; i++){
//							if (matsol[i][n] > 0)
//								fprintf(out,"(%d)%d\t",dados[i].l,matsol[i][n]);
//						}
//
//						//Se não for o último padrão de corte	
//						if(leftover != n)
//						{
//							//Imprime a perda (descontando um eventual retalho que possa existir no padrão)
//							fprintf(out,"%4.2f\t",(loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)));
//							
//							//Imprime um possível retalho que possa existir no padrão
//							fprintf(out,"%d\t",TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados));
//							
//							//Atualiza a quantidade máxima de retalhos permitida
//							if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) > 100)
//								maxRetalho--;
//						}
//						else
//						{
//							//Se for o último padrão de corte (com perda >= menor retalho), 
//							//considera toda a perda como retalho
//							fprintf(out,"0\t");
//							fprintf(out,"%d\t",(int)loss);
//						}
//
//						//If e ELSE abaixo pegam os valores de retalho para que no próximo período 
//						//ele seja considerado como um objeto a ser cortado
//						if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) > 0 || leftover == n)
//						{
//							if(leftover == n)
//							{
//								retalhos_gerados[qtdRetalhos] = loss;
//								amount_retalhos_gerados[qtdRetalhos] = vetsol[n];
//								qtdRetalhos++;
//							}
//							else
//							{
//								for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
//								{
//									if(matsol[i][n] > 0)
//									{
//										retalhos_gerados[qtdRetalhos] = dados[i].l;
//										amount_retalhos_gerados[qtdRetalhos] = vetsol[n]*matsol[i][n];
//										qtdRetalhos ++;
//									}
//								}
//							}
//						}
//						
//						////Dados para o relatório
//						//if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) || leftover == n)
//						//{
//						//	if(leftover == n)
//						//	{
//						//		sobra_total += vetsol[n]*loss;
//						//		totalSobra += vetsol[n]*loss;
//						//		obj_com_sobra += vetsol[n];
//
//						//		loss = 0;
//						//	}
//						//	else
//						//	{
//						//		sobra_total += vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados);
//						//		totalSobra += vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados);
//						//		obj_com_sobra += vetsol[n];
//
//						//		perda_total += vetsol[n]*loss - (vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)); 
//						//		totalPerda += vetsol[n]*loss - (vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)); 
//						//	}
//						//}
//						//else
//						//{
//						//	perda_total += vetsol[n]*loss;
//						//	totalPerda += vetsol[n]*loss;
//						//}
//
//						//if(!loss)
//						//	obj_perfeito += vetsol[n];
//						//else
//						//	obj_com_perda += vetsol[n];
//						////Fim Dados para Relatório
//				
//						fprintf(out,"\n");
//					}
//					j++;
//				}
//				n++;
//			}
//			
//			#pragma endregion
//
//			printf("Terminei a iteracao %d\n",iteracao);
//			iteracao++;
//			pare = false;
//
//			//Verifica se toda a demanda foi cumprida, senão volta para o começo do programa 
//			//(Inicio:) para fazer todo o processo de novo com as demandas atualizadas
//			for(i = 0; i < qtdTiposItem; i++)
//				if(dados[i].demanda > 0)
//					goto Inicio;
//
//			//Se toda demanda foi cumprida então imprime os valores totais de sobra e perda obtidos, assim como a quantidade de 
//			//itens padronizados cortados
//			fprintf(out,"Sobra Total: %4.2f\n",totalSobra);
//			fprintf(out,"Perda Total: %4.2f\n",totalPerda);
//			fprintf(out,"\nTotal Barras Cortadas:\n");
//			
//			for(i = 0; i < qtdTiposBarras; i++)
//			{
//				auxInt = qtdBarraInicial[i] - qtdBarra[i];
//				fprintf(out,"Barra (%d) : %d\n",tamanhoBarra[i], auxInt);
//			}
//
//			fprintf(out, "\nRetalhos Gerados:\n");
//			for(i = 0; i < qtdRetalhos; i++)
//				if(retalhos_gerados[i] > 0)
//					fprintf(out,"Retalho (%d) : %d\n",retalhos_gerados[i],amount_retalhos_gerados[i]);
//
//			fclose(in);
//			fclose(out);
//			fclose(teste);
//
//			////Dados para o relatório
//			//qtdd_padrao += num_padrao;
//
//			////ATUALIZA NÚMERO DE RETALHOS PARA O PRÓXIMO PERÍODO
//			//auxQtdRetalhos = qtdRetalhos + qtdTiposBarras - 2;
//			//j = 0;
//
//			//for(i = 2; i < qtdTiposBarras; i++)
//			//{
//			//	if(qtdBarra[i] > 0)
//			//	{
//			//		aux_retalhos_gerados[j] = tamanhoBarra[i];
//			//		aux_amount_retalhos_gerados[j] = qtdBarra[i];
//			//		j++;
//			//	}
//			//	else
//			//		auxQtdRetalhos --;
//			//}
//
//			//for(i = 0; i < qtdRetalhos; i++)
//			//{
//			//	if(amount_retalhos_gerados[i] > 0)
//			//	{
//			//		aux_retalhos_gerados[j] = retalhos_gerados[i];
//			//		aux_amount_retalhos_gerados[j] = amount_retalhos_gerados[i];
//			//		j++;
//			//	}
//			//	else
//			//		auxQtdRetalhos --;
//			//}
//
//			//for(i = 0; i < auxQtdRetalhos; i++)
//			//{
//			//	retalhos_gerados[i] = aux_retalhos_gerados[i];
//			//	amount_retalhos_gerados[i] = aux_amount_retalhos_gerados[i];
//			//}
//			//qtdRetalhos = auxQtdRetalhos;
//			////FIM DA ATUALIZAÇÃO
//		}
//	}
//
//    return 0;
//}
