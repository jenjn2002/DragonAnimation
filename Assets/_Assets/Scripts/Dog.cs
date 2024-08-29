using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    public string skill;
    public override void Attack()
    {
        base.Attack();
    }

    public void UseSkill()
    {
        Debug.Log(enemyName + this.skill);
    }
}
