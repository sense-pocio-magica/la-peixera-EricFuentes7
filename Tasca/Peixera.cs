namespace Tasca;

public class Peixera
{
    private static Random r = new Random();
    private List<Animal> animals;
    private int limitX;
    private int limitY;
    private string[,] mapa = new string[,]
    {
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#", "#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"}
        
    };
    public Peixera(List<Animal> anim, int limX, int limY)
    {
        animals = anim;
        limitX = limX;
        limitY = limY;
    }
    
    public void Començar()
    {
        
    }

    private void ConvertirAPunts()
    {
        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                mapa[i, j] = " ";
            }
        }
    }
    public void Inicialitza()
    {
        ConvertirAPunts();
        
        foreach (var a in animals)
        {
            if (a is Pop p)
            {
                p.assignarBeCoordenades();
            }
                (int X, int Y) pos = a.RetornarPosicio();
                mapa[pos.X, pos.Y] = a.RetornarInicials();
        }
    }
    
    public void MoureTots()
    {
        ConvertirAPunts();
        foreach (var a in animals)
        {
            
            a.Mou();
            (int X, int Y) pos = a.RetornarPosicio();
            pos = a.RetornarPosicio();
            mapa[pos.X, pos.Y] = a.RetornarInicials();
        }
    }

    public void Interactua()
    {
        List<Animal> bebes = new List<Animal>();
        HashSet<Animal> hanCriat = new HashSet<Animal>(); //deu em solucioni això, per a que no hi hagin 1 milio d'animals

        for (int i = 0; i < animals.Count; i++)
        {
            for (int j = i + 1; j < animals.Count; j++)
            {
                if (animals[i].RetornarPosicio() == animals[j].RetornarPosicio() && animals[i].EstaViu() && animals[j].EstaViu())
                {
                    animals[i].Interactua(animals[j]);
                    animals[j].Interactua(animals[i]);

                    if (animals[i].EstaViu() && animals[j].EstaViu() && 
                        animals[i].GetType() == animals[j].GetType() && 
                        animals[i].QuinSexeEs() != animals[j].QuinSexeEs() &&
                        animals[i] is not Pop)
                    { 
                        if (!hanCriat.Contains(animals[i]) && !hanCriat.Contains(animals[j]) && (animals.Count + bebes.Count) < 400)
                        {
                            CrearBebe(animals[i], animals[j], bebes);        
                            hanCriat.Add(animals[i]);
                            hanCriat.Add(animals[j]);
                        }
                    }
                }
            }
        }
    
        animals.AddRange(bebes);
    
        for (int i = animals.Count - 1; i >= 0; i--)
        {
            if (animals[i].EstaViu() == false)
            {
                animals.RemoveAt(i);
            }
        }
    }

    public void MostrarResultats()
    {
        for (int i = 0; i < mapa.GetLength(0); i++) 
        { 
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                Console.Write(mapa[i, j] + "\t");
            }

            Console.WriteLine();
            
        }  
    }
    

    private void CrearBebe(Animal pare1, Animal pare2, List<Animal> bebes)
    {
        int x = pare1.RetornarPosicio().Item1;
        int y = pare1.RetornarPosicio().Item2;

        int dirX = 0;
        int dirY = 0;
        bool direccioValida = false;

        while (direccioValida == false)
        {
            dirX = 0;
            dirY = 0;
            int orientacio = r.Next(4); 
            switch (orientacio)
            {
                case 0: dirY = -1; break;
                case 1: dirY = 1;  break; 
                case 2: dirX = -1; break; 
                case 3: dirX = 1;  break;
            }

            bool igualPare1 = (dirX == pare1.RetornarDireccio().X && dirY == pare1.RetornarDireccio().Y);
            bool igualPare2 = (dirX == pare2.RetornarDireccio().X && dirY == pare2.RetornarDireccio().Y);

            if (igualPare1 == false && igualPare2 == false)
            {
                direccioValida = true;
            }
        }

        Vector dirBebe = new Vector(dirX, dirY);

        Sexe sexeBebe = Sexe.MASCLE;
        if (r.Next(2) == 1) 
        {
            sexeBebe = Sexe.FEMELLA;
        }

        string inicial = pare1.RetornarInicials();
    
        if (pare1 is Peix) 
        {
            bebes.Add(new Peix(x, y, dirBebe, sexeBebe, true, inicial));
        }
        else if (pare1 is Tauro) 
        {
            bebes.Add(new Tauro(x, y, dirBebe, sexeBebe, true, inicial));
        }
        else if (pare1 is Tortuga) 
        {
            bebes.Add(new Tortuga(x, y, dirBebe, sexeBebe, true, inicial));
        }
        
    }
    public void MostrarResum(List<Animal> animals)
    {
        int peixos   = animals.Count(a => a is Peix);
        int taurons  = animals.Count(a => a is Tauro);
        int pops     = animals.Count(a => a is Pop);
        int tortugues = animals.Count(a => a is Tortuga);
 
        Console.WriteLine($"Peixos:    {peixos}");
        Console.WriteLine($"Taurons:   {taurons}");
        Console.WriteLine($"Pops:      {pops}");
        Console.WriteLine($"Tortugues: {tortugues}");
    }
}