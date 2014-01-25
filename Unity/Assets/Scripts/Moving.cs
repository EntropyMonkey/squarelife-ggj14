using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    abstract class Moving : MonoBehaviour
    {
        public abstract void SetDirection(Vector2 direction);
    }
}
