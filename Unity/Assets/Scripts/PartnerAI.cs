using UnityEngine;
using System.Collections;

public class PartnerAI : MonoBehaviour {
    private Jumping jumping;

    void Awake()
    {
        jumping = GetComponent<Jumping>();
    }

    void FixedUpdate()
    {
        jumping.SetJumping(true);
    }
}
