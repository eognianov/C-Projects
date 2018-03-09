using System;
using System.Collections.Generic;
using System.Text;


public class RandomList:List<string>
{
    Random random = new Random();
    public string RandomString()
    {

        string results = null;
        if (this.Count>0)
        {
            var randomIndex = random.Next(0, this.Count - 1);
            results = this[randomIndex];
            this.RemoveAt(randomIndex);

        }
        return results;
    }
}

