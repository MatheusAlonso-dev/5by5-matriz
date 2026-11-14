Random random = new Random();
int tamanhoTabuleiro = 10;
int[,] tabuleiroPlayer = new int[tamanhoTabuleiro, tamanhoTabuleiro];
int[,] tabuleiroMaquina = new int[tamanhoTabuleiro, tamanhoTabuleiro];
char[] indiceCaracter = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
string SpanJogadaAnterior;

int jogadorDaVez = 1;
string nomePlayer = "player";
string nomeMaquina = "maquina";
string nomeJogadorDaVez = "nome inicializdo";


//Console.ForegroundColor = ConsoleColor.Red;

void popularTabuleiros(int[,] tabuleiro)
{
    //preencher com agua
    for(int i = 0; i < tamanhoTabuleiro; i++)
    {
        for (int j = 0; j < tamanhoTabuleiro; j++)
        {
            tabuleiro[i, j] = 1;
        }
    }

    //randomizar local navios
    int qtdNaviosInseridos = 0;
    int tamanhoNavio = 0;
    int[] navio = new int[2];
    int linhaNavio;
    int colunaNavio;
    int direcao;
    
    while(qtdNaviosInseridos < 10)
    {
        bool inseriuNavio = false;

        if (qtdNaviosInseridos < 1)
            tamanhoNavio = 5;
        else if (qtdNaviosInseridos < 3)
            tamanhoNavio = 4;
        else if (qtdNaviosInseridos < 6)
            tamanhoNavio = 3;
        else
            tamanhoNavio = 2;

        navio[1] = tamanhoNavio;

        while (!inseriuNavio)
        {
            //linha e coluna
            linhaNavio = random.Next(0, 10);
            colunaNavio = random.Next(0, 10);

            direcao = random.Next(0, 2);
            navio[0] = direcao;
            int contaCasaLivre = 0;

            if (direcao == 0)
            {
                if(colunaNavio + tamanhoNavio <= tamanhoTabuleiro)
                {
                    for (int i = colunaNavio; i < colunaNavio + tamanhoNavio; i++)
                    {
                        if (tabuleiro[linhaNavio, i] == 1)
                            contaCasaLivre++;
                    }

                    if (contaCasaLivre == tamanhoNavio)
                    {
                        for (int i = colunaNavio; i < colunaNavio + tamanhoNavio; i++)
                        {
                            tabuleiro[linhaNavio, i] = 4;
                        }
                        inseriuNavio = true;
                        qtdNaviosInseridos++;
                    }
                }                

            }
            else
            {
                if (linhaNavio + tamanhoNavio <= tamanhoTabuleiro)
                {
                    for (int i = linhaNavio; i < linhaNavio + tamanhoNavio; i++)
                    {
                        if (tabuleiro[i, colunaNavio] == 1)
                            contaCasaLivre++;
                    }

                    if (contaCasaLivre == tamanhoNavio)
                    {
                        for (int i = linhaNavio; i < linhaNavio + tamanhoNavio; i++)
                        {
                            tabuleiro[i, colunaNavio] = 4;
                        }
                        inseriuNavio = true;
                        qtdNaviosInseridos++;
                    }
                }
            }

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
            switch (tabMaquina[i, j])
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
        Console.WriteLine();
    }
}

bool atirarNoTabuleiro(int[,] tabuleiro, int linha, int coluna)
{
    if (tabuleiro[linha, coluna] == 1)
        tabuleiro[linha, coluna] = 3;
    else if(tabuleiro[linha, coluna] == 4)
    {
        tabuleiro[linha, coluna] = 2;
        return true;
    }

    return false;
}

void alterarNomeJogadorDaVez(int idJogadorDaVez)
{
    if (idJogadorDaVez == 1)
        nomeJogadorDaVez = nomePlayer;
    if (idJogadorDaVez == 2)
        nomeJogadorDaVez = nomeMaquina;
}

void alterarSpanJogadaAnterior(int[,] tabuleiro, int linha, int coluna)
{
    if (tabuleiro[linha, coluna] == 1)
        SpanJogadaAnterior = $"jogador {nomeJogadorDaVez}atirou em [{linha},{coluna}] e acertou na agua.";
    if (tabuleiro[linha,coluna] == 2)
        SpanJogadaAnterior = $"jogador {nomeJogadorDaVez}atirou em [{linha},{coluna}] e acertou no MESMO lugar de um navio.";
    if (tabuleiro[linha,coluna] == 3)
        SpanJogadaAnterior = $"jogador {nomeJogadorDaVez}atirou em [{linha},{coluna}] e acertou no MESMO lugar da agua.";
    if (tabuleiro[linha,coluna] == 4)
        SpanJogadaAnterior = $"jogador {nomeJogadorDaVez}atirou em [{linha},{coluna}] e ACERTOU UM NAVIO!";
}



popularTabuleiros(tabuleiroPlayer);
popularTabuleiros(tabuleiroMaquina);
imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
