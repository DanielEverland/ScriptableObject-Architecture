# ScriptableObject-Architecture
[![openupm](https://img.shields.io/npm/v/com.danieleverland.scriptableobjectarchitecture?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.danieleverland.scriptableobjectarchitecture/)

Makes using Scriptable Objects as a fundamental part of your architecture in Unity super easy

Based on Ryan Hipple's 2017 Unite talk https://www.youtube.com/watch?v=raQ3iHhE_Kk

Now on the [Asset Store!](https://assetstore.unity.com/packages/tools/utilities/scriptableobject-architecture-131520)

Reading the [Quick Start Page](https://github.com/DanielEverland/ScriptableObject-Architecture/wiki/Quick-Start) is recommended!

# Features
- Automatic Script Generation
- Variables - All C# primitives
- Clamped Variables
- Variable References
- Typed Events
- Runtime Sets
- Custom Icons

Visual debugging of events

![](https://i.imgur.com/GPP3aVR.gif)

Full stacktrace and editor invocation for events

![](https://i.imgur.com/S90VUWI.png)

Custom icons

![](https://i.imgur.com/simB0mK.png)

Easy and automatic script generation

![](https://i.imgur.com/xm2gNmo.png)

# Installation
For a more detailed explanation, please read the [Quick Start Page](https://github.com/DanielEverland/ScriptableObject-Architecture/wiki/Quick-Start)

There are three ways you can install this package
- [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/scriptableobject-architecture-131520)
- .unitypackage from [Releases](https://github.com/DanielEverland/ScriptableObject-Architecture/releases)
- Unity package manager introduced in 2017.2
- [OpenUPM](https://openupm.com/packages/com.danieleverland.scriptableobjectarchitecture/)

## Package Manager Installation

Simply modify your `manifest.json` file found at `/PROJECTNAME/Packages/manifest.json` by including the following line

```
{
	"dependencies": {
		...
		"com.danieleverland.scriptableobjectarchitecture": "https://github.com/DanielEverland/ScriptableObject-Architecture.git#release/stable",
		...
	}
}
```
