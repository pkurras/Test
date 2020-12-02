using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Player 
{
    public Player() 
    { 
        scoreboard = new List<int>();
        name = "";
    }
    public string name;
    public List<int> scoreboard;
}
public class GameManager : MonoBehaviour
{
    public List<GameObject> Dices;
    public bool GameReady = false;
    public float DiceFacingBias = 0.99f;
    public Dictionary<int, Player> PlayerDB;
    private int PlayerCount = 0;
    public InputField PlayerString;
    private int CurrentPlayer;

    private void Start()
    {
        PlayerDB = new Dictionary<int, Player>();
        PlayerString.text = "Mr. X";
        AddPlayer();
    }
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
            CurrentPlayer++;
            CurrentPlayer %= PlayerCount;
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
        PlayerDB[CurrentPlayer].scoreboard.Add(Score);
        Debug.Log(PlayerDB[CurrentPlayer].name + "'s Score = " + PlayerDB[CurrentPlayer].scoreboard[PlayerDB[CurrentPlayer].scoreboard.Count-1]);
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
        for (int i = 0; i < PlayerCount; i++) 
        {
            PlayerDB[i].scoreboard.Clear();
        }
        CurrentPlayer = 0;
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
    public void AddPlayer()
    {
        var Player = new Player();
        Player.name = PlayerString.text;
        PlayerDB.Add(PlayerCount, Player);
        PlayerCount++;
    }
}
