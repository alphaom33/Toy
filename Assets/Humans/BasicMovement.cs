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
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }


    public void Move()
    {
        if ((transform.position - sign.position).magnitude > distance)
        {
            Vector3 changePos = speed * Time.deltaTime * (sign.position - transform.position).normalized;
            mine.Translate(changePos.x, 0, changePos.z);
        }
        else
            player.Damage(damage);
    }
}
