using System;

namespace Phazed.GuardClauses
{
    public static class Guard
    {
        public static void AgainstNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void AgainstEmpty(string value, string paramName)
        {
            AgainstNull(value, paramName);
            if (value.Length == 0)
            {
                throw new ArgumentException("Value cannot be empty.", paramName);
            }
        }
    }
}