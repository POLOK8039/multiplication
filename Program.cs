﻿using System;

namespace multiplication {
    class Program {
        static void Main(String[] args) {

            Console.Title = "Multiplication";
            string a;
            long multiplicando;
            long multiplicador;

            do {
            Console.Clear();

            Console.SetCursorPosition(14,0);
            Console.WriteLine("Welcome back!");

            Console.SetCursorPosition(0,2);
            Console.WriteLine("multiplicando x multiplicador = producto");

            Console.SetCursorPosition(11,3);
            Console.WriteLine("(Maximo 5 digitos)\n");

                while(true) {
                    Console.Write("Ingresa el multiplicando: ");

                    if(long.TryParse(a = Console.ReadLine(), out multiplicando) && multiplicando <= 99999) {
                        if(multiplicando >= 0) {
                            Console.WriteLine("> Valor ingresado correctamente\n");
                            break;
                        } else {
                            Console.WriteLine("> El multiplicando no puede ser negativo...\n");
                        }
                    } else {
                        Console.WriteLine("> Error: Valor invalido...\n");
                    }

                    if(multiplicando > 99999 || a.Length > 5) {
                        Console.WriteLine("> Error: Exediste los digitos permitidos (max 5)...\n");
                    }
                    if(a.Length == 0){
                        Console.WriteLine("Error: No se pueden ingresar espacios en blanco...\n");
                    }
                }

                while(true) {
                    Console.Write("Ingresa el multiplicador: ");

                    if(long.TryParse(a = Console.ReadLine(), out multiplicador) && multiplicador <= 99999) {
                        if(multiplicador >= 0) {
                            Console.WriteLine("> Valor ingresado correctamente\n");
                            break;
                        } else {
                            Console.WriteLine("> El multiplicador no puede ser negativo...\n");
                        }
                    } else {
                        Console.WriteLine("> Error: Valor invalido...\n");
                    }

                    if(multiplicador > 99999 || a.Length > 5) {
                        Console.WriteLine("> Error: Exediste los digitos permitidos (max 5)...\n");
                    }
                    if(a.Length == 0){
                        Console.WriteLine("Error: No se pueden ingresar espacios en blanco...\n");
                    }
                }

                Console.WriteLine("Producto: " + CalcularMultiplicacion(multiplicando, multiplicador));

            } while(ContinuarOperacion() == true);
        }

        static Boolean ContinuarOperacion() {
            while(true) {
                Console.Write("\n¿Deseas continuar? (S/n): ");
                string respuestaSn = Console.ReadLine()?.ToLower();
                
                if(respuestaSn != "s" && respuestaSn != "n") {
                    continue;
                }

                if(respuestaSn == "n") {
                    Console.Clear();
                    Console.WriteLine("Good bye!");
                    return false;
                }

                return true;
            }
        }

        static long CalcularMultiplicacion(long a, long b) {
            /*
                1er caso base: Si 'a' es igual a '0' o 'b' es igual
                a '0' entonces retorna '0'.

                Ejemplo:

                a = 0;
                b = 7;

                a = 7;
                b = 0;

                Resultado = '0'.
            */
            if(a == 0 || b == 0) {
                return 0;
            }
            /* 
                Caso recursivo: Si 'b' es mayor a '1' entonces retorna 'a'
                mas el metodo CalcularMultiplicacion('a', 'b' menos '1').

                Ejemplo:

                a = 6; 
                b = 4;

                Recursiones:

                1er.  6 + (6, 4 - 1): a = 12; b = 3;
                ¿'b' es mayor a '1'? Si...

                2do. 12 + (6, 3 - 1): a = 16; b = 2;
                ¿'b' es mayor a '1'? Si...

                3er. 16 + (6, 2 - 1): a = 24; b = 1;
                ¿'b' es mayor a '1'? No...

                Entonces retornara el 2do caso base.

                Resultado = '24'.

            */
            if (b > 1) {
                return a + CalcularMultiplicacion(a, b - 1);
            }
            /*
                2do caso base: Retorna el valor de 'a'.
            */
            return a;
        }

    }
}