using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactRange;

    private InteractiveObject interactiveObject;
    private Camera cam;
    private RaycastHit hit;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange);

        if (hit.transform)
        {
            interactiveObject = hit.transform.GetComponent<InteractiveObject>();
        }
        else
        {
            interactiveObject = null;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (interactiveObject)
            {
                interactiveObject.PerformAction();
            }
        }
    }
}
