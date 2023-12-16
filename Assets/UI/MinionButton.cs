using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinionButton : MonoBehaviour
{
    private GameMaster master;
    public BaseMinion minion;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        GetComponent<Button>().onClick.AddListener(() => master.SetCurrentMin(minion));
        GetComponentInChildren<TMP_Text>().text = minion.name;// + " " + minion.cost;
    }

    private void Update()
    {
        if (master.currentMin == minion)
            image.color = Color.yellow;
        else
            image.color = Color.white;

    }
}
