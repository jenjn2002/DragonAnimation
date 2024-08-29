using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float heal;
    private void Start()
    {
        this.SetName();
    }
    public virtual string GetName(Transform transform)
    {
        return transform.name;
    }

    public virtual void SetName()
    {
        enemyName = GetName(transform);
    }

    public virtual void Attack()
    {
        Debug.Log(enemyName + "attack");
    }
}
