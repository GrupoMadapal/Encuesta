using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class LoginBLL
    {

        public void InsertNewLogin(Login param)
        {
            LoginDAL DAL = new LoginDAL();
            DAL.InsertNewLogin(param);
        }
        public int searchUser(Login param)
        {
            LoginDAL DAL = new LoginDAL();
            return DAL.searchUser(param);
        }
        public int ExistUser(Login param)
        {
            LoginDAL DAL = new LoginDAL();
            return DAL.ExistUser(param);
        }
        public Login SelectUser(Login param)
        {
            LoginDAL DAL = new LoginDAL();
            return DAL.SelectUser(param);
        }
        
        public Login GetPasswordByEmail(Login param)
        {
            LoginDAL DAL = new LoginDAL();
            return DAL.GetPasswordByEmail(param);
        }
    }
}