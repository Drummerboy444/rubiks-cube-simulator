using UnityEngine;

public static class ColourLookup
{
    public static Color Get(Colour colour)
    {
        return colour switch
        {
            Colour.Red => Color.red,
            Colour.Green => Color.green,
            Colour.Blue => Color.blue,
            Colour.Yellow => Color.yellow,
            Colour.White => Color.white,
            Colour.Black => Color.black,
            _ => default
        };
    }
}
