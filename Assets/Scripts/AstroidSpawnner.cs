
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AstroidSpawnner : MonoBehaviour
{
    public AstroidGameManager GameManager;
    public GameObject astroidPrefab;
    
    private Bounds bounds;

    private Player _player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), Random.Range(2,6), Random.Range(1,6));
        bounds = GetComponent<BoxCollider2D>().bounds;

        _player = GameObject.FindAnyObjectByType<Player>();
        
        if(GameManager == null)
            GameManager = FindFirstObjectByType<AstroidGameManager>();
    }

   
    void Spawn()
    {
        if(_player == null)
            return;
        
        Vector3 randomPositionInBounds = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
        
        
        Vector3 dir = GetDireactionToPlayer();
        
        GameObject astroid = Instantiate(astroidPrefab, randomPositionInBounds, Quaternion.Euler(dir));
        
        var rigidbody2D = astroid.GetComponent<Rigidbody2D>();
        
        // add force to the astroid in forward direction
        rigidbody2D.AddForce(-dir * Random.Range(100, 300));
        
        var astroidComponent = astroid.GetComponent<Astroid>();
        astroidComponent._gameManager = GameManager;
        
        Debug.Log("Spawning Astroid from " + astroid.name);
        
    }
    
    private Vector3 GetDireactionToPlayer()
    {
        return (transform.position - _player.transform.position ).normalized;
    }
    
    
}
