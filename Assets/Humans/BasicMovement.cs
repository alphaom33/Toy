using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour, HumanMovement
{
    public Transform sign;
    public float speed;
    private Transform mine;
    private GameMaster player;
    public float damage;
    public float distance;

    private void Start()
    {
        sign = GameObject.FindWithTag("Sign").transform;
        mine = GetComponentsInParent<Transform>()[1];
        player = GameObject.FindWithTag("Player").GetComponent<GameMaster>();
    }


    public void Move()
    {
        if ((transform.position - sign.position).magnitude > distance)
            mine.Translate(speed * Time.deltaTime * (sign.position - transform.position).normalized);
        else
            player.Damage(damage);
    }
}
