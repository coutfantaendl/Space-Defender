using UnityEngine;

public class StraightMovement : MonoBehaviour,IMovementPattern
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
