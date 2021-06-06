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
                cubeController.Move(Move.Up);
                break;
            case 'D':
                cubeController.Move(Move.Down);
                break;
            case 'L':
                cubeController.Move(Move.Left);
                break;
            case 'R':
                cubeController.Move(Move.Right);
                break;
            case 'F':
                cubeController.Move(Move.Front);
                break;
            case 'B':
                cubeController.Move(Move.Back);
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
                cubeController.Move(Move.UpInverted);
                break;
            case 'D':
                cubeController.Move(Move.DownInverted);
                break;
            case 'L':
                cubeController.Move(Move.LeftInverted);
                break;
            case 'R':
                cubeController.Move(Move.RightInverted);
                break;
            case 'F':
                cubeController.Move(Move.FrontInverted);
                break;
            case 'B':
                cubeController.Move(Move.BackInverted);
                break;
        }
    }

    private void HandleRepeatToken(string token)
    {
        int times = int.Parse(token[1].ToString());
        
        switch (token[0])
        {
            case 'U':
                Utils.Repeat(times, () => cubeController.Move(Move.Up));
                break;
            case 'D':
                Utils.Repeat(times, () => cubeController.Move(Move.Down));
                break;
            case 'L':
                Utils.Repeat(times, () => cubeController.Move(Move.Left));
                break;
            case 'R':
                Utils.Repeat(times, () => cubeController.Move(Move.Right));
                break;
            case 'F':
                Utils.Repeat(times, () => cubeController.Move(Move.Front));
                break;
            case 'B':
                Utils.Repeat(times, () => cubeController.Move(Move.Back));
                break;
        }
    }
}
