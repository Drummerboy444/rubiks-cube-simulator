using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 0;
    
    private CubeController cubeController;

    private void Start()
    {
        cubeController = FindObjectOfType<CubeController>();

        cubeController.MoveSubject.Subscribe(HandleAnimation);
    }

    private void HandleAnimation(Move move)
    {
        MoveData moveData = MoveDataLookup.Get(move);
        
        foreach (string label in moveData.Labels)
        {
            Face face = cubeController.GetFace(label);
            face.transform.RotateAround(
                Vector3.zero,
                moveData.RotationAxis,
                -moveData.RotationAngle
            );

            StartCoroutine(Animate(face, moveData));
        }
    }

    private IEnumerator Animate(Face face, MoveData moveData)
    {
        int angle = moveData.RotationAngle;

        while (angle > 0)
        {
            face.transform.RotateAround(
                Vector3.zero,
                moveData.RotationAxis,
                1
            );
            yield return new WaitForSeconds(1 / degreesPerSecond);
            angle--;
        }
    }
}
