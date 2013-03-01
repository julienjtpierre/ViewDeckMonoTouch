using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libIIViewDeckController.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, Frameworks="CoreGraphics")]
