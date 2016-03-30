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
	int cod, mes, c;
	loja = fopen("c:\\vendas.dat", "ab+");
	clrscr();
	if (loja == NULL)
		 { cout << "\nErro na cria‡ao dos arquivos";
			 getch();
		 }
	else
		 { cout << "Digite o c¢digo do vendedor desejado ";
			 cin >> cod;
			 cout << "Digite o mˆs desejado ";
			 cin >> mes;
			 c=0;
			 fread(&b, sizeof(vendedor), 1, loja);
			 while ((!feof(loja)) && ((cod != b.codigo_vendedor) || (mes != b.mes)))
				 { fread(&b, sizeof(vendedor), 1, loja);
					 c++;
				 }
			 if (feof(loja))
					{ cout << "\nVenda nao cadastrada ! ";
						getch();
						fclose(loja);
					}
				else
					{ rewind(loja);
						fseek(loja, c * sizeof(vendedor), SEEK_SET);
						cout << "\nC¢digo: " << b.codigo_vendedor;
						cout << "\nNome: " << b.nome_vendedor;
						cout << "\nMˆs: " << b.mes;
						cout << "\nValor da venda: " << b.valor_venda << "\n";
						getch();
					}
			 fclose(loja);
		 }
}
