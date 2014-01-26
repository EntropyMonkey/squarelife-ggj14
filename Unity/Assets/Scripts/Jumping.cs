﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Moving))]
class Jumping : MonoBehaviour
{
    private const float TIMEOUT = .1f;

    public float LowerSpeed = 8;
    public float UpperSpeed = 12;
    public float LowerAge = 0;
    public float UpperAge = .8f;
    public float Speed { get; private set; }

    private bool jumping = false;
    private float timeout = 0;
    private Moving moving;
    private Aging aging;

    void Awake()
    {
        moving = GetComponent<Moving>();
        aging = GetComponent<Aging>();
    }

    void FixedUpdate()
    {
        float clamp = Mathf.Clamp((aging.Age - LowerAge) / (UpperAge - LowerAge), 0, 1);
        Speed = Mathf.Lerp(LowerSpeed, UpperSpeed, clamp);
        if (!moving.Grounded)
        {
            timeout = 0;
        }
        else if (timeout != 0)
        {
            timeout = Mathf.Max(timeout - Time.deltaTime, 0);
        }
        if (jumping && timeout == 0 && moving.Grounded)
        {
            rigidbody.velocity += Vector3.up * scale * Speed;
            timeout = TIMEOUT;
        }
    }

	public void SetJumping(bool jumping)
	{
		this.jumping = jumping;
	}
}
