﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show("Выбран файл: " + openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void multToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void invToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта программа позволяет вам проводить простейшие матричные вычисления. " +
                "Для этого Вам необходимо:\n\n1) Выбрать необходимую Вам операцию;\n\n" +
                "2) Задать количество строк и столбцов в матрице;\n\n" +
                "3) Выбрать один из предложенных типов матрицы. " +
                "Если Ваша матрица произвольная, то выберите пользовательский тип матрицы;\n\n" +
                "4) В появившемся окне задать элементы матрицы;\n\n" +
                "5) Нажать кнопку Вычислить!", "Help");
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Три начинающих программиста из Беларуси и Украины", "About Us");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a != 0 && b != 0)
            {
                Matrix form = new Matrix(a, b);
                form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value != 0 && numericUpDown6.Value != 0)
            {
                if (comboBox1.SelectedItem.ToString() == "Диагональная" || comboBox1.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown5.Value != numericUpDown6.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown5, numericUpDown6, comboBox1);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown4.Value != 0 && numericUpDown7.Value != 0)
            {
                if (comboBox2.SelectedItem.ToString() == "Диагональная" || comboBox2.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown4.Value != numericUpDown7.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown4, numericUpDown7, comboBox2);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
                if (comboBox4.SelectedItem.ToString() == "Диагональная" || comboBox4.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown1.Value != numericUpDown2.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown1, numericUpDown2, comboBox4);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Помогите двум бедным белорусам и одному украинцу. \nСбербанк Онлайн: +7-977-763-62-91", "Donate");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a!= 0 && b != 0)
            {
                Matrix form = new Matrix(a, b);
                form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown8.Value != 0 && numericUpDown3.Value != 0)
            {
                if (comboBox3.SelectedItem.ToString() == "Диагональная" || comboBox3.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown8.Value != numericUpDown3.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown8, numericUpDown3, comboBox3);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown10.Value != 0 && numericUpDown9.Value != 0)
            {
                if (comboBox6.SelectedItem.ToString() == "Диагональная" || comboBox6.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown10.Value != numericUpDown9.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown10, numericUpDown9, comboBox6);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (numericUpDown14.Value != 0 && numericUpDown13.Value != 0)
            {
                if (comboBox5.SelectedItem.ToString() == "Диагональная" || comboBox5.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown14.Value != numericUpDown13.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown14, numericUpDown13, comboBox5);
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a != 0 && b != 0)
            {
                Matrix form = new Matrix(a, b);
                form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a != 0 && b != 0)
            {
                Matrix form = new Matrix(a, b);
                form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }
    }
}
