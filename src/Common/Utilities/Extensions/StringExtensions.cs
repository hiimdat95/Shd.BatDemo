namespace BatDemo.Utils.Extensions
{
    public static class StringExtensions
    {
        // Write funtion convert char(1) oracle to bool
        // input string: "T"
        // output bool: true
        public static bool CharOracleToBool(this string value)
        {
            return value == "T";
        }
    }
}






