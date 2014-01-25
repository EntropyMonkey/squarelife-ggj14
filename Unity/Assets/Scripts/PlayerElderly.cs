using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerElderly : MonoBehaviour
{
    [SerializeField]
    private float lowNormalizedAge = .8f;
    [SerializeField]
    private float highNormalizedAge = 1;

    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent(typeof(PlayerController)) as PlayerController;
    }

    void OnGUI()
    {
        if (playerController.NormalizedAge >= lowNormalizedAge)
        {
            GUI.HorizontalSlider(new Rect(16, Screen.height - 32, Screen.width - 32, 16), playerController.NormalizedAge, lowNormalizedAge, highNormalizedAge);
        }
    }

    void FixedUpdate()
    {
        if (playerController.NormalizedAge >= 1)
        {
            Female female = GetComponent<Female>();
            if (female != null && female.Child != null)
            {
                female.SwitchToChild();
            }
            else
            {
                Mortal mortal = GetComponent<Mortal>();
                if (mortal != null)
                {
                    mortal.Kill(this);
                }
            }
        }
    }
}
