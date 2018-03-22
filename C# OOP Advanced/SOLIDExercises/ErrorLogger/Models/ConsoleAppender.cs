using System;
using System.Collections.Generic;
using System.Text;
using ErrorLogger.Models.Contracts;

namespace ErrorLogger.Models
{
    public class ConsoleAppender:IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get;private set; }

        public void Append(IError error)
        {
            string formatedError = this.Layout.FormatError(error);
            Console.WriteLine(formatedError);
            MessagesAppended ++;
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report Level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
