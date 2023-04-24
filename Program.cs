using System.Xml.Serialization;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static void Main(string[] args)
{
    int[] arr = { 3, 5, 1, 7, 4, 9, 8, 6, 2 };
    MergeSort(arr);
    Console.WriteLine(string.Join(",", arr));
}