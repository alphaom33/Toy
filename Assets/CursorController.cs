using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CursorController : MonoBehaviour
{
    public GameMaster master;
    public bool inMinionPlace;
    public HumanController currentHuman;
    public HumanController storeHuman;
    private MenuFather father;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        father = GameObject.FindWithTag("Father").GetComponent<MenuFather>();
    }

    // Update is called once per frame
    void Update()
    {
        if (master.currentCamera == 0)
        {
            SetPositionToCursor();
            SpawnMans();
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        if (currentHuman != null)
            storeHuman = currentHuman;
    }

    private void SetPositionToCursor()
    {
        RaycastHit hit;
        Vector3 castPoint = Input.mousePosition;
        castPoint.z = 12.5f;
        castPoint = Camera.main.ScreenToWorldPoint(castPoint);
        castPoint.z -= 12.5f;
        LayerMask mask = LayerMask.GetMask("Default", "Player", "Ignore Camra");
        if (Physics.Raycast(castPoint, Camera.main.transform.forward, out hit, Mathf.Infinity, mask))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        if (hit.point != Vector3.zero)
            transform.position = hit.point;
    }

    private void SpawnMans()
    {
        if (Input.GetMouseButtonDown(0) && inMinionPlace && HasCash())
        {
            Transform minion = Instantiate(master.currentMin.gameObject, transform.position, transform.rotation, storeHuman.GetComponentsInParent<Transform>()[1]).transform;
            minion.Rotate(90, 0, 0);
            minion.GetComponent<BaseMinion>().human = currentHuman;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MinionPlace"))
            inMinionPlace = true;
        if (other.CompareTag("Human"))
        {
            currentHuman = other.GetComponent<HumanController>();
            father.ResetButtons(currentHuman.unlockeds);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinionPlace"))
            inMinionPlace = false;
        if (other.CompareTag("Human"))
            currentHuman = null;
    }

    private bool HasCash()
    {
        float[] temp = master.currentMin.costs;
        for (int i = 0; i < storeHuman.currencies.Length; i++)
        {
            if (storeHuman.currencies[i].val - temp[i] < 0)
                return false;
        }
        return true;
    }
}
