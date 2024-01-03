using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinionButton : MonoBehaviour
{
    private GameMaster master;
    public BaseMinion minion;
    public CursorController cursorController;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        cursorController = GameObject.FindWithTag("Cursor").GetComponent<CursorController>();
        GetComponentInChildren<TMP_Text>().text = minion.name;// + " " + minion.cost;
        
        GetComponent<Button>().onClick.AddListener(SetMinion);
    }

    private void SetMinion()
    {
        if (image.color != Color.red)
            master.SetCurrentMin(minion);
    }

    private void Update()
    {
        if (cursorController.storeHuman && cursorController.storeHuman.minionNums[minion.myType] >= minion.max)
            image.color = Color.red;
        else if (master.currentMin == minion)
            image.color = Color.yellow;
        else
            image.color = Color.white;
    }
}
