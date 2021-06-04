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
                cubeController.Up();
                break;
            case 'D':
                cubeController.Down();
                break;
            case 'L':
                cubeController.Left();
                break;
            case 'R':
                cubeController.Right();
                break;
            case 'F':
                cubeController.Front();
                break;
            case 'B':
                cubeController.Back();
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
                cubeController.UpInverted();
                break;
            case 'D':
                cubeController.DownInverted();
                break;
            case 'L':
                cubeController.LeftInverted();
                break;
            case 'R':
                cubeController.RightInverted();
                break;
            case 'F':
                cubeController.FrontInverted();
                break;
            case 'B':
                cubeController.BackInverted();
                break;
        }
    }

    private void HandleRepeatToken(string token)
    {
        int times = int.Parse(token[1].ToString());
        
        switch (token[0])
        {
            case 'U':
                Utils.Repeat(times, () => cubeController.Up());
                break;
            case 'D':
                Utils.Repeat(times, () => cubeController.Down());
                break;
            case 'L':
                Utils.Repeat(times, () => cubeController.Left());
                break;
            case 'R':
                Utils.Repeat(times, () => cubeController.Right());
                break;
            case 'F':
                Utils.Repeat(times, () => cubeController.Front());
                break;
            case 'B':
                Utils.Repeat(times, () => cubeController.Back());
                break;
        }
    }
}
