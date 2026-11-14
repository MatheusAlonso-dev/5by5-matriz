int tamanhoTabuleiro = 10;
int[,] tabuleiroPlayer = new int[tamanhoTabuleiro, tamanhoTabuleiro];
int[,] tabuleiroMaquina = new int[tamanhoTabuleiro, tamanhoTabuleiro];
char[] indiceCaracter = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
//Console.ForegroundColor = ConsoleColor.Red;

void popularTabuleiros(int[,] tabuleiro)
{
    for(int i = 0; i < tamanhoTabuleiro; i++)
    {
        for (int j = 0; j < tamanhoTabuleiro; j++)
        {
            tabuleiro[i, j] = 1;
        }
    }
}

void imprimirTabuleiros(int[,] tabPlayer, int[,] tabMaquina)
{
    
    Console.WriteLine("\nSEU TABULEIRO\t\t\tTABULEIRO MAQUINA\n\n");

    //imprime indice coluna 2 tabelas
    Console.Write("   ");
    for (int i = 0; i < tamanhoTabuleiro; i++)
    {
        Console.Write($"{i} ");
    }
    Console.Write("\t\t   ");
    for (int j = 0; j < tamanhoTabuleiro; j++)
    {
        Console.Write($"{j} ");
    }
    Console.WriteLine("\n");

    //imprimir valores tabelas
    for (int i = 0; i < tamanhoTabuleiro; i++)
    {
        Console.Write($"{indiceCaracter[i]}  ");

        for (int j = 0; j < tamanhoTabuleiro; j++)
        {
            if(tabPlayer[i, j] == 1)
                Console.Write("O ");
        }
        Console.Write("\t\t");

        Console.Write($"{indiceCaracter[i]}  ");
        for (int j = 0; j < tamanhoTabuleiro; j++)
        {
            if (tabPlayer[i, j] == 1)
                Console.Write("O ");
        }
        Console.WriteLine();
    }
}

popularTabuleiros(tabuleiroPlayer);
imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
