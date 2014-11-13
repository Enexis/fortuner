using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fortuner
{
    public partial class ViewEdit : Form
    {
        private static Model m = new Model();
        public ViewEdit()
        {
            InitializeComponent();
        }

        public ViewEdit(string[] symbolList)
        {
            InitializeComponent();
            foreach (string symbol in symbolList)
            {
                lbList.Items.Add(symbol);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbSymbol.Text.ToUpper().Length > 4)
            {
                MessageBox.Show("Length too Long!");
            }
            else if (lbList.Items.Contains(tbSymbol.Text.ToUpper()))
            {
                MessageBox.Show("Symbol already exists in the list!");
                
            }
            else
            {
                lbList.Items.Add(tbSymbol.Text.ToUpper());
                m.UpdateSymbolList(lbList.Items.Cast<string>().ToArray());
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            tbSymbol.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tbSymbol.Text.ToUpper().Length > 4)
            {
                MessageBox.Show("Length too Long!");
            }
            else if(lbList.Items.Contains(tbSymbol.Text.ToUpper()))
            {
                lbList.Items.Remove(tbSymbol.Text.ToUpper());
                m.UpdateSymbolList(lbList.Items.Cast<string>().ToArray());
            }
            else
            {
                MessageBox.Show("Symbol does not exist in the list!");
            }
        }

        private void ViewEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
