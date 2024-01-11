using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetMouseButtonDown(0) && storeHuman)
        {
            MonkeySend monkeySend = GetComponentInParent<MonkeySend>();
            monkeySend.sendHuman = storeHuman;
            monkeySend.go = true;

            SendMessageUpwards("EndStop");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<MeshRenderer>().material = master.selected;
            storeHuman = other.GetComponent<HumanController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<MeshRenderer>().material = master.no;
            storeHuman = null;
        }
    }
}
