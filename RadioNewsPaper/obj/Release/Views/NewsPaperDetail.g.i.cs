﻿#pragma checksum "C:\Users\HooMan\Desktop\Windows Apps\RdoNewWinP\RadioNewsPaper\Views\NewsPaperDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A08BF563F0B6A51B90954407841946C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AdMediator.WindowsPhone8;
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
    
    
    public partial class NewsPaperDetail : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.AdMediator.WindowsPhone8.AdMediatorControl AdMediator_436C16;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.WebBrowser NewsPaperBrowser;
        
        internal System.Windows.Controls.ProgressBar browserProgress;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadioNewsPaper;component/Views/NewsPaperDetail.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.AdMediator_436C16 = ((Microsoft.AdMediator.WindowsPhone8.AdMediatorControl)(this.FindName("AdMediator_436C16")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.NewsPaperBrowser = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("NewsPaperBrowser")));
            this.browserProgress = ((System.Windows.Controls.ProgressBar)(this.FindName("browserProgress")));
        }
    }
}

