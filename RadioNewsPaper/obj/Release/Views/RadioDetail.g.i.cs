﻿#pragma checksum "C:\Users\Kalyan\Source\Repos\RdoNewWinP\RadioNewsPaper\Views\RadioDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C73C79D0A5E08290A8EEFD3860DE1707"
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
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.StackPanel mainPanel;
        
        internal System.Windows.Controls.TextBlock stationName;
        
        internal System.Windows.Controls.TextBlock artistName;
        
        internal System.Windows.Controls.StackPanel adPanel;
        
        internal System.Windows.Controls.ProgressBar bufferingProgress;
        
        internal System.Windows.Controls.TextBlock statusBox;
        
        internal System.Windows.Controls.Image play;
        
        internal System.Windows.Controls.Image stop;
        
        internal System.Windows.Controls.Primitives.Popup recordPopUp;
        
        internal System.Windows.Controls.Grid ReelGrid;
        
        internal System.Windows.Controls.Primitives.ToggleButton recordButton;
        
        internal System.Windows.Controls.Button playButton;
        
        internal System.Windows.Controls.Button saveButton;
        
        internal System.Windows.Controls.MediaElement playAudio;
        
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
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.mainPanel = ((System.Windows.Controls.StackPanel)(this.FindName("mainPanel")));
            this.stationName = ((System.Windows.Controls.TextBlock)(this.FindName("stationName")));
            this.artistName = ((System.Windows.Controls.TextBlock)(this.FindName("artistName")));
            this.adPanel = ((System.Windows.Controls.StackPanel)(this.FindName("adPanel")));
            this.bufferingProgress = ((System.Windows.Controls.ProgressBar)(this.FindName("bufferingProgress")));
            this.statusBox = ((System.Windows.Controls.TextBlock)(this.FindName("statusBox")));
            this.play = ((System.Windows.Controls.Image)(this.FindName("play")));
            this.stop = ((System.Windows.Controls.Image)(this.FindName("stop")));
            this.recordPopUp = ((System.Windows.Controls.Primitives.Popup)(this.FindName("recordPopUp")));
            this.ReelGrid = ((System.Windows.Controls.Grid)(this.FindName("ReelGrid")));
            this.recordButton = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("recordButton")));
            this.playButton = ((System.Windows.Controls.Button)(this.FindName("playButton")));
            this.saveButton = ((System.Windows.Controls.Button)(this.FindName("saveButton")));
            this.playAudio = ((System.Windows.Controls.MediaElement)(this.FindName("playAudio")));
        }
    }
}

