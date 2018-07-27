using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class NoPaddingButton: Button
    {
        public NoPaddingButton()
        {

        }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; } 

    }
}
