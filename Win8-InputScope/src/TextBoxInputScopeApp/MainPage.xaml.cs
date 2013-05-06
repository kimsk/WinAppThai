using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TextBoxInputScopeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IDictionary<string, InputScopeNameValue> inputScopeValues = new Dictionary<string, InputScopeNameValue>();        
        public MainPage()
        {
            this.InitializeComponent();   
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var inputScopeNameValue = typeof(InputScopeNameValue);                        
            var inputScopeNameValues = Enum.GetValues(inputScopeNameValue);

            foreach (var i in inputScopeNameValues)
            {                
                inputScopeValues[i.ToString()] = (InputScopeNameValue)i; 
            }

            anInputScopeComboBoxes.ItemsSource = inputScopeValues.Keys;            
        }

        private void anInputScopeComboBoxes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            InputScope scope = new InputScope();
            InputScopeName scopeName = new InputScopeName { NameValue = (InputScopeNameValue)(inputScopeValues[e.AddedItems.First().ToString()]) };
            scope.Names.Add(scopeName);
            aBigTextBox.InputScope = scope;
            aBigTextBox.Focus(FocusState.Keyboard);

        }
    }    
}
