using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1.2f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }
}
