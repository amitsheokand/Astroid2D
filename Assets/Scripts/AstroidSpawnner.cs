using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

enum SpawnnerSide
{
    Up,
    Down,
    Left,
    Right
}

[RequireComponent(typeof(BoxCollider2D))]
public class AstroidSpawnner : MonoBehaviour
{
    public GameObject astroidPrefab;
    
    [FormerlySerializedAs("shootingDirection")] [SerializeField]
    private SpawnnerSide spawnnerSide;
    
    private Bounds bounds;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), Random.Range(2,6), Random.Range(1,5));
        bounds = GetComponent<BoxCollider2D>().bounds;
    }

   
    void Spawn()
    {
        
        Vector3 randomPositionInBounds = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
        Vector3 dir = GetRandomOppositeDirection(spawnnerSide);
        
        GameObject astroid = Instantiate(astroidPrefab, randomPositionInBounds, Quaternion.Euler(dir));
        
        var rigidbody2D = astroid.GetComponent<Rigidbody2D>();
        
        // add force to the astroid
        rigidbody2D.AddTorque(Random.Range(-10, 10));
        rigidbody2D.AddForce(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
        
        Debug.Log("Spawning Astroid from " + astroid.name);
        
    }
    
    private Vector3 GetRandomOppositeDirection(SpawnnerSide spawnnerSide)
    {
        switch (spawnnerSide)
        {
            case SpawnnerSide.Up:
                return new Vector3(Random.Range(0, 180), -1, Random.Range(0, 180));
            case SpawnnerSide.Down:
                return new Vector3(Random.Range(0, 180), 1, Random.Range(180, 360));
            case SpawnnerSide.Left:
                return new Vector3(1, Random.Range(0, 360), Random.Range(0, 360));
            case SpawnnerSide.Right:
                return new Vector3(-1, Random.Range(0, 360), Random.Range(0, 360));
            default:
                return Vector3.zero;
        }
    }
    
}
