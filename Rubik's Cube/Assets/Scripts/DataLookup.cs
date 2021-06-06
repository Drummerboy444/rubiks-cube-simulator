using System.Collections.Generic;
using UnityEngine;

public static class DataLookup
{
    private static readonly Dictionary<Move, MoveData> moveDataLookup = new Dictionary<Move, MoveData>
    {
        [Move.Up] = new MoveData
        {
            Cycles = new []
            {
                new []{ "U1", "U3", "U9", "U7" },
                new []{ "U2", "U6", "U8", "U4" },
                new []{ "F1", "L1", "B1", "R1" },
                new []{ "F2", "L2", "B2", "R2" },
                new []{ "F3", "L3", "B3", "R3" },
            },
            FaceLabels = new []
            {
                "U1", "U2", "U3", "U4", "U5", "U6", "U7", "U8", "U9",
                "L1", "L2", "L3",
                "R1", "R2", "R3",
                "F1", "F2", "F3",
                "B1", "B2", "B3",
            },
            RotationAxis = new Vector3(0, 1, 0),
            RotationAngle = 90,
        }
    };

    public static string[][] GetCycles(Move move) => moveDataLookup[move].Cycles;
    public static string[] GetFaceLabels(Move move) => moveDataLookup[move].FaceLabels;
    public static Vector3 GetRotationAxis(Move move) => moveDataLookup[move].RotationAxis;
    public static int GetRotationAngle(Move move) => moveDataLookup[move].RotationAngle;
}
