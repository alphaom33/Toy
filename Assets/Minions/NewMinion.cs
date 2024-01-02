using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMinion : BaseMinion
{
    public BaseMinion[] unlocks;

    public void AddUnlockeds()
    {
        foreach (BaseMinion b in unlocks)
        {
            if (!human.unlockeds.Contains(b))
                human.unlockeds.Add(b);
        }
        GameObject.FindWithTag("Father").GetComponent<MenuFather>().ResetButtons(human.unlockeds);
    }
}
