using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;


namespace DaleranGames.SquadronLeader
{
    public class KineticWeapon : MonoBehaviour
    {
        [SerializeField]
        float projectileOffset = 1f;

        [SerializeField]
        GameObject ammo;

        [SerializeField]
        int currentRounds;
        [SerializeField]
        int maxRounds;
        [SerializeField]
        float roundsPerMinute;
        float fireDelay;
        float nextFire = 0f;
        [SerializeField]
        bool isFiring = false;

        Animator anim;



        // Use this for initialization
        void Start()
        {
            fireDelay = 60f / roundsPerMinute;
            MouseCursor.Instance.LMBClick.MouseButtonDown += MouseDown;
            MouseCursor.Instance.LMBClick.MouseButtonUp += MouseUp;
            anim = gameObject.GetRequiredComponent<Animator>();
            anim.speed = 1f/fireDelay;
        }

        void MouseDown()
        {
            isFiring = true;
        }

        private void MouseUp()
        {
            isFiring = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (isFiring)
                FireRound();
        }

        void FireRound()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireDelay;
                Instantiate(ammo, transform.position + (transform.up.normalized * projectileOffset), transform.rotation);
                anim.SetTrigger("Fire");
            }
        }
    }

}
