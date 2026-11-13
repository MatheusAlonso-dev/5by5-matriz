Random random = new Random();

int qtdMateria = 4;
string[] materias = {"matematica","portugues","geografia","historia"};
float[,] notas = new float[qtdMateria,3];
string[] situacao = new string[4];

string[,] tabelaExibicao = new string[4,5];

void popularNotas()
{
    for(int i = 0; i < qtdMateria; i++)
    {
        for(int j = 0; j < 2; j++)
        {
            notas[i, j] = random.Next(4,10);
        }
    }
    calcularMedia();
}

void calcularMedia()
{
    for (int i = 0; i < qtdMateria; i++)
    {
        float result = 0;
        int j;

        for (j = 0; j < 2; j++)
        {
            result += notas[i, j];
        }
        notas[i, j] = result / 2;

        //>=7 aprovado, >5 && <7 recuperacao, <=5 reprovado
        if (notas[i, j] >= 7)
            situacao[i] = "aprovado";
        else if (notas[i, j] > 5)
            situacao[i] = "recuperacao";
        else
            situacao[i] = "reprovado";
    }
}

void imprimirNotas()
{
    for (int i = 0; i < qtdMateria; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"[{notas[i, j]}] ");
        }
        Console.WriteLine();
    }
}

void popularTabelaExibicao(){
    
    for (int i = 0; i < 4; i++)
    {
        for(int j = 0; j < 5; j++)
        {
            switch (j)
            {
                case 0:
                    tabelaExibicao[i,j] = materias[i];
                    break;
                case 1:
                    tabelaExibicao[i,j] =  notas[i, 0].ToString();
                    break;
                case 2:
                    tabelaExibicao[i,j] = notas[i, 1].ToString();
                    break;
                case 3:
                    tabelaExibicao[i,j] = notas[i, 2].ToString();
                    break;
                case 4:
                    tabelaExibicao[i, j] = situacao[i];
                    break;
            }
        }
    }    
}

void imprimirTabelaExibicao()
{
    Console.WriteLine("------------------------------------------------------\n\t\tBOLETIM ESCOLAR\n");
    Console.WriteLine("matéria\t\tp1\tp2\tmédia\tsituação\n");
    for (int i = 0; i < 4; i++)
    {
        for(int j = 0; j < 5; j++)
        {
            Console.Write($"{tabelaExibicao[i,j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine("\n------------------------------------------------------\n");
}

popularNotas();
popularTabelaExibicao();
imprimirTabelaExibicao();
