﻿#pragma checksum "..\..\..\..\Pages\LoginAccountPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3B3ED37FC9715299C023E94FB49DA08DDDCC4BE2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using UI.Pages;


namespace UI.Pages {
    
    
    /// <summary>
    /// LoginAccountPage
    /// </summary>
    public partial class LoginAccountPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Pages\LoginAccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border loginBorder;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\LoginAccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginTB;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\LoginAccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border passwordBorder;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\LoginAccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI;component/pages/loginaccountpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\LoginAccountPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginBorder = ((System.Windows.Controls.Border)(target));
            
            #line 46 "..\..\..\..\Pages\LoginAccountPage.xaml"
            this.loginBorder.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseEnter);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\Pages\LoginAccountPage.xaml"
            this.loginBorder.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.loginTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordBorder = ((System.Windows.Controls.Border)(target));
            
            #line 57 "..\..\..\..\Pages\LoginAccountPage.xaml"
            this.passwordBorder.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseEnter);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\Pages\LoginAccountPage.xaml"
            this.passwordBorder.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.passwordTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 66 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.LoginBT_MouseEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.LoginBT_MouseLeave);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.LoginAccount_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 80 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseEnter);
            
            #line default
            #line hidden
            
            #line 81 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.TextBorder_MouseLeave);
            
            #line default
            #line hidden
            
            #line 82 "..\..\..\..\Pages\LoginAccountPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

