using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private CubeController cubeController;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) cubeController.MakeMove(Move.Up);
        if (Input.GetKeyDown(KeyCode.D)) cubeController.MakeMove(Move.Down);
        if (Input.GetKeyDown(KeyCode.L)) cubeController.MakeMove(Move.Left);
        if (Input.GetKeyDown(KeyCode.R)) cubeController.MakeMove(Move.Right);
        if (Input.GetKeyDown(KeyCode.F)) cubeController.MakeMove(Move.Front);
        if (Input.GetKeyDown(KeyCode.B)) cubeController.MakeMove(Move.Back);
    }
}
