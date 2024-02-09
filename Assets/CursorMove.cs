using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMove : MonoBehaviour
{
    public bool doRotation;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    [SerializeField] InputAction mouseDelta;
    public Vector2 mousePos;

    // Start is called before the first frame update
    void OnEnable()
    {
        mouseDelta.Enable();
    }

    private void OnDisable()
    {
        mouseDelta.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos += mouseDelta.ReadValue<Vector2>();
        SetPositionToCursor();
        //Debug.Log("Cmer" + Camera.main.WorldToScreenPoint(transform.position).x);
    }

    private void SetPositionToCursor()
    {
        Transform camer = Camera.main.transform;

        Vector3 castPoint = mousePos;
        castPoint += camer.forward * 12.5f;
        castPoint = Camera.main.ScreenToWorldPoint(castPoint);
        castPoint -= camer.forward * 12.5f;

        LayerMask mask = LayerMask.GetMask("Default", "Player", "Ignore Camra", "Human");
        if (Physics.Raycast(castPoint, camer.forward, out RaycastHit hit, Mathf.Infinity, mask) && doRotation)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            transform.rotation = Quaternion.Euler(rotationOffset);
        }
        
        if (hit.point != Vector3.zero)
            transform.position = hit.point + positionOffset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(Camera.main.WorldToScreenPoint(transform.position), Vector3.one * 25);
    }
}
