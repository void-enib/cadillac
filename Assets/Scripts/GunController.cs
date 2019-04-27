using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float fireRate;
    public Transform bullet;
    public Transform spawnBullet;
    public int munition;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire && munition!=0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            munition--;
        }
    }
}
