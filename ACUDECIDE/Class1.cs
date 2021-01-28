using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using System.Collections;

namespace ACUDECIDE
{
    class Class1
    {

        #region Variables

        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        private PrintDocument _printDocument = new PrintDocument();
        private DataGridView gw = new DataGridView();
        private string _ReportHeader;
        private string _search;
        private int _count;
        #endregion

        public Class1(DataGridView gridview, string ReportHeader, int count, string search)
        {
            _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
            _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
            gw = gridview;
            _ReportHeader = ReportHeader;
            _count = count;
            _search = search;
        }

        public void PrintForm()
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = _printDocument;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                _printDocument.DocumentName = "AJAYI CROWTHER UNIVERSITY, OYO.";
                _printDocument.Print();
            }

            //////Open the print preview dialog
            ////PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            ////    objPPdialog.Document = _printDocument;
            ////    objPPdialog.ShowDialog();
        }

        private void _printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //Set the left margin
            int iLeftMargin = e.MarginBounds.Left;
            //Set the top margin
            int iTopMargin = e.MarginBounds.Top;
            //Whether more pages have to print or not
            bool bMorePagesToPrint = false;
            int iTmpWidth = 0;

            //For the first page to print set the cell width and header height
            if (bFirstPage)
            {
                foreach (DataGridViewColumn GridCol in gw.Columns)
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        (double)iTotalWidth * (double)iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                    iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                        GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                    // Save width and height of headers
                    arrColumnLefts.Add(iLeftMargin);

                    arrColumnWidths.Add(iTmpWidth);
                    iLeftMargin += iTmpWidth;
                }
            }
            //Loop till all the grid rows not get printed
            while (iRow <= gw.Rows.Count - 1)
            {
                DataGridViewRow GridRow = gw.Rows[iRow];
                //Set the cell height
                iCellHeight = GridRow.Height;
                int iCount = 0;
                //Check whether the current page settings allows more rows to print
                if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                {
                    bNewPage = true;
                    bFirstPage = false;
                    bMorePagesToPrint = true;
                    break;
                }
                else
                {

                    if (bNewPage)
                    {

                        Graphics graphic = e.Graphics;

                        Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

                        float fontHeight = font.GetHeight();

                        int startX = 150;
                        int startY = 10;
                        int offset = 50;
                        int offset1 = 30;
                        int offset2 = 40;
                        //   int height = dataGridView1.Height;
                        // String Counter = (dataGridView1.RowCount - 1).ToString();
                        String date = DateTime.Today.ToString("dd-MM-yyyy");

                        graphic.DrawString("AJAYI CROWTHER UNIVERSITY, OYO.", new Font("Courier New", 24), new SolidBrush(Color.DarkRed), 95, startY);
                        graphic.DrawString(" " + String.Format("{0}", _ReportHeader), new Font("Courier New", 16), new SolidBrush(Color.Black), 164, offset1 + 15);

                        graphic.DrawString("TOTAL VOTES : ".PadRight(10) + String.Format("{0}", _search), new Font("Courier New", 12), new SolidBrush(Color.Black), 95, offset1 + 40);
                        graphic.DrawString("No. CANDIDATES : ".PadRight(10) + String.Format("{0}", _count - 1), new Font("Courier New", 12), new SolidBrush(Color.Black), 460, offset1 + 40);
                        //graphic.DrawString("Total Votes : ".PadRight(10) + String.Format("{0}", _search), new Font("Courier New", 12), new SolidBrush(Color.Black), 95, offset1 + 60);

                        //Draw Header
                        //e.Graphics.DrawString(_ReportHeader,
                        //    new Font(gw.Font, FontStyle.Bold),
                        //    Brushes.Black, e.MarginBounds.Right,
                        //    e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                        //    new Font(gw.Font, FontStyle.Bold),
                        //    e.MarginBounds.Width).Height - 13);

                        //String strDate = "";
                        ////Draw Date
                        //e.Graphics.DrawString(strDate,
                        //    new Font(gw.Font, FontStyle.Bold), Brushes.Black,
                        //    e.MarginBounds.Right +
                        //    (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                        //    new Font(gw.Font, FontStyle.Bold),
                        //    e.MarginBounds.Width).Width),
                        //    e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                        //    new Font(new Font(gw.Font, FontStyle.Bold),
                        //    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                        //Draw Columns                 
                        iTopMargin = e.MarginBounds.Top;
                        DataGridViewColumn[] _GridCol = new DataGridViewColumn[gw.Columns.Count];
                        int colcount = 0;
                        //Convert ltr to rtl
                        foreach (DataGridViewColumn GridCol in gw.Columns)
                        {
                            _GridCol[colcount++] = GridCol;

                        }
                        for (int i = 0; i <= (_GridCol.Count() - 1); i++)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight + 5));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iHeaderHeight + 5));

                            e.Graphics.DrawString(_GridCol[i].HeaderText,
                                _GridCol[i].InheritedStyle.Font,
                                new SolidBrush(_GridCol[i].InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iHeaderHeight + 5), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight + 5;
                    }


                    iCount = 0;
                    DataGridViewCell[] _GridCell = new DataGridViewCell[GridRow.Cells.Count];
                    int cellcount = 0;
                    //Convert ltr to rtl
                    foreach (DataGridViewCell Cel in GridRow.Cells)
                    {
                        _GridCell[cellcount++] = Cel;
                    }
                    //Draw Columns Contents                
                    for (int i = 0; i <= (_GridCell.Count() - 1); i++)
                    {
                        if (_GridCell[i].Value != null)
                        {
                            e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                                _GridCell[i].InheritedStyle.Font,
                                new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount],
                                (float)iTopMargin,
                                (int)arrColumnWidths[iCount], (float)iCellHeight + 5),
                                strFormat);
                        }
                        //Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                            (int)arrColumnWidths[iCount], iCellHeight + 5));
                        iCount++;
                    }
                }
                iRow++;
                iTopMargin += iCellHeight + 5;
            }
            //If more lines exist, print another page.
            if (bMorePagesToPrint)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
            //       MessageBoxIcon.Error);
            //}
        }

        private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in gw.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
