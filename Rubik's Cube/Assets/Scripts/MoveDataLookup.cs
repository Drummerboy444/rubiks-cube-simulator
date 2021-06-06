using System.Collections.Generic;
using UnityEngine;

public static class MoveDataLookup
{
    private static readonly Dictionary<Move, MoveData> moveDataLookup = new Dictionary<Move, MoveData>
    {
        [Move.Up] = new MoveData
        {
            AlgorithmNotation = "U",
            Cycles = new []
            {
                new []{ "U1", "U3", "U9", "U7" },
                new []{ "U2", "U6", "U8", "U4" },
                new []{ "F1", "L1", "B1", "R1" },
                new []{ "F2", "L2", "B2", "R2" },
                new []{ "F3", "L3", "B3", "R3" },
            },
            Labels = new []
            {
                "U1", "U2", "U3", "U4", "U5", "U6", "U7", "U8", "U9",
                "L1", "L2", "L3",
                "R1", "R2", "R3",
                "F1", "F2", "F3",
                "B1", "B2", "B3",
            },
            RotationAxis = new Vector3(0, 1, 0),
            RotationAngle = 90,
        },
        [Move.Down] = new MoveData
        {
            AlgorithmNotation = "D",
            Cycles = new []
            {
                new []{ "D1", "D3", "D9", "D7" },
                new []{ "D2", "D6", "D8", "D4" },
                new []{ "F7", "R7", "B7", "L7" },
                new []{ "F8", "R8", "B8", "L8" },
                new []{ "F9", "R9", "B9", "L9" },
            },
            Labels = new []
            {
                "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9",
                "L7", "L8", "L9",
                "R7", "R8", "R9",
                "F7", "F8", "F9",
                "B7", "B8", "B9",
            },
            RotationAxis = new Vector3(0, -1, 0),
            RotationAngle = 90,
        },
        [Move.Left] = new MoveData
        {
            AlgorithmNotation = "L",
            Cycles = new []
            {
                new []{ "L1", "L3", "L9", "L7" },
                new []{ "L2", "L6", "L8", "L4" },
                new []{ "U1", "F1", "D1", "B9" },
                new []{ "U4", "F4", "D4", "B6" },
                new []{ "U7", "F7", "D7", "B3" },
            },
            Labels = new []
            {
                "U1", "U4", "U7",
                "D1", "D4", "D7",
                "L1", "L2", "L3", "L4", "L5", "L6", "L7", "L8", "L9",
                "F1", "F4", "F7",
                "B3", "B6", "B9",
            },
            RotationAxis = new Vector3(-1, 0, 0),
            RotationAngle = 90,
        },
        [Move.Right] = new MoveData
        {
            AlgorithmNotation = "R",
            Cycles = new []
            {
                new []{ "R1", "R3", "R9", "R7" },
                new []{ "R2", "R6", "R8", "R4" },
                new []{ "U3", "B7", "D3", "F3" },
                new []{ "U6", "B4", "D6", "F6" },
                new []{ "U9", "B1", "D9", "F9" },
            },
            Labels = new []
            {
                "U3", "U6", "U9",
                "D3", "D6", "D9",
                "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9",
                "F3", "F6", "F9",
                "B1", "B4", "B7",
            },
            RotationAxis = new Vector3(1, 0, 0),
            RotationAngle = 90,
        },
        [Move.Front] = new MoveData
        {
            AlgorithmNotation = "F",
            Cycles = new []
            {
                new []{ "F1", "F3", "F9", "F7" },
                new []{ "F2", "F6", "F8", "F4" },
                new []{ "U7", "R1", "D3", "L9" },
                new []{ "U8", "R4", "D2", "L6" },
                new []{ "U9", "R7", "D1", "L3" },
            },
            Labels = new []
            {
                "U7", "U8", "U9",
                "D1", "D2", "D3",
                "L3", "L6", "L9",
                "R1", "R4", "R7",
                "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9",
            },
            RotationAxis = new Vector3(0, 0, -1),
            RotationAngle = 90,
        },
        [Move.Back] = new MoveData
        {
            AlgorithmNotation = "B",
            Cycles = new []
            {
                new []{ "B1", "B3", "B9", "B7" },
                new []{ "B2", "B6", "B8", "B4" },
                new []{ "U1", "L7", "D9", "R3" },
                new []{ "U2", "L4", "D8", "R6" },
                new []{ "U3", "L1", "D7", "R9" },
            },
            Labels = new []
            {
                "U1", "U2", "U3",
                "D7", "D8", "D9",
                "L1", "L4", "L7",
                "R3", "R6", "R9",
                "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9",
            },
            RotationAxis = new Vector3(0, 0, 1),
            RotationAngle = 90,
        },
    };

    public static MoveData Get(Move move) => moveDataLookup[move];
}
