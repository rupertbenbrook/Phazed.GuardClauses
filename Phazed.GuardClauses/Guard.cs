using System;
using System.Collections;

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
            ThrowIfEmpty(value.Length, paramName);
        }

        public static void AgainstEmpty(ICollection value, string paramName)
        {
            AgainstNull(value, paramName);
            ThrowIfEmpty(value.Count, paramName);
        }

        private static void ThrowIfEmpty(int size, string paramName)
        {
            if (size == 0)
            {
                throw new ArgumentException("Value cannot be empty.", paramName);
            }
        }

        public static void AgainstOutOfRange<T>(T value, T min, T max, string paramName) where T : IComparable
        {
            AgainstNull(value, paramName);
            if ((value.CompareTo(min) < 0) || (value.CompareTo(max) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, "Value must be between " + min + " and " + max + ".");
            }
        }
    }
}