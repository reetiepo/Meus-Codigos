
// abre pra leitura e escrita --- alteracao
// busca por codigo vendedor e mes

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
	loja = fopen("c:\\vendas.dat", "rb+");
	clrscr();
	if (loja == NULL)
		 { cout << "\nErro na cria‡ao dos arquivos";
			 getch();
		 }
	else
		 { cout << "Digite o c¢digo do vendedor ";
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
					}
			 else
					{
               //Repositions a file pointer to the beginning of a stream.
               // rewind(stream) is equivalent to fseek(stream, 0L, SEEK_SET),
               // except that rewind clears the end-of-file and error indicators,
               //while fseek clears the end-of-file indicator only.

                  rewind(loja);
						fseek(loja, c * sizeof(vendedor), SEEK_SET);
						cout << "\nNome do vendedor " << b.nome_vendedor;
						cout << "\nValor atual da venda " << b.valor_venda;
						cout << "\nDigite novo valor da venda ";
						cin >> b.valor_venda;
						fwrite(&b, sizeof(vendedor), 1, loja);
						cout << "\nAltera‡ao realizada com sucesso !";
						getch();
					}
			 fclose(loja);
		 }
}
