using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;
    private void OnEnable()
    {
        foreach(Transform t in canvas.transform)
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
            Disable();
        }
    }

    public void Disable()
    {
        foreach(Transform t in canvas.transform)
        {
            if (t.name != gameObject.name)
                t.gameObject.SetActive(true);
            Debug.Log(t.name);
        }
        Time.timeScale = 1; 

        gameObject.SetActive(false);
    }
}
