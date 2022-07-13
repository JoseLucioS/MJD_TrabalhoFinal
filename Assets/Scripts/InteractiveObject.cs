using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition;
    [SerializeField] private float animationTime;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private MovementType movementType;

    private enum MovementType
    {
        SLIDE,
        ROTATE
    };

    private Hashtable iTweenArgs;

    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", openPosition);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("isLocal", true);
    }


    public void PerformAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOpen)
            {
                iTweenArgs["position"] = closedPosition;
                iTweenArgs["rotation"] = closedPosition;
            }
            else
            {
                iTweenArgs["position"] = openPosition;
                iTweenArgs["rotation"] = openPosition;
            }

            isOpen = !isOpen;

            if (movementType == MovementType.SLIDE)
            {
                iTween.MoveTo(gameObject, iTweenArgs);
            }
            else if (movementType == MovementType.ROTATE)
            {
                iTween.RotateTo(gameObject, iTweenArgs);
            }
            
        }
        
    }
}
