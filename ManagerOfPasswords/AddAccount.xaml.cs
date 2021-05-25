using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerOfPasswords {
    /// <summary>
    /// Class for adding new account or update old if exists
    /// </summary>
    public partial class AddAccount : Window {
        readonly Window main;
        readonly DataBase db;
        readonly int user_id;

        public AddAccount(Window ParentWindow, DataBase db, int user_id) {
            InitializeComponent();
            main = ParentWindow;
            this.db = db;
            this.user_id = user_id;
            Fields.Children[0].Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            main.Show();
        }

        private void backstep_Click(object sender, RoutedEventArgs e) {
            Close();
        }


        /// <summary>
        /// Focus next unfilled field or click add button
        /// </summary>
        private void CheckFields(object sender, KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {

                if (FocusBlankFields() && CheckValidityFields()) {
                    this.add.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
        
        /// <summary>
        /// Check validation fields
        /// </summary>
        /// <returns>Check result</returns>
        private bool CheckValidityFields() {
            if (!add_address.Text.Contains(".")) {
                add_address.ToolTip = "Некорректно введен адрес сайта";
                add_address.Background = new SolidColorBrush(Color.FromRgb(0x4C, 0x2F, 0x2F));
                return false;
            }
            else {
                add_address.ToolTip = null;
                add_address.Background = Brushes.Transparent;
            }

            if (add_pass.Password != add_repeat.Password) {
                add_repeat.ToolTip = "Пароли не совпадают";
                add_repeat.Background = new SolidColorBrush(Color.FromRgb(0x4C, 0x2F, 0x2F));
                return false;
            }
            else {
                add_repeat.ToolTip = null;
                add_repeat.Background = Brushes.Transparent;
            }

            return true;
        }

        /// <summary>
        /// Check all fields with text and make focus on field where count
        /// letter less than 6
        /// </summary>
        /// <returns>Check result</returns>
        private bool FocusBlankFields() {
            foreach(UIElement element in Fields.Children) {
                if(element.GetType().Name == "TextBox") {
                    if(((TextBox)element).Text.Length < 6) {
                        element.Focus();
                        return false;
                    }
                }
                else if(element.GetType().Name != "StackPanel") {
                    if (((PasswordBox)element).Password.Length < 6) {
                        element.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private void add_Click(object sender, RoutedEventArgs e) {

        }
    }
}
