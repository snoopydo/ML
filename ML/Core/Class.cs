﻿using System;

namespace ML.Core
{
  /// <summary>
  /// Represents a classification class
  /// </summary>
  public class Class
  {
    /// <summary>
    /// Default class singleton
    /// </summary>
    public static readonly Class None = new Class("[NONE]");

    public readonly string m_Name;
    public readonly float  m_Value;

    public Class(string name, float? value = null)
    {
      if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Class.ctor(name=null|empty)");

      m_Name = name;
      m_Value = value ?? 0.0F;
    }

    /// <summary>
    /// Class Name
    /// </summary>
    public string Name  { get { return m_Name; } }

    /// <summary>
    /// Some associated value (e.g. {-1, +1} for two-classes classification)
    /// </summary>
    public float  Value { get { return m_Value; } }

    #region Overrides

    public override bool Equals(object obj)
    {
      if (obj==null) return false;

      var other = obj as Class;
      if (other==null) return false;

      if (!m_Name.Equals(other.m_Name)) return false;

      return m_Value == other.m_Value;
    }

    public override int GetHashCode()
    {
      return m_Name.GetHashCode() ^ m_Value.GetHashCode();
    }

    #endregion
  }
}