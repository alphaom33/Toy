using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        foreach(Transform t in GetComponentsInParent<Transform>()[1].GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.name != "Canvas" && t.name != "Pause Menu")
                t.gameObject.SetActive(false);
        }
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            gameObject.SetActive(false);
        }
    }
}
