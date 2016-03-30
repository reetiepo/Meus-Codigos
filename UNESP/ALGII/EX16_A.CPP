
// busca vendedor por codigo.
// soma quantidade de venda do vendedor

#include <iostream.h>
#include <conio.h>
#include <stdio.h>
void main()
{ struct vendedor
    { int codigo_vendedor, mes;
      char nome_vendedor[20];
      float valor_venda;
    };
  FILE *loja, *auxi;
  vendedor b;
  int cod;
	float total=0;
	loja = fopen("c:\\vendas.dat", "ab+");
	clrscr();
	if (loja == NULL)
		 { cout << "\nErro na cria‡ao dos arquivos";
			 getch();
		 }
	else
		 { cout << "Digite o c¢digo do vendedor desejado ";
			 cin >> cod;
			 fread(&b, sizeof(vendedor), 1, loja);
			 if (feof(loja))
					{ cout << "\nArquivo vazio !";
						getch();
					}
			 else
					{ while (!feof(loja))
							{ if (b.codigo_vendedor == cod)
									 total = total + b.valor_venda;
								fread(&b, sizeof(vendedor), 1, loja);
							}
						if (total == 0)
							 cout << "\nNao existem vendas cadastradas para este vendedor";
						else
							 cout << "\nTotal das vendas " << total;
						getch();
					}
				fclose(loja);
		 }
}
