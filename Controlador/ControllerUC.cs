using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Veterinaria.Controlador
{
    class ControllerUC
    {
        public void CargarUC(Grid grid, UserControl userControl)
        {
            if (grid.Children.Count != 0)
            {
                grid.Children.Clear();
                grid.Children.Add(userControl);
            }
            else
            {
                grid.Children.Add(userControl);
            }
        }
    }
}
