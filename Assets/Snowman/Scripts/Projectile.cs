using UnityEngine;

public class Projectile : MonoBehaviour
{

    GameObject player;
    Rigidbody2D rb;
    [SerializeField] float projSpeed;
    [SerializeField] float projDmg;
    Vector3 projDir;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        projDir = (player.transform.position - transform.position).normalized;
        if(projDir.x > 0)
        {
            spriteRenderer.flipX = true;    
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // add deletion code
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = projDir*projSpeed;
    }
}
