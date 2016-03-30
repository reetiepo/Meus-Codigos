#ifndef MOCHILA_H_
#define MOCHILA_H_

typedef struct problema_um *classe;//para o branch-and-bound
struct problema_um{
		double utilidade;//v[i]     ou p[i]
		int l;           //comprimento
		int demanda;    //sigma[i] ou b[i]
};

typedef struct solucao_um *solucao;//matriz das K melhores
struct solucao_um{
		int *indice;//vetor de indice relacionado a solucao
		int *sol;//vetor solucao
		int tamanho_k;//numero de elementos
		double  valor;//f.o.
};

class mochila {

	private:
		double fminRe(double a, double b);
		int solucao_repetida(int nc, int n, int *x, int *indice_x, double v_x, int tamanho, solucao matriz_K);
		void preproc (classe dados, int *newn, int n);
		void passo2(int c, int n, int K, classe dados, int **x, int **indice_x, double *v_x, int *tamanho, solucao matriz_K, int menor_item);
		void passo3(int n, int nc, classe dados, int *x, int *indice_x, double v_x, int tamanho, solucao matriz_K);
		void passo4(int n, int c,classe dados, int *x, int *indice_x, int tamanho, double *lim_sup, bool *controla, bool *controlb);
		void passo5(int c, int n, classe dados, int **x, double *v_x, int **indice_x, int *tamanho,  bool *controla, bool *controlb, double *lim_sup, int nc, solucao matriz_K, int menor_item);
	public:
		void branch_bound_k(classe dados, int n, int c, int nc, int menor_item, solucao *matriz_K_fim, time_t *fim, time_t *inicio);
};

#endif