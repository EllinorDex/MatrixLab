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
            comboBox.Text = "Custom";
        }

        private void tabControl1_DrawItem(Object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            Brush _textBrush;
            var _tabPage = tabControl1.TabPages[e.Index];
            var _tabBounds = tabControl1.GetTabRect(e.Index);

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

            var _tabFont = new Font("Arial", 30.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            var _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void openLeftMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var matrix = File.ReadAllLines(openFileDialog1.FileName);
            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Split(' ').Length;
            var arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            string[] matrixRow = {};
            for (var i = 0; i < numberOfRows; ++i)
            {
                matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (var j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show("The matrix you tried to load from the file is not set correctly.", "Error!");
                        return;
                    }
                }
                catch
                {
                        MessageBox.Show("The matrix you tried to load from the file is not set correctly.", "Error!");
                    return;
                }
            }
            var form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Left Matrix");
            form.ShowDialog();
        }

        private void openRightMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var matrix = File.ReadAllLines(openFileDialog1.FileName);
            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Split(' ').Length;
            var arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            string[] matrixRow = {};
            for (var i = 0; i < numberOfRows; ++i)
            {
                matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (var j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show("The matrix you tried to load from the file is not set correctly.", "Error!");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("The matrix you tried to load from the file is not set correctly.", "Error!");
                    return;
                }
            }
            var form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Right Matrix");
            form.ShowDialog();
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
            MessageBox.Show("This program allows you to perform simple matrix calculations. " +
                "For this you need:\n\n1) Select the operation you need;\n\n" +
                "2) Set the number of rows and columns in the matrix;\n\n" +
                "3) Select one of the proposed matrix types. " +
                "If your matrix is random, then select a custom matrix type;\n\n" +
                "4) In the window that appears, set the matrix elements;\n\n" +
                "5) Click the button Calculate!", "Help");
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Three beginning programmers from Belarus and Ukraine.", "About Us");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please, help two poor Belarusians and one Ukrainian. \nSberbank Online: +7-977-763-62-91", "Donate");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
                if (comboBox1.SelectedItem.ToString() == "Diagonal" || comboBox1.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown1.Value != numericUpDown2.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown1, numericUpDown2, comboBox1, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != 0 && numericUpDown4.Value != 0)
            {
                if (comboBox2.SelectedItem.ToString() == "Diagonal" || comboBox2.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown3.Value != numericUpDown4.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown3, numericUpDown4, comboBox2, "Right Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var matrix = new MatrixLib.Sum<int>(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please, set all the necessary matrices to perform the operation.", "Error!");
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value != 0 && numericUpDown6.Value != 0)
            {
                if (comboBox3.SelectedItem.ToString() == "Diagonal" || comboBox3.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown5.Value != numericUpDown6.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown5, numericUpDown6, comboBox3, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Value != 0 && numericUpDown8.Value != 0)
            {
                if (comboBox4.SelectedItem.ToString() == "Diagonal" || comboBox4.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown7.Value != numericUpDown8.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown7, numericUpDown8, comboBox4, "Right Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var matrix = new MatrixLib.Multiplication<int>(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please, set all the necessary matrices to perform the operation.", "Error!");
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown9.Value != 0 && numericUpDown10.Value != 0)
            {
                if (comboBox5.SelectedItem.ToString() == "Diagonal" || comboBox5.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown9.Value != numericUpDown10.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown9, numericUpDown10, comboBox5, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
                var matrix = new MatrixLib.InverseMatrix<int>(Matrix.GetLeftMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please, set the matrix to perform the operation.", "Error!");
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown11.Value != 0 && numericUpDown12.Value != 0)
            {
                if (comboBox6.SelectedItem.ToString() == "Diagonal" || comboBox6.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown11.Value != numericUpDown12.Value)
                    {
                        MessageBox.Show("The number of rows should be equal to the number of columns for diagonal and unit matrices.", "Error!");
                        return;
                    }
                }
                var form = new Matrix(numericUpDown11, numericUpDown12, comboBox6, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show("Please set all the necessary parameters to build the matrix.", "Error!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var matrix = new MatrixLib.Determinant<int>(Matrix.GetLeftMatrix());
                var determinant = matrix.Calculate();
                MessageBox.Show("The determinant of the matrix is " + determinant.ToString() + '.', "Determinant");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please, set the matrix to perform the operation.", "Error!");
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }
    }
}
