using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Dices;
    public bool GameReady = false;
    public int Score = 0;
    public float DiceFacingBias = 0.99f;

    void Update()
    {
        Restart();

        bool AllDicesResting = true;

        foreach (GameObject Dice in Dices)
        {
            if (!Dice.GetComponent<Rigidbody>().IsSleeping())
                AllDicesResting = false;
        }

        GameReady = AllDicesResting;

        if (AllDicesResting)
        {
            // TODO: Show Score
            foreach (GameObject Dice in Dices)
            {
                if (Vector3.Dot(Dice.transform.forward, Vector3.up) >= DiceFacingBias)
                {
                    Score += 1;
                }
                else if (Vector3.Dot(-Dice.transform.forward, Vector3.up) >= DiceFacingBias)
                {
                    Score += 6;
                }
                else if (Vector3.Dot(Dice.transform.right, Vector3.up) >= DiceFacingBias)
                {
                    Score += 4;
                }
                else if (Vector3.Dot(-Dice.transform.right, Vector3.up) >= DiceFacingBias)
                {
                    Score += 3;
                }
                else if (Vector3.Dot(Dice.transform.up, Vector3.up) >= DiceFacingBias)
                {
                    Score += 5;
                }
                else if (Vector3.Dot(-Dice.transform.up, Vector3.up) >= DiceFacingBias)
                {
                    Score += 2;
                }
                else
                {
                    Debug.Log("Facing no side!");
                    Restart();
                    return;
                }
            }
        }
    }
    void Restart()
    {
        GameReady = false;
        Score = 0;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
