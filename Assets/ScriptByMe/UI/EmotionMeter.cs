using UnityEngine;
using UnityEngine.UI;

public class EmotionMeter : MonoBehaviour
{
    public Image emotionMeter;
    public float totalEmotion = 100f;
    public static float emotionCollected = 0f;
    
    void Start()
    {
        emotionMeter.fillAmount = totalEmotion / 100f; 
    }

    void Update()
    {
        if(emotionCollected > 0f)
        {
            totalEmotion -= emotionCollected;
            emotionCollected = 0f;
            totalEmotion = Mathf.Clamp(totalEmotion, 0f, 100f);
            emotionMeter.fillAmount = totalEmotion / 100f;
        }
    }
}
