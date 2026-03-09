using System.Numerics;

namespace Tasca;

public abstract class Animal:AnimalMaritim
{
    private int posX;
    private int posY;
    private Vector direccio;
    private Sexe sex;
    private bool viu;

    public virtual void Mou()
    {
        
    }

    public virtual void Interactua(Animal animalAInteractuar)
    {
        
    }

}