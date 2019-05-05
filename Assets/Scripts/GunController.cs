using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float fireRate;
    public GameObject bullet;
    public Transform spawnBullet;
    public int munition;
    public float inaccuracy;
    public float speed;

    private Vector2 movement;
    private float nextFire;
    private float randomAngle;
    private Rigidbody2D rbBullet;
    private GameObject rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setBullet()
    {
        randomAngle = Random.Range(-inaccuracy, inaccuracy);
        movement = new Vector2(randomAngle, speed);
        Debug.Log("x = " + movement.x);
        Debug.Log("y = " + movement.y);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        GameObject copyBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        Rigidbody2D rbCopyBullet = GetComponent<Rigidbody2D>();
        rbCopyBullet.velocity = movement;
        Debug.Log("rb.velocity = " + rbCopyBullet.velocity);
    }

    void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && munition != 0)
        {
            nextFire = Time.time + fireRate;
            setBullet();
            munition--;
        }
    }

    void Target()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Target();
    }
}
