using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.SquadronLeader
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        protected ShipClass shipType;
        public ShipClass Type { get { return shipType; } } 

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