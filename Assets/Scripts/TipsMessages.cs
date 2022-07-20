using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsMessages : MonoBehaviour
{
    [SerializeField] private string myMessage;

    private TextAnimator textAnimator;
    
    void Start()
    {
        textAnimator = FindObjectOfType<TextAnimator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textAnimator.ShowMessage(myMessage);
        }
    }
}
