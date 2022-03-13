using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Enenmy_Manager enemys;
    // private MysteryShip mysteryShip;
    //private Bunker[] bunkers;

    //public GameObject gameOverUI;
    public TMP_Text scoreText;
    public TMP_Text HI_Score;

    public int score { get; private set; }
    public int hi_score { get; private set; }


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemys = FindObjectOfType<Enenmy_Manager>();
        //mysteryShip = FindObjectOfType<MysteryShip>();
        //bunkers = FindObjectsOfType<Bunker>();
    }


    // Start is called before the first frame update
    void Start()
    {
        DisplayScore(0);

        //player.killed += OnPlayerKilled;
        //mysteryShip.killed += OnMysteryShipKilled;
        enemys.killed += OnEnemyKilled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayScore(int scoreTD)
    {


        this.score = scoreTD;
        scoreText.text = score.ToString().PadLeft(4, '0');
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        DisplayScore(score + enemy.score);

        /**
        if (enemy.amountKilled == enemy.totalAmount)
        {
            NewRound();
        }
    */
    }


}
