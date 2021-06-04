using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private CubeController cubeController = null;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) cubeController.Up();
        if (Input.GetKeyDown(KeyCode.F)) cubeController.Front();
        if (Input.GetKeyDown(KeyCode.D)) cubeController.Down();
        if (Input.GetKeyDown(KeyCode.L)) cubeController.Left();
        if (Input.GetKeyDown(KeyCode.R)) cubeController.Right();
        if (Input.GetKeyDown(KeyCode.B)) cubeController.Back();
    }
}
