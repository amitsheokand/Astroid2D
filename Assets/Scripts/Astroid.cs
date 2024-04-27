using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Astroid : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public ParticleSystem deathParticle;

    public AstroidGameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        
        Invoke(nameof(Suicide), 8);
    }

    private void Suicide()
    {
        DestroyImmediate(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            CancelInvoke();

            _gameManager.IncrementScore();
            
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
