//For data read/write methods
//Working with Lists and Collections
//Working with Lists and Collections
//More advanced manipulation of lists/collections

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Noise;

public class Octave
{
    public readonly double amplitude;

    public readonly double frequency;
    public readonly double phaseShift;

    internal Octave(double f, double a, double p)
    {
        amplitude = a;
        frequency = f;
        phaseShift = p;
    }
}