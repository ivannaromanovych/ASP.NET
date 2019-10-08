using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHelloBelkaContract;
using IHelloBelkaContract.Entities;

namespace HelloBelkaService
{
    public class HelloBelkaContractService : MarshalByRefObject, IHelloBelkaContract.IHelloBelkaContractService
    {
        EFContext _context = new EFContext();
        public List<User> AddUser(string name, string login, string password, bool gender)
        {
            _context.users.Add(new User()
            {
                Name = name,
                Login = login,
                Password = password,
                Gender = gender
            });
            return _context.users.ToList();
        }


        public string GetMessage(string name)
        {
            return $"Hello belka + {name} ";
        }

    }
}
