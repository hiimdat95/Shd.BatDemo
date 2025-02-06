namespace BatDemo.Utils.Extensions
{
    public static class BoolExtensions
    {
        // Write funtion convert to bool in type oracle
        // input string: "true"
        // output string: "T"
        public static string ToBoolOrcale(this bool value)
        {
            return value ? "T" : "F";
        }
    }
}






