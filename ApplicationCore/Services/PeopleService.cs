using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.EF;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeopleService(IUnitOfWork unit, IMapper mapper)
        {
            _unitOfWork = unit;
            _mapper = mapper;
        }

        public IEnumerable<PeopleDTO> GetPeople()
        {
            var people = _unitOfWork.People.GetAll();
            return _mapper.Map< IEnumerable<People>, IEnumerable<PeopleDTO>>(people);
        }

        public IEnumerable<PeopleDTO> GetPeople(int pageIndex, int pageSize, int count)
        {
            throw new System.NotImplementedException();
        }

        //public bool CheckLogin(LoginDTO login)
        //{
        //    var people = _unitOfWork.People.GetAll().Where(m => m.Account.Contains(login.Account) && m.Pass.Contains(login.Password));

        //    if (people == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var claims = new List<Claim>();
        //        claims.Add(new Claim(ClaimTypes.Name, login.Account));
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, "Login");
        //        HttpContext.SignInAsync(
        //            CookieAuthenticationDefaults.AuthenticationScheme,
        //            new ClaimsPrincipal(identity),
        //            new AuthenticationProperties
        //            {
        //                IsPersistent = true,
        //                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
        //            });
        //        return true;
        //    }
        //}

        public void CreatePeople(PeopleDTO people)
        {
            throw new System.NotImplementedException();
        }


        public void UpdatePeople(PeopleDTO people)
        {
            throw new System.NotImplementedException();
        }
    }
}
