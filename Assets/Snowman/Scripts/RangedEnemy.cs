using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : Enemy
{

    [SerializeField] float minDist;
    bool retreating;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move(playerPos);
    }

    protected override void Move(Vector2 target)
    {
        float dist = (playerPos - (Vector2)transform.position).magnitude;
        if (isRetreating(dist) || dist > atkRange)
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

}
