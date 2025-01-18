﻿using System;
namespace multiplication {
    class Program{
        static void Main(String[] args){
            Console.WriteLine("Residuo: " + Multiplication(6,1));
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
            if (b > 1){
                return a + Multiplication(a, b - 1);
            }

            /*
                2do caso base: Retorna el valor de 'a'.
            */
            return a;
        }
        
    }
}