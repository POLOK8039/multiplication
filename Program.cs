﻿using System;
namespace multiplication {
    class Program {
        static void Main(String[] args) {

            do {
                try {
                    Console.Clear();
                    Console.WriteLine("Welcome back!");
                    Console.WriteLine("Multiplicacion de dos numeros");
                    Console.WriteLine("multiplicando x multiplicador = producto");

                    Console.WriteLine("Ingresa el multiplicando: ");
                    int a = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Ingresa el multiplicador: ");
                    int b = Int32.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Producto: " + Multiplication(a, b));
                }
                catch (FormatException) {
                    Console.WriteLine("Error: Por favor, ingresa un número válido.");
                }
                catch (OverflowException) {
                    Console.WriteLine("Error: El número ingresado es demasiado grande o demasiado pequeño.");
                }
                catch (Exception ex) {
                    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                }
            } while(Control() == true);

        }

        static Boolean Control() {
            Console.Write("¿Deseas continuar? (s/n): ");
            string respuesta = Console.ReadLine()?.ToLower();

            if(respuesta != "s" && respuesta != "n") {
                return Control();
            }

            if(respuesta == "n") {
                Console.Clear();
                Console.WriteLine("Goob Bye!");
                return false;
            }

            return true;
        }

        static int Multiplication(int a, int b) {
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
                return a + Multiplication(a, b - 1);
            }
            /*
                2do caso base: Retorna el valor de 'a'.
            */
            return a;
        }

    }
}
/*
    Los valores deben ser ingresados por teclado.
    Validar los valores ingresados por el usuario.
    Mostrar mensajes que hagan ilusion a lo que esta ocurriendo.
    El usuario puede elegir si continuar o no el proceso s/n.
    Solamente se pueden ingresar valores numericos.
    EL fonde debe ser blanco.
    Debe ejecutarse en la consola.
    Debe tener un titulo.
    Debe ser responsivo.
    No debe mostrar errores.
    El programa se va repetir cuantas veces lo requiera el usuario.
    El programa puede finalizar cuando el usario lo decida.
    Interfaz bonita.
*/