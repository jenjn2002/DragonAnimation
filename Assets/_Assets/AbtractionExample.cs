using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbtractionExample : MonoBehaviour
{
    public List<Spell> spells = new List<Spell>();
    void Start()
    {
        Spell sowrd = new Sword(1, 2);
        Spell bow = new Bow(5, 6);

        AddToList(bow);
        AddToList(sowrd);
        foreach(Spell spell in spells)
        {
            spell.UseSpell();
        }
    }

    void AddToList(Spell spell)
    {
        spells.Add(spell);
    }

}
