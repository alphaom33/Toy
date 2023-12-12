using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    private CursorController cursor;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindWithTag("Cursor").GetComponent<CursorController>();
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HumanController currentHuman = cursor.currentHuman;
        text.text = "";
        if (currentHuman)
        {
            foreach (HumanController.Currency c in currentHuman.currencies)
            {
                if (c.max > 0)
                {
                    text.text += "  " + c.tag + ": " + c.val;
                    text.text += "/" + c.max;
                }
            }
        }
    }
}
