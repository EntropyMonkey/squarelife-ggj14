using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Mortal mortal = contact.otherCollider.GetComponent<Mortal>();
            if (mortal != null)
            {
                mortal.Kill(this);
            }
        }
    }
}
