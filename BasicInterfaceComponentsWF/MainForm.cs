using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicInterfaceComponentsWF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string LastName { get => textBox1.Text; set => LastName = value; }
        public string FirstName { get => textBox2.Text; set => FirstName = value; }
        public string Patronymic { get => textBox3.Text; set => Patronymic = value; }
        public string Data { get => comboBox1.Text + " " + comboBox2.Text + " " + comboBox3.Text; set => Data = value; }
        public string Adress { get => textBox4.Text; set => Adress = value; }
        public string Email { get => textBox5.Text; set => Email = value; }
        public string PhoneType { get => comboBox4.Text; set => PhoneType = value; }
        public string PhoneNumber { get => textBox6.Text; set => PhoneNumber = value; }
        public string MinSalary { get => numericUpDown1.Text; set => MinSalary = value; }
        public string MaxSalary { get => numericUpDown2.Text; set => MaxSalary = value; }
        public string Summary { get => richTextBox1.Text; set => Summary = value; }

        // Блок отвечающий за опыт работы.
        #region Experience
        public short experience;

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => experience = 1;

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => experience = 2;

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => experience = 3;

        private void radioButton4_CheckedChanged(object sender, EventArgs e) => experience = 4;

        private void radioButton5_CheckedChanged(object sender, EventArgs e) => experience = 5;
        #endregion

        // Блок выбора пола.
        #region Gender
        public short gender;

        private void Man_CheckedChanged(object sender, EventArgs e) => gender = 1;

        private void Woman_CheckedChanged(object sender, EventArgs e) => gender = 2;
        #endregion

        // Блок выбора занятости.
        #region Schedule

        public short schedule;

        private void radioButton8_CheckedChanged(object sender, EventArgs e) => schedule = 1;

        private void radioButton9_CheckedChanged(object sender, EventArgs e) => schedule = 2;

        private void radioButton10_CheckedChanged(object sender, EventArgs e) => schedule = 3;

        private void radioButton11_CheckedChanged(object sender, EventArgs e) => schedule = 4;
        #endregion

        // Блок водительских прав и автомобиля.
        #region DriverLicense and Car
        bool hasCar = false;
        bool hasDriverLisence = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => hasCar = true;

        private void checkBox2_CheckedChanged(object sender, EventArgs e) => hasDriverLisence = true;

        bool categoryA = false;
        bool categoryB = false;
        bool categoryC = false;
        bool categoryD = false;

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked==true) categoryA = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) categoryB = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) categoryC = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) categoryD = true;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // Блок кнопок сохранения, очистки и выхода.
        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, World!");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo)== DialogResult.Yes) Application.Exit();
        }
        #endregion
    }
}
