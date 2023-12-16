using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseMinion
{
    public float[] maxAmount;

    // Start is called before the first frame update
    public override void Begin()
    {
        for (int i = 0; i < maxAmount.Length; i++)
        {
            human.currencies[i].max += maxAmount[i];
        }
    }
}
