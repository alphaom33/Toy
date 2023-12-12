using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseMinion
{
    public float maxAmount;

    // Start is called before the first frame update
    public override void Begin()
    {
        human.currencies[costType].max += maxAmount;
    }
}
