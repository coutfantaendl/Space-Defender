using UnityEngine;

public class ZigzagMovement : MonoBehaviour, IMovementPattern
{
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float amplitude = 1f;

    private float elapsedTime = 0f;
    private float lastUpdateTime = 0f;

    public void Move(Transform transform, float speed)
    {
        if (Time.deltaTime == 0)
        {
            return;
        }

        float deltaTime = Time.time - lastUpdateTime;
        lastUpdateTime = Time.time;

        elapsedTime += deltaTime;

        Vector2 position = transform.position;

        position.x += Mathf.Sin(elapsedTime * frequency) * amplitude;
        position.y -= speed * Time.deltaTime;

        transform.position = position;
    }
}
