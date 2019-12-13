using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixApp
{
    public partial class Matrix : Form
    {
        public Matrix()
        {

        }

        public Matrix(int numberOfRows, int numberOfColumns, int[,] matrixValues)
        {
            InitializeComponent();
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _resultMatrixValues = new int[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < matrixValues.GetLength(0); ++i)
                for (var j = 0; j < matrixValues.GetLength(1); ++j)
                    _resultMatrixValues[i, j] = matrixValues[i, j];
            _comboBoxValue = "Result";
            _operand = "Result";

            _resultMatrix = new MatrixLib.Matrix<int>(_resultMatrixValues.GetLength(0),
                _resultMatrixValues.GetLength(1), _resultMatrixValues);
        }

        public Matrix(NumericUpDown firstNumericUpDown, NumericUpDown secondNumericUpDown, ComboBox comboBox, string operand)
        {
            InitializeComponent();
            _numberOfRows = (int)firstNumericUpDown.Value;
            _numberOfColumns = (int)secondNumericUpDown.Value;
            _comboBoxValue = comboBox.SelectedItem.ToString();
            _operand = operand;
        }

        public Matrix(int numberOfRows, int numberOfColumns, int[,] matrixValues, string operand)
        {
            InitializeComponent();
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _resultMatrixValues = new int[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < matrixValues.GetLength(0); ++i)
                for (var j = 0; j < matrixValues.GetLength(1); ++j)
                    _resultMatrixValues[i, j] = matrixValues[i, j];
            _comboBoxValue = "Loaded";
            _operand = operand;
        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            this.Text = _operand;

            _userMatrixValues = new int[_numberOfRows, _numberOfColumns];

            if (_resultMatrix == null || _rightMatrix == null || _numberOfRows > _rightMatrix.Get2DArray().GetLength(0)
                || _numberOfColumns > _rightMatrix.Get2DArray().GetLength(1)
                || _numberOfRows > _resultMatrix.Get2DArray().GetLength(0) || _numberOfColumns > _resultMatrix.Get2DArray().GetLength(1))
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = 1;
            }

            else if (_resultMatrix != null && _operand == "Left Matrix")
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = _resultMatrix.Get2DArray()[i, j];

                _leftMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, _userMatrixValues);
                _resultMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, _userMatrixValues);
            }

            else if (_rightMatrix != null && _operand == "Right Matrix")
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = _rightMatrix.Get2DArray()[i, j];

                _rightMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, _userMatrixValues);
            }
            
            switch(_comboBoxValue)
            {
                case "Custom":
                    userMatrix();
                    break;
                case "Diagonal":
                    diagMatrix();
                    break;
                case "Unit":
                    unitMatrix();
                    break;
                case "Zero":
                    zeroMatrix();
                    break;
                case "Loaded":
                    loadedMatrix();
                    break;
                case "Result":
                    resultMatrix();
                    break;
            }
        }

        partial void userMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = _userMatrixValues[i, j];
            }
        }

        partial void loadedMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = _resultMatrixValues[i, j];
            }
        }

        partial void diagMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
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

        partial void unitMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    if (i == j)
                        dataGridView1.Rows[i].Cells[j].Value = 1;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = 0;

                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }

        partial void zeroMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }

        partial void resultMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = _resultMatrixValues[i, j];
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_comboBoxValue == "Custom" || _comboBoxValue == "Loaded" || _comboBoxValue == "Diagonal")
            {
                if (_operand == "Left Matrix")
                    _leftMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, matrixWrite());

                if (_operand == "Right Matrix")
                    _rightMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, matrixWrite());
            }

            if (_comboBoxValue == "Unit")
            {
                if (_operand == "Left Matrix")
                    _leftMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, MatrixLib.MatrixType.Ones);

                if (_operand == "Right Matrix")
                    _rightMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, MatrixLib.MatrixType.Ones);
            }

            if (_comboBoxValue == "Zero")
            {
                if (_operand == "Left Matrix")
                    _leftMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, MatrixLib.MatrixType.Zeros);

                if (_operand == "Right Matrix")
                    _rightMatrix = new MatrixLib.Matrix<int>(_numberOfRows, _numberOfColumns, MatrixLib.MatrixType.Zeros);
            }

            Close();
        }

        int[,] matrixWrite()
        {
            var arrayOfValues = new int[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    try
                    {
                        arrayOfValues[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("You entered an invalid character as a matrix element.\n" +
                            "Don't do that. Please, check the elements of the matrix you set.", "Error!");
                    }
                }
            }
            return arrayOfValues;
        }

        static public MatrixLib.Matrix<int> GetLeftMatrix()
        {
            return _leftMatrix;
        }

        static public MatrixLib.Matrix<int> GetRightMatrix()
        {
            return _rightMatrix;
        }

        string _operand;
        private int _numberOfRows;
        private int _numberOfColumns;
        int[,] _userMatrixValues;
        int[,] _resultMatrixValues;
        private string _comboBoxValue;

        static private MatrixLib.Matrix<int> _leftMatrix;
        static private MatrixLib.Matrix<int> _rightMatrix;
        static private MatrixLib.Matrix<int> _resultMatrix;
    }
}