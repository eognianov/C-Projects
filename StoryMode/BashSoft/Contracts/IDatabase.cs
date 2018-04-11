using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IDatabase:IRequester, IFilterAndTake, IOrderTaker
    {
        void LoadData(string fileName);
        void UnloadDate();
    }
}
