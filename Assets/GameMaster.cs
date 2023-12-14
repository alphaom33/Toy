using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public BaseMinion currentMin;
    public List<HumanController> humans = new();

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

        foreach (HumanController controller in humans)
        {
            if (controller.health < 0)
            {
                humans.Remove(controller);
                Destroy(controller.gameObject);
                break;
            }
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
        foreach (HumanController human in humans)
        {
            foreach (FaceCamer f in human.locations)
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
    }

    public void SetCurrentMin(BaseMinion minion)
    {
        currentMin = minion;
        CheckLocs();
    }
}
