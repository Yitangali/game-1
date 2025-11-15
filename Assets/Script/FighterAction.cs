using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject Enemy;
    private GameObject Hero;

    [SerializeField] 
    private GameObject meleePrefab;

    [SerializeField]
    GameObject rangedPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    private GameObject meleeAttack;
    private GameObject rangedAttack;

    void Awake()
    {
        Hero = GameObject.FindGameObjectWithTag("Hero");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = Hero;
        if(tag == "Hero")
        {
            victim = Enemy;
        }
        if (btn.CompareTo("Melee") == 0)
        {
            meleePrefab.GetComponent<AttackScript>().Attack(victim);

        }else if (btn.CompareTo("Range") == 0)
        {
            rangedPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        
    }
}
