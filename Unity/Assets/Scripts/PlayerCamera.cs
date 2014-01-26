using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public Scaling Player;
    public float MinSize = 5;
    public float MaxSize = 10;
    public float Speed = 2;

    void FixedUpdate()
    {
        if (Player != null)
        {
            camera.fieldOfView = MinSize + (MaxSize - MinSize) * Player.Scale / Player.MaxScale;
            camera.ResetAspect();
            camera.aspect /= Player.Aspect;

            Vector3 newPos = transform.position;
            newPos.z = Mathf.Lerp(newPos.z, Player.transform.position.z, Speed * Time.deltaTime);
            newPos.y = Mathf.Lerp(newPos.y, Player.transform.position.y, Speed * Time.deltaTime);
            transform.position = newPos;
        }
    }
}