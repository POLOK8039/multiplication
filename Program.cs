﻿using System;

namespace multiplication {
    class Program {
        static void Main(String[] args) {

            Console.Title = "Multiplication";

            int multiplicando;
            int multiplicador;

            do {
            Console.Clear();
            Console.WriteLine("Welcome back!");
            Console.WriteLine("multiplicando x multiplicador = producto");


                while(true) {
                    Console.WriteLine("Ingresa el multiplicando: ");

                    if(int.TryParse(Console.ReadLine(), out multiplicando)) {
                        break;
                    } else {
                        Console.WriteLine("Error: valor invalido...");
                    }
                }

                while(true) {
                    Console.WriteLine("Ingresa el multiplicador: ");
                    if(int.TryParse(Console.ReadLine(), out multiplicador)) {
                        if(multiplicador >= 0) {
                            break;
                        } else {
                            Console.WriteLine("El multiplicador no puede ser negativo...");
                        }
                    } else {
                        Console.WriteLine("Error: valor invalido...");
                    }
                }

                Console.WriteLine("Producto: " + CalcularMultiplicacion(multiplicando, multiplicador));

            } while(ContinuarOperacion() == true);
        }

        static Boolean ContinuarOperacion() {
            while(true) {
                Console.Write("¿Deseas continuar? (S/n): ");
                string respuestaSn = Console.ReadLine()?.ToLower();
                
                if(respuestaSn != "s" && respuestaSn != "n") {
                    continue;
                }

                if(respuestaSn == "n") {
                    return false;
                }

                return true;
            }
        }

        static int CalcularMultiplicacion(int a, int b) {
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
                mas el metodo Multiplicacion('a', 'b' menos '1').

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