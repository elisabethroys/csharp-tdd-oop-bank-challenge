using Boolean.CSharp.Main.Concrete.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class OverdraftRequests
    {
        private CurrentAccount _currentAccount;
        private decimal _limitRequest;
        public OverdraftRequests(CurrentAccount currentAccount, decimal limitRequest)
        {
            _currentAccount = currentAccount;
            _limitRequest = limitRequest;
        }

        public CurrentAccount CurrentAccount => _currentAccount;
        public decimal LimitRequest => _limitRequest;
    }
}
