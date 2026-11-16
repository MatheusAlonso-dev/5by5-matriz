// CONFIGURAÇÕES
bool modoComico = false;

bool modoDaltonico = false;
bool navioVisivel = false;

char charAgua = 'O';
char charNavioVisivel = '*';
char charNavioDanificado = '@';
char charTiroVago = 'x';

//--------------------------

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

int contTentativas = 0;

if (modoComico)
{
    modoDaltonico = true;
    navioVisivel = true;   
}

if (modoDaltonico)
{
    charAgua = '.';
}


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
    
    Console.WriteLine($"\n\t\t\t\tBATALHA NAVAL\n\n\t      SEU TABULEIRO\t\t    TABULEIRO {nomeMaquina}\n");

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
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{charNavioDanificado} ");
                    break;
                case 3:
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{charTiroVago} ");
                    break;
                case 4:
                    if (navioVisivel)
                    {
                        if (!modoDaltonico)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{charNavioVisivel} ");
                    }
                    else
                    {
                        if (!modoDaltonico)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{charAgua} ");
                    }
                    
                    break;
                default:
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{charAgua} ");
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
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{charNavioDanificado} ");
                    break;
                case 3:
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{charTiroVago} ");
                    break;
                case 4:
                    if (navioVisivel)
                    {
                        if (!modoDaltonico)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{charNavioVisivel} ");
                    }
                    else
                    {
                        if (!modoDaltonico)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{charAgua} ");
                    }
                    break;
                default:
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{charAgua} ");
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

void jogadaPlayer(int[,] tabuleiroMaq, int linh, int col)
{
    alterarSpanJogadaAnterior(tabuleiroMaq, linh, col);
    if (atirarNoTabuleiro(tabuleiroMaq, linh, col))
    {
        jogadorDaVez = 1;
        pontosPlayer++;
    }
    else
        jogadorDaVez = 2;

}

void imprimirWarnig()
{
    string warning = File.ReadAllText("warning.txt");
    for(int i = 0; i < 3; i++)
    {
        Console.Clear();
        Thread.Sleep(500);
        Console.WriteLine(warning);
        Thread.Sleep(300);

    }

}

void imprimirRisada()
{
    string frase = "Adivinha quem vai jogar de novo?";
    Console.Write("\n\n\n\n\t");
    for(int i = 0; i < frase.Length; i++)
    {
        Console.Write(frase[i]);
        Thread.Sleep(50);
    }
    Console.Write("\n\t");
    for (int i = 0; i < 30; i++)
    {
        Console.Write("k");
        Thread.Sleep(50);
    }
    Thread.Sleep(2000);
}

void imprimirFrase1()
{
    string frase = "É assim então? vamos ver se vc é bom mesmo!";
    Console.Write("\n\n\n\n\t");
    for (int i = 0; i < frase.Length; i++)
    {
        Console.Write(frase[i]);
        Thread.Sleep(50);
    }    
    
    Thread.Sleep(1000);
    frase = "Desligando modo daltonico";
    Console.Clear();
    Console.Write("\n\n\n\n\t");
    for (int i = 0; i < frase.Length; i++)
    {
        Console.Write(frase[i]);
        Thread.Sleep(50);
    }
    Console.Write("\n\n\t");
    for (int i = 0; i < 10; i++)
    {
        Console.Write("k");
        Thread.Sleep(50);
    }

    Thread.Sleep(2000);


}

void imprimirFraseFinal()
{
    string frase = "Que pena, você perdeu!";
    Console.Write("\n\n\n\n\t");
    for (int i = 0; i < frase.Length; i++)
    {
        Console.Write(frase[i]);
        Thread.Sleep(50);
    }

    Thread.Sleep(1000);
    frase = "NÃO tente novamente mais tarde!";
    Console.Write("\n\t");
    for (int i = 0; i < frase.Length; i++)
    {
        Console.Write(frase[i]);
        Thread.Sleep(50);
    }
    Console.Write("\n\n\n\n\n\n");
}

void imprimirBinario(int temp)
{
    Console.Clear();
    for (int i = 0; i < temp; i++)
    {
        Console.Write(random.Next(0, 2));
    }
    Console.Clear();
}

//---------------------------------------------------------

popularTabuleiros(tabuleiroPlayer);
popularTabuleiros(tabuleiroMaquina);

if (!modoComico)
{
    // modo normal
    while (!jogoFinalizado)
    {
        atualizarNomeJogadorDaVez();

        int linhaRandom = random.Next(0, 10);
        int colunaRandom = random.Next(0, 10);

        if (jogadorDaVez == 1)
        {
            char linhaChar = '@';
            int linha = 0;
            int coluna = 0; ;
            bool casaValida = true;

            while (true)
            {
                Console.Clear();
                imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
                Console.WriteLine($"\n\t{spanJogadaAnterior}");

                if (!casaValida)
                {
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tcasa inválida! Digite novamente.");
                    Console.ResetColor();

                }
                else
                {
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tSua vez!");
                    Console.ResetColor();
                }

                Console.Write("\n\tDigite a linha e coluna(ex: b1): ");
                string casaString = Console.ReadLine();

                if (casaString.Length < 2 || !char.IsLetter(casaString[0]) || !char.IsDigit(casaString[1]))
                {
                    casaValida = false;
                    continue;
                }

                linhaChar = casaString[0];
                linha = identificaChar(linhaChar);

                coluna = int.Parse(casaString[1].ToString());

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
                if (tabuleiroPlayer[linhaRandom, colunaRandom] == 1 || tabuleiroPlayer[linhaRandom, colunaRandom] == 4)
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

}
else
{
    // modo comico
    Console.Write("\n\n\n\n\t Digite seu nome de jogador: ");
    nomePlayer = Console.ReadLine();

    Console.WriteLine("\n\n\n\n\t Escolhendo seu adversario...");
    Thread.Sleep(4000);
    nomeMaquina = "Cyber Pestana";

    Console.Clear();
    Console.WriteLine($"\n\n\n\n\t Você vai jogar contra: {nomeMaquina}");
    Thread.Sleep(5000);

    Console.Clear();
    Console.WriteLine($"\n\n\n\n\t (Modo daltonico ativado)");
    Thread.Sleep(3000);


    while (!jogoFinalizado)
    {
        atualizarNomeJogadorDaVez();

        int linhaRandom = random.Next(0, 10);
        int colunaRandom = random.Next(0, 10);

        if (jogadorDaVez == 1)
        {
            char linhaChar = '@';
            int linha = 0;
            int coluna = 0; ;
            bool casaValida = true;

            //confere se a casa é valida
            while (true)
            {
                Console.Clear();
                imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
                Console.WriteLine($"\n\t{spanJogadaAnterior}");

                if (!casaValida)
                {
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tcasa inválida! Digite novamente.");
                    Console.ResetColor();

                }
                else
                {
                    if (!modoDaltonico)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tSua vez!");
                    Console.ResetColor();
                }

                Console.Write("\n\tDigite a linha e coluna(ex: b1): ");
                string casaString = Console.ReadLine();

                if (casaString.Length < 2 || !char.IsLetter(casaString[0]) || !char.IsDigit(casaString[1]))
                {
                    casaValida = false;
                    continue;
                }

                linhaChar = casaString[0];
                linha = identificaChar(linhaChar);

                coluna = int.Parse(casaString[1].ToString());

                if (linha >= 0 && linha <= 9 && coluna >= 0 && coluna <= 9)
                    break;

                casaValida = false;
            }

            switch (pontosPlayer)
            {
                case 5:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    
                    Console.Clear();
                    imprimirWarnig();
                    imprimirBinario(5000);                    
                    Console.WriteLine($"\n\n\n\n\t {nomeMaquina} Hackeou o jogo e decidiu que é a vez dele de jogar...");
                    Thread.Sleep(5000);
                    jogadorDaVez = 2;
                    break;
                case 10:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    imprimirBinario(5000);

                    Console.WriteLine($"\n\n\n\n\t {nomeMaquina} decidiu que é a vez dele de novo...");
                    Thread.Sleep(4000);
                    jogadorDaVez = 2;

                    break;

                case 20:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    imprimirBinario(5000);
                   
                    Console.WriteLine($"\n\n\n\n\tele de novo...");
                    Thread.Sleep(5000);
                    jogadorDaVez = 2;

                    break;

                case 22:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    imprimirBinario(40000);                    
                    imprimirRisada();
                    jogadorDaVez = 2;

                    break;

                case 25:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    imprimirBinario(40000);                    
                    imprimirFrase1();
                    jogadorDaVez = 2;
                    modoDaltonico = false;
                    charAgua = 'O';
                    charNavioDanificado = 'O';
                    charNavioVisivel = 'O';
                    charTiroVago = 'O';
                    break;
                                    
                case 29:
                    contTentativas++;

                    if (contTentativas > 2)
                    {
                        imprimirBinario(40000);                        
                        jogadorDaVez = 2;

                        charAgua = '.';
                        charNavioDanificado = '@';
                        charNavioVisivel = '*';
                        charTiroVago = 'x';
                    }

                    break;
                default:
                    jogadaPlayer(tabuleiroMaquina, linha, coluna);
                    break;

            }

            

        }
        else
        {
            // jogador 2
            Console.WriteLine($"\n\n\n\n\tAguardando {nomeJogadorDaVez} jogar...");
            if(contTentativas < 2)
                Thread.Sleep(2000);
            else
                Thread.Sleep(250);
            bool casaNova = false;

            while (!casaNova)
            {
                if (tabuleiroPlayer[linhaRandom, colunaRandom] == 1 || tabuleiroPlayer[linhaRandom, colunaRandom] == 4)
                {
                    casaNova = true;
                }
                else
                {
                    linhaRandom = random.Next(0, 10);
                    colunaRandom = random.Next(0, 10);
                }

                if(contTentativas > 2)
                {
                    casaNova = false;
                    if (tabuleiroPlayer[linhaRandom, colunaRandom] == 4)
                    {
                        casaNova = true;
                    }
                    else
                    {
                        linhaRandom = random.Next(0, 10);
                        colunaRandom = random.Next(0, 10);
                    }

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
}

Console.WriteLine("\n------------------------------------------------------------");
if(contTentativas == 0)
{
Console.WriteLine($"\n\t{nomeJogadorDaVez} ganhou!!\n\n\n\n");
}
else
{

    Console.Clear();
    imprimirTabuleiros(tabuleiroPlayer, tabuleiroMaquina);
    Console.WriteLine($"\n\t{spanJogadaAnterior}");

    imprimirFraseFinal();
}
