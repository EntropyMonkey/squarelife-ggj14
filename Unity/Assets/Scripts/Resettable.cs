using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resettable : MonoBehaviour
{

	List<IReset> resettables;

	void Awake()
	{
		resettables = new List<IReset>();
		resettables.AddRange(GetComponents<IReset>());
		resettables.AddRange(GetComponentsInChildren<IReset>());
	}

	public void Reset()
	{
		foreach (IReset s in resettables)
		{
			s.Reset();
		}
	}

}
