using UnityEngine;
using System.Collections;

// not interface bec can't find interfaces with getcomponent etc.
public abstract class IReset : MonoBehaviour
{
	public abstract void Reset();
}
