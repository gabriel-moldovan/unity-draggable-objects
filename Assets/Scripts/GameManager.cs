using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

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


        StartCoroutine(InitializeEventManager());
    }


    IEnumerator InitializeEventManager()
    {
        yield return new WaitUntil(() => EventManager.Instance != null);
        EventManager.Instance.SubscribeToDraggableEvents();
    }
}
