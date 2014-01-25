using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {
    public Transform Prefab;
    public Transform Instantiate(Vector3 position, Quaternion rotation)
    {
        return (Transform)Instantiate(Prefab, position, rotation);
    }
}
