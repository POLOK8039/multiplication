/* Datos del equipo...
    Ejercicio 3 Juego de Reversi.
    Grupo: 4C.
    Fecha: 11 de febrero de 2025.
    Integrantes:
        - Toledo Herrera, Neyzer Joel.
        - Martin Rojas, Carlos Ariel.
        - Monarrez Barron, Polo Alejandro.
*/

using System;

namespace polo;
class Program {
    static void Main(string[] args) {

        /*
            Si les esto ney, falta agregar una que otra validdacion
        */

        ConsoleColor[] colors = [
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan
        ];
        
        int[] colorJugadores = new int[2];
        string[] nombres = new string[2];
        string[,] tablero = new string[8, 8];
        
        for (int i = 0; i < 2; i++) {
            Console.Write($"Ingresa el nombre del jugador {i + 1}: ");
            nombres[i] = Console.ReadLine();
            Console.WriteLine($"{nombres[i]}, selecciona un color: ");
            PrintColors(colors);
            Console.Write("> ");
            colorJugadores[i] = Int32.Parse(Console.ReadLine()) + 1;
        }

        InicializarTablero(tablero);

        bool juegoTerminado = false;
        int jugadorActual = 0;

        while (!juegoTerminado) {
            PrintTable(tablero, colors, colorJugadores);
            Console.WriteLine($"Turno de {nombres[jugadorActual]} ({(jugadorActual == 0 ? "X" : "O")})");

            if(HayMovimientosDisponibles(tablero, jugadorActual + 1)) {
                PedirCoordenadas(tablero, jugadorActual + 1, colors, colorJugadores);
                jugadorActual = (jugadorActual + 1) % 2;
                /*
                    Intente hacer (jugadorActual + 1) - 1; pero al chile no se porque jalo.
                    El deep me dio esa solucion.
                */                                                  
            } else {
                if (!HayMovimientosDisponibles(tablero, 1) && !HayMovimientosDisponibles(tablero, 2)) {
                    juegoTerminado = true;
                } else {
                    Console.WriteLine($"{nombres[jugadorActual]} no tiene movimientos disponibles... El turno pasa al siguiente jugador.");
                    jugadorActual = (jugadorActual + 1) % 2;
                }
            }
        }

        PrintTable(tablero, colors, colorJugadores);
        int fichasJugador1 = ContarFichas(tablero, 1);
        int fichasJugador2 = ContarFichas(tablero, 2);

        Console.WriteLine($"Fin del juego! {nombres[0]}: {fichasJugador1} fichas, {nombres[1]}: {fichasJugador2} fichas.");
        if (fichasJugador1 > fichasJugador2)
        {
            Console.WriteLine($"{nombres[0]} gana!");
        }
        else if (fichasJugador2 > fichasJugador1)
        {
            Console.WriteLine($"{nombres[1]} gana!");
        }
        else
        {
            Console.WriteLine("Empate!");
        }
    }

    /* E S T O  Y A  V A  J A L A N D O  B I E N */
    static void InicializarTablero(string[,] tablero) {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                tablero[i, j] = "-";
            }
        }
        tablero[3, 3] = "X";
        tablero[3, 4] = "O";
        tablero[4, 3] = "O";
        tablero[4, 4] = "X";
    }
    static void PrintTable(string[,] tablero, ConsoleColor[] colors, int[] colorJugadores) {
        // char[] letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int i = 0; i < 8; i++) {
            Console.Write(i + " ");
            for (int j = 0; j < 8; j++) {
                if (tablero[i, j] == "X") {
                    Console.ForegroundColor = colors[colorJugadores[0]];
                    Console.Write(tablero[i, j] + " ");
                    Console.ResetColor();
                } else if (tablero[i, j] == "O") {
                    Console.ForegroundColor = colors[colorJugadores[1]];
                    Console.Write(tablero[i, j] + " ");
                    Console.ResetColor();
                } else {
                    Console.Write(tablero[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
    /* E S T O  Y A  V A  J A L A N D O  B I E N */

    /* R E V I S A R */
    static void PrintColors(ConsoleColor[] colors) {
        int i = 1;
        foreach (ConsoleColor color in colors) {
            Console.Write($"{i}.");
            Console.ForegroundColor = color;
            Console.WriteLine(color);
            i++;
            Console.ResetColor();
        }
    }
    static void PedirCoordenadas(string[,] tablero, int jugador, ConsoleColor[] colors, int[] colorJugadores) {
        Console.Write("Ingrese la fila (0-7): ");
        int fila = int.Parse(Console.ReadLine());
        Console.Write("Ingrese la columna (0-7): ");
        int columna = int.Parse(Console.ReadLine());
        /*
            Validar si el movimiento es valido que coloque la ficha si
            no que mande un mensaje de movimiento invalido
        */
        if (EsMovimientoValido(tablero, fila, columna, jugador)) {// Validar si el movimiento es valido que coloque la ficha
            ColocarFicha(tablero, fila, columna, jugador, colors, colorJugadores);
        } else {
            /*
                Si no es verdadero que mande un mensaje de movimiento invalido
                y pida nuevamente las cordenadas.
            */
            Console.WriteLine("Movimiento inválido... Intente nuevamente.");
            PedirCoordenadas(tablero, jugador, colors, colorJugadores);
        }
    }
    static bool EsMovimientoValido(string[,] tablero, int fila, int columna, int jugador) {
        //Condiciones
        //Casilla vacia o con un "-"
        if(tablero[fila,columna] != "-") {
            return false;
        }
        return true; // Aqui debe ser false, lo deje true para hacer pruebas
    }
    static void ColocarFicha(string[,] tablero, int fila, int columna, int jugador, ConsoleColor[] colors, int[] colorJugadores) {
        // Logica
    }
    static bool HayMovimientosDisponibles(string[,] tablero, int jugador) {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
               if (EsMovimientoValido(tablero, i, j, jugador)) {
                return true;
               }
            }
        }
        return false;
    }
    static int ContarFichas(string[,] tablero, int jugador) {
        int contador = 0;
        string fichaJugador = jugador == 1 ? "X" : "O";
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (tablero[i, j] == fichaJugador) {
                    contador++;
                }
            }
        }
        return contador;
    }
    /* R E V I S A R */

    /* P E N D I E N T E */
    // static void Coordinates(char posx, int posy, int initPosx, int initPosy)
    // {
    //     int numPosx = posx - 64;

    //     Console.SetCursorPosition(numPosx+initPosx, posy+initPosy);

    // }

    // static void PrintFicha(ConsoleColor color, int jugador)
    // {
    //     Console.ForegroundColor = color;
    //     if(jugador == 1)
    //         Console.Write("X");
    //     else
    //         Console.Write("O");
    //     Console.ResetColor();
    // }

    // static void CheckTable(string[,] table)
    // {
    //     for (int i = 0; i < 8; i++)
    //     {
    //         for (int j = 0; j < 8; j++)
    //         {
    //             if(
    //                 table[i,j] == null || 
    //                 table[i,j+1] == null || 
    //                 table[i,j+2] == null
    //             )
    //                 continue;

    //             string player = table[i,j];

    //             if(table[i,j+1] != player)
    //                 if(table[i,j+2] == player)
    //                     table[i,j+1] = null;
     
    //             if(table[i+1,j] != player)
    //                 if(table[i+2,j] == player)
    //                     table[i+1,j] = null;
    //         }
    //     }
    // }
    /* P E N D I E N T E */

}
