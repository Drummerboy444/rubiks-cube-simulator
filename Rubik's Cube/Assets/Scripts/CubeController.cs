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
            face.Colour = ColourLookup.GetStartingColour(label);
        }
    }

    public void Up()
    {
        CycleColours("U1", "U3", "U9", "U7");
        CycleColours("U2", "U6", "U8", "U4");
        CycleColours("F1", "L1", "B1", "R1");
        CycleColours("F2", "L2", "B2", "R2");
        CycleColours("F3", "L3", "B3", "R3");
    }

    public void UpInverted()
    {
        Utils.Repeat(3, Up);
    }

    public void Down()
    {
        CycleColours("D1", "D3", "D9", "D7");
        CycleColours("D2", "D6", "D8", "D4");
        CycleColours("F7", "R7", "B7", "L7");
        CycleColours("F8", "R8", "B8", "L8");
        CycleColours("F9", "R9", "B9", "L9");
    }

    public void DownInverted()
    {
        Utils.Repeat(3, Down);
    }

    public void Left()
    {
        CycleColours("L1", "L3", "L9", "L7");
        CycleColours("L2", "L6", "L8", "L4");
        CycleColours("U1", "F1", "D1", "B9");
        CycleColours("U4", "F4", "D4", "B6");
        CycleColours("U7", "F7", "D7", "B3");
    }

    public void LeftInverted()
    {
        Utils.Repeat(3, Left);
    }

    public void Right()
    {
        CycleColours("R1", "R3", "R9", "R7");
        CycleColours("R2", "R6", "R8", "R4");
        CycleColours("U3", "B7", "D3", "F3");
        CycleColours("U6", "B4", "D6", "F6");
        CycleColours("U9", "B1", "D9", "F9");
    }

    public void RightInverted()
    {
        Utils.Repeat(3, Right);
    }

    public void Front()
    {
        CycleColours("F1", "F3", "F9", "F7");
        CycleColours("F2", "F6", "F8", "F4");
        CycleColours("U7", "R1", "D3", "L9");
        CycleColours("U8", "R4", "D2", "L6");
        CycleColours("U9", "R7", "D1", "L3");
    }

    public void FrontInverted()
    {
        Utils.Repeat(3, Front);
    }

    public void Back()
    {
        CycleColours("B1", "B3", "B9", "B7");
        CycleColours("B2", "B6", "B8", "B4");
        CycleColours("U1", "L7", "D9", "R3");
        CycleColours("U2", "L4", "D8", "R6");
        CycleColours("U3", "L1", "D7", "R9");
    }

    public void BackInverted()
    {
        Utils.Repeat(3, Back);
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
