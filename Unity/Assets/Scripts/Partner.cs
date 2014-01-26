using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Colored))]
public class Partner : MonoBehaviour {
    public Colored Colored { get; private set; }

    void Awake()
    {
        Colored = GetComponent<Colored>();
    }

    void Start()
    {
       // Colored.Color = Colored.RandomColor();
    }

    public void Mate(Breeding partner)
    {
        Destroy(gameObject);
    }
}
