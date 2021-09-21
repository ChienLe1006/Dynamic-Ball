using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveForce;
    private float horizontalValue;
    private float vx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        vx = rb.velocity.x;
        if (horizontalValue != 0)
        {
            if (vx >= -10f && vx <= 10f)
            {
                rb.AddForce(Vector2.right * moveForce * horizontalValue);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Get Point")
        {
            GameController.Instance.GetPoint();
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            GameController.Instance.EndGame();
        }
    }
}
