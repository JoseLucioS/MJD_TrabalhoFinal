using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valor = 10;
    private string coinMessage = " coins acquired!";
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<TextAnimator>().ShowMessage(valor + coinMessage);
            GameManager.Instance.AddCoins(valor);
            Debug.Log(GameManager.Instance.GetCoins());
            Destroy(gameObject);
        }
    }
}
