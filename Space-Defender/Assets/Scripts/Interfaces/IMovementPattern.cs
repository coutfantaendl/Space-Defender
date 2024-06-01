using UnityEngine;

public interface IMovementPattern
{
    void Move(Transform transform, float speed);
}
