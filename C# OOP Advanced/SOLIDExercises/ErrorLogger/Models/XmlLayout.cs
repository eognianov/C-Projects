using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ErrorLogger.Models.Contracts;

namespace ErrorLogger.Models
{
    public class XmlLayout:ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private string Format =
            "<log>" + Environment.NewLine +
                "\t<date>{0}</date>" + Environment.NewLine +
                "\t<level>{1}</level>" + Environment.NewLine +
                "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formatedError;
        }
    }
}
