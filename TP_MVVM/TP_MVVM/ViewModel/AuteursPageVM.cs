using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class AuteursPageVM
    {
        public ManagerVM ManagerVM { get; private set; }

        public AuteursPageVM(ManagerVM managerVM) {
            ManagerVM = managerVM;
        }

    }
}
