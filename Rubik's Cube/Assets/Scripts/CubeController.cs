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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) Up();
        if (Input.GetKeyDown(KeyCode.F)) Front();
        if (Input.GetKeyDown(KeyCode.D)) Down();
        if (Input.GetKeyDown(KeyCode.L)) Left();
        if (Input.GetKeyDown(KeyCode.R)) Right();
        if (Input.GetKeyDown(KeyCode.B)) Back();
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

    private void Up()
    {
        CycleColours("U1", "U3", "U9", "U7");
        CycleColours("U2", "U6", "U8", "U4");
        CycleColours("F1", "L1", "B1", "R1");
        CycleColours("F2", "L2", "B2", "R2");
        CycleColours("F3", "L3", "B3", "R3");
    }

    private void Front()
    {
        
    }

    private void Down()
    {
        
    }

    private void Left()
    {
        
    }

    private void Right()
    {
        
    }

    private void Back()
    {
        
    }

    private void CycleColours(params string[] labels)
    {
        Dictionary<Face, Colour> faceToNewColourLookup = new Dictionary<Face, Colour>();

        for (int i = 0; i < labels.Length; i++)
        {
            Face face1 = labelToFaceLookup[labels[i]];
            Face face2 = labelToFaceLookup[labels[(i + 1) % labels.Length]];
            faceToNewColourLookup[face2] = face1.Colour;
        }
        
        foreach (KeyValuePair<Face,Colour> kvp in faceToNewColourLookup)
        {
            kvp.Key.Colour = kvp.Value;
        }
    }
}
