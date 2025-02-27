using UnityEngine;

public class DoorDraggable : IDraggable
{
    private HingeJoint hinge;
    private Rigidbody rigidBody;
    private float dragSpeed;
    private bool isMirrored;
    private Quaternion initialRotation;

    public DoorDraggable(HingeJoint hinge, Rigidbody rigidBody, float dragSpeed, bool isMirrored)
    {
        this.hinge = hinge;
        this.rigidBody = rigidBody;
        this.dragSpeed = dragSpeed;
        this.isMirrored = isMirrored;
    }

    public void Initialize()
    {
        if (hinge != null)
        {
            initialRotation = hinge.transform.localRotation;
        }
    }

    public void OnInteract(bool interacting, Vector2 inputDelta)
    {
        if (interacting)
        {
            float rotationInput = inputDelta.y * dragSpeed;
            Vector3 torque = (isMirrored ? -rotationInput : rotationInput) * hinge.transform.up;
            rigidBody.AddTorque(torque, ForceMode.Force);
        }
    }

    public void Reset()
    {
        if (hinge != null)
        {
            hinge.transform.localRotation = initialRotation;
        }
    }
}
