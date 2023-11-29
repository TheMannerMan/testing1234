using Helpers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace _03_Pearls;

class Program
{
    public class Pearl
    {
        

        public int Size { get; init; }
        public enColor Color { get; init; }
        public enShape Shape { get; init; }
        public enType Type { get; init; }

        public Pearl(csSeedGenerator _seeder)
        {
            Size = _seeder.NextInt(5, 25);
            Color = _seeder.FromEnum<enColor>();
            Shape = _seeder.FromEnum<enShape>();
            Type = _seeder.FromEnum<enType>();
        }

        public Pearl(int size, enColor color, enShape shape, enType type)
        {
            Size = size;
            Color = color;
            Shape = shape;
            Type = type;
        }

        public static void BiggestAndSmallestPearl(List<Pearl> pearls)
        {
            Pearl smallestPearl = null;
            Pearl largestPearl = null;
            int maxValue = int.MinValue;
            int minValue = int.MaxValue;

            for (int i = 0; i < pearls.Count; i++)
            {
                if (pearls[i].Size > maxValue)
                {
                    maxValue = pearls[i].Size;
                    largestPearl = pearls[i];
                }

                if (pearls[i].Size < minValue)
                {
                    minValue = pearls[i].Size;
                    smallestPearl = pearls[i];
                }
            }
            Console.WriteLine("The smallest pearl in the necklace is: ");
            Console.WriteLine(smallestPearl);
            Console.WriteLine("The largest pearl in the neckleace is: ");
            Console.WriteLine(largestPearl);
        }

        public override string ToString() => $"A {Color}, {Size}mm, {Shape} shaped {Type} pearl";

    }

    public enum enColor { Black, White, Pink}
    public enum enShape { Sphare, Droplet}
    public enum enType { FreshWater, SaltWater}

    static void Main(string[] args)
    {
        csSeedGenerator seeder = new csSeedGenerator();
        
        List<Pearl> necklace = new List<Pearl>();
        
        for (int i = 0; i < 10; i++)
        {
            Pearl pearl = new Pearl(seeder);
            Console.WriteLine(pearl);
            necklace.Add(pearl);
        }

        Pearl.BiggestAndSmallestPearl(necklace);
        
    }

    
}

//Exercise:
// 1. Modellera en pärlan i en C# class. Utmärkande för en pärla är
//    Storlek: Diameter 5mm till 25mm
//    Färg: Svart, Vit, Rosa
//    Form: Rund, Droppformad
//    Typ: Sötvatten, Saltvatten
//
// 2. När pärlan väl är skapad så ska man inte kunna ändra den. Använd init

// 3. Gör om constructor csPearl(csSeedGenerator _seeder) som initierar en slumpmässig pärla. använd .FromEnum liknande i Seedgeneratorn

// 4. Skapa en ToString i din pärlklass som presenterar pärlan.
//
// 4. Skapa ett halsband bestående av 10 pärlor av slumpmässig storlek, färg
//    form, och typ
//
// 5. Skriv kod som visar vilken färg, form och typ har den minsta och den största pärlan i halsbandet?
//
// 6. Deklarera en contruktor som tillåter dig att själv bestämma alla csPearl public properties
//
// 7. Deklarera en Copy constructor.
//
// 8. Använd copy constructorn för att skapa ett nytt halsband som är en kopia av ursprunget



