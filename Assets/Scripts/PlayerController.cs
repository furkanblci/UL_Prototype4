using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject powerupIndicator;
    private Rigidbody rb;
    private GameObject focalPoint;
    private bool hasPowerup;
    private float powerupStrength = 25;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

   
    void Update()
    {
        powerupIndicator.transform.position = transform.position;
        float forwardInput = Input.GetAxis("Vertical");
        
        rb.AddForce(focalPoint.transform.forward*speed*forwardInput);


        if (gameObject.transform.position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
            
            Debug.Log("Collided with"+other.gameObject.name+"With powerup set to"+hasPowerup);
            enemyRB.AddForce(awayFromPlayer*powerupStrength,ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7f);
        powerupIndicator.gameObject.SetActive(false);

        hasPowerup = false;
    }
}
