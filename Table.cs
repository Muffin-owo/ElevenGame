public class Table
{
    private List<Card> cardsOnTable = new List<Card>();

    public Table(Deck deck)
    {
        for (int i=0; i<9; i++)
        {   
            cardsOnTable.Add(deck.deal());
        }
    }
    
    public void displayTable()
    {
        Console.WriteLine("Table:");
        for (int i = 0; i < cardsOnTable.Count; i++)
        {
            Console.WriteLine($"{i}: {cardsOnTable[i]}");
        }
    }

    public Card getCard(int i)
    {
        return cardsOnTable[i];
    }

     public bool isValidIndex(int index)
    {
        return index >= 0 && index < cardsOnTable.Count;
    }

  public void removeCards(List<int> index)
    {
        index.Sort();    
        index.Reverse();  

        foreach (int i in index)
        {
            cardsOnTable.RemoveAt(i);
        }
    }

        public void replaceCards(Deck deck)
    {
        while (cardsOnTable.Count < 9 && !deck.isEmpty())
        {
            cardsOnTable.Add(deck.deal());
        }
    }

    public bool isEmpty()
    {
        return cardsOnTable.Count == 0;
    }
}



