using Google.Protobuf.WellKnownTypes;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Management_System
{
    public partial class LoginForm : Form
    {
        private string culture;
        BindingList<User> users;
        public LoginForm()
        {
            users = Database.GetAllUsers();
            culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            InitializeComponent();
            this.CenterToScreen();
            string culture_fullname = CultureInfo.CurrentCulture.Name;
            LocalTimezone = TimeZone.CurrentTimeZone.StandardName;
            if (culture == "pt") ChangeLanguage();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string targetUsername = textBox1.Text;
            string targetPassword = textBox2.Text;
            Database.loggedIn = true;
            Database.UserLoggedIn();
            //LINQ + Lambda
            User foundUser = users.FirstOrDefault<User>(u => u.username == targetUsername);


            try
            {
                if (foundUser != null)
                {
                    if (foundUser.password == textBox2.Text)
                    {
                        UserLogger();
                        Database.currentUser = textBox1.Text.Trim();
                        MainForm mainForm = new MainForm();
                        this.Dispose();
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        if (culture != "pt")
                        {
                            MessageBox.Show("Wrong password");
                        }
                        else
                        {
                            MessageBox.Show("Falsa senha");
                        }
                        return;
                    }
                }
                else
                {
                    if (culture != "pt")
                    {
                        MessageBox.Show("Wrong username");
                    }
                    else
                    {
                        MessageBox.Show("Falsa nome de usuário");
                    }
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        //Portugues
        private void ChangeLanguage()
        {
            LoginTitle.Text = "Página de Login";
            UsernameLabel.Text = "Nome de usuário";
            PasswordLabel.Text = "Senha";
            LoginBtn.Text = "Login";
            ExitBtn.Text = "Sair";
            this.Text = "Login aqui";
        }
        public string LocalTimezone { get { return Timezone.Text; } set { Timezone.Text = value;  } }

        private void UserLogger()
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\Login_History.txt";
            string login_details = $"{DateTime.UtcNow}: User \"{textBox1.Text}\" logged in successfully" + Environment.NewLine;
            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, login_details);
            }
            else
            {
                File.WriteAllText(filePath, login_details);
            }
        }
    }
}
