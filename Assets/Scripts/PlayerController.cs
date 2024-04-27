using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    
    private Vector2 velocity;
    private Rigidbody2D rigidbody2D;
    
    [SerializeField]
    private Transform nozzle;
    
    
    // TODO
    // 1. read wasd key input to move around
    // 2. take mouse input to look around
    // 3. if we go over edge, we come to other side
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Move(Vector2 moveVelocity)
    {
        velocity = moveVelocity;
    }
    
    // Reminder : Update for normal updates

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot
            GameObject spawnedBullet = Instantiate(bullet, nozzle.position, Quaternion.identity);
            
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 10, ForceMode2D.Impulse);
            
        }
    }


    // FixedUpdate for physics calulations 
    
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);
    }

    public void LookAt(Vector2 point)
    {
        Vector3 diff = (Vector3)point - transform.position;
        diff.Normalize();  
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
