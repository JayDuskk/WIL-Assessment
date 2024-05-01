using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public LayerMask Interactable;
    public Camera rayCamera;
    public float range = 10f;


    bool interactableInRange;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Interaction System Started");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
       

        if(Physics.Raycast(ray, out hit, range,Interactable))
        {
            Debug.DrawLine(transform.position, hit.point);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hit Object is Dialogue Based");
                Debug.Log("Starting Dialogue System...");

                hit.transform.gameObject.GetComponent<DialogueSystem>().Interacted();
            }
        }
    }
}
