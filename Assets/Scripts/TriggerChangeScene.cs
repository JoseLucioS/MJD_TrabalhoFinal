using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private enum Scenes { 
        HOSPITAL, 
        DUNGEON,
        GAMEOVER
    };

    [SerializeField] private Scenes toSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (toSceneName == Scenes.HOSPITAL)
            {
                LoadNextLevel("HospitalScene");
            }
            else if (toSceneName == Scenes.DUNGEON)
            {
                LoadNextLevel("DungeonScene");
            }
            else if (toSceneName == Scenes.GAMEOVER)
            {
                LoadNextLevel("GameOverScene");
            }
            
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
