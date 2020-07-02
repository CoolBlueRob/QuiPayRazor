using QuiPayRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Logic.Interfaces
{
    public interface IPaymentNotifier
    {
        void NotifyPaymentOffered(Payment payment);
    }
}
