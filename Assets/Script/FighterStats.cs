using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator animator;


    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private Text battleText;
/*
    [SerializeField]
    private GameObject magicFill;
*/
    [Header("Stats")]
    public float health;
    public float magic;
    public float melee;
    public float defense;
    public float magicRange;
    public float speed;
    public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    // Resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    void Awake()
{
    healthTransform = healthFill.GetComponent<RectTransform>();
    healthScale = healthFill.transform.localScale; // Fixed
/*
    magicTransform = magicFill.GetComponent<RectTransform>();
    magicScale = magicFill.transform.localScale; // Fixed
*/
    startHealth = health;
    // startMagic = magic; 
}

public void ReceiveDamage(float damage)
{
    Debug.Log("Received Damage!!!");
    health = health - damage;
    animator.Play("Damage");

    // set damage text

    if(health <= 0)
    {
        dead = true;
        gameObject.tag = "dead"; // Fixed
        Destroy(healthFill);
        Destroy(gameObject); // Fixed
    } 
    else if (damage > 0)
    {
        xNewHealthScale = healthScale.x * (health / startHealth);
        healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y); // Fixed
    }

    Invoke("ContinueGame", 2);
}

    public bool GetDead()
    {
        return dead;
    }

    void ContinueGame()
    {
        GameObject.Find("GameController").GetComponent<GameController>().NextTurn();
    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStat)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStat).nextActTurn);
        return nex;
    }
}
