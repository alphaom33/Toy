using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStop : MonoBehaviour
{
    private GameMaster master;
    private GameObject cursor;
    public CinemachineVirtualCamera virtualCamera;
    public bool hideCursor;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        master.canChangeCamers = false;
        master.go = false;

        virtualCamera.Priority = 1000;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        cursor = GameObject.FindWithTag("Cursor");
        StartCoroutine(a());
    }

    private void Update()
    {
        cursor.SetActive(false);
        Cursor.visible = !hideCursor;
    }

    private IEnumerator a()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;

    }

    public void EndStop()
    {
        Time.timeScale = 1.0f;
        
        master.canChangeCamers = true;
        master.go = true;

        virtualCamera.Priority = 0;
        cursor.SetActive(true);
        Cursor.visible = hideCursor;

        gameObject.SetActive(false);
    }
}
