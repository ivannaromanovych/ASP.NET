using IHelloBelkaContract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHelloBelkaContract
{
    public interface IHelloBelkaContractService
    {
        string GetMessage(string name);
        List<User> AddUser(string name, string login, string password, bool gender);
    }
}
