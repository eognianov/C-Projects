﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mission:IMission
{
    public abstract string Name { get; }
    public abstract double EnduranceRequired { get; }
    public double ScoreToComplete { get; private set; }
    public abstract double WearLevelDecrement { get; }

    protected Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }
}

