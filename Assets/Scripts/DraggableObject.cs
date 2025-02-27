using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;



public class DraggableObject : MonoBehaviour
{
    public event Action DragStarted;
    public event Action DragEnded;
    [SerializeField] private float dragSpeed = 5.0f;


    [Header("Door Attributes")]
    [SerializeField] private bool useDoorBehaviour = true;
    [SerializeField] private bool useMirroredRotation = false;

    [Header("Drawer Attributes")]
    [SerializeField] private float maxPullDistance = 0.5f;

    private IDraggable draggableStrategy;
    private StarterAssetsInputs playerInput;

    private bool isDragging;
    



    private void Awake()
    {
        playerInput = FindFirstObjectByType<StarterAssetsInputs>();

        draggableStrategy = useDoorBehaviour ? (IDraggable)new DoorDraggable(GetComponent<HingeJoint>(), GetComponent<Rigidbody>(), dragSpeed, useMirroredRotation) : new DrawerDraggable(transform, dragSpeed, maxPullDistance);

       draggableStrategy.Initialize();

    }

    public void Update()
    {
        if(playerInput.interact)
        {
            RaycastHit hit;
          if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.0f))
            {
                if(hit.collider.gameObject == gameObject)
                {
                  
                    isDragging = true;
                    DragStarted?.Invoke();
                    draggableStrategy.OnInteract(true, playerInput.look);
                }
            }
            else
            {
                isDragging = false;
                DragEnded?.Invoke();
                draggableStrategy.OnInteract(false, Vector2.zero);
            }      
        }
        else if(isDragging)  
        {
            DragEnded?.Invoke();
           isDragging = false;
        }
    }

    void OnDisable()
    {
    draggableStrategy.Reset();    
    }
}
