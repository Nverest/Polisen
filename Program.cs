class Program
{
    static void Main (string[] args)
    {       
        List<Utryckning> utryckningar= new();
        
        bool running = true;
        while(running)
        {
            Console.WriteLine("=============Menu============\n[1]Utryckningar\n[2]Rapporter\n[3]Personal\n[4]Sammanställning\n[5] Avsluta");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                int val= int.Parse(Console.ReadLine());

                if (val==1)
                {
                Console.WriteLine("====Utryckningar====");
                Console.WriteLine("ange Typ");
                string typ=Console.ReadLine();
                Console.WriteLine("Ange tid");
                DateTime tid=DateTime.Parse(Console.ReadLine());
                Console.WriteLine("ange plats");
                string plats = Console.ReadLine();
                Console.WriteLine("Ange Poliser");
                string poliser=Console.ReadLine();
                Utryckning utryckning1 = new Utryckning(typ, plats, tid,poliser);
                utryckningar.Add(utryckning1);
                }
                else if (val== 2)
                {
                foreach(var utryckning in utryckningar)
                {
                    Console.WriteLine($"{utryckning.Typ}, {utryckning.Tid}, {utryckning.Plats}, {utryckning.Poliser}");
                }
                }

                break;
                case 2:
                Console.WriteLine("====Rapporter====");
                break;
                case 3:
                    Console.WriteLine("====Personal====");
                break;
                case 4:
                   Console.WriteLine("Sammanställning");
                break;
                case 5:
                Environment.Exit(0);
                break;
            }
        }
    }
}
public class Utryckning
{
    public string Typ{get; set;}
    public string Plats{get; set;}
    public DateTime Tid{get; set;}
    public string Poliser{get; set;}

    public Utryckning(string typ, string plats, DateTime tid,string poliser)
    {
        this.Typ=typ;
        this.Plats= plats;
        this.Tid=tid;
        this.Poliser=poliser;
    }

    
}