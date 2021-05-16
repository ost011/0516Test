using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    public float attackAmount = 50.0f;
    private Rigidbody bulletRigidbody;



    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playercontroller= other.GetComponent<PlayerController>();

            if(playercontroller != null)
            {
                playercontroller.GetDamage(attackAmount);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
