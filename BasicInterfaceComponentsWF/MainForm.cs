using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace BasicInterfaceComponentsWF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Делает форму красной при нажатии левой кнопки мыши и зеленой при нажатии на правую.
        #region ChangeColourOfForm
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: BackColor = Color.Red; break;
                case MouseButtons.Right: BackColor = Color.Green; break;
            }
        }
        #endregion

        // Гетеры и сетеры.
        #region GetSet
        public string LastName { get => textBox1.Text; set => LastName = value; }
        public string FirstName { get => textBox2.Text; set => FirstName = value; }
        public string Patronymic { get => textBox3.Text; set => Patronymic = value; }
        public string Data { get => comboBox1.Text + " " + comboBox2.Text + " " + comboBox3.Text; set => Data = value; }
        public string HomeAdress { get => textBox4.Text; set => HomeAdress = value; }
        public string EmailAdress { get => textBox5.Text; set => EmailAdress = value; }
        public string PhoneType { get => comboBox4.Text; set => PhoneType = value; }
        public string PhoneNumber { get => textBox6.Text; set => PhoneNumber = value; }
        public string MinSalary { get => numericUpDown1.Text; set => MinSalary = value; }
        public string MaxSalary { get => numericUpDown2.Text; set => MaxSalary = value; }
        public string Summary { get => richTextBox1.Text; set => Summary = value; }
        #endregion

        // Блок отвечающий за опыт работы.
        #region Experience
        public short experience;

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => experience = 1;

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => experience = 2;

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => experience = 3;

        private void radioButton4_CheckedChanged(object sender, EventArgs e) => experience = 4;

        private void radioButton5_CheckedChanged(object sender, EventArgs e) => experience = 5;
        #endregion

        // Блок выбора занятости.
        #region Schedule

        public short schedule;

        private void radioButton8_CheckedChanged(object sender, EventArgs e) => schedule = 1;

        private void radioButton9_CheckedChanged(object sender, EventArgs e) => schedule = 2;

        private void radioButton10_CheckedChanged(object sender, EventArgs e) => schedule = 3;

        private void radioButton11_CheckedChanged(object sender, EventArgs e) => schedule = 4;
        #endregion

        // Проверка на корректность ввода.
        #region Test
        public bool lastNameVerification = false;
        public bool firstNameVerification = false;
        public bool PatronymicVerification = false;
        public bool EmailAdressVerification = false;
        public bool PhoneNumberVerification = false;

        //public bool pF, pN, pOt, pPh, pEm;
        public void Test()
        {
            if (textBox1.Text != string.Empty)
            {
                lastNameVerification = true;
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (!Char.IsLetter(textBox1.Text[i]))
                    {
                        lastNameVerification = false;
                        break;
                    }
                }
            }
            if (textBox2.Text != string.Empty)
            {
                firstNameVerification = true;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (!Char.IsLetter(textBox2.Text[i]))
                    {
                        firstNameVerification = false;
                        break;
                    }
                }
            }

            if (textBox3.Text != string.Empty)
            {
                PatronymicVerification = true;
                for (int i = 0; i < textBox3.Text.Length; i++)
                {
                    if (!Char.IsLetter(textBox3.Text[i]))
                    {
                        PatronymicVerification = false;
                        break;
                    }
                }
            }

            if (textBox5.Text != string.Empty)
            {
                EmailAdressVerification = false;
                string pattern = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
                if (Regex.IsMatch(textBox5.Text, pattern))
                {
                    EmailAdressVerification = true;
                }
            }

            if (textBox6.Text != string.Empty)
            {
                PhoneNumberVerification = true;
                for (int i = 0; i < textBox6.Text.Length; i++)
                {
                    if (textBox6.Text.Length != 9) PhoneNumberVerification = false;
                    else
                    {
                        if (!Char.IsNumber(textBox6.Text[i]))
                        {
                            PhoneNumberVerification = false;
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        // Блок кнопок сохранения, очистки и выхода.
        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            comboBox2.BackColor = Color.White;
            comboBox3.BackColor = Color.White;
            Test();
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox5.Text != string.Empty &&
                comboBox1.Text!= string.Empty && comboBox2.Text != string.Empty && comboBox3.Text != string.Empty)
            {
                if (lastNameVerification && firstNameVerification && PatronymicVerification && EmailAdressVerification && PhoneNumberVerification)
                {
                    File.AppendAllText("output.txt", "\r\n" + LastName + " " + FirstName + " " + Patronymic + "\r\n");
                    if (Man.Checked) File.AppendAllText("output.txt", "Пол - Мужской\r\n");
                    if (Woman.Checked) File.AppendAllText("output.txt", "Пол - Женский\r\n");
                    File.AppendAllText("output.txt", "Дата рождения - " + Data + "\r\n");
                    File.AppendAllText("output.txt", "Домашний адрес - " + HomeAdress + "\r\n");
                    File.AppendAllText("output.txt", "Email адрес - " + EmailAdress + "\r\n");
                    File.AppendAllText("output.txt", "Мобильный телефон - " + PhoneType + " " + "+375" + PhoneNumber + "\r\n");
                    string lineOne = "Стаж работы - ";
                    switch (experience)
                    {
                        case 1: File.AppendAllText("output.txt", "Прежде не работал" + "\r\n"); break;
                        case 2: File.AppendAllText("output.txt", lineOne + "Меньше 1 года" + "\r\n"); break;
                        case 3: File.AppendAllText("output.txt", lineOne + "От 1 года до 5 лет" + "\r\n"); break;
                        case 4: File.AppendAllText("output.txt", lineOne + "От 5 до 9 лет" + "\r\n"); break;
                        case 5: File.AppendAllText("output.txt", lineOne + "10 лет и больше" + "\r\n"); break;
                    }
                    string lineTwo = "Тип занятости - ";
                    switch (schedule)
                    {
                        case 1: File.AppendAllText("output.txt", lineTwo + "Полная занятость" + "\r\n"); break;
                        case 2: File.AppendAllText("output.txt", lineTwo + "Частичная занятость" + "\r\n"); break;
                        case 3: File.AppendAllText("output.txt", lineTwo + "Работа на дому" + "\r\n"); break;
                        case 4: File.AppendAllText("output.txt", lineTwo + "Посменная работа" + "\r\n"); break;
                    }

                    if (checkBox1.Checked) File.AppendAllText("output.txt", "Личный автомобиль - Есть\r\n");
                    else File.AppendAllText("output.txt", "Личного автомобиля - Нету\r\n");

                    if (checkBox2.Checked)
                    {
                        File.AppendAllText("output.txt", "Водительское удостоверение - Есть ");
                        if (checkBox3.Checked) File.AppendAllText("output.txt", " A");
                        if (checkBox4.Checked) File.AppendAllText("output.txt", " B");
                        if (checkBox5.Checked) File.AppendAllText("output.txt", " C");
                        if (checkBox6.Checked) File.AppendAllText("output.txt", " D");
                        File.AppendAllText("output.txt", "\r\n");

                    }
                    else File.AppendAllText("output.txt", "Водительское удостоверение - Нету\r\n");
                    if (MinSalary != "0" && MaxSalary != "0") File.AppendAllText("output.txt", "ЗП от:" + MinSalary + " до:" + MaxSalary + "\r\n");
                    if (richTextBox1.Text != String.Empty) File.AppendAllText("output.txt", "Краткое резюме:\r\n" + Summary + "\r\n");
                    File.AppendAllText("output.txt", "=================================\r\n");

                    MessageBox.Show("Сохранено!", "Сохранение!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    string lineThree = "Введены неверно следущие поля:\r\n";
                    if (!lastNameVerification) { lineThree += "- Фамилия\r\n"; textBox1.BackColor = Color.DarkRed; }
                    if (!firstNameVerification) { lineThree += "- Имя\r\n"; textBox2.BackColor = Color.DarkRed; }
                    if (!PatronymicVerification) { lineThree += "- Отчество\r\n"; textBox3.BackColor = Color.DarkRed; }
                    if (!EmailAdressVerification) { lineThree += "- Номер телефона\r\n"; textBox5.BackColor = Color.DarkRed; }
                    if (!PhoneNumberVerification) { lineThree += "- Адресс э. почты\r\n"; textBox6.BackColor = Color.DarkRed; }
                    MessageBox.Show(lineThree, "Неверно заполнены поля!", MessageBoxButtons.OK);
                }
            }
            else
            {
                string lineFour = "Не заполнены следущие поля:\r\n";
                if (textBox1.Text == string.Empty) { lineFour += "- Фамилия\r\n"; textBox1.BackColor = Color.DarkRed; }
                if (textBox2.Text == string.Empty) { lineFour += "- Имя\r\n"; textBox2.BackColor = Color.DarkRed; }
                if (textBox3.Text == string.Empty) { lineFour += "- Отчество\r\n"; textBox3.BackColor = Color.DarkRed; }
                if (comboBox1.Text == string.Empty) { lineFour += "- День рождения\r\n"; comboBox1.BackColor = Color.DarkRed; }
                if (comboBox2.Text == string.Empty) { lineFour += "- Месяц рождения\r\n"; comboBox2.BackColor = Color.DarkRed; }
                if (comboBox3.Text == string.Empty) { lineFour += "- Год рождения\r\n"; comboBox3.BackColor = Color.DarkRed; }
                if (textBox5.Text == string.Empty) { lineFour += "- Адрес эл. почты\r\n"; textBox5.BackColor = Color.DarkRed; }

                MessageBox.Show(lineFour, "Не заполнены поля!", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Experience1.Checked = false;
            Experience2.Checked = false;
            Experience3.Checked = false;
            Experience4.Checked = false;
            Experience5.Checked = false;
            Man.Checked = false;
            Woman.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            numericUpDown1.Text = "0";
            numericUpDown2.Text = "0";
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            comboBox2.BackColor = Color.White;
            comboBox3.BackColor = Color.White;
            BackColor = Color.Silver;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo)== DialogResult.Yes) Application.Exit();
        }
        #endregion
    }
}
