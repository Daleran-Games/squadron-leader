using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.SquadronLeader
{
    [CreateAssetMenu(fileName ="NewShipClass",menuName ="Squadron Commander/Ship Class",order = 1)]
    public class ShipClass : ScriptableObject 
    {

        [Header("Information")]
        [SerializeField]
        string className = "Default Ship Class";
        public string ClassName { get { return className; } }
        [SerializeField]
        ShipType type = ShipType.Fighter;
        public ShipType Type { get { return type; } }

        
        [Header("Movement")]
        [SerializeField]
        float maxSpeed = 10f;
        public float MaxSpeed { get { return maxSpeed; } }
        [SerializeField]
        float turningForce = 0.2f;
        public float TurningForce { get { return turningForce; } }
        [SerializeField]
        float rotationSpeed = 5f;
        public float RotationSpeed { get { return rotationSpeed; } }



    }

    public enum ShipType
    {
        Fighter,
        Capital
    }
}

