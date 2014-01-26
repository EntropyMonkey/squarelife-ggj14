using UnityEngine;
using System.Collections;

public class Breeding : IReset
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Instantiator PlayerPrefabInstantiator;
	public int HeartsNeededToBreed = 1;
	public ParticleSystem heartBeatParticles;
	public int heartBeatEmission = 10;

    public Transform Child { get; private set; }
    public Dispatcher<Transform> SwitchedToChild = new Dispatcher<Transform>();
	public int Hearts
	{
		get { return hearts; }
		set 
		{ 
			hearts = value;

			if (heartBeatParticles == null) heartBeatParticles = GetComponentInChildren<ParticleSystem>();

			if (hearts > 0)
			{
				heartBeatParticles.emissionRate = heartBeatEmission;
			}
			else
			{
				heartBeatParticles.emissionRate = 0;
			}
		}
	}
	int hearts = 0;

    private Colored colored;

    void Awake()
	{
		Child = null;
        colored = GetComponent<Colored>();
		Hearts = 0;
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width - 80, 16, 48, 24), "<3: " + Hearts + "/" + HeartsNeededToBreed);
    }

    public void SetSwitching(bool switching)
    {
        if (switching)
        {
            SwitchToChild();
        }
    }

    public void SwitchToChild()
    {
        if (Child != null)
        {
            //Transform child = PlayerPrefabInstantiator.Instantiate(Child.position, Child.rotation).transform;
            
            colored.Color = Child.GetComponent<Colored>().Color;

			GetComponent<Resettable>().Reset();

			SwitchedToChild.Dispatch(transform);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Partner partner = collision.gameObject.GetComponent<Partner>();
        if (partner != null && Child == null && Hearts >= HeartsNeededToBreed)
        {
            Child = (Transform)Instantiate(ChildPrefab, ChildAttachmentPoint.position, ChildAttachmentPoint.rotation);
            Child.parent = ChildAttachmentPoint;
            Child.GetComponent<Colored>().Color = colored.Blend(partner.Colored);
            partner.Mate(this);
            Hearts -= HeartsNeededToBreed;
        }
    }

	public override void Reset()
	{
		Hearts = 0;
		if (Child)
		{
			Destroy(Child.gameObject);
			Child = null;
		}
	}
}
