using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameMaster master;
    public HumanController inMinionPlace;
    public HumanController currentHuman;
    public HumanController storeHuman;
    private MenuFather father;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        father = GameObject.FindWithTag("Father").GetComponent<MenuFather>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMans();
        Cursor.visible = false;
        if (currentHuman != null)
            storeHuman = currentHuman;
        currentHuman = master.currentCamer.GetComponent<HumanController>();  
    }

    private void SpawnMans()
    {
        if (Input.GetMouseButtonDown(0) && HasCash() && storeHuman.minionNums[master.currentMin.myType] < master.currentMin.max && (storeHuman.Equals(inMinionPlace)))// || master.currentMin.tags[0] == "All"))
        {
        Debug.Log(inMinionPlace.gameObject.name);
            Transform minion = Instantiate(master.currentMin.gameObject, transform.position, transform.rotation, storeHuman.GetComponentsInParent<Transform>()[1]).transform;
            minion.Rotate(90, 0, 0);
            BaseMinion controller = minion.GetComponent<BaseMinion>();
            controller.human = currentHuman;
            storeHuman.minionNums[controller.myType]++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            inMinionPlace = other.GetComponentInParent<HumanController>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            inMinionPlace = null;
    }

    private bool HasCash()
    {
        float[] temp = master.currentMin.costs;
        for (int i = 0; i < storeHuman.currencies.Length; i++)
        {
            if (storeHuman.currencies[i].val - temp[i] < 0)
                return false;
        }
        return true;
    }
}
