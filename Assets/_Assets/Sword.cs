using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Spell
{
    protected int height;

    public Sword(int dam, int height):base(dam)
    {
        this.height = height;
    }

    public override void UseSpell()
    {
        Debug.Log("Swash" + dam + "with" + height);
    }
}
