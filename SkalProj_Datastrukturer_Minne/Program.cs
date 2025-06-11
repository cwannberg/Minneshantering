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
            Console.WriteLine(  "Skriv + följt av ordet du vill lägga till i listan. \n" +
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
                    foreach(var element in theList) 
                    {
                        Console.WriteLine(element);
                    }
                    break;
                default:
                    Console.WriteLine("Du måste ange + eller - som första tecken");
                    continueLoop = true;
                    break;
            } 
                
        }while(continueLoop);
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
            Console.WriteLine(  "** Välkommen till ICAs kösystem **\n" +
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
            Console.WriteLine(  "Skriv + följt av ordet du vill lägga till i listan \n" +
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

    public static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

        //Först en koll att vi har fått en giltig input från användaren
        string text = "";
        while (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Skriv in meningen vi ska kontrollera om paranteserna är rätt: ");
            text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Du måste skriva in något");
            }
        }

        //isValid. Om listan är tom när vi ska kontrollera en slutparantes, eller om slutparantesen och startparantesen inte matchar kommer isValid flaggas som false och då vet vi att texten inte är välformad.
        //containsParantheses. Vi vill kontrollera att texten som skrivs in faktiskt innehåller paranteser
        bool isValid = true;
        bool containsParantheses = false;
        var openP = new Stack<char>();

        //Vi kikar igenom alla char i användarens input-text. Om den aktuella char:en är en startparantes lägger vi till den i listan för startparanteser (openP).
        foreach(char c in text)
        {
            if (c.Equals('(') || c.Equals('{') || c.Equals('['))
            {
                openP.Push(c); 
                containsParantheses = true;
            }

            //Om char:en istället är en slutparantes kikar vi först på om vi har någon startparantes i openP. Har vi inte
            //det är listan inte välformad och vi hoppar ur loopen och sätter isValid-flaggan till false.
            //Om vi har något element i listan openP kikar vi på vad det är för ett tecken och tar sedan bort den.
            //Om det elementet inte har någon matchning i IsMatching-metoden är listan inte välformad och vi hoppar ur
            //loopen och sätter isValid-flaggan till false.

            else if (c.Equals(')') || c.Equals('}') || c.Equals(']'))
            {
                containsParantheses = true;
                if (openP.Count == 0)
                {
                    isValid = false;
                    break;
                }

                char charOnTopOfStack = openP.Pop();

                if (!IsMatching(c, charOnTopOfStack))
                {
                    isValid = false;
                    break;
                }
            }   
        }
        if (!containsParantheses)
        {
            Console.WriteLine("Inga paranteser hittades i texten.");
        }
        else if(isValid && openP.Count == 0)
        {
            Console.WriteLine("Texten är välformad.");
        }
        else
        {
            Console.WriteLine("Texten är inte välformad, parantserna matchar inte.");
        }
    }
    
    public static bool IsMatching(char open, char close)
    {
        return (open == ')' && close == '(') ||
               (open == ']' && close == '[') ||
               (open == '}' && close == '{');
    }
}

