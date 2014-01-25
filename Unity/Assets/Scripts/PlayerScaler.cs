using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerScaler : MonoBehaviour
{
    private Vector2 defaultScale;

    // inspector variables:
    [SerializeField]
    private Vector2 maxScale = new Vector2(5, 3);
    [SerializeField]
    private float lowNormalizedAge = 0;
    [SerializeField]
    private float highNormalizedAge = .8f;
    //Scaling is done so that at lowNorm and below, it is 1, and at highNorm and above, it is maxScale. The development in between is linear.

    // public variables:
    /// <summary>
    /// The player's current scale
    /// </summary>
    public Vector2 Scale
    {
        get;
        private set;
    }

    // component refs:
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent(typeof(PlayerController)) as PlayerController;
    }

    // Use this for initialization
    void Start()
    {
        Scale = defaultScale = new Vector2(
            transform.localScale.z,
            transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        float range = Mathf.Clamp((playerController.NormalizedAge - lowNormalizedAge) / (highNormalizedAge - lowNormalizedAge), 0, 1);
        Scale = Vector2.Lerp(defaultScale, maxScale, range);
        transform.localScale = new Vector3(
            transform.localScale.x,
            Scale.y,
            Scale.x);
    }
}
