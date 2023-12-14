using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinion : MonoBehaviour
{
    public HumanController human;
    public GameMaster controller;
    public float tickSpeed = 0.1f;
    public string[] tags;
    public int costType;
    public float cost;

    private void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        human.currencies[costType].val -= cost;
        Begin();
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        yield return new WaitForSeconds(tickSpeed);
        DoStuff();
        StartCoroutine(Tick());
    }

    public virtual void DoStuff()
    {

    }

    public virtual void Begin()
    {

    }
}
