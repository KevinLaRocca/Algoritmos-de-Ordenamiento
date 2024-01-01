using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosCuadraticos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            int[] ejemplo = new int[] { 6, 2, 5, 9, 0, 3, 2, 9, 9 };
            SelectionSort(ejemplo);
            MostarElementos(ejemplo);
        }

        public static void BubbleSort(int[] elems)
        {
            for(int i = 0; i< elems.Length; i++)
            {
                for(int j = i+1; j< elems.Length; j++)
                {
                    if (elems[j]< elems[i])
                    {
                        int aux = elems[j];
                        elems[j] = elems[i];
                        elems[i] = aux;
                    }
                }
            }
        }
        //Funcionamiento: Comenzamos en el primer elemento y comenzamos desde 1 en adelante. Preguntamos si el pos 1 es menor que el pos 0(si lo es, swap). Vamos haciendo esto con todos los elementos, moviendome por todo el array n veces(n = cant elementos).
        //¿Cual es el problema del bubble sort? Que su complejidad es O(n^2), bastante alta. La ventaja fundamental es que es muy fácil de programar y de entender que hace.
        //¿Cuando usarlo? Cuando sabemos que tenemos una entrada acotada de elementos, algo así como <=1000.


        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        //Funcionalidad: Comenzamos desde la 2da posicion y vamos preguntando si "los anteriores son mayores al actual". Mientras esto pase, vamos moviendo esas posiciones en orden. Luego, al final, mandamos al elemento menor(actual) a su posicion original
        //¿Cual es el problema del Insertion Sort? Que su complejidad es O(n^2) también.
        //¿Cuando usarlo? Existen casos en donde el array está semi ordenado, es decir, tenemos un array que está ordenado por ciertos tramos, y en ciertos tramos está desordenado.
        //En estos casos el algoritmo tendrá O(n). Si nos aseguran que se cumple lo anterior, entonces está bueno usar este algoritmo.

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length- 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        //Funcionalidad: Busco el elemento minimo de la lista, lo intercambio con el primero. Luego hago lo mismo con el 2do... n veces(n tamaño vector)
        //Complejidad: O(n^2).
        //Cuando usarlo: No hay una situación en donde sea mejor que otro. La única mejora es que hace menos iteraciones que el método burbuja, pero en general tienen la misma complejidad algoritmica.
        public static void MostarElementos(int[] arr)
        {
            for(int i = 0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
