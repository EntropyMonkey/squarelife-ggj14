using UnityEngine;
using System.Collections;

public interface Singleton<Type>
{
    Type Instance();
}
