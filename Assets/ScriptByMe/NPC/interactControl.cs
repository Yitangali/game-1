using UnityEngine;

public class InteractControl : MonoBehaviour
{

    [SerializeField] GameObject interactUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        interactUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactUI.SetActive(false);
    }
}
