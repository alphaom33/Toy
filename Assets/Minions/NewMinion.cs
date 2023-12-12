using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMinion : BaseMinion
{
    public BaseMinion[] unlocks;

    public override void Begin()
    {
        foreach (BaseMinion b in unlocks)
        {
            human.unlockeds.Add(b);
        }
        GameObject.FindWithTag("Father").GetComponent<MenuFather>().ResetButtons(human.unlockeds);
    }
}
