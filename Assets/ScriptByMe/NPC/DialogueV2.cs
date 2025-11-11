using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueV2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject dialogueBox;
    public GameObject playerControl;
    public GameObject camera;

    private int index;
    private bool hasTalked = false; // <--- Tambahkan ini

    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
        playerControl.GetComponent<PlayerControl2>().enabled = false;
        camera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // hanya kurangi emotion kalau belum pernah diajak bicara
            if (!hasTalked)
            {
                EmotionMeter.emotionCollected += 50f;
                hasTalked = true; // tandai sudah bicara
                Debug.Log("less Sad!");
            }

            dialogueBox.SetActive(false);
            playerControl.GetComponent<PlayerControl2>().enabled = true;
            camera.SetActive(true);
        }
    }
}
