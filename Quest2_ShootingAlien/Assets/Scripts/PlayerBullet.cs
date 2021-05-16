using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float attackAmount = 35.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30f); //5초후 제거!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Monster") // BulletSpawner
        //{
        //    BulletSpawner bulletmonster = other.GetComponent<BulletSpawner>();

        //    if (bulletmonster != null)
        //    {
        //        bulletmonster.GetDamage(attackAmount);
        //    }
        //}
        if(other.tag == "Monster2") // Alien Monster
        {
            MonsterCtrl alien = other.GetComponent<MonsterCtrl>();

            if (alien != null)
            {
                alien.GetDamage(attackAmount);
            }

        }

        Destroy(gameObject);
    }
}
