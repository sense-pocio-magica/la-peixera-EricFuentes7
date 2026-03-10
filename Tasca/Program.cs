namespace Tasca;

internal class Program
{
    static void Main(string[] args)
    {
        List<AnimalMaritim> animals = new List<AnimalMaritim>();

        Peixera joc = new Peixera(animals, 20, 20);
        
        joc.Inicialitza();
    }
}