using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamer : MonoBehaviour
{
    public string[] tags;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(90, 0, 0);
    }

    private void OnMouseEnter()
    {
        Debug.Log("what");
    }
}
