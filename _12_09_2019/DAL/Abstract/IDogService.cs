using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public delegate void AddDogDelegate(int count);
    public interface IDogService
    {
        void AddDogsRange(int count);

        Task AddDogsRangeAsync(int count);
        event AddDogDelegate AddDogEvent;
    }
}
