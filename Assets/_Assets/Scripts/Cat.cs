using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{

    public void Climb()
    {
        Debug.Log(enemyName + "is climbing");
    }

    public override string GetName(Transform transform)
    {
        return base.GetName(transform);
    }
}
