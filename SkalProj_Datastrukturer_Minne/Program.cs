namespace SkalProj_Datastrukturer_Minne;

public class Program
{
    //Svar
    /*
     1. Stacken och heapen utgör minneshanteringen i C#. Stacken kan man jämföra med t.ex. en hög med tallrikar, den nyaste läggs högst upp i högen och det är även den högst upp i högen som kommer att plockas bort först.
        Varje "tallrik" tar upp plats i minnet.
        Heapen föreställer jag mig som en anslagstavla där man kan fästa upp lappar med nålar. Anslagstavlan är överskådlig och lappar kan nålas fast och plockas bort efter behov. Här lagras
        t.ex.objekt, klasser, strings. Dessa ligger kvar tills Garbage collectorn städar bort allt som inte refereras till längre.
        På stacken lagras t.ex. int, double, bool och referenser till objekt. Dessa värden finns kvar så länge metoden körs.
        
     
     2. Value types är datatyper som lagrar sitt eget värde direkt på stacken, de tar upp liten plats.
        Reference types är datatyper som har en pekare som ligger på stacken och pekar mot det lagrade utrymmet i heapen. En referenstyp kan ha flera "pekare" samtidigt. Finns det inga pekare kommer referenstypen
        att städas bort av garbage collectorn.

    3.  Det första exemplet returnerar 3 eftersom int:en är sparad som värdetyp. X och Y är två självständiga värdetyper som inte påverkas av varandra om den ena ändras.
        Det andra exemplet returnerar 4 eftersom int-värdena är sparade på samma plats på heapen. x och y är två olika "pekare" som pekar mot samma plats i minnet. så ändras y kommer också x att ändras.
        x och y refererar till samma plats i minnet.
     */

    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    public static void Main()
    {
       ConsoleUI.MainMenu();
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    public static void ExamineList()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */
        //Svar
        /* 
         2. Listans kapacitet ökar när vi har uppnått max kapacitet. T.ex. Har vi capacity på 4 kommer den öka vid 5 poster i listan.
         3. När listan skapas är dess kapacitet 0. När vi lägger till något i listan ökar den kapaciteten till 4. Sedan kommer listan att öka dynamiskt. Den fördubblas varje gång 
            gränsen överskrids:
            Antal i listan (Count)	    Kapacitet (Capacity)
            0                           0
            1	                        4
            5	                        8
            9	                        16
            17	                        32
            33	                        64
            ...                         ...
        4. Det som händer när listan blir full är att en ny, dubbelt så stor, lista skapas och elementen kopieras över dit, den gamla listan kommer städas bort av garbage collectorn.
           Detta kallas för att minne allokeras (plats reserveras) och för att slippa skapa en ny lista vid varje element som läggs till i listan fördubblas istället kapaciteten när
           maxkapaciteten har uppnåtts.
        5. Nej, kapaciteten minskar inte. Det är "dyrare" att skapa en ny lista med mindre kapacitet än att ha kvar den gamla. 
        6. När man vet redan innan hur mycket kapacitet man kommer att behöva använda. Ska jag ha en lista över månaderna på året behöver den aldrig hålla fler än 12 element. Den dynamiska
           ökningen skulle ha reserverat 16 platser åt oss.
         */

        bool continueLoop = true;
        List<string> theList = new();
        do
        {
            Console.WriteLine("Skriv + följt av ordet du vill lägga till i listan. \n" +
                                "Skriv - följt av ordet du vill ta bort en post från listan. \n" +
                                "Skriv 1 för att se listan. \n" +
                                "Skriv 0 för att avsluta.");

            string input;
            char nav = ' ';
            string value = " ";
            try
            {
                input = Console.ReadLine();
                nav = input[0];
                value = input.Substring(1);
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            //nav är första tecknet i stringen som användaren skrev i sin input. vi förväntar oss ett +, -, 1 eller 0. Om användaren har skrivit något annat 
            //kommer hen att få frågan igen tackvare default-alternativet.
            // 0 : Stänger ner applikationen
            // 1 : Visar listan
            // + : Lägger till ett element i listan
            // - : Tar bort ett element ur listan
            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"Listans count: {theList.Count} och capacity: {theList.Capacity}");
                    continueLoop = true;
                    break;

                case '-':
                    Console.WriteLine($"Listans count: {theList.Count} och capacity: {theList.Capacity}");
                    theList.Remove(value);
                    continueLoop = true;
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    foreach (var element in theList)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                default:
                    Console.WriteLine("Du måste ange + eller - som första tecken");
                    continueLoop = true;
                    break;
            }

        } while (continueLoop);
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    public static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
        bool continueLoop = true;
        Queue<string> theQueue = new();
        do
        {
            Console.WriteLine("** Välkommen till ICAs kösystem **\n" +
                                "Skriv + följt med kundens namn för att ställa en kund i kön\n" +
                                "Skriv - när en kund har blivit expedierad och lämnar kön\n" +
                                "Skriv 1 för att se listan. \n" +
                                "Skriv 0 för att avsluta.");

            //nav är första tecknet i stringen som användaren skrev i sin input. vi förväntar oss ett +, -, 1 eller 0. Om användaren har skrivit något annat 
            //kommer hen att få frågan igen tackvare default-alternativet.
            // 0 : Stänger ner applikationen
            // 1 : Visar listan
            // + : Lägger till ett element sist i listan
            // - : Tar bort det första elementet i listan

            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    //Här läggs ett element till i kön. Elementet kommer att läggas till sist i kön.
                    theQueue.Enqueue($"På plats {theQueue.Count() + 1}: står {value}");
                    continueLoop = true;
                    break;

                case '-':
                    //Här tas det första elementet i kön bort.
                    theQueue.Dequeue();
                    continueLoop = true;
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    foreach (var customer in theQueue)
                    {
                        Console.WriteLine(customer);
                    }
                    break;
                default:
                    Console.WriteLine("Du måste ange + eller - som första tecken");
                    continueLoop = true;
                    break;
            }

        } while (continueLoop);
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    public static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */
        //Svar:
        /*
         1. När vi använder .Pop() kommer det element senast blev tillagt att tas bort. 
            När vi har kört koden kommer Kalle och Olle stå kvar eftersom Greta fick gå istället 
            för Kalle, och Stina fick gå istället för Greta.             
         */
        bool continueLoop = true;
        Stack<string> theStack = new();
        do
        {
            Console.WriteLine("Skriv + följt av ordet du vill lägga till i listan \n" +
                                "Skriv - för att ta bort en post från listan. \n" +
                                "Skriv 1 för att se listan. \n" +
                                "Skriv 0 för att avsluta.");

            //nav är första tecknet i stringen som användaren skrev i sin input. vi förväntar oss ett +, -, 1 eller 0. Om användaren har skrivit något annat 
            //kommer hen att få frågan igen tackvare default-alternativet.
            // 0 : Stänger ner applikationen
            // 1 : Visar listan
            // + : Lägger till ett element i listan
            // - : Tar bort ett element ur listan

            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    theStack.Push(value);
                    continueLoop = true;
                    break;

                case '-':
                    theStack.Pop();
                    continueLoop = true;
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    foreach (var element in theStack)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                default:
                    Console.WriteLine("Du måste ange + eller - som första tecken");
                    continueLoop = true;
                    break;
            }

        } while (continueLoop);
    }

    public static void ReverseText()
    {
        Console.WriteLine("Skriv ett ord att vända på: ");
        string userInput = Console.ReadLine();

        Stack<char> textToBeReversed = new(userInput);
        string reversedString = new(textToBeReversed.ToArray());

        Console.WriteLine("Ordet i omvänd ordning: " + reversedString);
    }

    //    /*
    //     * Use this method to check if the paranthesis in a string is Correct or incorrect.
    //     * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
    //     * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
    //     */

    //Svar:
    //1. Jag valde att använda en stack eftersom jag då kan kika på det översta elementet och se om den matchar med char:en vi tittar på i foreachen.
    //   Jag hade föredragit att avända en Dictionary eftersom jag hade kunnat matcha ihop parantesterna istället för att skriva en lång if-sats
    public static void CheckParanthesis()
    {
        //Vi fortsätter fråga input från användaren i en evig loop (tills användaren stänger ner programmet)
        bool continueInput = true;
        bool isAMatch = false;
        bool textContainsParanthesis = false;
        do
        {
            Console.WriteLine("Skriv in en text för att se om den är välformad: ");
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Du måste skriva något. Försök igen");
            }
            else
            {
                Stack<char> startParanthesises = new();
                foreach (char c in userInput)
                {
                    if (c.Equals('(') || c.Equals('{') || c.Equals('['))
                    {
                        textContainsParanthesis = true;
                        startParanthesises.Push(c); //Om c är en öppningsparantes lägges den till i Stacken.
                    }
                    else if (c.Equals(')') || c.Equals('}') || c.Equals(']')) // Om c är en stängningsparantes kikar vi om vi har något i stacken. Har vi inte det är det ingen matchning.
                    {
                        textContainsParanthesis = true;
                        if (startParanthesises.Count == 0)
                        {
                            isAMatch = false;
                        }
                        else
                        {
                            char start = startParanthesises.Pop();
                            //Om öppningsparantesen och stängningsparantesen matchar är dessa två välmatchade och vi fortsätter loopen.
                            if (start.Equals('(') && c.Equals(')') ||
                                start.Equals('{') && c.Equals('}') ||
                                start.Equals('[') && c.Equals(']'))
                            {
                                isAMatch = true;
                            }
                            else
                            {
                                isAMatch = false; //Om inte öppning och stängning matchar är inte strängen välformad och vi går ur loopen
                                break;
                            }
                        }
                    }
                }
                if (textContainsParanthesis == false)
                {
                    Console.WriteLine("Texten innehåller inga paranteser. Försök igen");
                }
                else 
                { 
                    if (startParanthesises.Count == 0 && isAMatch)
                    {
                        Console.WriteLine("Texten är välformad");
                    }
                    else
                    {
                        Console.WriteLine("Texten är inte välformad");
                    }
                }
            }
        } while (continueInput);
    }
}

