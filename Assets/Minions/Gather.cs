using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : BaseMinion
{
    public override void DoStuff()
    {
        if (human.currencies[costType].val < human.currencies[costType].max)
            human.currencies[costType].val++;
    }
}
