using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour
{
    public Dispatcher<MonoBehaviour> Killed = new Dispatcher<MonoBehaviour>();

    public void Kill(MonoBehaviour killer)
    {
        Destroy(gameObject);
        Killed.Dispatch(killer);
    }
}
