using System;
using System.Windows.Forms;
using MatrixApp.Properties;

namespace MatrixApp
{
    public partial class Matrix<T> : Form where T : IConvertible
    {
        public Matrix()
        {

        }

        public Matrix(int numberOfRows, int numberOfColumns, T[,] matrixValues)
        {
            InitializeComponent();
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _resultMatrixValues = new T[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < matrixValues.GetLength(0); ++i)
                for (var j = 0; j < matrixValues.GetLength(1); ++j)
                    _resultMatrixValues[i, j] = matrixValues[i, j];
            _comboBoxValue = "Result";
            _operand = "Result";

            _resultMatrix = new MatrixLib.Matrix<T>(_resultMatrixValues.GetLength(0),
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

        public Matrix(int numberOfRows, int numberOfColumns, T[,] matrixValues, string operand)
        {
            InitializeComponent();
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _resultMatrixValues = new T[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < matrixValues.GetLength(0); ++i)
                for (var j = 0; j < matrixValues.GetLength(1); ++j)
                    _resultMatrixValues[i, j] = matrixValues[i, j];
            _comboBoxValue = "Loaded";
            _operand = operand;
        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            this.Text = _operand;

            _userMatrixValues = new T[_numberOfRows, _numberOfColumns];

            if (_resultMatrix == null || _rightMatrix == null || _numberOfRows > _rightMatrix.Get2DArray().GetLength(0)
                || _numberOfColumns > _rightMatrix.Get2DArray().GetLength(1)
                || _numberOfRows > _resultMatrix.Get2DArray().GetLength(0) || _numberOfColumns > _resultMatrix.Get2DArray().GetLength(1))
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = (T)Convert.ChangeType(1, typeof(T));
            }

            else if (_resultMatrix != null && _operand == "Left Matrix")
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = _resultMatrix.Get2DArray()[i, j];

                _leftMatrix = new MatrixLib.Matrix<T>(_numberOfRows, _numberOfColumns, _userMatrixValues);
                _resultMatrix = new MatrixLib.Matrix<T>(_numberOfRows, _numberOfColumns, _userMatrixValues);
            }

            else if (_rightMatrix != null && _operand == "Right Matrix")
            {
                for (var i = 0; i < _numberOfRows; ++i)
                    for (var j = 0; j < _numberOfColumns; ++j)
                        _userMatrixValues[i, j] = _rightMatrix.Get2DArray()[i, j];

                _rightMatrix = new MatrixLib.Matrix<T>(_numberOfRows, _numberOfColumns, _userMatrixValues);
            }

            switch (_comboBoxValue)
            {
                case "Custom":
                    UserMatrix();
                    break;
                case "Diagonal":
                    DiagMatrix();
                    break;
                case "Unit":
                    UnitMatrix();
                    break;
                case "Zero":
                    ZeroMatrix();
                    break;
                case "Loaded":
                    LoadedMatrix();
                    break;
                case "Result":
                    ResultMatrix();
                    break;
            }
        }

        partial void UserMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = _userMatrixValues[i, j];
            }
        }

        partial void LoadedMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = _resultMatrixValues[i, j];
            }
        }

        partial void DiagMatrix()
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

        partial void UnitMatrix()
        {
            dataGridView1.RowCount = _numberOfRows;
            dataGridView1.ColumnCount = _numberOfColumns;
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = i == j ? 1 : 0;

                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }

        partial void ZeroMatrix()
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

        partial void ResultMatrix()
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

        private void Button1Click(object sender, EventArgs e)
        {
            switch (_comboBoxValue)
            {
                case "Unit":
                    {
                        if (_operand == "Left Matrix")
                            _leftMatrix = MatrixLib.Matrix<T>.CreateOnesMatrix(_numberOfRows, _numberOfColumns);
                        if (_operand == "Right Matrix")
                            _rightMatrix = MatrixLib.Matrix<T>.CreateOnesMatrix(_numberOfRows, _numberOfColumns);
                        break;
                    }
                case "Zero":
                    {
                        if (_operand == "Left Matrix")
                            _leftMatrix = MatrixLib.Matrix<T>.CreateZeroMatrix(_numberOfRows, _numberOfColumns);
                        if (_operand == "Right Matrix")
                            _rightMatrix = MatrixLib.Matrix<T>.CreateZeroMatrix(_numberOfRows, _numberOfColumns);
                        break;
                    }
                default:
                    {
                        if (_operand == "Left Matrix")
                            _leftMatrix = new MatrixLib.Matrix<T>(_numberOfRows, _numberOfColumns, MatrixWrite());
                        if (_operand == "Right Matrix")
                            _rightMatrix = new MatrixLib.Matrix<T>(_numberOfRows, _numberOfColumns, MatrixWrite());
                        break;
                    }
            }

            Close();
        }

        private T[,] MatrixWrite()
        {
            var arrayOfDoubleValues = new double[_numberOfRows, _numberOfColumns];
            var arrayOfValues = new T[_numberOfRows, _numberOfColumns];
            for (var i = 0; i < _numberOfRows; ++i)
            {
                for (var j = 0; j < _numberOfColumns; ++j)
                {
                    try
                    {
                        arrayOfDoubleValues[i, j] = (double)Convert.ChangeType(dataGridView1[j, i].Value, typeof(double));
                        arrayOfValues[i, j] = (T)Convert.ChangeType(arrayOfDoubleValues[i, j], typeof(T));
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(Resources.res02, Resources.res03);
                    }
                }
            }
            return arrayOfValues;
        }

        public static MatrixLib.Matrix<T> GetLeftMatrix()
        {
            return _leftMatrix;
        }

        public static MatrixLib.Matrix<T> GetRightMatrix()
        {
            return _rightMatrix;
        }

        string _operand;
        private int _numberOfRows;
        private int _numberOfColumns;
        private T[,] _userMatrixValues;
        private T[,] _resultMatrixValues;
        private string _comboBoxValue;

        private static MatrixLib.Matrix<T> _leftMatrix;
        private static MatrixLib.Matrix<T> _rightMatrix;
        private static MatrixLib.Matrix<T> _resultMatrix;
    }
}