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

    }

    public Currency[] currencies = { new(5, 10, "Snot"), new("Water"), new("Muscle") };
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
