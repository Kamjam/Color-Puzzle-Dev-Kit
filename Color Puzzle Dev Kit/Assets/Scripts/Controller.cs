using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    //player movement variables
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        float horzInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

        //Simple 2D movement
        Vector3 dir = new Vector3(horzInput, vertInput, 0);

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}