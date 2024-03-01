using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

namespace LBM.Controls.ZonesMGV
{
    public class DetailTabControl : TabControl
    {
        public delegate void OpenDetailDelegate();
        public event OpenDetailDelegate openDetailEvent;

        public DetailTabControl()
        {
            Font = new Font(Font.Name, 10);

            DrawMode = TabDrawMode.OwnerDrawFixed;
            DrawItem += new DrawItemEventHandler(TabControl_DrawItem);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            // Identify which TabPage is currently selected
            TabPage SelectedTab = this.TabPages[e.Index];

            // Get the area of the header of this TabPage
            Rectangle HeaderRect = this.GetTabRect(e.Index);

            // Create a Brush to paint the Text
            SolidBrush TextBrush = new SolidBrush(Color.Black);

            // Set the Alignment of the Text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Paint the Text using the appropriate Bold setting 
            if (Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                Font BoldFont = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
                e.Graphics.DrawString(SelectedTab.Text, BoldFont, TextBrush, HeaderRect, sf);
            }
            else
                e.Graphics.DrawString(SelectedTab.Text, e.Font, TextBrush, HeaderRect, sf);

            // Job done - dispose of the Brush
            TextBrush.Dispose();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                if (openDetailEvent != null)
                {
                    openDetailEvent();
                }
            }
            else if (e.Control && e.KeyCode.Equals(Keys.Delete))
            {
                BindingSource bs = (BindingSource)grid.DataSource;

                if (bs.Current != null)
                {
                    //TODO 
                    if (MessageBox.Show("Are you sure to delete " + bs.Current.ToString(), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bs.RemoveCurrent();
                    }
                }

            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            grid.ClearSelection();
        }

        internal void AddChildgrid(IList listOfDetail, string name)
        {
            //DataGridView grid = new DataGridView();
            KryptonDataGridView grid = new KryptonDataGridView();
            // Put a counter in the rowheader
            grid.RowPostPaint += DatagridviewHelper.rowPostPaint_HeaderCount;
            // Show the Property description in a tooltip when the mouse is hovered over
            grid.CellMouseEnter += NewGrid_CellMouseEnter;
            grid.CellEndEdit += Grid_CellEndEdit;
            grid.KeyDown += Grid_KeyDown;
            grid.SelectionChanged += Grid_SelectionChanged;

            Type tipo = TypeMethods.HeuristicallyDetermineType(listOfDetail);
            ConfigColumns(grid, tipo);

            DatagridviewHelper.ApplyGridTheme(grid);

            // Add the data
            BindingSource bs = new BindingSource();
            bs.DataSource = listOfDetail;
            bs.AllowNew = false;
            grid.DataSource = bs;

            // DatagridviewHelper.setGridColumnStyleAfterBinding(grid);

            // There are some collections of the double type that we do not want to be displayed
            if (TypeMethods.HeuristicallyDetermineType(listOfDetail) != typeof(double))
            {
                TabPage tabpage = new TabPage
                {
                    Text = name,
                    ToolTipText = TypeMethods.GetDescriptionFromType(tipo)
                };
               
                tabpage.Controls.Add(grid);

                this.TabPages.Add(tabpage);
            }
        }

        private static void ConfigColumns(DataGridView grid, Type tipo)
        {
            DataGridViewColumnCollection columns = grid.Columns;

            //columns.Add(DataGridColumnFactory.IntegerColumnStyle("GewasId", "ID"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("GewasNaam", "Gewas"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Temperatuur", "Temperatuur"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Vochtigheid", "Vochtigheid"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("PH", "PH"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Stikstof", "Stikstof"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Fosfor", "Fosfor"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Kalium", "Kalium"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("Intensiteit", "Intensiteit"));
            columns.Add(DataGridColumnFactory.IntegerColumnStyle("UrenPerDag", "UrenPerDag"));
        }

        void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            // Clear the row error in case the user presses ESC.   
            grid.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        ToolTip tt = new ToolTip();
        /// <summary>
        /// Show the Property description in a tooltip when the mouse is hovered over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView newGrid = (DataGridView)sender;
            BindingSource bs = (BindingSource)newGrid.DataSource;

            // Mostrar en un tooltip la descripción de la Propiedad cuando se pase el mouse por encima
            if (e.RowIndex == -1 && e.ColumnIndex != -1 && newGrid.DataSource != null)
            {
                Type tipo = TypeMethods.HeuristicallyDetermineType((IEnumerable)bs.DataSource);
                var property = tipo.GetProperty(newGrid.Columns[e.ColumnIndex].DataPropertyName);
                var description = TypeMethods.GetDescriptionFromPropertyInfo(property);

                if (string.IsNullOrWhiteSpace(description))
                {
                    tt.Hide(newGrid);
                }
                else
                {
                    tt.SetToolTip(newGrid, description);
                }

            }
            //else
            //{
            //    tt.Hide(newGrid);
            //}
        }
    }
}
