
// exclui registo do arquivo
// busca por codigo e mes
// gera novo arquivo auxiliar, depois exclui arquivo original

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
		 { cout << "Digite o c¢digo do vendedor a ser exclu¡do ";
			 cin >> cod;
			 cout << "Digite o mˆs a ser exclu¡do ";
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
					{ auxi = fopen("c:\\auxi.dat", "ab+");
						fclose(loja);
						loja = fopen("c:\\vendas.dat", "rb");
						fread(&b, sizeof(vendedor), 1, loja);
						while (!feof(loja))
							{ if ((b.codigo_vendedor != cod) || (b.mes != mes))
									 fwrite(&b, sizeof(vendedor), 1, auxi);
								fread(&b, sizeof(vendedor), 1, loja);
							}
						fclose(loja);
						fclose(auxi);
						remove("c:\\vendas.dat");
						rename("c:\\auxi.dat", "c:\\vendas.dat");
						cout << "\nDados exclu¡dos com sucesso !";
						getch();
					}
		 }
}
