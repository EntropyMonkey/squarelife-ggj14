using UnityEngine;
using System.Collections;

public abstract class Controller : MonoBehaviour
{
	public abstract bool Grounded { get; }

	public virtual float Scale { get { return 1; } }

	public abstract float NormalizedAge { get; protected set; }

	public abstract void MoveHorizontal(float axisValue);

	public abstract void Jump(bool jump);

    public abstract void Die(bool die);
}
