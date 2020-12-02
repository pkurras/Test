using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Dices;
    public List<int> ScoreList;
    public bool GameReady = false;
    public float DiceFacingBias = 0.99f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var Dice in Dices)
                Dice.GetComponent<DiceMovement>().enabled = false;
            GameReady = true;
        }

        bool AllDicesResting = true;
        foreach (GameObject Dice in Dices)
        {
            if (!Dice.GetComponent<Rigidbody>().IsSleeping())
                AllDicesResting = false;
        }

        if (AllDicesResting && GameReady)
        {
            CalculateScore();
            GameReady = false;
        }
    }
    void CalculateScore()
    {
        int Score = 0;
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
                RestartRound();
                return;
            }
        }
        ScoreList.Add(Score);
        RestartRound();
    }
    public void RestartRound()
    {
        foreach (var Dice in Dices)
        {
            Dice.GetComponent<DiceMovement>().enabled = true;
            Dice.GetComponent<DiceMovement>().Reset();
        }
    }
    public void RestartGame()
    {
        ScoreList.Clear();
        RestartRound();
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
