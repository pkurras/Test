using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Dices;
    public bool GameReady = false;
    public int Score = 0;

    void Update()
    {
        bool AllDicesStatic = true;
        foreach (GameObject Dice in Dices)
        {
            if (!Dice.GetComponent<Rigidbody>().IsSleeping())
                AllDicesStatic = false;
        }
        GameReady = AllDicesStatic;

        if (GameReady)
        {
            Score = 0;
            // TODO: Show Score
            foreach (GameObject Dice in Dices)
            {
                // Localspace forward/backward
                if (Vector3.Dot(Dice.transform.forward, Vector3.up) >= 0.9)
                {
                    Score += 1;
                }
                if (Vector3.Dot(-Dice.transform.forward, Vector3.up) >= 0.9)
                {
                    Score += 6;
                }

                // Localspace right/left
                if (Vector3.Dot(Dice.transform.right, Vector3.up) >= 0.9)
                {
                    Score += 4;
                }
                if (Vector3.Dot(-Dice.transform.right, Vector3.up) >= 0.9)
                {
                    Score += 3;
                }

                // Localspace up/dow
                if (Vector3.Dot(Dice.transform.up, Vector3.up) >= 0.9)
                {
                    Score += 5;
                }
                if (Vector3.Dot(-Dice.transform.up, Vector3.up) >= 0.9)
                {
                    Score += 2;
                }
            }
        }
    }
}
