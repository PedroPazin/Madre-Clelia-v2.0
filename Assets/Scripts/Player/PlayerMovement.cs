using UnityEngine;

public class PlaterMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.linearVelocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
