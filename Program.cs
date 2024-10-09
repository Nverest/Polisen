static class Program
{
    static List<Utryckning> NyUtryckning=new();
    static List<Personal> Konstapel=new();
    static void Main (string[] args)
    {
        Konstapel.Add(new Personal("Göran Eriksson", 1264));
        Konstapel.Add(new Personal("Kalle Karlsson", 1265));
        Konstapel.Add(new Personal("Sven Svensson", 1266));
        Konstapel.Add(new Personal("Bengt Bengtsson", 1267));
        NyUtryckning.Add(new Utryckning("Rån","Göteborg","Kungsgatan",DateTime.Parse("2021-10-10 12:00"),new List<Personal>{Konstapel[0],Konstapel[1]}));
        NyUtryckning.Add(new Utryckning("Kollision","Göteborg","Kungsgatan",DateTime.Parse("2021-10-10 12:00"),new List<Personal>{Konstapel[0],Konstapel[1]}));
        NyUtryckning.Add(new Utryckning("Rån","Växjö","Centrum",DateTime.Parse("2023-02-15 16:10"),new List<Personal>{Konstapel[0],Konstapel[3]}));
        NyUtryckning.Add(new Utryckning("Mord","Stockholm","Drottninggatan",DateTime.Parse("2021-10-11 01:00"),new List<Personal>{Konstapel[2],Konstapel[3], Konstapel[0]}));

        PrintMenu();
    }
    //Print metod för meny
    static void PrintMenu()
    {
        bool running=true;
        while (running)
        {

            Console.WriteLine("=============Rapportsystem=============");
            Console.Write("[1]Registrera Utryckning\n");
            Console.Write("[2]Registrera Rapport\n");
            Console.Write("[3]Lägg till Personal\n");
            Console.Write("[4]Visa Personal\n");
            Console.Write("[5]Sammanställning av rapport\n");
            Console.Write("[6]Avsluta\n");
            string input=Console.ReadLine();
            switch(input)
            {
            case "1":
                AddUtryckning();
        // Console.Clear();
            break;
            case "2":
                AddRapport();
            break;
            case "3":
               AddPersonal();
            break;
            case "4":
                PrintPersonal();
            break;
            case "5":
                PrintRapport();
            break;
            case "6":
                Environment.Exit(0);
            break;
            default:
                Console.WriteLine("Fel inmatning");
            break;
            }
        }
    }
    public static void AddUtryckning()
    {
        Console.Clear();
        Console.WriteLine("Lägg till ny Utryckning\n=======================");
        Console.Write("Skriv in Händelsetyp: ");
        string händelsetyp=Console.ReadLine();
        Console.Write("Skriv in Stad: ");
        string stad=Console.ReadLine();
        Console.Write("Skriv in Plats: ");
        string plats=Console.ReadLine();
        Console.Write("Skriv in Datum & Tid: ");
        //string input = Console.ReadLine();
        DateTime tidpunkt= DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Hur många poliser var på plats?");
        int antal=int.Parse(Console.ReadLine());
        while(antal>Konstapel.Count)
        {
            Console.WriteLine("Det finns ej så många Poliser");
            antal=int.Parse(Console.ReadLine());
        }
            PrintPersonal();
            Console.WriteLine("Skriv in Polis på plats (ange Indexnr): ");
            List<int> Antal=new();
            for(int i=0;i<antal;i++)
            {
            Console.Write("Index: ");
            int index=int.Parse(Console.ReadLine())-1;
            while(Antal.Contains(index))
            {
                Console.WriteLine("Du har redan valt denna");
                Console.Write("Index: ");
                index=int.Parse(Console.ReadLine())-1;
            }
            
            Antal.Add(index);
            }
            List<Personal>PolisPåplats=new();
            foreach(int index in Antal)
            {
            PolisPåplats.Add(Konstapel[index]);
            }
            NyUtryckning.Add(new Utryckning(händelsetyp,stad,plats,tidpunkt,PolisPåplats));
            Console.Clear();
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Ny Utryckning tillagd");
            Console.ResetColor();
            PrintMenu();       
        
    }
    //Metod för att lägga till personal
    public static void AddPersonal()
    {
        Console.Clear();
        Console.Write("Skriv in För och efternamn: ");
        string namn=Console.ReadLine();
        
        Console.Write("Ange Tjänstenummer: ");
        int tjänstNR=int.Parse(Console.ReadLine());
        while(Konstapel.Any(p => p.tjänstNR==tjänstNR))
        {
            
            Console.BackgroundColor=ConsoleColor.Red;
            Console.WriteLine("Tjänstenummer finns redan");
            Console.ResetColor();
            tjänstNR=int.Parse(Console.ReadLine());
            
        }
        
            Console.Clear();
            Konstapel.Add(new Personal(namn, tjänstNR));
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Ny personal tillagd");
            Console.ResetColor();
        
    }
    //Metod för att lägga till Rapporten i utryckningen
    public static void AddRapport()
    {
        Console.Clear();
        Console.WriteLine("[1]Välj utryckning:");
        PrintUtryckning();
        int index=int.Parse(Console.ReadLine());
        Console.Write("Skriv in en Beskrivning för utryckningen:");
        string rapport = Console.ReadLine();
        NyUtryckning[index].rapport=rapport;
        Console.Clear();
        Console.BackgroundColor= ConsoleColor.Green;
        Console.WriteLine("Ny Rapport tillagd");
        Console.ResetColor();
       
    }
    //Printmetod för personalen
    public static void PrintPersonal()
    {
        Console.Clear();
        for(int i=0;i<Konstapel.Count;i++)
        {
            Console.WriteLine($"[{i+1}]Konstapel:{Konstapel[i].namn}||ID Nummer:{Konstapel[i].tjänstNR}");
        }
        
    }
    //Printmetod för utryckning
    public static void PrintUtryckning()
    {
        //foreach(var utryckning in NyUtryckning)
        //{
            Console.Clear();
            for (int i=0;i<NyUtryckning.Count;i++)
            {
                Console.ForegroundColor=ConsoleColor.DarkYellow;
                Console.WriteLine($"[{i}]");
                Console.ResetColor();
                Console.WriteLine($"||{NyUtryckning[i].händelsetyp}||Station {NyUtryckning[i].stad}||{NyUtryckning[i].tidpunkt}||{NyUtryckning[i].rapport}");
                Console.WriteLine("   ===Polis på Plats===");
                for (int p=0;p<NyUtryckning[i].PolisPåplats.Count;p++)
                {
                    Console.WriteLine($"||{NyUtryckning[i].PolisPåplats[p].namn} || {NyUtryckning[i].PolisPåplats[p].tjänstNR}");
                }
            }
        //}
    }
    //Printmetod för rapporten med utryckning & station etc.
    public static void PrintRapport()
    {
        Console.Clear();
        Console.WriteLine("================Rapporter================");
        for (int i=0;i<NyUtryckning.Count;i++)
            {
                Console.WriteLine("=======================================1");
                Console.WriteLine($"Den {NyUtryckning[i].tidpunkt} skedde det en utryckning för {NyUtryckning[i].händelsetyp} i {NyUtryckning[i].stad}\nBeskrivningen av händelsen:{NyUtryckning[i].rapport}");
                Console.WriteLine($"Utryckande Personal från Station: {NyUtryckning[i].stad}\t");
                // Console.WriteLine("|");
                Console.WriteLine("Polis som kom till platsen var följande:");
                for (int j=0;j<NyUtryckning[i].PolisPåplats.Count;j++)
                {
                    Console.WriteLine($"{NyUtryckning[i].PolisPåplats[j].namn} || {NyUtryckning[i].PolisPåplats[j].tjänstNR}");
                    
                }
            }
        Console.WriteLine("==============Rapporter Slut===============");
    }
}
