namespace Tasca;

internal class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        Peixera joc = new Peixera(animals, 20, 20);
        
        joc.Començar();
    }
}