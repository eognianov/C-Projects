using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorLogger.Models.Contracts
{
    public interface IAppender
    {
         ILayout Layout { get; }

        ErrorLevel Level { get; }

        void Append(IError error);
    }
}
