#include <iostream.h>
#include <conio.h>
#include <stdio.h>
void main()
{ FILE *l;
	l = fopen("c:\\vendas.dat", "wb");
  clrscr();
  if (l == NULL)
		 cout << "\nErro na cria‡ao do arquivo";
	else
		 { cout << "\nSucesso na cria‡ao do arquivo";
       fclose(l);
     }
  getch();
}
