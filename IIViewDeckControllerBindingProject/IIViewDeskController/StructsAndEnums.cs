using System;

namespace ViewDeckController
{
	public enum IIViewDeckSide  // in IIViewDeckController.h
	{
		IIViewDeckLeftSide = 1,
		IIViewDeckRightSide = 2,
		IIViewDeckTopSide = 3,
		IIViewDeckBottomSide = 4
	}
	public enum IIViewDeckOffsetOrientation  // in IIViewDeckController.h
	{
		IIViewDeckHorizontalOrientation = 1,
		IIViewDeckVerticalOrientation = 2
	}
	public enum IIViewDeckPanningMode  // in IIViewDeckController.h
	{
		IIViewDeckNoPanning,
		IIViewDeckFullViewPanning,
		IIViewDeckNavigationBarPanning,
		IIViewDeckPanningViewPanning,
		IIViewDeckDelegatePanning,
		IIViewDeckNavigationBarOrOpenCenterPanning
	}
	public enum IIViewDeckCenterHiddenInteractivity  // in IIViewDeckController.h
	{
		IIViewDeckCenterHiddenUserInteractive,
		IIViewDeckCenterHiddenNotUserInteractive,
		IIViewDeckCenterHiddenNotUserInteractiveWithTapToClose,
		IIViewDeckCenterHiddenNotUserInteractiveWithTapToCloseBouncing
	}
	public enum IIViewDeckNavigationControllerBehavior  // in IIViewDeckController.h
	{
		IIViewDeckNavigationControllerContained,
		IIViewDeckNavigationControllerIntegrated
	}
	public enum IIViewDeckSizeMode  // in IIViewDeckController.h
	{
		IIViewDeckLedgeSizeMode,
		IIViewDeckViewSizeMode
	}
	public enum IIViewDeckDelegateMode  // in IIViewDeckController.h
	{
		IIViewDeckDelegateOnly,
		IIViewDeckDelegateAndSubControllers
	}
}

