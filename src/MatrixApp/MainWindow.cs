﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MatrixApp.Properties;
using MatrixLib.Operations;

namespace MatrixApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            tabControl1.DrawItem += TabControl1_DrawItem;
            SetComboBox(comboBox1);
            SetComboBox(comboBox2);
            SetComboBox(comboBox4);
            SetComboBox(comboBox3);
            SetComboBox(comboBox5);
            SetComboBox(comboBox6);
        }

        private static void SetComboBox(Control comboBox)
        {
            comboBox.Text = Resources.res04;
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            Brush textBrush;
            var tabPage = tabControl1.TabPages[e.Index];
            var tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                textBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(Brushes.Yellow, e.Bounds);
            }
            else
            {
                textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            var tabFont = new Font("Arial", 30.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            var stringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, new StringFormat(stringFlags));
        }

        private void OpenLeftMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = Resources.res05
            };
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var matrix = File.ReadAllLines(openFileDialog1.FileName);
            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Split(' ').Length;
            var arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            for (var i = 0; i < numberOfRows; ++i)
            {
                var matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (var j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show(Resources.res01, Resources.res03);
                        return;
                    }
                }
                catch
                {
                        MessageBox.Show(Resources.res01, Resources.res03);
                    return;
                }
            }
            var form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Left Matrix");
            form.ShowDialog();
        }

        private void OpenRightMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = Resources.res05
            };
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var matrix = File.ReadAllLines(openFileDialog1.FileName);
            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Split(' ').Length;
            var arrayOfMatrixValues = new int[numberOfRows, numberOfColumns];
            for (var i = 0; i < numberOfRows; ++i)
            {
                var matrixRow = matrix[i].Split(' ');
                try
                {
                    if (matrix[i].Split(' ').Length == numberOfColumns)
                    {
                        for (var j = 0; j < numberOfColumns; ++j)
                            arrayOfMatrixValues[i, j] = Convert.ToInt32(matrixRow[j]);
                    }
                    else
                    {
                        MessageBox.Show(Resources.res01, Resources.res03);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show(Resources.res01, Resources.res03);
                    return;
                }
            }
            var form = new Matrix(numberOfRows, numberOfColumns, arrayOfMatrixValues, "Right Matrix");
            form.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void MultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void InvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void DetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.res06, "Help");
        }

        private void AboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.res07, "About Us");
        }

        private void DonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.res08, "Donate");
        }

        private void Button1_Click(Object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
                if (comboBox1.SelectedItem.ToString() == "Diagonal" || comboBox1.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown1.Value != numericUpDown2.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown1, numericUpDown2, comboBox1, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button2_Click(Object sender, EventArgs e)
        {
            if (numericUpDown3.Value != 0 && numericUpDown4.Value != 0)
            {
                if (comboBox2.SelectedItem.ToString() == "Diagonal" || comboBox2.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown3.Value != numericUpDown4.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown3, numericUpDown4, comboBox2, "Right Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button3_Click(Object sender, EventArgs e)
        {
            try
            {
                var matrix = new Sum<int>(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Resources.res11, Resources.res03);
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, Resources.res03);
            }
        }

        private void Button4_Click(Object sender, EventArgs e)
        {
            if (numericUpDown5.Value != 0 && numericUpDown6.Value != 0)
            {
                if (comboBox3.SelectedItem.ToString() == "Diagonal" || comboBox3.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown5.Value != numericUpDown6.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown5, numericUpDown6, comboBox3, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button5_Click(Object sender, EventArgs e)
        {
            if (numericUpDown7.Value != 0 && numericUpDown8.Value != 0)
            {
                if (comboBox4.SelectedItem.ToString() == "Diagonal" || comboBox4.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown7.Value != numericUpDown8.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown7, numericUpDown8, comboBox4, "Right Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button6_Click(Object sender, EventArgs e)
        {
            try
            {
                var matrix = new Multiplication<int>(Matrix.GetLeftMatrix(), Matrix.GetRightMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Resources.res11, Resources.res03);
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, Resources.res03);
            }
        }

        private void Button7_Click(Object sender, EventArgs e)
        {
            if (numericUpDown9.Value != 0 && numericUpDown10.Value != 0)
            {
                if (comboBox5.SelectedItem.ToString() == "Diagonal" || comboBox5.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown9.Value != numericUpDown10.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown9, numericUpDown10, comboBox5, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button8_Click(Object sender, EventArgs e)
        {
            try
            { 
                var matrix = new InverseMatrix<int>(Matrix.GetLeftMatrix());
                var resultMatrix = matrix.Calculate();
                var form = new Matrix(resultMatrix.CountOfRows, resultMatrix.CountOfColumns, resultMatrix.Get2DArray());
                form.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Resources.res12, Resources.res03);
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, Resources.res03);
            }
        }

        private void Button9_Click(Object sender, EventArgs e)
        {
            if (numericUpDown11.Value != 0 && numericUpDown12.Value != 0)
            {
                if (comboBox6.SelectedItem.ToString() == "Diagonal" || comboBox6.SelectedItem.ToString() == "Unit")
                {
                    if (numericUpDown11.Value != numericUpDown12.Value)
                    {
                        MessageBox.Show(Resources.res09, Resources.res03);
                        return;
                    }
                }
                var form = new Matrix(numericUpDown11, numericUpDown12, comboBox6, "Left Matrix");
                form.ShowDialog();
            }
            else
                MessageBox.Show(Resources.res10, Resources.res03);
        }

        private void Button10_Click(Object sender, EventArgs e)
        {
            try
            {
                var matrix = new Determinant<int>(Matrix.GetLeftMatrix());
                var determinant = matrix.Calculate();
                MessageBox.Show(Resources.res13 + determinant.ToString() + '.', "Determinant");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Resources.res12, Resources.res03);
            }
            catch (MatrixLib.MatrixException exception)
            {
                MessageBox.Show(exception.Message, Resources.res03);
            }
        }

        private void MainWindow_Load(Object sender, EventArgs e)
        {

        }
    }
}
