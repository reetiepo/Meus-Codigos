// insere dados de vendedor - verifica codigo vendedor e mes da venda

#include <iostream.h>
#include <conio.h>
#include <stdio.h>
void main()
{ struct vendedor
    { int codigo_vendedor, mes;
      char nome_vendedor[20];
      float valor_venda;
    };
  FILE *loja;
  vendedor a, b;
	loja = fopen("c:\\vendas.dat", "ab+");
	clrscr();
	if (loja == NULL)
		 { cout << "\nErro na cria‡ao dos arquivos";
			 getch();
		 }
	else
		 { cout << "\nDigite o c¢digo do vendedor a ser inclu¡do ";
			 cin >> a.codigo_vendedor;
			 cout << "Digite o mˆs da venda a ser inclu¡do ";
			 cin >> a.mes;
			 fread(&b, sizeof(vendedor), 1, loja);
			 if (feof(loja))
					{ cout << "Digite o nome do vendedor a ser inclu¡do ";
						gets(a.nome_vendedor);
						cout << "Digite o valor da venda a ser inclu¡da ";
						cin >> a.valor_venda;
						fwrite(&a, sizeof(vendedor), 1, loja);
						fclose(loja);
						cout << "\nVenda inclu¡da com sucesso !";
						getch();
					}
			 else
				 { while ((!feof(loja)) && ((a.codigo_vendedor != b.codigo_vendedor)
									|| ((a.codigo_vendedor == b.codigo_vendedor) && (a.mes != b.mes))))
						 { fread(&b, sizeof(vendedor), 1, loja);
						 }
					 if (feof(loja))
							{ cout << "Digite o nome do vendedor a ser inclu¡do ";
								gets(a.nome_vendedor);
								cout << "Digite o valor da venda a ser inclu¡da ";
								cin >> a.valor_venda;
								fwrite(&a, sizeof(vendedor), 1, loja);
								cout << "\nVenda inclu¡da com sucesso !";
								getch();
							}
					 else
						{ cout << "\nDados j  estao cadastrados !";
							getch();
						}
			 fclose(loja);
		 }
	 }
}

