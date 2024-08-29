using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamReceiver : MonoBehaviour
{
    public int hp = 10;

    public virtual bool CheckHp()
    {
        return hp <= 0;
    }
    public virtual void Receive(int dam)
    {
        hp -= dam;
    }
}
