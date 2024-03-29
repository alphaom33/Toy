using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    private GameMaster cursor;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HumanController currentHuman = cursor.storeHuman;
        text.text = "";
        if (currentHuman)
        {
            foreach (HumanController.Currency c in currentHuman.currencies)
            {
                if (c.unlocked)
                {
                    text.text += "  " + c.name + ": " + c.val;
                    text.text += "/" + c.max;
                }
            }
        }
    }
}
