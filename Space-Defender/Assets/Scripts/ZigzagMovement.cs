using UnityEngine;

public class ZigzagMovement : MonoBehaviour, IMovementPattern
{
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float amplitude = 1f;

    public void Move(Transform transform, float speed)
    {
        Vector2 position = transform.position;

        position.x += Mathf.Sin(Time.time * frequency) * amplitude;
        position.y -= speed * Time.deltaTime;

        transform.position = position;
    }
}
