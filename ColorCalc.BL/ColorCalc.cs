namespace ColorCalc.BL
{
    using System;

    public static class ColorCalc
    {
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
    }
}
