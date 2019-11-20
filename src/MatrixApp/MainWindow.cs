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

        private void openLeftMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string[] matrix = File.ReadAllLines(openFileDialog1.FileName);
            int numberOfRows = matrix.Length;
            int numberOfColumns = matrix[0].Split(' ').Length;
            int[,] arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            string[] matrixRow = {};
            for (int i = 0; i < numberOfRows; ++i)
            {
                matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (int j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show("Матрица, которую Вы пытались загрузить из файла, задана некорректно.", "Ошибка!");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Матрица, которую Вы пытались загрузить из файла, задана некорректно.", "Ошибка!");
                    return;
                }
            }
            Matrix form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Left Matrix");
            form.Show();
        }

        private void openRightMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string[] matrix = File.ReadAllLines(openFileDialog1.FileName);
            int numberOfRows = matrix.Length;
            int numberOfColumns = matrix[0].Split(' ').Length;
            int[,] arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            string[] matrixRow = {};
            for (int i = 0; i < numberOfRows; ++i)
            {
                matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (int j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show("Матрица, которую Вы пытались загрузить из файла, задана некорректно.", "Ошибка!");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Матрица, которую Вы пытались загрузить из файла, задана некорректно.", "Ошибка!");
                    return;
                }
            }
            Matrix form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Right Matrix");
            form.Show();
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
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown1, numericUpDown2, comboBox1, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != 0 && numericUpDown4.Value != 0)
            {
                if (comboBox2.SelectedItem.ToString() == "Диагональная" || comboBox2.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown3.Value != numericUpDown4.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown3, numericUpDown4, comboBox2, "Right Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MatrixLib.Sum matrix = new MatrixLib.Sum(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                MatrixLib.Matrix resultMatrix = matrix.Calculate();
                Matrix form = new Matrix((int)resultMatrix.GetCountOfRows(), (int)resultMatrix.GetCountOfColumns(), resultMatrix.Get2DArray());
                form.Show();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Для выполнения операции, пожалуйста, задайте все необходимые матрицы.", "Ошибка!");
            }
            catch(MatrixLib.MatrixException)
            {
                MessageBox.Show("Размеры матриц не подходят для выполнения выбранной операции.\n" +
                    "Пожалуйста, проверьте корректность размеров заданных Вами матриц.", "Ошибка!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value != 0 && numericUpDown6.Value != 0)
            {
                if (comboBox3.SelectedItem.ToString() == "Диагональная" || comboBox3.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown5.Value != numericUpDown6.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown5, numericUpDown6, comboBox3, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Value != 0 && numericUpDown8.Value != 0)
            {
                if (comboBox4.SelectedItem.ToString() == "Диагональная" || comboBox4.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown7.Value != numericUpDown8.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown7, numericUpDown8, comboBox4, "Right Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MatrixLib.Multiplication matrix = new MatrixLib.Multiplication(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                MatrixLib.Matrix resultMatrix = matrix.Calculate();
                Matrix form = new Matrix((int)resultMatrix.GetCountOfRows(), (int)resultMatrix.GetCountOfColumns(), resultMatrix.Get2DArray());
                form.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для выполнения операции, пожалуйста, задайте все необходимые матрицы.", "Ошибка!");
            }
            catch (MatrixLib.MatrixException)
            {
                MessageBox.Show("Размеры матриц не подходят для выполнения выбранной операции.\n" +
                    "Пожалуйста, проверьте корректность размеров заданных Вами матриц.", "Ошибка!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown9.Value != 0 && numericUpDown10.Value != 0)
            {
                if (comboBox5.SelectedItem.ToString() == "Диагональная" || comboBox5.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown9.Value != numericUpDown10.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown9, numericUpDown10, comboBox5, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
                MatrixLib.InverseMatrix matrix = new MatrixLib.InverseMatrix(Matrix.GetLeftMatrix());
                MatrixLib.Matrix resultMatrix = matrix.Calculate();
                Matrix form = new Matrix((int)resultMatrix.GetCountOfRows(), (int)resultMatrix.GetCountOfColumns(), resultMatrix.Get2DArray());
                form.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для выполнения операции, пожалуйста, задайте матрицу.", "Ошибка!");
            }
            catch (MatrixLib.MatrixException)
            {
                MessageBox.Show("Введённая Вами матрица не является обратимой.\n" +
                    "Пожалуйста, введите другую матрицу.", "Ошибка!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown11.Value != 0 && numericUpDown12.Value != 0)
            {
                if (comboBox6.SelectedItem.ToString() == "Диагональная" || comboBox6.SelectedItem.ToString() == "Единичная")
                {
                    if (numericUpDown11.Value != numericUpDown12.Value)
                    {
                        MessageBox.Show("У диагональной и единичной матриц количество строк должно быть равно количеству столбцов.", "Ошибка!");
                        return;
                    }
                }
                Matrix form = new Matrix(numericUpDown11, numericUpDown12, comboBox6, "Left Matrix");
                form.Show();
            }
            else
                MessageBox.Show("Пожалуйста, задайте все необходимые параметры для построения матрицы.", "Ошибка!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                MatrixLib.Determinant matrix = new MatrixLib.Determinant(Matrix.GetLeftMatrix());
                int determinant = matrix.Calculate();
                MessageBox.Show("Определитель матрицы равен " + determinant.ToString() + '.', "Определитель");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для выполнения операции, пожалуйста, задайте матрицу.", "Ошибка!");
            }
            catch (MatrixLib.MatrixException)
            {
                MessageBox.Show("Размер матрицы не позволяет вычислить её определитель.\n" +
                    "Пожалуйста, проверьте корректность размеров заданной Вами матрицы.", "Ошибка!");
            }
        }
    }
}
