static void ShowCard(int cartNamber)
{
    switch (cartNamber)
    {
        case 13:
            Console.WriteLine($"{cartNamber}, King");
            break;
        
        case 12:
            Console.WriteLine($"{cartNamber}, Queen");
            break;

        case 11:
            Console.WriteLine($"{cartNamber}, Jack");
            break;
        
    }
}



for (int i = 0; i < 10; i++)
{
    Random rand = new Random();
    int card = rand.Next(11, 13);
    ShowCard(card);
}




