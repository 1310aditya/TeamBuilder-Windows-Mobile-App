﻿

#pragma checksum "C:\Users\anuradha\Documents\GitHub\TeamBuilder1.0\CricketTeamDistributor\AddTeam.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "42A3E4AD3B7B740B4FCD9635FBF9962B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CricketTeamDistributor
{
    partial class AddTeam : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 42 "..\..\AddTeam.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.NameTextBox_LostFocus;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 63 "..\..\AddTeam.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.FirstAttBox_LostFocus;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 71 "..\..\AddTeam.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.SecondAttBox_LostFocus;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 77 "..\..\AddTeam.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddtoDataButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


