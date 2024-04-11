using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public LayerMask Interactable;
    public Transform orientation;

    bool interactableInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactableInRange = Physics.Raycast(transform.position, orientation.forward, 100f, Interactable);

        if (interactableInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interactable in Range");

            // Dialouge System Here
        }
    }
}
