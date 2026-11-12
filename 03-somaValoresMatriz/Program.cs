using System.Security.Cryptography;

int qtdLinhas = 5;
int qtdColunas = 5;

int[,] matriz1 = new int[qtdLinhas, qtdColunas];

//popular matriz
void popularMatriz(int[,] matriz)
{
    for (int i = 0; i < qtdLinhas; i++)
    {
        for (int j = 0; j < qtdColunas; j++)
        {
            matriz[i, j] = RandomNumberGenerator.GetInt32(1, 9);
        }
    }
}

//imprimir matriz
void imprimirMatriz(int[,] matriz)
{
    Console.WriteLine("-----------------------\n\tMATRIZ");
    for (int i = 0; i < qtdLinhas; i++)
    {
        for (int j = 0; j < qtdColunas; j++)
        {
            Console.Write(matriz[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void somarLinhas(int[,] matriz)
{
    Console.WriteLine("-----------------------\n\tSOMAR LINHAS");
    for (int i = 0; i < qtdLinhas; i++)
    {
        int result = 0;
        for (int j = 0; j < qtdColunas; j++)
        {
            result += matriz[i, j]; 
            Console.Write(matriz[i, j] + " ");
        }
        Console.Write("= " + result);
        Console.WriteLine();
    }
}

void somarColunas(int[,] matriz)
{
    int[] vet = new int[qtdLinhas];

    Console.WriteLine("-----------------------\n\tSOMAR COLUNAS");
    for (int i = 0; i < qtdLinhas; i++)
    {

        for (int j = 0; j < qtdColunas; j++)
        {
            vet[j] += matriz[i, j];

            Console.Write(matriz[i, j] + "  ");
        }
        Console.WriteLine();

    }

    for (int i = 0; i < qtdLinhas; i++)
    {
        Console.Write("=  ");
    }
        Console.WriteLine();

    for (int i = 0; i < qtdLinhas; i++)
    {
        Console.Write(vet[i] + " ");
    }
    Console.WriteLine();
}

void somarDiagonais(int[,] matriz)
{    
    int resultDiagonalPrincipal = 0;
    int contadorDiagonalPrincipal=0;

    int resultDiagonalInversa = 0;
    int contadorDiagonalInversa = qtdLinhas-1;

    Console.WriteLine("-----------------------\n\tSOMAR DIAGONAIS");
    for (int i = 0; i < qtdLinhas; i++)
    {
        for (int j = 0; j < qtdColunas; j++)
        {
            if(j==contadorDiagonalPrincipal)
                resultDiagonalPrincipal += matriz[i, j];

            if (j == contadorDiagonalInversa)
                resultDiagonalInversa += matriz[i, j];

            Console.Write(matriz[i, j] + " ");
        }
        contadorDiagonalPrincipal++;
        contadorDiagonalInversa--;
        Console.WriteLine();
        
    }
    Console.WriteLine("\nsoma diagonal principal: " + resultDiagonalPrincipal);
    Console.WriteLine("soma diagonal inversa: " + resultDiagonalInversa);
}




popularMatriz(matriz1);
imprimirMatriz(matriz1);
somarLinhas(matriz1);
somarColunas(matriz1);
somarDiagonais(matriz1);

