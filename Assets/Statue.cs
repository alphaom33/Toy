using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public BaseMinion minion;
    private GameMaster master;

    private void Start()
    {
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
    }

    private void OnMouseEnter()
    {
        Debug.Log(minion.name);
    }

    private void OnMouseDown()
    {
        master.SetCurrentMin(minion);
        Debug.Log(minion.name);
    }
}
