﻿using System;

namespace multiplication {
    class Program {
        static void Main(String[] args) {

            Console.Title = "MULTIPLICATION";

            long multiplicando;
            long multiplicador;
            string input;

            do {

                Console.Clear();

                Console.SetCursorPosition(14,0);
                Console.WriteLine("Welcome Back!");

                Console.SetCursorPosition(0,2);
                Console.WriteLine("Multiplicando x Multiplicador = Producto");

                Console.SetCursorPosition(11,3);
                Console.WriteLine("(Máximo 5 dígitos)\n");


                while(true) {

                    Console.Write("Ingresa el Multiplicando: ");
                    input = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(input)) {
                        Console.WriteLine("> Error: No se pueden ingresar espacios en blanco...\n");
                        continue;
                    }

                    if(long.TryParse(input, out multiplicando)) {

                        if(multiplicando >= 0 && multiplicando <= 99999) {
                            Console.WriteLine("> Valor ingresado correctamente\n");
                            break;
                        } else if(multiplicando > 99999) {
                            Console.WriteLine("> Error: Excediste los dígitos permitidos (máx. 5)...\n");
                        } else {
                            Console.WriteLine("> Error: El Multiplicando no puede ser negativo...\n");
                        }

                    } else if(input.All(char.IsDigit)) {
                        Console.WriteLine("> Error: Excediste los dígitos permitidos (máx. 5)...\n");
                    } else {
                        Console.WriteLine("> Error: No se permiten valores alfanuméricos...\n");
                    }

                }

                while(true) {

                    Console.Write("Ingresa el Multiplicador: ");
                    input = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(input)) {
                        Console.WriteLine("> Error: No se pueden ingresar espacios en blanco...\n");
                        continue;
                    }

                    if(long.TryParse(input, out multiplicador)) {

                        if(multiplicador >= 0 && multiplicador <= 99999) {
                            Console.WriteLine("> Valor ingresado correctamente\n");
                            break;
                        } else if(multiplicador > 99999) {
                            Console.WriteLine("> Error: Excediste los dígitos permitidos (máx. 5)...\n");
                        } else {
                            Console.WriteLine("> Error: El Multiplicador no puede ser negativo...\n");
                        }

                    } else if(input.All(char.IsDigit)) {
                        Console.WriteLine("> Error: Excediste los dígitos permitidos (máx. 5)...\n");
                    } else {
                        Console.WriteLine("> Error: No se permiten valores alfanuméricos...\n");
                    }

                }

                Console.WriteLine("Producto de "+ multiplicando + " x " + multiplicador + " = " + CalcularMultiplicacion(multiplicando, multiplicador) + "\n> Operacion realizada con exito");

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
                // 1er caso base: Si 'a' es igual a '0' o 'b' es igual a '0', entonces retorna '0'.
                // La multiplicación de cualquier número por cero es siempre cero.
                //
                // Ejemplos:
                // a = 0, b = 7 => Producto = 0
                // a = 7, b = 0 => Producto = 0
            */
            if(a == 0 || b == 0) {
                return 0;
            }
            /* 
                // Caso recursivo: Si 'b' es mayor a '1', entonces retorna 'a' más el resultado de llamar a 'CalcularMultiplicacion(a, b - 1)', de forma recursiva.
                //
                // Ejemplo:
                // Si a = 6 y b = 4:
                //
                // 1ra llamada:  6 + CalcularMultiplicacion(6, 4 - 1) // a = 6, b = 3
                // > ¿'b' es mayor a '1'? Si...
                //
                // 2da llamada: 12 + CalcularMultiplicacion(6, 3 - 1) // a = 6, b = 2
                // > ¿'b' es mayor a '1'? Si...
                //
                // 3ra llamada: 18 + CalcularMultiplicacion(6, 2 - 1) // a = 6, b = 1
                // > ¿'b' es mayor a '1'? No...
                //
                // Después de llegar al '2do caso base (b = 1)', el resultado se va acumulando hacia atrás, devolviendo el resultado final, que en este caso es '24'.
            */
            if (b > 1) {
                return a + CalcularMultiplicacion(a, b - 1);
            }
            /*
                // 2do caso base: Cuando 'b' es igual a '1', retorna el valor de 'a'.
                // Esto marca el fin de la recursión y empieza a devolver los resultados hacia arriba.
                //
                // Ejemplo:
                // 6 + 6 = 12
                // 12 + 6 = 18
                // 18 + 6 = 24
                //
                // Producto = 24
            */
            return a;

        }

    }
    
}