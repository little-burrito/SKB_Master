using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKB_Master {
    delegate void UpdateUICallback();
    public interface IUpdateUI {
        void UpdateUI();
    }
}
