using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody playerRigidbody;
    public float speed = 8f;
    public float hp = 300.0f;
    //최대 hp
    int maxHp = 300;
    //hpslider 변수
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        //playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hpSlider.value = (float)hp / (float)maxHp;
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        //float xSpeed = xInput * speed;
        //float zSpeed = zInput * speed;

        //Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //playerRigidbody.velocity = newVelocity;
    }
    public void GetDamage(float amount)
    {
        hp -= amount;
        if (hp < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PUNCH")
        {
            GetDamage(10.0f);
        }
    }
}
