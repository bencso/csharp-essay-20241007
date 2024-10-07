using babolnai_bence_triatlon;
using System.IO;
using System.Text;

List<Versenyzo> versenyzok = new();
StreamReader sr = new StreamReader("@/../../../../src/forras.txt", encoding: Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new Versenyzo(sr.ReadLine()!));

Console.WriteLine("Ennyien fejezték be a versenyt: "+versenyzok.Count.ToString());
Console.WriteLine("Ennyi elit kategoriában versenyzők száma: "+versenyzok.Count(p=>p.Kategoria.ToLower()=="elit"));
Console.WriteLine("Női versenyzők álatéletkora: " + versenyzok.Where(p => p.Nem == "n").Average(p => DateTime.Now.Year - p.SzuletesiEv) + " év.");
Console.WriteLine("Kerékpározás összideje: "+Math.Round(TimeSpan.FromSeconds(versenyzok.Sum(p => p.KerekparozasIdo.TotalSeconds)).TotalHours,2));
Console.WriteLine("Úszás átlagos idejű elit junior kategória: " + TimeSpan.FromSeconds(versenyzok.Average(p => p.UszasiIdo.TotalSeconds)));
Console.WriteLine("Férfi győztes ideje: " + versenyzok.Min(p => TimeSpan.FromSeconds(p.KerekparozasIdo.TotalSeconds + p.UszasiIdo.TotalSeconds + p.FutasIdo.TotalSeconds)));
var kategoriak = versenyzok.GroupBy(p => p.Kategoria).Distinct().OrderBy(p=>p.Key);
Console.WriteLine("Korkategóriánként versenyt befejezők száma:");
foreach (var item in kategoriak)
{
    Console.WriteLine($"\t{item.Key.Substring(0, 1).ToUpper() + item.Key.Substring(1)}: {item.Count()} db");
}
Console.WriteLine("\nKorkategóriánként átlag depóidő:");
foreach (var item in kategoriak)
{
    Console.WriteLine($"\t{item.Key.Substring(0, 1).ToUpper() + item.Key.Substring(1)}: {TimeSpan.FromSeconds(item.Average(p=>item.Sum(p => p.IDepoIdo.TotalSeconds + p.IIDepoIdo.TotalSeconds)))}");
}