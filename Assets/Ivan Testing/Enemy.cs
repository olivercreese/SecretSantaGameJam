using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Entity
{
    GameObject player;

    protected Vector2 playerPos;
    [SerializeField] protected float speed;
    [SerializeField] protected float atkRange;

    protected SpriteRenderer spriteRender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        player = GameObject.Find("Player");
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        playerPos = player.transform.position;
        FacePlayer();
    }
    protected void FacePlayer()
    {
        if(transform.position.x < playerPos.x)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipX = false;
        }
    }

    protected virtual void Move(Vector2 target)
    {
        FacePlayer();
        float dist = (playerPos - (Vector2)transform.position).magnitude;
        if (dist < atkRange)
        {
            switch (spriteRender.flipX)
            {
                // Facing Right
                case true:
                    transform.position = Vector2.MoveTowards(transform.position, target - new Vector2(atkRange, 0), speed * Time.deltaTime);
                    break;
                // Facing Left
                case false:
                    transform.position = Vector2.MoveTowards(transform.position, target + new Vector2(atkRange, 0), speed * Time.deltaTime);
                    break;
            }
        }
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        Debug.Log($" Enemy {this.name} has taken {dmg} damage");

    }
    
    protected override void die()
    {
        base.die();
        Destroy(this.gameObject);
    }
}
