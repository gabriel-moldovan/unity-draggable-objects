using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
   public static EventManager Instance { get; private set; }

   public event Action OnDragStarted;
   public event Action OnDragEnded;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SubscribeToDraggableEvents()
    {
      DraggableObject[] draggableObjects = FindObjectsByType<DraggableObject>(FindObjectsSortMode.None);

      foreach(var draggable in draggableObjects)
      {
            draggable.DragStarted +=  HandleDragStarted;
            draggable.DragEnded += HandleDragEnded;   
      }
    }



    void HandleDragStarted()
    {
        OnDragStarted?.Invoke();
    }
    void HandleDragEnded()
    {
        OnDragEnded?.Invoke();
    }
}
