using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DaleranGames.SquadronLeader
{
    public class SpeedCursor : MonoBehaviour
    {
        [Header("Position Settings")]
        [SerializeField]
        float distanceFromCursor = 32f;
        [SerializeField]
        MouseSteering trackedShip;

        [Header("Speed Indicators")]
        [SerializeField]
        Sprite stopSprite;
        [SerializeField]
        Color32 stopColor = ColorExtensions.white;
        [SerializeField]
        Sprite slowSprite;
        [SerializeField]
        Color32 slowColor = ColorExtensions.white;
        [SerializeField]
        Sprite medSprite;
        [SerializeField]
        Color32 medColor = ColorExtensions.white;
        [SerializeField]
        Sprite maxSprite;
        [SerializeField]
        Color32 maxColor = ColorExtensions.white;

        Image sprite;
        RectTransform rect;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void MoveToNewPosition()
        {

        }

        void CheckSpriteAndColor()
        {

        }
    }
}


