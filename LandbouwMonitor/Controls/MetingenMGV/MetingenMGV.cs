﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

namespace LBM.Controls.MetingenMGV
{
    public class MetingenMGV : KryptonDataGridView   // DataGridView
    {
        internal List<int> lstCurrentRows = new List<int>();
        internal int rowDefaultHeight = 22;
        internal int rowExpandedHeight = 300;
        internal int rowDefaultDivider = 0;
        internal int rowExpandedDivider = 300 - 22;
        internal int rowDividerMargin = 5;
        internal bool doCollapseRow;


        ImageList rowHeaderIconList = new ImageList();

        internal DetailTabControl detailTabControl = new DetailTabControl
        {
            Height = 278 /*rowExpandedDivider*/ - 5/*rowDividerMargin*/ * 2,
            Visible = false
        };

        private IContainer components;

        public enum rowHeaderIcons
        {
            expand = 1,
            collapse = 0
        }

        public MetingenMGV()
        {
            InitializeComponent();

            rowHeaderIconList.Images.Add(DgvResource.expanded);
            rowHeaderIconList.Images.Add(DgvResource.collapsed);
            rowHeaderIconList.TransparentColor = Color.Transparent;
            rowHeaderIconList.Images.SetKeyName(1, "expanded.png");
            rowHeaderIconList.Images.SetKeyName(0, "collapsed.png");

            Scroll += MasterControl_Scroll;

            // Draw the "+" symbol
            RowPostPaint += MasterControl_RowPostPaint;

            // By clicking on the "+" symbol in the rowheader
            RowHeaderMouseClick += MasterControl_RowHeaderMouseClick;

            // Show the Property description in a tooltip when the mouse is hovered over
            CellMouseEnter += MetingenMGV_CellMouseEnter;

            // Clear cell when ESC is pressed
            CellEndEdit += MetingenMGV_CellEndEdit;

            // Disable Selection
            SelectionChanged += MetingenMGV_SelectionChanged;

            // Delete records or open details
            KeyDown += MetingenMGV_KeyDown;

            DatagridviewHelper.ApplyGridTheme(this);
        }

        void MetingenMGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MetingenMGV grid = (MetingenMGV)sender;

            // Clear the row error in case the user presses ESC.   
            grid.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void MetingenMGV_SelectionChanged(object sender, EventArgs e)
        {
            MetingenMGV grid = (MetingenMGV)(sender);
            grid.ClearSelection();
        }

        void MetingenMGV_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // refrescar las celdas a las que no se les haya hecho commit
            if (this.IsCurrentCellDirty)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        void MetingenMGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.Delete))
            {
                BindingSource bs = (BindingSource)this.DataSource;

                if (bs.Current != null)
                {
                    //TODO pending validation that it is not being used elsewhere
                    if (MessageBox.Show("Are you sure to delete " + bs.Current.ToString(), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bs.RemoveCurrent();
                    }
                }
            }
            else if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                // open detail
                OpenDetail(this.CurrentRow.Index);
            }
        }

        ToolTip tt = new ToolTip();
        private void MetingenMGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //// Show tooltip of Property Description in Header's Column
            //if (e.RowIndex == -1 && e.ColumnIndex != -1 && this.DataSource != null)
            //{
            //    var tipo = typeof(T);
            //    var property = tipo.GetProperty(this.Columns[e.ColumnIndex].DataPropertyName);
            //    var description = TypeMethods.GetDescriptionFromPropertyInfo(property);

            //    if (string.IsNullOrWhiteSpace(description))
            //    {
            //        tt.Hide(this);
            //    }
            //    else
            //    {
            //        tt.SetToolTip(this, description);
            //    }
            //}
            ////else
            ////{
            ////    tt.Hide(this);
            ////}
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MetingenMGV));


            ((ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();

            ((ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// It is necessary to set the daughter grid to the same hierarchy level as the Mastergrid
        /// </summary>
        public void SetChild()
        {
            if (this.Parent == null)
            {
                throw new Exception("The control should be in a container.");
            }
            this.Parent.Controls.Add(detailTabControl);
            detailTabControl.BringToFront();
        }


        private void MasterControl_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.X + ((rowDefaultHeight - 16) / 2), e.RowBounds.Y + ((rowDefaultHeight - 16) / 2), 16, 16);

            //if (HasDetailList())
            {
                if (doCollapseRow)
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        this.Rows[e.RowIndex].DividerHeight = this.Rows[e.RowIndex].Height - rowDefaultHeight;

                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.collapse], rect);

                        detailTabControl.Location = new Point(e.RowBounds.Left + this.RowHeadersWidth + 25, e.RowBounds.Top + rowDefaultHeight + 25);
                        detailTabControl.Width = e.RowBounds.Right - this.RowHeadersWidth;
                        detailTabControl.Height = this.Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        detailTabControl.Visible = false;
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.expand], rect);
                    }
                    doCollapseRow = false;
                }
                else
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        this.Rows[e.RowIndex].DividerHeight = this.Rows[e.RowIndex].Height - rowDefaultHeight;
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.collapse], rect);
                        detailTabControl.Location = new Point(e.RowBounds.Left + this.RowHeadersWidth + 25, e.RowBounds.Top + rowDefaultHeight + 25);
                        detailTabControl.Width = e.RowBounds.Right - this.RowHeadersWidth;
                        detailTabControl.Height = this.Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.expand], rect);
                    }
                }
            }

            DatagridviewHelper.rowPostPaint_HeaderCount(sender, e);
        }

        private void MasterControl_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.Rows[e.RowIndex].DataBoundItem == null)
            {
                return;
            }
            Rectangle rect = new Rectangle((rowDefaultHeight - 16) / 2, (rowDefaultHeight - 16) / 2, 16, 16);
            if (rect.Contains(e.Location))
            {
                // If you press the plus symbol the detail opens
                OpenDetail(e.RowIndex);
            }
            else
            {
                doCollapseRow = false;
            }
        }

        /// <summary>
        /// Open/Close the detail subgrid
        /// </summary>
        /// <param name="rowIndex">Index of the record to edit</param>
        private void OpenDetail(int rowIndex)
        {
            if (lstCurrentRows.Contains(rowIndex))
            {
                lstCurrentRows.Clear();
                this.Rows[rowIndex].Height = rowDefaultHeight;
                this.Rows[rowIndex].DividerHeight = rowDefaultDivider;
            }
            else
            {
                if (lstCurrentRows.Count != 0)
                {
                    int eRow = lstCurrentRows[0];
                    lstCurrentRows.Clear();
                    this.Rows[eRow].Height = rowDefaultHeight;
                    this.Rows[eRow].DividerHeight = rowDefaultDivider;
                    this.ClearSelection();
                    doCollapseRow = true;
                    this.Rows[eRow].Selected = true;
                }

                lstCurrentRows.Add(rowIndex);

                Type parentType = TypeMethods.HeuristicallyDetermineType((IList)this.DataSource);
                object parentObject = this.Rows[rowIndex].DataBoundItem;

                // Detalle
                detailTabControl.TabPages.Clear();

                detailTabControl.openDetailEvent += detailTabControl_OpenDetail;

                if (parentObject != null)
                {
                    foreach (FieldInfo childField in parentType.GetFields())
                    {
                        // Check if fieldtype is List
                        if (childField.FieldType.IsGenericType
                            && childField.FieldType.GetGenericTypeDefinition() == typeof(List<>)
                            && childField.FieldType.GetGenericTypeDefinition() != typeof(List<double>))
                        {
                            IList listOfDetail = (IList)childField.GetValue(parentObject);

                            foreach (var item in listOfDetail)
                            {
                                var zone = (EF.Zone)item;

                                string name = zone.ZoneNaam;

                                detailTabControl.AddChildgrid(zone.Gewassen, name);
                            }                            
                        }
                    }
                }

                // expand row
                if (detailTabControl.HasChildren)
                {
                    this.Rows[rowIndex].Height = 150; // rowExpandedHeight;
                    this.Rows[rowIndex].DividerHeight = rowExpandedDivider;
                }
                else
                {
                    detailTabControl.Visible = false;
                }
            }
            this.ClearSelection();
            doCollapseRow = true;
            this.Rows[rowIndex].Selected = true;
        }

        void detailTabControl_OpenDetail()
        {
            // Se invoca al método que abre/cierra la grilla de detalle
            OpenDetail(this.CurrentRow.Index);
        }

        private void MasterControl_Scroll(object sender, ScrollEventArgs e)
        {
            if (!(lstCurrentRows.Count == 0))
            {
                doCollapseRow = true;
                this.ClearSelection();
                this.Rows[lstCurrentRows[0]].Selected = true;
            }
        }
    }
}
