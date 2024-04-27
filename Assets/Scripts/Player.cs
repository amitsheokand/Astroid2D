
using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 3;

    private Camera viewCamera;
    private PlayerController _playerController;

    private AstroidGameManager _gameManager;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _gameManager = FindFirstObjectByType<AstroidGameManager>();
        viewCamera = Camera.main;
    }

    
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;
        _playerController.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane zPlane = new Plane(Vector3.forward, Vector3.zero);
        float rayDistance;

        if (zPlane.Raycast(ray, out rayDistance))
        {
            Vector2 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.green);

            _playerController.LookAt(point);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            _gameManager.OnPlayerDeath(transform.position);
            Destroy(gameObject);
        }
    }
}
