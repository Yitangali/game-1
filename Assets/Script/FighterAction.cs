using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject Enemy;
    private GameObject Hero;
    private GameController gameController; // <-- TAMBAHKAN INI

    [SerializeField] 
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        Hero = GameObject.FindGameObjectWithTag("Hero");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = Hero;
        if(tag == "Hero")
        {
            victim = Enemy;
            gameController.HideBattleMenu();
        }

        if (btn.CompareTo("Melee") == 0)
        {
            meleePrefab.GetComponent<AttackScript>().Attack(victim);

        } else if (btn.CompareTo("Range") == 0)
        {
            rangePrefab.GetComponent<AttackScript>().Attack(victim);
        } 
    }
}