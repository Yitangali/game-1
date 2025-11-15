using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public bool isNearPortal = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isNearPortal == true)
        {
            LevelControl.enterPortal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isNearPortal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNearPortal = false;
    }
}
