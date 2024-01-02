using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamer : MonoBehaviour
{
    public string[] tags;
    public Vector3 offset = new Vector3(90, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(offset);
    }
}
