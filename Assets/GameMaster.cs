using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public float[] currencies;

    public BaseMinion currentMin;
    public FaceCamer[] locations;

    public CinemachineVirtualCamera[] cameras;
    public float currentCamera;

    private void Start()
    {
        CheckLocs();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            currentCamera %= 4;
            ChangeCamera();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCamera--;
            currentCamera += currentCamera < 0 ? 4 : 0;
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == currentCamera)
                cameras[i].Priority = 1;
            else
                cameras[i].Priority = 0;
        }
    }

    private void CheckLocs()
    {
        foreach (FaceCamer f in locations)
        {
            f.gameObject.SetActive(false);
            for (int i = 0; i < f.tags.Length; i++)
            {
                for (int j = 0; j < currentMin.tags.Length; j++)
                {
                    if (currentMin.tags[j] == f.tags[i])
                    {
                        f.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void SetCurrentMin(BaseMinion minion)
    {
        currentMin = minion;
        CheckLocs();
    }
}
