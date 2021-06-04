using UnityEngine;

public static class ColourLookup
{
    private static readonly Color orange = new Color(1.0f, 0.64f, 0.0f);

    public static Color GetColor(Colour colour)
    {
        return colour switch
        {
            Colour.Green => Color.green,
            Colour.Blue => Color.blue,
            Colour.Orange => orange,
            Colour.Red => Color.red,
            Colour.Yellow => Color.yellow,
            Colour.White => Color.white,
            _ => default
        };
    }

    public static Colour GetStartingColour(string label)
    {
        return label[0] switch
        {
            'U' => Colour.Green,
            'D' => Colour.Blue,
            'L' => Colour.Orange,
            'R' => Colour.Red,
            'F' => Colour.Yellow,
            'B' => Colour.White,
            _ => default
        };
    }
}
