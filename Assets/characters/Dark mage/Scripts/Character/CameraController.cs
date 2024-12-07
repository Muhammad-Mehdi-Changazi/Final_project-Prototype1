using static scr_Models;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public scr_PlayerController playerController;
    private Vector3 targetRotation;
    public GameObject yGimbal;
    private Vector3 yGibalRotation;
    
    public float SensitivityX;
    public bool InvertedX;
    public float SensitivityY;
    public bool InvertedY;

    public float YClampMin = -40f;
    public float YClampMax = 40f;

    [Header("Character")]
    public float CharacterRotationSmoothdamp = 1f;
    
    
   // public CameraSettingsModel settings;



    private void Update()
    {
        CameraRotation();
        FollowPlayerCameraTarget();
    }
    

    private void CameraRotation()
    {
        var viewInput = playerController.input_View;

        targetRotation.y += (InvertedX ? -(viewInput.x * SensitivityX) : (viewInput.x * SensitivityX)) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(targetRotation);

        yGibalRotation.x += (InvertedY ? (viewInput.y * SensitivityY) : -(viewInput.y * SensitivityY)) * Time.deltaTime;
        yGibalRotation.x = Mathf.Clamp(yGibalRotation.x, YClampMin, YClampMax);

        yGimbal.transform.localRotation = Quaternion.Euler(yGibalRotation);

        if (playerController.isTargetMode)
        {
            var currentRotation = playerController.transform.rotation;

            var newRotation = currentRotation.eulerAngles;
            newRotation.y = targetRotation.y;

            currentRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(newRotation), CharacterRotationSmoothdamp);

            playerController.transform.rotation = currentRotation;
        }
    }

    private void FollowPlayerCameraTarget()
    {
        transform.position = playerController.cameraTarget.position;
    }
    
}