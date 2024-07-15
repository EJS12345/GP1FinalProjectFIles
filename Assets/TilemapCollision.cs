using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    void Start()
    {
        // Get or add the Tilemap component
        Tilemap tilemap = GetComponent<Tilemap>();
        if (tilemap == null)
        {
            tilemap = gameObject.AddComponent<Tilemap>();
        }

        // Add Tilemap Collider 2D if not already added
        TilemapCollider2D tilemapCollider = gameObject.GetComponent<TilemapCollider2D>();
        if (tilemapCollider == null)
        {
            tilemapCollider = gameObject.AddComponent<TilemapCollider2D>();
        }

        // Add Composite Collider 2D if not already added
        CompositeCollider2D compositeCollider = gameObject.GetComponent<CompositeCollider2D>();
        if (compositeCollider == null)
        {
            compositeCollider = gameObject.AddComponent<CompositeCollider2D>();
        }

        // Ensure the Rigidbody2D is set to Static
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Static; // Corrected line

        // Make the Tilemap Collider 2D use the Composite Collider 2D
        tilemapCollider.usedByComposite = true;
    }
}


