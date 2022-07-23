using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private Touch touch;
    public int speedModifier;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                playerRb.velocity = new Vector3(touch.deltaPosition.x * speedModifier* Time.deltaTime,
                                                transform.position.y,
                                                touch.deltaPosition.y * speedModifier* Time.deltaTime);
            }
        }
    }
}
