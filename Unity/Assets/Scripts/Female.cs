using UnityEngine;
using System.Collections;

public class Female : MonoBehaviour
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Transform PlayerPrefab;
    public Transform Child { get; private set; }

    public Female()
    {
        Child = null;
    }

    public void SwitchToChild()
    {
        Debug.Log("Female: Switch to child if any");
        if (Child != null)
        {
            Debug.Log("Female: Switching to child");
            Instantiate(PlayerPrefab, Child.position, Child.rotation);
        }
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
