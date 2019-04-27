using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float randomAngle;
    public float speed;
    public float inaccuracy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomAngle = Random.Range(-inaccuracy, inaccuracy);
        movement = new Vector2(speed*randomAngle, speed);
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
        
    }
}
