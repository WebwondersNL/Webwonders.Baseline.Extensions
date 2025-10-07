namespace Webwonders.Baseline.Extensions.Helpers;

public interface IColor {}

public class RGB : IColor
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public RGB(byte r, byte g, byte b)
    {
        this.R = r;
        this.G = g;
        this.B = b;
    }

    public override bool Equals(object? obj)
    {
        RGB? rgb = (RGB?)obj;
        
        return rgb != null && 
               (int) this.R == (int) rgb.R && 
               (int) this.G == (int) rgb.G && 
               (int) this.B == (int) rgb.B;
    }
    
    public override string ToString() => $"rgb({this.R}, {this.G}, {this.B})";
}

public class HSL : IColor
{
    public int H { get; set; }

    public byte S { get; set; }

    public byte L { get; set; }

    public HSL(int h, byte s, byte l)
    {
        this.H = h;
        this.S = s;
        this.L = l;
    }

    public override bool Equals(object? obj)
    {
        HSL? hsl = (HSL?) obj;
        return hsl != null && this.H == hsl.H && (int) this.S == (int) hsl.S && (int) this.L == (int) hsl.L;
    }

    public override string ToString() => $"{this.H}° {this.S}% {this.L}%";
}

public class HEX : IColor
{
    private string? _value;

    public string? Value
    {
        get => this._value;
        set => this._value = value != null && value.IndexOf('#') == 0 ? value.Substring(1) : value;
    }

    public HEX(string? value) => this.Value = value;

    public override bool Equals(object? obj)
    {
        return this.Value == (obj is HEX hex ? hex.Value : (string) null!);
    }

    public override string ToString() => this.Value ?? "";
}

public class ColorHelpers
{
    public static HSL RgbToHsl(RGB rgb)
    {
        double num1 = (double) rgb.R / (double) byte.MaxValue;
        double num2 = (double) rgb.G / (double) byte.MaxValue;
        double num3 = (double) rgb.B / (double) byte.MaxValue;
        double num4 = new List<double>() { num1, num2, num3 }.Min();
        double num5 = new List<double>() { num1, num2, num3 }.Max();
        double num6 = num5 - num4;
        double num7 = (num4 + num5) / 2.0;
        double num8;
        double num9;
        if (num6 == 0.0)
        {
            num8 = 0.0;
            num9 = 0.0;
        }
        else
        {
            num9 = num7 <= 0.5 ? num6 / (num4 + num5) : num6 / (2.0 - num5 - num4);
            double num10 = num1 != num5 ? (num2 != num5 ? 2.0 / 3.0 + (num1 - num2) / 6.0 / num6 : 1.0 / 3.0 + (num3 - num1) / 6.0 / num6) : (num2 - num3) / 6.0 / num6;
            double num11;
            double num12;
            if (num10 >= 0.0)
                num12 = num10;
            else
                num11 = num12 = num10 + 1.0;
            double num13 = num12;
            double num14;
            if (num13 <= 1.0)
                num14 = num13;
            else
                num11 = num14 = num13 - 1.0;
            num8 = num14;
        }
        return new HSL((int) Math.Round(num8 * 360.0), (byte) Math.Round(num9 * 100.0), (byte) Math.Round(num7 * 100.0));
    }

    public static RGB HexToRgb(HEX hex)
    {
        int int32 = Convert.ToInt32(hex.Value, 16 /*0x10*/);
        return new RGB((byte) (int32 >> 16 /*0x10*/ & (int) byte.MaxValue), (byte) (int32 >> 8 & (int) byte.MaxValue), (byte) (int32 & (int) byte.MaxValue));
    }
    
    public static HSL HexToHsl(HEX hex) => RgbToHsl(HexToRgb(hex));
}