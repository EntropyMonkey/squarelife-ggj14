using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public Mortal target;

    private Jumping jumping;
    private Moving moving;

    State act;

    void Awake()
    {
        jumping = GetComponent<Jumping>();
        moving = GetComponent<Moving>();
    }

    void Start()
    {
        act = waiting;
    }

    void FixedUpdate()
    {
        float direction;
        bool jump;
        if (Vector3.Distance(transform.position, target.transform.position) <= 10)
            act = attacking;
        else
            act = waiting;
        act(target, out direction, out jump);
        moving.SetDirection(direction);
        jumping.SetJumping(jump);
    }

    private delegate void State(Mortal target, out float direction, out bool jump);

    private void waiting(Mortal target, out float direction, out bool jump)
    {
        direction = 0;
        jump = false;
    }

    private void attacking(Mortal target, out float direction, out bool jump)
    {
        direction = target.transform.position.z - transform.position.z;
        jump = true;
    }
}
