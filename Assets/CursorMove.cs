using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPositionToCursor();
    }

    private void SetPositionToCursor()
    {
        Transform camer = Camera.main.transform;

        Vector3 castPoint = Input.mousePosition;
        castPoint += camer.forward * 12.5f;
        castPoint = Camera.main.ScreenToWorldPoint(castPoint);
        castPoint -= camer.forward * 12.5f;

        LayerMask mask = LayerMask.GetMask("Default", "Player", "Ignore Camra");

        if (Physics.Raycast(castPoint, camer.forward, out RaycastHit hit, Mathf.Infinity, mask))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        if (hit.point != Vector3.zero)
            transform.position = hit.point;
    }
}
