using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Walking))]
public class Killer : MonoBehaviour {
    private Walking walking;
    void Awake()
    {
        walking = GetComponent<Walking>();
    }
    void Start()
    {
        walking.GroundCollider.CollisionBegun.AddListener(other => {
            Mortal mortal = other.GetComponent<Mortal>();
            if (mortal != null && other.transform != transform)
            {
                mortal.Kill(this);
            }
            return false;
        });
    }
}
