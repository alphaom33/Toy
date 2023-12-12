using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public struct Currency
    {
        public float max;
        public string tag;
        public float val;

        public Currency(float max, string tag) : this()
        {
            this.max = max;
            this.tag = tag;
            val = 0;
        }

    }

    public Currency[] currencies = { new(10, "Snot"), new(0, "Water"), new(0, "Muscle") };
    public List<BaseMinion> unlockeds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
