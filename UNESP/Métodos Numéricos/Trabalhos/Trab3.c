// 	NOME				RA
//	Nino Marques		11023279
//	Renata Tiepo		11026121

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>

void inicializaVetor(float vet[10], int dimensao){
     int i;
     for (i = 0; i < dimensao; i++)
         vet[i] = 0;
}

void inicializaMatriz(float mat[10][11], int dimensao){
     int i, j;
     for (i = 0; i < dimensao; i++)
          for (j = 0; j <= dimensao; j++)
               mat[i][j] = 0;
}

int verificaSistemaTriangularSuperior(float mat[10][11], int dimensao){
     int i, j;
     for (i = 0; i < dimensao; i++)
          for (j = 0; j < dimensao; j++)
               if ((i > j) && (mat[i][j] != 0))
                    return 0;
     return 1;
}

int verificaSistemaTriangularInferior(float mat[10][11], int dimensao){
     int i, j;
     for (i = 0; i < dimensao; i++)
          for (j = 0; j < dimensao; j++)
               if ((j > i) && (mat[i][j] != 0))
                    return 0;
     return 1;
}

int MostrarMatriz(int dimensao, float mat[10][11])
{
    printf("MATRIZ:\n");
    int i, j;
    
    for(i = 0; i < dimensao; i++)
    {
        for(j = 0; j < dimensao; j++)
           printf("%f\t", mat[i][j]);
        printf("\n");
    }
    
    return 0;
}

int MostrarVetor(int dimensao, float vet[10])
{
    int i;
    
    for(i = 0; i < dimensao; i++){
        printf("%f\t", vet[i]);
        printf("\n");
    }
    
    return 0;
}

float Cofator(int dimensao, float mat[10][11], int coluna)
{
      float det = 0;
      int dimensaoCof = (dimensao - 1);
      float matCof[10][11];
      int iCof, jCof, i, j;
      iCof = 0;
      
      for (i = 1; i < dimensao; i++)
      {
          jCof = 0;
          for (j = 0; j < dimensao; j++)
          {
              if (j != coluna)
              {
                 matCof[iCof][jCof] = mat[i][j];
                 jCof++;
              }
          }
          iCof++;
      }
      printf("\n");
      for (i = 0; i < dimensaoCof; i++)
      {    
           for (j = 0; j < dimensaoCof; j++)
               printf("%f\t", matCof[i][j]);
           printf("\n");
      }
      
      if ((coluna+2)%2 == 0)
         i = 1;
      else
          i = -1;
              
      if (dimensaoCof > 2)
          for (j = 0; j < dimensaoCof; j++)
          {                  
              det += matCof[0][j] * Cofator(dimensaoCof, matCof, j);
          }
      else
          det = ((matCof[0][0]*matCof[1][1])-(matCof[0][1]*matCof[1][0]));
          
      return det * i;
}

float Determinante(int dimensao, float mat[10][11])
{
    float det = 0;
    int j;

    if(dimensao > 2)
      for (j = 0; j < dimensao; j++)
         det += mat[0][j] * Cofator(dimensao, mat, j);
    else if (dimensao == 2)
         det = ((mat[0][0]*mat[1][1])-(mat[0][1]*mat[1][0]));
    else
         det = mat[0][0];
        
    return det;
}

void SistemaTriangularSuperior(float vetX[10], int dimensao, float mat[10][11], float vetB[10]){
    int i = (dimensao - 1);
    int j;
    float somatorio;
    inicializaVetor(vetX, dimensao);
    
    vetX[i] = (vetB[i] / mat[i][i]);    
    for(i = (dimensao - 2); i >= 0; i--){
          somatorio = 0;
          for(j = i + 1; j < dimensao; j++){
              somatorio += (mat[i][j] * vetX[j]);
          }
          vetX[i] = ((vetB[i] - somatorio) / mat[i][i]);
    }
}

void SistemaTriangularInferior(float vetX[10], int dimensao, float mat[10][11], float vetB[10]){
    int i = 0;
    int j;
    float somatorio;
    inicializaVetor(vetX, dimensao);
    
    vetX[i] = (vetB[i] / mat[i][i]);   
    for(i = 1; i < dimensao; i++){
          somatorio = 0;
          for(j = 0; j < i + 1; j++){
              somatorio += (mat[i][j] * vetX[j]);
          }
          vetX[i] = ((vetB[i] - somatorio) / mat[i][i]);
    }
}

void CalculaPorLU(float mat[10][11], float vetB[10], float vetX[10], int dimensao){
    float L[10][11], U[10][11], vetY[10], somatorio;
    int i, j, aux;
    
    inicializaMatriz(U, dimensao);
    inicializaMatriz(L, dimensao);
    
    //Calcula a primeira linha de U
    for (j = 0; j < dimensao; j++)
        U[0][j] = mat[0][j];
    //Calcula a primeira coluna de L    
    for (i = 0; i < dimensao; i++)
        L[i][0] = mat[i][0]/U[0][0];
    somatorio = 0;
    for(i = 1; i < dimensao; i++){
        for(j = 0; j < i; j++){
             for(aux = 0; aux <= (j - 1); aux++){
                  somatorio += L[i][aux] * U[aux][j];
             }
             L[i][j] = (mat[i][j] - somatorio) / U[j][j];
             somatorio = 0;
        }
        L[i][i] = 1;
        for(j = i;  j < dimensao;  j++){
             for(aux = 0; aux <= (i - 1); aux++){
                  somatorio += L[i][aux] * U[aux][j];
             }  
             U[i][j] = mat[i][j] - somatorio;
             somatorio = 0;
        }
    }     

    SistemaTriangularInferior(vetY, dimensao, L, vetB);
    SistemaTriangularSuperior(vetX, dimensao, U, vetY);
}

CalculaPorGaussCompacto(float mat[10][11], float vetB[10], float vetX[10], int dimensao){
    float matAmpliada[10][11], LU[10][11], matAux[10][11], vetY[10], somatorio;    
    int i, j, auxI, auxJ;
    
    inicializaMatriz(LU, dimensao);
    inicializaMatriz(matAmpliada, dimensao);
    
    for (i = 0; i < dimensao; i++)
        for (j = 0; j < dimensao; j++)
            matAmpliada[i][j] = mat[i][j];
    for (i = 0; i < dimensao; i++)
        matAmpliada[i][j] = vetB[i];
    
    //Calcula a primeira linha de LU
    for(j = 0; j <= dimensao; j++){
        LU[0][j] = matAmpliada[0][j];
    }
    //Calcula a primeira coluna de LU
    for(i = 1; i < dimensao; i++){
        LU[i][0] = matAmpliada[i][0] / LU[0][0];
    }
    somatorio = 0;
    for(j = 1; j <= dimensao; j++){
        for(i = j; i < dimensao; i++){
            if(i > j){
                for(auxI = i; auxI < dimensao; auxI++){
                    for(auxJ = 0; auxJ < j; auxJ++){
                        somatorio += LU[auxI][auxJ] * LU[auxI][j];
                    }
                    LU[i][j] = (matAmpliada[i][j] - somatorio) / LU[j][j];
                    somatorio = 0;
                }
            }
            else{
                for(auxI = j; auxI <= dimensao; auxI++){
                    for(auxJ = 0; auxJ < i; auxJ++){
                        somatorio += LU[i][auxJ] * LU[auxJ][auxI];
                    }
                    LU[i][auxI] = matAmpliada[i][auxI] - somatorio;
                    somatorio = 0;
                }
            }
        }
    }
    
    for (i = 0; i < dimensao; i++)
        for (j = 0; j <= dimensao; j++){
            if (j >= dimensao) 
               vetY[i] = LU[i][j];
            else if (j >= i) 
                matAux[i][j] = LU[i][j];
            else 
                matAux[i][j] = 0;
        }
    
    MostrarMatrizAmpliada(dimensao, LU);
    
    SistemaTriangularSuperior(vetX, dimensao, matAux, vetY);   
}

void CalculaPorGaussJordan(float mat[10][11], float vetB[10], float vetX[10], int dimensao){
    int i, j, auxJ;
    float somatorio, divisao, vetAux[10], matAmpliada[10][11];
    
    inicializaVetor(vetAux, dimensao);
    
    for (i = 0; i < dimensao; i++)
        for (j = 0; j < dimensao; j++)
            matAmpliada[i][j] = mat[i][j];
    for (i = 0; i < dimensao; i++)
        matAmpliada[i][j] = vetB[i]; 
                
    for(j = 0; j < dimensao; j++){
        for(i = 0; i < dimensao; i++){
            if(i != j){
                divisao = matAmpliada[i][j] / matAmpliada[j][j];
                for(auxJ = j; auxJ <= dimensao; auxJ++){
                    matAmpliada[i][auxJ] -= divisao * matAmpliada[j][auxJ];
                }
            }
        }
    }
    for(i = 0; i < dimensao; i++){
        vetX[i] = matAmpliada[i][dimensao] / matAmpliada[i][i];
    }
}

void CalculaMatrizInversa(int dimensao, float mat[10][11], float vetB[10], float matR[10][11]){
    int i, j;
    float matI[10][10], vet[10];
    
    inicializaMatriz(matR, dimensao);
    
    for (i = 0; i < dimensao; i++){
        for (j = 0; j < dimensao; j++){
               matI[i][j] = (i == j) ? 1 : 0;
        }
    }
    
    for (i = 0; i < dimensao; i++){
        CalculaPorLU(mat, vetB, vet, dimensao);
        for (j = 0; j < dimensao; j++){
            matR[i][j] = vet[j];
        }
    }
}

void LerTermosIndependentes(float vetB[10], int dimensao){
    int i;
    system("cls");
    printf("Termos independentes: \n");
    for(i = 0; i < dimensao; i++)
    {
        printf("B%d = ", i+1);
        scanf("%f", &vetB[i]);
    }
}

int main()
{
    int D, i, j, escolha;
    float M[10][11], vetB[10], vetX[10], matR[10][11];
    
    inicializaMatriz(M, D);
    
    printf("OPERACOES:\n");
    printf("1 - Determinante\n");
    printf("2 - Sistema Triangular Superior\n");
    printf("3 - Sistema Triangular Inferior\n");
    printf("4 - Decomposicao LU\n");
    printf("5 - Gauss Compacto\n");
    printf("6 - Gauss Jordan\n");
    //printf("7 - Jacobi\n");
    //printf("8 - Gauss Seidel\n");
    printf("7 - Matriz Inversa\n");

    printf("\nEscolha uma operacao: ");
    do{
        scanf("%d", &escolha);
    }while (escolha < 1 || escolha > 7);
    
    system("cls");
    printf("Dimensao: ");
    scanf("%d", &D);
    
    system("cls");
    printf("Matriz: \n");
    for(i = 0; i < D; i++)
       for(j = 0; j < D; j++)
       {
               printf("A%d%d = ", i+1, j+1);
               scanf("%f", &M[i][j]);
       } 
    
    system("cls");
    switch(escolha){
        case 1:
               MostrarMatriz(D, M);
               printf("\nDeterminante: %f", Determinante(D, M));
               break;
        case 2:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               if (verificaSistemaTriangularSuperior(M, D)){
                   printf("\nSistema Triangular Superior - Resultado: \n");
                   SistemaTriangularSuperior(vetX, D, M, vetB);
                   MostrarVetor(D, vetX);
               } else 
                   printf("\nA matriz enviada não é triangular superior.");
               break;
        case 3:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               if (verificaSistemaTriangularInferior(M, D)){
                   printf("\nSistema Triangular Inferior - Resultado: \n");
                   SistemaTriangularInferior(vetX, D, M, vetB);
                   MostrarVetor(D, vetX);
               } else
                   printf("\nA matriz enviada não é triangular inferior.");
               break;
        case 4:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               printf("\nDecomposição LU - Resultado: \n");
               CalculaPorLU(M, vetB, vetX, D);
               MostrarVetor(D, vetX);
               break;
        case 5:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               printf("\nGauss Compacto - Resultado: \n");
               CalculaPorGaussCompacto(M, vetB, vetX, D);
               MostrarVetor(D, vetX);
               break;
        case 6:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               printf("\nGauss Jordan - Resultado: \n");
               CalculaPorGaussJordan(M, vetB, vetX, D);
               MostrarVetor(D, vetX);
               break;
        case 7:
               LerTermosIndependentes(vetB, D);
               system("cls");
               MostrarMatriz(D, M);
               printf("\nTERMOS INDEPENDENTES");
               MostrarVetor(D, vetB);
               printf("\nMatriz inversa - Resultado: \n");
               CalculaMatrizInversa(D, M, vetB, matR);
               MostrarMatriz(D, matR);
               break;            
    }
    system("pause"); 
    return 0;
}
