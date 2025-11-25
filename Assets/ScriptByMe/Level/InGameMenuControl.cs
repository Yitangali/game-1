using UnityEngine;

public class InGameMenuControl : MonoBehaviour
{
    [SerializeField] GameObject InGameMenuWindow;

    [SerializeField] GameObject AllMenu;
    [SerializeField] GameObject VeilInventory;
    //[SerializeField] GameObject ItemInventory;

    public bool isOnAllMenu = true;
    public bool isOnVeilInvenotry = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOnVeilInvenotry==true)
        {   
            ReturnToAllMenu();
        }
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1.0f;
        isOnAllMenu = false;
        Level1Control.isOnMainMenu = false;
        InGameMenuWindow.SetActive(false);
    }

    public void ReturnToAllMenu()
    {
        isOnAllMenu=true;
        VeilInventory.SetActive(false);
        AllMenu.SetActive(true);
    }

    public void EnterVeilInventory()
    {
        isOnAllMenu=false;
        isOnVeilInvenotry=true;
        AllMenu.SetActive(false);
        VeilInventory.SetActive(true);
    }
}
