public class GameController
{
    private Deck deck;
    private Table table;
    private string gameState;

    public GameController()
    {
        deck = new Deck();
        deck.shuffle();
        table = new Table(deck);
        gameState = "playing";
    }

    public void run()
    {
        while (gameState == "playing")
        {
            table.displayTable();

            Console.WriteLine($"Deck left: {deck.size()}");
            Console.WriteLine("Enter 2 indexes (sum 11) or 3 indexes (JQK/11,12,13). Type q to quit.");

            string? input = Console.ReadLine();
            
            if (input == null)
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

           if (input == "q" || input == "Q")
            {
                Console.WriteLine("Quitting game.");
                break;
            }

            submitSelection(input);
            checkEndState();
            if (gameState == "win")
            {
                Console.WriteLine("Congratulations! You win!");
            } 
            else if (gameState == "lose")
            {
                Console.WriteLine("No more moves available. You lose.");
            }
        }
    }


    public void submitSelection(string input)
    {
        string[] parts = input.Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> idx = new List<int>();

        foreach (string p in parts)
        {
            if (p.Length != 1 || p[0] < '0' || p[0] > '9')
            {
                Console.WriteLine("Invalid input.");
                return;
            }
        
        int n = p[0] - '0';
        idx.Add(n);
    }

        if (!validateSelection(idx))
        {
            Console.WriteLine("Invalid move.");
            return;
        }

        table.removeCards(idx);
        table.replaceCards(deck);

    }


    public bool validateSelection(List<int> idx)
    {
        if (idx.Count != 2 && idx.Count != 3)
        {
            Console.WriteLine("You must select 2 or 3 cards.");
            return false;
        }
            
        for (int i = 0; i < idx.Count; i++)
        {
            if (!table.isValidIndex(idx[i]))
            {
                return false;

            }
            
            for (int j = i + 1; j < idx.Count; j++)
                if (idx[i] == idx[j])
                    return false;
        }

        if (idx.Count == 2)
        {
            int a = table.getCard(idx[0]).getValue();
            int b = table.getCard(idx[1]).getValue();

            if (a > 10 || b > 10) return false;
            return a + b == 11;
        }

        bool hasJ = false;
        bool hasQ = false; 
        bool hasK = false;

        foreach (int i in idx)
        {
            int v = table.getCard(i).getValue();
            if (v == 11)
            {
                hasJ = true;
            } 
                
            else if (v == 12)
            {
                hasQ = true; 
            } 
            else if (v == 13)
            {
                hasK = true;
            } 
        }

        return hasJ && hasQ && hasK;
    }


    public void checkEndState()
    {
        if (table.isEmpty() && deck.isEmpty())
        {
            gameState = "win";
            return;
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                if (table.isValidIndex(i) && table.isValidIndex(j))
                {
                    int a = table.getCard(i).getValue();
                    int b = table.getCard(j).getValue();

                    if (a <= 10 && b <= 10 && a + b == 11)
                        return;
                }
            }
        }

        bool hasJ = false;
        bool hasQ = false;
        bool hasK = false;

        for (int i = 0; i < 9; i++)
        {
            if (table.isValidIndex(i))
            {
                int v = table.getCard(i).getValue();
                if (v == 11)
                    hasJ = true;
                else if (v == 12)
                    hasQ = true;
                else if (v == 13)
                    hasK = true;
            }
        }

        if (hasJ && hasQ && hasK)
            return;

        gameState = "lose";
    }
}