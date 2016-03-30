#include <stdio.h>
#include <conio.h>

//Calcula o numero magico(correspondente a soma das linhas/colunas/diagonais)
int CalcularNumMagico(int ordem)
{
   return ((ordem*ordem*ordem+ordem)/2);
}

//Le a ordem e verifica se eh um numero impar, positivo e menor que 9
int LerOrdem()
{
   int ordem;
   printf("Digite a ordem (positivo, impar e menor que 9) do Quadrado Magico:");
   scanf("%d",&ordem);
   if (ordem%2==0 || ordem > 9 || ordem < 1)
      do
      {
	 printf("Digite uma ordem valida:");
	 scanf("%d",&ordem);
      }
      while(ordem%2==0 || ordem > 9 || ordem < 1);
   return ordem;
}
//Mostra a matriz
void MostrarMatriz(int Mat[9][9], int ordem)
{
   printf("A ordem escolhida foi: %d\n",ordem);
   printf("A soma das linhas, colunas e diagonais deve ser: %d",CalcularNumMagico(ordem));

   //Comeca na linha 4 coluna 0
   for (int i=ordem-1;i>=0;i--)
   {
      printf("\n\n");
      for (int j=0;j<ordem;j++)
      {
	 printf("%d\t",Mat[i][j]);
      }
   }
}
//Controi a matriz correspondente ao quadrado magico
void ConstruirQuadrado(int ordem)
{
   clrscr();
   int i, j, k, total;
   int Mat[9][9];

   total = ordem*ordem; //total de numeros que serao usados

   //Atribui valor 0 ao espaco da matriz que sera usado
   for (i=0;i<ordem;i++)
      for (j=0;j<ordem;j++)
	 Mat[i][j] = 0;

   //Define da posicao do numero 1
   i = ordem-1; //primeira linha que sera mostrada
   j = ordem/2; //coluna central
   k = 1;
   Mat[i][j] = k;
   //Monta a matriz distribuindo os numeros em ordem na diagonal
   do
   {
      //Aumenta os indices para "andar" na diagonal
      i++;
      j++;
      //Aumenta o valor que sera colocado na matriz
      k++;
      //Verifica se a linha esta fora e a coluna dentro do intervalo
      if (i == ordem && j < ordem)
	 i = 0;
      //Verifica se a coluna esta fora e a linha dentro do intervalo
      else if (i < ordem && j == ordem)
	 j = 0;
      //Verifica se coluna e linha estao fora do intervalo OU
      //Verifica se o campo da matriz ja possui algum valor
      else if ((i == ordem && j == ordem) || (Mat[i][j] != 0))
      {
	 i = i-2;
	 j--;
      }
      //Atribui valor ao campo da matriz
      Mat[i][j] = k;
   }
   while(k <= total); //Repete ate que todos os numeros estejam na matriz
   MostrarMatriz(Mat,ordem);
}

void main()
{
   int key;
   //Faz o reprocessamento
   do
   {
      clrscr();
      ConstruirQuadrado(LerOrdem());
      printf("\n\nAperte 0 para construir outro Quadrado Magico:");
      scanf("%d",&key);
   }
   while(key == 0);
}

