using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ManagerOfPasswords {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        readonly DataBase db;
        private readonly int user_id;
        private List<Account> accounts;

        public MainWindow(DataBase db, int user_id, string user_login) {
            this.db = db;
            this.user_id = user_id;

            InitializeComponent();
            global_user_login.Content = user_login;
            FillUIAccountsList();

            if (accounts.Count == 0)
                search_site.IsEnabled = false;
        }

        private void ChangeFieldSelectedSite_Click(object sender, RoutedEventArgs e) {

        }


        //================ select account and show data ========================
        private void SelectAccount(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Message.Visibility = Visibility.Collapsed;
            AccountFields.Visibility = Visibility.Visible;
            Grid grid = (Grid)((Border)sender).Child;

            if(grid.Children.Count != 3) {
                grid.Children.Add(CreateBorder());
            }

            ShowAccountData((Border) sender);
        }

        private void ShowAccountData(Border elem) {
            Account needed_item = null;
            foreach(var item in accounts) {
                if (item.NameSite == (string)((Label)((Grid)elem.Child).Children[0]).Content
                    && item.Login == (string)((Label)((Grid)elem.Child).Children[1]).Content) {
                    needed_item = item;
                    break;
                }
            }
            if(needed_item != null) {
                name_site.Content = needed_item.NameSite;
                site_address.Text = needed_item.NameSite;
                user_login.Content = needed_item.Login;
                user_password.Password = needed_item.Password;
                date_create.Content = needed_item.CreateDate.ToString("dd/MM/yyyy");
                date_changing.Content = needed_item.ChangeDate.ToString("dd/MM/yyyy");
            }
            
        }

        private Border CreateBorder() {
            Border line = new();
            line.Width = 3;
            line.Background = new SolidColorBrush(Color.FromRgb(0xBF, 0xBF, 0xBF));
            line.HorizontalAlignment = HorizontalAlignment.Right;
            line.Opacity = 0.5;

            DeleteIfExistElement("selected");

            line.Name = "selected";
            Grid.SetRowSpan(line, 2);

            return line;
        }

        private void DeleteIfExistElement(string key) {
            var selected_obj = FindName(key);
            if (selected_obj != null) {
                ((Grid)((Border)selected_obj).Child).Children.RemoveAt(0);
            }
        }

        //======================================================================

        //================ fill accounts list ========================
        /// <summary>
        /// Download from db list of accounts concrete user and
        /// show this list in ui
        /// </summary>
        private void FillUIAccountsList() {
            accounts = new List<Account>();
            if (!db.GetAccountsList(accounts, user_id)) {
                MessageBox.Show("Ошибка с получением сайтов");
                return;
            }

            AccountsList.Visibility = Visibility.Visible;

            Border AccountItem = new();
            AccountItem.Style = (Style)Resources["account"];
            AccountItem.MouseDown += SelectAccount;

            AccountItem.Child = FillUIFieldsAccount();
            AccountsList.Children.Add(AccountItem);


            CalculateCountAccounts();
        }

        /// <summary>
        /// Set values and places of fields account
        /// </summary>
        /// <returns> Grid filled object with data</returns>
        private Grid FillUIFieldsAccount() {
            Grid grid = new();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10, GridUnitType.Star) });

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            foreach (Account item in accounts) {
                Label name_site = new();
                name_site.Content = item.NameSite;
                name_site.Foreground = new SolidColorBrush(Color.FromRgb(0xBF, 0xBF, 0xBF));
                name_site.VerticalAlignment = VerticalAlignment.Bottom;
                name_site.Padding = new Thickness(4, 4, 4, 0);
                name_site.FontWeight = FontWeights.Bold;
                Grid.SetColumn(name_site, 1);
                Grid.SetRow(name_site, 0);

                Label login = new();
                login.Content = item.Login;
                login.Foreground = new SolidColorBrush(Color.FromRgb(0xBF, 0xBF, 0xBF));
                login.VerticalAlignment = VerticalAlignment.Top;
                login.Opacity = 0.5;
                Grid.SetColumn(login, 1);
                Grid.SetRow(login, 1);

                grid.Children.Add(name_site);
                grid.Children.Add(login);
            }

            return grid;
        }

        private void CalculateCountAccounts() {
            int count_accounts = accounts.Count;
            string signature = "логин";
            if (count_accounts % 10 == 0 || count_accounts % 10 > 4)
                signature += "ов";
            else if (count_accounts % 10 > 1 && count_accounts % 10 < 5) {
                signature += "а";
            }

            countAccounts.Content = count_accounts.ToString() + " " + signature;
        }
        //===========================================================


        /// <summary>
        /// Show accounts with name site which starts with search string
        /// </summary>
        private void Search_site_TextChanged(object sender, TextChangedEventArgs e) {
            if (search_site.Text.Trim().Length == 0) {
                foreach (Border borders in AccountsList.Children) {
                    borders.Visibility = Visibility.Visible;
                }
            }

            foreach (Border borders in AccountsList.Children) {
                if (borders != search_form) {
                    Grid grid = (Grid)borders.Child;
                    if (!((Label)grid.Children[0]).Content.ToString().StartsWith(search_site.Text.Trim())) {
                        borders.Visibility = Visibility.Collapsed;
                    }
                }

            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e) {
            LoginForm loginForm = new();
            Close();
            loginForm.Show();
        }

        private void CopyLogin_Click(object sender, RoutedEventArgs e) {
            Clipboard.SetText(user_login.Content.ToString());
        }

        private void CopyPassword_Click(object sender, RoutedEventArgs e) {
            Clipboard.SetText(user_password.Password.ToString());
        }

        private void Add_account_Click(object sender, RoutedEventArgs e) {
            AddAccount add = new(this, db, user_id);
            Hide();
            add.Show();
        }
    }
}
