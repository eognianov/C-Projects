using System;
using System.Collections.Generic;
using System.Text;


    public interface IStreamProgress
    {
        int BytesSent { get; }

        int Length { get;  }
    }

