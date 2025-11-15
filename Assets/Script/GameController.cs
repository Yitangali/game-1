using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Transactions;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour
{

    private List<FighterStats> fighterStats;

    [SerializeField]
    private GameObject battleMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();
    }

    // Update is called once per frame
    public void NextTurn()
    {
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if(!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Hero")
            {
                this.battleMenu.SetActive(true);
            } else
            {
                string attackType = Random.Range(0, 2) == 1 ? "Melee" : "Range";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        } else
        {
            NextTurn(); 
        }
    }
}
