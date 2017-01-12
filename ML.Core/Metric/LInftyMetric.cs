﻿using System;

namespace ML.Core.Metric
{
  /// <summary>
  /// Represents L_infty metrics
  /// </summary>
  public sealed class LInftyMetric : MetricBase
  {
    /// <summary>
    /// Distance between two points
    /// </summary>
    public override float Dist(Point p1, Point p2)
    {
      Point.CheckDimensions(p1, p2);

      var dim = p1.Dimension;
      var max = double.MinValue;

      for (int i=0; i<dim; i++)
      {
        var abs = Math.Abs(p1[i]-p2[i]);
        if (abs > max) max = abs;
      }

      return (float)max;
    }

    /// <summary>
    /// Metric name
    /// </summary>
    public override string Name { get { return "L infinity"; } }
  }
}
