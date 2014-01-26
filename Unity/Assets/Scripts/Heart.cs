using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	public ParticleSystem particles;

    void OnTriggerEnter(Collider collider)
    {
        Breeding breeding = collider.GetComponent<Breeding>();
        if (breeding != null)
        {
            breeding.Hearts++;

			ParticleSystem heartses = Instantiate(particles, transform.position, Quaternion.identity) as ParticleSystem;

			StartCoroutine(DestroyAfterDone(heartses));
        }
    }

	IEnumerator DestroyAfterDone(ParticleSystem particles)
	{
		renderer.enabled = false;

		yield return new WaitForSeconds(particles.duration);

		Destroy(particles.gameObject);
		Destroy(gameObject);
	}
}
