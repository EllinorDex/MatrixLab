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

namespace MatrixApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            setComboBox(comboBox1);
            setComboBox(comboBox2);
            setComboBox(comboBox4);
            setComboBox(comboBox3);
            setComboBox(comboBox5);
            setComboBox(comboBox6);
        }

        void setComboBox(ComboBox comboBox)
        {
            comboBox.Text = "Пользовательская";
        }

        private void tabControl1_DrawItem(Object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = tabControl1.TabPages[e.Index];
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(Brushes.Yellow, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Arial", 30.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void openMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show("Выбран файл: " + openFileDialog1.FileName);
            /*StreamReader sr = new StreamReader(openFileDialog1.FileName);
            int[,] matrix = new int[4, 4];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                    matrix[i, j] = sr.Read();

            }*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        private void detToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
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

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Помогите двум бедным белорусам и одному украинцу. \nСбербанк Онлайн: +7-977-763-62-91", "Donate");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
                if (comboBox1.SelectedItem.ToString() == "Диагональная" || comboBox1.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown1.Value != numericUpDown2.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown1, numericUpDown2, comboBox1, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != 0 && numericUpDown4.Value != 0)
            {
                if (comboBox2.SelectedItem.ToString() == "Диагональная" || comboBox2.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown3.Value != numericUpDown4.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown3, numericUpDown4, comboBox2, "Right Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jkjk");
            MatrixLib.Sum matrix = new MatrixLib.Sum(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
            MatrixLib.Matrix resultMatrix = matrix.Calculate();
            MessageBox.Show("jkjk");
            //MessageBox.Show(tabControl1.SelectedTab.Text);
            if (resultMatrix.GetCountOfRows() != 0 && resultMatrix.GetCountOfColumns() != 0)
            {
                Matrix form = new Matrix((int)resultMatrix.GetCountOfRows(), (int)resultMatrix.GetCountOfColumns(), resultMatrix.Get2DArray());
                form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value != 0 && numericUpDown6.Value != 0)
            {
                if (comboBox3.SelectedItem.ToString() == "Диагональная" || comboBox3.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown5.Value != numericUpDown6.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown5, numericUpDown6, comboBox3, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Value != 0 && numericUpDown8.Value != 0)
            {
                if (comboBox4.SelectedItem.ToString() == "Диагональная" || comboBox4.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown7.Value != numericUpDown8.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown7, numericUpDown8, comboBox4, "Right Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a != 0 && b != 0)
            {
                //Matrix form = new Matrix(a, b);
               // form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown9.Value != 0 && numericUpDown10.Value != 0)
            {
                if (comboBox5.SelectedItem.ToString() == "Диагональная" || comboBox5.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown9.Value != numericUpDown10.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown9, numericUpDown10, comboBox5, "Left Matrix");
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
                //Matrix form = new Matrix(a, b);
                //form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown11.Value != 0 && numericUpDown12.Value != 0)
            {
                if (comboBox6.SelectedItem.ToString() == "Диагональная" || comboBox6.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown11.Value != numericUpDown12.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов", "Error");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown11, numericUpDown12, comboBox6, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы", "Error");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 6;
            if (a != 0 && b != 0)
            {
                //Matrix form = new Matrix(a, b);
                //form.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так", "Error");
        }
    }
}
