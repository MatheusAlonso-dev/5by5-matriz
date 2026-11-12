using System.Security.Cryptography;

int qtdLinhas = 3;
int qtdColunas = 5;

int[,] matriz = new int[qtdLinhas, qtdColunas];
int[,] matrizInversa = new int[qtdColunas, qtdLinhas];

//popular matriz
for (int i = 0; i < qtdLinhas; i++)
{
    for (int j = 0; j < qtdColunas; j++)
    {
        matriz[i, j] = RandomNumberGenerator.GetInt32(1, 9);
        Console.Write(matriz[i, j] + " ");
    }
}
Console.WriteLine("\n");


//imprimir matriz
for (int i = 0; i < qtdLinhas; i++)
{
    for (int j = 0; j < qtdColunas; j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}

//copiar matriz inversa
Console.WriteLine();
for (int i = 0; i < qtdColunas; i++)
{
    for (int j = 0; j < qtdLinhas; j++)
    {
        matrizInversa[i, j] = matriz[j, i];
    }
}

//imprimir matriz inversa
for (int i = 0; i < qtdColunas; i++)
{
    for (int j = 0; j < qtdLinhas; j++)
    {
        Console.Write(matrizInversa[i, j] + " ");
    }
    Console.WriteLine();
}

