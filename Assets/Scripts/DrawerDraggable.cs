using UnityEngine;

public class DrawerDraggable : IDraggable
{
    private Transform transform;
    private float dragSpeed;
    private float maxPullDistance = 0.5f;
    private float minPullDistance = 0.0f;
    private Vector3 initialPosition;


    public DrawerDraggable(Transform transform, float dragSpeed, float maxPullDistance = 0.5f)
    {
        this.transform = transform;
        this.dragSpeed = dragSpeed;
        this.maxPullDistance = maxPullDistance;

    }
    public void Initialize()
    {
        initialPosition = transform.localPosition;

    }
    public void OnInteract(bool interacting, Vector2 inputDelta)
    {
        if (interacting)
        {
            // getting the mouse delta and changing tranform position, making it move

            float movement = inputDelta.y * dragSpeed / 100;


            Vector3 newPosition = transform.localPosition + new Vector3(0, 0, movement);


            newPosition.z = Mathf.Clamp(newPosition.z, initialPosition.z - minPullDistance, initialPosition.z + maxPullDistance);


            transform.localPosition = newPosition;
        }
    }
    public void Reset()
    {
        transform.position = initialPosition;
    }
}
