using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    Rigidbody rb;
    float jumpforce = 7;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        float vertical = Input.GetAxis("Vertical");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
           
    }
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
