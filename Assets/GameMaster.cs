using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameMaster : MonoBehaviour
{

    public BaseMinion currentMin;
    public List<HumanController> humans = new();
    private MenuFather father;

    [Header("Boy Stuff")]
    public HealthBar healthBar;
    public float maxHealth = 20;
    public float health;

    //public CinemachineVirtualCamera[] cameras;
    public float currentCamera;

    [Header("Base Unlocks")]
    public List<BaseMinion> baseUnlockeds = new();
    public BaseMinion storeSnot;
    public BaseMinion makeWater;

    [Header("Humans")]
    public GameObject[] humanPrefabs;
    public GameObject[] spawnPositions;
    public float spawnWaitTime;
    public List<Transform> camers = new();
    public CinemachineVirtualCamera virtualCamera;
    private Transform currentCamer;

    private void Start()
    {
        spawnPositions = GameObject.FindGameObjectsWithTag("HumanSpawn");

        health = maxHealth;
        healthBar.SetInitialHealth(health);

        CheckLocs();
        father = GameObject.FindWithTag("Father").GetComponent<MenuFather>();
        StartCoroutine(SlowExpose());
        StartCoroutine(SpawnFriends());

        health = maxHealth;
    }

    private void Update()
    {
        //CameraControl();

        KillHumans();

        Damage(0);
    }

    private IEnumerator SlowExpose()
    {
        yield return new WaitWhile(() => humans[0].currencies[0].val < storeSnot.costs[0]);
        baseUnlockeds.Add(storeSnot);
        humans[0].unlockeds.Add(storeSnot);
        father.ResetButtons(humans[0].unlockeds);
        yield return new WaitWhile(() => humans[0].currencies[0].val < makeWater.costs[0]);
        baseUnlockeds.Add(makeWater);
        humans[0].unlockeds.Add(makeWater);
        father.ResetButtons(humans[0].unlockeds);
    }

    private void KillHumans()
    {
        foreach (HumanController controller in humans)
        {
            if (controller.health < 0)
            {
                humans.Remove(controller);
                Destroy(controller.gameObject.GetComponentsInParent<Transform>()[1].gameObject);
                break;
            }
        }
    }

    private void CameraControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int temp = camers.FindIndex(a => a == currentCamer);
            temp++;
            temp %= camers.Count;
            ChangeCamera(temp);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //currentCamera--;
            //currentCamera += currentCamera < 0 ? humans.Count : 0;
            //ChangeCamera();
        }
    }

    private void ChangeCamera(int yes)
    {
        for (int i = 0; i < humans.Count; i++)
        {
            if (i == yes)
                //camers.Priority = 1;
            else
                humans[i].camer.Priority = 0;
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

    public void Damage(float amount)
    {
        health -= amount;
        healthBar.UpdateHealth(health);
    }

    private IEnumerator SpawnFriends()
    {
        Transform position = spawnPositions[Random.Range(0, 2)].transform;
        Instantiate(humanPrefabs[Random.Range(0, humanPrefabs.Length)], position.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(spawnWaitTime);
        StartCoroutine(SpawnFriends());
    }
}
