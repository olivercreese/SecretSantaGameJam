using UnityEngine;

public class TestCollision : MonoBehaviour
{
    public float dmg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"{col.name} collided");
        if (col.TryGetComponent<Entity>(out Entity enemy))
        {
            Debug.Log($"entity {col.name} collided");
            enemy.TakeDamage(dmg);
        }
    }
}
