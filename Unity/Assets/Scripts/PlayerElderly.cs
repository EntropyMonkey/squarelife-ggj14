using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Female))]
[RequireComponent(typeof(Mortal))]
[RequireComponent(typeof(PlayerController))]
public class PlayerElderly : MonoBehaviour
{
    [SerializeField]
    private float lowNormalizedAge = .8f;
    [SerializeField]
    private float highNormalizedAge = 1;

    private Female female;
    private Mortal mortal;
    private PlayerController playerController;

    void Awake()
    {
        female = GetComponent<Female>();
        mortal = GetComponent<Mortal>();
        playerController = GetComponent<PlayerController>();
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
            if (female.Child != null)
            {
                female.SwitchToChild();
            }
            mortal.Kill(this);
        }
    }
}
