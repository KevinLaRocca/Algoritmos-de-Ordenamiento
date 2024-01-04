using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosLineales
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = { 4, 2, 5, 1, 3 };
            Console.WriteLine("Arreglo original:");
            PrintArray(arr);

            CountingSortAlgorithm(arr);

            Console.WriteLine("\nArreglo ordenado:");
            PrintArray(arr);

        }
        /*COUNTING SORT
        Se basa en crear un array de "m" elementos, donde m será el maximo elemento de la lista que querramos ordenar.
        Luego, iremos iterando sobre la lista que queremos ordenar y por cada número que haya, sumaremos ++ en la posición del mismo número en nuestro array creado anteriormente
        Ej: si tengo el número 4, entonces mi array en la posición 4 ahora aumentará en 1.
        Complejidad: O(n+k). n es el tamaño del array a ordenar y k es el tamaño de array que creamos(el array count).
        Esto es -> si n > k = O(n), si k > n = O(k), si k=n = O(2k o 2n) = O(k) u O(n).*/
        static void CountingSortAlgorithm(int[] arr)
        {
            
            int[] output = new int[arr.Length];

            // Encuentra el valor máximo en el arreglo
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            // Crea un arreglo de conteo para almacenar las ocurrencias de cada elemento
            int[] count = new int[max + 1];

            // Incrementa el conteo para cada elemento en el arreglo original
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }

            // Actualiza el conteo acumulado
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }

            // Construye el arreglo de salida
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;
            }

            // Copia el arreglo ordenado de vuelta al arreglo original
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }


        /*RADIX SORT
          Este algoritmo se basa en ordenar los números dependiendo de las unidades, decenas, centenas etc.
          Vamos chequeando desde el dígito menos significativo hasta el dígito mas significativo.
          Complejidad: O(d*(n+k). d será el tamaño del número mas grande, n el tamaño del array y k será la base del sistema númerico que usaremos.
          Este algoritmo será lineal siempre y cuando k esté acotado(supongamos 10 por que es nuestro sistema númerico) y también estén acotados los números que tenemos que ordenar(siendo d un valor mucho menor que n)
          Si d == n -> n*n = O(n^2). Todo depende del dato de entrada.*/


        static int GetMax(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }


        static void CountSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10]; // Solo hay 10 dígitos posibles

            // Inicializa el arreglo de conteo
            for (int i = 0; i < 10; i++)
            {
                count[i] = 0;
            }

            // Almacena la cantidad de ocurrencias de cada dígito en el arreglo de conteo
            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            // Actualiza el conteo acumulado
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Construye el arreglo de salida
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copia el arreglo ordenado de vuelta al arreglo original
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        static void RadixSortAlgorithm(int[] arr, int n)
        {
            int max = GetMax(arr, n);

            // Realiza el conteo y la suma acumulativa para cada dígito
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(arr, n, exp);
            }
        }

        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
