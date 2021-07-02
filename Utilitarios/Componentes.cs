using System;
using System.Windows.Forms;


namespace Utilitarios
{
    public class Componentes
    {
        public static DataGridViewButtonColumn BotonDeColumna(String nombre)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "-";
            btn.Name = "button";
            btn.Text = nombre;
            btn.UseColumnTextForButtonValue = true;
            return btn;
        }




        public static void DesactivarOrdenamientoDGV(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public static void CambiarAnchoColumna(DataGridView dgv, int idx, int size)
        {
            dgv.Columns[idx].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns[idx].Width = size;
        }
    }
}
