using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStorage;
using Npgsql;

namespace GameForms
{
    public partial class Form3 : Form
    {

        IScoreRepository _scoreRepository;

        public Form3()
        {
            InitializeComponent();

            _scoreRepository = new PostgresScoreRepository();

        }
        private void SelectData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "name";
            dataGridView1.Columns[1].Name = "second";
            dataGridView1.Columns[2].Name = "time";

            int i;
           foreach(var result in _scoreRepository.GetAll())
            {
                i = dataGridView1.Rows.Add();

                

                dataGridView1.Rows[i].Cells[0].Value = result.Username;
                dataGridView1.Rows[i].Cells[1].Value = result.Second;
                dataGridView1.Rows[i].Cells[2].Value = result.DateTime;
            }
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}
