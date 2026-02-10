

public class Deck
{
    private List<Card> cards = new List<Card>();
    
    public Deck ()
    {
        for (int i=0; i<Card.Suits.Length; i++)
        {
            for (int j=0; j<Card.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i], Card.Values[j]));
            }
        }
    }

    //Shuffle the deck
    public void shuffle()
    {
        Random rand = new Random();
        for (int i=0; i< cards.Count; i++)
        {
            int j = rand.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card deal()
    {
        Card top = cards[0];
        cards.RemoveAt(0);
        return top;
    }

     public bool isEmpty()
    {
        return cards.Count == 0;
    }

    public int size()
    {
        return cards.Count;
    }
}