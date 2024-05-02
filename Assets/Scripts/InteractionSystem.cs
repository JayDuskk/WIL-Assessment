using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public LayerMask Interactable;
    public Camera rayCamera;
    public float range = 10f;
    public bool debug = false;


    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Interaction System Started");
    }

    public void reEnable()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
       

        if(Physics.Raycast(ray, out hit, range,Interactable))
        {
            if (debug)
            {
                Debug.DrawLine(transform.position, hit.point, Color.black);
            }
            if (Input.GetKeyDown(KeyCode.E) && active == false)
            {
                Debug.Log("Hit Object is Dialogue Based");
                Debug.Log("Starting Dialogue System...");

                hit.transform.gameObject.GetComponent<DialogueSystem>().Interacted();
                active = true;
            }
        }
    }
}
