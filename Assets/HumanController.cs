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

    public Currency[] currencies = { new(5, 10, "Snot", true), new(5, 10, "Water"), new(5, 5, "Muscle") };
    public List<BaseMinion> unlockeds;
    public float health;
    public FaceCamer[] locations;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
