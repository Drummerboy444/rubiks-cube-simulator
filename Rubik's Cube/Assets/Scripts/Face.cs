using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private new Renderer renderer = null;

    private Colour colour = default;
    public Colour Colour
    {
        get => colour;
        set
        {
            colour = value;
            renderer.material.color = ColourLookup.GetColor(colour);
        }
    }
}
