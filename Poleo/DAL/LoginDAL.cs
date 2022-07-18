using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class LoginDAL
    {
        public ISqlMapper mapper;
        public void InsertNewLogin (Login param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertNewLogin", param);
        }
        public int searchUser(Login param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<int>("searchUser", param);
        }
        public int ExistUser(Login param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<int>("ExistUser", param);
        }
        public Login SelectUser(Login param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Login>("SelectUser", param);
        }
        public Login GetPasswordByEmail(Login param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Login>("GetPasswordByEmail", param);
        }
    }
}