﻿using System.Linq;
using ML.Core.Algorithms;
using ML.Contracts;
using ML.Core;

namespace ML.MetricalMethods
{
  /// <summary>
  /// Leave-One-Out calculators
  /// </summary>
  public static class LOO
  {
    /// <summary>
    /// LOO for NNK
    /// </summary>
    public static NearestKNeighboursAlgorithm.Params For_NearestKNeighboursAlgorithm(ClassifiedSample trainingSample, IMetric metric)
    {
      var kMin = int.MaxValue;
      var looMin = int.MaxValue;

      for (int k = 1; k < trainingSample.Count; k++)
      {
        var loo = 0;

        for (int i = 0; i < trainingSample.Count; i++)
        {
          var pData = trainingSample.ElementAt(i);
          var trunkSample = new ClassifiedSample(trainingSample);
          trunkSample.Remove(pData.Key);

          var pars = new NearestKNeighboursAlgorithm.Params(k);
          var alg = new NearestKNeighboursAlgorithm(trunkSample, metric, pars);
          var cls = alg.Classify(pData.Key);
          if (cls != pData.Value) loo++;
        }

        if (looMin > loo)
        {
          looMin = loo;
          kMin = k;
        }
      }

      return new NearestKNeighboursAlgorithm.Params(kMin);
    }

    /// <summary>
    /// LOO for PFW
    /// </summary>
    public static ParzenFixedAlgorithm.Params For_ParzenFixedAlgorithm(ClassifiedSample trainingSample, IMetric metric, IKernel kernel, float hmin, float hmax)
    {
      var hMin = float.MaxValue;
      var looMin = float.MaxValue;
      var step = (hmax-hmin)/100.0F;

      for (float h = hmin; h < hmax; h += step)
      {
        var loo = 0;

        for (int i = 0; i < trainingSample.Count; i++)
        {
          var pData = trainingSample.ElementAt(i);
          var trunkSample = new ClassifiedSample(trainingSample);
          trunkSample.Remove(pData.Key);

          var pars = new ParzenFixedAlgorithm.Params(h);
          var alg = new ParzenFixedAlgorithm(trunkSample, metric, kernel, pars);
          var cls = alg.Classify(pData.Key);
          if (cls != pData.Value) loo++;
        }

        if (looMin > loo)
        {
          looMin = loo;
          hMin = h;
        }
      }

      return new ParzenFixedAlgorithm.Params(hMin);
    }

  }
}