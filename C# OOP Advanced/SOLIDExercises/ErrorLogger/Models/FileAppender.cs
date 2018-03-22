using ErrorLogger.Models.Contracts;

namespace ErrorLogger.Models
{
    internal class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }
        public ErrorLevel Level { get; }
        public int MessagesAppended { get;private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report Level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}, FileSize {this.logFile.Size}";
            return result;
        }
    }
}