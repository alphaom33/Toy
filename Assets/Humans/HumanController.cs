using System;
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

    [Header("Minion Stuffs")]
    public Currency[] currencies = { new(50, 10, "Snot", true), new(5, 10, "Water"), new(5, 7, "Muscle") };
    public List<BaseMinion> unlockeds = new();
    public FaceCamer[] locations;

    [Header("Other Stuffs")]
    public float health;
    private GameMaster master;

    [Header("Stuffs")]
    public HumanMovement movement;
    private HumanDamage damage;

    public Dictionary<BaseMinion.MinionType, int> minionNums = new();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(currencies[0]);
        master = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
        movement = GetComponent<HumanMovement>();
        damage = GetComponent<HumanDamage>();
        UpdateTags();
        foreach (BaseMinion.MinionType type in Enum.GetValues(typeof(BaseMinion.MinionType)))
        {
            minionNums.Add(type, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (master.go)
        {
            movement.Move();
            damage.Damage();
        }
    }

    void UpdateTags()
    {
        string[] checkTags = master.currentMin.tags;
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

    public void AddToCurrency(float add, Currency currency)
    {
        AddToCurrency(add, Array.IndexOf(currencies, currency));
    }

    public void AddToCurrency(float add, int index)
    {
        if (currencies[index].val < currencies[index].max)
            currencies[index].val += add;
    }
}
