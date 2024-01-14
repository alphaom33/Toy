using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

public class GameMaster : MonoBehaviour
{

    public BaseMinion currentMin;
    public List<HumanController> humans = new();
    private MenuFather father;
    public bool canChangeCamers = true;
    public Material selected;
    public Material no;
    public HumanController storeHuman;

    [Header("Boy Stuff")]
    public HealthBar healthBar;
    public float maxHealth = 20;
    public float health;

    //public CinemachineVirtualCamera[] cameras;
    //public float currentCamera;

    [Header("Base Unlocks")]
    [SerializeField] private List<BaseMinion> baseUnlockeds = new();
    public BaseMinion storeSnot;
    public BaseMinion makeWater;
    public BaseMinion[] endUnlockeds;

    [Header("Humans")]
    public GameObject[] humanPrefabs;
    public GameObject[] spawnPositions;
    public float spawnWaitTime;
    public List<Transform> camers = new();
    public Transform currentCamer;
    public CinemachineVirtualCamera virtualCamera;
    public bool go;

    private void Start()
    {
        spawnPositions = GameObject.FindGameObjectsWithTag("HumanSpawn");

        health = maxHealth;
        healthBar.SetInitialHealth(health);

        CheckLocs();
        father = GameObject.FindWithTag("Father").GetComponent<MenuFather>();
        StartCoroutine(SlowExpose());
        //StartCoroutine(SpawnFriends());

        health = maxHealth;

        currentCamer = camers[0];
    }

    private void Update()
    {
        if (canChangeCamers)
            CameraControl();
        CamerLook();

        KillHumans();

        Damage(0);
        storeHuman = currentCamer.GetComponent<HumanController>();
    }

    private IEnumerator SlowExpose()
    {
        yield return new WaitForEndOfFrame();
        father.ResetButtons(baseUnlockeds);

        yield return new WaitWhile(() => humans[0].currencies[0].val < storeSnot.costs[0]);
        humans[0].unlockeds.Add(storeSnot);
        baseUnlockeds.Add(storeSnot);
        father.ResetButtons(humans[0].unlockeds);

        yield return new WaitWhile(() => humans[0].currencies[0].val < makeWater.costs[0]);
        humans[0].unlockeds.Add(makeWater);
        baseUnlockeds.Add(makeWater);
        father.ResetButtons(humans[0].unlockeds);

        StartCoroutine(SpawnFriends());
    }

    private void KillHumans()
    {
        foreach (HumanController controller in humans)
        {
            if (controller.health < 0)
            {
                humans.Remove(controller);
                int temp = camers.IndexOf(currentCamer);
                temp++;
                temp %= camers.Count;
                currentCamer = camers[temp];
                camers.Remove(currentCamer);
                Destroy(controller.gameObject.GetComponentsInParent<Transform>()[1].gameObject);
                break;
            }
        }
    }

    private void CameraControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamer.GetComponent<MeshRenderer>().material = no;
            int temp = camers.IndexOf(currentCamer);
            temp++;
            temp %= camers.Count;
            currentCamer = camers[temp];
            currentCamer.GetComponent<MeshRenderer>().material = selected;
            father.ResetButtons(currentCamer.GetComponent<HumanController>().unlockeds);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCamer.GetComponent<MeshRenderer>().material = no;
            int temp = camers.IndexOf(currentCamer);
            temp--;
            temp += temp < 0 ? camers.Count : 0;
            currentCamer = camers[temp];
            currentCamer.GetComponent<MeshRenderer>().material = selected;
            father.ResetButtons(currentCamer.GetComponent<HumanController>().unlockeds);
        }
    }

    private void CamerLook()
    {
        if (currentCamer != null)
            virtualCamera.transform.LookAt(currentCamer);
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
        Vector3 position = spawnPositions[UnityEngine.Random.Range(0, 2)].transform.position;
        GameObject tmp = Instantiate(humanPrefabs[UnityEngine.Random.Range(0, humanPrefabs.Length)], position, Quaternion.Euler(0, 0, 0));
        HumanController human = tmp.GetComponentInChildren<HumanController>();
        human.unlockeds = baseUnlockeds.ToList();
        humans.Add(human);

        camers.Add(tmp.GetComponentsInChildren<Transform>()[1]);

        float timer = 0;
        while (timer <= spawnWaitTime)
        {
            if (go)
                timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(SpawnFriends());
    }
}
