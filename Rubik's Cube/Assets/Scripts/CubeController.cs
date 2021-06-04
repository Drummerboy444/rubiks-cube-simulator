using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private readonly Dictionary<string, Face> labelToFaceLookup = new Dictionary<string, Face>();

    private void Start()
    {
        foreach (Face face in FindObjectsOfType<Face>())
        {
            string label = face.name;
            labelToFaceLookup[label] = face;
            face.Colour = GetStartingColour(label);
        }
    }

    private Colour GetStartingColour(string label)
    {
        return label[0] switch
        {
            'U' => Colour.Green,
            'F' => Colour.Yellow,
            'D' => Colour.Blue,
            'L' => Colour.Black,
            'R' => Colour.Red,
            'B' => Colour.White,
            _ => default
        };
    }
}
