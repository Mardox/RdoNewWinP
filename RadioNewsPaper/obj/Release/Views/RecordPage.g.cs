﻿#pragma checksum "C:\Users\Kalyan\Source\Repos\RdoNewWinP\RadioNewsPaper\Views\RecordPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A72C2100800C0889E92748A031AF0FA"
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
    
    
    public partial class RecordPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button recordStartButton;
        
        internal System.Windows.Controls.Button recordStopButton;
        
        internal System.Windows.Controls.Button playButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadioNewsPaper;component/Views/RecordPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.recordStartButton = ((System.Windows.Controls.Button)(this.FindName("recordStartButton")));
            this.recordStopButton = ((System.Windows.Controls.Button)(this.FindName("recordStopButton")));
            this.playButton = ((System.Windows.Controls.Button)(this.FindName("playButton")));
            this.playAudio = ((System.Windows.Controls.MediaElement)(this.FindName("playAudio")));
        }
    }
}

