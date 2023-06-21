using UnityEngine;

public class PlayerColliderManipulation : MonoBehaviour
{
    public new Collider2D collider2D;
    public Vector2[] sizes;
    public int currentFrame = 0;

    private void Update()
    {
        Bounds colliderBounds = collider2D.bounds;
        colliderBounds.size = sizes[currentFrame];
    }
}
