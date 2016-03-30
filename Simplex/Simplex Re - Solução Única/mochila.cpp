#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <Windows.h>
#include <math.h>
#include <vector>
#include "mochila.h"

using namespace std;

void mochila::troca(int tamanhoItem[], float qtdItem[], float custoItem[], float valorItem[], int i, int j)
{
	int auxInt;
	float auxFlot;

	auxInt = tamanhoItem[i];
	tamanhoItem[i] = tamanhoItem[j];
	tamanhoItem[j] = auxInt;

	auxFlot = qtdItem[i];
	qtdItem[i] = qtdItem[j];
	qtdItem[j] = auxFlot;

	auxFlot = custoItem[i];
	custoItem[i] = custoItem[j];
	custoItem[j] = auxFlot;

	auxFlot = valorItem[i];
	valorItem[i] = valorItem[j];
	valorItem[j] = auxFlot;
}

void mochila::ordena(int tamanhoItem[], float qtdItem[], float custoItem[], float valorItem[], int qtdTiposItem)
{
	int i, j;
	for(i = 0; i < qtdTiposItem - 1; i++)
		for(j = i + 1; j < qtdTiposItem; j++)
			if(valorItem[i] < valorItem[j])
				troca(tamanhoItem, qtdItem, custoItem, valorItem, i, j);
}

void mochila::reordena(int tamanhoItem[], float qtdItem[], float custoItem[], float solucao[], int original[], int qtdTiposItem)
{
	int i, j;
	for(i = 0; i < qtdTiposItem; i++)
		for(j = 0; j < qtdTiposItem; j++)
			if(original[i] == tamanhoItem[j])
				troca(tamanhoItem, qtdItem, custoItem, solucao, i, j);
}

float mochila::calulaSolucaoInicial(int maxRetalho, float minPositivo, float x[], int tamanhoItem[], float qtdItem[], int totalItens, int tamanhoBarra, int qtdTiposItem, bool *temRetalho)
{
	int j, i;
	float soma = 0;
	bool ok = true;

    for (j = 0; j < totalItens; j++)
	{
		ok = true;

        if (qtdItem[j] > minPositivo) 
		{
			if ((((tamanhoBarra - soma) - tamanhoItem[j]) > minPositivo))
			{
				//Verifica se é item discretizado
				if(j >= qtdTiposItem)
                {
					for(i = qtdTiposItem; i < j; i++)
						//Verifica se já não existe um item discretizado sendo utilizado nesse padrão
						if(x[i] > minPositivo)
						{
							ok = false;
							x[j] = 0;
							break;
						}
				}
				
				if(ok)
				{
					//Verifica se caso tenha sido marcado um item discretizado, se a variável que limita a quantidade de 
					//itens discretizados não está valendo 0
					if(j < qtdTiposItem || (j >= qtdTiposItem && maxRetalho > 0))
					{
						if(j < qtdTiposItem)
						{
							x[j] = floor((tamanhoBarra - soma) / tamanhoItem[j]);				

							if (x[j] - qtdItem[j] > minPositivo)
								x[j] = qtdItem[j];
						}
						else
						{
							if(maxRetalho > 0 && (tamanhoBarra - soma) - tamanhoItem[j] > 0.0001)
							{
								x[j] = 1;
								*temRetalho = true;
							}
							else
								x[j] = 0;
						}
					}
					else
					//Se a variável limitante de número de retalhos estourou, então não pode ser usado aquele item
						x[j] = 0;
                }
				else
					x[j] = 0;
            }
			else
            {
				x[j] = 0;
            }
        }
		else
        {
			x[j] = 0;
        }
            soma += tamanhoItem[j] * x[j];
    }
	return soma;
}

double mochila::calculaMochila(int maxRetalho, float minPositivo, int tamanhoBarra, int qtdTiposItem, int tamanhoItem[], float custoItem[], float qtdItem[], int totalItens, float solucao[])
{
	int i,j;
	int indice = 0;
	float *x = new float[totalItens];
	float *valor = new float[totalItens];
	int *troca = new int[totalItens];
	double total = 0;
	double sobra = 0;
	double G = 0;
	double auxG = 0;
	double retorno = 0;
	double contExtra = 0;

	bool temRetalho = false;
	
	//TRATAMENTO DADOS
	for(i = 0; i < totalItens; i++)
	{
		valor[i] = custoItem[i] / tamanhoItem[i];
		troca[i] = tamanhoItem[i];
	}

	ordena(tamanhoItem,qtdItem,custoItem,valor,qtdTiposItem);
	//FIM TRATAMENTO DADOS

Passo1:

	for(i = 0; i < totalItens; i++)
		x[i] = 0;

Passo2:
	
	temRetalho = false;
	//SOLUÇÃO INICIAL
	calulaSolucaoInicial(maxRetalho,minPositivo,x,tamanhoItem,qtdItem,totalItens,tamanhoBarra,qtdTiposItem,&temRetalho);
	//FIM SOLUÇÃO INICIAL

	//AVALIA SOLUÇÃO
Passo3:
	total = 0;

	for(i = 0; i < totalItens; i++){
		total += x[i] * custoItem[i];
	}
		
	if(G - total < 0.000001)
	{
		G = total;
		retorno = total;
		for(i = 0; i < totalItens; i++)
			solucao[i] = x[i];
	}
	//FIM AVALIA SOLUÇÃO

	//TESTA OTIMALIDADE
Passo4:
	indice = -1;

	//DETERMINA INDICE
	for(i = 0; i < totalItens; i++)
		if(x[i] > minPositivo)
			indice = i;
	//FIM DETERMINA INDICE

	if(indice == -1)
		goto Final;
	else
	{
		auxG = 0;
		contExtra = tamanhoBarra;

		for(i = 0; i < indice; i++)
		{
			auxG += custoItem[i] * x[i];
			contExtra -= tamanhoItem[i] * x[i];
		}

		auxG += custoItem[indice] * (x[indice] - 1);
		contExtra -= tamanhoItem[indice] * (x[indice] - 1);

		if(indice != totalItens)
			auxG += (custoItem[indice + 1] / tamanhoItem[indice + 1]) * contExtra;
	}
	//FIM TESTA OTIMALIDADE

	//BACKTRACKING
	if(auxG <= G)
	{
		x[indice] = 0;
		goto Passo4;
	}
	else
	{
		x[indice] = x[indice] - 1;

		contExtra = tamanhoBarra;

		for(i = indice; i < totalItens - 1; i++)
		{
			sobra = 0;

			for(j = 0; j < i + 1; j++)
				sobra += (tamanhoItem[j] * x[j]);

			sobra = contExtra - sobra;
			if(((i + 1) >= qtdTiposItem && !temRetalho && maxRetalho > 0) || (i + 1) < qtdTiposItem)
			{
				if((i + 1) >= qtdTiposItem)
				{
					if((x[totalItens - 1] < 1) && (x[totalItens - 2] < 1) && (x[totalItens - 3] < 1))
					{
						if(floor(sobra / tamanhoItem[i + 1]) > 0.5)						
							x[i + 1] = 1;
						else
							x[i + 1] = 0;
					}
				}
				else
				{
					if(qtdItem[i + 1] - floor(sobra / tamanhoItem[i + 1]) > minPositivo)
					{
						x[i + 1] = floor(sobra / tamanhoItem[i + 1]);
					}
					else
					{
						x[i + 1] = qtdItem[i + 1];
					}
				}
			}
		}
		goto Passo3;
		//FIM BACKTRACKING
	}

Final:
	reordena(tamanhoItem,qtdItem,custoItem,solucao,troca,qtdTiposItem);

	delete[] x;
	delete[] valor;

	return retorno;
}
