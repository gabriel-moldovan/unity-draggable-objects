using UnityEngine;
public interface IDraggable
{
    void Initialize();
    void OnInteract(bool interacting, Vector2 inputDelta);
    void Reset();
}