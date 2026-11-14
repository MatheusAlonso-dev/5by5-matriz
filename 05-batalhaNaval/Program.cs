Random random = new Random();
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
            tabuleiro[i, j] = random.Next(1,5);
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
            
            switch(tabPlayer[i, j])
            {
                
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@ ");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("x ");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("* ");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("O ");
                    break;
            }

        }
        Console.ResetColor();
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
