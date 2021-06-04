using UnityEngine;

public static class ColourLookup
{
    private static readonly Color orange = new Color(1.0f, 0.64f, 0.0f);

    public static Color Get(Colour colour)
    {
        return colour switch
        {
            Colour.Red => Color.red,
            Colour.Green => Color.green,
            Colour.Blue => Color.blue,
            Colour.Yellow => Color.yellow,
            Colour.White => Color.white,
            Colour.Orange => orange,
            _ => default
        };
    }
}
