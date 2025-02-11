/*
    Toledo Herrera Neyzer Joel
    Martin Rojas Carlos Ariel
    Monarrez Barron Polo Alejandro
    11 de febrero de 2025
    4C
    Ejercicio 3 Juego de Reversi
*/
namespace polo;

class Program
{
    //Cambiar el color del texto a rojo
    //     Console.ForegroundColor = ConsoleColor.Red;
    //     Console.WriteLine("Texto en rojo");

    //Cambiar el color del texto a azul
    //     Console.ForegroundColor = ConsoleColor.Blue;
    //     Console.WriteLine("Texto en azul");

    //Restablecer el color del texto al color predeterminado
    //     Console.ResetColor();
    //     Console.WriteLine("Texto en color predeterminado");
    static void Main(string[] args)
    {

        ConsoleColor[] color = [
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan
        ];        
        
        int[] colorJugadores = new int[2];
        string[] nombres = new string[2];
        String[,] tablero = new string[8, 8];
        
        for (int i = 0; i < 2; i++) {
            Console.Write($"Ingresa el nombre del jugador {i+1}: ");
            nombres[i] = Console.ReadLine();
            
            Console.WriteLine($"{nombres[i]}, selecciona un color: ");
            PrintColors(color);
            Console.Write("> ");
            colorJugadores[i] = Int32.Parse(Console.ReadLine());
        }

        PrintTable();
        

    }

    static void PrintTable()
    {
        char[] letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
        for (int i = 0; i < 9; i++)
        {
            if(i!=0)
                Console.Write(i+1);

            for (int j = 0; j < 9; j++)
            {
                if(i==0)
                    Console.Write($" {letters[j-1]}");
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }   

    static void PrintColors(ConsoleColor[] colors)
    {
        int i = 1;
        foreach (ConsoleColor color in colors)
        {
            Console.Write($"{i}.");
            Console.ForegroundColor = color;
            Console.WriteLine(color);
            i++;
            Console.ResetColor();
        }
    }

    static void Coordinates(char posx, int posy, int initPosx, int initPosy)
    {
        int numPosx = posx - 64;

        Console.SetCursorPosition(numPosx+initPosx, posy+initPosy);

    }

    static void PrintFicha(ConsoleColor color, int jugador)
    {
        Console.ForegroundColor = color;
        if(jugador == 1)
            Console.Write("X");
        else
            Console.Write("O");
        Console.ResetColor();
    }

    static void CheckTable(string[,] table)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(
                    table[i,j] == null || 
                    table[i,j+1] == null || 
                    table[i,j+2] == null
                )
                    continue;
                
                string player = table[i,j];

                if(table[i,j+1] != player)
                    if(table[i,j+2] == player)
                        table[i,j+1] = null;
                        
                if(table[i+1,j] != player)
                    if(table[i+2,j] == player)
                        table[i+1,j] = null;

                
            }
        }
    }
    static void PedirCordenadas()
    {}


}
