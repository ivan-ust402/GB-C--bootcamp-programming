int[] array = new int[5];
for (int i = 0; i < 5; i++) {
    array[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine(string.Join(" ", array));