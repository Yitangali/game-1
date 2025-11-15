using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private bool physical;

    private GameObject hero;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("MeleeBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Melee");
        } else if (btn.CompareTo("DeffenseBtn") == 0)
       {
            hero.GetComponent<FighterAction>().SelectAttack("Deffense");
        } else
        {
            //debug.log
        } 
    }
}
