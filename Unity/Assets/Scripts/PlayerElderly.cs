using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Aging))]
public class PlayerElderly : MonoBehaviour
{
    public float LowerAge = .8f;
    public float UpperAge = 1;

    private Aging aging;
    private Breeding breeding;
    private Mortal mortal;

    void Awake()
    {
        aging = GetComponent<Aging>();
        breeding = GetComponent<Breeding>();
        mortal = GetComponent<Mortal>();
    }

    void OnGUI()
    {
        if (aging.Age >= LowerAge)
        {
            GUI.HorizontalSlider(new Rect(16, Screen.height - 32, Screen.width - 32, 16), aging.Age, LowerAge, UpperAge);
        }
    }

    void Update()
    {
        if (aging.Age >= 1)
        {
            breeding.SwitchToChild();
            mortal.Kill(this);
        }
    }
}
