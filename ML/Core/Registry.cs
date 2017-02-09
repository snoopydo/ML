﻿using System.Collections.Generic;
using ML.Core.Kernels;
using ML.Core.Metric;
using ML.Core.Logical;
using ML.Core.ActivationFunctions;

namespace ML.Core
{
  public static class Registry
  {
    public static class Kernels
    {
      private static readonly GaussianKernel    m_GaussianKernel    = new GaussianKernel();
      private static readonly QuadraticKernel   m_QuadraticKernel   = new QuadraticKernel();
      private static readonly QuarticKernel     m_QuarticKernel     = new QuarticKernel();
      private static readonly RectangularKernel m_RectangularKernel = new RectangularKernel();
      private static readonly TriangularKernel  m_TriangularKernel  = new TriangularKernel();

      public static GaussianKernel    GaussianKernel    { get { return m_GaussianKernel; } }
      public static QuadraticKernel   QuadraticKernel   { get { return m_QuadraticKernel; } }
      public static QuarticKernel     QuarticKernel     { get { return m_QuarticKernel; } }
      public static RectangularKernel RectangularKernel { get { return m_RectangularKernel; } }
      public static TriangularKernel  TriangularKernel  { get { return m_TriangularKernel; } }
    }

    public static class Metrics
    {
      private static readonly EuclideanMetric m_EuclideanMetric = new EuclideanMetric();
      private static readonly LInftyMetric    m_LInftyMetric    = new LInftyMetric();
      private static readonly Dictionary<double, LpMetric> m_LpMetrics= new Dictionary<double, LpMetric>();

      public static EuclideanMetric EuclideanMetric { get { return m_EuclideanMetric; } }
      public static LInftyMetric LInftyMetric { get { return m_LInftyMetric; } }
      public static LpMetric LpMetric(double p)
      {
        LpMetric result;
        if (!m_LpMetrics.TryGetValue(p, out result))
        {
          result = new LpMetric(p);
          m_LpMetrics[p] = result;
        }

        return result;
      }
    }

    public static class Informativities
    {
      private static readonly GiniIndex m_GiniInformativity = new GiniIndex();
      private static readonly DonskoyIndex m_DonskoyInformativity = new DonskoyIndex();
      private static readonly EntropyIndex m_EntropyInformativity = new EntropyIndex();

      public static GiniIndex GiniInfomativity { get { return m_GiniInformativity; } }
      public static DonskoyIndex DonskoyInformativity { get { return m_DonskoyInformativity; } }
      public static EntropyIndex EntropyInformativity { get { return m_EntropyInformativity; } }
    }

    public static class ActivationFunctions
    {
      private static readonly ArctanActivation m_Atan = new ArctanActivation();
      private static readonly BinaryStepActivation m_BinaryStep = new BinaryStepActivation();
      private static readonly IdentityActivation m_Identity = new IdentityActivation();
      private static readonly LogisticActivation m_Logistic = new LogisticActivation();
      private static readonly ReLUActivation m_ReLU = new ReLUActivation();
      private static readonly TanhActivation m_TanhActivation = new TanhActivation();


      public static ArctanActivation Atan { get { return m_Atan; } }
      public static BinaryStepActivation BinaryStep { get { return m_BinaryStep; } }
      public static IdentityActivation Identity { get { return m_Identity; } }
      public static LogisticActivation Logistic { get { return m_Logistic; } }
      public static ReLUActivation ReLU { get { return m_ReLU; } }
      public static TanhActivation TanhActivation { get { return m_TanhActivation; } }
    }
  }
}
