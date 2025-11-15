using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
   // Set up references for player and enemy
   [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

   // Set up health values for player and enemy
   [SerializeField] int playerHealth = 10;
    [SerializeField] int maxPlayerHealth = 10;
    [SerializeField] int enemyHealth = 10;
    [SerializeField] int maxEnemyHealth = 10;

    // Set up UI elements connections: player health, enemy health, etc
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI enemyHealthText;
    [SerializeField] Button attackButton;

    // track which character's turn it is
    private bool playerTurn = true;

    // store original positions of player and enemy for "animation"
    private Vector3 playerStartPosition;
    private Vector3 enemyStartPosition;

    void Start()
    {
        playerStartPosition = player.transform.position;
        enemyStartPosition = enemy.transform.position;

        UpdateUI();

        playerTurn = true;

        attackButton.onClick.AddListener(PlayerAttack);
    }

    void PlayerAttack()
    {
        // If it's not the player's turn, do nothing
        if(!playerTurn)
        {
            return;
        }

        // start an attack animation
        StartCoroutine(DoAttack(player, enemy, () =>
        {
            // take damage from enemy
            enemyHealth -= 2;

            if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                UpdateUI();
                attackButton.interactable = false;
                Debug.Log("Enemy Defeated!");
                return;
            }

            //Otherwise, end players turn and start enemy turn after delay
            playerTurn = false;
            UpdateUI();
            Invoke(nameof(EnemyAttack), 1f);
        }));
    }

    void EnemyAttack()
{
    // call DoAttack with attacker = enemy, target = player, and damage logic in callback
    StartCoroutine(DoAttack(enemy, player, () =>
    {
        // take damage from player
        playerHealth -= 1;

        // if player health is <= 0, disable button, and show message
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            UpdateUI();
            attackButton.interactable = false;
            Debug.Log("Player Defeated!");
            return;
        }
        playerTurn = true;
        UpdateUI();
    }));  
}

IEnumerator DoAttack(GameObject attacker, GameObject target, System.Action onComplete)
{
    Vector3 attackerStart = (attacker == player) ? playerStartPosition : enemyStartPosition;
    Vector3 targetStart = (target == player) ? playerStartPosition : enemyStartPosition;

    Vector3 attackPos = attackerStart + (targetStart - attackerStart).normalized * 0.5f;
    Vector3 hitPushPos = targetStart + (targetStart - attackerStart).normalized * 0.3f;

    //move attacker forward
    yield return MoveOverTime(attacker, attackerStart, attackPos, 0.1f);
    yield return MoveOverTime(attacker, attackPos, attackerStart, 0.1f);
    yield return MoveOverTime(target, targetStart, hitPushPos, 0.05f);
    yield return MoveOverTime(target, hitPushPos, targetStart, 0.1f);
    onComplete?.Invoke();
}

IEnumerator MoveOverTime(GameObject obj, Vector3 startPosition, Vector3 endPosition, float duration)
{
    float elapsed = 0f;
    while (elapsed < duration)
    {
        obj.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
    }
    obj.transform.position = endPosition;
}

void UpdateUI()
{
    playerHealthText.text = playerHealth + " / " + maxPlayerHealth;
    enemyHealthText.text = enemyHealth + " / " + maxEnemyHealth;
}

}


