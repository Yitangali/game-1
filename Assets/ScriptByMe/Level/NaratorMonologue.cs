using System.Collections;
using UnityEngine;
using TMPro;

public class NaratorMonologue : MonoBehaviour
{
    public TextMeshProUGUI textComponentNarator;
    public string[] linesNarator;
    public float textSpeedNarator;
    public GameObject dialogueBoxNarator;
    public GameObject playerControlNarator;
    public GameObject cameraNarator;
    public GameObject fadeOutNarator;
    public GameObject blackScreenNarator;

    [SerializeField] GameObject cutscene2;

    private int indexNarator;
    private bool hasTalkedNarator = false; // <--- Tambahkan ini

    void Start()
    {
        textComponentNarator.text = string.Empty;
        startMonologue();
        playerControlNarator.GetComponent<PlayerControl2>().enabled = false;
        cameraNarator.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponentNarator.text == linesNarator[indexNarator])
            {
                NextLineNarator();
            }
            else
            {
                StopAllCoroutines();
                textComponentNarator.text = linesNarator[indexNarator];
            }
        }
    }

    void startMonologue()
    {
        indexNarator = 0;
        StartCoroutine(TypeLineNarator());
    }

    IEnumerator TypeLineNarator()
    {
        foreach (char c in linesNarator[indexNarator].ToCharArray())
        {
            textComponentNarator.text += c;
            yield return new WaitForSeconds(textSpeedNarator);
        }
    }

    void NextLineNarator()
    {
        if (indexNarator < linesNarator.Length - 1)
        {
            indexNarator++;
            textComponentNarator.text = string.Empty;
            StartCoroutine(TypeLineNarator());
        }
        else
        {
            // hanya kurangi emotion kalau belum pernah diajak bicara
            //if (!hasTalkedNarator)
            //{
            //    EmotionMeter.emotionCollected += 50f;
            //    hasTalked = true; // tandai sudah bicara
            //    Debug.Log("less Sad!");
            //}

            dialogueBoxNarator.SetActive(false);
            blackScreenNarator.SetActive(false);
            fadeOutNarator.SetActive(true);
            StartCoroutine(Wait());
            playerControlNarator.GetComponent<PlayerControl2>().enabled = true;
            cameraNarator.SetActive(true);
            //LevelControl.isCutscene2 = true;
            cutscene2.SetActive(true);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
