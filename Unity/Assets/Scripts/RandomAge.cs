using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Age))]
public class RandomAge : MonoBehaviour
{
    private Age age;

    void Awake()
    {
        age = GetComponent<Age>();
    }

    public void Start()
    {
        age.age = Random.value;
    }
}
