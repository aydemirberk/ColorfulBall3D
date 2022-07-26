using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CameraShaker cameraShake;
    public UIManager uIManager;
    private Rigidbody playerRb;
    private Touch touch;
    [Range(10,40)]
    public int speedModifier;
    public int forwardSpeed;
    public GameObject cam;
    public GameObject vectorForward;
    public GameObject vectorBack;
    
    

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }
    public void Update()
    {
        if (Variables.firstTouch == 1)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Variables.firstTouch = 1;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                playerRb.velocity = new Vector3(touch.deltaPosition.x * speedModifier* Time.deltaTime,
                                                transform.position.y,
                                                touch.deltaPosition.y * speedModifier* Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                playerRb.velocity = Vector3.zero;
            }
        }
    }


    public GameObject[] FractureItems;
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("BadObject"))
        {
            uIManager.StartCoroutine("WhiteEffect");
            cameraShake.CameraShakesCall();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            foreach(GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                
            }
        }
    }
}
