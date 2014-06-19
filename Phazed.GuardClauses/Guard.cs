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
            CheckIfEmpty(value.Length, paramName);
        }

        public static void AgainstEmpty(ICollection value, string paramName)
        {
            AgainstNull(value, paramName);
            CheckIfEmpty(value.Count, paramName);
        }

        private static void CheckIfEmpty(int size, string paramName)
        {
            if (size == 0)
            {
                throw new ArgumentException("Value cannot be empty.", paramName);
            }
        }
    }
}