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
    public GameMaster cursorController;

    [Header("Texts")]
    public TMP_Text nameText;
    public TMP_Text costText;

    private Image image;

    private string[] names = { "Snot", "Water", "Muscle" };

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        cursorController = GameObject.FindWithTag("Player").GetComponent<GameMaster>();

        nameText.text = minion.name;

        GetComponent<Button>().onClick.AddListener(SetMinion);
    }

    private void LateUpdate()
    {
        SetCost();
    
    }

    private void SetCost()
    {
        costText.text = "";
        for (int i = 0; i < minion.costs.Length; i++)
        {
            if (minion.costs[i] > 0)
            {
                costText.text += $"{(costText.text != "" ? "," : "")} {names[i]}: {minion.costs[i]}";
            }
        }
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
