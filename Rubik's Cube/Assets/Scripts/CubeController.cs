using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private readonly Dictionary<string, Face> labelToFaceLookup = new Dictionary<string, Face>();

    public Subject<Move> MoveSubject { get; } = new Subject<Move>();

    private void Start()
    {
        foreach (Face face in FindObjectsOfType<Face>())
        {
            string label = face.name;
            labelToFaceLookup[label] = face;
            face.Colour = ColourLookup.GetStartingColour(label);
        }
    }

    public void MakeMove(Move move)
    {
        foreach (string[] cycle in MoveDataLookup.Get(move).Cycles) Cycle(cycle);
        MoveSubject.Next(move);
    }

    public Face GetFace(string label) => labelToFaceLookup[label];

    private void Up()
    {
        Cycle("U1", "U3", "U9", "U7");
        Cycle("U2", "U6", "U8", "U4");
        Cycle("F1", "L1", "B1", "R1");
        Cycle("F2", "L2", "B2", "R2");
        Cycle("F3", "L3", "B3", "R3");
    }

    private void Down()
    {
        Cycle("D1", "D3", "D9", "D7");
        Cycle("D2", "D6", "D8", "D4");
        Cycle("F7", "R7", "B7", "L7");
        Cycle("F8", "R8", "B8", "L8");
        Cycle("F9", "R9", "B9", "L9");
    }

    private void Left()
    {
        Cycle("L1", "L3", "L9", "L7");
        Cycle("L2", "L6", "L8", "L4");
        Cycle("U1", "F1", "D1", "B9");
        Cycle("U4", "F4", "D4", "B6");
        Cycle("U7", "F7", "D7", "B3");
    }

    private void Right()
    {
        Cycle("R1", "R3", "R9", "R7");
        Cycle("R2", "R6", "R8", "R4");
        Cycle("U3", "B7", "D3", "F3");
        Cycle("U6", "B4", "D6", "F6");
        Cycle("U9", "B1", "D9", "F9");
    }

    private void Front()
    {
        Cycle("F1", "F3", "F9", "F7");
        Cycle("F2", "F6", "F8", "F4");
        Cycle("U7", "R1", "D3", "L9");
        Cycle("U8", "R4", "D2", "L6");
        Cycle("U9", "R7", "D1", "L3");
    }

    private void Back()
    {
        Cycle("B1", "B3", "B9", "B7");
        Cycle("B2", "B6", "B8", "B4");
        Cycle("U1", "L7", "D9", "R3");
        Cycle("U2", "L4", "D8", "R6");
        Cycle("U3", "L1", "D7", "R9");
    }

    private void Cycle(params string[] labels)
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
