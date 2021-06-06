using System;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmApplier : MonoBehaviour
{
    private CubeController cubeController;

    private readonly Dictionary<string, Move> algorithmNotationToMoveLookup = new Dictionary<string, Move>();

    private void Start()
    {
        cubeController = FindObjectOfType<CubeController>();

        foreach (Move move in Enum.GetValues(typeof(Move)))
        {
            algorithmNotationToMoveLookup[MoveDataLookup.Get(move).AlgorithmNotation] = move;
        }
    }

    public void Apply(string algorithm)
    {
        foreach (string token in algorithm.Split(' '))
        {
            cubeController.MakeMove(algorithmNotationToMoveLookup[token]);
        }
    }
}
