using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour
{
    public Dispatcher<MonoBehaviour> Killed = new Dispatcher<MonoBehaviour>();

	public GameObject CrossPrefab;

	bool isDying;

    public void Kill(MonoBehaviour killer)
    {
		if (isDying) return;

		isDying = true;
		Killed.Dispatch(killer);

		StartCoroutine(DieAfter(1));

		renderer.enabled = false;
    }

	IEnumerator DieAfter(float t)
	{
		transform.position = transform.GetComponentInChildren<WorldCollider>().LastCollisionPosition;
		GetComponent<Resettable>().Reset();

		yield return new WaitForSeconds(t);

		if (CrossPrefab)
		{
			GameObject cross = Instantiate(CrossPrefab, transform.position + Vector3.forward, Quaternion.Euler(-0.5f, -105, -7.8f)) as GameObject;
			cross.transform.parent = GameObject.FindGameObjectWithTag("CrossCollector").transform;
		}

		renderer.enabled = true;
		isDying = false;
	}
}
