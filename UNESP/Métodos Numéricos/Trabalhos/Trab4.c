// 	NOME				RA
//	Nino Marques		11023279
//	Renata Tiepo		11026121

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include <math.h>

#define maxpontos 10
#define maxgrau 10
#define max 10

typedef float tabela[2][maxpontos];
typedef float vetorA[maxgrau];
typedef float vetorY[maxpontos];

void inicializaVetor(float vet[], int dimensao, int valor){
     int i;
     for (i = 0; i < dimensao; i++)
         vet[i] = valor;
}

void inicializaMatriz(float mat[][max], int dimensao){
     int i, j;
     for (i = 0; i < 2; i++)
          for (j = 0; j <= dimensao; j++)
               mat[i][j] = 0;
}

int verificaSistemaTriangularSuperior(float mat[][max], int dimensao){
     int i, j;
     for (i = 0; i < dimensao; i++)
          for (j = 0; j < dimensao; j++)
               if ((i > j) && (mat[i][j] != 0))
                    return 0;
     return 1;
}

double Fatorial(int i){ 
    int k , j; 
    k = 1; 
    for(j = 1; j < i; j++) 
          k *= (j + 1);  
    return k;
} 

int MostrarMatrizAmpliada(int dimensao, float mat[][max])
{
    printf("MATRIZ:\n");
    int i, j;
    
    for(i = 0; i < dimensao; i++)
    {
        for(j = 0; j <= dimensao; j++)
           printf("%f\t", mat[i][j]);
        printf("\n");
    }
    
    return 0;
}

int MostrarTabela(int dimensao, tabela tbPts)
{
    printf("TABELA DE PONTOS:\n");
    int i, j;
    
    printf("X\t\tY\n");
    
    for(i = 0; i < dimensao; i++)
        printf("%f\t%f\n", tbPts[0][i], tbPts[1][i]);
    
    return 0;
}

int MostrarVetor(int dimensao, float vet[])
{
    int i;
    
    for(i = 0; i < dimensao; i++){
        printf("%f\t", vet[i]);
        printf("\n");
    }
    
    return 0;
}

void SistemaTriangularSuperior(float vetX[], int dimensao, float mat[][max], float vetB[]){
    int i = (dimensao - 1);
    int j;
    float somatorio;
    inicializaVetor(vetX, dimensao, 0);
    
    vetX[i] = (vetB[i] / mat[i][i]);    
    for(i = (dimensao - 2); i >= 0; i--){
          somatorio = 0;
          for(j = i + 1; j < dimensao; j++){
              somatorio += (mat[i][j] * vetX[j]);
          }
          vetX[i] = ((vetB[i] - somatorio) / mat[i][i]);
    }
}

void CalculaPorGaussCompacto(float mat[][max], float vetB[], float vetX[], int dimensao){
    float matAmpliada[dimensao][dimensao + 1], LU[dimensao][dimensao + 1], matAux[dimensao][dimensao + 1], vetY[dimensao], somatorio;    
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

float Lagrange(int qtdPts, tabela tbPts, float x){
       float L[qtdPts];
       float s = 0;
       int i, j;
       
       inicializaVetor(L, qtdPts, 1);
       
       for (i = 0; i < qtdPts; i++){
           for (j = 0; j < qtdPts; j++){
               if (j != i)
                  L[i] *= ((x - tbPts[0][j])/(tbPts[0][i] - tbPts[0][j]));
           }
       }
       
       for (i = 0; i < qtdPts; i++)
           s += (tbPts[1][i] * L[i]);
       
       return s;
}

void MatrizDiferencasDivididas(float mat[][max], int qtdPts, tabela tbPts){
     int i, j;
     int dimensao = (qtdPts - 1);
     
     inicializaMatriz(mat, dimensao);
     for (i = 0; i < dimensao; i++)
         mat[i][0] = tbPts[1][i];
     
     for (i = 0; i < dimensao; i++){
         for (j = 1; j < dimensao; j++){
             if (i + j < qtdPts)
                mat[i][j] = (mat[i + 1][j - 1] - mat[i][j - 1]) / (tbPts[0][i + j] - tbPts[0][i]);
         }
     }                  
}

double Newton(int qtdPts, tabela tbPts, double x){
    float matDifDiv[qtdPts - 1][qtdPts - 1], mult, s;
    int i, j;
    
    MatrizDiferencasDivididas(matDifDiv, qtdPts, tbPts);
    
    s = matDifDiv[0][0];
    
    for (i = 1; i < qtdPts; i++){
        mult = 1;
        for (j = 0; j < i; j++){
            mult *= (x - tbPts[0][j]);
        }
        mult *= matDifDiv[i][0];
        s += mult;
    }
    
    return s;
}

double NewtonGregory(int qtdPts, tabela tbPts, double x){
    float matDifDiv[qtdPts - 1][qtdPts - 1], mult, s, h;
    int i, j;
    
    MatrizDiferencasDivididas(matDifDiv, qtdPts, tbPts);
    
    s = matDifDiv[0][0];
    
    for (i = 1; i < (qtdPts - 1); i++){
        mult = 1;
        for (j = 0; j < i; j++){
            mult *= (x - tbPts[0][j]);
        }
        h = (tbPts[0][i - 1] - tbPts[0][i]);
        //mult *= (matDifDiv[i][0] * (Fatorial(i) * pow(h, i));
        s += mult;
    }
    
    return s;
}

float CoeficienteDeterminacao(int qtdPts, tabela tbPts, vetorY vetY){
    float SomaY, SomaY2, SomaE2, vetE[qtdPts];
    int i;
  
    for(i = 0; i < qtdPts; i++){
        SomaY += tbPts[1][i];
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaY2 += pow(tbPts[1][i], 2);
    }
    
    for(i = 0; i < qtdPts; i++){
        vetE[i] = tbPts[1][i] - vetY[i];
    }
   
    for(i = 0; i < qtdPts; i++){
        SomaE2 += pow(vetE[i], 2);
    }
    
    return (1 - (SomaE2 / (SomaY2 - (pow(SomaY, 2) / qtdPts))));
}

float CalculaA0(int qtdPts, tabela tbPts){
    int i;
    float SomaY, SomaX, SomaXY, SomaX2;
    SomaY = SomaX = SomaXY = SomaX2 = 0;
   
    for(i = 0; i < qtdPts; i++){
        SomaY += tbPts[1][i];
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaX += tbPts[0][i];
    }
   
    for(i = 0; i < qtdPts; i++){
        SomaXY += tbPts[0][i] * tbPts[1][i];
    }
   
    for(i = 0; i < qtdPts; i++){
        SomaX2 += pow(tbPts[0][i], 2);
    } 
    
    return ((qtdPts * SomaXY) - (SomaX * SomaY)) / ((qtdPts * SomaX2) - pow(SomaX, 2));
}

float CalculaA1(int qtdPts, tabela tbPts, float a0){
   int i;
   float SomaY, SomaX;
   SomaY = SomaX = 0;
   
    for(i = 0; i < qtdPts; i++){
        SomaY += tbPts[1][i];
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaX += tbPts[0][i];
    }
    
    return (SomaY - (a0 * SomaX)) / qtdPts;
}

void AjusteReta(int qtdPts, tabela tbPts, float *a0, float *a1, vetorY vetY, float *coeficiente){
    int cont2;
    int i;
    (*a0) = CalculaA0(qtdPts, tbPts);
    (*a1) = CalculaA1(qtdPts, tbPts, *a0);
    
    for(i = 0; i < qtdPts;  i++){
       vetY[i] = (*a0) * tbPts[0][i] + (*a1);
    }
    
    *coeficiente = CoeficienteDeterminacao(qtdPts, tbPts, vetY);
}

void AjustePolinomio(int qtdPts, int grau, tabela tbPts, vetorA vetA, vetorY vetY, float *coeficiente){
    float mat[grau + 1][maxgrau], vet[grau + 1], soma;
    int i, j, k;
    
    mat[0][0] = qtdPts;
    for (i = 0; i <= grau; i++){
        for (j = 0; j < qtdPts; j++){
            soma = 0;
            for(k = 0; k < qtdPts; k++)
              soma += pow(tbPts[0][k], (i + j));
            if((i > 0)||(j > 0))
                mat[i][j] = soma;
        }
    }
    
    for (i = 0;i <= grau; i++){
         soma = 0;
         for(j = 0;j < qtdPts; j++){
             soma += (pow(tbPts[0][j], i) * (tbPts[1][j]));
         }
         vet[i] = soma;
    }
    
    CalculaPorGaussCompacto(mat, vet, vetA, (grau + 1));
    for(i = 0; i < qtdPts; i++){
        soma=0;
        for (j = 0;j <= grau; j++){
           soma += (pow(tbPts[0][i], j) * vetA[j]);
        }
        vetY[i] = soma;
    }
    
    *coeficiente = CoeficienteDeterminacao(qtdPts, tbPts, vetY);
}

void AjusteExponencial(int qtdPts, tabela tbPts, float *a, float *b, vetorY vetY, float *coeficiente){
    double bAux, SomaX, SomaY, SomaX2, SomaXY;
    SomaX = SomaY = SomaX2 = SomaXY = 0;
    int i, j;
    vetorY lnY;
    
    for(i = 0; i < qtdPts; i++){
        lnY[i] = log(tbPts[1][i]);
        SomaY += lnY[i];
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaX += tbPts[0][i];
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaX2 += pow(tbPts[0][i], 2);
    }
    
    for(i = 0; i < qtdPts; i++){
        SomaXY += tbPts[0][i] * lnY[i];
    }
    
    bAux = ((qtdPts * SomaXY) - (SomaX * SomaY)) / ((qtdPts * SomaX2) - (SomaX * SomaX));
    
    *a = exp(bAux);
    *b = exp((SomaY - (bAux * SomaX)) / qtdPts);
    
    for(i = 0; i < qtdPts; i++){
        vetY[i] = (*a) * (pow(*b, tbPts[0][i]));
    }
    
    *coeficiente = CoeficienteDeterminacao(qtdPts, tbPts, vetY);
}

int main(){
    int escolha, qtdPts, i; 
    float coeficiente, a, b, x, grau;
    tabela tbPts;
    vetorY vetY;
    vetorA vetA;

    printf("OPERACOES:\n");
    printf("1 - Lagrange\n");
    printf("2 - Newton\n");
    printf("3 - Newton Gregory\n");
    printf("4 - Ajuste de Reta\n");
    printf("5 - Ajuste de Polinomio\n");
    printf("6 - Ajuste Exponencial\n");

    printf("\nEscolha uma operacao: ");
    do{
        scanf("%d", &escolha);
    }while (escolha < 1 || escolha > 7);
    
    system("cls");
    printf("Quantidade de pontos: ");
    scanf("%d", &qtdPts);
    system("cls");
    printf("Tabela de pontos: \n");
    for(i = 0; i < qtdPts; i++){
        printf("X%d = ", i);
        scanf("%f", &tbPts[0][i]);
        printf("Y%d = ", i);
        scanf("%f", &tbPts[1][i]);
    }     
    system("cls");
    
    switch(escolha){
        case 1:
               printf("Ponto onde deseja conhecer o P(x) interpolado: ");
               scanf("%f", &x);
               system("cls");
               MostrarTabela(qtdPts, tbPts);
               printf("\nLAGRANGE\nP(%f) = %f", x, Lagrange(qtdPts, tbPts, x));
               break;
        case 2:
               printf("Ponto onde deseja conhecer o P(x) interpolado: ");
               scanf("%f", &x);
               system("cls");
               MostrarTabela(qtdPts, tbPts);
               printf("\nNEWTON\nP(%f) = %f", x, Newton(qtdPts, tbPts, x));
               break;
        case 3:
               printf("Ponto onde deseja conhecer o P(x) interpolado: ");
               scanf("%f", &x);
               system("cls");
               MostrarTabela(qtdPts, tbPts);
               printf("\nNEWTON GREGORY\nP(%f) = %f", x, NewtonGregory(qtdPts, tbPts, x));
               break;
        case 4:
               MostrarTabela(qtdPts, tbPts);
               AjusteReta(qtdPts, tbPts, &a, &b, vetY, &coeficiente);
               printf("\nAJUSTE DE RETA\n");
               printf("a0 = %f\na1 = %f\ncoeficiente = %f\n", a, b, coeficiente);
               printf("Vetor Y ajustado:\n");
               MostrarVetor(qtdPts, vetY);
               break;
        case 5:
               printf("Grau desejado do polinomio: ");
               scanf("%f", &grau);
               system("cls");
               MostrarTabela(qtdPts, tbPts);
               AjustePolinomio(qtdPts, grau, tbPts, vetA, vetY, &coeficiente);
               printf("\nAJUSTE EXPONENCIAL\n");
               printf("coeficiente = %f\n", coeficiente);
               printf("\nCoeficientes do polinomio ajustados:\n");
               MostrarVetor(qtdPts, vetA);
               printf("\nVetor Y ajustado:\n");
               MostrarVetor(qtdPts, vetY);
               break;
        case 6:
               MostrarTabela(qtdPts, tbPts);
               AjusteExponencial(qtdPts, tbPts, &a, &b, vetY, &coeficiente);
               printf("\nAJUSTE EXPONENCIAL\n");
               printf("a = %f\nb = %f\ncoeficiente = %f\n", a, b, coeficiente);
               printf("Vetor Y ajustado:\n");
               MostrarVetor(qtdPts, vetY);
               break;
    }
    system("pause"); 
    return 0;
}
