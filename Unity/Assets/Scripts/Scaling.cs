using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Aging))]
public class Scaling : MonoBehaviour
{
    public float MaxScale = 3;
    public float MaxAspect = 1.5f;
    public float LowerAge = 0;
    public float UpperAge = .8f;
    public float Scale { get; private set; }
    public float Aspect { get; private set; }

    private Aging aging;

    void Awake()
    {
        aging = GetComponent<Aging>();
    }

    void FixedUpdate()
    {
        float clamp = Mathf.Clamp((aging.Age - LowerAge) / (UpperAge - LowerAge), 0, 1);
        Scale = Mathf.Lerp(1, MaxScale, clamp);
        Aspect = Mathf.Lerp(1, MaxAspect, clamp);
        transform.localScale = new Vector3(
            1,
            Aspect * Scale,
            Scale);
    }
}
