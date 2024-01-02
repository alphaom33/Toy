using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosShow : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 1, 0.75f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
