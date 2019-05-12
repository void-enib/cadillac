using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float randomAngle;
    private Vector2 movement;

    public float speed;
    public float inaccuracy;

    // Start is called before the first frame update
    void Start()
    {
        randomAngle = Random.Range(-inaccuracy, inaccuracy);
        transform.Rotate(0, 0, randomAngle, Space.Self);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
