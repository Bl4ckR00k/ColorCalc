namespace ColorCalc.BL
{
    using System;
    using System.Text.RegularExpressions;

    public static class ColorCalc
    {
        public static Tuple<string, int[]> GetColorFromInput(string input)
        {
            var result = new Tuple<string, int[]>(string.Empty, null);

            if (input.Contains(",") || input.Contains("."))
            {
                var rgb = GetRgbFromString(input);
                var hex = CalculateHexFromRgb(rgb);

                if (rgb != null)
                {
                    result = new Tuple<string, int[]>(hex, rgb);
                }
            }
            else if (input.Contains("#"))
            {
                var hex = GetHexFromString(input);

                int[] aRgb;

                var rgb = CalculateRgbFromHex(hex, out aRgb);
                
                if (aRgb != null)
                {
                    result = new Tuple<string, int[]>(rgb, aRgb);
                }
            }

            return result;
        }
        
        public static int[] GetRgbFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var result = input.Split('.');

            if (result.Length <= 1)
            {
                result = input.Split(',');

                if (result.Length <= 1)
                {
                    return null;
                }
            }

            if (result.Length != 3)
            {
                return null;
            }
            else
            {
                var output = new int[3];

                for (var i = 0; i < output.Length; i++)
                {
                    try
                    {
                        var element = int.Parse(result[i]);

                        if (element < 0 || element > 255)
                        {
                            return null;
                        }

                        output[i] = element;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                
                return output;
            }            
        }

        public static string CalculateHexFromRgb(int[] rgb)
        {
            if (rgb?.Length != 3)
            {
                return "#";
            }

            var result = "#";

            foreach (var t in rgb)
            {
                if (t < 0 || t > 255)
                {
                    return "#";
                }

                result += t.ToString("X2");
            }

            return result.Length != 7 ? "#" : result;
        }

        public static string[] GetHexFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (!input.Contains("#"))
            {
                return null;
            }

            const string Pat = @"(?:#|0x)?(?:[0-9A-F]{2}){3,4}";

            var r = new Regex(Pat, RegexOptions.IgnoreCase);

            var m = r.Match(input);

            if (!m.Success)
            {
                return null;
            }

            if (input.Length != 7)
            {
                return null;
            }

            var result = new string[3];
            result[0] = input.Substring(1, 2);
            result[1] = input.Substring(3, 2);
            result[2] = input.Substring(5, 2);

            return result;
        }

        public static string CalculateRgbFromHex(string[] hex, out int[] aRgb)
        {
            aRgb = null;

            if (hex?.Length != 3)
            {
                return ",,";
            }

            var result = string.Empty;

            for (var i = 0; i < hex.Length; i++)
            {
                var r = new Regex(@"(?:[0-9A-F]{2})", RegexOptions.IgnoreCase);

                if (r.Match(hex[i]).Success)
                {
                    result += Convert.ToInt32(hex[i], 16) + (i == 2 ? string.Empty : ",");
                }
            }

            aRgb = GetRgbFromString(result);

            return aRgb == null ? ",," : result;
        }
    }
}
