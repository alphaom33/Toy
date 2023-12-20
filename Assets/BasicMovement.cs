using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour, HumanMovement
{
    private Transform sign;
    public float speed;

    private void Start()
    {
        sign = GameObject.FindWithTag("Sign").transform;
    }


    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * (sign.position - transform.position).normalized);
    }
}
