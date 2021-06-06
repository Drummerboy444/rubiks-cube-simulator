using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Dictionary<Move, Action> moveLookup;
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
        
        moveLookup = new Dictionary<Move, Action>
        {
            [global::Move.Up] = Up,
            [global::Move.UpInverted] = UpInverted,
            [global::Move.Down] = Down,
            [global::Move.DownInverted] = DownInverted,
            [global::Move.Left] = Left,
            [global::Move.LeftInverted] = LeftInverted,
            [global::Move.Right] = Right,
            [global::Move.RightInverted] = RightInverted,
            [global::Move.Front] = Front,
            [global::Move.FrontInverted] = FrontInverted,
            [global::Move.Back] = Back,
            [global::Move.BackInverted] = BackInverted,
        };
    }

    public void Move(Move move)
    {
        moveLookup[move]();
        MoveSubject.Next(move);
    }

    private void Up()
    {
        CycleColours("U1", "U3", "U9", "U7");
        CycleColours("U2", "U6", "U8", "U4");
        CycleColours("F1", "L1", "B1", "R1");
        CycleColours("F2", "L2", "B2", "R2");
        CycleColours("F3", "L3", "B3", "R3");
    }

    private void UpInverted()
    {
        Utils.Repeat(3, Up);
    }

    private void Down()
    {
        CycleColours("D1", "D3", "D9", "D7");
        CycleColours("D2", "D6", "D8", "D4");
        CycleColours("F7", "R7", "B7", "L7");
        CycleColours("F8", "R8", "B8", "L8");
        CycleColours("F9", "R9", "B9", "L9");
    }

    private void DownInverted()
    {
        Utils.Repeat(3, Down);
    }

    private void Left()
    {
        CycleColours("L1", "L3", "L9", "L7");
        CycleColours("L2", "L6", "L8", "L4");
        CycleColours("U1", "F1", "D1", "B9");
        CycleColours("U4", "F4", "D4", "B6");
        CycleColours("U7", "F7", "D7", "B3");
    }

    private void LeftInverted()
    {
        Utils.Repeat(3, Left);
    }

    private void Right()
    {
        CycleColours("R1", "R3", "R9", "R7");
        CycleColours("R2", "R6", "R8", "R4");
        CycleColours("U3", "B7", "D3", "F3");
        CycleColours("U6", "B4", "D6", "F6");
        CycleColours("U9", "B1", "D9", "F9");
    }

    private void RightInverted()
    {
        Utils.Repeat(3, Right);
    }

    private void Front()
    {
        CycleColours("F1", "F3", "F9", "F7");
        CycleColours("F2", "F6", "F8", "F4");
        CycleColours("U7", "R1", "D3", "L9");
        CycleColours("U8", "R4", "D2", "L6");
        CycleColours("U9", "R7", "D1", "L3");
    }

    private void FrontInverted()
    {
        Utils.Repeat(3, Front);
    }

    private void Back()
    {
        CycleColours("B1", "B3", "B9", "B7");
        CycleColours("B2", "B6", "B8", "B4");
        CycleColours("U1", "L7", "D9", "R3");
        CycleColours("U2", "L4", "D8", "R6");
        CycleColours("U3", "L1", "D7", "R9");
    }

    private void BackInverted()
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
