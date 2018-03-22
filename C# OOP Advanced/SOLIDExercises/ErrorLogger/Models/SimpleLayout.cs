using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ErrorLogger.Models.Contracts;

namespace ErrorLogger.Models
{
    public class SimpleLayout:ILayout
    {
        //error.Datetime - error.Level - error.Message
        const string Format = "{0} - {1} - {2}";

        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formatedError;
        }
    }
}
