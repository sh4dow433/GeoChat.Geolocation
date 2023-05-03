public class GeoHasher : IGeoHasher
{
    private readonly int precision;
    private readonly double[][] limits = new double[][] { new double[] { -90, 90 }, new double[] { -180, 180 } };
    private readonly int LATITUDE = 0, LONGITUDE = 1, LEFT = 0, RIGHT = 1, BASE = 32;

    public GeoHasher(IConfiguration configuration)
    {
        try{
            this.precision = Int32.Parse(configuration["GeoHasher:Precision"]);
        }catch (ArgumentNullException e) {
            throw new ArgumentNullException("Precision value is missing from configuration.", e);
        }
    }

    public String getGeoHashCode(double latitude, double longitude)
    {
        String geoHashCode = "";
        int fourBitChar = 0;
        int bit = 0;
        Boolean even = true;

        while (geoHashCode.Length < precision)
        {
            int axis;
            double value;
            if (even)
            {
                axis = LONGITUDE;
                value = longitude;
            }
            else
            {
                axis = LATITUDE;
                value = latitude;
            }

            double middle = (limits[axis][LEFT] + limits[axis][RIGHT]) / 2;
            if (value > middle)
            {
                fourBitChar = fourBitChar * 2 + 1;
                limits[axis][LEFT] = middle;
            }
            else
            {
                fourBitChar = fourBitChar * 2;
                limits[axis][RIGHT] = middle;
            }

            if (bit < 4) bit++;
            else
            {
                geoHashCode += Convert.ToString(fourBitChar, BASE);
                bit = 0;
                fourBitChar = 0;
            }
            even = !even;
        }
        return geoHashCode;
    }
}