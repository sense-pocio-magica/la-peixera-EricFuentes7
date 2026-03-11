namespace Tasca;

public class Pop:AnimalReproductiu
{

    private static Random r = new Random();
    public Pop(int pX, int pY, Vector dir, Sexe sx, bool vi,string ini):base(pX,pY,dir,sx, vi,ini)
    {
        
    }

    public void assignarBeCoordenades()
    {
        int onAnar = r.Next(3);
        switch (onAnar)
        {
            case 0:
                posX = 0;
                break;
            case 1:
                posX = 19;
                break;
            case 2:
                posY = 0;
                break;
            case 3:
                posY = 19;
                break;
        }
    }
    public override void Mou()
    {
    }
}