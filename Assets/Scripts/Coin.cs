using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 10;
    private string coinMessage = " coins acquired!";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<TextAnimator>().ShowMessage(value + coinMessage);
            GameManager.Instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}
