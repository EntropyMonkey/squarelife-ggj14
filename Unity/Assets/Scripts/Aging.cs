using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Age))]
public class Aging : MonoBehaviour
{
    public Age Age
    {
        get;
        private set;
    }

    public float Lifetime = 30;
    public float AbsoluteAge { get; private set; }

    public Dispatcher<Aging> LifetimeExpired = new Dispatcher<Aging>();

    void Awake()
    {
        Age = GetComponent<Age>();
    }

    void FixedUpdate()
    {
        AbsoluteAge += Time.deltaTime;
        Age.age = AbsoluteAge / Lifetime;
        if (AbsoluteAge >= Lifetime)
        {
            LifetimeExpired.Dispatch(this);
        }
    }
}
