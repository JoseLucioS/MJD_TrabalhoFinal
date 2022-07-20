using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    //[SerializeField] private Vector3 positionChange;
    [SerializeField] private int direction = 1;
    private float maxValue;
    private float minValue;
    private float currentValue;

    void Start()
    {
        currentValue = transform.position.x;
        maxValue = currentValue + 5;
        minValue = currentValue - 5;
    }

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
