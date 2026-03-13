namespace Tasca;

public class Tauro : AnimalReproductiu
{
    private int rondesViscudes = 0;

    public Tauro(int pX, int pY, Vector dir, Sexe sx, bool vi, string ini)
        : base(pX, pY, dir, sx, vi, ini) { }

    public override void Mou()
    {
        base.Mou();
        rondesViscudes++;
        if (rondesViscudes >= 75)
            viu = false;
    }

    public override void Interactua(Animal animalAInteractuar)
    {
        if (animalAInteractuar is Tortuga)
        {
            direccio.X *= -1;
            direccio.Y *= -1;
        }
        else if (animalAInteractuar is Tauro)
        {
            base.Interactua(animalAInteractuar);
        }
        else
        {
            animalAInteractuar.Morir();
        }
    }
}
