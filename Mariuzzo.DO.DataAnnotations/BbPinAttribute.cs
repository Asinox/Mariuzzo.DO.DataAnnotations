﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Mariuzzo.DO.DataAnnotations
{
    /// <summary>
    /// The <code>BbPinAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class BbPinAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determine if a string value is a valid BlackBerry PIN number.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid BlackBerry PIN number, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            var str = value as string;

            if (String.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            Regex regex = new Regex(@"^[\dA-Fa-f]{8}$");
            return regex.Matches(str).Count > 0;
        }
    }
}
