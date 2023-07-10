using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCLibrary
{
    public static class WCUtility
    {
        public static void SelectItemByValue(this ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i].ToString().Contains(value))
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
