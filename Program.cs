using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

static class Program
{
    static List<Utryckning> Nyutryckning =new();
    static List<Personal> AllPolis=new();
   
    static void Main (string[] args)
    {
        AllPolis.Add(new Personal("Henrik Svensson",1634));
        AllPolis.Add(new Personal("Adam Karlsson",1840));
        AllPolis.Add(new Personal("Lena Svensson",1337));
        AllPolis.Add(new Personal("Kurt Melander",1001));
        Nyutryckning.Add(new Utryckning("Rån", "Hagaborgsgatan", new DateTime(2024,12,06,14,30,00),AllPolis.GetRange(0,2)));
        Nyutryckning.Add(new Utryckning("Mord", "Jungfrugatan", new DateTime(2024,05,23,22,04,00),AllPolis.GetRange(1,3)));
        Nyutryckning.Add(new Utryckning("Inbrott", "Alfabetsvägen", new DateTime(2023,08,16,01,34,00),AllPolis.GetRange(1,3)));
        Nyutryckning.Add(new Utryckning("Krock", "Väg 27, Hagamotet", new DateTime(2023,10,09,17,54,00),AllPolis.GetRange(3,1)));
        Nyutryckning.Add(new Utryckning("Rån", "Fabriksområde 2", new DateTime(2024,01,12,06,17,00),AllPolis.GetRange(0,2)));

       addUtryckning();
       // PrintPersonal();
        PrintRapport();

        
    }
    public static void PrintRapport()
    {
        foreach(var utryckning in Nyutryckning)
        {
            Console.WriteLine($"|Händelse:{utryckning.HändelseTyp}\t|Plats:{utryckning.plats}\t|Datum & Tid:{utryckning.tidPunkt}");
            Console.WriteLine("Poliser på plats:");
            foreach(var polis in utryckning.OnScene)
            {
                Console.WriteLine($"|Namn:{polis.namn}\t|TjänsteNr:{polis.tjänsteNr}");
            }
            Console.WriteLine("________________________");
            
        }
    }
    public static void addUtryckning()
    {
        Console.WriteLine("Skriv in Typen av Brott");
        string typ=Console.ReadLine();
        Console.WriteLine("Skriv in Platsen för händelsen");
        string plats=Console.ReadLine();
        Console.WriteLine("Skriv in datum & tid (YYYY-MM-DD HH:MM");
        DateTime tid=DateTime.Parse(Console.ReadLine());
        PrintPersonal();
        Console.WriteLine("Välj polis som är på platsen");
        int input=int.Parse(Console.ReadLine());
        List<Personal> onScene=new();
        onScene.Add(AllPolis[input]);
        Console.WriteLine("Vill du lägga till fler poliser på platsen? (J/N)");
        string svar=Console.ReadLine();
        while(svar=="J")
        {
            PrintPersonal();
            input=int.Parse(Console.ReadLine());
            onScene.Add(AllPolis[input]);
            Console.WriteLine("Vill du lägga till fler poliser på platsen? (J/N)");
            svar=Console.ReadLine();
        }
        Nyutryckning.Add(new Utryckning(typ, plats,tid,onScene));
        
    }
public static void PrintPersonal()
{
    for (int i=0; i<AllPolis.Count;i++)
        {
            Personal Polisen= AllPolis[i]; 
            Console.WriteLine($"{i}: Konstapel:{Polisen.namn}||Tjänstenr:{Polisen.tjänsteNr}");
        }
        
}
}
class Utryckning
{
    public string HändelseTyp;
    public string plats;
    public DateTime tidPunkt;
    public List<Personal>OnScene;

    public Utryckning(string händelseTyp, string plats, DateTime tidPunkt, List<Personal>onScene)
    {
        this.HändelseTyp=händelseTyp;
        this.plats=plats;
        this.tidPunkt=tidPunkt;
        this.OnScene=onScene;
    }
}
class Personal
{
    public string namn;
    public int tjänsteNr;
    public Personal(string namn, int tjänsteNr)
    {
        this.namn=namn;
        this.tjänsteNr=tjänsteNr;
    }
}