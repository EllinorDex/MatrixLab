using System;
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
    public partial class Matrix : Form
    {
        public Matrix()
        {

        }

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            InitializeComponent();
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _comboBoxValue = "Результирующая";
        }

        public Matrix(NumericUpDown firstNumericUpDown, NumericUpDown secondNumericUpDown, ComboBox comboBox)
        {
            InitializeComponent();
            _numberOfRows = (int)firstNumericUpDown.Value;
            _numberOfColumns = (int)secondNumericUpDown.Value;
            _comboBoxValue = comboBox.SelectedItem.ToString();
        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            if (_comboBoxValue == "Пользовательская")
                userMatrix();

            if (_comboBoxValue == "Диагональная" || _comboBoxValue == "Единичная")
                diagMatrix();

            if (_comboBoxValue == "Нулевая")
                zeroMatrix();

            if (_comboBoxValue == "Результирующая")
                resultMatrix();
        }

        partial void userMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (int i = 0; i < _numberOfRows; ++i)
            {
                for (int j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = 1;
            }
        }

        partial void diagMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (int i = 0; i < _numberOfRows; ++i)
            {
                for (int j = 0; j < _numberOfColumns; ++j)
                {
                    if (i == j)
                        dataGridView1.Rows[i].Cells[j].Value = 1;
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }

        partial void zeroMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (int i = 0; i < _numberOfRows; ++i)
            {
                for (int j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = 0;
            }
        }

        partial void resultMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (int i = 0; i < _numberOfRows; ++i)
            {
                for (int j = 0; j < _numberOfColumns; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 2;
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_comboBoxValue == "Пользовательская")
            {
                int[,] arrayOfValues = new int[_numberOfRows, _numberOfColumns];
                for (int i = 0; i < _numberOfRows; ++i)
                {
                    for (int j = 0; j < _numberOfColumns; ++j)
                        arrayOfValues[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                }

            }

            if (_comboBoxValue == "Диагональная")
            {
                int[,] arrayOfValues = new int[_numberOfRows, _numberOfColumns];
                for (int i = 0; i < _numberOfRows; ++i)
                {
                    for (int j = 0; j < _numberOfColumns; ++j)
                    {
                        if (i == j)
                            arrayOfValues[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                        else
                            arrayOfValues[i, j] = 0;
                    }
                }
            }

            if (_comboBoxValue == "Единичная")
            {
                int[,] arrayOfValues = new int[_numberOfRows, _numberOfColumns];
                for (int i = 0; i < _numberOfRows; ++i)
                {
                    for (int j = 0; j < _numberOfColumns; ++j)
                    {
                        if (i == j)
                            arrayOfValues[i, j] = 1;
                        else
                            arrayOfValues[i, j] = 0;

                    }
                }
            }

            if (_comboBoxValue == "Нулевая")
            {
                int[,] arrayOfValues = new int[_numberOfRows, _numberOfColumns];
                for (int i = 0; i < _numberOfRows; ++i)
                {
                    for (int j = 0; j < _numberOfColumns; ++j)
                            arrayOfValues[i, j] = 0;
                }
            }

            Close();
        }
        
        private int _numberOfRows;
        private int _numberOfColumns;
        private string _comboBoxValue;
    }
}
