using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BooleanStat : Stat<bool>
{
    public BooleanStat(bool value)
        : base(value)
    {
    }

    public static implicit operator bool(BooleanStat stat)
    {
        return stat.Value;
    }

    public static implicit operator BooleanStat(bool value)
    {
        return new BooleanStat(value);
    }
}

[System.Serializable]
public class IntegerStat : Stat<int>
{
    public IntegerStat(int value)
        : base(value)
    {
    }

    public static implicit operator int(IntegerStat stat)
    {
        return stat.Value;
    }

    public static implicit operator IntegerStat(int value)
    {
        return new IntegerStat(value);
    }
}

[System.Serializable]
public class FloatStat : Stat<float>
{
    public FloatStat(float value)
        : base(value)
    {
    }

    public static implicit operator float(FloatStat stat)
    {
        return stat.Value;
    }

    public static implicit operator FloatStat(float value)
    {
        return new FloatStat(value);
    }
}

[System.Serializable]
public class DoubleStat : Stat<double>
{
    public DoubleStat(double value)
        : base(value)
    {
    }

    public static implicit operator double(DoubleStat stat)
    {
        return stat.Value;
    }

    public static implicit operator DoubleStat(double value)
    {
        return new DoubleStat(value);
    }
}

[System.Serializable]
public class EnumStat : Stat<Enum>
{
    public EnumStat(Enum value)
        : base(value)
    {
    }

    public static implicit operator Enum(EnumStat stat)
    {
        return stat.Value;
    }

    public static implicit operator EnumStat(Enum value)
    {
        return new EnumStat(value);
    }
}

[System.Serializable]
public class Vector2Stat : Stat<Vector2>
{
    public Vector2Stat(Vector2 value)
        : base(value)
    {
    }

    public static implicit operator Vector2(Vector2Stat stat)
    {
        return stat.Value;
    }

    public static implicit operator Vector2Stat(Vector2 value)
    {
        return new Vector2Stat(value);
    }
}

[System.Serializable]
public class Vector3Stat : Stat<Vector3>
{
    public Vector3Stat(Vector3 value)
        : base(value)
    {
    }

    public static implicit operator Vector3(Vector3Stat stat)
    {
        return stat.Value;
    }

    public static implicit operator Vector3Stat(Vector3 value)
    {
        return new Vector3Stat(value);
    }
}

[System.Serializable]
public class Vector4Stat : Stat<Vector4>
{
    public Vector4Stat(Vector4 value)
        : base(value)
    {
    }

    public static implicit operator Vector4(Vector4Stat stat)
    {
        return stat.Value;
    }

    public static implicit operator Vector4Stat(Vector4 value)
    {
        return new Vector4Stat(value);
    }
}

/// <summary>
/// Usage:
/// 
///		FloatStat MinSpeed;
///		MinSpeed.AddModifier(x => 1.05f * x); // increases x by 5%
///		MinSpeed.Base = 1; // only change base value, leave modifiers intact
///		MinSpeed = 1; // change base value, delete modifiers (creates new stat, gc gets to work)
/// </summary>
/// <typeparam name="T">Type of the stat variable</typeparam>
public class Stat<T>
{
    public delegate T Modifier(T value);

    [SerializeField]
    private T _base;
    private T current;
    private LinkedList<Modifier> modifiers = new LinkedList<Modifier>();
    private bool initialized = false;

    public T Base
    {
        get { return _base; }
        set
        {
            _base = value;
            Recalculate();
        }
    }

    public T Value
    {
        get { return initialized ? current : (current = _base); }
    }

    public Stat(T value)
    {
        _base = value;
        current = _base;
        initialized = true;
    }

    public void AddModifier(Modifier modifier)
    {
        modifiers.AddLast(modifier);
        current = modifier(initialized ? current : _base);
    }

    public bool RemoveModifier(Modifier modifier)
    {
        bool result = modifiers.Remove(modifier);
        if (result)
            Recalculate();
        return result;
    }

    private void Recalculate()
    {
        current = _base;
        foreach (Modifier modifier in modifiers)
            current = modifier(current);
        initialized = true;
    }
}