using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell 
{
    public int dam;

    public Spell(int dam)
    {
        this.dam = dam;
    }

    public abstract void UseSpell();
}
