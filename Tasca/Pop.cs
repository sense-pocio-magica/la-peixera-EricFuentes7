namespace Tasca;
 
public class Pop : AnimalReproductiu
{
    private static Random r = new Random();
 
    public Pop(int pX, int pY, Vector dir, Sexe sx, bool vi, string ini)
        : base(pX, pY, dir, sx, vi, ini) { }
 
    public void assignarBeCoordenades()
    {
        int onAnar = r.Next(4);
        switch (onAnar)
        {
            case 0: posX = 0;  break;
            case 1: posX = 19; break;
            case 2: posY = 0;  break;
            case 3: posY = 19; break;
        }
    }
 
    public override void Mou()
    {
        int proximX = posX + direccio.X;
        int proximY = posY + direccio.Y;
 
        if (proximX > 19 || proximX < 0 || proximY > 19 || proximY < 0)
        {
            if      (direccio.X == 1)  { direccio.X = 0;  direccio.Y = 1;  }
            else if (direccio.Y == 1)  { direccio.X = -1; direccio.Y = 0;  }
            else if (direccio.X == -1) { direccio.X = 0;  direccio.Y = -1; }
            else if (direccio.Y == -1) { direccio.X = 1;  direccio.Y = 0;  }
        }
        else
        {
            posX = proximX;
            posY = proximY;
        }
    }
 
    public override void Interactua(Animal animalAInteractuar)
    {
        if (animalAInteractuar is Pop)
        {
            direccio.X *= -1;
            direccio.Y *= -1;
        }
    }
}