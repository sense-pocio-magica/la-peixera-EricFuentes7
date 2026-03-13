namespace Tasca;

internal class Program
{
    private static Random r = new Random();
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Console. BackgroundColor = ConsoleColor.Gray;
        //Console.Clear();
        List<Animal> animals = new List<Animal>();

        for (int i = 0; i < 141; i++)
        {
            int dirX = r.Next(1);
            int dirY;
            if (dirX == 0) dirY = 1; else  dirY = 0;
            
            switch (i)
            {
                case < 50:
                    animals.Add(new Peix(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true, "\U0001F41F"));
                    break;
                case < 100:
                    animals.Add(new Peix(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.FEMELLA, true,"\U0001F41F"));
                    break;
                case < 110:
                    animals.Add(new Tauro(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true,"\U0001F988"));
                    break;
                case < 120:
                    animals.Add(new Tauro(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true,"\U0001F988"));
                    break;
                case < 135:
                    animals.Add(new Pop(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.POP, true,"\U0001F419"));
                    // Al crear el joc, a la itineració 1 fer la funcio assignarBeCOordenades
                    break;
                case < 138:
                    animals.Add(new Tortuga(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.MASCLE, true,"\U0001F422"));
                    break;
                case < 141:
                    animals.Add(new Tortuga(r.Next(20), r.Next(20), new Vector(dirX, dirY), Sexe.FEMELLA, true,"\U0001F422"));
                    break;
                    
                    
            }
        }

        Peixera joc = new Peixera(animals, 20, 20);
        
        joc.Inicialitza();
        joc.MostrarResultats();
        joc.MoureTots();
        Thread.Sleep(2000);
        Console.WriteLine();
        joc.MostrarResultats();
    }
}