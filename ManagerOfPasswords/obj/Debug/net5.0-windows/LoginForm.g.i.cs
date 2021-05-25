﻿#pragma checksum "..\..\..\LoginForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "347E813D2CE68DC15044AB54ECE711BD7A25C837"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ManagerOfPasswords;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace ManagerOfPasswords {
    
    
    /// <summary>
    /// LoginForm
    /// </summary>
    public partial class LoginForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackStep;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label HeadText;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginField;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passField;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox repeatPass;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Entry;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Register;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\LoginForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel WarningMessages;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ManagerOfPasswords;component/loginform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LoginForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BackStep = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\LoginForm.xaml"
            this.BackStep.Click += new System.Windows.RoutedEventHandler(this.BackStep_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HeadText = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.loginField = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\LoginForm.xaml"
            this.loginField.KeyDown += new System.Windows.Input.KeyEventHandler(this.LoginField_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.passField = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 62 "..\..\..\LoginForm.xaml"
            this.passField.KeyDown += new System.Windows.Input.KeyEventHandler(this.PassField_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.repeatPass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 63 "..\..\..\LoginForm.xaml"
            this.repeatPass.KeyDown += new System.Windows.Input.KeyEventHandler(this.PassField_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Entry = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\LoginForm.xaml"
            this.Entry.Click += new System.Windows.RoutedEventHandler(this.Entry_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Register = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\LoginForm.xaml"
            this.Register.Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.WarningMessages = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

