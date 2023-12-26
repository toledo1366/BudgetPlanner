using System;
using Android.App;
using Android.Runtime;
using BudgetPlanner.Core;
using MvvmCross.Platforms.Android.Views;

namespace BudgetPlanner
{
	[Application]
	public class MainApplication : MvxAndroidApplication<Setup, App>
	{
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
        {
        }
    }
}

