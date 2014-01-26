using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Age))]
public class PlayerElderly : MonoBehaviour
{
    public float LowerAge = .8f;
    public float UpperAge = 1;

    private Age aging;
    private Breeding breeding;
    private Mortal mortal;

    void Awake()
    {
        aging = GetComponent<Age>();
        breeding = GetComponent<Breeding>();
        mortal = GetComponent<Mortal>();
    }

    void OnGUI()
    {
        if (aging.age >= LowerAge)
        {
            GUI.HorizontalSlider(new Rect(16, Screen.height - 32, Screen.width - 32, 16), aging.age, LowerAge, UpperAge);
        }
    }

    void FixedUpdate()
    {
        if (aging.age >= 1)
        {
            breeding.SwitchToChild();
            mortal.Kill(this);
        }
    }
}
