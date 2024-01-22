using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayPlace : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;

    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
