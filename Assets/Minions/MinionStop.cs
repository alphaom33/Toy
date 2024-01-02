using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStop : MonoBehaviour
{
    private GameMaster master;
    private GameObject cursor;
    public CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        master.canChangeCamers = false;
        virtualCamera.Priority = 1000;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        cursor = GameObject.FindWithTag("Cursor");
        StartCoroutine(a());
    }

    private void Update()
    {
        cursor.SetActive(false);
        Cursor.visible = true;
    }

    private IEnumerator a()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.01f;

    }

    public void EndStop()
    {
        Time.timeScale = 1.0f;
        master.canChangeCamers = true;
        virtualCamera.Priority = 0;
        cursor.SetActive(true);
        Cursor.visible = false;

        gameObject.SetActive(false);
    }
}
