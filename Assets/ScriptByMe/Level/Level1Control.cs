using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Level1Control : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    public static bool isOnMainMenu = false;
    public static bool enterPortal = false;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject fadeIn;
    public static bool isOnCutscene = true;
    //[SerializeField] GameObject cutscene1;
    [SerializeField] GameObject cutscene2;
    [SerializeField] GameObject level1Theme;
    [SerializeField] GameObject cutscene1Theme;

    void Update()
    {  
        if (enterPortal == true)
        {
            fadeIn.SetActive(true);
            StartCoroutine(Transition());
            SceneManager.LoadScene(2);
            enterPortal = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isOnMainMenu == false )//&& isOnCutscene == false)
        {
            Time.timeScale = 0;
            MainMenu.SetActive(true);
            isOnMainMenu=true;
        }
        //else if (Input.GetKeyDown(KeyCode.Escape) && isOnMainMenu == true)
        //{
        //    Time.timeScale = 1;
        //    MainMenu.SetActive(false);
        //    isOnMainMenu=false;
        //}

        if(!level1Theme.GetComponent<AudioSource>().isPlaying && isOnCutscene == false)
        {
            level1Theme.GetComponent<AudioSource>().Play();
        }

        if (!cutscene1Theme.GetComponent<AudioSource>().isPlaying && isOnCutscene == true)
        {
            cutscene1Theme.GetComponent<AudioSource>().Play();
        }
        else if (cutscene1Theme.GetComponent<AudioSource>().isPlaying && isOnCutscene == false)
        {
            cutscene1Theme.GetComponent<AudioSource>().Stop();
        }

        //if (isCutscene2 == true)
        //{
        //    cutscene2.SetActive(true);
        //    isCutscene2 = false;
        //}
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(3);
    }
}
