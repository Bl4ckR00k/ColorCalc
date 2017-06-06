namespace ColorCalc.BL
{
    using System;
    using System.Text.RegularExpressions;

    public static class ColorCalc
    {
        public static Tuple<string, int[]> GetColorFromInput(string input)
        {
            var result = new Tuple<string, int[]>(string.Empty, null);

            if(input.Contains(",") || input.Contains("."))
            {
                var rgb = GetRgbFromString(input);
                var hex = CalculateHexFromRgb(rgb);

                if (rgb != null)
                {
                    result = new Tuple<string, int[]>(hex, rgb);
                }
            }
            else if(input.Contains("#"))
            {
                var hex = GetHexFromString(input);
                int[] aRgb = null;
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
                int[] output = new int[3];

                for(int i = 0; i < output.Length; i++)
                {
                    try
                    {
                        var element = int.Parse(result[i]);

                        if (element < 0 || element > 255 )
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

        public static string CalculateHexFromRgb(int[] RGB)
        {
            if(RGB == null)
            {
                return "#";
            }

            if (RGB.Length != 3)
            {
                return "#";
            }

            var result = "#";

            for (int i = 0; i < RGB.Length; i++)
            {
                if(RGB[i] < 0 || RGB[i] > 255)
                {
                    return "#";
                }

                result += RGB[i].ToString("X2");
            }

            if(result.Length != 7)
            {
                return "#";
            }

            return result;
        }

        public static string[] GetHexFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if(input.Contains("#"))
            {
                var pat = @"(?:#|0x)?(?:[0-9A-F]{2}){3,4}";

                Regex r = new Regex(pat, RegexOptions.IgnoreCase);

                Match m = r.Match(input);

                if(m.Success)
                { 
                    if (input.Length == 7)
                    {
                        var result = new string[3];
                        result[0] = input.Substring(1, 2);
                        result[1] = input.Substring(3, 2);
                        result[2] = input.Substring(5, 2);

                        return result;
                    }
                }

            }
            return null;
        }

        public static string CalculateRgbFromHex(string[] Hex, out int[] aRgb)
        {
            aRgb = null;

            if (Hex == null)
            {
                return ",,";
            }

            if (Hex.Length != 3)
            {
                return ",,";
            }

            var result = "";

            for (int i = 0; i < Hex.Length; i++)
            {
                Regex r = new Regex(@"(?:[0-9A-F]{2})", RegexOptions.IgnoreCase);

                if (r.Match(Hex[i]).Success)
                {
                    result += Convert.ToInt32(Hex[i], 16).ToString() + (i == 2 ? "": ",");
                }
            }

            aRgb = GetRgbFromString(result);

            if(aRgb == null)
            {
                return ",,";
            }

            return result;
        }
    }
}
