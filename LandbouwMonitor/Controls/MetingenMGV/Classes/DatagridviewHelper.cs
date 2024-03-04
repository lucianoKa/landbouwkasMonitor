using System;
using System.Drawing;
using System.Windows.Forms;

namespace LBM.Controls.MetingenMGV
{
    public class DatagridviewHelper
    {
        static DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        static DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        /// <summary>
        /// Cabecera de las grillas
        /// </summary>
        private static readonly DataGridViewCellStyle ColumnHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
            Font = new Font("Segoe UI", 10, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True


        };

        /// <summary>
        /// Default cell style
        /// </summary>
        private static readonly DataGridViewCellStyle DefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            Font = new Font("Segoe UI", 10, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        /// <summary>
        /// Estilo del rowheader
        /// </summary>
        private static readonly DataGridViewCellStyle RowHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 10, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };


        public static void ApplyGridTheme(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.ShowCellToolTips = false;


            dataGridView.BackgroundColor = SystemColors.Window;
            dataGridView.BorderStyle = BorderStyle.None;

            // Format columnheader
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle = ColumnHeaderCellStyle;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Format rowheader
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView.RowHeadersDefaultCellStyle = RowHeaderCellStyle;
            dataGridView.TopLeftHeaderCell.Value = "No ";
            dataGridView.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.DefaultCellStyle = DefaultCellStyle;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = SystemColors.GradientInactiveCaption;
            dataGridView.Font = ColumnHeaderCellStyle.Font;


            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.BackgroundColor = SystemColors.Window;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle = DefaultCellStyle;// gridCellStyle;
            dataGridView.ColumnHeadersHeight = 32;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.DefaultCellStyle = DefaultCellStyle;//gridCellStyle2;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = SystemColors.GradientInactiveCaption;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.RowHeadersDefaultCellStyle = DefaultCellStyle;//gridCellStyle3;
            dataGridView.Font = DefaultCellStyle.Font;//gridCellStyle.Font;

            dataGridView.Refresh();
        }

        /// <summary>
        /// Fijar el estilo de las columnas en base a su tipo
        /// Importante: Invocar después de llenar las columnas
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void setGridColumnStyleAfterBinding(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.ValueType == null)
                {
                    //cCol.DefaultCellStyle = dateCellStyle;
                }
                else if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle = dateCellStyle;
                }
                else if (column.ValueType == typeof(decimal) || column.ValueType == typeof(double) || column.ValueType == typeof(int))
                {
                    column.DefaultCellStyle = amountCellStyle;
                }
            }
            //dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        /// <summary>
        /// Poner un contador el el rowheader (columna de la izquierda)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();
            dynamic centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView.RowHeadersWidth, e.RowBounds.Height  /* - sender.rows(e.RowIndex).DividerHeight*/  );
            e.Graphics.DrawString(rowIdx, dataGridView.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

    }
}
