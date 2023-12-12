using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScroll : MonoBehaviour
{
    private Scrollbar scrollBar;

    private void Start()
    {
        scrollBar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollBar.value += Input.GetAxis("Mouse ScrollWheel");
    }
}
