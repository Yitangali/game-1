using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform HeroKnight;

    private void Start()
    {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-0.94f, 0f);
        } else
        {
            position = new Vector3(+0.94f, 0f);
        }
        Instantiate(HeroKnight, position, Quaternion.identity);
    }
}
