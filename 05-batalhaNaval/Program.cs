Random random = new Random();
int tamanhoTabuleiro = 10;
int[,] tabuleiroPlayer = new int[tamanhoTabuleiro, tamanhoTabuleiro];
int[,] tabuleiroMaquina = new int[tamanhoTabuleiro, tamanhoTabuleiro];
char[] indiceCaracter = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
string spanJogadaAnterior = "";
bool jogoFinalizado = false;

int pontosPlayer = 0;
int pontosMaquina = 0;

int jogadorDaVez = 1;
string nomePlayer = "player";
string nomeMaquina = "maquina";
string nomeJogadorDaVez = "nome inicializdo";

bool navioVisivel = false;

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
    
    Console.WriteLine("\n\t\t\t\tBATALHA NAVAL\n\n\t      SEU TABULEIRO\t\t    TABULEIRO MAQUINA\n");

    //imprime indice coluna 2 tabelas
    Console.Write("\t   ");
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
        Console.Write($"\t{indiceCaracter[i]}  ");

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
                    if (navioVisivel)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O ");
                    }
                    
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
                    if (navioVisivel)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O ");
                    }
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

void atualizarNomeJogadorDaVez()
{
    if (jogadorDaVez == 1)
        nomeJogadorDaVez = nomePlayer;
    if (jogadorDaVez == 2)
        nomeJogadorDaVez = nomeMaquina;
}

void alterarSpanJogadaAnterior(int[,] tabuleiro, int linha, int coluna)
{
    if (tabuleiro[linha, coluna] == 1)
        spanJogadaAnterior = $"jogador {nomeJogadorDaVez} atirou em [{indiceCaracter[linha]},{coluna}] e acertou na agua.";
    if (tabuleiro[linha,coluna] == 2)
        spanJogadaAnterior = $"jogador {nomeJogadorDaVez} atirou em [{indiceCaracter[linha]},{coluna}] e acertou no MESMO lugar de um navio.";
    if (tabuleiro[linha,coluna] == 3)
        spanJogadaAnterior = $"jogador {nomeJogadorDaVez} atirou em [{indiceCaracter[linha]},{coluna}] e acertou no MESMO lugar da agua.";
    if (tabuleiro[linha,coluna] == 4)
        spanJogadaAnterior = $"jogador {nomeJogadorDaVez} atirou em [{indiceCaracter[linha]},{coluna}] e ACERTOU UM NAVIO!";
}

int identificaChar(char c)
{
    switch (c)
    {
        case 'a' or 'A':
            return 0;
            break;
        case 'b' or 'B':
            return 1;
            break;
        case 'c' or 'C':
            return 2;
            break;
        case 'd' or 'D':
            return 3;
            break;
        case 'e' or 'E':
            return 4;
            break;
        case 'f' or 'F':
            return 5;
            break;
        case 'g' or 'G':
            return 6;
            break;
        case 'h' or 'H':
            return 7;
            break;
        case 'i' or 'I':
            return 8;
            break;
        case 'j' or 'J':
            return 9;
            break;
        default:
            return -1;
            break;
    }
}

//---------------------------------------------------------

popularTabuleiros(tabuleiroPlayer);
popularTabuleiros(tabuleiroMaquina);

while (!jogoFinalizado)
{
    atualizarNomeJogadorDaVez();

    int linhaRandom = random.Next(0, 10);
    int colunaRandom = random.Next(0, 10);

    if (jogadorDaVez == 1)
    {
        char linhaChar='@';
        int linha=0;
        int coluna = 0; ;
        bool casaValida = true;

        while (true)
        {
            Console.Clear();
            imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
            Console.WriteLine($"\n\t{spanJogadaAnterior}");

            if (!casaValida)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tcasa inválida! [{linhaChar},{coluna}]. Digite novamente.");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tSua vez!");
                Console.ResetColor();
            }

            Console.Write("\n\tDigite a linha (char): ");
            linhaChar = char.Parse(Console.ReadLine());
            linha = identificaChar(linhaChar);

            Console.Write("\n\tDigite a coluna (int): ");
            coluna = int.Parse(Console.ReadLine());

            if (linha >= 0 && linha <= 9 && coluna >= 0 && coluna <= 9)
                break;

            casaValida = false;
        }



        alterarSpanJogadaAnterior(tabuleiroMaquina, linha, coluna);
        if (atirarNoTabuleiro(tabuleiroMaquina, linha, coluna))
        {
            jogadorDaVez = 1;
            pontosPlayer++;
        }
        else
            jogadorDaVez = 2;

    }
    else
    {
        Console.WriteLine("\n\tAguardando maquina jogar...");
        Thread.Sleep(2000);
        bool casaNova = false;

        while (!casaNova)
        {
            if (tabuleiroPlayer[linhaRandom,colunaRandom] == 1 || tabuleiroPlayer[linhaRandom, colunaRandom] == 4)
            {
                casaNova = true;                
            }
            else
            {
                linhaRandom = random.Next(0, 10);
                colunaRandom = random.Next(0, 10);
            }

        }

        alterarSpanJogadaAnterior(tabuleiroPlayer, linhaRandom, colunaRandom);
        if (atirarNoTabuleiro(tabuleiroPlayer, linhaRandom, colunaRandom))
        {
            jogadorDaVez = 2;
            pontosMaquina++;
        }
        else
            jogadorDaVez = 1;

    }

    Console.Clear();
    imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
    Console.WriteLine($"\n\t{spanJogadaAnterior}");

    if (pontosPlayer == 30 || pontosMaquina == 30)
        jogoFinalizado = true;

}

Console.WriteLine("\n------------------------------------------------------------");
Console.WriteLine($"{nomeJogadorDaVez} ganhou!!\n\n\n\n");


