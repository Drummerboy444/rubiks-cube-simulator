using UnityEngine;

public class InputController : MonoBehaviour
{
    private CubeController cubeController;

    private void Start()
    {
        cubeController = FindObjectOfType<CubeController>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) cubeController.Move(Move.Up);
        if (Input.GetKeyDown(KeyCode.D)) cubeController.Move(Move.Down);
        if (Input.GetKeyDown(KeyCode.L)) cubeController.Move(Move.Left);
        if (Input.GetKeyDown(KeyCode.R)) cubeController.Move(Move.Right);
        if (Input.GetKeyDown(KeyCode.F)) cubeController.Move(Move.Front);
        if (Input.GetKeyDown(KeyCode.B)) cubeController.Move(Move.Back);
    }
}
