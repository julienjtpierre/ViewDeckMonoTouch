using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libIIViewDeckController.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
