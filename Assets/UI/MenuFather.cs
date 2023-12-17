using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFather : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonParent;

    private CursorController cursor;
    private GameObject child;
    private List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>();
        cursor = GameObject.FindWithTag("Cursor").GetComponent<CursorController>();   
        child = GetComponentsInChildren<RectTransform>()[1].gameObject;
    }

    private void Update()
    {
        child.SetActive(cursor.storeHuman);
    }

    public void ResetButtons(List<BaseMinion> humanLoceds)
    {
        foreach (GameObject g in buttons)
        {
            Destroy(g);
        }
        buttons.Clear();
        foreach (BaseMinion b in humanLoceds)
        {
            GameObject a = Instantiate(buttonPrefab, buttonParent);
            a.GetComponent<MinionButton>().minion = b;
            buttons.Add(a);
        }
    }
}
