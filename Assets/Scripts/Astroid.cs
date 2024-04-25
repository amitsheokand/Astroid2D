using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Astroid : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    
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
}
