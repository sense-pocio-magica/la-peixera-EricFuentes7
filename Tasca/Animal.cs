using System.Numerics;

namespace Tasca;

public abstract class Animal:AnimalMaritim
{
    protected int posX;
    protected int posY;
    protected Vector direccio;
    protected Sexe sex;
    protected bool viu;
    protected string inicial;
    public Animal(int pX, int pY, Vector dir, Sexe sx, bool vi, string ini)
    {
        posX = pX;
        posY = pY;
        direccio = dir;
        sex = sx;
        viu = vi;
        inicial = ini;
    }
    public virtual void Mou()
    {
        if (posX + direccio.X > 20)
        {
            posX = 0;
        } else if (posX + direccio.X < 0)
        {
            posX = 20;
        }
        else
        {
            posX += direccio.X;
        }
        
        if (posY + direccio.Y > 20)
        {
            posY = 0;
        } else if (posY + direccio.Y < 0)
        {
            posY = 20;
        }
        else
        {
            posY += direccio.Y;
        }
    }

    public virtual void Interactua(Animal animalAInteractuar)
    {
        
    }

    public string RetornarInicials()
    {
        return inicial;
    }

    public (int, int) RetornarPosicio()
    {
        return (posX, posY);
    }
}