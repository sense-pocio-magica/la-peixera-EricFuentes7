
namespace Tasca;
 
internal class Program
{
    private static Random r = new Random();
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Animal> animals = new List<Animal>();
 
        for (int i = 0; i < 141; i++)
        {
            int dirX = 0;
            int dirY = 0;
            int orientacio = r.Next(4);
 
            switch (orientacio)
            {
                case 0: dirY = -1; break;
                case 1: dirY = 1;  break;
                case 2: dirX = -1; break;
                case 3: dirX = 1;  break;
            }
 
            switch (i)
            {
                case < 50:
                    animals.Add(new Peix(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true, "\U0001F41F"));
                    break;
                case < 100:
                    animals.Add(new Peix(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.FEMELLA, true, "\U0001F41F"));
                    break;
                case < 110:
                    animals.Add(new Tauro(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true, "\U0001F988"));
                    break;
                case < 120:
                    animals.Add(new Tauro(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.FEMELLA, true, "\U0001F988"));
                    break;
                case < 135:
                    animals.Add(new Pop(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.POP, true, "\U0001F419"));
                    break;
                case < 138:
                    animals.Add(new Tortuga(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true, "\U0001F422"));
                    break;
                case < 141:
                    animals.Add(new Tortuga(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.FEMELLA, true, "\U0001F422"));
                    break;
            }
        }
 
        Peixera joc = new Peixera(animals, 20, 20);
        joc.Inicialitza();
 
        for (int i = 0; i < 100; i++)
        {
            joc.MoureTots();
            joc.Interactua();
            Console.Clear();
            Console.WriteLine($"RONDA: {i + 1}");
        }
        joc.MostrarResum(animals);
        joc.MostrarResultats();
        
    }
}