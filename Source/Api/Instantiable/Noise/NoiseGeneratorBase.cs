using System.Collections.Generic;
using UnityEngine;

//For data read/write methods
//Working with Lists and Collections
//Working with Lists and Collections
//More advanced manipulation of lists/collections

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Noise;

public abstract class NoiseGeneratorBase
{
    protected readonly List<Octave> octaves = new();

    public readonly long seed;

    /**
 * As opposed to scaling
 */
    public bool clampEdge = false;

    protected double inputFactor = 1;
    protected double maxRange = 1;

    private NoiseGeneratorBase xNoise;
    private double xNoiseScale;
    private NoiseGeneratorBase yNoise;
    private double yNoiseScale;
    private NoiseGeneratorBase zNoise;
    private double zNoiseScale;

    protected NoiseGeneratorBase(long s)
    {
        seed = s;
    }

    public double getValue(Vector3 vec)
    {
        return getValue(vec.x, vec.y, vec.z);
    }

    public double getValue(double x, double y, double z)
    {
        return calculateValues(x * inputFactor, y * inputFactor, z * inputFactor);
    }

    private double calculateValues(double x, double y, double z)
    {
        if (displaceCalculation())
        {
            var x0 = x;
            var y0 = y;
            var z0 = z;
            x += getXDisplacement(x0, y0, z0);
            y += getYDisplacement(x0, y0, z0);
            z += getZDisplacement(x0, y0, z0);
        }

        var val = calcValue(x, y, z, 1, 1);

        if (octaves.Count > 0)
        {
            foreach (var o in octaves)
                val += calcValue(x + o.phaseShift, y + o.phaseShift, z + o.phaseShift, o.frequency, o.amplitude);
            if (clampEdge)
                val = Mathf.Clamp((float) val, -1, 1);
            else
                val /= maxRange;
        }

        return val;
    }

    protected virtual bool displaceCalculation()
    {
        return true;
    }

    protected abstract double calcValue(double x, double y, double z, double freq, double amp);

    public NoiseGeneratorBase setFrequency(double f)
    {
        inputFactor = f;
        return this;
    }

    public double getFrequencyScale()
    {
        return inputFactor;
    }

    public NoiseGeneratorBase addOctave(double relativeFrequency, double relativeAmplitude)
    {
        return addOctave(relativeFrequency, relativeAmplitude, 0);
    }

    public NoiseGeneratorBase addOctave(double relativeFrequency, double relativeAmplitude, double phaseShift)
    {
        octaves.Add(new Octave(relativeFrequency, relativeAmplitude, phaseShift));
        maxRange += relativeAmplitude;
        return this;
    }

    public NoiseGeneratorBase setDisplacementSimple(long seedX, double fx, long seedZ, double fz, double s)
    {
        return setDisplacement(new SimplexNoiseGenerator(seedX).setFrequency(fx), s, null, s,
            new SimplexNoiseGenerator(seedZ).setFrequency(fz), s);
    }

    public NoiseGeneratorBase setDisplacementSimple(long seedX, double fx, long seedY, double fy, long seedZ, double fz,
        double s)
    {
        return setDisplacement(new SimplexNoiseGenerator(seedX).setFrequency(fx), s,
            new SimplexNoiseGenerator(seedY).setFrequency(fy), s, new SimplexNoiseGenerator(seedZ).setFrequency(fz), s);
    }

    public NoiseGeneratorBase setDisplacement(NoiseGeneratorBase x, NoiseGeneratorBase y, NoiseGeneratorBase z,
        double s)
    {
        return setDisplacement(x, s, y, s, z, s);
    }

    public NoiseGeneratorBase setDisplacement(NoiseGeneratorBase x, double xs, NoiseGeneratorBase y, double ys,
        NoiseGeneratorBase z, double zs)
    {
        xNoise = x;
        yNoise = y;
        zNoise = z;
        xNoiseScale = xs;
        yNoiseScale = ys;
        zNoiseScale = zs;
        return this;
    }

    public double getXDisplacement(double x, double y, double z)
    {
        return xNoise != null ? xNoise.getValue(x, y, z) * xNoiseScale : 0;
    }

    public double getYDisplacement(double x, double y, double z)
    {
        return yNoise != null ? yNoise.getValue(x, y, z) * yNoiseScale : 0;
    }

    public double getZDisplacement(double x, double y, double z)
    {
        return zNoise != null ? zNoise.getValue(x, y, z) * zNoiseScale : 0;
    }
}