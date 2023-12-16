using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : BaseMinion
{
    public int gatherType;

    public override void Begin()
    {
        for (int i = 0; i < costs.Length; i++)
        {
            if (costs[i] > 0)
                human.currencies[i].unlocked = true;
        }
    }

    public override void DoStuff()
    {
        if (human.currencies[gatherType].val < human.currencies[gatherType].max)
            human.currencies[gatherType].val++;
    }
}
