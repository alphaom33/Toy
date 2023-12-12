using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public List<Vector3> spots;

    // Start is called before the first frame update
    void Start()
    {
        spots = new List<Vector3>();
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t != GetComponent<Transform>())
            {
                spots.Add(t.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
