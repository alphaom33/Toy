using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BaseMinion
{
    public float damage;

    public override void DoStuff()
    {
        human.health -= damage;
    }
}
