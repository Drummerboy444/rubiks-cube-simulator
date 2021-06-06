using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private CubeController cubeController;
    [SerializeField] private int degreesPerUpdate = 0;

    private Move currentMove = default;
    private int remainingDegrees = 0;

    private bool Animating => remainingDegrees > 0;

    private void Start()
    {
        cubeController.MoveSubject.Subscribe(HandleAnimation);
    }

    private void Update()
    {
        if (!Animating) return;

        RotateFaces(currentMove, degreesPerUpdate);
        remainingDegrees -= degreesPerUpdate;
    }

    private void HandleAnimation(Move move)
    {
        MoveData moveData = MoveDataLookup.Get(move);
        
        foreach (string label in moveData.Labels)
        {
            if (Animating) CancelCurrentAnimation();
            
            Face face = cubeController.GetFace(label);
            face.transform.RotateAround(
                Vector3.zero,
                moveData.RotationAxis,
                -moveData.RotationAngle
            );

            currentMove = move;
            remainingDegrees = moveData.RotationAngle;
        }
    }

    private void CancelCurrentAnimation()
    {
        RotateFaces(currentMove, remainingDegrees);
    }

    private void RotateFaces(Move move, int angle)
    {
        MoveData moveData = MoveDataLookup.Get(move);
        
        foreach (string label in moveData.Labels)
        {
            cubeController.GetFace(label).transform.RotateAround(
                Vector3.zero,
                moveData.RotationAxis,
                angle
            );
        }
    }
}
