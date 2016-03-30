#include <cstdlib>
#include <iostream>
#include <stdio.h>
#include <math.h>
#include <time.h>
#include "mochila.h"

using namespace std;

double mochila::fminRe(double a, double b) {
	if (a < b) 
		return (a);
	return (b);
}
int mochila::solucao_repetida(int nc, int n, int *x, int *indice_x, double v_x, int tamanho, solucao matriz_K){
  int igual;  
  //printf("\n\n\nCALCULAR SOLUCAO REPETIDA\n\n\n\n");
 
  for(int k=0; k<nc; k++){
          igual = 1;
          if(matriz_K[k].valor == v_x && matriz_K[k].tamanho_k == tamanho){
                   //printf("tamanho = %d\n", tamanho);                
                               
                   for(int j = tamanho; j>=0; j--){
                            //printf("x[%d] = %d\t", j, x[j]);
                            //printf("matriz_[%d].sol[%d] = %d\n", k, j, matriz_K[k].sol[j]);
                            //printf("indice_x[%d] = %d\t", j, indice_x[j]);
                            //printf("matriz_[%d].indice[%d] = %d\n", k, j, matriz_K[k].indice[j]);getchar();
			if(matriz_K[k].indice!=NULL){
                           if((matriz_K[k].indice[j] != indice_x[j]) || (matriz_K[k].sol[j] != x[j])){
                                igual = 0;                                         
                                break;
                           }
       			}
                   }
                   if(igual == 1) return (1);
          }     
  }

  return(0);

}

void mochila::passo2(int c, int n, int K, classe dados, int **x, int **indice_x, double *v_x, int *tamanho, solucao matriz_K, int menor_item){

  int k, n_e;
  
  int largura_util;
  largura_util=c; 
  *v_x = 0;
  
  //Solucao inicial
  int ii=0;
       //printf("menor_item = %d", menor_item); //getchar();
         while(largura_util>= menor_item && ii<n){
            //printf("ii=%d\t ", ii);
            //printf("largura_util=%ld\n", largura_util); 
             int aux;
             aux = int(fminRe(int(largura_util/dados[ii].l), dados[ii].demanda));
             //printf("aux=%d", aux); //getchar();
             if(aux>0){                  
                (*tamanho)++;
                (*x) = (int*) realloc((*x), sizeof(int)*(*tamanho));    
                (*indice_x) = (int*) realloc((*indice_x), sizeof(int)*(*tamanho)); 
                
                (*x)[(*tamanho)-1] = aux;
                (*indice_x)[(*tamanho)-1] = ii;
                (*v_x) = (*v_x) + dados[ii].utilidade*aux;
                largura_util -= dados[ii].l*aux;
                //printf("largura_util = %d", largura_util); //getchar();
             }
             ii++;
         }               
        

  int *x_aux;
  x_aux = (int*) malloc(sizeof(int)*(*tamanho));
  for(int i = 0; i<*tamanho; i++){
          x_aux[i] = (*x)[i];  
          //printf("x_aux[%d] = %d\t", i, x_aux[i]);      
          //printf("indice_x[%d] = %d\n", i, (*indice_x)[i]);  
  }
  //printf("\nv_x = %lf", *v_x); //getchar();
  
  double v_aux = *v_x;
  int tamanho_aux = (*tamanho);
  //printf("tamanho_aux=%d", tamanho_aux); //getchar();
  
  //Salvar as K melhores
  
    for(int k = 0; k<K; k++){
          matriz_K[k].tamanho_k = tamanho_aux;
          matriz_K[k].valor = v_aux;
          //printf("\nv_aux = %lf", v_aux); //getchar();
          //printf("matriz_K[%d].valor = %lf\n", k, matriz_K[k].valor);  
          matriz_K[k].sol = NULL;
          matriz_K[k].indice = NULL;
          matriz_K[k].sol = (int*) realloc(matriz_K[k].sol, sizeof(int)*tamanho_aux);
          matriz_K[k].indice = (int*) realloc(matriz_K[k].indice, sizeof(int)*tamanho_aux);
          
          for(int i = 0; i<tamanho_aux; i++){
             matriz_K[k].sol[i] =  x_aux[i];
             //printf("x_aux[%d] = %d ; dados[%d].utilidade = %lf", i, x_aux[i], i , dados[(*indice_x)[i]].utilidade); getchar();
             matriz_K[k].indice[i] =  (*indice_x)[i];
             //printf("vaux = %lf - %lf = %lf", v_aux , dados[(*indice_x)[i]].utilidade, v_aux - dados[(*indice_x)[i]].utilidade); getchar();
            
          }
          //printf("(*indice_x)[%d] = %d", tamanho_aux-1, (*indice_x)[tamanho_aux-1]); getchar();
          v_aux = v_aux - dados[(*indice_x)[tamanho_aux-1]].utilidade;
         
             
          x_aux[tamanho_aux-1]--;
          if (x_aux[tamanho_aux-1] == 0){
             tamanho_aux--;
             if (tamanho_aux == 0){
            //                 printf("break ----->sair"); getchar();
                break;                 
             }
             
             //printf("tamanho_aux = %d", tamanho_aux); getchar();
             
          }
          /*if (x_aux[tamanho_aux-1]>0){
             x_aux[tamanho_aux-1]--;
          }
          else{
              tamanho_aux--;
          }*/
	 
  }  
  
/*  for(int k=0; k<K; k++){
       printf("matriz_K[%d].tamanho_k = %d\t", k, matriz_K[k].tamanho_k);
       printf("matriz_K[%d].valor = %lf\n", k, matriz_K[k].valor);
       for(int jj=0; jj< matriz_K[k].tamanho_k; jj++){ 
               printf("matriz_K[%d].indice[%d] = %d\t", k, jj, matriz_K[k].indice[jj]); 
               printf("matriz_K[%d].sol[%d] = %d\n", k, jj, matriz_K[k].sol[jj]);
       }      
  }getchar();  */
  
  //for(int i = 0; i<*tamanho; i++){   
  //        printf("indice_x[%d] = %d\n", i, (*indice_x)[i]);  
  //}
  //  printf("comecou"); //getchar();
  free(x_aux);
  return;
}

void mochila::passo3(int n, int nc, classe dados, int *x, int *indice_x, double v_x, int tamanho, solucao matriz_K){
   double g=0;
   int i, j, k;
   bool repeticao, pare;
   int aux;
   //printf("PASSO 3---------------->\n");// getchar();
   //printf("\nv_x = %lf", v_x); //getchar();
   //printf("\nmatriz_k[%d].valor = %lf", nc-1, matriz_K[nc-1].valor ); //getchar();
   
   if(matriz_K[nc-1].valor<v_x){
       //printf("\tentrou no if"); //getchar();
 
       repeticao=solucao_repetida(nc, n, x, indice_x, v_x, tamanho, matriz_K);//se repeticao for 1 eh porque a solução já está armazenada
   
       if(repeticao==0){
              //printf("\n solucao nao eh repetida ------> trocar"); //getchar();
              for(i=0;i<nc;i++){
                 if(matriz_K[i].valor<v_x){//deletar o ultimo vetor e fazer a troca
              
                     int *ptr_ind = NULL;
                     int *ptr_sol = NULL;
                     
                     
                     ptr_ind = matriz_K[nc-1].indice;
                     ptr_sol = matriz_K[nc-1].sol;
                     
                     //free(matriz_K[nc-1].indice);//Deletando
                     //free(matriz_K[nc-1].sol);
                     
                     
                     for(j = nc-1; j>i ; j--){
                          matriz_K[j].valor = matriz_K[j-1].valor;
                          matriz_K[j].tamanho_k = matriz_K[j-1].tamanho_k;
                          matriz_K[j].indice = matriz_K[j-1].indice;
                          matriz_K[j].sol = matriz_K[j-1].sol;
                     }
                     matriz_K[i].valor = v_x;
                     matriz_K[i].tamanho_k = tamanho;
                     
                     matriz_K[i].indice = ptr_ind;
                     matriz_K[i].sol = ptr_sol;
                     
                     matriz_K[i].indice = (int*) realloc ( matriz_K[i].indice ,sizeof(int)*tamanho);
                     matriz_K[i].sol = (int*) realloc ( matriz_K[i].sol ,sizeof(int)*tamanho);
                     
                     for (k = 0 ; k < tamanho ; k++){
                             matriz_K[i].indice[k] = indice_x[k];
                             matriz_K[i].sol[k] = x[k];
                     }
                 
                     break;   
                 }
              }          
       }
   }
   return;
} 


void mochila::passo4(int n, int c,classe dados, int *x, int *indice_x, int tamanho, double *lim_sup, bool *controla, bool *controlb){
   int i, h;
   
   //printf("PASSO 4 ------------------>"); //getchar();

   double largura_util=c; 
   if( tamanho  == 0){ //o vetor  é nulo voltou ao nó inicial: A Solução é Ótima
         *controla=0;
         *controlb=0;
        // printf("o vetor x eh nulo e a solucao eh otima");// getchar();
   }
   else{
        //printf("else calcular novo limitante"); //getchar();
        *lim_sup=0;
        for(i=0;i<tamanho-1;i++){
                //printf("indice_x[%d] = %d\n", i, indice_x[i]);
                *lim_sup = *lim_sup + dados[indice_x[i]].utilidade*x[i];
                
                largura_util = largura_util - (dados[indice_x[i]].l*x[i]);
        }
        
        //printf("lim_sup = %lf\n", *lim_sup);      
              
        *lim_sup = *lim_sup + dados[indice_x[tamanho-1]].utilidade*(x[tamanho-1]-1);
          
        // printf("lim_sup = %lf", *lim_sup);  
            
        largura_util=largura_util-(dados[indice_x[tamanho-1]].l*(x[tamanho-1]-1));  
        
        h=indice_x[tamanho-1]+1;
       // printf ("tamanho = %d ; h = %d\n", tamanho, h);
        
        while((h<n)&&((dados[h].l*dados[h].demanda) <= largura_util)){
                                                                       
               largura_util = largura_util - (dados[h].l*dados[h].demanda);
               
               *lim_sup=*lim_sup + (dados[h].utilidade*dados[h].demanda); 
               
               h++;                                                              
        } 
        
        if(h!=(n)) *lim_sup=*lim_sup+(dados[h].utilidade/dados[h].l)*largura_util;
        
        //printf("*lim_sup = %lf\n", *lim_sup);// getchar();
   }

   return;
}



void mochila::passo5(int c, int n, classe dados, int **x, double *v_x, int **indice_x, int *tamanho,  bool *controla, bool *controlb, double *lim_sup, int nc, solucao matriz_K, int menor_item){
  int i, aux, ii, repeticao, z, j, pare;
  double foaux=0;
  int largura_util=c;
  //printf("\n\n PASSO 5 -------------------->\n"); //getchar();
  if(*lim_sup<=matriz_K[nc-1].valor){//backtracking longo
       //printf("\n Executar backtracking longo\n ");// getchar();
  
       *v_x = *v_x - dados[(*indice_x)[(*tamanho)-1]].utilidade * (*x)[*tamanho-1];
       (*x)[*tamanho-1]=0; //zera o último elemento diferente de do vetor x
       
       (*tamanho)--;
       (*x) = (int*) realloc ((*x),sizeof(int)*(*tamanho));
       (*indice_x) = (int*) realloc ((*indice_x),sizeof(int)*(*tamanho));
       
       *controlb=1;//volta ao passo 4
  }
  
  else{//backtracking curto
        
        //printf("\n Executar backtracking curto\n "); //getchar();
        
       (*x)[*tamanho-1] = (*x)[*tamanho-1]-1;//backtracking curto
       *v_x = *v_x - dados[(*indice_x)[(*tamanho)-1]].utilidade;
       
        ii=(*indice_x)[*tamanho-1]+1;

       
       if ((*x)[*tamanho-1] == 0){
            (*tamanho)--;                
            (*x) = (int*) realloc ((*x),sizeof(int)*(*tamanho));
            (*indice_x) = (int*) realloc ((*indice_x),sizeof(int)*(*tamanho));
       }
       
       
       for(i=0;i < (*tamanho);i++){//calcula a largura e a fo atual para acrescentar os novos itens
             largura_util= largura_util-dados[(*indice_x)[i]].l * (*x)[i];
             foaux = foaux + dados[(*indice_x)[i]].utilidade * (*x)[i];  
       }
       ///percorrer novos nos
       
       //printf("\tlargura_util = %d\n", largura_util); 
       
      
       while ((largura_util >= menor_item) && (ii < n)){                                    
             int aux;
            
             aux = int(fminRe(int(largura_util/dados[ii].l), dados[ii].demanda));
             // printf("\t aux = %d", aux);//getchar();
             if(aux > 0){                  
             
                 (*tamanho)++;
                 (*x) = (int*) realloc((*x), (*tamanho)*sizeof(int));
                 (*indice_x) = (int*) realloc((*indice_x), (*tamanho)*sizeof(int*));
                 (*x)[(*tamanho)-1] = aux;
                 (*indice_x)[(*tamanho)-1] = ii;
                 (*v_x) = (*v_x) + dados[ii].utilidade * aux;
                 largura_util -= dados[ii].l * aux;
             
             }
             ii++;
             
       }//fecha o while

       double v_aux = *v_x;
       int tamanho_aux = *tamanho;
       int *x_aux;
       x_aux = (int*) malloc(sizeof(int)*(*tamanho));
       
      // printf("\nnova solucao\n"); 
      // printf("\t*v_x = %lf\n", *v_x); //getchar();
       for(i = 0; i<*tamanho; i++){
              x_aux[i] = (*x)[i];  
              //printf("\t x_aux[%d] = %d\t", i, x_aux[i]);      
             // printf("\t indice_x[%d] = %d\n", i, (*indice_x)[i]);  
       }
       
       int repeticao;
       //printf("\nVerificar se adiciona a nova solucao\n");// getchar();
       
       //while (v_aux > matriz_K[nc-1].valor){
            repeticao=solucao_repetida(nc, n, *x, *indice_x, *v_x, tamanho_aux, matriz_K);//se repeticao for 1 eh porque a solução já está armazenada
            //printf("repeticao = %d", repeticao);// getchar();
            //printf("\n solucao nao eh repetida ------> trocar\n");// getchar();
            i = 0;
            while (/*(repeticao == 0) && */(i < nc) && v_aux > matriz_K[nc-1].valor) {
            
                 if((matriz_K[i].valor < v_aux)){//deletar o ultimo vetor e fazer a troca
                    // printf("i=%d", i); //getchar(); 
                   if(repeticao ==0){ 
                     int *ptr_ind = NULL;
                     int *ptr_sol = NULL;
                     
                     
                     ptr_ind = matriz_K[nc-1].indice;
                     ptr_sol = matriz_K[nc-1].sol;
                     
                     //FAZER AS TROCAS
                     for(j = nc-1; j>i ; j--){
                          matriz_K[j].valor = matriz_K[j-1].valor;
                          matriz_K[j].tamanho_k = matriz_K[j-1].tamanho_k;
                          matriz_K[j].indice = matriz_K[j-1].indice;
                          matriz_K[j].sol = matriz_K[j-1].sol;
                     }
                     matriz_K[i].valor = v_aux;
                     
                    // printf("matriz_K[%d].valor = %d", i, matriz_K[i].valor); //getchar();
                     
                     matriz_K[i].tamanho_k = tamanho_aux;
                     
                     matriz_K[i].indice = ptr_ind;
                     matriz_K[i].sol = ptr_sol;
                     
                     matriz_K[i].indice = (int*) realloc ( matriz_K[i].indice ,sizeof(int)*(tamanho_aux));
                     matriz_K[i].sol = (int*) realloc ( matriz_K[i].sol ,sizeof(int)*(tamanho_aux));
                     
                     for (int k = 0 ; k < (tamanho_aux) ; k++){
                             matriz_K[i].indice[k] = (*indice_x)[k];
                             matriz_K[i].sol[k] = x_aux[k];
                     }
                 }
                      
                     v_aux = v_aux - dados[(*indice_x)[tamanho_aux-1]].utilidade;
                                       
                     x_aux[tamanho_aux-1]--;
                     if (x_aux[tamanho_aux-1] == 0){
			tamanho_aux--;
                        if (tamanho_aux-1 == 0){
                           break;
                        }
                        
                     }
                     //printf("\nproxima a verificar\n");
                    // printf("\tv_aux = %lf\n", v_aux); //getchar();
                    // for(i = 0; i<tamanho_aux; i++){
                                     //x_aux[i] = (*x)[i];  
                           //printf("\t x_aux[%d] = %d\t", i, x_aux[i]);      
                           //printf("\t indice_x[%d] = %d\n", i, (*indice_x)[i]);  
                     //}
                     repeticao = solucao_repetida(nc, n, x_aux, *indice_x, v_aux, tamanho_aux, matriz_K);//se repeticao for 1 eh porque a solução já está armazenada
                    // printf("repeticao = %d", repeticao); //getchar();
                      
                 }
                 
                 i++;
                 
                //printf("\tatual matriz de solucao");// getchar();
                /*for (int k=0; k<nc; k++){
                   printf("matriz_K[%d].tamanho_k = %d\t", k, matriz_K[k].tamanho_k);
                   printf("matriz_K[%d].valor = %lf\n", k, matriz_K[k].valor);
                   for (int jj=0; jj< matriz_K[k].tamanho_k; jj++){ 
                       printf("matriz_K[%d].indice[%d] = %d\t", k, jj, matriz_K[k].indice[jj]); 
                       printf("matriz_K[%d].sol[%d] = %d\n", k, jj, matriz_K[k].sol[jj]);
                   }     
                } //getchar(); */
              }   
   
       //}
       *controla=1;//volta ao passo 3
       *controlb=0;//sai do passo 4
       free(x_aux);
  }
  
  return;
}

void mochila::branch_bound_k(classe dados, int n, int c, int nc, int menor_item, solucao *matriz_K_fim, time_t *fim, time_t *inicio){
    int i, j,linha;       //número de itens, capacidade da mochila e nc o número de melhores soluções a ser determinado(k melhores soluções)  
    double lim_inff=-1000;
    double lim_sup;
    bool controla=1, controlb=1;

    //matriz das k melhores
    solucao matriz_K;
    matriz_K = (solucao_um *) malloc(sizeof(solucao_um) * nc);
    for (int k=0; k<nc; k++){
	 matriz_K[k].tamanho_k = 0;
	 matriz_K[k].valor = 0;
	 matriz_K[k].indice = NULL;
	 matriz_K[k].sol = NULL;
    }
    //Vetor da solucao incumbente
    int *x = NULL;//vetor do no da arvore
    int *indice_x = NULL;
    double v_x;
    int tamanho;
    tamanho = 0;

/********************************************Branch-and-Bound******************************************************/       

    passo2(c, n, nc, dados, &x, &indice_x, &v_x, &tamanho, matriz_K, menor_item); //salvar as k melhores solucoes iniciais
      //printf("\n\nfim do passo 2\n"); 
      
 
      
      //printf ("Tamanho = %d\n", tamanho); 
      
      do{ 

           passo3(n, nc, dados, x, indice_x, v_x, tamanho, matriz_K);//salva a solucao incumbente na matriz de K melhores solucoes se ela for melhor q o limitante inferior (a K-esima)
             //printf("\n\nfim do passo3\n");

           do{

               /*for (int k=0; k<nc; k++){
                   printf("matriz_K[%d].tamanho_k = %d\t", k, matriz_K[k].tamanho_k);
                   printf("matriz_K[%d].valor = %lf\n", k, matriz_K[k].valor);
                   for (int jj=0; jj< matriz_K[k].tamanho_k; jj++){ 
                       printf("matriz_K[%d].indice[%d] = %d\t", k, jj, matriz_K[k].indice[jj]); 
                       printf("matriz_K[%d].sol[%d] = %d\n", k, jj, matriz_K[k].sol[jj]);
                   }     
               } getchar();*/
                                 
                             
               passo4(n, c, dados, x, indice_x, tamanho, &lim_sup, &controla, &controlb); // calculo do limitante superior
               //printf("\n\n passo 4");
               
               if(controla==1||controlb==1) 
                    passo5(c, n, dados, &x, &v_x, &indice_x, &tamanho,  &controla, &controlb, &lim_sup, nc, matriz_K, menor_item);  
                   //printf("pass5"); //getchar();
    
		time(fim);
           }while((controlb==1) && (difftime (*fim,*inicio) < 3600));
	   time(fim);
    }while((controla==1) && (difftime (*fim,*inicio) < 3600));
    
    *matriz_K_fim = matriz_K;
    return;
    //printf("ACABOOOOOOOOOOOOOO"); getchar();

   //Variaveis a ser passadas para o principal             
      //*g_nsaux=g_nc;
      //*X=X_nc;
      //free(x);  


}




