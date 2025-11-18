using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelControl : MonoBehaviour
{
    public static bool enterPortal = false;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject fadeIn;
    public static bool isCutscene2 = false;
    [SerializeField] GameObject cutscene2;

    void Update()
    {  
        if (enterPortal == true)
        {
            fadeIn.SetActive(true);
            StartCoroutine(Transition());
            SceneManager.LoadScene(1);
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
