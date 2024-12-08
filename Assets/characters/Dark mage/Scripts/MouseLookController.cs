using UnityEngine;

public class MouseLookController : MonoBehaviour
{
   
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;

   
    public float minYAngle = -40f;
    public float maxYAngle = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        
        rotationX += mouseX;
        rotationY -= mouseY;

       
        rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

       
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
