using UnityEngine;
using System.Collections;


public class Aging : IReset {
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

	public override void Reset()
	{
		Age = 0;
		AbsoluteAge = 0;
	}
}
