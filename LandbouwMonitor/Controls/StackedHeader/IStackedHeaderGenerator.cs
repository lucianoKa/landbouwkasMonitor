using System.Windows.Forms;

namespace LBM
{
    public interface IStackedHeaderGenerator
    {
        StackedHeader GenerateStackedHeader(DataGridView objGridView);
    }
}
