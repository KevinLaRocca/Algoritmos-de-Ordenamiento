using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosNLogN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] example = { 9, -3, 2, 6, 1, 0, -6, -1, 0, 7, 2 };
            Console.WriteLine("Mostrar el array desordenado: ");
            mostrarElementos(example);

            Console.WriteLine("Mostrar el array ordenado: ");
            QuickSort(example, 0, example.Length - 1);
            mostrarElementos(example);

            int[] example2 = { 9, 2, 6, 1, -6, 1, 0, 6, 0, 7, -1, 0 };
            Console.WriteLine("Mostrar el array desordenado: ");
            mostrarElementos(example2);

            Console.WriteLine("Mostrar el array ordenado: ");
            MergeSortAlgorithm(example2, 0, example2.Length-1);
            mostrarElementos(example2);

        }

        static void QuickSort(int[] array, int izquierda, int derecha)
        {
            if (izquierda < derecha)//Mi caso base. Si llega a no cumplirse, se termina la recursión y ejecuta los quickSorts que faltan.
            {
                int indiceParticion = Particionar(array, izquierda, derecha);

                QuickSort(array, izquierda, indiceParticion - 1);//Hacemos recursión de quickSort pero con el array "a la mitad".
                QuickSort(array, indiceParticion + 1, derecha);//El primer llamado sub ordena el array, luego lo divide en 2 y sub ordena las sub divisiones. Repetir proceso hasta que no cumpla la condición.
            }
        }

        static int Particionar(int[] array, int izquierda, int derecha)
        {
            int pivote = array[derecha];//FUNDAMENTAL, de esto depende la complejidad de mi algortimo. DEPENDIENDO QUE PIVOTE TOME, tendrá una complejidad mayor o menor.
            int indiceMenor = izquierda - 1;//Inicializado afuera del array, o sea -1, por que aún no sabemos que elemento es el mínimo

            for (int indiceActual = izquierda; indiceActual < derecha; indiceActual++)
            {
                if (array[indiceActual] <= pivote)
                {
                    indiceMenor++;//Corremos el índice y nos vamos moviendo si el actual es menor que el pivote.
                    Intercambiar(array, indiceMenor, indiceActual);
                }
            }

            Intercambiar(array, indiceMenor + 1, derecha);//Hacemos el swap correspondiente: Por eso es que está sub ordenado, por cada llamado hacemos a lo sumo 1 swap.

            return indiceMenor + 1;//Este índice será lo que "divida" a mi array en 2.
        }

        static void Intercambiar(int[] array, int indice1, int indice2)
        {
            int temp = array[indice1];
            array[indice1] = array[indice2];
            array[indice2] = temp;
        }


        static void MergeSortAlgorithm(int[] arr, int left, int right)
        {
            if (left < right)//Muy similar a quickSort
            {
                // Encuentra el punto medio del arreglo
                int middle = left + (right - left) / 2;

                // Ordena la primera y segunda mitad
                MergeSortAlgorithm(arr, left, middle);
                MergeSortAlgorithm(arr, middle + 1, right);//Hasta acá lo mismo que quickSort, o muy similar.

                // Combina las mitades ordenadas
                Merge(arr, left, middle, right);
                //Lo nuevo, unir las dos partes que quedaron subdivididas. Recordemos que llegaremos a esto con 2 arrays de 1 elemento, luego 2 arrays de 2 etc etc.
            }
        }

        // Función para combinar dos subarreglos de arr[]
        static void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Crear arreglos temporales
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copiar datos a los arreglos temporales
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, middle + 1, rightArray, 0, n2);
            //Si quieren se podría hacer fors, pero son mas líneas para escribir lo mismo

            // Índices iniciales de los subarreglos izquierdo y derecho
            int i = 0, j = 0;

            // Índice inicial del subarreglo combinado
            int k = left;

            // Combina los arreglos temporales de nuevo en arr[left..right]
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Copia los elementos restantes de leftArray[], si los hay
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            // Copia los elementos restantes de rightArray[], si los hay
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        //COMENTARIOS: Ambos tienen costo O(nlogn). El quick sort puede llegar a tener O(n^2) si elegimos mal el pivote. En general, en la práctica, utilizamos el quicksort por que es mas sencillo de programar que el merge.
        //Cuando usarlo? Cuando no nos dan información sobre nuestros datos de entrada, queremos ordenarlos y buscamos el mejor caso posible(existen O(n), pero necesitamos información extra).
        static void mostrarElementos(int[] array)
        {
            foreach (var elemento in array)
            {
                Console.Write(elemento + " ");
            }
            Console.WriteLine();
        }
    }
}
