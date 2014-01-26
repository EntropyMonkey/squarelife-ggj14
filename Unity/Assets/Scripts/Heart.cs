using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
    void OnTriggerEnter(Collider collider)
    {
        Breeding breeding = collider.GetComponent<Breeding>();
        if (breeding != null)
        {
            breeding.Hearts++;
            Destroy(gameObject);
        }
    }
}
