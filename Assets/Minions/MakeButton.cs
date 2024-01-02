using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    public BaseMinion addMinion;
    private NewMinion myMinion;

    // Start is called before the first frame update
    void Start()
    {
        myMinion = GetComponentInParent<NewMinion>();
        GetComponent<Button>().onClick.AddListener(AddMinion);
    }

    private void AddMinion()
    {
        myMinion.unlocks = new BaseMinion[1] { addMinion };
        myMinion.SendMessage("AddUnlockeds");
        SendMessageUpwards("EndStop");
    }
}
