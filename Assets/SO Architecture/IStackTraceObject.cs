using System.Collections.Generic;

public interface IStackTraceObject
{
    List<StackTraceEntry> StackTraces { get; }

    void AddStackTrace();
    void AddStackTrace(object value);
}