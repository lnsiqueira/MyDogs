using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDog.Client.Service
{
    public interface IMyDogService
    {
        event Action OnChange;
        public List<MyDog.Shared.Breed> Breed { get; set; }
        public List<MyDog.Shared.MyDog> Dogs { get; set; }
        Task<List<MyDog.Shared.MyDog>> GetMyDogs(); 
        Task GetBreed();
        Task<MyDog.Shared.MyDog> GetMyDog(int id);
        Task<List<MyDog.Shared.MyDog>> CreateDog(MyDog.Shared.MyDog dog);
        Task<List<MyDog.Shared.MyDog>> UpdateDog(MyDog.Shared.MyDog dog, int id);
        Task<List<MyDog.Shared.MyDog>> DeleteDog(int id);
    }
}
