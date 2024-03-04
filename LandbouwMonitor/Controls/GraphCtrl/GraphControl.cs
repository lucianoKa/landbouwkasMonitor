using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LBM
{
    public partial class GraphControl : Control
    {
        #region Declarations
        private const int GraphPenWidth = 1;
        private const int SelectedGraphPenWidth = 2;
        private const int DefaultWidth = 200;
        private const int DefaultHeight = 400;
        private const int XMargin = 10;
        private const int YMargin = 10;
        private const int GraphLegendXMargin = 10;
        private const int AxeWidth = 1;
        private const int AxeTickSize = 10;
        private Dictionary<string, PointsSerie> _PointsSeries;
        private GraphAxe _HorizontalAxe;
        private GraphAxe _VerticalPrimaryAxe;
        private GraphAxe _VerticalSecondaryAxe;
        private Font _GraphFont, _GraphLegendFont, _AxeFont;
        private RectangleF _GraphRectangle;
        private RectangleF _GraphTitleRectangle;
        private RectangleF _GraphLegendsRectangle;
        private Dictionary<string, RectangleF> _GraphLegendRectangles;
        private RectangleF _HorizontalAxeRectangle;
        private RectangleF _VerticalPrimaryAxeRectangle;
        private RectangleF _VerticalSecondaryAxeRectangle;
        private string _SelectedSerie;
        private TextBox GraphTitleTextBox;
        private Font GraphLegendSymbolFont;
        private string _DateTimeFormat;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize a new GraphControl using default Title, Legend and Axe fonts.
        /// </summary>
        public GraphControl()
        {
            Initialize();
            _GraphFont = new Font("Arial", 15);
            _GraphLegendFont = new Font("Arial", 10);
            _AxeFont = new Font("Arial", 8);
            _DateTimeFormat = "ddd MMM-d hh:mm";
        }

        /// <summary>
        /// Initialize a new GraphControl using the specified Title, Legend and Axe fonts.
        /// </summary>
        /// <param name="TitleFont">The font used to display the title of the Graph Control.</param>
        /// <param name="GraphLegendFont">The font use to display the legends.</param>
        /// <param name="AxeFont">The font used to display values on axes.</param>
        public GraphControl(Font TitleFont, Font GraphLegendFont, Font AxeFont)
        {
            Initialize();
            _GraphFont = TitleFont;
            _GraphLegendFont = GraphLegendFont;
            _AxeFont = AxeFont;
            _DateTimeFormat = "ddd MMM-d hh:mm";
        }

        /// <summary>
        /// Initialize a new GraphControl using the specified Title, Legend and Axe fonts and Date Time format.
        /// </summary>
        /// <param name="TitleFont">The font used to display the title of the Graph Control.</param>
        /// <param name="GraphLegendFont">The font use to display the legends.</param>
        /// <param name="AxeFont">The font used to display values on axes.</param>
        /// <param name="DTFormat">The format to use to display the Date and Time.</param>
        public GraphControl(Font TitleFont, Font GraphLegendFont, Font AxeFont, string DTFormat)
        {
            Initialize();
            _GraphFont = TitleFont;
            _GraphLegendFont = GraphLegendFont;
            _AxeFont = AxeFont;

            DateTime DateTimeTemp = DateTime.Now;
            String StrgTemp;
            try
            {
                StrgTemp = DateTimeTemp.ToString(DTFormat); //Will generate an exception if the format is not correct
                _DateTimeFormat = DTFormat;
            }
            catch
            {
                _DateTimeFormat = "ddd MMM-d hh:mm";
            }
        }
        #endregion

        private void Initialize()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            this.Width = DefaultWidth;
            this.Height = DefaultHeight;
            _PointsSeries = new Dictionary<string, PointsSerie>();
            _HorizontalAxe = new GraphAxe(Axes.Horizontal);
            _VerticalPrimaryAxe = new GraphAxe(Axes.VerticalPrimary);
            _VerticalSecondaryAxe = new GraphAxe(Axes.VerticalSecondary);
            _GraphRectangle = new RectangleF();
            _GraphTitleRectangle = new RectangleF();
            _GraphLegendsRectangle = new RectangleF();
            _GraphLegendRectangles = new Dictionary<string, RectangleF>();
            _HorizontalAxeRectangle = new RectangleF();
            _VerticalPrimaryAxeRectangle = new RectangleF();
            _VerticalSecondaryAxeRectangle = new RectangleF();
            _SelectedSerie = string.Empty;
            GraphLegendSymbolFont = new Font("Verdana", 8, FontStyle.Bold);            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            DrawGraph(pe.Graphics, ClientRectangle);
        }

        /// <summary>
        /// Draw the control to a Graphics object.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto.</param>
        /// <param name="bounds">The Rectangle on which to draw</param>
        public void DrawGraph(System.Drawing.Graphics g, Rectangle bounds)
        {
            float xFactor;
            double yPrimaryAxeFactor, ySecondaryAxeFactor;
            PointF[] GraphPointsArray = null;
            Pen AxePen = new Pen(Brushes.Black, AxeWidth);
            Pen PrimaryAxeTickPen = new Pen(Brushes.Gray, AxeWidth);
            Pen SecondaryAxeTickPen = new Pen(Brushes.DarkGray, AxeWidth);
            bool IsPoints = false;
            DateTime XCurrentDateTime;
            TimeSpan HorizontalAxeTimeSpan;
            float HorizontalTickPosition, VerticalTickPosition;
            StringFormat HorizontalAxeStringFormat, VerticalStringFormat;
            SizeF HorizontalAxeTickTextSize, HorizontalAxeTickMaxTextSize, VerticalPrimaryTickTextSize, VerticalPrimaryTickMaxTextSize, VerticalSecondaryTickTextSize, VerticalSecondaryTickMaxTextSize, GraphTitleTextSize;
            string GraphLegendsText = string.Empty;
            SizeF GraphLegendsPrimarySymbolSize = new SizeF(0, 0);
            SizeF GraphLegendsSecondarySymbolSize = new SizeF(0, 0);
            SizeF GraphLegendsSymbolsTotalSize = new SizeF(0, 0);
            SizeF GraphLegendsTotalSize = new SizeF(0, 0);
            Dictionary<string, SizeF> GraphLegendTextSizes = new Dictionary<string, SizeF>(); 
            double yCurrentValue;

            //_GraphRectangle = ClientRectangle;
            _GraphRectangle = bounds;
            _GraphRectangle.Inflate(-1, -1);
            g.DrawRectangle(Pens.Black, _GraphRectangle.Location.X, _GraphRectangle.Location.Y, _GraphRectangle.Width, _GraphRectangle.Height);
            _GraphRectangle.Inflate(1, 1);

            //Check if there any Point
            foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
            {
                if (kvp.Value.Count != 0)
                {
                    IsPoints = true;
                    break;
                }
            }

            //Display Graphs
            if (IsPoints)
            {
                //Adjust the way Text are rendered
                //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //Calculate various Text sizes
                //Graph Title
                GraphTitleTextSize = g.MeasureString(Name, _GraphFont);
                //Graph Legends
                //Determine the size of Primary and Secondary Symbols
                GraphLegendsPrimarySymbolSize = g.MeasureString(Properties.Resources.PRIMARY_AXE_SYMBOL, GraphLegendSymbolFont);
                GraphLegendsSecondarySymbolSize = g.MeasureString(Properties.Resources.SECONDARY_AXE_SYMBOL, GraphLegendSymbolFont);
                GraphLegendsSymbolsTotalSize.Width = GraphLegendsPrimarySymbolSize.Width;
                GraphLegendsSymbolsTotalSize.Height = GraphLegendsPrimarySymbolSize.Height;
                if (GraphLegendsPrimarySymbolSize.Width < GraphLegendsSecondarySymbolSize.Width) GraphLegendsSymbolsTotalSize.Width = GraphLegendsSecondarySymbolSize.Width;
                if (GraphLegendsPrimarySymbolSize.Height < GraphLegendsSecondarySymbolSize.Height) GraphLegendsSymbolsTotalSize.Height = GraphLegendsSecondarySymbolSize.Height;
                //Inflate by 1 point all around
                GraphLegendsSymbolsTotalSize.Width += 2;
                GraphLegendsSymbolsTotalSize.Height += 2;
                //Determine the total size of the legends
                GraphLegendsTotalSize.Width = 0;
                GraphLegendsTotalSize.Height = GraphLegendsSymbolsTotalSize.Height;
                {
                    SizeF TmpSize;
                    foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
                    {
                        TmpSize = g.MeasureString(kvp.Value.Label, _GraphLegendFont);
                        TmpSize.Width += 1; //Compensate for future float to int conversion
                        GraphLegendTextSizes.Add(kvp.Key, TmpSize);
                        if (GraphLegendTextSizes[kvp.Key].Height > GraphLegendsTotalSize.Height) GraphLegendsTotalSize.Height = GraphLegendTextSizes[kvp.Key].Height;
                    }
                }
                foreach (KeyValuePair<string, SizeF> kvp in GraphLegendTextSizes)
                {
                    GraphLegendsTotalSize.Width += GraphLegendsSymbolsTotalSize.Width;
                    GraphLegendsTotalSize.Width += 1;
                    GraphLegendsTotalSize.Width += kvp.Value.Width;
                    GraphLegendsTotalSize.Width += GraphLegendXMargin;
                }
                GraphLegendsTotalSize.Width -= GraphLegendXMargin;

                //Horizontal Axe
                XCurrentDateTime = _HorizontalAxe.MinValueDateTime;
                HorizontalAxeTickMaxTextSize = new SizeF(0, 0);
                do
                {
                    XCurrentDateTime = XCurrentDateTime.AddDays(1);
                    HorizontalAxeTickTextSize = g.MeasureString(XCurrentDateTime.Date.ToString(_DateTimeFormat), _AxeFont);
                    if (HorizontalAxeTickTextSize.Width > HorizontalAxeTickMaxTextSize.Width) HorizontalAxeTickMaxTextSize.Width = HorizontalAxeTickTextSize.Width;
                    if (HorizontalAxeTickTextSize.Height > HorizontalAxeTickMaxTextSize.Height) HorizontalAxeTickMaxTextSize.Height = HorizontalAxeTickTextSize.Height;
                }
                while (XCurrentDateTime.CompareTo(_HorizontalAxe.MaxValueDateTime) < 0);
                //Vertical Primary Axe
                VerticalPrimaryTickMaxTextSize = new SizeF(0, 0);
                yCurrentValue = Math.Ceiling(_VerticalPrimaryAxe.MinValue / _VerticalPrimaryAxe.MajorUnit) * _VerticalPrimaryAxe.MajorUnit;
                do
                {
                    if (yCurrentValue < _VerticalPrimaryAxe.MaxValue)
                    {
                        VerticalPrimaryTickTextSize = g.MeasureString(yCurrentValue.ToString(), _AxeFont);
                        if (VerticalPrimaryTickTextSize.Width > VerticalPrimaryTickMaxTextSize.Width) VerticalPrimaryTickMaxTextSize.Width = VerticalPrimaryTickTextSize.Width;
                        if (VerticalPrimaryTickTextSize.Height > VerticalPrimaryTickMaxTextSize.Height) VerticalPrimaryTickMaxTextSize.Height = VerticalPrimaryTickTextSize.Height;
                    }
                    yCurrentValue += _VerticalPrimaryAxe.MajorUnit;
                }
                while (yCurrentValue < _VerticalPrimaryAxe.MaxValue);

                //Vertical Secondary Axe
                VerticalSecondaryTickMaxTextSize = new SizeF(0, 0);
                yCurrentValue = Math.Ceiling(_VerticalSecondaryAxe.MinValue / _VerticalSecondaryAxe.MajorUnit) * _VerticalSecondaryAxe.MajorUnit;
                do
                {
                    if (yCurrentValue < _VerticalSecondaryAxe.MaxValue)
                    {
                        VerticalSecondaryTickTextSize = g.MeasureString(yCurrentValue.ToString(), _AxeFont);
                        if (VerticalSecondaryTickTextSize.Width > VerticalSecondaryTickMaxTextSize.Width) VerticalSecondaryTickMaxTextSize.Width = VerticalSecondaryTickTextSize.Width;
                        if (VerticalSecondaryTickTextSize.Height > VerticalSecondaryTickMaxTextSize.Height) VerticalSecondaryTickMaxTextSize.Height = VerticalSecondaryTickTextSize.Height;
                    }
                    yCurrentValue += _VerticalSecondaryAxe.MajorUnit;
                }
                while (yCurrentValue < _VerticalSecondaryAxe.MaxValue);

                //Calculate various rectangles
                //Graph Title
                _GraphTitleRectangle.Location = new PointF(bounds.Left + XMargin, bounds.Top + YMargin);
                _GraphTitleRectangle.Size = new SizeF(bounds.Width - (2 * XMargin), GraphTitleTextSize.Height);
                //Graph Legends
                _GraphLegendsRectangle.Location = new PointF(bounds.Left + XMargin, _GraphTitleRectangle.Bottom);
                _GraphLegendsRectangle.Size = new SizeF(bounds.Width - (2 * XMargin), GraphLegendsTotalSize.Height);
                //Vertical Primary Axe
                _VerticalPrimaryAxeRectangle.Location = new PointF(bounds.Left + XMargin, _GraphLegendsRectangle.Bottom);
                _VerticalPrimaryAxeRectangle.Size = new SizeF(VerticalPrimaryTickMaxTextSize.Width + AxeTickSize, bounds.Height - (2 * YMargin) - _GraphTitleRectangle.Height - _GraphLegendsRectangle.Height - HorizontalAxeTickMaxTextSize.Width - AxeTickSize);
                if (!_VerticalPrimaryAxe.IsUsed)
                {
                    _VerticalPrimaryAxeRectangle.Width = 0;
                }
                //Vertical Secondary Axe
                _VerticalSecondaryAxeRectangle.Size = new SizeF(VerticalSecondaryTickMaxTextSize.Width + AxeTickSize, _VerticalPrimaryAxeRectangle.Height);
                if (_VerticalSecondaryAxe.IsUsed)
                {
                    _VerticalSecondaryAxeRectangle.Location = new PointF(bounds.Right - XMargin - VerticalSecondaryTickMaxTextSize.Width - AxeTickSize, _GraphLegendsRectangle.Bottom);
                }
                else
                {
                    _VerticalSecondaryAxeRectangle.Location = new PointF(bounds.Right - XMargin, _GraphLegendsRectangle.Bottom);
                    _VerticalSecondaryAxeRectangle.Width = 0;
                }
                //Horizontal Axe
                _HorizontalAxeRectangle.Location = new PointF(_VerticalPrimaryAxeRectangle.Right, _VerticalPrimaryAxeRectangle.Bottom);
                _HorizontalAxeRectangle.Size = new SizeF(_VerticalSecondaryAxeRectangle.Left - _VerticalPrimaryAxeRectangle.Right, HorizontalAxeTickMaxTextSize.Width + AxeTickSize);
                //Graph
                _GraphRectangle.Location = new PointF(_VerticalPrimaryAxeRectangle.Right, _VerticalPrimaryAxeRectangle.Top);
                _GraphRectangle.Size = new SizeF(_HorizontalAxeRectangle.Width, _VerticalPrimaryAxeRectangle.Height);

                //Calculate xFactor
                xFactor = _GraphRectangle.Width;
                if ((_HorizontalAxe.MaxValueDateTime.Ticks - _HorizontalAxe.MinValueDateTime.Ticks) != 0)
                {
                    xFactor /= (_HorizontalAxe.MaxValueDateTime.Ticks - _HorizontalAxe.MinValueDateTime.Ticks);
                }
                else
                {
                    xFactor /= _HorizontalAxe.MaxValueDateTime.Ticks; //Cannot be null
                }

                //Draw Horizontal Axe
                g.DrawLine(AxePen, _HorizontalAxeRectangle.Left, _HorizontalAxeRectangle.Top, _HorizontalAxeRectangle.Right, _HorizontalAxeRectangle.Top);
                //Draw ticks
                HorizontalAxeStringFormat = new StringFormat();
                HorizontalAxeStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                XCurrentDateTime = _HorizontalAxe.MinValueDateTime;
                XCurrentDateTime = XCurrentDateTime.AddDays(1);
                do
                {
                    HorizontalAxeTimeSpan = TimeSpan.FromTicks(XCurrentDateTime.Date.Ticks - _HorizontalAxe.MinValueDateTime.Ticks);
                    HorizontalTickPosition = _HorizontalAxeRectangle.Left + (HorizontalAxeTimeSpan.Ticks * xFactor);
                    g.DrawLine(AxePen, HorizontalTickPosition, _HorizontalAxeRectangle.Top - (AxeTickSize / 2),
                        HorizontalTickPosition, _HorizontalAxeRectangle.Top + (AxeTickSize / 2));
                    HorizontalAxeTickTextSize = g.MeasureString(XCurrentDateTime.Date.ToString(_DateTimeFormat), _AxeFont);
                    g.DrawString(XCurrentDateTime.Date.ToString(_DateTimeFormat), _AxeFont, Brushes.Black, new PointF(HorizontalTickPosition - (HorizontalAxeTickTextSize.Height / 2), _HorizontalAxeRectangle.Top + AxeTickSize), HorizontalAxeStringFormat);
                    XCurrentDateTime = XCurrentDateTime.AddDays(1);
                }
                while (XCurrentDateTime.CompareTo(_HorizontalAxe.MaxValueDateTime) < 0);

                //Display Graph Name
                g.DrawString(Name, _GraphFont, Brushes.Black, _GraphTitleRectangle);

                //Display Legends
                {
                    string AxeSymbol = string.Empty;
                    RectangleF GraphCurrentLegendRectangle = new RectangleF();
                    Rectangle TmpRectangle = new Rectangle();
                    float GraphLegendCurrentXPosition = bounds.Left + XMargin + ((_GraphLegendsRectangle.Width - GraphLegendsTotalSize.Width) / 2);
                    float GraphLegendCurrentYPosition = 0;
                    StringFormat GraphLegendSymbolStrgFormat = new StringFormat();
                    GraphLegendSymbolStrgFormat.Alignment = StringAlignment.Center;
                    GraphLegendSymbolStrgFormat.LineAlignment = StringAlignment.Center;
                    _GraphLegendRectangles.Clear();
                    foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
                    {
                        GraphCurrentLegendRectangle.Location = new PointF(GraphLegendCurrentXPosition, _GraphLegendsRectangle.Top);
                        GraphCurrentLegendRectangle.Height = GraphLegendsTotalSize.Height;
                        AxeSymbol = _VerticalPrimaryAxe.Contains(kvp.Value) ? Properties.Resources.PRIMARY_AXE_SYMBOL :
                            Properties.Resources.SECONDARY_AXE_SYMBOL;
                        GraphLegendCurrentYPosition = GraphCurrentLegendRectangle.Top;
                        GraphLegendCurrentYPosition += ((GraphLegendsTotalSize.Height - GraphLegendsSymbolsTotalSize.Height) / 2);
                        TmpRectangle.Location = new Point((int)GraphLegendCurrentXPosition, (int)GraphLegendCurrentYPosition);
                        TmpRectangle.Size = GraphLegendsSymbolsTotalSize.ToSize();
                        g.DrawRectangle(Pens.Black, TmpRectangle);
                        g.FillRectangle(Brushes.Black, TmpRectangle);
                        g.DrawString(AxeSymbol, GraphLegendSymbolFont, Brushes.White, TmpRectangle, GraphLegendSymbolStrgFormat);
                        GraphLegendCurrentXPosition += GraphLegendsSymbolsTotalSize.Width;
                        GraphLegendCurrentXPosition += 1;
                        GraphLegendCurrentYPosition = GraphCurrentLegendRectangle.Top;
                        GraphLegendCurrentYPosition += ((GraphLegendsTotalSize.Height - GraphLegendTextSizes[kvp.Key].Height) / 2);
                        TmpRectangle.Location = new Point((int)GraphLegendCurrentXPosition, (int)GraphLegendCurrentYPosition);
                        TmpRectangle.Size = GraphLegendTextSizes[kvp.Key].ToSize();
                        g.DrawString(kvp.Value.Label, _GraphLegendFont, new SolidBrush(kvp.Value.GraphColor), TmpRectangle, GraphLegendSymbolStrgFormat);
                        GraphCurrentLegendRectangle.Width = GraphLegendsSymbolsTotalSize.Width + 1 + GraphLegendTextSizes[kvp.Key].Width;
                        _GraphLegendRectangles.Add(kvp.Key, GraphCurrentLegendRectangle);
                        GraphLegendCurrentXPosition += GraphLegendTextSizes[kvp.Key].Width;
                        GraphLegendCurrentXPosition += GraphLegendXMargin;
                    }
                }

                //Display Vertical Axes
                yPrimaryAxeFactor = _GraphRectangle.Height;
                if ((_VerticalPrimaryAxe.MaxValue - _VerticalPrimaryAxe.MinValue) != 0)
                {
                    yPrimaryAxeFactor /= (_VerticalPrimaryAxe.MaxValue - _VerticalPrimaryAxe.MinValue);
                }
                else
                {
                    if (_VerticalPrimaryAxe.MaxValue != 0)
                    {
                        yPrimaryAxeFactor /= (_VerticalPrimaryAxe.MaxValue);
                    }
                    else
                    {
                        yPrimaryAxeFactor = 1;
                    }
                }

                ySecondaryAxeFactor = _GraphRectangle.Height;
                if ((_VerticalSecondaryAxe.MaxValue - _VerticalSecondaryAxe.MinValue) != 0)
                {
                    ySecondaryAxeFactor /= (_VerticalSecondaryAxe.MaxValue - _VerticalSecondaryAxe.MinValue);
                }
                else
                {
                    if (_VerticalSecondaryAxe.MaxValue != 0)
                    {
                        ySecondaryAxeFactor /= (_VerticalSecondaryAxe.MaxValue);
                    }
                    else
                    {
                        ySecondaryAxeFactor = 1;
                    }
                }

                g.DrawLine(AxePen, _VerticalPrimaryAxeRectangle.Right, _VerticalPrimaryAxeRectangle.Bottom, _VerticalPrimaryAxeRectangle.Right, _VerticalPrimaryAxeRectangle.Top);
                g.DrawLine(AxePen, _VerticalSecondaryAxeRectangle.Left, _VerticalSecondaryAxeRectangle.Bottom, _VerticalSecondaryAxeRectangle.Left, _VerticalSecondaryAxeRectangle.Top);

                VerticalStringFormat = new StringFormat();
                VerticalStringFormat.LineAlignment = StringAlignment.Center;

                if (_VerticalPrimaryAxe.IsUsed)
                {
                    VerticalStringFormat.Alignment = StringAlignment.Far;
                    yCurrentValue = Math.Ceiling(_VerticalPrimaryAxe.MinValue / _VerticalPrimaryAxe.MajorUnit) * _VerticalPrimaryAxe.MajorUnit;
                    do
                    {
                        if (yCurrentValue < _VerticalPrimaryAxe.MaxValue)
                        {
                            VerticalTickPosition = (float)(_VerticalPrimaryAxeRectangle.Bottom - ((yCurrentValue - _VerticalPrimaryAxe.MinValue) * yPrimaryAxeFactor));
                            g.DrawLine(PrimaryAxeTickPen, _VerticalPrimaryAxeRectangle.Right - (AxeTickSize / 2), VerticalTickPosition, _GraphRectangle.Right, VerticalTickPosition);
                            g.DrawString(yCurrentValue.ToString(), _AxeFont, Brushes.Black, new RectangleF(new PointF(_VerticalPrimaryAxeRectangle.Left, VerticalTickPosition - (VerticalPrimaryTickMaxTextSize.Height / 2)),
                                new SizeF(_VerticalPrimaryAxeRectangle.Width - (AxeTickSize / 2), VerticalPrimaryTickMaxTextSize.Height)), VerticalStringFormat);
                        }
                        yCurrentValue += _VerticalPrimaryAxe.MajorUnit;
                    }
                    while (yCurrentValue < _VerticalPrimaryAxe.MaxValue);
                };

                if (_VerticalSecondaryAxe.IsUsed)
                {
                    VerticalStringFormat.Alignment = StringAlignment.Near;
                    yCurrentValue = Math.Ceiling(_VerticalSecondaryAxe.MinValue / _VerticalSecondaryAxe.MajorUnit) * _VerticalSecondaryAxe.MajorUnit;
                    do
                    {
                        if (yCurrentValue < _VerticalSecondaryAxe.MaxValue)
                        {
                            VerticalTickPosition = (float)(_VerticalSecondaryAxeRectangle.Bottom - ((yCurrentValue - _VerticalSecondaryAxe.MinValue) * ySecondaryAxeFactor));
                            g.DrawLine(SecondaryAxeTickPen, _VerticalSecondaryAxeRectangle.Left + (AxeTickSize / 2), VerticalTickPosition, _GraphRectangle.Left, VerticalTickPosition);
                            g.DrawString(yCurrentValue.ToString(), _AxeFont, Brushes.Black, new RectangleF(new PointF(_VerticalSecondaryAxeRectangle.Left + (AxeTickSize / 2), VerticalTickPosition - (VerticalSecondaryTickMaxTextSize.Height / 2)),
                                new SizeF(_VerticalSecondaryAxeRectangle.Width - (AxeTickSize / 2), VerticalSecondaryTickMaxTextSize.Height)), VerticalStringFormat);
                        }
                        yCurrentValue += _VerticalSecondaryAxe.MajorUnit;
                    }
                    while (yCurrentValue < _VerticalSecondaryAxe.MaxValue);
                };

                //Display Graphs
                foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
                {
                    GraphPointsArray = kvp.Value.GetPointsArray(_HorizontalAxe, _VerticalPrimaryAxe.Contains(kvp.Value) ? _VerticalPrimaryAxe : _VerticalSecondaryAxe, _GraphRectangle);
                    if ((GraphPointsArray != null) && (GraphPointsArray.Length > 1))
                    {
                        g.DrawLines(new Pen(kvp.Value.GraphColor, (kvp.Key == _SelectedSerie) ? SelectedGraphPenWidth : GraphPenWidth), GraphPointsArray);
                    }
                }
            }
            else
            {
                g.DrawString(Name + ": " + Properties.Resources.ERROR_NOPOINTS, _GraphFont, Brushes.Red, bounds);
            }
            AxePen.Dispose();
            PrimaryAxeTickPen.Dispose();
            SecondaryAxeTickPen.Dispose();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //PointF[] GraphPointsArray = null;
            //bool IsSerieCliked = false;
            double MinimumDistance = double.MaxValue;
            double Distance;
            string SelectedSerieBackup = _SelectedSerie;

            _SelectedSerie = string.Empty;
            //Check if the Graph Title is clicked
            if (_GraphTitleRectangle.Contains(e.Location))
            {
                CloseGraphTitleTextBox();
                GraphTitleTextBox = new TextBox();
                GraphTitleTextBox.Location = new Point((int)_GraphTitleRectangle.Location.X, (int)_GraphTitleRectangle.Location.Y);
                GraphTitleTextBox.Width = (int)_GraphRectangle.Width;
                GraphTitleTextBox.TabIndex = 0;
                GraphTitleTextBox.Name = "GraphTitleTextBox";
                GraphTitleTextBox.KeyDown += new KeyEventHandler(GraphTitleTextBox_KeyDown);
                GraphTitleTextBox.Text = Name;
                this.Controls.Add(GraphTitleTextBox);
            }
            else if (_HorizontalAxeRectangle.Contains(e.Location))
            {
                CloseGraphTitleTextBox();
            }
            else if (_VerticalPrimaryAxeRectangle.Contains(e.Location))
            {
                CloseGraphTitleTextBox();
            }
            else if (_VerticalSecondaryAxeRectangle.Contains(e.Location))
            {
                CloseGraphTitleTextBox();
            }
            else
            {
                CloseGraphTitleTextBox();
                //Check if a Graph is cliked
                foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
                {
                    Distance = kvp.Value.GetMinimumDistance(new PointF((float)e.Location.X, (float)e.Location.Y));
                    if (Distance < MinimumDistance)
                    {
                        MinimumDistance = Distance;
                        _SelectedSerie = kvp.Key;
                    }

                    /*GraphPointsArray = kvp.Value.GetPointsArray(_HorizontalAxe, _VerticalPrimaryAxe.Contains(kvp.Value) ? _VerticalPrimaryAxe : _VerticalSecondaryAxe, _GraphRectangle);
                    for (int i = 0; i < GraphPointsArray.Length; i++)
                    {
                        if (((int)GraphPointsArray[i].X == e.Location.X) && ((int)GraphPointsArray[i].Y == e.Location.Y))
                        {
                            _SelectedSerie = kvp.Key;
                            IsSerieCliked = true;
                            Invalidate();
                            break;
                        }
                    }*/
                }
                /*if (!IsSerieCliked)
                {
                    _SelectedSerie = string.Empty;
                    Invalidate();
                }*/
                //Invalidate();
            }
            if (_SelectedSerie != SelectedSerieBackup) Invalidate();

            base.OnMouseClick(e);
        }

        protected void GraphTitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == '\r') && (GraphTitleTextBox != null))
            {
                CloseGraphTitleTextBox();
            }
        }

        private void CloseGraphTitleTextBox()
        {
            if (GraphTitleTextBox != null)
            {
                System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 éèàê_-]+$");
                System.Text.RegularExpressions.Match rxm = rx.Match(GraphTitleTextBox.Text);
                if (rxm.Success)
                {
                    this.Name = GraphTitleTextBox.Text;
                    this.Controls.Remove(GraphTitleTextBox);
                    GraphTitleTextBox.Dispose();
                    GraphTitleTextBox = null;
                }
                else
                {
                    MsgBox msgbox = new MsgBox(Properties.Resources.ERROR_BAD_GRAPH_NAME,
                                    Properties.Resources.ERROR,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msgbox.ShowDialog();
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
            {
                kvp.Value.ClearPointsArray();
            }
            _PointsSeries.Clear();
        }

        /// <summary>
        /// Add a Serie of points to the Graph Control.
        /// </summary>
        /// <param name="Key">A key used to identify the serie.</param>
        /// <param name="Axe">The vertical axe used to display the serie.</param>
        /// <param name="Label">The displayed label of the serie.</param>
        /// <param name="C">The color of the serie.</param>
        public void AddPointsSerie(string Key, Axes Axe, string Label, Color C)
        {
            PointsSerie PS;

            PS = new PointsSerie(Label, C);
            _HorizontalAxe.AddPointsSerie(Key, PS);
            switch (Axe)
            {
                case Axes.VerticalPrimary:
                    _PointsSeries.Add(Key, PS);
                    _VerticalPrimaryAxe.AddPointsSerie(Key, PS);
                    break;
                case Axes.VerticalSecondary:
                    _PointsSeries.Add(Key, PS);
                    _VerticalSecondaryAxe.AddPointsSerie(Key, PS);
                    break;
            }
        }

        /// <summary>
        /// Remove a Serie of points from the Graph Control.
        /// </summary>
        /// <param name="Key">The key of the serie to remove.</param>
        public void RemovePointsSerie(string Key)
        {
            PointsSerie PS;

            if (_PointsSeries.ContainsKey(Key))
            {
                PS = _PointsSeries[Key];
                PS.ClearPointsArray();
                _HorizontalAxe.RemovePointsSerie(Key);
                _VerticalPrimaryAxe.RemovePointsSerie(Key);
                _VerticalSecondaryAxe.RemovePointsSerie(Key);
                _PointsSeries.Remove(Key);
            }
        }

        /// <summary>
        /// Get a Serie.
        /// </summary>
        /// <param name="Key">The key of the serie to retrieve.</param>
        /// <returns></returns>
        public PointsSerie GetPointsSerie(string Key)
        {
            if (_PointsSeries.ContainsKey(Key))
            {
                return _PointsSeries[Key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Set the Axe of a Serie.
        /// </summary>
        /// <param name="Key">The key identifying the serie.</param>
        /// <param name="Axe">The vertical axe to be used for the serie.</param>
        public void SetSerieAxe(string Key, Axes VerticalAxe)
        {
            if (VerticalAxe == Axes.Horizontal)
            {
                throw new ArgumentException(Properties.Resources.ERROR_WRONG_AXE_TYPE);
            }

            if (_PointsSeries.ContainsKey(Key))
            {
                _VerticalPrimaryAxe.RemovePointsSerie(Key);
                _VerticalSecondaryAxe.RemovePointsSerie(Key);

                switch (VerticalAxe)
                {
                    case Axes.VerticalPrimary:
                        _VerticalPrimaryAxe.AddPointsSerie(Key, _PointsSeries[Key]);
                        break;
                    case Axes.VerticalSecondary:
                        _VerticalSecondaryAxe.AddPointsSerie(Key, _PointsSeries[Key]);
                        break;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// The Serie dictionary.
        /// </summary>
        public Dictionary<string, PointsSerie> PointsSeries
        {
            get
            {
                return _PointsSeries;
            }
        }

        /// <summary>
        /// The Primary Axe.
        /// </summary>
        public GraphAxe VerticalPrimaryAxe
        {
            get
            {
                return _VerticalPrimaryAxe;
            }
        }

        /// <summary>
        /// The Secondary Axe.
        /// </summary>
        public GraphAxe VerticalSecondaryAxe
        {
            get
            {
                return _VerticalSecondaryAxe;
            }
        }

      /*[Category("Data"), Description("Access to the serie.")]
        public PointsSerie Points
        {
            get
            {
                return _PointsSerie;
            }

            set
            {
                _PointsSerie = value;
                Invalidate();
            }
        }*/
    }

    public class PointsSerie
    {
        private double _YMinValue;
        private double _YMaxValue;
        private DateTime _XMinDateTime;
        private DateTime _XMaxDateTime;
        private List<GraphPoint> _GraphPoints;
        private Color _GraphColor;
        private string _Label;
        private PointF[] _PointsArray; //Contains the Graph's points converted to the display units
        private bool _IsDirty; //Used to know if the PointsArray is to be re-calculated or not when the GetPointsArray() method is called
        private double xFactor, yFactor, xOffset, yOffset;

        /// <summary>
        /// Initializes a new Serie of points, displayed in the default color black with no label.
        /// </summary>
        public PointsSerie()
        {
            Initialize();
            _GraphColor = Color.Black;
            _Label = string.Empty;
        }

        /// <summary>
        /// Initializes a new Serie of points, displayed in the specified color with no label.
        /// </summary>
        /// <param name="C">The color used to dispplay the Graph.</param>
        public PointsSerie(Color C)
        {
            Initialize();
            _Label = string.Empty;
            _GraphColor = C;
        }

        /// <summary>
        /// Initializes a new Serie of points, displayed in the specified color and label.
        /// </summary>
        /// <param name="Label">The label shown for the Graph.</param>
        /// <param name="C">The color used to dispplay the Graph.</param>
        public PointsSerie(string Label, Color C)
        {
            Initialize();
            _Label = Label;
            _GraphColor = C;
        }

        private void Initialize()
        {
            _YMinValue = float.MaxValue;
            _YMaxValue = 0;
            _XMinDateTime = DateTime.MaxValue;
            _XMaxDateTime = DateTime.MinValue;
            _GraphPoints = new List<GraphPoint>();
            _PointsArray = null;
            _IsDirty = false;
            xFactor = 1;
            yFactor = 1;
            xOffset = 0;
            yOffset = 0;
        }

        /// <summary>
        /// Add a point to the serie. The Y value being a float.
        /// </summary>
        /// <param name="t">The Date and Time of the point (X Axe).</param>
        /// <param name="Y">The Y value.</param>
        public void AddPointF(DateTime t, float Y)
        {
            AddPointCommon(t, Y);
        }

        /// <summary>
        /// Add a point to the serie. The Y value being a double.
        /// </summary>
        /// <param name="t">The Date and Time of the point (X Axe).</param>
        /// <param name="Y">The Y value.</param>
        public void AddPointD(DateTime t, double Y)
        {
            AddPointCommon(t, Y);
        }

        /// <summary>
        /// Add a point to the serie. The Y value being a string representing a float. Any invalid string will be discarded.
        /// </summary>
        /// <param name="t">The Date and Time of the point (X Axe).</param>
        /// <param name="Y">The Y value.</param>
        public void AddPointS(DateTime t, string Y)
        {
            float YF;

            if (float.TryParse(Y, out YF))
            {
                AddPointCommon(t, YF);
            }
        }

        private void AddPointCommon(DateTime t, double Y)
        {
            _GraphPoints.Add(new GraphPoint(t, Y));
            if (_XMinDateTime.CompareTo(t) > 0) _XMinDateTime = t;
            if (_XMaxDateTime.CompareTo(t) < 0) _XMaxDateTime = t;
            if (_YMinValue > Y) _YMinValue = Y;
            if (_YMaxValue < Y) _YMaxValue = Y;
            _IsDirty = true;
            //_VerticalAxe.AddValue(Y);
        }

        public PointF[] GetPointsArray(GraphAxe HorizontalAxe, GraphAxe VerticalAxe, RectangleF GraphRectangle)
        {
            double xFactor, yFactor, xOffset, yOffset;

            xFactor = GraphRectangle.Width;
            if ((HorizontalAxe.MaxValueDateTime.Ticks - HorizontalAxe.MinValueDateTime.Ticks) != 0)
            {
                xFactor /= (HorizontalAxe.MaxValueDateTime.Ticks - HorizontalAxe.MinValueDateTime.Ticks);
            }
            else
            {
                xFactor /= HorizontalAxe.MaxValueDateTime.Ticks; //Cannot be null
            }

            yFactor = GraphRectangle.Height;
            if ((VerticalAxe.MaxValue - VerticalAxe.MinValue) != 0)
            {
                yFactor /= (VerticalAxe.MaxValue - VerticalAxe.MinValue);
            }
            else
            {
                if (VerticalAxe.MaxValue != 0)
                {
                    yFactor /= VerticalAxe.MaxValue;
                }
                else
                {
                    yFactor = 1;
                }
            }
            yFactor *= -1; //Needed because Y drawing Axe is inverted

            xOffset = GraphRectangle.Left;

            yOffset = GraphRectangle.Bottom;

            if (_IsDirty || (this.xFactor != xFactor) || (this.yFactor != yFactor) || (this.xOffset != xOffset) || (this.yOffset != yOffset))
            {
                _PointsArray = new PointF[_GraphPoints.Count];

                for (int i = 0; i < _GraphPoints.Count; i++)
                {
                    _PointsArray[i].X = (_GraphPoints[i].t.Ticks - HorizontalAxe.MinValueDateTime.Ticks);
                    _PointsArray[i].X *= (float)xFactor;
                    _PointsArray[i].X += (float)xOffset;
                    if (YMaxValue != YMinValue)
                    {
                        _PointsArray[i].Y = (float)(_GraphPoints[i].Y - VerticalAxe.MinValue);
                    }
                    else
                    {
                        _PointsArray[i].Y = (float)_GraphPoints[i].Y;
                    }
                    _PointsArray[i].Y *= (float)yFactor;
                    _PointsArray[i].Y += (float)yOffset;
                }
                _IsDirty = false;
                this.xFactor = xFactor;
                this.yFactor = yFactor;
                this.xOffset = xOffset;
                this.yOffset = yOffset;
            }

            return _PointsArray;
        }

        /// <summary>
        /// Clear all points of the serie.
        /// </summary>
        public void ClearPointsArray()
        {
            _GraphPoints.Clear();
            _YMinValue = float.MaxValue;
            _YMaxValue = 0;
            _XMinDateTime = DateTime.MaxValue;
            _XMaxDateTime = DateTime.MinValue;
            _IsDirty = true;
        }

        /// <summary>
        /// Return the distance between the provided point and the closest point found on the Graph.
        /// </summary>
        /// <param name="p">The point to which the distance is calculated from. It is given in displayed units.</param>
        /// <returns></returns>
        public double GetMinimumDistance(PointF p)
        {
            double MinimumDistance = double.MaxValue;
            double Distance;
            if (_PointsArray != null)
            {
                for (int i = 0; i < _PointsArray.Length; i++)
                {
                    Distance = (Math.Pow(p.X - _PointsArray[i].X, 2) + Math.Pow(p.Y - _PointsArray[i].Y, 2));
                    if (Distance < MinimumDistance) MinimumDistance = Distance;
                }
                MinimumDistance = Math.Sqrt(MinimumDistance);
            }

            return MinimumDistance;
        }

        /// <summary>
        /// Returns the Minimum Y value for the serie. 
        /// </summary>
        public double YMinValue
        {
            get
            {
                return _YMinValue;
            }
        }

        /// <summary>
        /// Returns the Maximum Y value for the serie.
        /// </summary>
        public double YMaxValue
        {
            get
            {
                return _YMaxValue;
            }
        }

        /// <summary>
        /// Returns the Minimum Date and Time for the serie.
        /// </summary>
        public DateTime XMinDateTime
        {
            get
            {
                return _XMinDateTime;
            }
        }

        /// <summary>
        /// Returns the Maximum Date and Time for the serie.
        /// </summary>
        public DateTime XMaxDateTime
        {
            get
            {
                return _XMaxDateTime;
            }
        }

        /// <summary>
        /// Returns the Minimum Date and Time in ticks for the serie.
        /// </summary>
        public double XMinValue
        {
            get
            {
                return _XMinDateTime.Ticks;
            }
        }

        /// <summary>
        /// Returns the Maximum Date and Time in ticks for the serie.
        /// </summary>
        public double XMaxValue
        {
            get
            {
                return _XMaxDateTime.Ticks;
            }
        }

        /// <summary>
        /// Returns the color of the Graph.
        /// </summary>
        public Color GraphColor
        {
            get
            {
                return _GraphColor;
            }
            set
            {
                _GraphColor = value;
            }
        }

        /// <summary>
        /// Returns the label of the serie.
        /// </summary>
        public string Label
        {
            get
            {
                return _Label;
            }
            set
            {
                _Label = value;
            }
        }

        /// <summary>
        /// Return the number of points in the serie.
        /// </summary>
        public int Count
        {
            get
            {
                return _GraphPoints.Count;
            }
        }
    }

    public class GraphPoint
    {
        public DateTime t;
        public double Y;

        public GraphPoint()
        {
            t = DateTime.Now;
            Y = 0;
        }

        public GraphPoint(DateTime t, double Y)
        {
            this.t = t;
            this.Y = Y;
        }
    }

    public class GraphAxe
    {
        private double _MinValue;
        private double _MaxValue;
        private DateTime _MinDateTime;
        private DateTime _MaxDateTime;
        private Axes _AxeType;
        //private double _MinorUnit;
        private double _MajorUnit;
        private Dictionary<string, PointsSerie> _PointsSeries;

        /// <summary>
        /// Initialized a new Axe which is horizontal by dafault.
        /// </summary>
        public GraphAxe()
        {
            Initialize();
            _AxeType = Axes.Horizontal;
        }

        /// <summary>
        /// Initializes a new Axe of the specified type.
        /// </summary>
        /// <param name="AxeType">The type of Axe to intialize.</param>
        public GraphAxe(Axes AxeType)
        {
            Initialize();
            _AxeType = AxeType;
        }

        private void Initialize()
        {
            _MinValue = float.MaxValue;
            _MaxValue = float.MinValue;
            _MinDateTime = DateTime.MaxValue;
            _MaxDateTime = DateTime.MinValue;
            //_MinorUnit = 1;
            _MajorUnit = 1;
            _PointsSeries = new Dictionary<string, PointsSerie>();
        }

        /// <summary>
        /// Associate a serie to this axe.
        /// </summary>
        /// <param name="Key">A key for the serie to associate.</param>
        /// <param name="PS">The serie of points.</param>
        public void AddPointsSerie(string Key, PointsSerie PS)
        {
            _PointsSeries.Add(Key, PS);
        }

        /// <summary>
        /// Remove a serie from this axe.
        /// </summary>
        /// <param name="Key">The key of the serie to remove.</param>
        public void RemovePointsSerie(string Key)
        {
            if (_PointsSeries.ContainsKey(Key))
            {
                _PointsSeries.Remove(Key);
            }
        }

        /// <summary>
        /// Check if a serie is associated with this axe.
        /// </summary>
        /// <param name="PS">The serie of points</param>
        /// <returns></returns>
        public bool Contains(PointsSerie PS)
        {
            return _PointsSeries.ContainsValue(PS);
        }

        /*public Size GetAxe(float Factor, float Offset)
        {
            double Length;

            Length = _MaxValue - _MinValue;
            Length *= Factor;
            Length += Offset;

            return (new Size(Convert.ToInt32(Length), 0));
        }*/

        private void UpdateMinMax()
        {
            _MinValue = float.MaxValue;
            _MaxValue = float.MinValue;
            _MinDateTime = DateTime.MaxValue;
            _MaxDateTime = DateTime.MinValue;
            foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
            {
                if ((AxeType == Axes.VerticalPrimary) || (AxeType == Axes.VerticalSecondary))
                {
                    if (_MaxValue < kvp.Value.YMaxValue) _MaxValue = kvp.Value.YMaxValue;
                    if (_MinValue > kvp.Value.YMinValue) _MinValue = kvp.Value.YMinValue;
                }
                else if (AxeType == Axes.Horizontal)
                {
                    if (_MaxDateTime.CompareTo(kvp.Value.XMaxDateTime) < 0) _MaxDateTime = kvp.Value.XMaxDateTime;
                    if (_MinDateTime.CompareTo(kvp.Value.XMinDateTime) > 0) _MinDateTime = kvp.Value.XMinDateTime;
                }
            }
        }

        public double MaxValue
        {
            get
            {
                if (AxeType == Axes.Horizontal) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);
                UpdateMinMax();
                return _MaxValue;
            }
        }

        public double MinValue
        {
            get
            {
                if (AxeType == Axes.Horizontal) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);
                UpdateMinMax();
                return _MinValue;
            }
        }

        public DateTime MaxValueDateTime
        {
            get
            {
                if ((AxeType == Axes.VerticalPrimary) || (AxeType == Axes.VerticalSecondary)) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);
                UpdateMinMax();
                return _MaxDateTime;
            }
        }

        public DateTime MinValueDateTime
        {
            get
            {
                if ((AxeType == Axes.VerticalPrimary) || (AxeType == Axes.VerticalSecondary)) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);
                UpdateMinMax();
                return _MinDateTime;
            }
        }

        /*public double MinorUnit
        {
            get
            {
                return _MinorUnit;
            }
        }*/

        /// <summary>
        /// Returns the auto-calculated Major Unit for Vertical Axes.
        /// </summary>
        public double MajorUnit
        {
            get
            {
                int[] Divisions = { 1, 2, 5 }; //Sorted smaller to bigger

                if (AxeType == Axes.Horizontal) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);

                double NBDivisions, Multiplier;

                for (int i = 0; i < Divisions.Length; i++)
                {
                    Multiplier = 1;
                    NBDivisions = MaxValue - MinValue;
                    NBDivisions /= Divisions[i];
                    while (NBDivisions >= 1)
                    {
                        NBDivisions /= 10;
                        Multiplier *= 10;
                    };
                    NBDivisions *= 10;
                    Multiplier /= 10;
                    NBDivisions = Math.Floor(NBDivisions);
                    if ((NBDivisions >= 4) && (NBDivisions < 10))
                    {
                        _MajorUnit = Divisions[i] * Multiplier;
                        //_MajorUnit = (Math.Floor(((MaxValue - MinValue) / NBDivisions) / Multiplier)) * Multiplier;
                        break;
                    }
                }

                return _MajorUnit;
            }
        }

        /// <summary>
        /// Returns the auto-calculated Major Unit for the Horizontal Axe.
        /// </summary>
        public TimeSpan MajorUnitDateTime
        {
            get
            {                
                if ((AxeType == Axes.VerticalPrimary) || (AxeType == Axes.VerticalSecondary)) throw new ArgumentException(Properties.Resources.ERROR_WRONG_PROPERTY_USAGE_AXE);

                TimeSpan ts = new TimeSpan(MaxValueDateTime.Ticks - MinValueDateTime.Ticks);
                int MinNumberOfDivisions = 10;
                int MaxNumberOfDivisions = 25;
                
                if (ts.TotalDays >= MinNumberOfDivisions)
                {
                    return new TimeSpan(GetUnit(ts.TotalDays, MinNumberOfDivisions, MaxNumberOfDivisions), 0, 0, 0);
                }
                else if (ts.TotalHours >= MinNumberOfDivisions)
                {
                    return new TimeSpan(0, GetUnit(ts.TotalHours, MinNumberOfDivisions, MaxNumberOfDivisions), 0, 0);
                }
                else if (ts.TotalMinutes >= MinNumberOfDivisions)
                {
                    return new TimeSpan(0, 0, GetUnit(ts.TotalMinutes, MinNumberOfDivisions, MaxNumberOfDivisions), 0);
                }
                else
                {
                    return new TimeSpan(0, 0, 0, GetUnit(ts.TotalSeconds, MinNumberOfDivisions, MaxNumberOfDivisions));
                }
            }
        }

        private int GetUnit(double Value, int MinNumberOfDivisions, int MaxNumberOfDivisions)
        {
            int[] Divisions = { 1, 2, 5 }; //Sorted smaller to bigger
            double NBDivisions;
            int Multiplier = 1;
            int Unit = 1;

            for (int i = 0; i < Divisions.Length; i++)
            {
                Multiplier = 1;
                NBDivisions = Value;
                NBDivisions /= Divisions[i];
                while (NBDivisions >= 1)
                {
                    NBDivisions /= 10;
                    Multiplier *= 10;
                };
                NBDivisions *= 10;
                Multiplier /= 10;
                if ((NBDivisions >= 4) && (NBDivisions <= MaxNumberOfDivisions))
                {
                    Unit = Divisions[i] * Multiplier;
                    break;
                }
            }

            return Unit;
        }

        /// <summary>
        /// Returns the type of Axe.
        /// </summary>
        public Axes AxeType
        {
            get
            {
                return _AxeType;
            }
            set
            {
                _AxeType = value;
            }
        }

        /// <summary>
        /// Returns the information on whether there is at least one serie associated to this axe.
        /// </summary>
        public bool IsUsed
        {
            get
            {
                return (_PointsSeries.Count > 0);
            }
        }

        /// <summary>
        /// Return the PointsSerie names associated to the axe.
        /// </summary>
        public string[] PointsSeriesKeys
        {
            get
            {
                string[] Keys = new string[_PointsSeries.Keys.Count];
                int i = 0;

                foreach (KeyValuePair<string, PointsSerie> kvp in _PointsSeries)
                {
                    Keys[i] = kvp.Key;
                    i++;
                }

                return Keys;
            }
        }
    }

    /// <summary>
    /// The various Axe types.
    /// </summary>
    public enum Axes
    {
        Horizontal = 0,
        VerticalPrimary,
        VerticalSecondary
    }

    public enum AxeDirections
    {
        Horizontal = 0,
        Vertical
    }
}