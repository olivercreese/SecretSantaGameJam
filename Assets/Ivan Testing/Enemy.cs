using UnityEngine;

public class Enemy : Entity
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
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
