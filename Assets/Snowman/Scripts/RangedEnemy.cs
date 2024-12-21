using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : Enemy
{

    [SerializeField] GameObject projectile;

    [SerializeField] float minDist;
    bool retreating;

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();
    }

    #region Movement
    protected override void Move()
    {
        float dist = (playerPos - (Vector2)transform.position).magnitude;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, playerPos.y), speed * Time.deltaTime);
        if (isRetreating(dist) || dist > atkRange)
        {
            switch (spriteRender.flipX)
            {
                // Facing Right
                case true:
                    transform.position = Vector2.MoveTowards(transform.position, playerPos - new Vector2(atkRange, 0), speed * Time.deltaTime);
                    break;
                // Facing Left
                case false:
                    transform.position = Vector2.MoveTowards(transform.position, playerPos + new Vector2(atkRange, 0), speed * Time.deltaTime);
                    break;
            }
        }        
    }

    private bool isRetreating(float dist)
    {
        if (dist < minDist)
        {
            retreating = true;
        }
        else if (dist >= atkRange)
        {
            retreating = false;
        }
        return retreating;
    }

    #endregion
    protected override void attack()
    {
        anim.SetTrigger("Shoot");
    }

    private void shootProjectile()
    {
        Instantiate(projectile, transform.position , transform.rotation);
    }

}
