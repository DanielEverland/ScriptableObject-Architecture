using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public interface IStackTraceObject
    {
        List<StackTraceEntry> StackTraces { get; }

        void AddStackTrace();
        void AddStackTrace(object value);
    } 
}