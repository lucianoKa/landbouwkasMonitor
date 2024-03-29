﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LBM
{
    public class StackedHeaderGenerator : IStackedHeaderGenerator
    {
        private static readonly StackedHeaderGenerator objInstance;

        static StackedHeaderGenerator()
        {
            objInstance = new StackedHeaderGenerator();
        }

        public static StackedHeaderGenerator Instance
        {
            get { return objInstance; }
        }

        private StackedHeaderGenerator()
        {
        }

        public StackedHeader GenerateStackedHeader(DataGridView objGridView)
        {
            StackedHeader objParentHeader = new StackedHeader();
            Dictionary<string, StackedHeader> objHeaderTree = new Dictionary<string, StackedHeader>();
            int iX = 0;
            foreach (DataGridViewColumn objColumn in objGridView.Columns)
            {
                string[] segments = objColumn.HeaderText.Split('.');
                if (segments.Length > 0)
                {
                    string segment = segments[0];
                    StackedHeader tempHeader, lastTempHeader = null;
                    if (objHeaderTree.ContainsKey(segment))
                    {
                        tempHeader = objHeaderTree[segment];
                    }
                    else
                    {
                        tempHeader = new StackedHeader { Name = segment, X = iX };
                        objParentHeader.Children.Add(tempHeader);
                        objHeaderTree[segment] = tempHeader;
                        tempHeader.ColumnId = objColumn.Index;
                    }
                    for (int i = 1; i < segments.Length; ++i)
                    {
                        segment = segments[i];
                        bool found = false;
                        foreach (StackedHeader child in tempHeader.Children)
                        {
                            if (0 == string.Compare(child.Name, segment, StringComparison.InvariantCultureIgnoreCase))
                            {
                                found = true;
                                lastTempHeader = tempHeader;
                                tempHeader = child;
                                break;
                            }
                        }
                        if (!found || i == segments.Length - 1)
                        {
                            StackedHeader temp = new StackedHeader
                            {
                                Name = segment,
                                X = iX,
                                ColumnId = objColumn.Index
                            };
                            if (found && i == segments.Length - 1 && null != lastTempHeader)
                            {
                                lastTempHeader.Children.Add(temp);
                            }
                            else
                            {
                                tempHeader.Children.Add(temp);
                            }
                            tempHeader = temp;
                        }
                    }
                }
                iX += objColumn.Width;
            }
            return objParentHeader;
        }
    }
}
