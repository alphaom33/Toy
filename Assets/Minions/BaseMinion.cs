using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinion : MonoBehaviour
{
    public HumanController human;
    private GameMaster controller;

    public float tickSpeed = 0.1f;
    public string[] tags;
    public float[] costs = new float[3];
    public MinionType myType;
    public int max;

    public enum MinionType
    {
        GATHER_SNOT,
        GATHER_WATER,
        GATHER_MUSCLE,
        STORE_SNOT,
        STORE_WATER,
        STORE_MUSCLE,
        MAKE_WATER_OR_MUSCLE,
        DO_DAMAGE,
        SEND_MATERIALS
    }

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
        float timer = 0;
        while (timer <= tickSpeed)
        {
            if (controller.go)
                timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Tick());
    }

    public virtual void DoStuff()
    {

    }

    public virtual void Begin()
    {

    }
}
