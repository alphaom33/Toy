using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinionButton : MonoBehaviour
{
    private GameMaster master;
    public BaseMinion minion;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        GetComponent<Button>().onClick.AddListener(() => master.SetCurrentMin(minion));
        GetComponentInChildren<TMP_Text>().text = minion.name;
    }
}
