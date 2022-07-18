using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private string itemMessage;

    [SerializeField] InteractiveObject unlockableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<TextAnimator>().ShowMessage(itemMessage);
            unlockableObject.ToggleIsLocked(false);
            Destroy(gameObject);
        }
    }
}
