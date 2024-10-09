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