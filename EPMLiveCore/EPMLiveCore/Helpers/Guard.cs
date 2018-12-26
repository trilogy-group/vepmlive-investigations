using System;

namespace EPMLiveCore.Helpers
{
    public static class Guard
    {
        public static void ArgumentIsNotNull(object value, string argument)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }
        }

        public static void ValueIsNotNull(object objValue, string argument)
        {
            if (objValue == null)
            {
                throw new InvalidOperationException($"{argument} cannot be null");
            }
        }

        public static bool TryParseBool(string str)
        {
            bool booleanValue;
            if (bool.TryParse(str, out booleanValue))
            {
                return booleanValue;
            }

            throw new InvalidOperationException($"{str} should contain a valid bool value.");
        }

        public static int TryParseInt(string str)
        {
            int intValue;
            if (int.TryParse(str, out intValue))
            {
                return intValue;
            }

            throw new InvalidOperationException($"{str} should contain a valid int value.");
        }
    }
}
