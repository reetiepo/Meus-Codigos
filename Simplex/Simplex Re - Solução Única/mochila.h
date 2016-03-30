#ifndef MOCHILA_H_
#define MOCHILA_H_

class mochila {

	private:
		void mochila::troca(int tamanhoItem[], float qtdItem[], float custoItem[], float valorItem[], int i, int j);
		void mochila::ordena(int tamanhoItem[], float qtdItem[], float custoItem[], float valorItem[], int qtdTiposItem);
		void mochila::reordena(int tamanhoItem[], float qtdItem[], float custoItem[], float solucao[], int original[], int qtdTiposItem);
		float mochila::calulaSolucaoInicial(int maxRetalho, float minPositivo, float x[], int tamanhoItem[], float qtdItem[], int totalItens, int tamanhoBarra, int qtdTiposItem, bool *temRetalho);
	public:
		double mochila::calculaMochila(int maxRetalho, float minPositivo, int tamanhoBarra, int qtdTiposItem, int tamanhoItem[], float custoItem[], float qtdItem[], int totalItens, float solucao[]);

};

#endif