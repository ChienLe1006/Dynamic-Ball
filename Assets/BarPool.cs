using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPool : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(Random.Range(-4.2f, -1.9f), -5.9f, 0);
    }
}
