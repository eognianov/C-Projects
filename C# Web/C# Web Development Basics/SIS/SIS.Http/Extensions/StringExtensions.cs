﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)} cannot be null");
            }
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
