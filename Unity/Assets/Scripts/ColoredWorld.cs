using UnityEngine;
using System.Collections;

public class ColoredWorld : MonoBehaviour
{
    private Color color;

    public Color Color
    {
        set
        {
            GetComponentsInChildren<Renderer>()[0].sharedMaterial.color = color = value;
        }
        get
        {
            return color;
        }
    }
}
