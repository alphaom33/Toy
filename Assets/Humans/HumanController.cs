using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public struct Currency
    {
        public float max;
        public string name;
        public float val;
        public bool unlocked;

        public Currency(float max, string name) : this()
        {
            this.max = max;
            this.name = name;
            val = 0;
        }

        public Currency(string name) : this()
        {
            max = 10;
            this.name = name;
            val = 0;
        }

        public Currency(float val, float max, string name) : this()
        {
            this.max = max;
            this.name = name;
            this.val = val;
        }

        public Currency(float val, float max, string name, bool unlocked) : this()
        {
            this.max = max;
            this.name = name;
            this.val = val;
            this.unlocked = unlocked;
        }

    }

    public Currency[] currencies = { new(50, 10, "Snot", true), new(5, 10, "Water"), new(5, 7, "Muscle") };
    public List<BaseMinion> unlockeds;
    public float health;
    public FaceCamer[] locations;
    public CinemachineVirtualCamera camer;
    public HumanMovement movement;
    private HumanDamage damage;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<HumanMovement>();
        damage = GetComponent<HumanDamage>();
        UpdateTags();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move();
        damage.Damage();
    }

    void UpdateTags()
    {
        string[] checkTags = GameObject.FindWithTag("Player").GetComponent<GameMaster>().currentMin.tags;
        foreach (FaceCamer f in locations)
        {
            f.gameObject.SetActive(false);
            foreach (string tag in f.tags)
            {
                foreach (string s in checkTags)
                {
                    if (s == tag)
                        f.gameObject.SetActive(true);
                }
            }
        }
    }
}
