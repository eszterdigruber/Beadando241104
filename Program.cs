using CA241104;
using System.Net.Http.Headers;
using System.Text;

List<Versenyzo> versenyzok = [];

// Órai munka csopi3 dolgozat:

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyzok szama: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29 kategoriaban versenyzok szama: {f1} fo");

var f2 = versenyzok.Average(v => 2014 - v.Szulev);
Console.WriteLine($"versenyzok atlag eletkora: {f2:0.00} ev");

var f3 = versenyzok.Sum(v => v.Idok["úszás"].TotalHours);
Console.WriteLine($"uszassal toltott ido: {f3:0.00} ora");

var f4 = versenyzok
    .Where(v => v.Kategoria == "elit")
    .Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"atlagos uszasi ido elit kategoriaban: {f4:0.00} perc");

var f5 = versenyzok
    .Where(v => v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"gyoztes ferfi: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine($"kategoriankent a versenyt befejezok szama: ");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{grp.Key, 11}: {grp.Count(), 2}");
}

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .ToDictionary(g => g.Key, g => g.Average(v =>
        v.Idok["I. depó"].TotalMinutes +
        v.Idok["II. depó"].TotalMinutes))
    .OrderBy(kvp => kvp.Key);
Console.WriteLine($"kategoriankent az atlagos depo ido: ");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key, 11}: {kvp.Value:0.00} perc");
}

Console.WriteLine("----------------------------");

// Órai munka folytatása csopi1:

var f8 = versenyzok.Where(v => v.Kategoria == "elit");
Console.WriteLine($"elit versenyzok szama: {f8.Count()} db");

var f9 = versenyzok
    .Where(v => !v.Nem)
    .Average(v => 2014 - v.Szulev);
Console.WriteLine($"noi versenyzok atlag eletkora: {f9:0} év");

var f10 = versenyzok.Sum(v => v.Idok["kerékpár"].TotalHours);
Console.WriteLine($"kerekparozassal toltott ido: {f10:0.00} ora");

var f11 = versenyzok
    .Where(v => v.Kategoria == "elit junior")
    .Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"atlagos uszasi ido elit junior kategoriaban: {f11:0.00} perc");

var f12 = versenyzok
    .Where(v => v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"ferfi gyoztes: {f12}");
Console.WriteLine("----------------------------");

// Órai munka folytatás csopi2:

var f13 = versenyzok.Where(v => v.Kategoria == "elit junior");
Console.WriteLine($"elit versenyzok szama: {f13.Count()}");

var f14 = versenyzok
    .Where(v => v.Nem)
    .Average(v => 2014 - v.Szulev);
Console.WriteLine($"ferfi versenyzok atlag elekora: {f14:0.00} fo");

var f15 = versenyzok.Sum(v => v.Idok["futás"].TotalHours);
Console.WriteLine($"futassal toltott ido: {f15:0.00} ora");

var f16 = versenyzok
    .Where(v => v.Kategoria == "20-24")
    .Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"atlagos uszasi ido 20-24 kategoriaban: {f16:0.00} perc");

var f17 = versenyzok
    .Where(v => !v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"noi gyoztes: {f17}");

var f18 = versenyzok.GroupBy(v => v.Nem);
Console.WriteLine($"a versenyt befejezo nemek szerint: ");
foreach (var grp in f18)
{
    Console.WriteLine($"\t{(grp.Key ? "ferfi" : "no"), 5}: {grp.Count()} fo");
}