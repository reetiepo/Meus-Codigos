#include <stdio.h>
#include <stdlib.h>
#include <iostream>
//#include <Windows.h>
#include <string.h>
#include <math.h>
#include <vector>
#include "mochila.h"

// Auxiliar para verificar n�mero negativo
#define minPositivo 0.00001
// V�riavel utilizada no c�lculo do Branch and Bound
#define custoAlto 10000
// Quantidade m�xima de diferentes tipos de retalhos permitidos
#define maxQtdTipoRetalho 5
// Diret�rio dos arquivos de entrada
#define dirArquivoEntrada "Arquivo/Entrada/Class8/D8d"
// Diret�rio dos arquivos de saida e relat�rios
#define dirArquivoSaidaRelatorio "Arquivo/Saida/Class8/D8d"
// Quantidade de arquivos de entrada que devem ser lidos
#define qtdArquivosEntrada 20
// Quantidade de solu��es da mochila
#define k_solucoes 10
#define usaKmelhores true

using namespace std;

int comecar = 20;

// in - arquivo de entrada
// out - arquivo de sa�da
// report - relat�rio
FILE *in, *out, *report;

// N�mero m�ximo de retalhos que pode ser gerado (informa��o do arquivo de entrada)
int maxRetalho;

typedef struct solucoesCR{
	float *sol;//vetor solucao
	double  valor;//f.o.
	float cr; //cr
	int indice;
	struct solucoesCR *prox;
} solCR;

solCR* criaLista()
{
	return NULL;
}
solCR* insereListaOrdenado(solCR* lst, double v, float alfa[], float cr, int i, int tam) 
{
	solCR* novo;
	solCR* ant = NULL;
	solCR* p = lst;

	while(p != NULL && p->cr < cr){
		ant = p;
		p = p->prox;
	}

	novo = (solCR*) malloc(sizeof(solCR)); 
	novo->sol = new float[tam];
	for(int aux = 0; aux < tam; aux++)
		novo->sol[aux] = alfa[aux];
	novo->valor = v;
	novo->cr = cr;
	novo->indice = i;

	if(ant == NULL){
		novo->prox = lst;
		lst = novo;
	} else {
		novo->prox = ant->prox;
		ant->prox = novo;
	}

	return lst;
}
solCR* reordenaLista(solCR* lst, int tam, float cbar[], float msimplex[], classe dados){
	solCR* novo = criaLista();
	solCR* l2 = NULL;
	double valor;
	
	while(lst != NULL){
		valor = 0;
		for (int i = 0; i < tam; i++)
			valor = valor + dados[i].utilidade * lst->sol[i];
		lst->cr = cbar[lst->indice] - lst->valor - msimplex[tam + lst->indice];
		novo = insereListaOrdenado(novo, valor, lst->sol, lst->cr, lst->indice, tam);
		lst = lst->prox;
	}

	return novo;
}
void Ordena(int m, classe dados){
	int i, j;
	double t_utilidade;
	int t_demanda, t_l, t_pos;  
             
	double pivo;          
             
	for(i = 1; i < m; i++){
		pivo = (dados[i].utilidade / dados[i].l);
		t_l = dados[i].l;
		t_utilidade = dados[i].utilidade;
		t_demanda = dados[i].demanda;

		j = i - 1;

		while((j >= 0) && (pivo > (dados[j].utilidade / dados[j].l))){
			dados[j+1].l = dados[j].l;
			dados[j+1].utilidade = dados[j].utilidade;
			dados[j+1].demanda = dados[j].demanda;
			j = j-1;
		}

		dados[j + 1].l = t_l;
		dados[j + 1].utilidade = t_utilidade;
		dados[j + 1].demanda = t_demanda;
	}
	       
	return;
}

void Reordena(int m, classe dados, solucao matriz, int troca[]){
	int i, j, h, k;
	int indice_K;
	double t_utilidade;
	int t_demanda, t_l, t_sol;
	vector<vector<int> > sol(k_solucoes,vector<int>(m));

	for (h = 0; h < k_solucoes; h++){
		indice_K = 0;
		if (matriz[h].tamanho_k > 0){
			for(k = 0; k < m; k++){
				if (k == matriz[h].indice[indice_K]){
					sol[h][k] = matriz[h].sol[indice_K];
					if (indice_K < (matriz[h].tamanho_k-1))
						indice_K++;
				}
				else
					sol[h][k] = 0;
			}
		}
	}

	/*for (int re = 0 ; re < k_solucoes ; re++){
		printf("ANTES:\n"); 
		for(int re2 = 0; re2<matriz[re].tamanho_k; re2++)
			printf("%d:%d\t", dados[matriz[re].indice[re2]].l, matriz[re].sol[re2]);
		printf("\n");
	}*/
             
	for(i = 0; i < m; i++){
		for (j = 0; j < m; j++){
			if (troca[i] == dados[j].l){

				t_l = dados[i].l;
				t_utilidade = dados[i].utilidade;
				t_demanda = dados[i].demanda;
				
				dados[i].l = dados[j].l;
				dados[i].utilidade = dados[j].utilidade;
				dados[i].demanda = dados[j].demanda;
				
				dados[j].l = t_l;
				dados[j].utilidade = t_utilidade;
				dados[j].demanda = t_demanda;

				for (int h = 0 ; h < k_solucoes ; h++){
					t_sol = sol[h][i];
					sol[h][i] = sol[h][j];
					sol[h][j] = t_sol;
				}
			}
		}
	}

	for (h = 0 ; h < k_solucoes ; h++){
		indice_K = 0;
		if(matriz[h].tamanho_k > 0){
			for(k = 0; k < m; k++){
				if (sol[h][k] != 0){
					matriz[h].indice[indice_K] = k;
					matriz[h].sol[indice_K] = sol[h][k];
					indice_K++;
				}
			}
		}
	}

	/*for (int re = 0 ; re < k_solucoes ; re++){
		printf("DEPOIS:\n"); 
		for(int re2 = 0; re2<matriz[re].tamanho_k; re2++)
			printf("%d:%d\t", dados[matriz[re].indice[re2]].l, matriz[re].sol[re2]);
		printf("\n");
	}
	system("pause");*/
}
void TrocaBase(int i, int j, int idBarraPadrao[], vector<vector<int>> *matrizInicial, float solucaoInicial[], int totalItens, int qtdTiposBarras)
{
	int auxInt;
	float auxFloat;
	int *auxVet = new int[totalItens + qtdTiposBarras];

	for (auxInt = 0; auxInt < (totalItens + qtdTiposBarras); auxInt++)
	{
		auxVet[auxInt] = (*matrizInicial)[auxInt][i];
		(*matrizInicial)[auxInt][i] = (*matrizInicial)[auxInt][j];
		(*matrizInicial)[auxInt][j] = auxVet[auxInt];
	}

	auxInt = idBarraPadrao[i];
	idBarraPadrao[i] = idBarraPadrao[j];
	idBarraPadrao[j] = auxInt;

	auxFloat = solucaoInicial[i];
	solucaoInicial[i] = solucaoInicial[j];
	solucaoInicial[j] = auxFloat;

	delete[] auxVet;
}

void CalculaDirecaoSimplex(float direcaoSimplex[], vector<vector<float>> matrizInversa, float alfa[], int indice, int totalItensDiscretizados, int qtdTiposBarras)
{
	int i,j;

	for(i = 0; i < (2 * (totalItensDiscretizados + qtdTiposBarras)); i++)
		direcaoSimplex[i] = 0;

	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
		for(j = 0; j < (totalItensDiscretizados); j++)
			direcaoSimplex[i] -= (matrizInversa[i][j] * alfa[j]);

	for(i = 0;i < (totalItensDiscretizados + qtdTiposBarras); i++)
			direcaoSimplex[i] -= matrizInversa[i][totalItensDiscretizados + indice];
}

void CalculaPasso(float solucaoInicial[], float direcaoSimplex[], float *passoSimplex, int *indiceNovoPadrao, int totalItensDiscretizados, int qtdTiposBarras, int qtdTiposItem)
{
	int i;

	(*passoSimplex) = 2 * custoAlto;
	(*indiceNovoPadrao) = 0;
	
	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
	{
		if(direcaoSimplex[i] < -minPositivo)
			if((-solucaoInicial[i] / direcaoSimplex[i]) < (*passoSimplex) - minPositivo)
			{
				(*passoSimplex) = (-solucaoInicial[i] / direcaoSimplex[i]);
				(*indiceNovoPadrao) = i;
			}
	}
}		
void AtualizaMatriz(int *solucaoHomogenea[], int maior, int sbar[], int *demanda[], classe dados, vector<vector<int>> *matriz, float alfa[], int indiceNovoPadrao, int idBarraPadrao[], int indice, vector<vector<float>> *matrizInversa, float direcaoSimplex[], float solucaoInicial[], float passoSimplex, float multiplicadorSimplex[], float custoMinimo, int totalItensDiscretizados, int qtdTiposBarras)
{
	int i,j;
	double perda1, perda2;
	int barra1, barra2;
	bool problDemanda = false;
	bool troca = false;
	perda1 = perda2 = 0;
	barra2 = maior;

	for(i = 0; i < totalItensDiscretizados; i++){
		if (alfa[i] > 0){
			if (alfa[i] > (*demanda)[i])
				problDemanda = true;
		}
	}

	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++){
		if (i < totalItensDiscretizados)	
			perda1 += alfa[i] * dados[i].l;
		else{
			if(alfa[i] == 1)
				barra1 = i - totalItensDiscretizados;
		}
	}
	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++){
		if (i < totalItensDiscretizados)	
			perda2 += (*matriz)[i][indiceNovoPadrao] * dados[i].l;
		else{
			if((*matriz)[i][indiceNovoPadrao] == 1)
				barra2 = i - totalItensDiscretizados;
		}
	}

	perda1 = sbar[barra1] - perda1;
	perda2 = sbar[barra2] - perda2;

	if (problDemanda){
		if (perda1 <= perda2)
			troca = true;
		else
			troca = false;
	}
	else
		troca = true;
	
	if (troca){
		if ((*solucaoHomogenea)[indiceNovoPadrao] == 0){
			for(i = 0; i < totalItensDiscretizados; i++)
				(*demanda)[i] = (*demanda)[i] + ((*matriz)[i][indiceNovoPadrao] * floor(solucaoInicial[indiceNovoPadrao]));
		}

		for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++){
			(*matriz)[i][indiceNovoPadrao] = alfa[i];
		}

		idBarraPadrao[indiceNovoPadrao] = indice;

		for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
		{ 
			(*matrizInversa)[indiceNovoPadrao][j] = -((*matrizInversa)[indiceNovoPadrao][j] / direcaoSimplex[indiceNovoPadrao]);
		}

		solucaoInicial[indiceNovoPadrao] = passoSimplex;

		for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
			if(i != indiceNovoPadrao)
			{
				for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
					(*matrizInversa)[i][j] += ((*matrizInversa)[indiceNovoPadrao][j] * direcaoSimplex[i]);
					
				solucaoInicial[i] += (passoSimplex * direcaoSimplex[i]);
			}

		for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
		{
			multiplicadorSimplex[j]+= ((*matrizInversa)[indiceNovoPadrao][j] * custoMinimo);
		}
		
		for(i = 0; i < totalItensDiscretizados; i++)
			(*demanda)[i] = (*demanda)[i] - ((*matriz)[i][indiceNovoPadrao] * floor(solucaoInicial[indiceNovoPadrao]));
		(*solucaoHomogenea)[indiceNovoPadrao] = 0;
	}
}

int VerificaPadraoNulo(vector<vector<int>> matriz, int j, int qtdTiposItem)
{
	int i;

	for(i = 0; i < qtdTiposItem; i++)
		if(matriz[i][j] > 0)
			return 1; // Padr�o n�o nulo
			
	return 0; // Padr�o nulo
}

double PerdaPadrao(vector<vector<int>> matriz, int j, int qtdTiposItem, classe dados, int tamanhoBarra[],int totalItensDiscretizados, int qtdTiposBarras)
{
	int i, indice;
	int soma = 0;

	for(i = 0; i < qtdTiposItem; i++)
		soma += dados[i].l * matriz[i][j];

	for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
		if(matriz[i][j] != 0)
		{
			indice = i;
			break;
		}

	return tamanhoBarra[indice - totalItensDiscretizados] - soma;
}

int TamanhoRetalhoPadrao(vector<vector<int>> matriz, int j, int qtdTiposItem, classe dados, int totalItensDiscretizados)
{
	int i;
	int total = 0;

	for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
		if(matriz[i][j] > 0)
			total += matriz[i][j] * dados[i].l;

	return total;
}

int main(int argc, char **argv)
{
	int  i, j, n, p, numArquivoEntrada; 
	char entrada[100], saida[100], sNumArquivoEntrada[5];

	int qtdd_bar_usadas;
	//int qtdTiposItem, sujeira, mediaItens;
	//int qtdRetalhos = 0;
	//int auxQtdRetalhos = 0;
	int *retalhos_gerados = new int[100];
	//int *aux_retalhos_gerados = new int[100];
	int *amount_retalhos_gerados = new int[100];
	//int *aux_amount_retalhos_gerados = new int[100];
	float totalPerda, totalSobra, auxFloat;
	int qtdTiposItem, qtdTiposBarras, mediaItens, qtdRetalhos, auxQtdRetalhos, leftover, auxInt, sujeira;
	int *aux_retalhos_gerados = new int[100];
	int *aux_amount_retalhos_gerados = new int[100];

	//Vari�veis para o ultimo padr�o
	//int leftover;

Volta:

	for(numArquivoEntrada = comecar; numArquivoEntrada <= qtdArquivosEntrada; numArquivoEntrada++)
	{
		qtdRetalhos = auxQtdRetalhos = 0;

		itoa(numArquivoEntrada, sNumArquivoEntrada, 10);

		strcpy(entrada, dirArquivoEntrada);
		strcat(entrada, sNumArquivoEntrada);
		strcat(entrada, ".txt");

		if ((in = fopen(entrada, "r")) != NULL)
		{			
			strcpy(saida, dirArquivoSaidaRelatorio);
			strcat(saida, sNumArquivoEntrada);
			strcat(saida, ".txt");

			out = fopen(saida, "a");
	     
			printf("\nArquivo: %d\n",numArquivoEntrada);
			printf("\n");

			fprintf(out,"\n%d Solu��es\n", k_solucoes);
			fprintf(out,"\nSaida %s\n", entrada);
			fprintf(out,"\nMinimizar a Perda Total\n");
		         	   
			float lixo;
			int qtdTiposBarras;
			float total_sobra = 0;
			float total_perda = 0;

			fscanf(in, "%d\n", &qtdTiposBarras);

			qtdTiposBarras += qtdRetalhos;

			//vari�veis utilizadas para controle dos valores das barras
			int *size_bar = new int[qtdTiposBarras];
			int *amount_bar = new int[qtdTiposBarras];
			float *cost_bar = new float[qtdTiposBarras];
			int *amount_bar_fixo = new int[qtdTiposBarras];

			//leitura dos valores das barras
			for(n = 0; n < qtdTiposBarras - qtdRetalhos; n++)
			{
				fscanf(in, "%d %d %f %d\n", &sujeira, &size_bar[n], &cost_bar[n], &amount_bar[n]);
				amount_bar_fixo[n] = amount_bar[n];
			}

			for(n = 0; n < qtdRetalhos; n++)
			{
				size_bar[n + qtdTiposBarras - qtdRetalhos] = retalhos_gerados[n];
				cost_bar[n + qtdTiposBarras - qtdRetalhos] = 100; 
				amount_bar[n + qtdTiposBarras - qtdRetalhos] = amount_retalhos_gerados[n];
				amount_bar_fixo[n + qtdTiposBarras - qtdRetalhos] = amount_retalhos_gerados[n];
			}
		         
			fscanf(in, "%d\n", &qtdTiposItem);    

			float g = 0;
			float perc_min_perda;
			int indice = 0;
			int num_bar = 1;
			int tam_sol;
			int maior;
			int totalItensDiscretizados;
			int qtdd_bar_ret;

			//efeito de teste
			int itens_totais_discreto;
			float teste_matrix;
			int aux;
			int aux_max_retalho;
			
			//int *size = new int[qtdTiposItem];
			//int *amount = new int[qtdTiposItem];
			//int *cost = new int[qtdTiposItem];
	       
			//calculo da quantidade de itens discretizados que haver�
			totalItensDiscretizados = qtdTiposItem + maxQtdTipoRetalho;

			classe dados = (problema_um *) malloc(sizeof(problema_um) * 2 * (totalItensDiscretizados + qtdTiposBarras));

			if(dados == NULL){
				printf("Erro de aloca��o de mem�ria!!\n\n");   
				getchar();   
				exit(1);
			}		 

			//leitura dos valores dos itens a serem cortados
			for (i=0; i<qtdTiposItem; i++)
				fscanf(in, "%d %d %d\n", &sujeira, &dados[i].l, &dados[i].demanda);

			fscanf(in, "%d\n", &qtdd_bar_ret);
			fscanf(in, "%f\n", &perc_min_perda);
			fscanf(in, "%f\n", &lixo);
			fscanf(in, "%d\n", &maxRetalho);
			fscanf(in, "%d\n", &mediaItens);

			maxRetalho = maxQtdTipoRetalho;

			int menorItem = dados[0].l;

			for (i = 0; i < qtdTiposItem; i++)
			{
				if (dados[i].l < menorItem)
					menorItem = dados[i].l;
			}

			int maiorBarra = size_bar[0];

			for (i = 1; i < qtdTiposBarras; i++)
			{
				if (size_bar[i] > maiorBarra)
					maiorBarra = size_bar[i];
			}

			//totalItensDiscretizados = qtdTiposItem + ((size_bar[1] - menorItem) - mediaItens + 1)/10 + 1;

			perc_min_perda *= size_bar[0];

			//efeito de teste
			itens_totais_discreto = totalItensDiscretizados;
	        
			float *auxd = new float[totalItensDiscretizados];
			float *estoqueutilizado = new float[totalItensDiscretizados];

			//vari�veis utilizadas para controle dos itens a serem cortados
			int *y = new int[totalItensDiscretizados];
			//int *size_item = new int[totalItensDiscretizados];
			//float *amount_item = new float[totalItensDiscretizados];
			//float *cost_item = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *solucaoBB = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *direcaoSimplex = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			int *idBarraPadrao = new int[2 * (totalItensDiscretizados + qtdTiposBarras)];

			double loss;
			float ult_loss = 0;

			int cont_padrao = 0;
			float frequencia = HUGE_VAL;
			int num_padrao = 1;

			float *rcost = new float[2 * totalItensDiscretizados];
			vector<vector<int>> matriz(2 * (totalItensDiscretizados + qtdTiposBarras),vector<int>(2 * (totalItensDiscretizados + qtdTiposBarras)));
			vector<vector<float>> matrizInversa(2 * (totalItensDiscretizados + qtdTiposBarras),vector<float>(2 * (totalItensDiscretizados + qtdTiposBarras)));
			float *solucaoInicial = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			int *solucaoHomogenea = new int[totalItensDiscretizados];
			float *multiplicadorSimplex = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *valor = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *perda = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *alfa = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			int caso = 1;
			int indiceNovoPadrao;
			float custo_var_folga = 0;
			float z;
			bool acabouKmelhores = true;
			float cr;
			float fo;
			float perdatotal;
			float soma =0;
			float passoSimplex;
			bool pare = false;
			bool chamamochila;
			bool ok;
			int iteracao = 1;

			int *ordem = new int[qtdTiposItem];
			int **xs = new int*[1];
			
			for(int h = 0; h < 1; h++)
			{
				xs[h] = new int[qtdTiposItem + 1];
			}

			/*for(i = 0; i < qtdTiposItem; i++)
			{
				size_item[i] = size[i];
				amount_item[i] = amount[i];
			}*/
	       
			if (maxQtdTipoRetalho > 0){
				int s = (int)((maiorBarra - menorItem - mediaItens) / maxQtdTipoRetalho);

				for(i = 0; i < maxQtdTipoRetalho; i++)
				{
					dados[qtdTiposItem + i].l = mediaItens + (s * i);
					dados[qtdTiposItem + i].demanda = 10;
				}
			}

			qtdRetalhos = 0;
			for (i = 0; i < 100; i++)
			{
				retalhos_gerados[i] = 0;
				amount_retalhos_gerados[i] = 0;
			}

	Inicio:
			
			//Inicializando as vari�veis
			for (i = totalItensDiscretizados; i < 2 * totalItensDiscretizados; i++)
				dados[i].utilidade = 0;

			for(i = 0; i < (2 * (qtdTiposBarras + totalItensDiscretizados)); i++)
			{
				for(j = 0; j < (2 * (qtdTiposBarras + totalItensDiscretizados)); j++)
				{
					matriz[i][j] = 0;
					matrizInversa[i][j] = 0;
				}
				solucaoInicial[i] = 0;
				multiplicadorSimplex[i] = 0;
				direcaoSimplex[i] = 0;
				perda[i] = 0;
				idBarraPadrao[i] = -HUGE_VAL;
				dados[i].utilidade = 0;
			}

			/// CUTTING-OPTIMIZATION PROBLEM ///

			//BASE HOMOG�NEA
			maior = 0;
			while(amount_bar[maior] == 0)
				maior++;

			for(i = maior + 1; i < qtdTiposBarras; i++)
				if(size_bar[maior] < size_bar[i] && amount_bar[i] > 0)
					maior = i;

			for(i = 0; i < totalItensDiscretizados; i++)
			{
				if(i < qtdTiposItem)
					idBarraPadrao[i] = maior;
					
				if(size_bar[maior] / dados[i].l > dados[i].demanda)
					matriz[i][i] = dados[i].demanda;
				else
					matriz[i][i] = size_bar[maior] / dados[i].l;

				if(matriz[i][i] == 0)
				{
					matriz[i][i] = 1;
					idBarraPadrao[i] = -maior;
				}
				solucaoHomogenea[i] = 1;
			}

			for(i = 0; i < totalItensDiscretizados; i++)
				matriz[totalItensDiscretizados + maior][i] = 1;

			for(i = 0; i < qtdTiposBarras; i++)
			{
				idBarraPadrao[totalItensDiscretizados + i] = -i;
				matriz[totalItensDiscretizados + i][totalItensDiscretizados + i] = 1;
			}
			//FIM BASE HOMOG�NEA

			//SOLU��O INICIAL
			for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
				solucaoInicial[i] = 0;
				
			for(i = 0; i < totalItensDiscretizados; i++)
			{
				teste_matrix = matriz[i][i];
				solucaoInicial[i] = dados[i].demanda / teste_matrix;
			}
			
			soma = 0;
			for(i = 0; i < qtdTiposItem; i++)
				soma += solucaoInicial[i];

			if(amount_bar[maior] > (soma - minPositivo))
			{
				solucaoInicial[totalItensDiscretizados + maior] = amount_bar[maior] - soma;
				caso = 1;
			}
			else
			{
				matriz[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = -1;
				solucaoInicial[totalItensDiscretizados + maior] = -(amount_bar[maior] - soma);
				caso = 2;
				idBarraPadrao[totalItensDiscretizados + maior] = 0;
			}

			for(i = 0; i < qtdTiposBarras; i++)
				if(i != maior)
					solucaoInicial[totalItensDiscretizados + i] = amount_bar[i];
			//FIM SOLU��O INICIAL

			//INVERSA BASE INICIAL
			for(i = 0; i < totalItensDiscretizados; i++)
			{
				teste_matrix = (matriz[i][i]);
				matrizInversa[i][i] = 1 / teste_matrix;
			}

			for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
				matrizInversa[i][i] = 1;

			if(caso == 1)
			{
				matrizInversa[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = 1;
				for(i = 0; i < totalItensDiscretizados; i++)
				{
					teste_matrix = (matriz[i][i]);
					matrizInversa[totalItensDiscretizados + maior][i] = -1 / teste_matrix;
				}
			}
			else
			{
				matrizInversa[totalItensDiscretizados + maior][totalItensDiscretizados + maior] = -1;
				for(i = 0; i < totalItensDiscretizados; i++)
				{
					teste_matrix = (matriz[i][i]);
					matrizInversa[totalItensDiscretizados + maior][i] = 1 / teste_matrix;
				}
			}
			//FIM INVERSA BASE INICIAL

			//C�LCULO DO CUSTO DOS ITENS
			for(i = 0; i < qtdTiposItem; i++)
				dados[i].utilidade = cost_bar[maior];
				
			for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
				dados[i].utilidade = (minPositivo) * cost_bar[maior];

			if(caso == 2)
				dados[totalItensDiscretizados + maior].utilidade = custoAlto;
			//FIM C�LCULO DO CUSTO DOS ITENS

			//MULTIPLICADOR SIMPLEX INICIAL
			if(caso == 1)
			{
				for(i = 0; i < qtdTiposItem; i++)
					multiplicadorSimplex[i] = cost_bar[maior] / matriz[i][i];
					
				for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
					multiplicadorSimplex[i] = (minPositivo) * cost_bar[maior] / matriz[i][i];
			}
			else
			{
				for(i = 0; i < totalItensDiscretizados; i++)
					multiplicadorSimplex[i] = (cost_bar[maior] + custoAlto) / matriz[i][i];
				multiplicadorSimplex[totalItensDiscretizados+maior] = -custoAlto;
			}
			//FIM MULTIPLICADOR SIMPLEX INICIAL

			solCR* lista = criaLista();
			bool recalcula = usaKmelhores;
			int ii = 0;
			time_t fim, inicio;
			int *troca = new int[totalItensDiscretizados];
			int *demanda = new int[totalItensDiscretizados];

			for(int h = 0; h < totalItensDiscretizados; h++){
				troca[h] = dados[h].l;
				demanda[h] = dados[h].demanda;
			}

			while(!pare)
			{
				chamamochila = true;
				custo_var_folga = -custoAlto;

				for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
					if(multiplicadorSimplex[i] > minPositivo && multiplicadorSimplex[i] > custo_var_folga)
					{
						custo_var_folga = -multiplicadorSimplex[i];
						indice = i - totalItensDiscretizados;
						chamamochila = false;
					}
				
				if(!chamamochila)
				{
					g = custo_var_folga;

					for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
						alfa[i] = 0;
					alfa[totalItensDiscretizados + indice] = 1;
				}
				else
				{
					g = custoAlto;
					ii++;

					for(i = 0; i < totalItensDiscretizados; i++)
						valor[i] = multiplicadorSimplex[i];
					indice = -1;

					mochila m;

					solucao matriz_K;
					float menorUtilidade = dados[0].utilidade;
					int menorItemComDemanda = size_bar[maior] + 1;

					for(int h = 0; h < totalItensDiscretizados; h++){
						dados[h].utilidade = dados[h].l + valor[h];
						if (dados[h].utilidade < menorUtilidade)
							menorUtilidade = dados[h].utilidade;
						if (h >= qtdTiposItem){
							menorUtilidade = menorUtilidade	* 0,9;
							dados[h].utilidade = menorUtilidade;
						}
						if (dados[h].utilidade > 0 && dados[h].demanda > 0 && menorItemComDemanda > dados[h].l)
							menorItemComDemanda = dados[h].l;
					}

					for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
						solucaoBB[i] = 0;
						
					if (!usaKmelhores){
						for(i = 0; i < qtdTiposBarras; i++){
							if(amount_bar[i] > 0 && (size_bar[i] > menorItemComDemanda))
							{
								for (int h = 0; h < qtdTiposItem; h++)
									ordem[h] = h;
								
								for (int h = 0; h < 1; h++){
									for (int j = 0; j < qtdTiposItem + 1; j++)
										xs[h][j] = 0;
								}

								Ordena(totalItensDiscretizados, dados);
								
								//CHAMA O PROCEDIMENTO QUE RESOLVE O PROBLEMA DA MOCHILA
								m.branch_bound_k(dados, totalItensDiscretizados, size_bar[i], k_solucoes, menorItem, &matriz_K, &fim, &inicio);
								
								Reordena(totalItensDiscretizados, dados, matriz_K, troca);
									
								cr = (cost_bar[i]) - matriz_K[0].valor - multiplicadorSimplex[totalItensDiscretizados+i];

								//verifica se o custo do novo padr�o � menor do que o melhor padr�o encontrado at� o instante
								if(cr - g < 0.000001)
								{
									g = cr;
									indice = i;
									
									for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
										alfa[j] = 0;
										
									//for(j = 0; j < totalItensDiscretizados; j++)
									//	alfa[j] = solucaoBB[j];
									for (j = 0; j < matriz_K[0].tamanho_k; j++){
										alfa[matriz_K[0].indice[j]] = matriz_K[0].sol[j];
									}
								}
							}
						if(indice != -1)
							alfa[totalItensDiscretizados+indice] = 1;
						}
					}

					if (usaKmelhores){
						if (acabouKmelhores){
							for(i = 0; i < qtdTiposBarras; i++){
								if(amount_bar[i] > 0 && (size_bar[i] > menorItemComDemanda))
								{
									for (int h = 0; h < qtdTiposItem; h++)
										ordem[h] = h;
									
									for (int h = 0; h < 1; h++){
										for (int j = 0; j < qtdTiposItem + 1; j++)
											xs[h][j] = 0;
									}

									Ordena(totalItensDiscretizados, dados);
									
									//CHAMA O PROCEDIMENTO QUE RESOLVE O PROBLEMA DA MOCHILA
									m.branch_bound_k(dados, totalItensDiscretizados, size_bar[i], k_solucoes, menorItem, &matriz_K, &fim, &inicio);
								
									Reordena(totalItensDiscretizados, dados, matriz_K, troca);
									
									double valorK;

									for (int kk = 0; kk < k_solucoes; kk++){
										if (matriz_K[kk].tamanho_k > 0){
											for (int jj = 0; jj < (totalItensDiscretizados + qtdTiposBarras); jj++)
												alfa[jj] = 0;
											for (int jj = 0; jj < matriz_K[kk].tamanho_k; jj++)
												alfa[matriz_K[kk].indice[jj]] = matriz_K[kk].sol[jj];

											valorK = 0;
											for (int jj = 0; jj < matriz_K[kk].tamanho_k; jj++) 
												valorK += dados[matriz_K[kk].indice[jj]].utilidade * matriz_K[kk].sol[jj];
											matriz_K[kk].valor = valorK;

											cr = (cost_bar[i]) - matriz_K[kk].valor - multiplicadorSimplex[totalItensDiscretizados+i];

											lista = insereListaOrdenado(lista, matriz_K[kk].valor, alfa, cr, i, totalItensDiscretizados);
										}
									}
								}
							}
							
							recalcula = ((lista != NULL) && (lista->cr < -1) && (ii < 10000));
							acabouKmelhores = false;
						}

						lista = reordenaLista(lista, totalItensDiscretizados, cost_bar, multiplicadorSimplex, dados);

						if (!acabouKmelhores){
							if((lista != NULL) && (lista->cr < 0) && (lista->cr - g < 0.000001))
							{
								g = lista->cr;
								indice = lista->indice;

								for(int jj  = 0; jj < (totalItensDiscretizados + qtdTiposBarras); jj++)
									alfa[jj] = 0;
								for(int jj  = 0; jj < totalItensDiscretizados; jj++)
									alfa[jj] = lista->sol[jj];

								lista = lista->prox;
							}
							else
							{
								indice = -1;
								acabouKmelhores = true;
								lista = criaLista();
							}
							
							if(indice != -1)
								alfa[totalItensDiscretizados+indice] = 1;
						}
					}
				}
				
				aux = floor(g*-100);
				
				//TESTE DE OTIMALIDADE
				if(aux <= 0)
				{
					if (!recalcula){
						pare = true;
					
						if(idBarraPadrao[totalItensDiscretizados + maior] == -HUGE_VAL && solucaoInicial[totalItensDiscretizados + maior] > minPositivo)
							fo = 100;
						else
						{
							for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
							{
								if((idBarraPadrao[i] < 0 && idBarraPadrao[i] != HUGE_VAL) || solucaoInicial[i] < minPositivo)
								{
									j = i + 1;
									
									while(idBarraPadrao[j] < 0 && idBarraPadrao[j] != HUGE_VAL)
										j++;

									if(j < (totalItensDiscretizados + qtdTiposBarras))
										TrocaBase(i,j,idBarraPadrao,&matriz,solucaoInicial,totalItensDiscretizados,qtdTiposBarras);
								}
							}
							
							i = 0;
				
							while(idBarraPadrao[i] >= 0)
								i++;

							tam_sol = i - 1;

							fo = 0;
							for(i = 0; i < tam_sol; i++)
								fo += solucaoInicial[i];
						}
					}
				}
				else
				{
					CalculaDirecaoSimplex(direcaoSimplex,matrizInversa,alfa,indice,totalItensDiscretizados,qtdTiposBarras);
					CalculaPasso(solucaoInicial,direcaoSimplex,&passoSimplex,&indiceNovoPadrao,totalItensDiscretizados,qtdTiposBarras,qtdTiposItem);
					AtualizaMatriz(&solucaoHomogenea,maiorBarra,size_bar,&demanda,dados,&matriz,alfa,indiceNovoPadrao,idBarraPadrao,indice,&matrizInversa,direcaoSimplex,solucaoInicial,passoSimplex,multiplicadorSimplex,g,totalItensDiscretizados,qtdTiposBarras);
					

					if(!chamamochila)
						idBarraPadrao[indiceNovoPadrao] = -indice;
				}
			}
			//printf("SAIU TUDO");

			vector<vector<int>> matsol(2 * (totalItensDiscretizados + qtdTiposBarras),vector<int>(tam_sol));
			vector<float> vetsol(tam_sol);
			float auxf_troca;
			int auxi_troca;

			j = 0;
			n = 0;

			fflush(out);

			//passa os padr�es gerados na matriz "matriz" para a matriz "matsol", j� verificando o n�mero de retalhos usados
			//as frequ�ncias dos padr�es s�o passadas do vetor solucaoInicial para o vetsol
			while (j < tam_sol && n < tam_sol + 2)
			{
				//VerificaPadraoNulo - verifica se o padr�o n�o � um padr�o nulo
				if(VerificaPadraoNulo(matriz,n,qtdTiposItem))
				{
					//IF e ELSE para controlar a quantidade de retalhos
					//Perda - devolve o valor da perda inteira do padr�o (se houver sobra, essa fun��o considera como perda)
					if(PerdaPadrao(matriz,n,qtdTiposItem,dados,size_bar,totalItensDiscretizados,qtdTiposBarras) < perc_min_perda || maxRetalho > 0)
					{
						vetsol[j] = solucaoInicial[n];
						idBarraPadrao[j] = idBarraPadrao[n];
						for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
							matsol[i][j] = matriz[i][n];
					}
					else
					{
						//Retalho - devolve o tamanho do retalho no padr�o, se houver
						if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,dados,totalItensDiscretizados) && maxRetalho > 0)
						{
							vetsol[j] = solucaoInicial[n];
							idBarraPadrao[j] = idBarraPadrao[n];
							for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
								matsol[i][j] = matriz[i][n];
						}
						else
						{
							//Caso o padr�o gere retalho e o limite de retalhos j� estourou, a frequ�ncia do padr�o � zerada
							if(maxRetalho == 0)
							{
								vetsol[j] = solucaoInicial[n];
								if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,dados,totalItensDiscretizados))
									vetsol[j] = 0;

								idBarraPadrao[j] = idBarraPadrao[n];
								for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
									matsol[i][j] = matriz[i][n];
							}
						}
					}
					j++;
				}
				n++;
			}
	
			//Teste para garantir a integridade do tam_sol
			if(j < tam_sol)
				tam_sol = j;

			//Ordenar os padr�es pela menor frequ�ncia
			i = 0;
			j = 0;
			n = 0;
			p = 0;
			while (j<tam_sol-1)
			{
				if(VerificaPadraoNulo(matriz,n,qtdTiposItem))
				{	
					i = j+1;
					p = j+1;
					while(i<tam_sol && p<tam_sol)
					{
						if(VerificaPadraoNulo(matriz,p,qtdTiposItem))
						{
							//o primeiro if abaixo � para ordena��o pela frequ�ncia, o segundo � para ordena��o pela perda
							if(vetsol[n] < vetsol[p])
							//if(PerdaPadrao(matriz,n,qtdTiposItem,size_item,size_bar,totalItensDiscretizados,qtdTiposBarras) > PerdaPadrao(matriz,p,qtdTiposItem,size_item,size_bar,totalItensDiscretizados,qtdTiposBarras))
							{
								auxf_troca = vetsol[n];
								vetsol[n] = vetsol[p];
								vetsol[p] = auxf_troca;

								for(aux = 0; aux<2*(totalItensDiscretizados+qtdTiposBarras); aux++)
								{
									auxi_troca = matsol[aux][n];
									matsol[aux][n] = matsol[aux][p];
									matsol[aux][p] = auxi_troca;
								}

								auxi_troca = idBarraPadrao[n];
								idBarraPadrao[n] = idBarraPadrao[p];
								idBarraPadrao[p] = auxi_troca;
							}
							i++;
						}
						p++;
					}
					j++;
				}
				n++;
			}
			
			//Se quiser verificar todos os padr�es gerados (ordenados) antes da heur�stica ser aplicada neles � s� descomentar
			//a parte de c�digo abaixo
			
			/*fprintf(out,"\nANTES DA HEUR�STICA\n");
			for(j = 0; j < tam_sol; j++)
			{
				if(vetsol[j] > 0.0001)
				{
					fprintf(out,"Frequencia: %4.2lf\n",vetsol[j]);
					for(n = 0; n < totalItensDiscretizados; n++)
						fprintf(out,"(%d)(%4.2lf)%d\t",size_item[n],amount_item[n],matsol[n][j]);
					fprintf(out,"\n");
				}
			}
			
			fflush(out);*/
	
			printf("Cheguei nos finalmentes\n");
			printf("Tam_Sol: %d\n",tam_sol);
			printf("Aplicando Heuristica de Arredondamento\n");

			for(j = 0; j< qtdTiposItem; j++)
				auxd[j] = 0;
			
			for(j = 0; j < qtdTiposBarras; j++)
				estoqueutilizado[j] = 0;

			//Verificar a factibilidade
			i = 0;			
			j = 0;
			n = 0;

			for(i = 0; i < tam_sol; i++)
			{
				ok = true;
				
				//Arredonda o padr�o para cima
				if(vetsol[i] > minPositivo && VerificaPadraoNulo(matsol,i,qtdTiposItem))
					vetsol[i] = ceil(vetsol[i]);
				else
					vetsol[i] = 0;
				
				do
				{
				
					//Verificar a factibilidade com rela��o a quantidade de itens cortados
					for(j = 0; j< qtdTiposItem; j++)
						auxd[j] = 0;

					for(n = 0; n < qtdTiposItem; n++)
						for(j = 0; j < tam_sol; j++)
						{
							if(j > i && vetsol[j] > 0.000001)
								auxd[n] += floor(vetsol[j]) * matsol[n][j];
							if(j <= i)
								auxd[n] += vetsol[j] * matsol[n][j];
						}

					ok = true;

					for(j = 0; j < qtdTiposItem; j++)
						if(auxd[j] - dados[j].demanda > 0.000001)
							ok = false;
					
					//Verificar a factibilidade com rela��o a quantidade de barras cortadas
					for(j = 0; j < qtdTiposBarras; j++)
						estoqueutilizado[j] = 0;

					for(j = 0; j < tam_sol; j++)
						estoqueutilizado[idBarraPadrao[j]] += vetsol[j];

					for(j = 0; j < qtdTiposBarras; j++)
						if(estoqueutilizado[j] - amount_bar[j] > 0.000001) 
							ok = false;
					
					while(!ok)
					{
						//Se o padr�o viola qualquer uma das duas verifica��es de factibilidade
						//sua frequ�ncia � reduzida em uma unidade
						vetsol[i] -= 1;

						//Verificar a factibilidade com rela��o a quantidade de itens cortados
						for(j = 0; j < qtdTiposItem; j++)
							auxd[j] = 0;
			
						for(n = 0; n < qtdTiposItem; n++)
							for(j = 0; j < tam_sol; j++)
							{
								if(j > i && vetsol[j] > 0.000001)
									auxd[n] += floor(vetsol[j]) * matsol[n][j];
								if(j <= i)
									auxd[n] += vetsol[j] * matsol[n][j];
							}

						ok = true;

						for(j = 0; j < qtdTiposItem; j++)
							if(auxd[j] - dados[j].demanda > 0.000001)
								ok = false;

						//caso o padr�o verificado atinge frequ�ncia 0, a heur�stica sai do loop e vai para o pr�ximo padr�o
						if(vetsol[i] <= 0.000001)
						{
							vetsol[i] = 0;
							ok = true;
						}
					}
				}while(!ok);
			}

			for(n = 0; n < qtdTiposItem; n++)
				auxd[n] = 0;

			//Soma a quantidade de cada item cortado em todos os padr�es de corte
			for(j = 0; j < tam_sol; j++)
				if(vetsol[j] > 0.000001)
				{
					for(n = 0; n < qtdTiposItem; n++)
						auxd[n] += vetsol[j] * matsol[n][j];
				}
			
			//Atualiza a demanda dos itens 
			for(j = 0; j < qtdTiposItem; j++)
				dados[j].demanda -= auxd[j];

			for(j = 0; j < qtdTiposBarras; j++)
				estoqueutilizado[j] = 0;

			//Soma a quantidade de cada barra cortada
			for(j = 0; j < tam_sol; j++)
				estoqueutilizado[idBarraPadrao[j]] += vetsol[j];

			//Atualiza o estoque das barras
			for(j = 0; j < qtdTiposBarras; j++)
				amount_bar[j] -= estoqueutilizado[j];				
	
			printf("Arredondamento finalizado\n");

			//Se quiser verificar todos os padr�es gerados depois da heur�stica ser aplicada neles � s� descomentar
			//a parte de c�digo abaixo
	
			/*fprintf(out,"\nDEPOIS DA HEUR�STICA\n");
			for(j = 0; j < tam_sol; j++)
			{
				if(vetsol[j] > 0.0001)
				{
					fprintf(out,"Frequencia: %4.2lf\n",vetsol[j]);
					for(n = 0; n < qtdTiposItem; n++)
						fprintf(out,"(%d)(%4.2lf)%d\t",size_item[n],amount_item[n],matsol[n][j]);
					fprintf(out,"\n");
				}
			}
			fflush(out)*/

			//Verifica se o grupo de padr�es de corte gerado � o ultimo (toda a demana cumprida)
			ok = true;
			for(j = 0; j < qtdTiposItem; j++)
				if(dados[j].demanda > 0)
					ok = false;

			leftover = -1;

			//VERIFICA �LTIMO PADR�O
			//Se for o �ltimo grupo, verifica qual � o �ltimo padr�o gerado
			if(ok)
			{
				n = -1;
				for(j = 0; j < tam_sol; j++){
					if(VerificaPadraoNulo(matsol,j,qtdTiposItem) && vetsol[j] > 0.5)
						n = j;
				}

				//if (n > -1){
					loss = PerdaPadrao(matsol,n,qtdTiposItem,dados,size_bar,totalItensDiscretizados,qtdTiposBarras);

					//Se o �ltimo padr�o possui um retalho de tamanho padronizado (300,400,500), esse retalho � zerado
					//j� que toda a perda ser� considerada como um retalho
					for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
						matsol[i][n] = 0;
					
					//Se no �ltimo padr�o a perda for maior ou igual a 300, toda a perda � considerada como um retalho
					if (loss > dados[qtdTiposItem].l)
					{
						leftover = n;
					}
				//}
			}
			//FIM DO VERIFICA �LTIMO PADR�O

			fprintf(out,"max retalho: %d\n",maxRetalho);
			fflush(out);

			double val_total = 0;
			j = 0;
			n = 0;
			
			//Imprime as solu��es obtidas no arquivo de sa�da
			while (j < tam_sol)
			{
				if(VerificaPadraoNulo(matsol,n,qtdTiposItem))
				{
					loss = PerdaPadrao(matsol,n,qtdTiposItem,dados,size_bar,totalItensDiscretizados,qtdTiposBarras);
					
					//Verifica integridade do n�mero de retalhos usados
					if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) && maxRetalho == 0 && vetsol[n] > 0.5)
					{
						amount_bar[idBarraPadrao[j]] += vetsol[n];
						vetsol[n] = 0;
						for(i = 0; i < qtdTiposItem; i++)
							dados[i].demanda += matsol[i][n];
					}

					//Verifica se o padr�o de corte n�o possui frequ�ncia nula
					if(vetsol[n] > 0.5)
					{
						//Se um dia achar necess�rio us�-la novamente :)
						//POG DA ADRIANA
						//if (loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)> 299.99){
							/*if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)> 499.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) != 500)
							{
								matsol[totalItensDiscretizados - 3][n] ++;
							}
							if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)> 399.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) != 400)
							{
								matsol[totalItensDiscretizados - 2][n] ++;
							}
							if ((loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)> 299.99) && TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) != 300)
							{
								matsol[totalItensDiscretizados - 1][n] ++;
							}*/
						//}
						//FIM POG

						fprintf(out,"\n(%d)(%d)\t%4.2f\t",n,size_bar[idBarraPadrao[j]],vetsol[n]);

						////Dados para o relat�rio
						//qtdd_obj += vetsol[n];
						//if (idBarraPadrao[j] == 0 || idBarraPadrao[j] == 1)
						//{
						//	if(idBarraPadrao[j] == 0)
						//		obj_padrao0 += vetsol[n];
						//	else
						//		obj_padrao1 += vetsol[n];

						//	qtdd_padrao += vetsol[n];
						//}
						//else
						//{
						//	obj_retalho += vetsol[n];
						//	//tam_total += (double)(vetsol[n] * size_bar[idBarraPadrao[j]]) / 5;
						//}
						////Fim dados para relat�rio
							
						val_total = 0;
						//Imprime o tamanho do item e a quantidade cortada do mesmo no padr�o de corte
						for(i = 0; i < totalItensDiscretizados; i++)
							if (matsol[i][n] > 0)
								fprintf(out,"(%d)%d\t",dados[i].l,matsol[i][n]);

						//Se n�o for o �ltimo padr�o de corte	
						if(leftover != n)
						{
							//Imprime a perda (descontando um eventual retalho que possa existir no padr�o)
							fprintf(out,"%4.2f\t",(loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)));
							
							//Imprime um poss�vel retalho que possa existir no padr�o
							fprintf(out,"%d\t",TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados));
							
							//Atualiza a quantidade m�xima de retalhos permitida
							if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) > 100)
								maxRetalho--;
						}
						else
						{
							//Se for o �ltimo padr�o de corte (com perda >= 300), considera toda a perda como retalho
							fprintf(out,"0\t");
							fprintf(out,"%d\t",(int)loss);
						}

						//If e ELSE abaixo pegam os valores de retalho para que no pr�ximo per�odo ele seja considerado como um objeto a ser cortado
						if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) > 0 || leftover == n)
						{
							if(leftover == n)
							{
								retalhos_gerados[qtdRetalhos] = loss;
								amount_retalhos_gerados[qtdRetalhos] = vetsol[n];
								qtdRetalhos++;
							}
							else
							{
								for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
								{
									if(matsol[i][n] > 0)
									{
										retalhos_gerados[qtdRetalhos] = dados[i].l;
										amount_retalhos_gerados[qtdRetalhos] = vetsol[n]*matsol[i][n];
										qtdRetalhos ++;
									}
								}
							}
						}
						
						//Dados para o relat�rio
						if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados) || leftover == n)
						{
							if(leftover == n)
							{
								total_sobra += vetsol[n]*loss;
								loss = 0;
							}
							else
							{
								total_sobra += vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados);
								total_perda += vetsol[n]*loss - (vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,dados,totalItensDiscretizados)); 
							}
						}
						else
						{
							total_perda += vetsol[n]*loss;
						}

						//if(!loss)
							//obj_perfeito += vetsol[n];
						//else
							//obj_com_perda += vetsol[n];
						//Fim Dados para Relat�rio
				
						fprintf(out,"\n");
					}
					j++;
				}
				n++;
			}
			
			printf("Terminei a iteracao %d\n",iteracao);
			iteracao++;
			if (iteracao > 100){
				comecar = numArquivoEntrada + 1;
				goto Volta;
			}

			pare = false;

			//Verifica se toda a demanda foi cumprida, sen�o volta para o come�o do programa (Inicio:) para fazer todo o processo de novo
			//agora com as demandas atualizadas
			for(i = 0; i<qtdTiposItem; i++)
				if(dados[i].demanda > 0)
					goto Inicio;

			//Se toda demanda foi cumprida ent�o imprime os valores totais de sobra e perda obtidos, assim como a quantidade de 
			//itens padronizados cortados
			fprintf(out,"Sobra Total: %4.2f\n",total_sobra);
			fprintf(out,"Perda Total: %4.2f\n",total_perda);
			fprintf(out,"\nTotal Barras Cortadas:\n");
			
			for(i = 0; i < qtdTiposBarras; i++)
			{
				qtdd_bar_usadas = amount_bar_fixo[i] - amount_bar[i];
				fprintf(out,"Barra (%d) : %d\n",size_bar[i],qtdd_bar_usadas);
			}

			fprintf(out, "\nRetalhos Gerados:\n");
			for(i = 0; i < qtdRetalhos; i++)
				if(retalhos_gerados[i] > 0)
					fprintf(out,"Retalho (%d) : %d\n",retalhos_gerados[i],amount_retalhos_gerados[i]);

			fclose(in);
			fclose(out);

			//Dados para o relat�rio
			//qtdd_padrao += num_padrao;

			//ATUALIZA N�MERO DE RETALHOS PARA O PR�XIMO PER�ODO
			auxQtdRetalhos = qtdRetalhos + qtdTiposBarras - 2;
			j = 0;

			for(i = 2; i < qtdTiposBarras; i++)
			{
				if(amount_bar[i] > 0)
				{
					aux_retalhos_gerados[j] = size_bar[i];
					aux_amount_retalhos_gerados[j] = amount_bar[i];
					j++;
				}
				else
					auxQtdRetalhos --;
			}

			for(i = 0; i < qtdRetalhos; i++)
			{
				if(amount_retalhos_gerados[i] > 0)
				{
					aux_retalhos_gerados[j] = retalhos_gerados[i];
					aux_amount_retalhos_gerados[j] = amount_retalhos_gerados[i];
					j++;
				}
				else
					auxQtdRetalhos --;
			}

			for(i = 0; i < auxQtdRetalhos; i++)
			{
				retalhos_gerados[i] = aux_retalhos_gerados[i];
				amount_retalhos_gerados[i] = aux_amount_retalhos_gerados[i];
			}
			qtdRetalhos = auxQtdRetalhos;
			//FIM DA ATUALIZA��O
		}
	}

	//Abre o arquivo que vai conter as informa��es do relat�rio
	//strcpy(entrada,"Saida/D1-Relatorio.txt");
	//strcpy(entrada,"Alex/Saida/E3-Relatorio.txt");

	//report = fopen(entrada, "w");

	//fprintf(report,"\nRelat�rio\n");
	//fprintf(report,"\n>>>Minimizar a Perda Total<<<\n");

	//Informa��es para um relat�rio mais completo, igual usado nas 16 classes com 20 exemplos cada
	//S� descomentar o bloco abaixo
	/*tam_total_padrao = (obj_padrao0/5)*1000+(obj_padrao1/5)*1100;
	tam_total += tam_total_padrao;

	fprintf(report,"N�mero m�dio de objetos cortados: %.2f\n",qtdd_obj/5);
	fprintf(report,"N�mero m�dio de padr�es de corte: %.2f\n",qtdd_padrao/5);
	fprintf(report,"Tempo m�dio (segundos): %.2f\n",tempo_total/5);
	fprintf(report,"Perda m�dia: %.2f\n",perda_total/5);
	fprintf(report,"Porcentagem de Perda M�dia: %.2f%c\n",100*((perda_total/5)/tam_total),'%');
	fprintf(report,"Perda total: %.2f\n",perda_total);
	fprintf(report,"Sobra m�dia: %.2f\n",sobra_total/5);
	fprintf(report,"N�mero total de retalhos: %.2f\n",obj_com_sobra);
	fprintf(report,"N�mero m�dio de objetos retalhos: %.2f\n",obj_retalho/5);
	fprintf(report,"N�mero total de objetos retalhos cortados: %.2f\n",obj_retalho);
	fprintf(report,"N�mero m�dio de objetos cortados sem perda: %.2f\n",obj_perfeito/5);
	fprintf(report,"N�mero m�dio de objetos cortados com perda: %.2f\n",obj_com_perda/5);
	fprintf(report,"N�mero m�dio de objetos cortados com sobra: %.2f\n",obj_com_sobra/5);
	fprintf(report,"N�mero m�dio de objetos padronizados: %.2f\n",(obj_padrao0+obj_padrao1)/5);
	fprintf(report,"N�mero m�dio de objetos padronizados(1000): %.2f\n",obj_padrao0/5);
	fprintf(report,"N�mero m�dio de objetos padronizados(1100): %.2f\n",obj_padrao1/5);
	fprintf(report,"Tamanho m�dio de objetos padronizados cortados: %.2f\n",tam_total_padrao);*/

	
	//Informa��es para um relat�rio mais resumido, igual o gerado nos exemplos do Alex
	
	//Para cada problema do Alex, o tamanho das barras (6000, 3500) � diferente, tem que atualizar
	//tam_total_padrao = 3500*obj_padrao0;
	//tam_total_padrao = 3000*obj_padrao1;

	//fprintf(report,"Porcentagem de Perda: %.2f%c\n",100*(perda_total/tam_total_padrao),'%');
	//fprintf(report,"N�mero de retalhos gerados: %.2f\n",obj_com_sobra);
	//fprintf(report,"N�mero total de objetos cortados: %.2f\n",(obj_padrao0+obj_padrao1));
	//fprintf(report,"N�mero de objetos cortados(tipo1): %.2f\n",obj_padrao0);
	//fprintf(report,"N�mero de objetos cortados(tipo2): %.2f\n",obj_padrao1);

	//fclose(report);
    return 0;
}
