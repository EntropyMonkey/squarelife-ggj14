using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour
{
    public Dispatcher<MonoBehaviour> Killed = new Dispatcher<MonoBehaviour>();

    public void Kill(MonoBehaviour killer)
    {
        Debug.Log("Mortal: Killing " + this + " (killer: " + killer + ")");
        Destroy(gameObject);
        Killed.Dispatch(killer);
    }
}
