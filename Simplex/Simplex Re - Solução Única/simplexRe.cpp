#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <Windows.h>
#include <math.h>
#include <vector>
#include "mochila.h"

// Auxiliar para verificar número negativo
#define minPositivo 0.00001
// Váriavel utilizada no cálculo do Branch and Bound
#define custoAlto 10000
// Quantidade máxima de diferentes tipos de retalhos permitidos
#define maxQtdTipoRetalho 0
// Diretório dos arquivos de entrada
#define dirArquivoEntrada "Arquivo/Entrada/D1d"
// Diretório dos arquivos de saida e relatórios
#define dirArquivoSaidaRelatorio "Arquivo/Saida/S-D1d"
// Quantidade de arquivos de entrada que devem ser lidos
#define qtdArquivosEntrada 20

using namespace std;

// in - arquivo de entrada
// out - arquivo de saída
// report - relatório
FILE *in, *out, *report;

// Número máximo de retalhos que pode ser gerado (informação do arquivo de entrada)
int maxRetalho;

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
void AtualizaMatriz(vector<vector<int>> *matriz, float alfa[], int indiceNovoPadrao, int idBarraPadrao[], int indice, vector<vector<float>> *matrizInversa, float direcaoSimplex[], float solucaoInicial[], float passoSimplex, float multiplicadorSimplex[], float custoMinimo, int totalItensDiscretizados, int qtdTiposBarras)
{
	int i,j;

	for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
		(*matriz)[i][indiceNovoPadrao] = floor(alfa[i]);

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
}

int VerificaPadraoNulo(vector<vector<int>> matriz, int j, int qtdTiposItem)
{
	int i;

	for(i = 0; i < qtdTiposItem; i++)
		if(matriz[i][j] > 0)
			return 1; // Padrão não nulo
			
	return 0; // Padrão nulo
}

double PerdaPadrao(vector<vector<int>> matriz, int j, int qtdTiposItem, int tamanhoItem[], int tamanhoBarra[],int totalItensDiscretizados, int qtdTiposBarras)
{
	int i, indice;
	int soma = 0;

	for(i = 0; i < qtdTiposItem; i++)
		soma += tamanhoItem[i] * matriz[i][j];

	for(i = totalItensDiscretizados; i < (totalItensDiscretizados + qtdTiposBarras); i++)
		if(matriz[i][j] != 0)
		{
			indice = i;
			break;
		}

	return tamanhoBarra[indice - totalItensDiscretizados] - soma;
}

int TamanhoRetalhoPadrao(vector<vector<int>> matriz, int j, int qtdTiposItem, int tamanhoItem[], int totalItensDiscretizados)
{
	int i;
	int total = 0;

	for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
		if(matriz[i][j] > 0)
			total += matriz[i][j] * tamanhoItem[i];

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

	//Variáveis para o ultimo padrão
	//int leftover;

	for(numArquivoEntrada = 1; numArquivoEntrada <= qtdArquivosEntrada; numArquivoEntrada++)
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

			fprintf(out,"\nSaida %s\n", entrada);
			fprintf(out,"\nMinimizar a Perda Total\n");
		         	   
			float lixo;
			int qtdTiposBarras;
			float total_sobra = 0;
			float total_perda = 0;

			fscanf(in, "%d\n", &qtdTiposBarras);

			qtdTiposBarras += qtdRetalhos;

			//variáveis utilizadas para controle dos valores das barras
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
			
			int *size = new int[qtdTiposItem];
			int *amount = new int[qtdTiposItem];
			int *cost = new int[qtdTiposItem];		 

			//leitura dos valores dos itens a serem cortados
			for (i=0; i<qtdTiposItem; i++)
				fscanf(in, "%d %d %d\n", &sujeira, &size[i], &amount[i]);

			fscanf(in, "%d\n", &qtdd_bar_ret);
			fscanf(in, "%f\n", &perc_min_perda);
			fscanf(in, "%f\n", &lixo);
			fscanf(in, "%d\n", &maxRetalho);
			fscanf(in, "%d\n", &mediaItens);
	       
			//calculo da quantidade de itens discretizados que haverá
			totalItensDiscretizados = qtdTiposItem + maxQtdTipoRetalho;

			int menorItem = size[0];

			for (i = 1; i < qtdTiposItem; i++)
			{
				if (size[i] < menorItem)
					menorItem = size[i];
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

			//variáveis utilizadas para controle dos itens a serem cortados
			int *y = new int[totalItensDiscretizados];
			int *size_item = new int[totalItensDiscretizados];
			float *amount_item = new float[totalItensDiscretizados];
			float *cost_item = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *solucao = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
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
			float *multiplicadorSimplex = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *valor = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *perda = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			float *alfa = new float[2 * (totalItensDiscretizados + qtdTiposBarras)];
			int caso = 1;
			int indiceNovoPadrao;
			float custo_var_folga = 0;
			float z;
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

			for(i = 0; i < qtdTiposItem; i++)
			{
				size_item[i] = size[i];
				amount_item[i] = amount[i];
			}
	       
			if (maxQtdTipoRetalho > 0){
				int s = (int)((maiorBarra - menorItem - mediaItens) / maxQtdTipoRetalho);

				for(i = 0; i < maxQtdTipoRetalho; i++)
				{
					size_item[qtdTiposItem + i] = mediaItens + (s * i);
					amount_item[qtdTiposItem + i] = 10;
				}
			}

			qtdRetalhos = 0;
			for (i = 0; i < 100; i++)
			{
				retalhos_gerados[i] = 0;
				amount_retalhos_gerados[i] = 0;
			}

	Inicio:
			
			//Inicializando as variáveis
			for (i = totalItensDiscretizados; i < 2 * totalItensDiscretizados; i++)
				cost_item[i] = 0;

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
				cost_item[i] = 0;
			}

			/// CUTTING-OPTIMIZATION PROBLEM ///

			//BASE HOMOGÊNEA
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
					
				if(size_bar[maior] / size_item[i] > amount_item[i])
					matriz[i][i] = amount_item[i];
				else
					matriz[i][i] = size_bar[maior] / size_item[i];

				if(matriz[i][i] == 0)
				{
					matriz[i][i] = 1;
					idBarraPadrao[i] = -maior;
				}
			}

			for(i = 0; i < totalItensDiscretizados; i++)
				matriz[totalItensDiscretizados + maior][i] = 1;

			for(i = 0; i < qtdTiposBarras; i++)
			{
				idBarraPadrao[totalItensDiscretizados + i] = -i;
				matriz[totalItensDiscretizados + i][totalItensDiscretizados + i] = 1;
			}
			//FIM BASE HOMOGÊNEA

			//SOLUÇÃO INICIAL
			for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
				solucaoInicial[i] = 0;
				
			for(i = 0; i < totalItensDiscretizados; i++)
			{
				teste_matrix = matriz[i][i];
				solucaoInicial[i] = amount_item[i] / teste_matrix;
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
			//FIM SOLUÇÃO INICIAL

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

			//CÁLCULO DO CUSTO DOS ITENS
			for(i = 0; i < qtdTiposItem; i++)
				cost_item[i] = cost_bar[maior];
				
			for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
				cost_item[i] = (minPositivo) * cost_bar[maior];

			if(caso == 2)
				cost_item[totalItensDiscretizados + maior] = custoAlto;
			//FIM CÁLCULO DO CUSTO DOS ITENS

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


					indice = -1;

					for(i = 0; i < (totalItensDiscretizados + qtdTiposBarras); i++)
						solucao[i] = 0;
						
					for(i = 0; i < qtdTiposBarras; i++)
						if(amount_bar[i] > 0)
						{
							for (int h = 0; h < qtdTiposItem; h++)
								ordem[h] = h;
							
							for (int h = 0; h < 1; h++){
								for (int j = 0; j < qtdTiposItem + 1; j++)
									xs[h][j] = 0;
							}
							
							mochila m;


							//CHAMA O PROCEDIMENTO QUE RESOLVE O PROBLEMA DA MOCHILA
							z = m.calculaMochila(maxRetalho, minPositivo, size_bar[i],qtdTiposItem,size_item,valor,amount_item,totalItensDiscretizados,solucao);


							cr = (cost_bar[i]) - z - multiplicadorSimplex[totalItensDiscretizados+i];

							//verifica se o custo do novo padrão é menor do que o melhor padrão encontrado até o instante
							if(cr - g < 0.000001)
							{
								g = cr;
								indice = i;
								
								for(j = 0; j < (totalItensDiscretizados + qtdTiposBarras); j++)
									alfa[j] = 0;
									
								for(j = 0; j < totalItensDiscretizados; j++)
									alfa[j] = solucao[j];
							}
						}
					if(indice != -1)
						alfa[totalItensDiscretizados+indice] = 1;
				}
				
				aux = floor(g*-100);
				
				//TESTE DE OTIMALIDADE
				if(aux <= 0)
				{
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
				else
				{
					CalculaDirecaoSimplex(direcaoSimplex,matrizInversa,alfa,indice,totalItensDiscretizados,qtdTiposBarras);
					CalculaPasso(solucaoInicial,direcaoSimplex,&passoSimplex,&indiceNovoPadrao,totalItensDiscretizados,qtdTiposBarras,qtdTiposItem);
					AtualizaMatriz(&matriz,alfa,indiceNovoPadrao,idBarraPadrao,indice,&matrizInversa,direcaoSimplex,solucaoInicial,passoSimplex,multiplicadorSimplex,g,totalItensDiscretizados,qtdTiposBarras);

					if(!chamamochila)
						idBarraPadrao[indiceNovoPadrao] = -indice;
				}
			}

			vector<vector<int>> matsol(2 * (totalItensDiscretizados + qtdTiposBarras),vector<int>(tam_sol));
			vector<float> vetsol(tam_sol);
			float auxf_troca;
			int auxi_troca;

			j = 0;
			n = 0;

			fflush(out);

			//passa os padrões gerados na matriz "matriz" para a matriz "matsol", já verificando o número de retalhos usados
			//as frequências dos padrões são passadas do vetor solucaoInicial para o vetsol
			while (j < tam_sol && n < tam_sol + 2)
			{
				//VerificaPadraoNulo - verifica se o padrão não é um padrão nulo
				if(VerificaPadraoNulo(matriz,n,qtdTiposItem))
				{
					//IF e ELSE para controlar a quantidade de retalhos
					//Perda - devolve o valor da perda inteira do padrão (se houver sobra, essa função considera como perda)
					if(PerdaPadrao(matriz,n,qtdTiposItem,size_item,size_bar,totalItensDiscretizados,qtdTiposBarras) < perc_min_perda || maxRetalho > 0)
					{
						vetsol[j] = solucaoInicial[n];
						idBarraPadrao[j] = idBarraPadrao[n];
						for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
							matsol[i][j] = matriz[i][n];
					}
					else
					{
						//Retalho - devolve o tamanho do retalho no padrão, se houver
						if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,size_item,totalItensDiscretizados) && maxRetalho > 0)
						{
							vetsol[j] = solucaoInicial[n];
							idBarraPadrao[j] = idBarraPadrao[n];
							for(i = 0; i < 2 * (totalItensDiscretizados + qtdTiposBarras); i++)
								matsol[i][j] = matriz[i][n];
						}
						else
						{
							//Caso o padrão gere retalho e o limite de retalhos já estourou, a frequência do padrão é zerada
							if(maxRetalho == 0)
							{
								vetsol[j] = solucaoInicial[n];
								if(TamanhoRetalhoPadrao(matriz,n,qtdTiposItem,size_item,totalItensDiscretizados))
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

			//Ordenar os padrões pela menor frequência
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
							//o primeiro if abaixo é para ordenação pela frequência, o segundo é para ordenação pela perda
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
			
			//Se quiser verificar todos os padrões gerados (ordenados) antes da heurística ser aplicada neles é só descomentar
			//a parte de código abaixo
			
			/*fprintf(out,"\nANTES DA HEURÍSTICA\n");
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
				
				//Arredonda o padrão para cima
				if(vetsol[i] > minPositivo && VerificaPadraoNulo(matsol,i,qtdTiposItem))
					vetsol[i] = ceil(vetsol[i]);
				else
					vetsol[i] = 0;
				
				do
				{
				
					//Verificar a factibilidade com relação a quantidade de itens cortados
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
						if(auxd[j] - amount_item[j] > 0.000001)
							ok = false;
					
					//Verificar a factibilidade com relação a quantidade de barras cortadas
					for(j = 0; j < qtdTiposBarras; j++)
						estoqueutilizado[j] = 0;

					for(j = 0; j < tam_sol; j++)
						estoqueutilizado[idBarraPadrao[j]] += vetsol[j];

					for(j = 0; j < qtdTiposBarras; j++)
						if(estoqueutilizado[j] - amount_bar[j] > 0.000001) 
							ok = false;
					
					while(!ok)
					{
						//Se o padrão viola qualquer uma das duas verificações de factibilidade
						//sua frequência é reduzida em uma unidade
						vetsol[i] -= 1;

						//Verificar a factibilidade com relação a quantidade de itens cortados
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
							if(auxd[j] - amount_item[j] > 0.000001)
								ok = false;

						//caso o padrão verificado atinge frequência 0, a heurística sai do loop e vai para o próximo padrão
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

			//Soma a quantidade de cada item cortado em todos os padrões de corte
			for(j = 0; j < tam_sol; j++)
				if(vetsol[j] > 0.000001)
				{
					for(n = 0; n < qtdTiposItem; n++)
						auxd[n] += vetsol[j] * matsol[n][j];
				}
			
			//Atualiza a demanda dos itens 
			for(j = 0; j < qtdTiposItem; j++)
				amount_item[j] -= auxd[j];

			for(j = 0; j < qtdTiposBarras; j++)
				estoqueutilizado[j] = 0;

			//Soma a quantidade de cada barra cortada
			for(j = 0; j < tam_sol; j++)
				estoqueutilizado[idBarraPadrao[j]] += vetsol[j];

			//Atualiza o estoque das barras
			for(j = 0; j < qtdTiposBarras; j++)
				amount_bar[j] -= estoqueutilizado[j];				
	
			printf("Arredondamento finalizado\n");

			//Se quiser verificar todos os padrões gerados depois da heurística ser aplicada neles é só descomentar
			//a parte de código abaixo
	
			/*fprintf(out,"\nDEPOIS DA HEURÍSTICA\n");
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

			//Verifica se o grupo de padrões de corte gerado é o ultimo (toda a demana cumprida)
			ok = true;
			for(j = 0; j < qtdTiposItem; j++)
				if(amount_item[j] > 0)
					ok = false;

			leftover = -1;

			//VERIFICA ÚLTIMO PADRÃO
			//Se for o último grupo, verifica qual é o último padrão gerado
			if(ok)
			{
				n = -1;
				for(j = 0; j < tam_sol; j++)
					if(VerificaPadraoNulo(matsol,j,qtdTiposItem) && vetsol[j] > 0.5)
						n = j;

				loss = PerdaPadrao(matsol,n,qtdTiposItem,size_item,size_bar,totalItensDiscretizados,qtdTiposBarras);

				//Se o último padrão possui um retalho de tamanho padronizado (300,400,500), esse retalho é zerado
				//já que toda a perda será considerada como um retalho
				for(i = qtdTiposItem; i < totalItensDiscretizados; i++)
					matsol[i][n] = 0;
				
				//Se no último padrão a perda for maior ou igual a 300, toda a perda é considerada como um retalho
				if (loss > size_item[qtdTiposItem])
				{
					leftover = n;
				}

			}
			//FIM DO VERIFICA ÚLTIMO PADRÃO

			fprintf(out,"max retalho: %d\n",maxRetalho);
			fflush(out);

			double val_total = 0;
			j = 0;
			n = 0;
			
			//Imprime as soluções obtidas no arquivo de saída
			while (j < tam_sol)
			{
				if(VerificaPadraoNulo(matsol,n,qtdTiposItem))
				{
					loss = PerdaPadrao(matsol,n,qtdTiposItem,size_item,size_bar,totalItensDiscretizados,qtdTiposBarras);
					
					//Verifica integridade do número de retalhos usados
					if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) && maxRetalho == 0 && vetsol[n] > 0.5)
					{
						amount_bar[idBarraPadrao[j]] += vetsol[n];
						vetsol[n] = 0;
						for(i = 0; i < qtdTiposItem; i++)
							amount_item[i] += matsol[i][n];
					}

					//Verifica se o padrão de corte não possui frequência nula
					if(vetsol[n] > 0.5)
					{
						//Se um dia achar necessário usá-la novamente :)
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

						fprintf(out,"lalala(%d)(%d)\t%4.2f\t",n,size_bar[idBarraPadrao[j]],vetsol[n]);

						////Dados para o relatório
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
						////Fim dados para relatório
							
						val_total = 0;
						//Imprime o tamanho do item e a quantidade cortada do mesmo no padrão de corte
						for(i = 0; i < totalItensDiscretizados; i++){
							if (matsol[i][n] > 0)
								fprintf(out,"(%d)%d\t",size_item[i],matsol[i][n]);
						}

						//Se não for o último padrão de corte	
						if(leftover != n)
						{
							//Imprime a perda (descontando um eventual retalho que possa existir no padrão)
							fprintf(out,"%4.2f\t",(loss - (double)TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)));
							
							//Imprime um possível retalho que possa existir no padrão
							fprintf(out,"%d\t",TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados));
							
							//Atualiza a quantidade máxima de retalhos permitida
							if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) > 100)
								maxRetalho--;
						}
						else
						{
							//Se for o último padrão de corte (com perda >= 300), considera toda a perda como retalho
							fprintf(out,"0\t");
							fprintf(out,"%d\t",(int)loss);
						}

						//If e ELSE abaixo pegam os valores de retalho para que no próximo período ele seja considerado como um objeto a ser cortado
						if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) > 0 || leftover == n)
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
										retalhos_gerados[qtdRetalhos] = size_item[i];
										amount_retalhos_gerados[qtdRetalhos] = vetsol[n]*matsol[i][n];
										qtdRetalhos ++;
									}
								}
							}
						}
						
						//Dados para o relatório
						if(TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados) || leftover == n)
						{
							if(leftover == n)
							{
								//sobra_total += vetsol[n]*loss;
								total_sobra += vetsol[n]*loss;
								//obj_com_sobra += vetsol[n];

								loss = 0;
							}
							else
							{
								//sobra_total += vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados);
								total_sobra += vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados);
								//obj_com_sobra += vetsol[n];

								//perda_total += vetsol[n]*loss - (vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)); 
								total_perda += vetsol[n]*loss - (vetsol[n]*TamanhoRetalhoPadrao(matsol,n,qtdTiposItem,size_item,totalItensDiscretizados)); 
							}
						}
						else
						{
							//perda_total += vetsol[n]*loss;
							total_perda += vetsol[n]*loss;
						}

						//if(!loss)
							//obj_perfeito += vetsol[n];
						//else
							//obj_com_perda += vetsol[n];
						//Fim Dados para Relatório
				
						fprintf(out,"\n");
					}
					j++;
				}
				n++;
			}
			
			printf("Terminei a iteracao %d\n",iteracao);
			iteracao++;
			pare = false;

			//Verifica se toda a demanda foi cumprida, senão volta para o começo do programa (Inicio:) para fazer todo o processo de novo
			//agora com as demandas atualizadas
			for(i = 0; i<qtdTiposItem; i++)
				if(floor(amount_item[i]) > 0)
					goto Inicio;

			//Se toda demanda foi cumprida então imprime os valores totais de sobra e perda obtidos, assim como a quantidade de 
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

			//Dados para o relatório
			//qtdd_padrao += num_padrao;

			//ATUALIZA NÚMERO DE RETALHOS PARA O PRÓXIMO PERÍODO
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
			//FIM DA ATUALIZAÇÃO
		}
	}

	//Abre o arquivo que vai conter as informações do relatório
	//strcpy(entrada,"Saida/D1-Relatorio.txt");
	//strcpy(entrada,"Alex/Saida/E3-Relatorio.txt");

	//report = fopen(entrada, "w");

	//fprintf(report,"\nRelatório\n");
	//fprintf(report,"\n>>>Minimizar a Perda Total<<<\n");

	//Informações para um relatório mais completo, igual usado nas 16 classes com 20 exemplos cada
	//Só descomentar o bloco abaixo
	/*tam_total_padrao = (obj_padrao0/5)*1000+(obj_padrao1/5)*1100;
	tam_total += tam_total_padrao;

	fprintf(report,"Número médio de objetos cortados: %.2f\n",qtdd_obj/5);
	fprintf(report,"Número médio de padrões de corte: %.2f\n",qtdd_padrao/5);
	fprintf(report,"Tempo médio (segundos): %.2f\n",tempo_total/5);
	fprintf(report,"Perda média: %.2f\n",perda_total/5);
	fprintf(report,"Porcentagem de Perda Média: %.2f%c\n",100*((perda_total/5)/tam_total),'%');
	fprintf(report,"Perda total: %.2f\n",perda_total);
	fprintf(report,"Sobra média: %.2f\n",sobra_total/5);
	fprintf(report,"Número total de retalhos: %.2f\n",obj_com_sobra);
	fprintf(report,"Número médio de objetos retalhos: %.2f\n",obj_retalho/5);
	fprintf(report,"Número total de objetos retalhos cortados: %.2f\n",obj_retalho);
	fprintf(report,"Número médio de objetos cortados sem perda: %.2f\n",obj_perfeito/5);
	fprintf(report,"Número médio de objetos cortados com perda: %.2f\n",obj_com_perda/5);
	fprintf(report,"Número médio de objetos cortados com sobra: %.2f\n",obj_com_sobra/5);
	fprintf(report,"Número médio de objetos padronizados: %.2f\n",(obj_padrao0+obj_padrao1)/5);
	fprintf(report,"Número médio de objetos padronizados(1000): %.2f\n",obj_padrao0/5);
	fprintf(report,"Número médio de objetos padronizados(1100): %.2f\n",obj_padrao1/5);
	fprintf(report,"Tamanho médio de objetos padronizados cortados: %.2f\n",tam_total_padrao);*/

	
	//Informações para um relatório mais resumido, igual o gerado nos exemplos do Alex
	
	//Para cada problema do Alex, o tamanho das barras (6000, 3500) é diferente, tem que atualizar
	//tam_total_padrao = 3500*obj_padrao0;
	//tam_total_padrao = 3000*obj_padrao1;

	//fprintf(report,"Porcentagem de Perda: %.2f%c\n",100*(perda_total/tam_total_padrao),'%');
	//fprintf(report,"Número de retalhos gerados: %.2f\n",obj_com_sobra);
	//fprintf(report,"Número total de objetos cortados: %.2f\n",(obj_padrao0+obj_padrao1));
	//fprintf(report,"Número de objetos cortados(tipo1): %.2f\n",obj_padrao0);
	//fprintf(report,"Número de objetos cortados(tipo2): %.2f\n",obj_padrao1);

	//fclose(report);
    return 0;
}
