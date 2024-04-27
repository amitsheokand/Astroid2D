using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Suicide), 2);
    }

    private void Suicide()
    {
        DestroyImmediate(this.gameObject);
    }
}
