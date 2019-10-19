## Introduction
Collections quite simply contain objects, just like we expect from a C# collection, but serialized in an asset inside your project

Note that Unity **realy** doesn't like it if you reference scene objects in assets, and as such have made certain editor functions incompatible with them. Therefore if any object in the collection is not persistent, they're disabled as you can see below, although you can still reorder, delete and click on them to see them in your scene view. Note that none of these conditions affect how they work under the hood, these precautions are merely related to the editor

## Script Reference
There are various ways to interact with the collection. Available are the following members

T this[int index]

IList List { get; }
int Count { get; }
Type Type { get; }

void Add(T)
void Remove(T)
RemoveAt(int)
void Clear()
bool Contains(T)
int IndexOf(T)
Insert(int, T)

T[] ToArray()
