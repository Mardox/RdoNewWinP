﻿#pragma checksum "C:\Users\Kalyan\Source\Repos\RdoNewWinP\RadioNewsPaper\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B4BFCECB02791FB1CB74FB4F3A8F3239"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using RateMyApp.Controls;
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


namespace RadioNewsPaper {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard RotateCircle;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.LongListSelector RadioList;
        
        internal Microsoft.Phone.Controls.LongListSelector NewsPaperList;
        
        internal Microsoft.Phone.Controls.LongListSelector FavList;
        
        internal Microsoft.Phone.Controls.LongListSelector RecList;
        
        internal Microsoft.Phone.Controls.LongListSelector MoreList;
        
        internal System.Windows.Controls.Primitives.Popup recordPlayPopUp;
        
        internal System.Windows.Controls.Grid ReelGrid;
        
        internal System.Windows.Controls.MediaElement playRecAudio;
        
        internal RateMyApp.Controls.FeedbackOverlay FeedbackOverlay;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadioNewsPaper;component/MainPage.xaml", System.UriKind.Relative));
            this.RotateCircle = ((System.Windows.Media.Animation.Storyboard)(this.FindName("RotateCircle")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.RadioList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("RadioList")));
            this.NewsPaperList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("NewsPaperList")));
            this.FavList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("FavList")));
            this.RecList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("RecList")));
            this.MoreList = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("MoreList")));
            this.recordPlayPopUp = ((System.Windows.Controls.Primitives.Popup)(this.FindName("recordPlayPopUp")));
            this.ReelGrid = ((System.Windows.Controls.Grid)(this.FindName("ReelGrid")));
            this.playRecAudio = ((System.Windows.Controls.MediaElement)(this.FindName("playRecAudio")));
            this.FeedbackOverlay = ((RateMyApp.Controls.FeedbackOverlay)(this.FindName("FeedbackOverlay")));
        }
    }
}

