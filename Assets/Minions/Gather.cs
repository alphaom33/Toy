using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

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
        human.AddToCurrency(1, gatherType);
        //if (human.currencies[gatherType].val < human.currencies[gatherType].max)
        //    human.currencies[gatherType].val++;
    }
}
