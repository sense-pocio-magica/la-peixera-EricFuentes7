namespace Tasca;

public abstract class AnimalReproductiu : Animal
{
    public AnimalReproductiu(int pX, int pY, Vector dir, Sexe sx, bool vi, string ini) : base(pX, pY, dir, sx, vi, ini) { }
    
    public override void Interactua(Animal animalAInteractuar)
    {
        if (GetType() == animalAInteractuar.GetType()
            && sex == animalAInteractuar.QuinSexeEs())
        {
            Lluita();
            animalAInteractuar.Morir();
        }
    }

    public void Lluita()
    {
        Morir();
    }

    public void Procrea()
    {
        //fa el pare
    }
}