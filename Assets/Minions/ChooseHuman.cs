using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class ChooseHuman : MonoBehaviour
{
    GameMaster master;
    public HumanController storeHuman;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(storeHuman);
        if (Input.GetMouseButtonDown(0) && storeHuman)
        {
            MonkeySend monkeySend = GetComponentInParent<MonkeySend>();
            monkeySend.sendHuman = storeHuman;
            monkeySend.go = true;

            SendMessageUpwards("EndStop");
        }
    }

    private Transform whyIsExist(Transform other)
    {
        int t = 0;
        while (other.GetComponent<Animator>() == null || t > 100) {
            other = other.GetComponentsInParent<Transform>()[1];
        }
        return other.GetComponentsInParent<Transform>()[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Transform parent = whyIsExist(other.transform); 
            parent.GetComponentInChildren<SkinnedMeshRenderer>().material = master.selected;
            Debug.Log(parent.name);
            storeHuman = parent.GetComponentInChildren<HumanController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HumanArea"))
        {
            other.GetComponentInParent<HumanController>().GetComponentsInParent<Transform>()[1].GetComponentInChildren<SkinnedMeshRenderer>().material = master.no;
            storeHuman = null;
        }
    }
}
