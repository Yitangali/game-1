using UnityEngine;

public class NPCinteractable : MonoBehaviour
{   
    [SerializeField] GameObject dialogueBox;
    public void Interact()
    {
        //Debug.Log("Interact!");
        dialogueBox.SetActive(true);
    }
}
