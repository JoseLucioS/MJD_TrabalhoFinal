using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAnimator : MonoBehaviour
{
    private Text warningText;
    [SerializeField] private float visibilityTime = 2f, elapsedTime = 0;
    private bool visibilityToggled = false;
    void Start()
    {
        warningText = GetComponent<Text>();
    }

    void Update()
    {
        if (elapsedTime >= visibilityTime)
        {
            ToggleVisibility(false);
            visibilityToggled = false;
        }
        else if(visibilityToggled)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void ShowMessage(string message)
    {
        ToggleVisibility(true);
        warningText.text = message;
        elapsedTime = 0;
        visibilityToggled = true;
    }

    private void ToggleVisibility(bool show)
    {
        Color color = warningText.color;
        color.a = show ? 1 : 0;
        warningText.color = color;
    }
}
