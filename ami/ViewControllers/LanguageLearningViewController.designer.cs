// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ami.ViewControllers
{
	[Register ("LanguageLearningViewController")]
	partial class LanguageLearningViewController
	{
		[Outlet]
		UIKit.UISegmentedControl FromLanguageSegment { get; set; }

		[Outlet]
		UIKit.UIButton PlayTranslatedButton { get; set; }

		[Outlet]
		UIKit.UISegmentedControl ToLanguageSegment { get; set; }

		[Outlet]
		UIKit.UITextField TranslationTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FromLanguageSegment != null) {
				FromLanguageSegment.Dispose ();
				FromLanguageSegment = null;
			}

			if (PlayTranslatedButton != null) {
				PlayTranslatedButton.Dispose ();
				PlayTranslatedButton = null;
			}

			if (ToLanguageSegment != null) {
				ToLanguageSegment.Dispose ();
				ToLanguageSegment = null;
			}

			if (TranslationTextField != null) {
				TranslationTextField.Dispose ();
				TranslationTextField = null;
			}
		}
	}
}
