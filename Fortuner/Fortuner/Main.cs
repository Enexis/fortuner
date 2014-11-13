using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Fortuner
{
    public partial class Main : Form
    {
        private static Model m = new Model();
        public Main()
        {
            InitializeComponent();

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            string symbolList;
            Model m = new Model();
            m.ShutDown();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            System.Threading.Thread worker1 = new System.Threading.Thread(btnStart_Click_Thread);
            worker1.Start();
        }

        private void btnStart_Click_Thread()
        {
            string[] datas = { };
            string[] symbols = m.GetSymbolList();
            foreach (string symbol in symbols)
            {
                datas = m.GetDataNoHeader(m.GenerateUrl(symbol)).ToArray();
                m.CreateTable(symbol);
                m.InsertTableData(datas, symbol);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ViewEdit viewEdit = new ViewEdit(m.GetSymbolList());
            viewEdit.Show();
            foreach (string symbol in m.GetSymbolList())
            {
                //MessageBox.Show(symbol);
            }
        }

        private void btnStart_Click()
        {

        }
    }
}
