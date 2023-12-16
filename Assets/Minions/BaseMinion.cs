using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinion : MonoBehaviour
{
    public HumanController human;
    public GameMaster controller;
    public float tickSpeed = 0.1f;
    public string[] tags;
    //public int costType;
    public float[] costs = new float[3];

    private void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<GameMaster>();

        for (int i = 0; i < costs.Length; i++)
        {
            human.currencies[i].val -= costs[i];
        }

        Begin();
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        DoStuff();
        yield return new WaitForSeconds(tickSpeed);
        StartCoroutine(Tick());
    }

    public virtual void DoStuff()
    {

    }

    public virtual void Begin()
    {

    }
}
