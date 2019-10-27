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
            InitializeComponent();
        }

        public Matrix(NumericUpDown numericUpDown1, NumericUpDown numericUpDown2)
        {
            InitializeComponent();
            _numericUpDown1 = numericUpDown1;
            _numericUpDown2 = numericUpDown2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)_numericUpDown2.Value;
            dataGridView1.ColumnCount = (int)_numericUpDown1.Value;
            for (int i = 0; i < (int)_numericUpDown2.Value; i++)
            {
                for (int j = 0; j < (int)_numericUpDown1.Value; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private NumericUpDown _numericUpDown1;
        private NumericUpDown _numericUpDown2;
    }
}
