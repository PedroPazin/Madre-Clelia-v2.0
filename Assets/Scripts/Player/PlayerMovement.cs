using UnityEditor.U2D;
using UnityEngine;

public class PlaterMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;

    // Animation
    private Animator anim;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.linearVelocity = direction.normalized * speed;

        if (direction.x != 0)
        {
            // Walk sides
            ResetLayers();
            anim.SetLayerWeight(2, 1);
            sprite.flipX = !(direction.x > 0);
        }
        else if (direction.y != 0)
        {
            ResetLayers();
            anim.SetLayerWeight(direction.y > 0 ? 1 : 0, 1);
        }

        // Is walking or not
        anim.SetBool("walking", direction != Vector2.zero);
    }

    private void ResetLayers()
    {
        for (int i = 0; i < 3; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
