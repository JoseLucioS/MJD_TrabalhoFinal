using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition;
    [SerializeField] private float animationTime;
    [SerializeField] private bool isOpen = false, isLocked = false, opensUnlockableObject;
    [SerializeField] private bool isTreasureChest;
    [SerializeField] private MovementType movementType;
    [SerializeField] private string objectMessage;
    [SerializeField] private InteractiveObject myUnlockableObject;

    private TextAnimator textAnimator;

    private enum MovementType
    {
        SLIDE,
        ROTATE
    };

    private Hashtable iTweenArgs;

    void Start()
    {
        textAnimator = FindObjectOfType<TextAnimator>();
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", openPosition);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("isLocal", true);
    }


    public void PerformAction()
    {
        if (!isLocked)
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
                ToggleMyUnlockableObject(isOpen);

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
        else
        {
            textAnimator.ShowMessage(objectMessage);
        }

        
    }

    private void ToggleMyUnlockableObject(bool shouldLock)
    {
        if (myUnlockableObject)
        {
            myUnlockableObject.ToggleIsLocked(false);
            if (opensUnlockableObject)
            {
                myUnlockableObject.PerformAction();
                myUnlockableObject.ToggleIsLocked(true);
            }
        }
    }

    public void ToggleIsLocked(bool newIsLocked)
    {
        isLocked = newIsLocked;
    }

}
