using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PVIBroker
{
    public partial class PropGrid : DataGridView
    {
        public PropGrid()
        {
            InitializeComponent();
        }    

        public void PrintProperty(string propname,params object[] vals)
        {
            bool setted = false;
            if (this.Columns.Count == 0) return;
            foreach (DataGridViewRow dgvr in this.Rows)
            {
                if (dgvr.Cells[0].Value == propname)
                {
                    int idx = 1;
                    foreach (object obj in vals)
                    {
                        dgvr.Cells[idx].Value = obj.ToString();
                        idx++;
                    }
                    setted = true;
                    break;
                }              

            }
            if (!setted)
            {
                foreach (DataGridViewRow dgvr in this.Rows)
                {
                    if (dgvr.Cells[0].Value == null)
                    {
                        dgvr.Cells[0].Value = propname;
                        int idx = 1;
                        foreach (object obj in vals)
                        {
                            dgvr.Cells[idx].Value = obj.ToString();
                            idx++;
                        }
                        setted = true;
                        break;
                    }
                }
            }
            if (!setted)
            {
                int newrowidx = this.Rows.Add();
                this.Rows.Add();
                this.Rows[newrowidx].Cells[0].Value = propname;
                int idx = 1;
                foreach (object obj in vals)
                {
                    this.Rows[newrowidx].Cells[idx].Value = obj.ToString();
                    idx++;
                }
            }

            this.Refresh();
        }
    }
}
