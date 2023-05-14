﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SESSIONWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int CountTry = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void buttonBlock(Button button)
        {
            if(CountTry == 3)
            {
                button.IsEnabled = false;
                MessageBox.Show("Введено предельное количество попыток, подождите 5 секунд!");
                var timer = new System.Timers.Timer(500);
                timer.Elapsed += (sender, e) =>
                {
                    button.Dispatcher.Invoke(() =>
                    {
                        button.IsEnabled = true;
                    });
                    timer.Stop();
                };
                timer.Start();
                CountTry = 1;
            }
            else
            {
                CountTry++;
            }
        }

        private void bt_Login_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            try
            {
                dataBaseClass.sqlExecute(string.Format(Query.selectAuth, tb_login.Text, tb_password.Password), DataBaseClass.act.select);
                if (dataBaseClass.resultTable.Rows.Count != 0)
                {
                    string role = dataBaseClass.resultTable.Rows[0][2].ToString();
                    if (role == "Заказчик")
                    {

                        this.Close();
                    }
                    else if (role == "Менеджер по работе с клиентами")
                    {

                        this.Close();
                    }
                    else if (role == "Менеджер по закупкам")
                    {

                        this.Close();
                    }
                    else if (role == "Мастер")
                    {

                        this.Close();
                    }
                    else if (role == "Директор")
                    {

                        this.Close();
                    }
                    else
                    {
                        CountTry++;
                    }
                }
                else
                {
                    //MessageBox.Show("Неверное введён логин или пароль!");
                    buttonBlock((sender as Button));
                }
            }
            catch
            {
                //MessageBox.Show("Неверное введён логин или пароль!");
                buttonBlock((sender as Button));
                tb_login.Focus();
            }
            finally
            {
                dataBaseClass.connection.Close();
                tb_login.Clear();
                tb_password.Clear();
            }
        }

        private void tb_Registration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
