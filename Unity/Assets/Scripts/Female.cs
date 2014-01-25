using UnityEngine;
using System.Collections;

public class Female : MonoBehaviour
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Instantiator PlayerPrefabInstantiator;
    public Transform Child { get; private set; }

    public Female()
    {
        Child = null;
    }

    public bool SwitchToChild()
    {
        Debug.Log("Female: Switch to child if any");
        bool child = Child != null;
        if (child)
        {
            Debug.Log("Female: Switching to child");
            DeathManager.Instance().Player = null;
            Transform player = PlayerPrefabInstantiator.Instantiate(Child.position, Child.rotation);
            Camera.main.GetComponent<PlayerCamera>().player = player.GetComponent<PlayerController>();
        }
        return child;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Child == null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Male male = contact.otherCollider.GetComponent<Male>();
                if (male != null)
                {
                    Debug.Log("Female: Collision with Male while not having child, create child");
                    Child = (Transform)Instantiate(ChildPrefab, ChildAttachmentPoint.position, ChildAttachmentPoint.rotation);
                    Child.parent = ChildAttachmentPoint;
                    Destroy(male.gameObject);
                    break;
                }
            }
        }
    }

}
