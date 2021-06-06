using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private CubeController cubeController;

    private void Start()
    {
        cubeController = FindObjectOfType<CubeController>();
    }
}
