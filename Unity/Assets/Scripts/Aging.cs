using UnityEngine;
using System.Collections;

public class Aging : IReset {
    public float Lifetime = 30;
    public float Age { get; private set; }
    public float AbsoluteAge { get; private set; }

    public Dispatcher<Aging> LifetimeExpired = new Dispatcher<Aging>();

    void FixedUpdate()
    {
        AbsoluteAge += Time.deltaTime;
        Age = AbsoluteAge / Lifetime;
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
