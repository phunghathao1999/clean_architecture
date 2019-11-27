using ApplicationCore.DTO;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<PeopleDTO> GetPeople();
        IEnumerable<PeopleDTO> GetPeople(int pageIndex, int pageSize, int count);

        //bool CheckLogin(LoginDTO login);

        void CreatePeople(PeopleDTO people);
        void UpdatePeople(PeopleDTO people);
    }
}
