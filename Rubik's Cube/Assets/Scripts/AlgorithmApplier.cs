using UnityEngine;

public class AlgorithmApplier : MonoBehaviour
{
    private CubeController cubeController;

    private void Start()
    {
        cubeController = FindObjectOfType<CubeController>();
    }

    public void Apply(string algorithm)
    {
        foreach (string token in algorithm.Split(' '))
        {
            switch (token.Length)
            {
                case 1:
                    HandleLength1Token(token);
                    break;
                case 2:
                    HandleLength2Token(token);
                    break;
            }
        }
    }

    private void HandleLength1Token(string token)
    {
        switch (token[0])
        {
            case 'U':
                cubeController.MakeMove(Move.Up);
                break;
            case 'D':
                cubeController.MakeMove(Move.Down);
                break;
            case 'L':
                cubeController.MakeMove(Move.Left);
                break;
            case 'R':
                cubeController.MakeMove(Move.Right);
                break;
            case 'F':
                cubeController.MakeMove(Move.Front);
                break;
            case 'B':
                cubeController.MakeMove(Move.Back);
                break;
        }
    }

    private void HandleLength2Token(string token)
    {
        if (token[1] == '\'')
        {
            HandleInvertToken(token);
        }
        else
        {
            HandleRepeatToken(token);
        }
    }

    private void HandleInvertToken(string token)
    {
        switch (token[0])
        {
            case 'U':
                cubeController.MakeMove(Move.UpInverted);
                break;
            case 'D':
                cubeController.MakeMove(Move.DownInverted);
                break;
            case 'L':
                cubeController.MakeMove(Move.LeftInverted);
                break;
            case 'R':
                cubeController.MakeMove(Move.RightInverted);
                break;
            case 'F':
                cubeController.MakeMove(Move.FrontInverted);
                break;
            case 'B':
                cubeController.MakeMove(Move.BackInverted);
                break;
        }
    }

    private void HandleRepeatToken(string token)
    {
        int times = int.Parse(token[1].ToString());
        
        switch (token[0])
        {
            case 'U':
                cubeController.MakeMove(Move.Up2);
                break;
            case 'D':
                cubeController.MakeMove(Move.Down2);
                break;
            case 'L':
                cubeController.MakeMove(Move.Left2);
                break;
            case 'R':
                cubeController.MakeMove(Move.Right2);
                break;
            case 'F':
                cubeController.MakeMove(Move.Front2);
                break;
            case 'B':
                cubeController.MakeMove(Move.Back2);
                break;
        }
    }
}
