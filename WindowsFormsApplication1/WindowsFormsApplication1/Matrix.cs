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
            if ((int)_numericUpDown1.Value != 0 && (int)_numericUpDown2.Value != 0)
                InitializeComponent();
        }

        public Matrix(NumericUpDown numericUpDown1, NumericUpDown numericUpDown2)
        {
            InitializeComponent();
            _numericUpDown1 = numericUpDown1;
            _numericUpDown2 = numericUpDown2;
            _result = true;
        }

        public Matrix(NumericUpDown numericUpDown1, NumericUpDown numericUpDown2, ComboBox comboBox4)
        {
            InitializeComponent();
            _numericUpDown1 = numericUpDown1;
            _numericUpDown2 = numericUpDown2;
            _comboBox = comboBox4;
            //доделать
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            if (_comboBox.SelectedItem.ToString() == "Пользовательская" || _result)
                userMatrix();

            if (((int)_numericUpDown1.Value == (int)_numericUpDown2.Value) && 
                (_comboBox.SelectedItem.ToString() == "Диагональная" || _comboBox.SelectedItem.ToString() == "Единичная"))
                diagMatrix();

            if (_comboBox.SelectedItem.ToString() == "Нулевая")
                zeroMatrix();
        }

        partial void userMatrix()
        {
            dataGridView1.RowCount = (int)_numericUpDown2.Value;
            dataGridView1.ColumnCount = (int)_numericUpDown1.Value;
            for (int i = 0; i < (int)_numericUpDown2.Value; i++)
            {
                for (int j = 0; j < (int)_numericUpDown1.Value; j++)
                    dataGridView1.Rows[i].Cells[j].Value = 1;
            }
        }

        partial void diagMatrix()
        {
            dataGridView1.RowCount = (int)_numericUpDown2.Value;
            dataGridView1.ColumnCount = (int)_numericUpDown1.Value;
            for (int i = 0; i < (int)_numericUpDown2.Value; i++)
            {
                for (int j = 0; j < (int)_numericUpDown1.Value; j++)
                    dataGridView1.Rows[i].Cells[j].Value = (i == j)
                        ? 1
                        : 0;
            }
        }

        partial void zeroMatrix()
        {
            dataGridView1.RowCount = (int)_numericUpDown2.Value;
            dataGridView1.ColumnCount = (int)_numericUpDown1.Value;
            for (int i = 0; i < (int)_numericUpDown2.Value; i++)
            {
                for (int j = 0; j < (int)_numericUpDown1.Value; j++)
                    dataGridView1.Rows[i].Cells[j].Value = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private bool _result;
        private NumericUpDown _numericUpDown1;
        private NumericUpDown _numericUpDown2;
        private ComboBox _comboBox;
    }
}
