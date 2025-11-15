using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public static bool enterPortal = false;

    void Start()
    {

    }

    void Update()
    {
        if (enterPortal == true)
        {
            SceneManager.LoadScene(1);
        } 
    }
}
