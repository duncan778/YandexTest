using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] float vertSpeed = 5;
    [SerializeField] float horSpeed = 5;
    private bool isUp;

    void Update()
    {
        if (isUp)
            transform.Translate(0, vertSpeed * Time.deltaTime, 0);
        else
            transform.Translate(0, -vertSpeed * Time.deltaTime, 0);

        if (transform.position.x < -10)
            transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(30,50), transform.position.y, 0);

        transform.position = new Vector3(transform.position.x - Time.deltaTime * horSpeed, transform.position.y, 0);

        if (transform.position.y >= 4.7 && isUp)
            isUp = false;
        else if (transform.position.y <= -4.7 && !isUp)
            isUp = true;
    }

}
