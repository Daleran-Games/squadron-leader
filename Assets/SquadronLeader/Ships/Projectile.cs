using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.SquadronLeader
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        float velocity;
        [SerializeField]
        float armorPiercing;
        [SerializeField]
        float damage;
        [SerializeField]
        float armingDistance;
        bool armed = false;
        [SerializeField]
        float burnOutDistance;

        Vector3 firedPosition;
        Rigidbody2D rb;

        [SerializeField]
        float distance;

        private void Start()
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
            firedPosition = transform.position;
            rb.velocity = transform.up * velocity;
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector2.Distance(firedPosition,transform.position);

            if (distance >= armingDistance && armed == false)
                armed = true;

            if (distance > burnOutDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (armed == true)
            {
                Debug.Log("Hit Something");
                Destroy(this);
            }
        }
    }
}

