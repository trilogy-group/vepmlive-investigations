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
    }
}
