using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour, HumanDamage
{
    private bool colliding;
    private GameMaster sign;
    public float damage;

    private void Start()
    {
        sign = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
    }

    public void Damage()
    {
        if (colliding)
            sign.Damage(damage * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sign")
            colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sign")
            colliding = false;
    }
}
