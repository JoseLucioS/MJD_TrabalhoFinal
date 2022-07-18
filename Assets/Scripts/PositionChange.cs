using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    //[SerializeField] private Vector3 positionChange;
    private int direction = 1;
    private float maxValue = 5f;
    private float minValue = -5f;
    private float currentValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += direction * Time.deltaTime;

        if (currentValue >= maxValue)
        {
            direction *= -1;
            currentValue = maxValue;
        }
        else if(currentValue <= minValue)
        {
            direction *= -1;
            currentValue = minValue;
        }

        //move the object on the axis X
        transform.position = new Vector3(currentValue, transform.position.y, transform.position.z);
    }
}
