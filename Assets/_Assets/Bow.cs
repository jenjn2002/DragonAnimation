using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Spell
{
    int range;

    public Bow(int dam, int range): base(dam)
    {
        this.range = range;
    }

    public override void UseSpell()
    {
        Debug.Log("Swash" + dam + "with" + range);
    }
}
