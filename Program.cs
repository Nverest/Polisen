using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography;

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
            Console.Write("Skriv in Händelsetyp: ");
            string händelsetyp=Console.ReadLine();
            Console.Write("Skriv in Stad: ");
            string stad=Console.ReadLine();
            Console.Write("Skriv in Plats: ");
            string plats=Console.ReadLine();
            Console.Write("Skriv in Datum & Tid: ");
            DateTime tidpunkt= DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Skriv in Polis på plats (ange Indexnr): ");
            PrintPersonal();
            Console.Write("Index: ");
            int index=int.Parse(Console.ReadLine());
            
            List<Personal>PolisPåplats=new();
            //PolisPåplats.Add(Konstapel[index]);
            NyUtryckning.Add(new Utryckning(händelsetyp,stad,plats,tidpunkt,PolisPåplats));
            Console.Clear();
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Ny Utryckning tillagd");
            Console.ResetColor();
            PrintMenu();       
    }
    public static void AddPersonal()
    {
        Console.Write("Skriv in För och efternamn: ");
        string namn=Console.ReadLine();
        
        Console.Write("Ange Tjänstenummer: ");
        int tjänstNR=int.Parse(Console.ReadLine());
        if(Konstapel.Any(p => p.tjänstNR==tjänstNR))
        {
            Console.BackgroundColor=ConsoleColor.Red;
            Console.WriteLine("Tjänstenummer finns redan");
            Console.ResetColor();
            AddPersonal();
        }
        else
        {
            Console.Clear();
            Konstapel.Add(new Personal(namn, tjänstNR));
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Ny personal tillagd");
            Console.ResetColor();
        }
    }
    public static void AddRapport()
    {
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
    public static void PrintPersonal()
    {
        for(int i=0;i<Konstapel.Count;i++)
        {
            Console.WriteLine($"[{i}]Konstapel:{Konstapel[i].namn}||ID Nummer:{Konstapel[i].tjänstNR}");
        }
        
    }
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
    public static void PrintRapport()
    {
        Console.Clear();
        Console.WriteLine("================Rapporter================");
        for (int i=0;i<NyUtryckning.Count;i++)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Den {NyUtryckning[i].tidpunkt} skedde det en utryckning för {NyUtryckning[i].händelsetyp} i {NyUtryckning[i].stad}\nBeskrivningen av händelsen:{NyUtryckning[i].rapport}");
                Console.WriteLine($"Utryckande Personal från Station: {NyUtryckning[i].stad}");
                Console.WriteLine("|");
                Console.WriteLine("Polis som kom till platsen var följande:");
                for (int j=0;j<NyUtryckning[i].PolisPåplats.Count;j++)
                {
                    Console.WriteLine($"{NyUtryckning[i].PolisPåplats[j].namn}||{NyUtryckning[i].PolisPåplats[j].tjänstNR}");
                    
                }
            }
        Console.WriteLine("==============Rapporter Slut===============");
    }
}
public class Utryckning
{
    public string händelsetyp;
    public string stad;
    public string plats;
    public DateTime tidpunkt;
    public string rapport;
    public List<Personal>PolisPåplats;

    public Utryckning(string händelsetyp,string stad, string plats, DateTime tidpunkt,List<Personal>PolisPåplats)
    {
        this.händelsetyp=händelsetyp;
        this.stad=stad;
        this.plats=plats;
        this.tidpunkt=tidpunkt;
        this.PolisPåplats=PolisPåplats;

    }
}
public class Personal
{
    public string namn;
    public int tjänstNR;

    public Personal(string namn, int tjänstNR)
    {
        this.namn=namn;
        this.tjänstNR=tjänstNR;
    }
}
