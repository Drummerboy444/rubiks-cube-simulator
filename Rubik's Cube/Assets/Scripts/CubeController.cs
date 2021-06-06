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
