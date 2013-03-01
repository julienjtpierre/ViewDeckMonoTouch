using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace ViewDeckController
{


	//typedef void (^IIViewDeckControllerBlock) (IIViewDeckController *controller, BOOL success);
	//[Export ("(IIViewDeckController *controller, BOOL success)")]
	// just declaring delegate
	delegate void IIViewDeckControllerBlock (UIViewController controller, bool success);
	
	//typedef void (^IIViewDeckControllerBounceBlock) (IIViewDeckController *controller);
	//[Export ("(IIViewDeckController *controller)")]
	// just declaring delegate
	delegate void IIViewDeckControllerBounceBlock (UIViewController controller);
	
	delegate void SomeDelegate(bool finished);
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//


	[BaseType (typeof (UIViewController), Delegates = new string[]{"WeakDelegate","PanningGetureWeakDelegate"} )]
	//Events = new Type[] { (typeof(IIViewDeckControllerDelegate))}
	//[Register("IIViewDeckController",true)]
	interface IIViewDeckController
	{

		//extern NSString* NSStringFromIIViewDeckSide(IIViewDeckSide side);
		[Static,Export ("NSStringFromIIViewDeckSide:")]
		string NSStringFromIIViewDeckSide(IIViewDeckSide side);
		
		//extern IIViewDeckOffsetOrientation IIViewDeckOffsetOrientationFromIIViewDeckSide(IIViewDeckSide side);
		[Static, Export ("IIViewDeckOffsetOrientationFromIIViewDeckSide")]
		IIViewDeckOffsetOrientation IIViewDeckOffsetOrientationFromIIViewDeckSide(IIViewDeckSide side);


		//- (IIViewDeckSide)sideForController:(UIViewController*)controller;
		[Export ("sideForController:")]
		IIViewDeckSide SideForController (UIViewController controller);
		
		[Export("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		//@property (nonatomic, assign) id<IIViewDeckControllerDelegate> delegate;
		[Wrap("WeakDelegate")]
		[NullAllowed]
		IIViewDeckControllerDelegate Delegate{ get; set; }
		
		//@property (nonatomic, assign) IIViewDeckDelegateMode delegateMode;
		[Export ("delegateMode", ArgumentSemantic.Assign)]
		IIViewDeckDelegateMode DelegateMode { get; set;  }
		
		//@property (nonatomic, readonly, retain) NSArray* controllers;
		[Export ("controllers", ArgumentSemantic.Retain)]
		UIViewController[] Controllers { get; }
		
		//@property (nonatomic, retain) UIViewController* centerController;
		[Export ("centerController", ArgumentSemantic.Retain)]
		UIViewController CenterController { get; set;  }
		
		//@property (nonatomic, retain) UIViewController* leftController;
		[Export ("leftController", ArgumentSemantic.Retain)]
		UIViewController LeftController { get; set;  }
		
		//@property (nonatomic, retain) UIViewController* rightController;
		[Export ("rightController", ArgumentSemantic.Retain)]
		UIViewController RightController { get; set;  }
		
		//@property (nonatomic, retain) UIViewController* topController;
		[Export ("topController", ArgumentSemantic.Retain)]
		UIViewController TopController { get; set;  }
		
		//@property (nonatomic, retain) UIViewController* bottomController;
		[Export ("bottomController", ArgumentSemantic.Retain)]
		UIViewController BottomController { get; set;  }
		
		//@property (nonatomic, readonly, assign) UIViewController* slidingController;
		[Export ("slidingController", ArgumentSemantic.Assign)]
		UIViewController SlidingController { get;  }
		
		//@property (nonatomic, retain) UIView* panningView;
		[Export ("panningView", ArgumentSemantic.Retain)]
		UIView PanningView { get; set;  }

		[Export("panningGestureDelegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject PanningGestureWeakDelegate { get; set; }
		
		//@property (nonatomic, assign) id<UIGestureRecognizerDelegate> panningGestureDelegate;
		[Wrap("PanningGestureWeakDelegate")]
		[NullAllowed]
		UIGestureRecognizerDelegate PanningGestureDelegate{ get; set; }
		
		//@property (nonatomic, assign, getter=isEnabled) BOOL enabled;
		[Export ("enabled", ArgumentSemantic.Assign)]
		bool Enabled { [Bind ("isEnabled")] get; set;  }
		
		//@property (nonatomic, assign, getter=isElastic) BOOL elastic;
		[Export ("elastic", ArgumentSemantic.Assign)]
		bool Elastic { [Bind ("isElastic")] get; set;  }
		
		//@property (nonatomic, assign) CGFloat leftSize;
		[Export ("leftSize", ArgumentSemantic.Assign)]
		float LeftSize { get; set;  }
		
		//@property (nonatomic, assign, readonly) CGFloat leftViewSize;
		[Export ("leftViewSize", ArgumentSemantic.Assign)]
		float LeftViewSize { get;  }
		
		//@property (nonatomic, assign, readonly) CGFloat leftLedgeSize;
		[Export ("leftLedgeSize", ArgumentSemantic.Assign)]
		float LeftLedgeSize { get;  }
		
		//@property (nonatomic, assign) CGFloat rightSize;
		[Export ("rightSize", ArgumentSemantic.Assign)]
		float RightSize { get; set; }
		
		//@property (nonatomic, assign, readonly) CGFloat rightViewSize;
		[Export ("rightViewSize", ArgumentSemantic.Assign)]
		float RightViewSize { get;  }
		
		//@property (nonatomic, assign, readonly) CGFloat rightLedgeSize;
		[Export ("rightLedgeSize", ArgumentSemantic.Assign)]
		float RightLedgeSize { get;  }
		
		//@property (nonatomic, assign) CGFloat topSize;
		[Export ("topSize", ArgumentSemantic.Assign)]
		float TopSize { get; set;  }
		
		//@property (nonatomic, assign, readonly) CGFloat topViewSize;
		[Export ("topViewSize", ArgumentSemantic.Assign)]
		float TopViewSize { get;  }
		
		//@property (nonatomic, assign, readonly) CGFloat topLedgeSize;
		[Export ("topLedgeSize", ArgumentSemantic.Assign)]
		float TopLedgeSize { get;  }
		
		//@property (nonatomic, assign) CGFloat bottomSize;
		[Export ("bottomSize", ArgumentSemantic.Assign)]
		float BottomSize { get; set;  }
		
		//@property (nonatomic, assign, readonly) CGFloat bottomViewSize;
		[Export ("bottomViewSize", ArgumentSemantic.Assign)]
		float BottomViewSize { get;  }
		
		//@property (nonatomic, assign, readonly) CGFloat bottomLedgeSize;
		[Export ("bottomLedgeSize", ArgumentSemantic.Assign)]
		float BottomLedgeSize { get;  }
		
		//@property (nonatomic, assign) CGFloat maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		float MaxSize { get; set;  }
		
		//@property (nonatomic, assign) BOOL resizesCenterView;
		[Export ("resizesCenterView", ArgumentSemantic.Assign)]
		bool ResizesCenterView { get; set;  }
		
		//@property (nonatomic, assign) IIViewDeckPanningMode panningMode;
		[Export ("panningMode", ArgumentSemantic.Assign)]
		IIViewDeckPanningMode PanningMode { get; set;  }
		
		//@property (nonatomic, assign) IIViewDeckCenterHiddenInteractivity centerhiddenInteractivity;
		[Export ("centerhiddenInteractivity", ArgumentSemantic.Assign)]
		IIViewDeckCenterHiddenInteractivity CenterhiddenInteractivity { get; set;  }
		
		//@property (nonatomic, assign) IIViewDeckNavigationControllerBehavior navigationControllerBehavior;
		[Export ("navigationControllerBehavior", ArgumentSemantic.Assign)]
		IIViewDeckNavigationControllerBehavior NavigationControllerBehavior { get; set;  }
		
		//@property (nonatomic, assign) BOOL automaticallyUpdateTabBarItems;
		[Export ("automaticallyUpdateTabBarItems", ArgumentSemantic.Assign)]
		bool AutomaticallyUpdateTabBarItems { get; set;  }
		
		//@property (nonatomic, assign) IIViewDeckSizeMode sizeMode;
		[Export ("sizeMode", ArgumentSemantic.Assign)]
		IIViewDeckSizeMode SizeMode { get; set;  }
		
		//@property (nonatomic, assign) CGFloat bounceDurationFactor; 
		[Export ("bounceDurationFactor", ArgumentSemantic.Assign)]
		float BounceDurationFactor { get; set;  }
		
		//@property (nonatomic, assign) CGFloat bounceOpenSideDurationFactor; 
		[Export ("bounceOpenSideDurationFactor", ArgumentSemantic.Assign)]
		float BounceOpenSideDurationFactor { get; set;  }
		
		//@property (nonatomic, assign) CGFloat openSlideAnimationDuration;
		[Export ("openSlideAnimationDuration", ArgumentSemantic.Assign)]
		float OpenSlideAnimationDuration { get; set;  }
		
		//@property (nonatomic, assign) CGFloat closeSlideAnimationDuration;
		[Export ("closeSlideAnimationDuration", ArgumentSemantic.Assign)]
		float CloseSlideAnimationDuration { get; set;  }


		//- (id)initWithCenterViewController:(UIViewController*)centerController;
		[Export ("initWithCenterViewController:")]
		IntPtr Constructor (UIViewController centerController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController leftViewController:(UIViewController*)leftController;
		[Export ("initWithCenterViewController:leftViewController:")]
		IntPtr Constructor (UIViewController centerController, UIViewController leftController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController rightViewController:(UIViewController*)rightController;
		//[Export ("initWithCenterViewController:rightViewController:")]
		//IntPtr Constructor (UIViewController centerController, UIViewController rightController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController leftViewController:(UIViewController*)leftController rightViewController:(UIViewController*)rightController;
		[Export ("initWithCenterViewController:leftViewController:rightViewController:")]
		IntPtr Constructor (UIViewController centerController, UIViewController leftController, UIViewController rightController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController topViewController:(UIViewController*)topController;
		//[Export ("initWithCenterViewController:topViewController:")]
		//IntPtr Constructor (UIViewController centerController, UIViewController topController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController bottomViewController:(UIViewController*)bottomController;
		//[Export ("initWithCenterViewController:bottomViewController:")]
		//IntPtr Constructor (UIViewController centerController, UIViewController bottomController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController topViewController:(UIViewController*)topController bottomViewController:(UIViewController*)bottomController;
		//[Export ("initWithCenterViewController:topViewController:bottomViewController:")]
		//IntPtr Constructor (UIViewController centerController, UIViewController topController, UIViewController bottomController);
		
		//- (id)initWithCenterViewController:(UIViewController*)centerController leftViewController:(UIViewController*)leftController rightViewController:(UIViewController*)rightController topViewController:(UIViewController*)topController bottomViewController:(UIViewController*)bottomController;
		[Export ("initWithCenterViewController:leftViewController:rightViewController:topViewController:bottomViewController:")]
		IntPtr Constructor (UIViewController centerController, UIViewController leftController, UIViewController rightController, UIViewController topController, UIViewController bottomController);


		//- (void)setLeftSize:(CGFloat)leftSize completion:(void(^)(BOOL finished))completion;
		[Export ("setLeftSize:completion:")]
		void SetLeftSize (float leftSize, SomeDelegate del);
		                                   
		 //- (void)setRightSize:(CGFloat)rightSize completion:(void(^)(BOOL finished))completion;
		[Export ("setRightSize:completion:")]
		void SetRightSize (float rightSize, SomeDelegate del);
		                                     
		//- (void)setTopSize:(CGFloat)leftSize completion:(void(^)(BOOL finished))completion;
		[Export ("setTopSize:completion:")]
		//void SetTopSize (float leftSize, SomeDelegate del);
		void SetTopSize (float topSize, SomeDelegate del);
		                                  
		//- (void)setBottomSize:(CGFloat)rightSize completion:(void(^)(BOOL finished))completion;
		[Export ("setBottomSize:completion:")]
		//void SetBottomSize (float rightSize, SomeDelegate del);
		void SetBottomSize (float bottomSize, SomeDelegate del);
		                                      
		//- (void)setMaxSize:(CGFloat)maxSize completion:(void(^)(BOOL finished))completion;
		[Export ("setMaxSize:completion:")]
		void SetMaxSize (float maxSize, SomeDelegate del);
		                                 
		//- (BOOL)toggleLeftView;
		[Export ("toggleLeftView")]
		bool ToggleLeftView();
		
		//- (BOOL)openLeftView;
		[Export ("openLeftView")]
		bool OpenLeftView();
		
		//- (BOOL)closeLeftView;
		[Export ("closeLeftView")]
		bool CloseLeftView();
		
		//- (BOOL)toggleLeftViewAnimated:(BOOL)animated;
		[Export ("toggleLeftViewAnimated:")]
		bool ToggleLeftViewAnimated (bool animated);
		
		//- (BOOL)toggleLeftViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("toggleLeftViewAnimated:completion:")]
		bool ToggleLeftViewAnimated (bool animated, IIViewDeckControllerBlock completedBlock);
		
		//- (BOOL)openLeftViewAnimated:(BOOL)animated;
		[Export ("openLeftViewAnimated:")]
		bool OpenLeftViewAnimated (bool animated);
		
		//- (BOOL)openLeftViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("openLeftViewAnimated:completion:")]
		bool OpenLeftViewAnimated (bool animated, IIViewDeckControllerBlock completedBlock);
		
		//- (BOOL)openLeftViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("openLeftViewBouncing:")]
		bool OpenLeftViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)openLeftViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("openLeftViewBouncing:completion:")]
		bool OpenLeftViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeLeftViewAnimated:(BOOL)animated;
		[Export ("closeLeftViewAnimated:")]
		bool CloseLeftViewAnimated (bool animated);
		
		//- (BOOL)closeLeftViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeLeftViewAnimated:completion:")]
		bool CloseLeftViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeLeftViewAnimated:(BOOL)animated duration:(NSTimeInterval)duration completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeLeftViewAnimated:duration:completion:")]
		bool CloseLeftViewAnimated (bool animated, double duration, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeLeftViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("closeLeftViewBouncing:")]
		bool CloseLeftViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)closeLeftViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeLeftViewBouncing:completion:")]
		bool CloseLeftViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)toggleRightView;
		[Export ("toggleRightView")]
		bool ToggleRightView();
		
		//- (BOOL)openRightView;
		[Export ("openRightView")]
		bool OpenRightView();
		
		//- (BOOL)closeRightView;
		[Export ("closeRightView")]
		bool CloseRightView();
		
		//- (BOOL)toggleRightViewAnimated:(BOOL)animated;
		[Export ("toggleRightViewAnimated:")]
		bool ToggleRightViewAnimated (bool animated);
		
		//- (BOOL)toggleRightViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("toggleRightViewAnimated:completion:")]
		bool ToggleRightViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)openRightViewAnimated:(BOOL)animated;
		[Export ("openRightViewAnimated:")]
		bool OpenRightViewAnimated (bool animated);
		
		//- (BOOL)openRightViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("openRightViewAnimated:completion:")]
		bool OpenRightViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)openRightViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("openRightViewBouncing:")]
		bool OpenRightViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)openRightViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("openRightViewBouncing:completion:")]
		bool OpenRightViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeRightViewAnimated:(BOOL)animated;
		[Export ("closeRightViewAnimated:")]
		bool CloseRightViewAnimated (bool animated);
		
		//- (BOOL)closeRightViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeRightViewAnimated:completion:")]
		bool CloseRightViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeRightViewAnimated:(BOOL)animated duration:(NSTimeInterval)duration completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeRightViewAnimated:duration:completion:")]
		bool CloseRightViewAnimated (bool animated, double duration, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeRightViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("closeRightViewBouncing:")]
		bool CloseRightViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)closeRightViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeRightViewBouncing:completion:")]
		bool CloseRightViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)toggleTopView;
		[Export ("toggleTopView")]
		bool ToggleTopView();
		
		//- (BOOL)openTopView;
		[Export ("openTopView")]
		bool OpenTopView();
		
		//- (BOOL)closeTopView;
		[Export ("closeTopView")]
		bool CloseTopView();
		
		//- (BOOL)toggleTopViewAnimated:(BOOL)animated;
		[Export ("toggleTopViewAnimated:")]
		bool ToggleTopViewAnimated (bool animated);
		
		//- (BOOL)toggleTopViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("toggleTopViewAnimated:completion:")]
		bool ToggleTopViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)openTopViewAnimated:(BOOL)animated;
		[Export ("openTopViewAnimated:")]
		bool OpenTopViewAnimated (bool animated);
		
		//- (BOOL)openTopViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("openTopViewAnimated:completion:")]
		bool OpenTopViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)openTopViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("openTopViewBouncing:")]
		bool OpenTopViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)openTopViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("openTopViewBouncing:completion:")]
		bool OpenTopViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeTopViewAnimated:(BOOL)animated;
		[Export ("closeTopViewAnimated:")]
		bool CloseTopViewAnimated (bool animated);
		
		//- (BOOL)closeTopViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeTopViewAnimated:completion:")]
		bool CloseTopViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeTopViewAnimated:(BOOL)animated duration:(NSTimeInterval)duration completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeTopViewAnimated:duration:completion:")]
		bool CloseTopViewAnimated (bool animated, double duration, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeTopViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("closeTopViewBouncing:")]
		bool CloseTopViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)closeTopViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeTopViewBouncing:completion:")]
		bool CloseTopViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)toggleBottomView;
		[Export ("toggleBottomView")]
		bool ToggleBottomView();
		
		//- (BOOL)openBottomView;
		[Export ("openBottomView")]
		bool OpenBottomView();
		
		//- (BOOL)closeBottomView;
		[Export ("closeBottomView")]
		bool CloseBottomView();
		
		//- (BOOL)toggleBottomViewAnimated:(BOOL)animated;
		[Export ("toggleBottomViewAnimated:")]
		bool ToggleBottomViewAnimated (bool animated);
		
		//- (BOOL)toggleBottomViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("toggleBottomViewAnimated:completion:")]
		bool ToggleBottomViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)openBottomViewAnimated:(BOOL)animated;
		[Export ("openBottomViewAnimated:")]
		bool OpenBottomViewAnimated (bool animated);
		
		//- (BOOL)openBottomViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("openBottomViewAnimated:completion:")]
		bool OpenBottomViewAnimated (bool animated, IIViewDeckControllerBlock  completed);
		
		//- (BOOL)openBottomViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("openBottomViewBouncing:")]
		bool OpenBottomViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)openBottomViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("openBottomViewBouncing:completion:")]
		bool OpenBottomViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeBottomViewAnimated:(BOOL)animated;
		[Export ("closeBottomViewAnimated:")]
		bool CloseBottomViewAnimated (bool animated);
		
		//- (BOOL)closeBottomViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeBottomViewAnimated:completion:")]
		bool CloseBottomViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeBottomViewAnimated:(BOOL)animated duration:(NSTimeInterval)duration completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeBottomViewAnimated:duration:completion:")]
		bool CloseBottomViewAnimated (bool animated, double duration, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeBottomViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("closeBottomViewBouncing:")]
		bool CloseBottomViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)closeBottomViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeBottomViewBouncing:completion:")]
		bool CloseBottomViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)toggleOpenView;
		[Export ("toggleOpenView")]
		bool ToggleOpenView();
		
		//- (BOOL)toggleOpenViewAnimated:(BOOL)animated;
		[Export ("toggleOpenViewAnimated:")]
		bool ToggleOpenViewAnimated (bool animated);
		
		//- (BOOL)toggleOpenViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("toggleOpenViewAnimated:completion:")]
		bool ToggleOpenViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeOpenView;
		[Export ("closeOpenView")]
		bool CloseOpenView();
		
		//- (BOOL)closeOpenViewAnimated:(BOOL)animated;
		[Export ("closeOpenViewAnimated:")]
		bool CloseOpenViewAnimated (bool animated);
		
		//- (BOOL)closeOpenViewAnimated:(BOOL)animated completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeOpenViewAnimated:completion:")]
		bool CloseOpenViewAnimated (bool animated, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeOpenViewAnimated:(BOOL)animated duration:(NSTimeInterval)duration completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeOpenViewAnimated:duration:completion:")]
		bool CloseOpenViewAnimated (bool animated, double duration, IIViewDeckControllerBlock completed);
		
		//- (BOOL)closeOpenViewBouncing:(IIViewDeckControllerBounceBlock)bounced;
		[Export ("closeOpenViewBouncing:")]
		bool CloseOpenViewBouncing (IIViewDeckControllerBounceBlock bounced);
		
		//- (BOOL)closeOpenViewBouncing:(IIViewDeckControllerBounceBlock)bounced completion:(IIViewDeckControllerBlock)completed;
		[Export ("closeOpenViewBouncing:completion:")]
		bool CloseOpenViewBouncing (IIViewDeckControllerBounceBlock bounced, IIViewDeckControllerBlock completed);
		
		//- (BOOL)previewBounceView:(IIViewDeckSide)viewDeckSide;
		[Export ("previewBounceView:")]
		bool PreviewBounceView (IIViewDeckSide viewDeckSide);
		
		//- (BOOL)previewBounceView:(IIViewDeckSide)viewDeckSide withCompletion:(IIViewDeckControllerBlock)completed;
		[Export ("previewBounceView:withCompletion:")]
		bool PreviewBounceView (IIViewDeckSide viewDeckSide, IIViewDeckControllerBlock completed);
		
		//- (BOOL)previewBounceView:(IIViewDeckSide)viewDeckSide toDistance:(CGFloat)distance duration:(NSTimeInterval)duration callDelegate:(BOOL)callDelegate completion:(IIViewDeckControllerBlock)completed;
		[Export ("previewBounceView:toDistance:duration:callDelegate:completion:")]
		bool PreviewBounceView (IIViewDeckSide viewDeckSide, float distance, double duration, bool callDelegate, IntPtr completed);
		
		//- (BOOL)previewBounceView:(IIViewDeckSide)viewDeckSide toDistance:(CGFloat)distance duration:(NSTimeInterval)duration numberOfBounces:(CGFloat)numberOfBounces dampingFactor:(CGFloat)zeta callDelegate:(BOOL)callDelegate completion:(IIViewDeckControllerBlock)completed;
		[Export ("previewBounceView:toDistance:duration:numberOfBounces:dampingFactor:callDelegate:completion:")]
		bool PreviewBounceView (IIViewDeckSide viewDeckSide, float distance, double duration, float numberOfBounces, float zeta, bool callDelegate, IntPtr completed);
		
		//- (BOOL)canRightViewPushViewControllerOverCenterController;
		[Export ("canRightViewPushViewControllerOverCenterController")]
		bool CanRightViewPushViewControllerOverCenterController { get; }
		
		//- (void)rightViewPushViewControllerOverCenterController:(UIViewController*)controller;
		[Export ("rightViewPushViewControllerOverCenterController:")]
		void RightViewPushViewControllerOverCenterController (UIViewController controller);
		
		//- (BOOL)isSideClosed:(IIViewDeckSide)viewDeckSide;
		[Export ("isSideClosed:")]
		bool IsSideClosed (IIViewDeckSide viewDeckSide);
		
		//- (BOOL)isSideOpen:(IIViewDeckSide)viewDeckSide;
		[Export ("isSideOpen:")]
		bool IsSideOpen (IIViewDeckSide viewDeckSide);
		
		//- (BOOL)isAnySideOpen;
		[Export ("isAnySideOpen")]
		bool IsAnySideOpen { get; }
		
		//- (CGFloat)statusBarHeight;
		[Export ("statusBarHeight")]
		float StatusBarHeight { get; }
		

		
		}

	[Model]
	[BaseType (typeof (NSObject))]
	interface IIViewDeckControllerDelegate {

		//@optional- (BOOL)viewDeckController:(IIViewDeckController*)viewDeckController shouldPan:(UIPanGestureRecognizer*)panGestureRecognizer;
		[Abstract, Export ("viewDeckController:shouldPan:")]
		bool ViewDeckController (IIViewDeckController viewDeckController, UIPanGestureRecognizer panGestureRecognizer);

		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController applyShadow:(CALayer*)shadowLayer withBounds:(CGRect)rect;
		[Abstract, Export ("viewDeckController:applyShadow:withBounds:")]
		void ViewDeckController (IIViewDeckController viewDeckController, CALayer shadowLayer, System.Drawing.RectangleF rect);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController didChangeOffset:(CGFloat)offset orientation:(IIViewDeckOffsetOrientation)orientation panning:(BOOL)panning;
		[Abstract, Export ("viewDeckController:didChangeOffset:orientation:panning:")]
		void ViewDeckController (IIViewDeckController viewDeckController, float offset, IIViewDeckOffsetOrientation orientation, bool panning);
		
		//- (void)viewDeckController:(IIViewDeckController *)viewDeckController didBounceViewSide:(IIViewDeckSide)viewDeckSide openingController:(UIViewController*)openingController;
		[Abstract, Export ("viewDeckController:didBounceViewSide:openingController:")]
		void ViewDeckController (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, UIViewController openingController);
		
		//- (void)viewDeckController:(IIViewDeckController *)viewDeckController didBounceViewSide:(IIViewDeckSide)viewDeckSide closingController:(UIViewController*)closingController;
		[Abstract, Export ("viewDeckController:didBounceViewSide:closingController:")]
		void ViewDeckControllerDidBounceViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, UIViewController closingController);
		
		//- (BOOL)viewDeckController:(IIViewDeckController*)viewDeckController shouldOpenViewSide:(IIViewDeckSide)viewDeckSide;
		[Abstract, Export ("viewDeckController:shouldOpenViewSide:")]
		bool ViewDeckController (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController willOpenViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:willOpenViewSide:animated:")]
		void ViewDeckController (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController didOpenViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:didOpenViewSide:animated:")]
		void ViewDeckControllerDidOpenViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (BOOL)viewDeckController:(IIViewDeckController*)viewDeckController shouldCloseViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:shouldCloseViewSide:animated:")]
		bool ViewDeckControllerShouldCloseViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController willCloseViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:willCloseViewSide:animated:")]
		void ViewDeckControllerWillCloseViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController didCloseViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:didCloseViewSide:animated:")]
		void ViewDeckControllerDidCloseViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (void)viewDeckController:(IIViewDeckController*)viewDeckController didShowCenterViewFromSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:didShowCenterViewFromSide:animated:")]
		void ViewDeckControllerDidShowCenterViewFromSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (BOOL)viewDeckController:(IIViewDeckController *)viewDeckController shouldPreviewBounceViewSide:(IIViewDeckSide)viewDeckSide;
		[Abstract, Export ("viewDeckController:shouldPreviewBounceViewSide:")]
		bool ViewDeckControllerShouldPreviewBounceViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide);
		
		//- (void)viewDeckController:(IIViewDeckController *)viewDeckController willPreviewBounceViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:willPreviewBounceViewSide:animated:")]
		void ViewDeckControllerWillPreviewBounceViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (void)viewDeckController:(IIViewDeckController *)viewDeckController didPreviewBounceViewSide:(IIViewDeckSide)viewDeckSide animated:(BOOL)animated;
		[Abstract, Export ("viewDeckController:didPreviewBounceViewSide:animated:")]
		void ViewDeckControllerDidPreviewBounceViewSide (IIViewDeckController viewDeckController, IIViewDeckSide viewDeckSide, bool animated);
		
		//- (CGFloat)viewDeckController:(IIViewDeckController*)viewDeckController changesLedge:(CGFloat)ledge forSide:(IIViewDeckSide)viewDeckSide;
		[Abstract, Export ("viewDeckController:changesLedge:forSide:")]
		float ViewDeckController (IIViewDeckController viewDeckController, float ledge, IIViewDeckSide viewDeckSide);
		//*/
	}
	
	//[Category]
	[BaseType (typeof (UIViewController))]
	interface UIViewDeckItem {
		
		//@property(nonatomic,readonly,retain) IIViewDeckController *viewDeckController; 
		//[Export ("viewDeckController", ArgumentSemantic.Retain)]
		//IIViewDeckController ViewDeckController { get;  }
	}
	//delegates
	delegate void IIWrapControllerDelegate (UIViewController controller);
	delegate void IIWrapControllerAnimatedDelegate (UIViewController controller, bool animated);

	[BaseType (typeof(UIViewController))]
	interface IIWrapController
	{

		//@property (nonatomic, readonly, retain) UIViewController* wrappedController;
		[Export ("wrappedController", ArgumentSemantic.Retain)]
		UIViewController WrappedController { get;  }
		
		//@property (nonatomic, copy) void(^onViewDidLoad)(IIWrapController* controller);
		[Export ("viewDidLoad", ArgumentSemantic.Copy)]
		IIWrapControllerDelegate onViewDidLoad { get; set;  }
		
		//@property (nonatomic, copy) void(^onViewWillAppear)(IIWrapController* controller, BOOL animated);
		[Export ("ViewWillAppear", ArgumentSemantic.Copy)]
		IIWrapControllerAnimatedDelegate onViewWillAppear{ get; set;  }
		
		//@property (nonatomic, copy) void(^onViewDidAppear)(IIWrapController* controller, BOOL animated);
		[Export ("ViewDidAppear", ArgumentSemantic.Copy)]
		IIWrapControllerAnimatedDelegate onViewDidAppear{ get; set;  }
		
		//@property (nonatomic, copy) void(^onViewWillDisappear)(IIWrapController* controller, BOOL animated);
		[Export ("ViewWillDisappear", ArgumentSemantic.Copy)]
		IIWrapControllerAnimatedDelegate onViewWillDisappear{ get; set;  }
		
		//@property (nonatomic, copy) void(^onViewDidDisappear)(IIWrapController* controller, BOOL animated);
		[Export ("ViewDidDisappear", ArgumentSemantic.Copy)]
		IIWrapControllerAnimatedDelegate onViewDidDisappear{ get; set;  }
		
		
	}

	[BaseType (typeof (UIViewController))]
	//[Category]
	interface WrapControllerItem {
		
		//- (id)initWithViewController:(UIViewController*)controller;
		[Export ("initWithViewController:")]
		IntPtr Constructor (UIViewController controller);

			//@property(nonatomic,readonly,assign) IIWrapController *wrapController; 
			[Export ("wrapController", ArgumentSemantic.Assign)]
			IIWrapController WrapController { get; }
		
	}

		[BaseType (typeof (IIWrapController))]
		interface IISideController 
		{
		//@property (nonatomic, assign) BOOL animatedShrink; 
		[Export ("animatedShrink", ArgumentSemantic.Assign)]
		bool AnimatedShrink { get; set;  }

		
		//- (id)initWithViewController:(UIViewController*)controller constrained:(CGFloat)constrainedSize;
		[Export ("initWithViewController:constrained:")]
		IntPtr Constructor (UIViewController controller, float constrainedSize);
		}
		
}
