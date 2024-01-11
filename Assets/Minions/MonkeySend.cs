using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySend : BaseMinion
{
    public HumanController sendHuman;
    public bool go; 

    public override void DoStuff()
    {
        if (go)
        {
            for (int i = 0; i < human.currencies.Length; i++)
            {
                if (human.currencies[i].unlocked)
                {
                    sendHuman.currencies[i].unlocked = true;
                }
            }

            for (int i = 0; i < human.currencies.Length; i++)
            {
                if (human.currencies[i].val > 0)
                {
                    human.currencies[i].val--;
                    sendHuman.AddToCurrency(1, i);
                }
            }
        }
    }
}
