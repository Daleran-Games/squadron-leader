using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.SquadronLeader
{
    public class MouseSteering : MonoBehaviour
    {
        

        [SerializeField]
        [Range(0f,1f)]
        float stopCursorDistance = 0.1f;
        [SerializeField]
        [Range(0f, 1f)]
        float maxSpeedCursorDistance = 0.8f;

        Rigidbody2D rb;
        Ship ship;

        private void Awake()
        {
            if (stopCursorDistance >= maxSpeedCursorDistance)
                Debug.Log("Error: Stop Cursor Distance cannot be greater than the max speed cursor distance");

            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
