using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ManagerOfPasswords {
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window {
        private readonly DataBase db;
        private int user_id = -1;
        public LoginForm() {
            db = new DataBase("postgres", "rekbr1488");
            if (!db.ConnectToDB()) {
                // TODO: если не удалось подключиться к БД
                MessageBox.Show("не удалось подключиться к БД");
                this.Close();
            }
            InitializeComponent();
            loginField.Focus();
        }

        private void CheckLoginFields(ref bool flag) {
            if (loginField.Text.Length < 6) {
                loginField.ToolTip = "Длина логина должна быть больше 5 символов.";
                loginField.Background = new SolidColorBrush(Color.FromRgb(0x4C, 0x2F, 0x2F));
                flag = false;
            }
            else {
                ClearToolTips(true);
            }

            if (passField.Password.Length < 6) {
                passField.ToolTip = "Длина пароля должна быть больше 5 символов.";
                passField.Background = new SolidColorBrush(Color.FromRgb(0x4C, 0x2F, 0x2F));
                flag = false;
            }
            else {
                ClearToolTips(false);
            }

            if(repeatPass.Visibility == Visibility.Visible && (passField.Password != repeatPass.Password || repeatPass.Password.Length < 6)) {
                repeatPass.ToolTip = "Введенные пароли не совпадают.";
                repeatPass.Focus();
                repeatPass.Background = new SolidColorBrush(Color.FromRgb(0x4C, 0x2F, 0x2F));
                flag = false;
            }
            else {
                ClearToolTips(false);
            }
        }

        private void ClearToolTips(bool isLoginFields) {
            if (isLoginFields) {
                loginField.ToolTip = null;
                loginField.Background = Brushes.Transparent;
            }
            else {
                passField.ToolTip = null;
                passField.Background = Brushes.Transparent;
                repeatPass.ToolTip = null;
                repeatPass.Background = Brushes.Transparent;
            }
        }

        /// <summary>
        /// Make request into db and start main window or show message about mistake
        /// </summary>
        private void RequestMainWindow() {
            ClearToolTips(true);
            ClearToolTips(false);

            user_id = db.Login(loginField.Text.Trim(), passField.Password.Trim());

            if (user_id != -1) {
                MainWindow mainWindow = new(db, user_id, loginField.Text);
                Close();
                mainWindow.Show();
            }
            else {
                WarningMessages.Visibility = Visibility.Visible;
            }
        }

        private void Entry_Click(object sender, RoutedEventArgs e) {
            bool flag_all_right = true;

            CheckLoginFields(ref flag_all_right);

            if (flag_all_right) {
                RequestMainWindow();
            }
        }

        private void LoginField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (passField.Password.Length < 6) {
                    passField.Focus();
                }
                else if (loginField.Text.Length >= 6) {
                    this.Entry.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        /// <summary>
        /// Focus and refocus fields if click enter
        /// </summary>]
        private void PassField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                if (loginField.Text.Length < 6) {
                    loginField.Focus();
                }
                else if (passField.Password.Length >= 6 && repeatPass.IsVisible == false) {
                    Entry.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else if(passField.Password.Length < 6) {
                    passField.Focus();
                }
                else if(repeatPass.Password.Length < 6){
                    repeatPass.Focus();
                }
                else {
                    Register.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void ShowHideRegisterForm(bool needToShow = false) {
            HeadText.Content = needToShow ? "Регистрация" : "Вход";
            repeatPass.Password = string.Empty;
            passField.Password = string.Empty;
            repeatPass.Visibility = needToShow ? Visibility.Visible : Visibility.Collapsed;
            Entry.Visibility = needToShow ? Visibility.Collapsed : Visibility.Visible;
            Register.Content = needToShow ? "Зарегистрироваться" : "Регистрация";
            Register.Width = needToShow ? 200 : 100;
            BackStep.Visibility = needToShow ? Visibility.Visible : Visibility.Collapsed;
            Grid.SetColumnSpan(Register, needToShow ? 2 : 1);
            Grid.SetColumn(Register, needToShow ? 0 : 1);

            if (needToShow)
                loginField.Focus();
        }

        private bool CheckAllRegisterFields() {
            bool allRight = true;
            CheckLoginFields(ref allRight);
            return allRight;
        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            bool showRegisterForm = HeadText.Content.ToString() == "Вход";

            if (!showRegisterForm) {
                if (CheckAllRegisterFields()) {
                    if(!db.RegisterNewUser(loginField.Text.Trim(), passField.Password.Trim())) {
                        WarningMessages.Visibility = Visibility.Visible;
                        TextBlock message = (TextBlock)WarningMessages.Children[1];
                        message.Text = "Вы ввели существующие логин и пароль.";
                        WarningMessages.Children[1] = message;
                        showRegisterForm = true;
                    }
                    else {
                        WarningMessages.Visibility = Visibility.Collapsed;
                        TextBlock message = (TextBlock)WarningMessages.Children[1];
                        message.Text = "Не удалось войти, проверьте правильность логина и пароля";
                        WarningMessages.Children[1] = message;
                    }
                    
                }
                else {
                    WarningMessages.Visibility = Visibility.Visible;
                    TextBlock message = (TextBlock) WarningMessages.Children[1];
                    message.Text = "Некорректно введены поля регистрации, повторите ввод";
                    WarningMessages.Children[1] = message;
                    showRegisterForm = true;
                }
            }

            ShowHideRegisterForm(showRegisterForm);
        }

        private void BackStep_Click(object sender, RoutedEventArgs e) {
            WarningMessages.Visibility = Visibility.Collapsed;
            ShowHideRegisterForm();
        }
    }
}
