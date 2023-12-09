using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CursorController : MonoBehaviour
{
    public GameMaster master;
    public bool inMinionPlace;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
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
        if (Input.GetMouseButtonDown(0) && inMinionPlace)
        {
            Instantiate(master.currentMin.gameObject, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MinionPlace"))
            inMinionPlace = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinionPlace"))
            inMinionPlace = false;
    }
}
