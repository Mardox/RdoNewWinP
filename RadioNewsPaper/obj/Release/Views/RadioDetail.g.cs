﻿#pragma checksum "C:\Users\HooMan\Desktop\Windows Apps\RdoNewWinP\RadioNewsPaper\Views\RadioDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E9018EE23A928C27EAC1159D7EE201D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AdMediator.WindowsPhone8;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace RadioNewsPaper.Views {
    
    
    public partial class RadioDetail : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard RotateCircle;
        
        internal Microsoft.Phone.Shell.ApplicationBar AppBar;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtState;
        
        internal System.Windows.Controls.TextBlock warning;
        
        internal System.Windows.Controls.TextBlock txtTrack;
        
        internal System.Windows.Controls.ProgressBar positionIndicator;
        
        internal System.Windows.Controls.TextBlock textPosition;
        
        internal System.Windows.Controls.TextBlock textRemaining;
        
        internal System.Windows.Controls.ProgressBar bufferingProgress;
        
        internal System.Windows.Controls.Grid AdPanel;
        
        internal Microsoft.AdMediator.WindowsPhone8.AdMediatorControl AdMediator_Radio_Detail;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadioNewsPaper;component/Views/RadioDetail.xaml", System.UriKind.Relative));
            this.RotateCircle = ((System.Windows.Media.Animation.Storyboard)(this.FindName("RotateCircle")));
            this.AppBar = ((Microsoft.Phone.Shell.ApplicationBar)(this.FindName("AppBar")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtState = ((System.Windows.Controls.TextBlock)(this.FindName("txtState")));
            this.warning = ((System.Windows.Controls.TextBlock)(this.FindName("warning")));
            this.txtTrack = ((System.Windows.Controls.TextBlock)(this.FindName("txtTrack")));
            this.positionIndicator = ((System.Windows.Controls.ProgressBar)(this.FindName("positionIndicator")));
            this.textPosition = ((System.Windows.Controls.TextBlock)(this.FindName("textPosition")));
            this.textRemaining = ((System.Windows.Controls.TextBlock)(this.FindName("textRemaining")));
            this.bufferingProgress = ((System.Windows.Controls.ProgressBar)(this.FindName("bufferingProgress")));
            this.AdPanel = ((System.Windows.Controls.Grid)(this.FindName("AdPanel")));
            this.AdMediator_Radio_Detail = ((Microsoft.AdMediator.WindowsPhone8.AdMediatorControl)(this.FindName("AdMediator_Radio_Detail")));
        }
    }
}

