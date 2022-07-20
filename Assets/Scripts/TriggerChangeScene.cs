using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    private enum Scenes { HOSPITAL, DUNGEON};
    [SerializeField] private Scenes toSceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (toSceneName == Scenes.HOSPITAL)
            {
                GameManager.Instance.LoadScene("HospitalScene");
            }
            else if (toSceneName == Scenes.DUNGEON)
            {
                GameManager.Instance.LoadScene("DungeonScene");
            }
            
        }
    }

}
