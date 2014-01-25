using UnityEngine;
using System.Collections;

public abstract class Moving : MonoBehaviour
{
    public abstract void SetDirection(float direction);
	public abstract bool Grounded { get; protected set; }
}