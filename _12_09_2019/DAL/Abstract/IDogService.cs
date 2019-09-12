using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public delegate void AddDogDelegate(int count);
    public delegate void FindDogDelegate(Dog dog);
    public interface IDogService
    {
        void AddDogsRange(int count);
        void FindDog(string name);
        Task FindDogsAsync(Dog dog);
        Task AddDogsRangeAsync(int count);
        event AddDogDelegate AddDogEvent;
        event FindDogDelegate FindDogEvent;
    }
}
