using System.Security.Cryptography;

int qtdLinhas;
int qtdColunas;

Console.Write("insira a quantidade de linhas: ");
qtdLinhas = int.Parse(Console.ReadLine());

Console.Write("insira a quantidade de colunas: ");
qtdColunas = int.Parse(Console.ReadLine());

int[,] matriz = new int[qtdLinhas, qtdColunas];

for(int i = 0; i < qtdLinhas; i++)
{
    for (int j = 0; j < qtdColunas; j++)
    {
        matriz[i, j] = RandomNumberGenerator.GetInt32(1, 9);
        Console.Write(matriz[i,j] + " ");
    }
}
Console.WriteLine("\n");

for (int i = 0; i < qtdLinhas; i++)
{
    for (int j = 0; j < qtdColunas; j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine();
for (int i = 0; i < qtdColunas; i++)
{
    for (int j = 0; j < qtdLinhas; j++)
    {
        Console.Write(matriz[j, i] + " ");
    }
    Console.WriteLine();
}