using System;
using System.Linq;
using Formen;
namespace FormenKonsole
{
    enum KreisParameter
    {
        radius,
        durchmesser,
        umfang,
        volumen,
        oberfläche,
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wähle den Parameter aus dem die anderen Werte berechnen werden sollen:");
                Console.WriteLine("Gebe ein: r für Radius");
                Console.WriteLine("Gebe ein: d für Durchmesser");
                Console.WriteLine("Gebe ein: u für Umfang");
                Console.WriteLine("Gebe ein: V für Volumen");
                Console.WriteLine("Gebe ein: O für Oberfläche");
                string aktion = Console.ReadLine();

                KreisParameter parameter;

                if (aktion == "r") parameter = KreisParameter.radius;
                else if (aktion == "d") parameter = KreisParameter.durchmesser;
                else if (aktion == "u") parameter = KreisParameter.umfang;
                else if (aktion == "V") parameter = KreisParameter.volumen;
                else if (aktion == "O") parameter = KreisParameter.oberfläche;
                else
                {
                    Console.Error.WriteLine("Etwas ist schiefgelaufen. Drücke eine beliebige Taste");
                    Console.ReadKey();
                    continue;
                }
                double wert;
                Console.WriteLine("\nGebe nun den Wert für diese Parameter ohne Einheit ein");
                try
                {
                    wert = double.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.Error.WriteLine("Etwas ist schiefgelaufen. Drücke eine beliebige Taste");
                    Console.ReadKey();
                    continue;
                }

                Kugel k = null;

                try
                {
                    switch (parameter)
                    {
                        case KreisParameter.radius:
                            k = Kugel.vonRadius(wert);
                            break;
                        case KreisParameter.durchmesser:
                            k = Kugel.vonDurchmesser(wert);
                            break;
                        case KreisParameter.umfang:
                            k = Kugel.vonUmfang(wert);
                            break;
                        case KreisParameter.volumen:
                            k = Kugel.vonVolumen(wert);
                            break;
                        case KreisParameter.oberfläche:
                            k = Kugel.vonOberfläche(wert);
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Error.WriteLine("Etwas ist bei der Erstellung der Kugel schiefgelaufen. Drücke eine beliebige Taste");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Das sind die Parametere für eine Kugel mit einem {parameter.ToString().FirstCharToUpper()} von {wert}:");
                Console.WriteLine();
                try
                {
                    Console.WriteLine("Radius      r: " + k.Radius);
                    Console.WriteLine("Durchmesser d: " + k.Durchmesser);
                    Console.WriteLine("Umfang      u: " + k.Umfang);
                    Console.WriteLine("Volumen     V: " + k.Volumen);
                    Console.WriteLine("Oberfläche  O: " + k.Oberfläche);
                }
                catch (Exception)
                {
                    Console.Error.WriteLine("Etwas ist bei der Berechnung der anderen Parameter schiefgelaufen. Drücke eine beliebige Taste");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("\nDrücke eine beliebige Taste um eine neue Kugel zu berechnen");
                Console.ReadKey();

            }

        }
    }
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };
    }
}
